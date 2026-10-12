using Label = AntdUI.Label;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AntdUI;

namespace qc;

public class andform : Window
{
	private object _0 = null;

	private object _1;

	private object m_2;

	private object _3;

	private object _4;

	private object _5;

	private object _6;

	private object _7;

	private object _8;

	public andform(string product, string androidVersion, string brand, string kernel, string slot, string version, string unlockStatus)
	{
		_2();
		((Control)this.m_2).Text = "代号: " + product;
		((Control)_4).Text = "安卓版本: " + androidVersion;
		((Control)_3).Text = "厂商: " + brand;
		((Control)_7).Text = "内核版本: " + kernel;
		((Control)_6).Text = "插槽: " + slot;
		((Control)_5).Text = "系统版本: " + version;
		((Control)_8).Text = "解锁状态: " + unlockStatus;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _0 != null)
		{
			((IDisposable)_0).Dispose();
		}
		base.Dispose(disposing);
	}

	private void _2()
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
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(andform));
		_1 = (object)new PageHeader();
		this.m_2 = (object)new Label();
		_3 = (object)new Label();
		_4 = (object)new Label();
		_5 = (object)new Label();
		_6 = (object)new Label();
		_7 = (object)new Label();
		_8 = (object)new Label();
		((Control)this).SuspendLayout();
		((Control)_1).BackColor = Color.LightSkyBlue;
		((PageHeader)_1).DividerColor = Color.FromArgb(22, 119, 255);
		((Control)_1).Dock = DockStyle.Top;
		((Control)_1).ForeColor = Color.White;
		((PageHeader)_1).Icon = (Image)componentResourceManager.GetObject("pageHeader1.Icon");
		((Control)_1).Location = new Point(0, 0);
		((Control)_1).Margin = new Padding(4, 4, 4, 4);
		((PageHeader)_1).MaximizeBox = false;
		((Control)_1).Name = "pageHeader1";
		((PageHeader)_1).ShowButton = true;
		((PageHeader)_1).ShowIcon = true;
		((Control)_1).Size = new Size(345, 26);
		((Control)_1).TabIndex = 0;
		((Control)_1).Text = "投屏信息展示_BY_TMF";
		((Control)this.m_2).Location = new Point(12, 45);
		((Control)this.m_2).Name = "lblProduct";
		((Control)this.m_2).Size = new Size(321, 22);
		((Control)this.m_2).TabIndex = 1;
		((Control)this.m_2).Text = "代号:";
		((Control)_3).Location = new Point(12, 73);
		((Control)_3).Name = "lblBrand";
		((Control)_3).Size = new Size(321, 22);
		((Control)_3).TabIndex = 2;
		((Control)_3).Text = "厂商:";
		((Control)_4).Location = new Point(12, 101);
		((Control)_4).Name = "lblAndroid";
		((Control)_4).Size = new Size(321, 22);
		((Control)_4).TabIndex = 3;
		((Control)_4).Text = "安卓版本:";
		((Control)_5).Location = new Point(12, 129);
		((Control)_5).Name = "lblVersion";
		((Control)_5).Size = new Size(321, 22);
		((Control)_5).TabIndex = 4;
		((Control)_5).Text = "系统:";
		((Control)_6).Location = new Point(12, 157);
		((Control)_6).Name = "lblSlot";
		((Control)_6).Size = new Size(321, 22);
		((Control)_6).TabIndex = 5;
		((Control)_6).Text = "槽位: ";
		((Control)_7).Location = new Point(12, 185);
		((Control)_7).Name = "lblKernel";
		((Control)_7).Size = new Size(321, 22);
		((Control)_7).TabIndex = 6;
		((Control)_7).Text = "内核版本:";
		((Control)_8).Location = new Point(12, 213);
		((Control)_8).Name = "lblUnlock";
		((Control)_8).Size = new Size(321, 22);
		((Control)_8).TabIndex = 7;
		((Control)_8).Text = "解锁状态:";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 17f);
		((ContainerControl)this).AutoScaleMode = AutoScaleMode.Font;
		((Form)this).ClientSize = new Size(345, 263);
		((Control)this).Controls.Add((Control)_8);
		((Control)this).Controls.Add((Control)_7);
		((Control)this).Controls.Add((Control)_6);
		((Control)this).Controls.Add((Control)_5);
		((Control)this).Controls.Add((Control)_4);
		((Control)this).Controls.Add((Control)_3);
		((Control)this).Controls.Add((Control)this.m_2);
		((Control)this).Controls.Add((Control)_1);
		((Control)(object)this).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Form)this).FormBorderStyle = FormBorderStyle.FixedDialog;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).Margin = new Padding(4, 4, 4, 4);
		((Control)this).Name = "andform";
		((Control)(object)this).Text = "投屏信息";
		((Control)this).ResumeLayout(false);
	}
}
