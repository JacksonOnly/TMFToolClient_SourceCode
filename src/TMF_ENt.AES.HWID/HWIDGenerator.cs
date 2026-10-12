using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace TMF_ENt.AES.HWID;

public class HWIDGenerator
{
	public static string GetCpuId()
	{
		try
		{
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select ProcessorId from Win32_Processor");
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
				return managementObject["ProcessorId"]?.ToString() ?? "未知";
			}
		}
		catch
		{
			return "未知";
		}
		return "未知";
	}

	public static string GetDiskId()
	{
		try
		{
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select SerialNumber from Win32_PhysicalMedia");
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
				return managementObject["SerialNumber"]?.ToString() ?? "未知";
			}
		}
		catch
		{
			return "未知";
		}
		return "未知";
	}

	public static string GetBiosId()
	{
		try
		{
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select SerialNumber from Win32_BIOS");
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
				return managementObject["SerialNumber"]?.ToString() ?? "未知";
			}
		}
		catch
		{
			return "未知";
		}
		return "未知";
	}

	public static string GetHWID()
	{
		try
		{
			string cpuId = GetCpuId();
			string diskId = GetDiskId();
			string biosId = GetBiosId();
			string s = cpuId + diskId + biosId;
			using MD5 mD = MD5.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			byte[] array = mD.ComputeHash(bytes);
			return BitConverter.ToString(array).Replace("-", "").ToLower();
		}
		catch
		{
			return "未知";
		}
	}
}
