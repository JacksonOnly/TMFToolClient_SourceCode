using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal class DeviceHelper
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public DeviceHelper _003C_003E4__this;

		public byte[] recviceData;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public int bytesToRead;

		public _003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals1;

		internal int _1()
		{
			return ((SerialPort)CS_0024_003C_003E8__locals1._003C_003E4__this._1).Read(CS_0024_003C_003E8__locals1.recviceData, 0, bytesToRead);
		}
	}



	private object _1;

	public DeviceHelper(SerialPort serialPort)
	{
		_1 = serialPort;
		((SerialPort)_1).WriteTimeout = 5000;
	}

	public void Open()
	{
		((SerialPort)_1).Open();
	}

	public void Close()
	{
		((SerialPort)_1).Close();
		((Component)_1).Dispose();
	}

	public async Task<string> SendXml(string xml)
	{
		object bytes = Encoding.UTF8.GetBytes(xml.Trim());
		((SerialPort)_1).Write((byte[])bytes, 0, ((Array)bytes).Length);
		return await ReadFromDevice();
	}

	public void SendCommand(string command)
	{
		byte[] bytes = Encoding.Default.GetBytes(command);
		((SerialPort)_1).Write(bytes, 0, bytes.Length);
	}

	public void SendHex(string hex)
	{
		byte[] array = (byte[])b(hex.Trim());
		((SerialPort)_1).Write(array, 0, array.Length);
		Thread.Sleep(50);
	}

	public void WritePort(byte[] send, int offSet, int count)
	{
		int num = 0;
		Exception ex = new TimeoutException();
		bool flag = false;
		while (num++ <= 6 && ex != null && ex.GetType() == typeof(TimeoutException))
		{
			try
			{
				((SerialPort)_1).WriteTimeout = 2000;
				((SerialPort)_1).Write(send, offSet, count);
				flag = true;
				ex = null;
			}
			catch (TimeoutException ex2)
			{
				ex = ex2;
				Console.WriteLine("write time out try agian " + num);
				Thread.Sleep(500);
			}
			catch (Exception ex3)
			{
				Console.WriteLine("write failed: " + ex3.Message);
			}
		}
		if (!flag)
		{
			throw new Exception("write time out,maybe device was disconnected.");
		}
	}

	public string GetOutputStr()
	{
		string text = "";
		for (int i = 0; i < 5; i++)
		{
			text = text + ReadFromDevice()?.ToString() + "\r\n";
		}
		return text;
	}

	public async Task<string> ReadFromDevice()
	{
		object obj = new _003C_003Ec__DisplayClass10_0();
		((_003C_003Ec__DisplayClass10_0)obj)._003C_003E4__this = this;
		nint num = 10;
		((_003C_003Ec__DisplayClass10_0)obj).recviceData = null;
		while (true)
		{
			int num2 = (int)num;
			num = num2 - 1;
			if (num2 < 0)
			{
				break;
			}
			object CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass10_1();
			((_003C_003Ec__DisplayClass10_1)CS_0024_003C_003E8__locals10).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass10_0)obj;
			((_003C_003Ec__DisplayClass10_1)CS_0024_003C_003E8__locals10).bytesToRead = ((SerialPort)_1).BytesToRead;
			if (((_003C_003Ec__DisplayClass10_1)CS_0024_003C_003E8__locals10).bytesToRead > 0)
			{
				((_003C_003Ec__DisplayClass10_1)CS_0024_003C_003E8__locals10).CS_0024_003C_003E8__locals1.recviceData = new byte[((_003C_003Ec__DisplayClass10_1)CS_0024_003C_003E8__locals10).bytesToRead];
				await Task.Run(() => ((SerialPort)((_003C_003Ec__DisplayClass10_1)CS_0024_003C_003E8__locals10).CS_0024_003C_003E8__locals1._003C_003E4__this._1).Read(((_003C_003Ec__DisplayClass10_1)CS_0024_003C_003E8__locals10).CS_0024_003C_003E8__locals1.recviceData, 0, ((_003C_003Ec__DisplayClass10_1)CS_0024_003C_003E8__locals10).bytesToRead));
				if (((_003C_003Ec__DisplayClass10_1)CS_0024_003C_003E8__locals10).CS_0024_003C_003E8__locals1.recviceData.Length != 0)
				{
					return Encoding.Default.GetString(((_003C_003Ec__DisplayClass10_1)CS_0024_003C_003E8__locals10).CS_0024_003C_003E8__locals1.recviceData);
				}
			}
			await Task.Delay(50);
		}
		return string.Empty;
	}

	public byte[] ReadDataFromPort()
	{
		int num = 10;
		byte[] array = null;
		array = ReadPortData();
		while (num-- >= 0 && array == null)
		{
			Thread.Sleep(50);
			array = ReadPortData();
		}
		return array;
	}

	public byte[] ReadPortData()
	{
		byte[] result = null;
		if (((SerialPort)_1).IsOpen)
		{
			int bytesToRead = ((SerialPort)_1).BytesToRead;
			if (bytesToRead > 0)
			{
				result = new byte[bytesToRead];
				try
				{
					((SerialPort)_1).Read(result, 0, bytesToRead);
					return result;
				}
				catch (TimeoutException)
				{
					return result;
				}
			}
		}
		return result;
	}

	private object b(object hexString)
	{
		hexString = ((string)hexString).Replace(" ", "");
		if (((string)hexString).Length % 2 != 0)
		{
			hexString = (string)hexString + " ";
		}
		byte[] array = new byte[((string)hexString).Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Convert.ToByte(((string)hexString).Substring(i * 2, 2), 16);
		}
		return array;
	}
}
