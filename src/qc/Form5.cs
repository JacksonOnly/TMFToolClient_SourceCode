using Message = AntdUI.Message;
using TabPage = System.Windows.Forms.TabPage;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using AntdUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sunny.UI;
using TMF_ENt.AES;
using TMF_ENt.Http;

namespace qc;

public class Form5 : UIForm
{
	private static readonly object _0 = new HttpClient();

	private object m_1;

	public string SigKey = "LKHIKNIBUNUMI892";

	private object m_3 = null;

	private object m_4;

	private object m_5;

	private object _6;

	private object m_7;

	private object _8;

	private object _9;

	private object a;

	private object b;

	private object c;

	private object d;

	private object e;

	private object f;

	private object _10;

	public Form5(string api)
	{
		_7();
		this.m_1 = api;
	}

	private async void _1(object sender, object e)
	{
		((UIComboBox)this.e).SelectedIndex = 0;
		long num = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		object obj = $"timestamp={num}";
		object mD5Hash = AesHelper.GetMD5Hash((string)obj + SigKey);
		object obj2 = new
		{
			Timestamp = num,
			Sign = (string)mD5Hash
		};
		object plainText = JsonConvert.SerializeObject(obj2);
		object stringToEscape = AesHelper.Encrypt((string)plainText);
		object obj3 = Uri.EscapeDataString((string)stringToEscape);
		object obj4 = await HttpHelper.Get(Url: "/api/V2/eInfo?encryptedRequest=" + (string)obj3, api: (string)this.m_1);
		nint num2 = ((JToken)obj4).Value<int>((object)"code");
		object text = ((JToken)obj4).Value<string>((object)"message");
		object obj5 = ((JToken)obj4).Value<string>((object)"version");
		if (num2 == 200)
		{
			if (LoginFrom.lang == "en")
			{
				((Control)_8).Text = "Version:" + (string)obj5;
			}
			else
			{
				((Control)_8).Text = "当前版本:" + (string)obj5;
			}
			((UIRichTextBox)this.m_7).ReadOnly = true;
			((Control)this.m_7).Text = (string)text;
		}
		else
		{
			((Control)this.m_7).Text = (string)text;
		}
	}

	private void _2(object sender, object e)
	{
		string fileName = "https://www.yuque.com/tamim/llxpks/ugekwskoplui8gix?singleDoc#";
		Process.Start(fileName);
	}

	private void _3(object sender, object e)
	{
		if (((CheckBox)_10).Checked)
		{
			((UIDropControl)this.e).DropDownStyle = (UIDropDownStyle)0;
		}
		else
		{
			((UIDropControl)this.e).DropDownStyle = (UIDropDownStyle)1;
		}
	}

	private void _4(object sender, object e)
	{
		if (!((CheckBox)_10).Checked)
		{
			switch (((UIComboBox)this.e).SelectedItem.ToString())
			{
			case "官方线路":
				Apis.SetApi("http://xm.tmtft.cn");
				Message.success((Form)(object)this, "切换官方线路1成功！", (Font)null, (int?)null);
				return;
			case "WuMing专线":
				Apis.SetApi("http://110.40.52.117:9923");
				Message.success((Form)(object)this, "切换Wuming线路1成功！", (Font)null, (int?)null);
				return;
			case "WuMing专线2":
				Apis.SetApi("http://tmft.wutools.net");
				Message.success((Form)(object)this, "切换Wuming线路2成功！", (Font)null, (int?)null);
				return;
			case "TiMi专线":
				Apis.SetApi("http://tamim.llxll.cn");
				Message.success((Form)(object)this, "切换TiMi专线1成功！", (Font)null, (int?)null);
				return;
			}
		}
		if (string.IsNullOrEmpty(((Control)this.e).Text))
		{
			Message.error((Form)(object)this, "请输入线路！", (Font)null, (int?)null);
			return;
		}
		Apis.SetApi(((Control)this.e).Text);
		Message.success((Form)(object)this, "切换自定义线路成功！", (Font)null, (int?)null);
	}

	private void _5(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_3 != null)
		{
			((IDisposable)this.m_3).Dispose();
		}
		base.Dispose(disposing);
	}

	private void _7()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		this.m_4 = (object)new UITabControlMenu();
		this.m_5 = new TabPage();
		this.m_7 = (object)new UIRichTextBox();
		c = new TabPage();
		f = (object)new UIPanel();
		_10 = new CheckBox();
		e = (object)new UIComboBox();
		d = (object)new UISymbolButton();
		_6 = new TabPage();
		_9 = new GroupBox();
		b = (object)new UploadDragger();
		a = (object)new UILinkLabel();
		_8 = (object)new UISymbolLabel();
		((Control)this.m_4).SuspendLayout();
		((Control)this.m_5).SuspendLayout();
		((Control)c).SuspendLayout();
		((Control)f).SuspendLayout();
		((Control)_6).SuspendLayout();
		((Control)_9).SuspendLayout();
		((Control)this).SuspendLayout();
		((TabControl)this.m_4).Alignment = TabAlignment.Left;
		((Control)this.m_4).Controls.Add((Control)this.m_5);
		((Control)this.m_4).Controls.Add((Control)c);
		((Control)this.m_4).Controls.Add((Control)_6);
		((TabControl)this.m_4).DrawMode = TabDrawMode.OwnerDrawFixed;
		((Control)this.m_4).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UITabControlMenu)this.m_4).ItemSize = new Size(60, 40);
		((Control)this.m_4).Location = new Point(3, 35);
		((UITabControlMenu)this.m_4).MenuStyle = (UIMenuStyle)0;
		((TabControl)this.m_4).Multiline = true;
		((Control)this.m_4).Name = "uiTabControlMenu1";
		((TabControl)this.m_4).SelectedIndex = 0;
		((Control)this.m_4).Size = new Size(569, 351);
		((TabControl)this.m_4).SizeMode = TabSizeMode.Fixed;
		((UITabControlMenu)this.m_4).TabBackColor = Color.FromArgb(243, 249, 255);
		((Control)this.m_4).TabIndex = 0;
		((UITabControlMenu)this.m_4).TabSelectedColor = Color.White;
		((Control)this.m_5).BackColor = Color.White;
		((Control)this.m_5).Controls.Add((Control)this.m_7);
		((TabPage)this.m_5).Location = new Point(61, 0);
		((Control)this.m_5).Name = "tabPage1";
		((Control)this.m_5).Size = new Size(508, 351);
		((TabPage)this.m_5).TabIndex = 0;
		((Control)this.m_5).Text = "公告";
		((UIUserControl)this.m_7).FillColor = Color.White;
		((Control)this.m_7).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_7).Location = new Point(4, 5);
		((Control)this.m_7).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_7).MinimumSize = new Size(1, 1);
		((Control)this.m_7).Name = "textBox1";
		((Control)this.m_7).Padding = new Padding(2);
		((UIUserControl)this.m_7).RectColor = Color.Silver;
		((UIRichTextBox)this.m_7).ScrollBarStyleInherited = false;
		((UIPanel)this.m_7).ShowText = false;
		((Control)this.m_7).Size = new Size(500, 341);
		((Control)this.m_7).TabIndex = 0;
		((UIUserControl)this.m_7).TextAlignment = ContentAlignment.MiddleCenter;
		((Control)c).Controls.Add((Control)f);
		((Control)c).Font = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((TabPage)c).Location = new Point(61, 0);
		((Control)c).Name = "tabPage3";
		((Control)c).Size = new Size(508, 351);
		((TabPage)c).TabIndex = 2;
		((Control)c).Text = "线路";
		((TabPage)c).UseVisualStyleBackColor = true;
		((Control)f).Controls.Add((Control)_10);
		((Control)f).Controls.Add((Control)e);
		((Control)f).Controls.Add((Control)d);
		((UIUserControl)f).FillColor = Color.Transparent;
		((Control)f).Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)f).Location = new Point(12, 10);
		((Control)f).Margin = new Padding(4, 5, 4, 5);
		((Control)f).MinimumSize = new Size(1, 1);
		((Control)f).Name = "uiPanel1";
		((Control)f).Size = new Size(479, 328);
		((Control)f).TabIndex = 37;
		((Control)f).Text = null;
		((UIUserControl)f).TextAlignment = ContentAlignment.MiddleCenter;
		((Control)_10).AutoSize = true;
		((Control)_10).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_10).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)_10).Location = new Point(300, 173);
		((Control)_10).Name = "checkBox1";
		((Control)_10).Size = new Size(75, 21);
		((Control)_10).TabIndex = 37;
		((Control)_10).Text = "手动输入";
		((ButtonBase)_10).UseVisualStyleBackColor = true;
		((CheckBox)_10).CheckedChanged += _3;
		((UIComboBox)e).DataSource = null;
		((UIDropControl)e).DropDownStyle = (UIDropDownStyle)1;
		((UIUserControl)e).FillColor = Color.White;
		((Control)e).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)e).ForeColor = Color.DodgerBlue;
		((UIComboBox)e).ItemHoverColor = Color.FromArgb(155, 200, 255);
		((UIComboBox)e).Items.AddRange(new object[2] { "官方线路", "WuMing专线" });
		((UIComboBox)e).ItemSelectForeColor = Color.FromArgb(235, 243, 255);
		((Control)e).Location = new Point(77, 116);
		((Control)e).Margin = new Padding(4, 5, 4, 5);
		((Control)e).MinimumSize = new Size(63, 0);
		((Control)e).Name = "comboBox2";
		((Control)e).Padding = new Padding(0, 0, 30, 2);
		((UIUserControl)e).RectColor = Color.Silver;
		((Control)e).Size = new Size(298, 24);
		((UIDropControl)e).SymbolSize = 24;
		((Control)e).TabIndex = 36;
		((UIUserControl)e).TextAlignment = ContentAlignment.MiddleLeft;
		((UIDropControl)e).Watermark = "URL";
		((Control)d).Cursor = Cursors.Hand;
		((UIButton)d).FillColor = Color.LightSkyBlue;
		((UIButton)d).FillColor2 = Color.LightSkyBlue;
		((UIButton)d).FillHoverColor = SystemColors.GradientActiveCaption;
		((Control)d).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIButton)d).LightColor = Color.FromArgb(14, 30, 63);
		((Control)d).Location = new Point(14, 285);
		((Control)d).MinimumSize = new Size(1, 1);
		((Control)d).Name = "uiSymbolButton1";
		((UIButton)d).RectColor = Color.FromArgb(192, 255, 255);
		((UIButton)d).RectHoverColor = Color.FromArgb(224, 224, 224);
		((Control)d).Size = new Size(451, 28);
		((UIControl)d).Style = (UIStyle)0;
		((UISymbolButton)d).Symbol = 362845;
		((Control)d).TabIndex = 1;
		((Control)d).Text = "切换线路";
		((UIButton)d).TipsFont = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)d).Click += _4;
		((Control)_6).BackColor = Color.White;
		((Control)_6).Controls.Add((Control)_9);
		((TabPage)_6).Location = new Point(61, 0);
		((Control)_6).Name = "tabPage2";
		((Control)_6).Size = new Size(508, 351);
		((TabPage)_6).TabIndex = 1;
		((Control)_6).Text = "关于";
		((Control)_9).Controls.Add((Control)b);
		((Control)_9).Controls.Add((Control)a);
		((Control)_9).Controls.Add((Control)_8);
		((Control)_9).Location = new Point(22, 18);
		((Control)_9).Name = "groupBox1";
		((Control)_9).Size = new Size(463, 313);
		((Control)_9).TabIndex = 1;
		((GroupBox)_9).TabStop = false;
		((Control)_9).Text = "关于";
		((Control)b).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)b).Location = new Point(15, 20);
		((Control)b).Name = "uploadDragger";
		((Control)b).Size = new Size(432, 203);
		((Control)b).TabIndex = 37;
		((Control)b).Text = "关于软件";
		((UploadDragger)b).TextDesc = "获取到的信息";
		((LinkLabel)a).ActiveLinkColor = Color.FromArgb(80, 160, 255);
		((Control)a).Cursor = Cursors.Hand;
		((Control)a).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)a).ForeColor = Color.FromArgb(48, 48, 48);
		((LinkLabel)a).LinkBehavior = LinkBehavior.AlwaysUnderline;
		((UILinkLabel)a).LinkColor = Color.DeepSkyBlue;
		((Control)a).Location = new Point(360, 263);
		((Control)a).Name = "uiLinkLabel1";
		((Control)a).Size = new Size(77, 23);
		((Control)a).TabIndex = 1;
		((LinkLabel)a).TabStop = true;
		((Control)a).Text = "购买经销商";
		((LinkLabel)a).VisitedLinkColor = Color.FromArgb(230, 80, 80);
		((Control)a).Click += _2;
		((Control)_8).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_8).Location = new Point(15, 256);
		((Control)_8).MinimumSize = new Size(1, 1);
		((Control)_8).Name = "uiSymbolLabel1";
		((Control)_8).Size = new Size(189, 30);
		((UISymbolLabel)_8).Symbol = 61568;
		((Control)_8).TabIndex = 0;
		((Control)_8).Text = "版本";
		((ContainerControl)this).AutoScaleMode = AutoScaleMode.None;
		((Form)this).ClientSize = new Size(575, 386);
		((Control)this).Controls.Add((Control)this.m_4);
		((Control)(object)this).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIBaseForm)this).MaximizeBox = false;
		((UIBaseForm)this).MinimizeBox = false;
		((Control)this).Name = "Form5";
		((Control)this).Padding = new Padding(0, 29, 0, 0);
		((Form)this).ShowIcon = false;
		((Control)(object)this).Text = "设置";
		((UIBaseForm)this).TitleColor = Color.LightSkyBlue;
		((UIBaseForm)this).TitleFont = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIBaseForm)this).TitleHeight = 29;
		((UIForm)this).ZoomScaleRect = new Rectangle(15, 15, 572, 385);
		((Form)this).Load += _1;
		((Control)this.m_4).ResumeLayout(false);
		((Control)this.m_5).ResumeLayout(false);
		((Control)c).ResumeLayout(false);
		((Control)f).ResumeLayout(false);
		((Control)f).PerformLayout();
		((Control)_6).ResumeLayout(false);
		((Control)_9).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}
}
