using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class AutoCloseMessageBox : Form
{
	public AutoCloseMessageBox(string message, int duration)
	{
		StartPosition = FormStartPosition.CenterScreen;
		FormBorderStyle = FormBorderStyle.None;
		Size = new Size(300, 100);
		BackColor = Color.FromArgb(135, 206, 250);
		TopMost = true;
		Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
		Label value = new Label
		{
			Text = message,
			Dock = DockStyle.Fill,
			TextAlign = ContentAlignment.MiddleCenter,
			Font = new Font("微软雅黑", 10f, FontStyle.Regular),
			ForeColor = Color.White
		};
		Controls.Add(value);
		Timer timer = new Timer
		{
			Interval = duration
		};
		timer.Tick += (object s, EventArgs e) =>
		{
			timer.Stop();
			Close();
		};
		timer.Start();
	}

	[DllImport("Gdi32.dll")]
	private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

	public static void Show(string message, int duration)
	{
		AutoCloseMessageBox autoCloseMessageBox = new AutoCloseMessageBox(message, duration);
		autoCloseMessageBox.ShowDialog();
	}
}
