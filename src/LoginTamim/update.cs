using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace LoginTamim;

public class update : UIForm
{
	private object _0;

	private object m_1;

	private object m_2 = null;

	private object m_3;

	private object m_4;

	private object m_5;

	public update(string Url)
	{
		_0 = Url;
		_7();
	}

	private async void _1(object sender, object e)
	{
		if (!string.IsNullOrEmpty((string)_0))
		{
			await _2(_0);
		}
	}

	private async Task _2(object downloadUrl)
	{
		try
		{
			object obj = new HttpClient();
			try
			{
				object fileNameWithoutExtension = Path.GetFileNameWithoutExtension(new Uri((string)downloadUrl).LocalPath);
				object extension = Path.GetExtension(new Uri((string)downloadUrl).LocalPath);
				object obj2 = DateTime.Now.ToString("yyyyMMddHHmmss");
				fileNameWithoutExtension = (string)fileNameWithoutExtension + "_" + (string)obj2 + (string)extension;
				object folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				object obj3 = Path.Combine((string)folderPath, (string)fileNameWithoutExtension);
				object progress = new Progress<(long, long)>(_4);
				await _3(obj, downloadUrl, obj3, progress);
				Process.Start(new ProcessStartInfo((string)obj3)
				{
					UseShellExecute = true
				});
				Application.Exit();
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			object obj4 = ex;
			MessageBox.Show("下载失败: " + ((Exception)obj4).Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.Exit();
		}
	}

	private async Task _3(object client, object downloadUrl, object destinationFilePath, object progress)
	{
		this.m_1 = Stopwatch.StartNew();
		object obj = await ((HttpClient)client).GetAsync((string)downloadUrl, HttpCompletionOption.ResponseHeadersRead);
		try
		{
			((HttpResponseMessage)obj).EnsureSuccessStatusCode();
			long item = ((HttpResponseMessage)obj).Content.Headers.ContentLength ?? (-1);
			long num = 0L;
			object obj2 = new byte[65536];
			object obj3 = await ((HttpResponseMessage)obj).Content.ReadAsStreamAsync();
			try
			{
				object obj4 = new FileStream((string)destinationFilePath, FileMode.Create, FileAccess.Write, FileShare.None, ((Array)obj2).Length, useAsync: true);
				try
				{
					long elapsedMilliseconds = ((Stopwatch)this.m_1).ElapsedMilliseconds;
					while (true)
					{
						nint num2 = await ((Stream)obj3).ReadAsync((byte[])obj2, 0, ((Array)obj2).Length);
						int num3 = (int)num2;
						IntPtr intPtr = num2;
						if (num3 <= 0)
						{
							break;
						}
						await ((Stream)obj4).WriteAsync((byte[])obj2, 0, (int)(nint)intPtr);
						num += (nint)intPtr;
						if (((Stopwatch)this.m_1).ElapsedMilliseconds - elapsedMilliseconds >= 10)
						{
							((IProgress<(long, long)>)progress)?.Report((item, num));
							elapsedMilliseconds = ((Stopwatch)this.m_1).ElapsedMilliseconds;
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
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
		((Stopwatch)this.m_1).Stop();
	}

	private void _4((long totalBytes, long downloadedBytes) progressData)
	{
		var (totalBytes, downloadedBytes) = progressData;
		if (totalBytes > 0)
		{
			((Control)this).Invoke((Delegate)(Action)(() =>
			{
				((UIProcessBar)this.m_5).Value = (int)(downloadedBytes * 100 / totalBytes);
				double totalSeconds = ((Stopwatch)this.m_1).Elapsed.TotalSeconds;
				double num = (double)downloadedBytes / totalSeconds / 1024.0;
				((Control)this.m_3).Text = $"下载速度: {num:F2} KB/s | 已下载: {downloadedBytes / 1024} KB / {totalBytes / 1024} KB";
			}));
		}
	}

	private void _5(object sender, object e)
	{
		Application.Exit();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_2 != null)
		{
			((IDisposable)this.m_2).Dispose();
		}
		base.Dispose(disposing);
	}

	private void _7()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected Obj, but got Unknown
		this.m_3 = new Label();
		this.m_4 = new Label();
		this.m_5 = (object)new UIProcessBar();
		((Control)this).SuspendLayout();
		((Control)this.m_3).AutoSize = true;
		((Control)this.m_3).Location = new Point(304, 64);
		((Control)this.m_3).Name = "label1";
		((Control)this.m_3).Size = new Size(0, 17);
		((Control)this.m_3).TabIndex = 1;
		((Control)this.m_4).AutoSize = true;
		((Control)this.m_4).Location = new Point(9, 73);
		((Control)this.m_4).Name = "label2";
		((Control)this.m_4).Size = new Size(92, 17);
		((Control)this.m_4).TabIndex = 2;
		((Control)this.m_4).Text = "开始下载新版本";
		((UIProcessBar)this.m_5).FillColor = SystemColors.Control;
		((Control)this.m_5).Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_5).ForeColor = SystemColors.ActiveCaption;
		((Control)this.m_5).Location = new Point(12, 43);
		((Control)this.m_5).MinimumSize = new Size(3, 3);
		((Control)this.m_5).Name = "progress1";
		((UIProcessBar)this.m_5).RectColor = Color.LightSkyBlue;
		((Control)this.m_5).Size = new Size(734, 18);
		((Control)this.m_5).TabIndex = 3;
		((Control)this.m_5).Text = "uiProcessBar1";
		((ContainerControl)this).AutoScaleMode = AutoScaleMode.None;
		((Form)this).ClientSize = new Size(759, 96);
		((Control)this).Controls.Add((Control)this.m_5);
		((Control)this).Controls.Add((Control)this.m_4);
		((Control)this).Controls.Add((Control)this.m_3);
		((Control)(object)this).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIBaseForm)this).MaximizeBox = false;
		((UIBaseForm)this).MinimizeBox = false;
		((Control)this).Name = "update";
		((Control)this).Padding = new Padding(0, 29, 0, 0);
		((UIBaseForm)this).RectColor = Color.FromArgb(128, 255, 255);
		((Form)this).ShowIcon = false;
		((Control)(object)this).Text = "更新版本中.....";
		((UIBaseForm)this).TextAlignment = StringAlignment.Center;
		((UIBaseForm)this).TitleColor = Color.LightSkyBlue;
		((UIBaseForm)this).TitleFont = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIBaseForm)this).TitleHeight = 29;
		((UIForm)this).ZoomScaleRect = new Rectangle(15, 15, 759, 122);
		((Form)this).FormClosing += _5;
		((Form)this).Load += _1;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
