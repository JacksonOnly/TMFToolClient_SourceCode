using System;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace TMF_ENt;

public class ComputerInfoHelper
{
	public static async Task<string> GetComputerInfoAsync()
	{
		object obj = new StringBuilder();
		object obj2 = Task.Run(() => (string)_1());
		object obj3 = Task.Run(() => (string)_2());
		object obj4 = Task.Run(() => (string)_3());
		object obj5 = Task.Run(() => (string)_4());
		object obj6 = Task.Run(() => (string)_5());
		await Task.WhenAll<string>((Task<string>)obj2, (Task<string>)obj3, (Task<string>)obj4, (Task<string>)obj5, (Task<string>)obj6);
		object obj7 = obj;
		((StringBuilder)obj7).AppendLine(await (Task<string>)obj2);
		object obj8 = obj;
		((StringBuilder)obj8).AppendLine(await (Task<string>)obj3);
		object obj9 = obj;
		((StringBuilder)obj9).AppendLine(await (Task<string>)obj4);
		object obj10 = obj;
		((StringBuilder)obj10).AppendLine(await (Task<string>)obj5);
		object obj11 = obj;
		((StringBuilder)obj11).AppendLine(await (Task<string>)obj6);
		return obj.ToString();
	}

	private static object _1()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("【操作系统信息】");
		try
		{
			ManagementScope managementScope = new ManagementScope("\\\\.\\root\\CIMV2");
			managementScope.Connect();
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, new ObjectQuery("SELECT Caption, Version, OSArchitecture, SerialNumber FROM Win32_OperatingSystem"));
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				stringBuilder.AppendLine(string.Format("操作系统: {0}", item["Caption"]));
				stringBuilder.AppendLine(string.Format("版本: {0}", item["Version"]));
				stringBuilder.AppendLine(string.Format("架构: {0}", item["OSArchitecture"]));
				stringBuilder.AppendLine(string.Format("序列号: {0}", item["SerialNumber"]));
			}
		}
		catch (Exception ex)
		{
			stringBuilder.AppendLine("获取操作系统信息失败: " + ex.Message);
		}
		return stringBuilder.ToString();
	}

	private static object _2()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("\n【处理器信息】");
		try
		{
			ManagementScope managementScope = new ManagementScope("\\\\.\\root\\CIMV2");
			managementScope.Connect();
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, new ObjectQuery("SELECT Name, NumberOfCores, NumberOfLogicalProcessors, Manufacturer FROM Win32_Processor"));
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				stringBuilder.AppendLine(string.Format("处理器: {0}", item["Name"]));
				stringBuilder.AppendLine(string.Format("核心数: {0}", item["NumberOfCores"]));
				stringBuilder.AppendLine(string.Format("逻辑处理器数: {0}", item["NumberOfLogicalProcessors"]));
				stringBuilder.AppendLine(string.Format("制造商: {0}", item["Manufacturer"]));
			}
		}
		catch (Exception ex)
		{
			stringBuilder.AppendLine("获取处理器信息失败: " + ex.Message);
		}
		return stringBuilder.ToString();
	}

	private static object _3()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("\n【内存信息】");
		try
		{
			ManagementScope managementScope = new ManagementScope("\\\\.\\root\\CIMV2");
			managementScope.Connect();
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, new ObjectQuery("SELECT Capacity, MemoryType, Manufacturer FROM Win32_PhysicalMemory"));
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				stringBuilder.AppendLine(string.Format("内存容量: {0} GB", Convert.ToUInt64(item["Capacity"]) / 1024 / 1024 / 1024));
				stringBuilder.AppendLine(string.Format("内存类型: {0}", item["MemoryType"]));
				stringBuilder.AppendLine(string.Format("制造商: {0}", item["Manufacturer"]));
			}
		}
		catch (Exception ex)
		{
			stringBuilder.AppendLine("获取内存信息失败: " + ex.Message);
		}
		return stringBuilder.ToString();
	}

	private static object _4()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("\n【硬盘信息】");
		try
		{
			ManagementScope managementScope = new ManagementScope("\\\\.\\root\\CIMV2");
			managementScope.Connect();
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, new ObjectQuery("SELECT Model, Size, InterfaceType FROM Win32_DiskDrive"));
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				stringBuilder.AppendLine(string.Format("硬盘型号: {0}", item["Model"]));
				stringBuilder.AppendLine(string.Format("硬盘大小: {0} GB", Convert.ToUInt64(item["Size"]) / 1024 / 1024 / 1024));
				stringBuilder.AppendLine(string.Format("接口类型: {0}", item["InterfaceType"]));
			}
		}
		catch (Exception ex)
		{
			stringBuilder.AppendLine("获取硬盘信息失败: " + ex.Message);
		}
		return stringBuilder.ToString();
	}

	private static object _5()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("\n【BIOS信息】");
		try
		{
			ManagementScope managementScope = new ManagementScope("\\\\.\\root\\CIMV2");
			managementScope.Connect();
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, new ObjectQuery("SELECT SMBIOSBIOSVersion, ReleaseDate, Manufacturer FROM Win32_BIOS"));
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				stringBuilder.AppendLine(string.Format("BIOS版本: {0}", item["SMBIOSBIOSVersion"]));
				stringBuilder.AppendLine(string.Format("发布日期: {0}", item["ReleaseDate"]));
				stringBuilder.AppendLine(string.Format("制造商: {0}", item["Manufacturer"]));
			}
		}
		catch (Exception ex)
		{
			stringBuilder.AppendLine("获取BIOS信息失败: " + ex.Message);
		}
		return stringBuilder.ToString();
	}
}
