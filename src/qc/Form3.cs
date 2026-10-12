using StyleLine = AntdUI.Tabs.StyleLine;
using IStyle = AntdUI.Tabs.IStyle;
using Button = AntdUI.Button;
using ContextMenuStrip = System.Windows.Forms.ContextMenuStrip;
using Message = AntdUI.Message;
using TabPage = AntdUI.TabPage;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;
using Newtonsoft.Json.Linq;
using SLA_Challenge;
using Sunny.UI;

namespace qc;

public class Form3 : Window
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public StringBuilder output;

		internal void _1(object sender, DataReceivedEventArgs e)
		{
			output.AppendLine(e.Data);
		}

		internal void _2(object sender, DataReceivedEventArgs e)
		{
			output.AppendLine(e.Data);
		}
	}

	private static object _0 = "5F4s81sbtO6KyhibL3dftN47fAbssNFH";

	public static string BaseUrl = "http://api.auth-xiaomi.com";

	public static string WumingeUrl = "https://api.wutools.net";

	private IntPtr m_3 = (IntPtr)0;

	private IntPtr m_4 = (IntPtr)0;

	private object m_5 = null;

	private object m_6;

	private object m_7;

	private object m_8;

	private object m_9;

	private object m_a;

	private object m_b;

	private object m_c;

	private object d;

	private object m_e;

	private object m_f;

	private object _10;

	private object m_11;

	private object m_12;

	private object m_13;

	private object m_14;

	private object m_15;

	private object m_16;

	private object m_17;

	private object m_18;

	private object m_19;

	private object _1a;

	private object m_1b;

	private object _1c;

	private object _1d;

	private object _1e;

	private object _1f;

	private object _20;

	private string Blob => ((Control)_20).Text;

	public Form3()
	{
		_1b();
	}

	public void SetToken(string token)
	{
		((Control)_20).Text = token;
	}

	private void _2(object sender, object e)
	{
		if (((Control)this.m_b).Text == "双击复制BLOB")
		{
		}
		((Control)this.m_b).Text = "";
		((Input)this.m_b).ForeColor = Color.Black;
	}

	private void _3(object sender, object e)
	{
		if (string.IsNullOrEmpty(((Control)this.m_b).Text))
		{
			((Control)this.m_b).Text = "双击复制BLOB";
			((Input)this.m_b).ForeColor = Color.Gray;
		}
	}

	private void _4(object sender, EventArgs e)
	{
	}

	private void _5(object sender, object e)
	{
		Clipboard.SetText(((Control)_20).Text);
	}

	private async void _6(object sender, object e)
	{
		object obj = Application.OpenForms.OfType<Form1>().FirstOrDefault();
		object obj2 = ((Control)this.m_b).Text.Trim();
		if (string.IsNullOrEmpty((string)obj2))
		{
			Message.warn((Form)obj, "是不是应该输入点什么呢?", (Font)null, (int?)null);
			return;
		}
		if (((string)obj2).Length != 512)
		{
			Message.error((Form)obj, "Sig长度校验失败！请不要携带空格", (Font)null, (int?)null);
			return;
		}
		try
		{
			object hexString = ((Control)this.m_b).Text.Trim();
			object bytes = _7(hexString);
			object obj3 = "C:\\TMFTool";
			if (!Directory.Exists((string)obj3))
			{
				Directory.CreateDirectory((string)obj3);
			}
			object path = Path.Combine((string)obj3, "sig.txt");
			File.WriteAllBytes((string)path, (byte[])bytes);
			object fileName = "C:\\TMFTool\\fastboot.exe";
			object obj4 = "C:\\TMFTool\\sig.txt";
			object obj5 = await _8(fileName, "stage \"" + (string)obj4 + "\"");
			if (obj == null)
			{
				return;
			}
			if (((string)obj5).Contains("OKAY"))
			{
				((Form1)obj).UpdateRichTextBox("写入签名成功", Color.Black);
				object path2 = Path.Combine("C:\\TMFTool", "sig.txt");
				if (File.Exists((string)path2))
				{
					File.Delete((string)path2);
				}
				((Control)this).Hide();
				if ((await _8(fileName, "oem edl")).Contains("OKAY"))
				{
					((Form1)obj).UpdateRichTextBox("进入EDL成功", Color.Black);
					((Form)this).Close();
				}
				else
				{
					((Form1)obj).UpdateRichTextBox("进入EDL失败", Color.Red);
					((Form)this).Close();
				}
			}
			else
			{
				((Form1)obj).UpdateRichTextBox("写入签名失败", Color.Red);
				object path3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sig.txt");
				if (File.Exists((string)path3))
				{
					File.Delete((string)path3);
				}
				((Form)this).Close();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("操作失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private object _7(object hexString)
	{
		if (string.IsNullOrWhiteSpace((string)hexString))
		{
			throw new ArgumentException("输入的sig为空或无效");
		}
		hexString = ((string)hexString).Replace(" ", "");
		if (((string)hexString).Length % 2 != 0)
		{
			throw new ArgumentException("傻逼sig长度不对");
		}
		byte[] array = new byte[((string)hexString).Length / 2];
		for (int i = 0; i < ((string)hexString).Length; i += 2)
		{
			string value = ((string)hexString).Substring(i, 2);
			array[i / 2] = Convert.ToByte(value, 16);
		}
		return array;
	}

	private async Task<string> _8(object fileName, object arguments)
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
		object obj = new Process
		{
			StartInfo = (ProcessStartInfo)startInfo
		};
		try
		{
			object CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass8_0();
			((_003C_003Ec__DisplayClass8_0)CS_0024_003C_003E8__locals4).output = new StringBuilder();
			((Process)obj).OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
			{
				((_003C_003Ec__DisplayClass8_0)CS_0024_003C_003E8__locals4).output.AppendLine(e.Data);
			};
			((Process)obj).ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
			{
				((_003C_003Ec__DisplayClass8_0)CS_0024_003C_003E8__locals4).output.AppendLine(e.Data);
			};
			((Process)obj).Start();
			((Process)obj).BeginOutputReadLine();
			((Process)obj).BeginErrorReadLine();
			await ((Process)obj).WaitForExitAsync();
			return ((_003C_003Ec__DisplayClass8_0)CS_0024_003C_003E8__locals4).output.ToString();
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private void _9(object sender, FormClosingEventArgs e)
	{
	}

	private void a(object sender, object e)
	{
		Config.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UITextBox)_20).ReadOnly = true;
	}

	private void b(object msg)
	{
		((Input)this.m_11).AppendText((string)msg + "\r\n");
	}

	private void c(object msg)
	{
		((Input)this.m_13).AppendText((string)msg + "\r\n");
	}

	public static string AesDecrypt(string DecryptStr, string Key)
	{
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Key);
			byte[] array = Convert.FromBase64String(DecryptStr);
			byte[] bytes2 = new RijndaelManaged
			{
				Key = bytes,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			}.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
			return Encoding.UTF8.GetString(bytes2);
		}
		catch (Exception)
		{
			return null;
		}
	}

	private void e()
	{
		((Input)this.m_11).Clear();
		((Input)this.m_13).Clear();
	}

	private async void f(object sender, object e)
	{
		object text = ((Control)d).Text;
		object text2 = ((Control)this.m_e).Text;
		if (((Control)d).Text == "" || ((Control)this.m_e).Text == "")
		{
			this.e();
			b("请填写账号或密码");
			return;
		}
		this.e();
		object obj = JObject.Parse(await Utlis.Request(BaseUrl + "/api/v1/Login?user=" + (string)text + "&password=" + (string)text2));
		if (((object)((JObject)obj)["code"]).ToString() == "200")
		{
			this.e();
			this.m_3 = (IntPtr)1;
			b("登录成功");
			b("FDL点数：[" + ((object)((JObject)obj)["creditfdl"]).ToString() + "]");
			Thread.Sleep(200);
		}
		else
		{
			b(((object)((JObject)obj)["msg"]).ToString());
		}
	}

	private async void _11(object sender, object e)
	{
		object text = ((Control)d).Text;
		object text2 = ((Control)this.m_e).Text;
		this.e();
		if (this.m_3 == (IntPtr)0)
		{
			this.e();
			b("请先登录账号!");
			return;
		}
		object obj = JObject.Parse(await Utlis.Request(BaseUrl + "/api/v1/Auth?user=" + (string)text + "&password=" + (string)text2 + "&blob=" + Blob + "&soc=fdl"));
		b(((object)((JObject)obj)["msg"]).ToString());
		if (((object)((JObject)obj)["code"]).ToString() == "200")
		{
			((Control)this.m_b).Text = ((object)((JObject)obj)["sign"]).ToString();
			_6(null, null);
		}
		else
		{
			b(((object)((JObject)obj)["msg"]).ToString());
		}
	}

	private async void _12(object sender, object e)
	{
		object text = ((Control)this.m_16).Text;
		object text2 = ((Control)this.m_15).Text;
		this.e();
		if ((string)text == "" || (string)text2 == "")
		{
			this.e();
			c("请填写账号或密码");
			return;
		}
		((Control)this.m_13).Text = "";
		object obj = JObject.Parse(await Utlis.wumingRequest(WumingeUrl + "/api.php?user=" + (string)text + "&password=" + (string)text2));
		if (((object)((JObject)obj)["code"]).ToString() == "200")
		{
			this.m_4 = (IntPtr)1;
			this.e();
			c("登录成功");
			c("FDL点数：[" + ((object)((JObject)obj)["fbprice"]).ToString() + "]");
			Thread.Sleep(200);
		}
		else
		{
			c(((object)((JObject)obj)["msg"]).ToString());
		}
	}

	private async void _13(object sender, object e)
	{
		object text = ((Control)this.m_16).Text;
		object text2 = ((Control)this.m_15).Text;
		this.e();
		if (this.m_4 == (IntPtr)0)
		{
			this.e();
			c("请先登录账号!");
			return;
		}
		object obj = JObject.Parse(await Utlis.wumingRequest(WumingeUrl + "/api.php?user=" + (string)text + "&password=" + (string)text2 + "&fb=" + Blob));
		if (((object)((JObject)obj)["code"]).ToString() == "200")
		{
			((Control)this.m_b).Text = ((object)((JObject)obj)["sig"]).ToString();
			c(((object)((JObject)obj)["msg"]).ToString());
			_6(null, null);
		}
		else
		{
			c(((object)((JObject)obj)["msg"]).ToString());
		}
	}

	private void _14(object sender, object e)
	{
		Clipboard.SetText(((Control)_20).Text);
	}

	private void _15(object sender, object e)
	{
		Clipboard.SetText(((Control)_20).Text);
	}

	private void _16(object sender, CancelEventArgs e)
	{
	}

	private void _17(object sender, CancelEventArgs e)
	{
	}

	private void _18(object sender, object e)
	{
		string text = Clipboard.GetText();
		((Control)this.m_b).Text = text;
	}

	private void _19(object sender, object e)
	{
		Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
		Clipboard.SetText(((Control)_20).Text);
		Message.success((Form)(object)form, "已复制剪切板！", (Font)null, (int?)null);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_5 != null)
		{
			((IDisposable)this.m_5).Dispose();
		}
		base.Dispose(disposing);
	}

	private void _1b()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected Obj, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Obj, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected Obj, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected Obj, but got Unknown
		this.m_5 = new Container();
		StyleLine style = new StyleLine();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form3));
		this.m_6 = (object)new WindowBar();
		this.m_7 = (object)new Tabs();
		this.m_8 = (object)new TabPage();
		_20 = (object)new UITextBox();
		this.m_c = (object)new Button();
		this.m_b = (object)new Input();
		_1e = new ContextMenuStrip((IContainer)this.m_5);
		_1f = new ToolStripMenuItem();
		this.m_9 = (object)new TabPage();
		this.m_17 = (object)new Button();
		this.m_18 = (object)new Button();
		_10 = (object)new Badge();
		this.m_11 = (object)new Input();
		this.m_f = (object)new Badge();
		this.m_e = (object)new Input();
		d = (object)new Input();
		this.m_a = (object)new TabPage();
		this.m_19 = (object)new Button();
		_1a = (object)new Button();
		this.m_12 = (object)new Badge();
		this.m_13 = (object)new Input();
		this.m_14 = (object)new Badge();
		this.m_15 = (object)new Input();
		this.m_16 = (object)new Input();
		_1c = new ContextMenuStrip((IContainer)this.m_5);
		_1d = new ToolStripMenuItem();
		this.m_1b = (object)new UIToolTip((IContainer)this.m_5);
		((Control)this.m_7).SuspendLayout();
		((Control)this.m_8).SuspendLayout();
		((Control)_1e).SuspendLayout();
		((Control)this.m_9).SuspendLayout();
		((Control)this.m_a).SuspendLayout();
		((Control)_1c).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)this.m_6).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((WindowBar)this.m_6).IsMax = false;
		((Control)this.m_6).Location = new Point(2, 1);
		((WindowBar)this.m_6).MaximizeBox = false;
		((Control)this.m_6).Name = "windowBar1";
		((Control)this.m_6).Size = new Size(495, 32);
		((WindowBar)this.m_6).SubText = "TMFTool";
		((Control)this.m_6).TabIndex = 67;
		((Control)this.m_6).Text = "MI Fastboot To EDL";
		((Control)this.m_7).Cursor = Cursors.Hand;
		((Control)this.m_7).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Tabs)this.m_7).Gap = 12;
		((Control)this.m_7).Location = new Point(11, 33);
		((Control)this.m_7).Name = "tabs2";
		((iCollection<TabPage>)(object)((Tabs)this.m_7).Pages).Add((TabPage)this.m_8);
		((iCollection<TabPage>)(object)((Tabs)this.m_7).Pages).Add((TabPage)this.m_9);
		((iCollection<TabPage>)(object)((Tabs)this.m_7).Pages).Add((TabPage)this.m_a);
		((Control)this.m_7).Size = new Size(478, 267);
		((Tabs)this.m_7).Style = (IStyle)(object)style;
		((Control)this.m_7).TabIndex = 70;
		((Control)this.m_7).Text = "tabs2";
		((Control)this.m_8).Controls.Add((Control)_20);
		((Control)this.m_8).Controls.Add((Control)this.m_c);
		((Control)this.m_8).Controls.Add((Control)this.m_b);
		((Control)this.m_8).Dock = DockStyle.Fill;
		((Control)this.m_8).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((TabPage)this.m_8).IconSvg = "";
		((Control)this.m_8).Location = new Point(3, 33);
		((Control)this.m_8).Name = "tabPage4";
		((Control)this.m_8).Size = new Size(472, 231);
		((Control)this.m_8).TabIndex = 69;
		((Control)this.m_8).Text = "计算";
		((UITextBox)_20).ButtonSymbol = 557677;
		((Control)_20).Cursor = Cursors.Default;
		((Control)_20).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_20).Location = new Point(4, 6);
		((Control)_20).Margin = new Padding(4, 5, 4, 5);
		((Control)_20).MinimumSize = new Size(1, 16);
		((Control)_20).Name = "uiTextBox1";
		((Control)_20).Padding = new Padding(5);
		((UITextBox)_20).ReadOnly = true;
		((UIUserControl)_20).RectColor = Color.FromArgb(224, 224, 224);
		((UITextBox)_20).ShowButton = true;
		((UIPanel)_20).ShowText = false;
		((Control)_20).Size = new Size(458, 28);
		((Control)_20).TabIndex = 76;
		((UIUserControl)_20).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)_20).Watermark = "";
		((UITextBox)_20).ButtonClick += _19;
		((Control)this.m_c).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_c).Location = new Point(0, 200);
		((Control)this.m_c).Name = "uiButton1";
		((Control)this.m_c).Size = new Size(462, 34);
		((Control)this.m_c).TabIndex = 71;
		((Control)this.m_c).Text = "Auth";
		((Button)this.m_c).Type = (TTypeMini)1;
		((Control)this.m_c).Click += _6;
		((IControl)this.m_b).Badge = "";
		((Control)this.m_b).ContextMenuStrip = (ContextMenuStrip)_1e;
		((Control)this.m_b).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_b).Location = new Point(3, 41);
		((Input)this.m_b).Multiline = true;
		((Control)this.m_b).Name = "textBox1";
		((Input)this.m_b).PlaceholderText = "Sign key";
		((Control)this.m_b).Size = new Size(459, 153);
		((Control)this.m_b).TabIndex = 3;
		((Input)this.m_b).WaveSize = 0;
		((ToolStrip)_1e).Items.AddRange(new ToolStripItem[1] { (ToolStripItem)_1f });
		((Control)_1e).Name = "contextMenuStrip1";
		((Control)_1e).Size = new Size(101, 26);
		((ToolStripDropDown)_1e).Opening += _16;
		((ToolStripItem)_1f).Name = "粘贴ToolStripMenuItem";
		((ToolStripItem)_1f).Size = new Size(100, 22);
		((ToolStripItem)_1f).Text = "粘贴";
		((ToolStripItem)_1f).Click += _18;
		((Control)this.m_9).Controls.Add((Control)this.m_17);
		((Control)this.m_9).Controls.Add((Control)this.m_18);
		((Control)this.m_9).Controls.Add((Control)_10);
		((Control)this.m_9).Controls.Add((Control)this.m_11);
		((Control)this.m_9).Controls.Add((Control)this.m_f);
		((Control)this.m_9).Controls.Add((Control)this.m_e);
		((Control)this.m_9).Controls.Add((Control)d);
		((Control)this.m_9).Dock = DockStyle.Fill;
		((Control)this.m_9).Location = new Point(3, 33);
		((Control)this.m_9).Name = "tabPage5";
		((Control)this.m_9).Size = new Size(472, 231);
		((Control)this.m_9).TabIndex = 0;
		((Control)this.m_9).Text = "TiMi自动";
		((Control)this.m_9).Visible = false;
		((Control)this.m_17).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_17).Location = new Point(232, 195);
		((Control)this.m_17).Name = "button3";
		((Control)this.m_17).Size = new Size(230, 34);
		((Control)this.m_17).TabIndex = 81;
		((Control)this.m_17).Text = "授权";
		((Button)this.m_17).Type = (TTypeMini)1;
		((Control)this.m_17).Click += _11;
		((Control)this.m_18).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_18).Location = new Point(0, 194);
		((Control)this.m_18).Name = "button2";
		((Control)this.m_18).Size = new Size(226, 34);
		((Control)this.m_18).TabIndex = 80;
		((Control)this.m_18).Text = "登录";
		((Button)this.m_18).Type = (TTypeMini)1;
		((Control)this.m_18).Click += f;
		((Control)_10).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_10).Location = new Point(0, 112);
		((Control)_10).Name = "badge1";
		((Control)_10).Size = new Size(43, 17);
		((Badge)_10).State = (TState)2;
		((Control)_10).TabIndex = 79;
		((Control)_10).Text = "日志";
		((IControl)this.m_11).Badge = "";
		((Control)this.m_11).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_11).Location = new Point(3, 129);
		((Input)this.m_11).Multiline = true;
		((Control)this.m_11).Name = "richTextBox1";
		((Input)this.m_11).PlaceholderText = "";
		((Input)this.m_11).ReadOnly = true;
		((Control)this.m_11).Size = new Size(459, 60);
		((Input)this.m_11).Status = (TType)1;
		((Control)this.m_11).TabIndex = 78;
		((Input)this.m_11).WaveSize = 0;
		((Control)this.m_f).Font = new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_f).Location = new Point(3, 3);
		((Control)this.m_f).Name = "badge2";
		((Control)this.m_f).Size = new Size(120, 32);
		((Badge)this.m_f).State = (TState)2;
		((Control)this.m_f).TabIndex = 73;
		((Control)this.m_f).Text = "账号登录TiMi";
		((IControl)this.m_e).Badge = "";
		((Control)this.m_e).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_e).Location = new Point(3, 76);
		((Control)this.m_e).Name = "textBox5";
		((Input)this.m_e).PasswordChar = '*';
		((Input)this.m_e).PlaceholderText = "密码";
		((Control)this.m_e).Size = new Size(459, 32);
		((Input)this.m_e).Status = (TType)1;
		((Control)this.m_e).TabIndex = 4;
		((Input)this.m_e).WaveSize = 0;
		((IControl)d).Badge = "";
		((Control)d).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)d).Location = new Point(3, 38);
		((Control)d).Name = "textBox4";
		((Input)d).PlaceholderText = "账户";
		((Control)d).Size = new Size(459, 32);
		((Input)d).Status = (TType)1;
		((Control)d).TabIndex = 3;
		((Input)d).WaveSize = 0;
		((Control)this.m_a).Controls.Add((Control)this.m_19);
		((Control)this.m_a).Controls.Add((Control)_1a);
		((Control)this.m_a).Controls.Add((Control)this.m_12);
		((Control)this.m_a).Controls.Add((Control)this.m_13);
		((Control)this.m_a).Controls.Add((Control)this.m_14);
		((Control)this.m_a).Controls.Add((Control)this.m_15);
		((Control)this.m_a).Controls.Add((Control)this.m_16);
		((Control)this.m_a).Dock = DockStyle.Fill;
		((Control)this.m_a).Location = new Point(3, 33);
		((Control)this.m_a).Name = "tabPage6";
		((Control)this.m_a).Size = new Size(472, 231);
		((Control)this.m_a).TabIndex = 0;
		((Control)this.m_a).Text = "Wuming 自动";
		((Control)this.m_a).Visible = false;
		((Control)this.m_19).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_19).Location = new Point(232, 194);
		((Control)this.m_19).Name = "button1";
		((Control)this.m_19).Size = new Size(230, 34);
		((Control)this.m_19).TabIndex = 86;
		((Control)this.m_19).Text = "授权";
		((Button)this.m_19).Type = (TTypeMini)1;
		((Control)this.m_19).Click += _13;
		((Control)_1a).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_1a).Location = new Point(0, 194);
		((Control)_1a).Name = "button4";
		((Control)_1a).Size = new Size(226, 34);
		((Control)_1a).TabIndex = 85;
		((Control)_1a).Text = "登录";
		((Button)_1a).Type = (TTypeMini)1;
		((Control)_1a).Click += _12;
		((Control)this.m_12).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_12).Location = new Point(3, 107);
		((Control)this.m_12).Name = "badge3";
		((Control)this.m_12).Size = new Size(59, 24);
		((Badge)this.m_12).State = (TState)2;
		((Control)this.m_12).TabIndex = 84;
		((Control)this.m_12).Text = "日志";
		((IControl)this.m_13).Badge = "";
		((Control)this.m_13).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_13).Location = new Point(3, 131);
		((Input)this.m_13).Multiline = true;
		((Control)this.m_13).Name = "richTextBox2";
		((Input)this.m_13).PlaceholderText = "";
		((Input)this.m_13).ReadOnly = true;
		((Control)this.m_13).Size = new Size(459, 57);
		((Input)this.m_13).Status = (TType)1;
		((Control)this.m_13).TabIndex = 83;
		((Input)this.m_13).WaveSize = 0;
		((Control)this.m_14).Font = new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_14).Location = new Point(3, 3);
		((Control)this.m_14).Name = "badge4";
		((Control)this.m_14).Size = new Size(159, 32);
		((Badge)this.m_14).State = (TState)2;
		((Control)this.m_14).TabIndex = 82;
		((Control)this.m_14).Text = "账号登录Wuming";
		((IControl)this.m_15).Badge = "";
		((Control)this.m_15).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_15).Location = new Point(3, 76);
		((Control)this.m_15).Name = "textBox2";
		((Input)this.m_15).PasswordChar = '*';
		((Input)this.m_15).PlaceholderText = "密码";
		((Control)this.m_15).Size = new Size(459, 32);
		((Input)this.m_15).Status = (TType)1;
		((Control)this.m_15).TabIndex = 81;
		((Input)this.m_15).WaveSize = 0;
		((IControl)this.m_16).Badge = "";
		((Control)this.m_16).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_16).Location = new Point(3, 38);
		((Control)this.m_16).Name = "textBox3";
		((Input)this.m_16).PlaceholderText = "账户";
		((Control)this.m_16).Size = new Size(459, 32);
		((Input)this.m_16).Status = (TType)1;
		((Control)this.m_16).TabIndex = 80;
		((Input)this.m_16).WaveSize = 0;
		((ToolStrip)_1c).Items.AddRange(new ToolStripItem[1] { (ToolStripItem)_1d });
		((Control)_1c).Name = "copy";
		((Control)_1c).Size = new Size(101, 26);
		((ToolStripDropDown)_1c).Opening += _17;
		((ToolStripItem)_1d).Name = "复制ToolStripMenuItem";
		((ToolStripItem)_1d).Size = new Size(100, 22);
		((ToolStripItem)_1d).Text = "复制";
		((ToolStripItem)_1d).Click += _15;
		((ToolTip)this.m_1b).BackColor = Color.FromArgb(54, 54, 54);
		((ToolTip)this.m_1b).ForeColor = Color.FromArgb(239, 239, 239);
		((ToolTip)this.m_1b).OwnerDraw = true;
		((ToolTip)this.m_1b).ToolTipTitle = "复制";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = AutoScaleMode.Font;
		((Form)this).ClientSize = new Size(497, 307);
		((Control)this).Controls.Add((Control)this.m_7);
		((Control)this).Controls.Add((Control)this.m_6);
		((Form)this).FormBorderStyle = FormBorderStyle.FixedDialog;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Form3";
		((Form)this).StartPosition = FormStartPosition.CenterScreen;
		((Control)(object)this).Text = "高通FASTBOOT踢EDL授权弹窗";
		((Form)this).Load += a;
		((Control)this.m_7).ResumeLayout(false);
		((Control)this.m_8).ResumeLayout(false);
		((Control)_1e).ResumeLayout(false);
		((Control)this.m_9).ResumeLayout(false);
		((Control)this.m_a).ResumeLayout(false);
		((Control)_1c).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}
}
