using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;

namespace RlinQualcomm;

internal class LinQcPortClass
{
	private static async Task<byte[]> _0(object SePort)
	{
		((SerialPort)SePort).ReadTimeout = 10000;
		object obj = new byte[8192];
		nint num;
		try
		{
			num = ((SerialPort)SePort).Read((byte[])obj, 0, ((Array)obj).Length);
		}
		catch (Exception)
		{
			((SerialPort)SePort).Close();
			((Component)SePort).Dispose();
			return null;
		}
		nint num2 = 10;
		if (num2 <= 0)
		{
		}
		object obj2 = new byte[num];
		Array.Copy((Array)obj, (Array)obj2, (int)num);
		return (byte[])obj2;
	}

	public static byte[] AsciiToHexCom(string strvar)
	{
		return Encoding.ASCII.GetBytes(strvar);
	}

	public static string HexToAscii(byte[] HexByte)
	{
		if (HexByte == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int[] array = new int[HexByte.Length];
		for (int i = 0; i < HexByte.Length; i++)
		{
			array[i] = HexByte[i];
		}
		for (int j = 0; j < array.Length; j++)
		{
			stringBuilder.Append((char)array[j]);
		}
		return stringBuilder.ToString();
	}

	public static async Task<int> ERasexml(SerialPort SePort, string xml)
	{
		try
		{
			if (!SePort.IsOpen)
			{
				return -1;
			}
			object obj = AsciiToHexCom(xml);
			SePort.WriteTimeout = 2000;
			SePort.Write((byte[])obj, 0, ((Array)obj).Length);
			await Task.Delay(800);
			object obj2 = HexToAscii(await _0(SePort));
			if (obj2 == null)
			{
				return 3;
			}
			if (((string)obj2).ToLower().Contains("ACK".ToLower()))
			{
				return 1;
			}
			return 2;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public static async Task<int> SenndXmls(SerialPort SePort, string xml)
	{
		try
		{
			if (!SePort.IsOpen)
			{
				return -1;
			}
			object obj = AsciiToHexCom(xml);
			SePort.WriteTimeout = 2000;
			SePort.Write((byte[])obj, 0, ((Array)obj).Length);
			await Task.Delay(800);
			object obj2 = HexToAscii(await _0(SePort));
			if (obj2 == null)
			{
				return 3;
			}
			if (((string)obj2).ToLower().Contains("ACK".ToLower()))
			{
				return 1;
			}
			if (((string)obj2).ToLower().Contains("calling handler for configure".ToLower()))
			{
				return 0;
			}
			if (((string)obj2).ToLower().Contains("MemoryName=\"UFS\"".ToLower()))
			{
				return 0;
			}
			return 2;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public static async Task<string> xmlinfo(SerialPort SePort, string xml)
	{
		try
		{
			if (!SePort.IsOpen)
			{
				return "端口未打开";
			}
			object obj = AsciiToHexCom(xml);
			SePort.WriteTimeout = 2000;
			SePort.Write((byte[])obj, 0, ((Array)obj).Length);
			await Task.Delay(800);
			object obj2 = HexToAscii(await _0(SePort));
			if (obj2 == null)
			{
				return "返回数据为空";
			}
			return (string)obj2;
		}
		catch (Exception ex)
		{
			object obj3 = ex;
			return "错误: " + ((Exception)obj3).Message;
		}
	}

	public static async Task<int> SendCon(SerialPort SePort, string xml)
	{
		try
		{
			if (!SePort.IsOpen)
			{
				return -1;
			}
			object obj = AsciiToHexCom(xml);
			SePort.WriteTimeout = 5000;
			SePort.Write((byte[])obj, 0, ((Array)obj).Length);
			await Task.Delay(300);
			object obj2 = HexToAscii(await _0(SePort));
			if (obj2 == null)
			{
				return 3;
			}
			if (((string)obj2).ToLower().Contains("error: only nop and sig tag can be recevied before authentication".ToLower()))
			{
				return 1;
			}
			if (((string)obj2).ToLower().Contains("calling handler for configure".ToLower()))
			{
				return 0;
			}
			if (((string)obj2).ToLower().Contains("ACK".ToLower()))
			{
				return 0;
			}
			if (((string)obj2).ToLower().Contains("MemoryName=\"eMMC\"".ToLower()))
			{
				return 4;
			}
			return 2;
		}
		catch (Exception)
		{
			return -1;
		}
	}
}
