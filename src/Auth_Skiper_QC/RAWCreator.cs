using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Auth_Skiper_QC;

internal class RAWCreator
{
	private static object _0 = new string[159]
	{
		"98", "111", "111", "116", "45", "114", "101", "99", "111", "118",
		"101", "114", "121", "0", "0", "0", "0", "0", "0", "0",
		"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
		"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
		"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
		"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
		"0", "0", "0", "0", "114", "101", "99", "111", "118", "101",
		"114", "121", "10", "45", "45", "117", "112", "100", "97", "116",
		"101", "95", "112", "97", "99", "107", " 97", "103", "101", "61",
		"47", "115", "121", "115", "116", "101", "109", "47", "101", "116",
		"99", "47", "114", "101", "115", "116", "111", "114", "101", "95",
		"97", "108", "108", "95", "115", "101", "116", "116", "105", "110",
		"103", "115", "46", "115", "104", "47", "109", "111", "100", "101",
		"61", "114", "101", "115", "101", "116", "95", "115", "101", "116",
		"116", "105", "110", "103", "115", "10", "45", "45", "108", "111",
		"99", "97", "108", "101", "61", "67", "78", "10", "10"
	};

	private static object _1 = new string[118]
	{
		"98", "111", "111", "116", "45", "114", "101", "99", "111", "118",
		"101", "114", "121", "0", "0", "0", "0", "0", "0", "0",
		"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
		"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
		"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
		"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
		"0", "0", "0", "0", "114", "101", "99", "111", "118", "101",
		"114", "121", "10", "45", "45", "119", "105", "112", "101", "95",
		"100", "97", "116", "97", "10", "45", "45", "114", "101", "97",
		"115", "111", "110", "61", "97", "110", "100", "114", "111", "105",
		"100", "10", "45", "45", "108", "111", "99", "97", "108", "101",
		"61", "101", "110", "95", "85", "83", "10", "10"
	};

	private static object m_2;

	public static void CreatedRawProgram(List<RawPartition> listraw, string sFolder)
	{
		foreach (RawPartition item in listraw)
		{
			if (item.PhysicalNum == "0")
			{
				RawCheckAndCreate(listraw, "0", sFolder);
			}
			else if (item.PhysicalNum == "1")
			{
				RawCheckAndCreate(listraw, "1", sFolder);
			}
			else if (item.PhysicalNum == "2")
			{
				RawCheckAndCreate(listraw, "2", sFolder);
			}
			else if (item.PhysicalNum == "3")
			{
				RawCheckAndCreate(listraw, "3", sFolder);
			}
			else if (item.PhysicalNum == "4")
			{
				RawCheckAndCreate(listraw, "4", sFolder);
			}
			else if (item.PhysicalNum == "5")
			{
				RawCheckAndCreate(listraw, "5", sFolder);
			}
		}
	}

	public static void RawCheckAndCreate(List<RawPartition> listraw, string lun, string folder)
	{
		StreamWriter streamWriter = new StreamWriter(Path.Combine(folder, "rawprogram" + lun + ".xml"));
		streamWriter.WriteLine("<?xml version=\"1.0\" ?>");
		streamWriter.WriteLine("<data>");
		streamWriter.WriteLine("  <!--NOTE: TMFTool V1 2024-2025 by Tamim-->");
		foreach (RawPartition item in listraw)
		{
			if (item.PhysicalNum == lun)
			{
				streamWriter.WriteLine((string)_2(item.SectorSize, item.Name, item.PhysicalNum, item.NumSector, item.Start));
			}
		}
		streamWriter.WriteLine("</data>");
		streamWriter.Close();
	}

	private static object _2(object SecterSizeInByte, object label, object physicalnum, object numsector, object startsector)
	{
		int num = Convert.ToInt32((string)SecterSizeInByte);
		long num2 = Convert.ToInt64(Convert.ToInt64((string)numsector) * num) / 1024;
		long num3 = Convert.ToInt64((string)startsector);
		return string.Format("  <program SECTOR_SIZE_IN_BYTES=\"{0}\" file_sector_offset=\"0\"  filename=\"{1}\"  label=\"{2}\" num_partition_sectors=\"{3}\"  physical_partition_number=\"{4}\" readbackverify=\"false\" size_in_KB=\"{5}.0\" sparse=\"false\" start_byte_hex=\"{6}\" start_sector=\"{7}\"/>", SecterSizeInByte, (string)label + ".img", label, numsector, physicalnum, num2, "0x" + num3.ToString("x") + "000", startsector);
	}

	public static string SafeFormatXML(string sectorSize, string start_sector, string drive)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("<?xml version=\"1.0\" ?>");
		stringBuilder.AppendLine("<patches>");
		for (int i = 0; i < ((Array)_0).Length; i++)
		{
			stringBuilder.AppendLine(PatchCreate(sectorSize, i.ToString(), (string)((object[])_0)[i], start_sector, drive));
		}
		stringBuilder.AppendLine("</patches>");
		return stringBuilder.ToString();
	}

	public static string FormatXML(string sectorSize, string start_sector, string drive)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("<?xml version=\"1.0\" ?>");
		stringBuilder.AppendLine("<patches>");
		for (int i = 0; i < ((Array)_1).Length; i++)
		{
			stringBuilder.AppendLine(PatchCreate(sectorSize, i.ToString(), (string)((object[])_1)[i], start_sector, drive));
		}
		stringBuilder.AppendLine("</patches>");
		return stringBuilder.ToString();
	}

	public static string OnePlusFRP(string sectorSize, string start_sector, string drive)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("<?xml version=\"1.0\" ?>");
		stringBuilder.AppendLine("<patches>");
		for (int i = 0; i <= 128; i++)
		{
			stringBuilder.AppendLine(PatchCreate(sectorSize, i.ToString(), "0", start_sector, drive));
		}
		stringBuilder.AppendLine("</patches>");
		return stringBuilder.ToString();
	}

	public static string MasterClearXML(string sectorSize, string start_sector, string drive)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("<?xml version=\"1.0\" ?>");
		stringBuilder.AppendLine("<patches>");
		for (int i = 0; i < ((Array)RAWCreator.m_2).Length; i++)
		{
			stringBuilder.AppendLine(PatchCreate(sectorSize, i.ToString(), (string)((object[])RAWCreator.m_2)[i], start_sector, drive));
		}
		stringBuilder.AppendLine("</patches>");
		return stringBuilder.ToString();
	}

	public static string PatchCreate(string sectorSize, string byteoffset, string value, string start_sector, string lun)
	{
		return "<patch SECTOR_SIZE_IN_BYTES=\"" + sectorSize + "\" byte_offset=\"" + byteoffset + "\" filename=\"DISK\" physical_partition_number=\"" + lun + "\" size_in_bytes=\"1\" start_sector=\"" + start_sector + "\" value=\"" + value + "\"  what=\"Zero.\"/>";
	}

	static RAWCreator()
	{
		RAWCreator.m_2 = new string[135]
		{
			"98", "111", "111", "116", "45", "114", "101", "99", "111", "118",
			"101", "114", "121", "0", "0", "0", "0", "0", "0", "0",
			"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
			"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
			"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
			"0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
			"0", "0", "0", "0", "114", "101", "99", "111", "118", "101",
			"114", "121", "10", "45", "45", "119", "105", "112", "101", "95",
			"100", "97", "116", "97", "10", "45", "45", "114", "101", "97",
			"115", "111", "110", "61", "77", "97", "115", "116", "101", "114",
			"67", "108", "101", "97", "114", "67", "111", "110", "102", "105",
			"114", "109", "95", "117", "100", "105", "115", "107", "10", "45",
			"45", "108", "111", "99", "97", "108", "101", "61", "122", "104",
			"45", "67", "78", "10", "10"
		};
	}
}
