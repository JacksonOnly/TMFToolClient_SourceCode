using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;

namespace XiaoMiFlash.code.Utility;

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
		if (!serialPort.IsOpen)
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
			_ = _5;
			int num = 0;
			Exception ex = new TimeoutException();
			bool flag = false;
			while (num++ <= 6 && ex != null && ex.GetType() == typeof(TimeoutException))
			{
				try
				{
					serialPort.WriteTimeout = 2000;
					serialPort.Write(send, offSet, count);
					flag = true;
					if (isWriteDump)
					{
						_19(send);
					}
					ex = null;
				}
				catch (TimeoutException ex2)
				{
					ex = ex2;
					Thread.Sleep(500);
				}
				catch (Exception)
				{
				}
			}
			if (!flag)
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
		}
		WritePort(bytes, 0, bytes.Length);
		if (checkAck)
		{
			return GetResponse(checkAck);
		}
		return false;
	}

	private uint e(object str, object substring)
	{
		if (((string)str).Contains((string)substring))
		{
			string text = ((string)str).Replace((string)substring, "");
			return (uint)((((string)str).Length - text.Length) / ((string)substring).Length);
		}
		return 0u;
	}

	public bool chkRspAck(out string msg)
	{
		msg = null;
		byte[] binary = (byte[])_13();
		string[] array = (string[])_1a(binary, 1u);
		string value = "<response value=\"ACK\"";
		int num = 10;
		while ((array.Length != 2 || array[1].IndexOf(value) < 0) && num-- >= 0)
		{
			Thread.Sleep(10);
			binary = (byte[])_13();
			array = (string[])_1a(binary, 1u);
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
		byte[] binary = (byte[])_13();
		string[] array = (string[])_1a(binary, 1u);
		string text = "<response value=\"ACK\"";
		int num = 10;
		while ((array.Length != 2 || array[1].IndexOf(text) < 0) && num-- >= 0)
		{
			Thread.Sleep(10);
			binary = (byte[])_13();
			array = (string[])_1a(binary, 1u);
		}
		if (array.Length == 2 && array[1].IndexOf(text) >= 0)
		{
			int i = (int)e(array[1], text);
			num = 10;
			for (; i < chunkCount * 2; i += (int)e(array[1], text))
			{
				if (num-- <= 0)
				{
					break;
				}
				Thread.Sleep(10);
				binary = (byte[])_13();
				array = (string[])_1a(binary, 1u);
			}
			if (chunkCount * 2 > i)
			{
				throw new Exception("ACK count don't match!");
			}
			CleanBuffer();
			writeCount = 0;
			return true;
		}
		msg = array[1];
		return false;
	}

	public byte[] getRecDataIgnoreExcep()
	{
		byte[] array = (byte[])_13();
		if (array != null && array.Length != 0 && isReadDump)
		{
			_19(array);
		}
		return array;
	}

	public byte[] getRecData()
	{
		byte[] array = (byte[])_13();
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

	private object _13()
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

	private uint _14()
	{
		bool flag = false;
		int num = 10;
		while (num-- > 0 && !flag)
		{
			byte[] binary = (byte[])_13();
			string[] array = (string[])_19(binary);
			flag = array.Length == 2 && array[1].IndexOf("<response value=\"ACK\" />") >= 0;
			Thread.Sleep(50);
		}
		return flag ? 1u : 0u;
	}

	public bool GetResponse(bool waiteACK)
	{
		bool result = false;
		if (!waiteACK)
		{
			return _13() != null;
		}

		if (waiteACK)
		{
			
		}
		List<XmlDocument> responseXml = GetResponseXml(waiteACK);
		_ = responseXml.Count;
		foreach (XmlDocument item in responseXml)
		{
			XmlNodeList childNodes = item.SelectSingleNode("data").ChildNodes;

			foreach (XmlNode item2 in childNodes)
			{
				if (item2.Name.ToLower() == "sig")
				{
					auth = item2.OuterXml.Replace("blob", "sig");
				}
				foreach (XmlAttribute attribute in item2.Attributes)
				{
					if (attribute.Name.ToLower() == "maxpayloadsizetotargetinbytes")
					{
						m_dwBufferSectors = Convert.ToInt32(attribute.Value) / intSectorSize;
					}
					if (attribute.Value.ToLower() == "ack")
					{
						result = true;
					}
					if (attribute.Value == "WARN: NAK: MaxPayloadSizeToTargetInBytes sent by host 1048576 larger than supported 16384")
					{
						result = true;
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
		return result;
	}

	private object _16()
	{
		return GetResponseXml(waiteACK: false);
	}

	public List<XmlDocument> GetResponseXml(bool waiteACK)
	{
		List<XmlDocument> list = new List<XmlDocument>();
		byte[] binary = (byte[])_13();
		string[] array = (string[])_1a(binary, waiteACK ? 1u : 0u);
		if (array.Length >= 2)
		{
			foreach (string item in Regex.Split(array[1], "\\<\\?xml").ToList())
			{
				if (!string.IsNullOrEmpty(item))
				{
					if (item.ToLower().IndexOf(edlAuthErr) >= 0)
					{
						needEdlAuth = true;
					}
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml("<?xml " + item);
					list.Add(xmlDocument);
				}
			}
		}
		return list;
	}

	private object _18()
	{
		byte[] binary = (byte[])_13();
		return ((object[])_19(binary))[1];
	}

	private object _19(object binary)
	{
		return _1a(binary, 0u);
	}

	private object _1a(object binary, uint waitACK)
	{
		if (binary == null)
		{
			return new string[2] { "", "" };
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		new StringBuilder();
		new StringBuilder();
		for (int i = 0; i < ((Array)binary).Length; i++)
		{
			stringBuilder2.Append(Convert.ToChar(((byte[])binary)[i]).ToString());
		}
		if (waitACK != 0)
		{
		}
		if ((int)(nint)_5 != 0)
		{
		}
		return new string[2]
		{
			stringBuilder.ToString(),
			stringBuilder2.ToString()
		};
	}
}
