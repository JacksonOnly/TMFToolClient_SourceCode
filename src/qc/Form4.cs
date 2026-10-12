using StyleLine = AntdUI.Tabs.StyleLine;
using IStyle = AntdUI.Tabs.IStyle;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using AntdUI;
using Sunny.UI;

namespace qc;

public class Form4 : Form
{
	private object _0;

	private object m_1 = "C:\\TMFTool";

	private object m_2;

	private object m_3;

	private object m_4 = null;

	private object _5;

	private object m_6;

	private object _7;

	private object _8;

	private object _9;

	public Form4(string api)
	{
		_6();
		this.m_3 = api;
	}

	private void _1(object sender, object e)
	{
		this.m_2 = Path.Combine((string)this.m_1, "adb.zip");
		_2();
	}

	private void _2()
	{
		string uriString = (string)this.m_3 + "/TMFTool/tools.zip";
		if (!Directory.Exists((string)this.m_1))
		{
			Directory.CreateDirectory((string)this.m_1);
		}
		_0 = new WebClient();
		((WebClient)_0).DownloadProgressChanged += _3;
		((WebClient)_0).DownloadFileCompleted += _4;
		try
		{
			((WebClient)_0).DownloadFileAsync(new Uri(uriString), (string)this.m_2);
		}
		catch (Exception ex)
		{
			MessageBox.Show("无法连接服务器: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.Exit();
		}
	}

	private void _3(object sender, object e)
	{
		((UIProcessBar)_7).Value = ((ProgressChangedEventArgs)e).ProgressPercentage;
	}

	private void _4(object sender, object e)
	{
		if (((AsyncCompletedEventArgs)e).Error == null)
		{
			try
			{
				ZipFile.ExtractToDirectory((string)this.m_2, (string)this.m_1);
				File.Delete((string)this.m_2);
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show("解压或删除操作失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
			}
		}
		else
		{
			MessageBox.Show("下载失败: " + ((AsyncCompletedEventArgs)e).Error.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.Exit();
		}
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_4 != null)
		{
			((IDisposable)this.m_4).Dispose();
		}
		base.Dispose(disposing);
	}

	private void _6()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form4));
		_5 = (object)new UILabel();
		this.m_6 = (object)new WindowBar();
		_7 = (object)new UIProcessBar();
		_8 = (object)new Badge();
		_9 = (object)new Signal();
		SuspendLayout();
		((Control)_5).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_5).ForeColor = Color.FromArgb(48, 48, 48);
		((Control)_5).Location = new Point(499, 78);
		((Control)_5).Name = "uiLabel2";
		((Control)_5).Size = new Size(105, 21);
		((Control)_5).TabIndex = 2;
		((Control)_5).Text = "请保持网络畅通！";
		((Control)this.m_6).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((WindowBar)this.m_6).IsMax = false;
		((WindowBar)this.m_6).Loading = true;
		((Control)this.m_6).Location = new Point(0, 5);
		((WindowBar)this.m_6).MaximizeBox = false;
		((WindowBar)this.m_6).MinimizeBox = false;
		((Control)this.m_6).Name = "windowBar2";
		((Control)this.m_6).Size = new Size(668, 32);
		((Control)this.m_6).TabIndex = 70;
		((Control)this.m_6).Text = "加载中";
		((UIProcessBar)_7).FillColor = SystemColors.Control;
		((Control)_7).Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_7).ForeColor = SystemColors.ActiveCaption;
		((Control)_7).Location = new Point(15, 48);
		((Control)_7).MinimumSize = new Size(3, 3);
		((Control)_7).Name = "progress2";
		((UIProcessBar)_7).RectColor = Color.LightSkyBlue;
		((Control)_7).Size = new Size(589, 18);
		((Control)_7).TabIndex = 0;
		((Control)_7).Text = "uiProcessBar1";
		((Control)_8).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_8).Location = new Point(3, 67);
		((Control)_8).Name = "badge1";
		((Control)_8).Size = new Size(120, 32);
		((Badge)_8).State = (TState)2;
		((Control)_8).TabIndex = 71;
		((Control)_8).Text = "初始化环境中.....";
		((Control)_9).Location = new Point(456, 76);
		((Control)_9).Name = "signal6";
		((Control)_9).Size = new Size(40, 19);
		((Signal)_9).StyleLine = true;
		((Control)_9).TabIndex = 72;
		((Control)_9).Text = "signal6";
		((Signal)_9).Value = 5;
		AutoScaleMode = AutoScaleMode.None;
		ClientSize = new Size(626, 102);
		ControlBox = false;
		Controls.Add((Control)_9);
		Controls.Add((Control)_8);
		Controls.Add((Control)this.m_6);
		Controls.Add((Control)_5);
		Controls.Add((Control)_7);
		Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		FormBorderStyle = FormBorderStyle.None;
		Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "Form4";
		Padding = new Padding(0, 29, 0, 0);
		StartPosition = FormStartPosition.CenterScreen;
		Text = "配置系统环境变量中";
		Load += _1;
		ResumeLayout(performLayout: false);
	}
}
