using Button = AntdUI.Button;
using ContextMenuStrip = System.Windows.Forms.ContextMenuStrip;
using Message = AntdUI.Message;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AntdUI;
using Sunny.UI;

namespace qc;

public class AuthFrp : Window
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object _1;

	private object _2 = null;

	private object _3;

	private object _4;

	private object m_5;

	private object m_6;

	private object m_7;

	private object _8;

	private object m_9;

	private object a;

	public string SginedKey
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

	public string BlobKey
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

	public AuthFrp(string Blob)
	{
		BlobKey = Blob;
		_9();
		((Control)this.m_6).Text = BlobKey;
		Config.ShowInWindow = true;
		Config.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
	}

	private void _5(object sender, object e)
	{
		Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
		if (string.IsNullOrEmpty(((Control)this.m_7).Text))
		{
			Message.warn((Form)(object)form, "是不是应该输入点什么呢?", (Font)null, (int?)null);
			return;
		}
		SginedKey = ((Control)this.m_7).Text;
		((Form)this).DialogResult = DialogResult.OK;
		((Form)this).Close();
	}

	private void _6(object sender, object e)
	{
		Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
		Clipboard.SetText(((Control)this.m_6).Text);
		Message.success((Form)(object)form, "已复制剪切板！", (Font)null, (int?)null);
	}

	private void _7(object sender, object e)
	{
		string text = Clipboard.GetText();
		((Control)this.m_7).Text = text;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _2 != null)
		{
			((IDisposable)_2).Dispose();
		}
		base.Dispose(disposing);
	}

	private void _9()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		_2 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AuthFrp));
		_3 = (object)new Collapse();
		_4 = (object)new PageHeader();
		this.m_5 = (object)new PageHeader();
		this.m_6 = (object)new UITextBox();
		this.m_7 = (object)new Input();
		_8 = (object)new Button();
		this.m_9 = new ContextMenuStrip((IContainer)_2);
		a = new ToolStripMenuItem();
		((Control)this.m_9).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)_3).Location = new Point(148, 54);
		((Control)_3).Margin = new Padding(4, 4, 4, 4);
		((Control)_3).Name = "collapse1";
		((Control)_3).Size = new Size(88, 33);
		((Control)_3).TabIndex = 0;
		((Control)_3).Text = "collapse1";
		((Control)_4).Dock = DockStyle.Top;
		((PageHeader)_4).Icon = (Image)componentResourceManager.GetObject("pageHeader1.Icon");
		((Control)_4).Location = new Point(3, 3);
		((Control)_4).Margin = new Padding(4);
		((PageHeader)_4).MaximizeBox = false;
		((PageHeader)_4).MinimizeBox = false;
		((Control)_4).Name = "pageHeader1";
		((PageHeader)_4).ShowButton = true;
		((PageHeader)_4).ShowIcon = true;
		((Control)_4).Size = new Size(69, 23);
		((Control)_4).TabIndex = 1;
		((Control)_4).Text = "Input window";
		((Control)this.m_5).Dock = DockStyle.Top;
		((PageHeader)this.m_5).Icon = (Image)componentResourceManager.GetObject("pageHeader2.Icon");
		((Control)this.m_5).Location = new Point(0, 0);
		((Control)this.m_5).Margin = new Padding(5, 6, 5, 6);
		((PageHeader)this.m_5).MaximizeBox = false;
		((PageHeader)this.m_5).MinimizeBox = false;
		((Control)this.m_5).Name = "pageHeader2";
		((PageHeader)this.m_5).ShowButton = true;
		((PageHeader)this.m_5).ShowIcon = true;
		((Control)this.m_5).Size = new Size(458, 33);
		((PageHeader)this.m_5).SubText = "TMFTool";
		((Control)this.m_5).TabIndex = 1;
		((Control)this.m_5).Text = "MiFrp Auth";
		((UITextBox)this.m_6).ButtonSymbol = 557677;
		((Control)this.m_6).Cursor = Cursors.Default;
		((Control)this.m_6).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_6).Location = new Point(13, 44);
		((Control)this.m_6).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_6).MinimumSize = new Size(1, 16);
		((Control)this.m_6).Name = "Blobtext";
		((Control)this.m_6).Padding = new Padding(5);
		((UITextBox)this.m_6).ReadOnly = true;
		((UIUserControl)this.m_6).RectColor = Color.FromArgb(224, 224, 224);
		((UITextBox)this.m_6).ShowButton = true;
		((UIPanel)this.m_6).ShowText = false;
		((Control)this.m_6).Size = new Size(434, 34);
		((Control)this.m_6).TabIndex = 76;
		((UIUserControl)this.m_6).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)this.m_6).Watermark = "";
		((UITextBox)this.m_6).ButtonClick += _6;
		((IControl)this.m_7).Badge = "";
		((Control)this.m_7).ContextMenuStrip = (ContextMenuStrip)this.m_9;
		((Control)this.m_7).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_7).Location = new Point(13, 86);
		((Input)this.m_7).Multiline = true;
		((Control)this.m_7).Name = "Sgintxt";
		((Input)this.m_7).PlaceholderText = "Sign Key";
		((Control)this.m_7).Size = new Size(434, 221);
		((Control)this.m_7).TabIndex = 77;
		((Input)this.m_7).WaveSize = 0;
		((Control)_8).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_8).Location = new Point(12, 313);
		((Control)_8).Name = "Authbut";
		((Control)_8).Size = new Size(435, 32);
		((Control)_8).TabIndex = 78;
		((Control)_8).Text = "Auth";
		((Button)_8).Type = (TTypeMini)1;
		((Button)_8).WaveSize = 0;
		((Control)_8).Click += _5;
		((ToolStrip)this.m_9).Items.AddRange(new ToolStripItem[1] { (ToolStripItem)a });
		((Control)this.m_9).Name = "contextMenuStrip1";
		((Control)this.m_9).Size = new Size(101, 26);
		((ToolStripItem)a).Name = "粘贴ToolStripMenuItem";
		((ToolStripItem)a).Size = new Size(180, 22);
		((ToolStripItem)a).Text = "粘贴";
		((ToolStripItem)a).Click += _7;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 17f);
		((ContainerControl)this).AutoScaleMode = AutoScaleMode.Font;
		((Form)this).ClientSize = new Size(458, 354);
		((Control)this).Controls.Add((Control)_8);
		((Control)this).Controls.Add((Control)this.m_7);
		((Control)this).Controls.Add((Control)this.m_6);
		((Control)this).Controls.Add((Control)this.m_5);
		((Control)this).Controls.Add((Control)_3);
		((Control)(object)this).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).Margin = new Padding(4, 4, 4, 4);
		((Control)this).Name = "AuthFrp";
		((Form)this).StartPosition = FormStartPosition.CenterParent;
		((Control)(object)this).Text = "AuthFrp";
		((Control)this.m_9).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}
}
