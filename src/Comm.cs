using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;

public class Comm
{
	public int writeCount;

	public bool isReadDump = true;

	public bool isWriteDump;

	public bool ignoreResponse = true;

	public SerialPort serialPort;

	private IntPtr _5;

	public byte[] recData;

	private long _7;

	public int MAX_SECTOR_STR_LEN = 20;

	public int SECTOR_SIZE_UFS = 4096;

	public int SECTOR_SIZE_EMMC = 512;

	public int m_dwBufferSectors;

	public int intSectorSize;

	public string auth = "";

	public string edlAuthErr = "error: only nop and sig tag can be recevied before authentication";

	public bool needEdlAuth;

	public bool isSupportPartialReset;

	public bool isDdr4;

	public bool isDdr5;

	public string storageInfo = "";

	public bool isGetChipNum;

	public string chipNum = "";

	public bool IsOpen
	{
		get
		{
			int num = 20;
			while (num-- > 0 && !serialPort.IsOpen)
			{
				Thread.Sleep(50);
			}
			return serialPort.IsOpen;
		}
	}

	public Comm()
	{
		_5 = (IntPtr)0;
	}

	public bool isKeepReading()
	{
		return (byte)(nint)_5 != 0;
	}

	public void StartReading()
	{
		if (_5 == (IntPtr)0)
		{
			_5 = (IntPtr)1;
		}
	}

	public void StopReading()
	{
		if ((int)(nint)_5 != 0)
		{
			_5 = (IntPtr)0;
		}
	}

	public byte[] ReadPortData()
	{
		byte[] array = null;
		if (serialPort.IsOpen)
		{
			int bytesToRead = serialPort.BytesToRead;
			if (bytesToRead > 0)
			{
				array = new byte[bytesToRead];
				try
				{
					serialPort.Read(array, 0, bytesToRead);
				}
				catch (TimeoutException)
				{
				}
			}
		}
		return array;
	}

	public byte[] ReadPortData(int offset, int count)
	{
		byte[] array = new byte[count];
		try
		{
			serialPort.Read(array, offset, count);
		}
		catch (TimeoutException)
		{
		}
		return array;
	}

	public void Open()
	{
		Close();
		serialPort.Open();
		if (serialPort.IsOpen)
		{
		}
	}

	private void _8(object sender, object e)
	{
		int bytesToRead = serialPort.BytesToRead;
		recData = new byte[bytesToRead];
		_7 += bytesToRead;
		serialPort.Read(recData, 0, bytesToRead);
	}

	public void Close()
	{
		serialPort.Close();
	}

	public void CleanBuffer()
	{
		serialPort.DiscardOutBuffer();
		serialPort.DiscardInBuffer();
	}

	public void WritePort(byte[] send, int offSet, int count)
	{
		if (IsOpen)
		{
			bool flag = (byte)(nint)_5 != 0;
			int num = 0;
			Exception ex = new TimeoutException();
			bool flag2 = false;
			while (num++ <= 6 && ex != null && ex.GetType() == typeof(TimeoutException))
			{
				try
				{
					serialPort.WriteTimeout = 2000;
					serialPort.Write(send, offSet, count);
					flag2 = true;
					if (isWriteDump)
					{
						_19(send);
					}
					ex = null;
				}
				catch (Exception)
				{
				}
			}
			if (!flag2)
			{
				throw new Exception("write time out,maybe device was disconnected.");
			}
		}
		writeCount++;
	}

	public bool SendCommand(string command)
	{
		return SendCommand(command, checkAck: false);
	}

	public bool SendCommand(string command, bool checkAck)
	{
		byte[] bytes = Encoding.Default.GetBytes(command);
		if ((int)((nint)_5 | (checkAck ? 1 : 0)) != 0)
		{
			WritePort(bytes, 0, bytes.Length);
		}
		return checkAck && GetResponse(checkAck);
	}

	public bool SendCommandXML(string command)
	{
		byte[] bytes = Encoding.Default.GetBytes(command);
		WritePort(bytes, 0, bytes.Length);
		return true;
	}

	private uint f(object str, object substring)
	{
		if (!((string)str).Contains((string)substring))
		{
			return 0u;
		}
		string text = ((string)str).Replace((string)substring, "");
		return (uint)((((string)str).Length - text.Length) / ((string)substring).Length);
	}

	public bool chkRspAck(out string msg)
	{
		msg = null;
		string[] array = (string[])_19(_14(), 1u);
		string value = "<response value=\"ACK\"";
		int num = 10;
		while ((array.Length != 2 || array[1].IndexOf(value) < 0) && num-- >= 0)
		{
			Thread.Sleep(10);
			array = (string[])_19(_14(), 1u);
		}
		if (array.Length == 2 && array[1].IndexOf(value) >= 0)
		{
			CleanBuffer();
			return true;
		}
		msg = "did not detect ACK from target.";
		return false;
	}

	public bool chkRspAck(out string msg, int chunkCount)
	{
		msg = null;
		string[] array = (string[])_19(_14(), 1u);
		string text = "<response value=\"ACK\"";
		int num = 10;
		while ((array.Length != 2 || array[1].IndexOf(text) < 0) && num-- >= 0)
		{
			Thread.Sleep(10);
			array = (string[])_19(_14(), 1u);
		}
		if (array.Length != 2 || array[1].IndexOf(text) < 0)
		{
			msg = array[1];
			return false;
		}
		int i = (int)f(array[1], text);
		num = 10;
		string[] array2;
		for (; i < chunkCount * 2; i += (int)f(array2[1], text))
		{
			if (num-- <= 0)
			{
				break;
			}
			Thread.Sleep(10);
			array2 = (string[])_19(_14(), 1u);
		}
		if (chunkCount * 2 > i)
		{
			throw new Exception("ACK count don't match!");
		}
		CleanBuffer();
		writeCount = 0;
		return true;
	}

	public byte[] getRecDataIgnoreExcep()
	{
		byte[] array = (byte[])_14();
		if (array != null && array.Length != 0 && isReadDump)
		{
			_19(array);
		}
		return array;
	}

	public byte[] getRecData()
	{
		byte[] array = (byte[])_14();
		if (array == null)
		{
			throw new Exception("can not read from port " + serialPort.PortName);
		}
		if (array.Length != 0 && isReadDump)
		{
			_19(array);
		}
		return array;
	}

	private object _14()
	{
		int num = 10;
		recData = null;
		recData = ReadPortData();
		while (num-- >= 0 && recData == null)
		{
			Thread.Sleep(50);
			recData = ReadPortData();
		}
		return recData;
	}

	private uint _15()
	{
		bool flag = false;
		int num = 10;
		while (num-- > 0 && !flag)
		{
			string[] array = (string[])_19(_14());
			flag = array.Length == 2 && array[1].IndexOf("<response value=\"ACK\" />") >= 0;
			Thread.Sleep(50);
		}
		return flag ? 1u : 0u;
	}

	public bool GetResponse(bool waiteACK)
	{
		bool flag = false;
		if (!waiteACK)
		{
			return _14() != null;
		}
		int num = 2;
		if (waiteACK)
		{
			num = 32;
		}
		while (num-- > 0 && !flag)
		{
			List<XmlDocument> responseXml = GetResponseXml(waiteACK);
			int count = responseXml.Count;
			foreach (XmlDocument item in responseXml)
			{
				foreach (XmlElement childNode in item.SelectSingleNode("data").ChildNodes)
				{
					if (childNode.Name.ToLower() == "sig")
					{
						auth = childNode.OuterXml.Replace("blob", "sig");
					}
					foreach (XmlAttribute attribute in childNode.Attributes)
					{
						if (attribute.Name.ToLower() == "maxpayloadsizetotargetinbytes")
						{
							m_dwBufferSectors = Convert.ToInt32(attribute.Value) / intSectorSize;
						}
						if (attribute.Value.ToLower() == "ack")
						{
							flag = true;
						}
						if (attribute.Value == "WARN: NAK: MaxPayloadSizeToTargetInBytes sent by host 1048576 larger than supported 16384")
						{
							flag = true;
						}
						if (attribute.Value.Contains("0xC3 0x00 0x40 0x10 "))
						{
							isDdr4 = true;
						}
						if (attribute.Value.Contains("0xC3 0x00 0x31 0x10 "))
						{
							isDdr4 = true;
						}
						if (attribute.Value.Contains("0xC3 0x00 0x02 0x10 "))
						{
							isDdr4 = true;
						}
						if (attribute.Value.Contains("0xC3 0x00 0x00 0x10 "))
						{
							isDdr5 = true;
						}
						if (attribute.Value.Contains("0xC3 0x00 0x51 0x10 "))
						{
							isDdr5 = true;
						}
						if (attribute.Value.Contains("0xC3 0x00 0x32 0x10 "))
						{
							isDdr5 = true;
						}
						if (attribute.Value.Contains("UFS Inquiry Command Output"))
						{
							storageInfo = attribute.Value;
						}
						if (attribute.Value.Contains("INFO: quick_reset") && !isSupportPartialReset)
						{
							isSupportPartialReset = true;
						}
						if (attribute.Value.Contains("Chip serial num") && !isGetChipNum)
						{
							isGetChipNum = true;
							int num2 = attribute.Value.IndexOf('(') + 1;
							int num3 = attribute.Value.IndexOf(')');
							string text = attribute.Value.Substring(num2, num3 - num2);
							if (text.Length < 10)
							{
								int length = 10 - text.Length;
								string text2 = "00000000";
								text = text.Substring(0, 2) + text2.Substring(0, length) + text.Substring(2, text.Length - 2);
							}
							chipNum = text;
						}
					}
				}
			}
			if (waiteACK)
			{
				Thread.Sleep(50);
			}
		}
		return flag;
	}

	private object _17()
	{
		return GetResponseXml(waiteACK: false);
	}

	public List<XmlDocument> GetResponseXml(bool waiteACK)
	{
		List<XmlDocument> list = new List<XmlDocument>();
		string[] array = (string[])_19(_14(), waiteACK ? 1u : 0u);
		if (array.Length >= 2)
		{
			int num = array.Length - 2;
			for (int i = 0; i < num; i += 2)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(array[i] + array[i + 1]);
				list.Add(xmlDocument);
			}
		}
		return list;
	}

	private object _19(object binary, uint waitAck = 0u)
	{
		string[] array = Regex.Split(Encoding.Default.GetString((byte[])binary), "(?=<response)", RegexOptions.IgnoreCase);
		if ((((array.Length < 2) ? 1u : 0u) | waitAck) != 0)
		{
		}
		return array;
	}
}
