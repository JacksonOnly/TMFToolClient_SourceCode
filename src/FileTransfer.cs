using System;
using System.IO;
using System.IO.Ports;
using System.Text;

public class FileTransfer
{
	protected Stream fileStream;

	public byte[] filePath;

	public string portName;

	public long fileLength;

	public FileTransfer(string port, byte[] filePath)
	{
		portName = port;
		this.filePath = filePath;
		_2(filePath, 0u);
	}

	private uint _1(object filePath)
	{

		try
		{
			if (!Directory.Exists(Path.GetDirectoryName((string)filePath)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName((string)filePath));
			}
			if (!File.Exists((string)filePath))
			{
				File.Create((string)filePath).Close();
			}
			return 1u;
		}
		catch (Exception ex)
		{

			throw new Exception(ex.Message);
		}
	}

	private uint _2(object filePath, uint isWriteFile)
	{
		this.filePath = (byte[])filePath;

		try
		{
			fileLength = ((Array)filePath).Length;
			fileStream = ((isWriteFile == 0) ? new MemoryStream((byte[])filePath) : new MemoryStream((byte[])filePath));
			return 1u;
		}
		catch (Exception ex)
		{

			throw new Exception(ex.Message);
		}
	}

	public int transfer(SerialPort port, int offset, int size)
	{
		if (!port.IsOpen)
		{
			_ = port.PortName + " is not open";
			return 0;
		}
		int n = 0;
		byte[] bytesFromFile = GetBytesFromFile(offset, size, out n);
		port.Write(bytesFromFile, 0, size);
		return n;
	}

	public void closeTransfer()
	{
		if (fileStream != null)
		{
			fileStream.Close();
			fileStream.Dispose();
		}
	}

	public void SetBytesToFile(byte[] sendData, long offset)
	{
		try
		{
			long length = fileStream.Length;
			fileStream.Seek(offset, SeekOrigin.Begin);
			fileStream.Write(sendData, 0, sendData.Length);
		}
		catch (IOException)
		{
		}
	}

	public byte[] GetBytesFromFile(long offset, int size, out int n)
	{
		float num = 0f;
		long length = fileStream.Length;
		byte[] array = new byte[size];
		fileStream.Seek(offset, SeekOrigin.Begin);
		n = fileStream.Read(array, 0, size);
		num = (float)offset / (float)length;
		return array;
	}

	public void ReadFile(Comm portCnn, string strPartitionStartSector, string strPartitionSectorNumber, string pszImageFile, string strFileStartSector, string strFilesize, string strFileSectorOffset, string sector_size, string physical_partition_number, string addtionalFirehose, bool chkAck, int? chunkCount)
	{
		long num = Convert.ToInt64(strPartitionSectorNumber);
		if (num == 0)
		{
			num = 2147483647L;
		}
		Convert.ToInt64(strFileStartSector);
		long num2 = Convert.ToInt64(strFileSectorOffset);
		long num3 = Convert.ToInt64(sector_size);
		long num4 = Convert.ToInt64(physical_partition_number);
		string command = string.Format(Firehose.FIREHOSE_READ, num3, num, strPartitionStartSector, num4, strFilesize, addtionalFirehose);
		portCnn.SendCommand(command);
		bool flag = true;
		bool flag2 = false;
		long num5 = num2;
		while (true)
		{
			byte[] array = null;
			bool flag3 = false;
			byte[] recData = portCnn.getRecData();
			int num6 = portCnn.recData.Length;
			if (flag)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < num6; i++)
				{
					stringBuilder.Append(Convert.ToChar(recData[i]).ToString());
				}
				string text = stringBuilder.ToString();
				if (text.IndexOf("response value") >= 0)
				{
					if (text.IndexOf("response value=\"ACK\" rawmode=\"true\"") < 0)
					{
						break;
					}
					int startIndex = text.IndexOf("response value=\"ACK\" rawmode=\"true\"");
					int num7 = text.IndexOf("</data>", startIndex);

					flag3 = true;
					array = new byte[num6 - 7 - num7];
					Array.Copy(recData, num7 + 7, array, 0, num6 - num7 - 7);
					num6 = num6 - num7 - 7;
				}
			}
			else
			{
				array = recData;
				flag3 = true;
			}
			if (num6 - 210 > 0)
			{
				byte[] array2 = new byte[240];
				Array.Copy(array, num6 - 240, array2, 0, 240);
				StringBuilder stringBuilder2 = new StringBuilder();
				for (int j = 0; j < 240; j++)
				{
					stringBuilder2.Append(Convert.ToChar(array2[j]).ToString());
				}
				string text2 = stringBuilder2.ToString();
				if (text2.IndexOf("response value=\"ACK\" rawmode=\"false\"") >= 0)
				{
					int num8 = text2.IndexOf("<?xml version=\"1.0\"");
					flag2 = true;
					num6 -= 240 - num8;
					byte[] array3 = new byte[num6];
					Array.Copy(array, 0, array3, 0, num6);
					array = array3;
				}
			}
			if ((num6 > 0) & flag3)
			{
				SetBytesToFile(array, num5);
				num5 += num6;
			}
			if (flag2)
			{
				return;
			}
		}
		throw new Exception("did not detect ACK from target.");
	}
}
