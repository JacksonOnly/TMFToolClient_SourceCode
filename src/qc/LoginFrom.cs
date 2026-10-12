using Message = AntdUI.Message;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;
using LoginTamim;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using qc.Password;
using Sunny.UI;
using TMF_ENt.AES;
using TMF_ENt.AES.HWID;
using TMF_ENt.Http;
using TMF_ENt.Http.Login;

namespace qc;

public class LoginFrom : UIForm
{
	private struct Systemtime
	{
		public short Year;

		public short Month;

		public short DayOfWeek;

		public short Day;

		public short Hour;

		public short Minute;

		public short Second;

		public short Milliseconds;
	}

	private object _0;

	private object m_1;

	private IntPtr m_2 = (IntPtr)0;

	private IntPtr m_3 = (IntPtr)0;

	private object m_4;

	private object m_5;

	private object m_6 = new PasswordHandler();

	public string SigKey = "LKHIKNIBUNUMI892";

	private static readonly object m_8;

	private const string m_9 = "";

	public static string updateLink;

	private IntPtr m_b = (IntPtr)0;

	private const int m_c = 3;



	private IntPtr m_e = (IntPtr)0;

	private IntPtr m_f = (IntPtr)0;

	public string token;

	public string name;

	public string sapi;

	public string logintimer;

	public string PASS;

	public string type;

	public string Tile;

	public string role;

	public int Steer;

	public string Lang;

	public string modules;

	public static string lang;

	private static readonly object m_1c;

	private object m_1d;

	public string api;

	private object _1f;

	private static readonly object _20;

	private object _21;

	private object _22 = null;

	private object _23;

	private object _24;

	private object _25;

	private object _26;

	private object _27;

	private object _28;

	private object _29;

	private object _2a;

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool SetLocalTime(ref Systemtime time);

	public LoginFrom()
	{
		_1a();
		_1();
		_3();
	}

	private void _1()
	{
		this.m_4 = new System.Windows.Forms.Timer();
		((System.Windows.Forms.Timer)this.m_4).Interval = 5000;
		((System.Windows.Forms.Timer)this.m_4).Tick += (object sender, EventArgs e) =>
		{
			_15();
		};
		((System.Windows.Forms.Timer)this.m_4).Start();
		this.m_5 = new System.Windows.Forms.Timer();
		((System.Windows.Forms.Timer)this.m_5).Interval = 5000;
		((System.Windows.Forms.Timer)this.m_5).Tick += (object sender, EventArgs e) =>
		{
			_17();
		};
		((System.Windows.Forms.Timer)this.m_5).Start();
	}

	private void _2(object sender, object e)
	{
		string value = Apis.Api;
		if (!string.IsNullOrEmpty(value))
		{
			api = value;
		}
		((Form)(object)new Form5(api)).ShowDialog();
		_4();
	}

	private void _3()
	{
		((Control)_26).Enabled = false;
		((Control)_23).Enabled = false;
		((Control)_25).Enabled = false;
		((Control)_28).Enabled = false;
	}

	private void _4()
	{
		((Control)_26).Enabled = true;
		((Control)_23).Enabled = true;
		((Control)_25).Enabled = true;
		((Control)_28).Enabled = true;
	}

	private async void _5(object sender, object e)
	{
		object value = Apis.Api;
		if (!string.IsNullOrEmpty((string)value))
		{
			api = (string)value;
		}
		((Control)_23).Enabled = false;
		object text = ((Control)_25).Text;
		object text2 = ((Control)_26).Text;
		object hWID = HWIDGenerator.GetHWID();
		if (string.IsNullOrEmpty((string)text) || string.IsNullOrEmpty((string)text2))
		{
			if (lang == "en")
			{
				MessageBox.Show("User And Paswword text NO NUll", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				MessageBox.Show("账户或密码不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			((Control)_23).Enabled = true;
			return;
		}
		object obj = await LoginService.LoginAsync((string)text, (string)text2, (string)hWID, "6.0.9", api);
		if (((LoginResult)obj).Success)
		{
			if (((UICheckBox)_28).Checked)
			{
				((PasswordHandler)this.m_6).SavePassword((string)text, (string)text2, (string)hWID);
			}
			role = ((LoginResult)obj).role;
			type = (string)hWID;
			token = ((LoginResult)obj).Token;
			name = (string)text;
			sapi = api;
			Tile = ((LoginResult)obj).tile;
			logintimer = ((LoginResult)obj).expiry;
			Steer = ((LoginResult)obj).steer;
			Lang = ((LoginResult)obj).lang;
			modules = ((LoginResult)obj).modules;
			PASS = ((Control)_26).Text;
			((Form)this).DialogResult = DialogResult.OK;
			((Form)this).Close();
			return;
		}
		this.m_f += (nint)1;
		MessageBox.Show("登录失败: " + ((LoginResult)obj).Message);
		((Control)_23).Enabled = true;
		if ((nint)this.m_f >= 5)
		{
			if (lang == "en")
			{
				MessageBox.Show("There are too many password errors, and the error is about to exit", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				MessageBox.Show("密码错误过多，错误即将退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			Application.Exit();
		}
	}

	private static uint _6(object host, out DateTime syncDateTime, out string message)
	{
		syncDateTime = DateTime.Now;
		message = string.Empty;
		try
		{
			IPHostEntry hostEntry = Dns.GetHostEntry((string)host);
			IPAddress address = hostEntry.AddressList[0];
			IPEndPoint remoteEP = new IPEndPoint(address, 123);
			byte[] array = new byte[48];
			array[0] = 27;
			using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
			{
				socket.Connect(remoteEP);
				socket.ReceiveTimeout = 3000;
				socket.Send(array);
				socket.Receive(array);
			}
			ulong num = _7(BitConverter.ToUInt32(array, 40));
			ulong num2 = _7(BitConverter.ToUInt32(array, 44));
			ulong num3 = num * 1000 + num2 * 1000 / 4294967296L;
			DateTime dateTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(num3).ToLocalTime();
			if (_8(dateTime) != 0)
			{
				syncDateTime = dateTime;
				return 1u;
			}
			message = "设置本地时间失败。";
			return 0u;
		}
		catch (Exception ex)
		{
			message = "错误：" + ex.Message;
			return 0u;
		}
	}

	private static uint _7(ulong x)
	{
		return (uint)(((x & 0xFF) << 24) | ((x & 0xFF00) << 8) | ((x & 0xFF0000) >> 8) | ((x & 0xFF000000u) >> 24));
	}

	private static uint _8(DateTime dateTime)
	{
		Systemtime time = new Systemtime
		{
			Year = (short)dateTime.Year,
			Month = (short)dateTime.Month,
			Day = (short)dateTime.Day,
			Hour = (short)dateTime.Hour,
			Minute = (short)dateTime.Minute,
			Second = (short)dateTime.Second,
			Milliseconds = (short)dateTime.Millisecond
		};
		return SetLocalTime(ref time) ? 1u : 0u;
	}

	private object _9(object filePath)
	{
		using MD5 mD = MD5.Create();
		using FileStream inputStream = File.OpenRead((string)filePath);
		byte[] array = mD.ComputeHash(inputStream);
		return BitConverter.ToString(array).Replace("-", "").ToLower();
	}

	private async Task a()
	{
		if ((string)_21 != (string)_1f)
		{
			((Control)this).Invoke((Delegate)(MethodInvoker)(() =>
			{
				MessageBox.Show("程序被感染或者不完整，请重新下载", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}));
			object obj = new Random();
			nint num = ((Random)obj).Next(1000, 5000);
			Thread.Sleep((int)num);
			Environment.Exit(0);
		}
	}

	private void b()
	{
		if (this.m_1d == null || !((Thread)this.m_1d).IsAlive)
		{
			c();
		}
	}

	private async void c()
	{
		this.m_1d = new Thread(async () =>
		{
			while (true)
			{
				await a();
				Thread.Sleep(20000);
			}
		});
		((Thread)this.m_1d).IsBackground = true;
		((Thread)this.m_1d).Start();
	}

	private void d()
	{
		if (lang == "en")
		{
			((Control)_23).Text = "Login";
			((Control)_28).Text = "Remember";
			((Control)_29).Text = "For professional use, idle people, etc., please delete within 24 hours";
		}
	}

	private async void e(object sender, object e)
	{
		_15();
		_17();
		d();
		object obj = new ApiManager();
		nint num = ((await ((ApiManager)obj).PingAsync()) ? 1 : 0);
		IntPtr intPtr = num;
		if ((int)(nint)intPtr != 0)
		{
			api = ((ApiManager)obj).GetActiveApi();
			Config.ShowInWindow = true;
			object host = "ntp.aliyun.com";
			DateTime dateTime = default;
			string obj2 = default;
			if (_6(host, out dateTime, out obj2) != 0)
			{
				if (lang == "en")
				{
					Message.success((Form)(object)this, $"The current time：{dateTime:yyyy-MM-dd HH:mm:ss}", (Font)null, (int?)null);
				}
				else
				{
					Message.success((Form)(object)this, $"当前时间：{dateTime:yyyy-MM-dd HH:mm:ss}", (Font)null, (int?)null);
				}
			}
			else
			{
				Message.error((Form)(object)this, "同步失败：" + (string)obj2, (Font)null, (int?)null);
			}
			long num2 = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			object obj3 = $"timestamp={num2}";
			object mD5Hash = AesHelper.GetMD5Hash((string)obj3 + SigKey);
			object obj4 = new
			{
				Timestamp = num2,
				Sign = (string)mD5Hash
			};
			object plainText = JsonConvert.SerializeObject(obj4);
			object stringToEscape = AesHelper.Encrypt((string)plainText);
			object obj5 = Uri.EscapeDataString((string)stringToEscape);
			object obj6 = await HttpHelper.Get(Url: "/api/V2/eInfo?encryptedRequest=" + (string)obj5, api: api);
			nint num3 = ((JToken)obj6).Value<int>((object)"code");
			object text = ((JToken)obj6).Value<string>((object)"message");
			((JToken)obj6).Value<string>((object)"version");
			object obj7 = ((JToken)obj6).Value<string>((object)"version");
			nint num4 = ((JToken)obj6).Value<int>((object)"status");
			object url = ((JToken)obj6).Value<string>((object)"update_link");
			object obj8 = ((JToken)obj6).Value<string>((object)"md5_hash");
			if (num3 != 200)
			{
				MessageBox.Show((string)text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if ((string)obj7 != "6.0.9")
			{
				if (num4 != 1)
				{
					MessageBox.Show("版本过期请前往售后群下载", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Application.Exit();
					return;
				}
				((Control)this).Hide();
				object obj9 = new update((string)url);
				((Form)obj9).ShowDialog();
			}
			_4();
			((PasswordHandler)this.m_6).ReadPassword();
			((Control)_25).Text = ((PasswordHandler)this.m_6).user;
			((Control)_26).Text = ((PasswordHandler)this.m_6).password;
			_1f = _9(Application.ExecutablePath);
			_21 = obj8;
			b();
			if (((PasswordHandler)this.m_6).password != null)
			{
				((UICheckBox)_28).Checked = true;
			}
		}
		else
		{
			MessageBox.Show("尝试连接服务器出错！请重试", "服务器请求超时", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void f(object sender, object e)
	{
		if (!((UICheckBox)_28).Checked)
		{
			((PasswordHandler)this.m_6).Deleteuser();
		}
	}

	private void _10(object sender, object e)
	{
		string fileName = "https://www.yuque.com/tamim/llxpks/ugekwskoplui8gix?singleDoc";
		Process.Start(fileName);
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

	private void _14(object sender, object e)
	{
		if (((KeyEventArgs)e).KeyCode == Keys.Return)
		{
			((UIButton)_23).PerformClick();
			((KeyEventArgs)e).Handled = true;
		}
	}

	private void _15()
	{
		if ((int)(nint)this.m_2 != 0)
		{
			return;
		}
		this.m_2 = (IntPtr)1;
		_0 = new CancellationTokenSource();
		CancellationToken token = ((CancellationTokenSource)_0).Token;
		Task.Run(() =>
		{
			try
			{
				while (!token.IsCancellationRequested)
				{
					Random rand = new Random();
					int millisecondsTimeout = rand.Next(1000, 5001);
					IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
					if (defaultWebProxy != null)
					{
						Uri destination = new Uri("http://www.example.com");
						Uri proxy = defaultWebProxy.GetProxy(destination);
						int[] source = new int[4] { 8888, 8080, 8000, 3128 };
						if (proxy.Host == "127.0.0.1" && source.Contains(proxy.Port))
						{
							((Control)this).Invoke((Delegate)(Action)(() =>
							{
								MessageBox.Show("检测到抓包工具正在运行，请关闭后重试。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								((Control)this).Hide();
								Thread.Sleep(rand.Next(1000, 5000));
								Environment.Exit(0);
							}));
						}
					}
					if (_16() != 0)
					{
						((Control)this).Invoke((Delegate)(Action)(() =>
						{
							MessageBox.Show("检测到可疑根证书（抓包工具可能注入），请关闭相关软件后重试。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							((Control)this).Hide();
							Thread.Sleep(rand.Next(1000, 5000));
							Environment.Exit(0);
						}));
					}
					Thread.Sleep(millisecondsTimeout);
				}
			}
			catch (Exception)
			{
				this.m_2 = (IntPtr)0;
				((Control)this).Invoke((Delegate)(Action)(() =>
				{
					_17();
				}));
			}
		}, token);
	}

	private uint _16()
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

	private void _17()
	{
		if ((int)(nint)this.m_3 != 0)
		{
			return;
		}
		this.m_3 = (IntPtr)1;
		this.m_1 = new CancellationTokenSource();
		CancellationToken token = ((CancellationTokenSource)this.m_1).Token;
		Task.Run(() =>
		{
			try
			{
				while (!token.IsCancellationRequested)
				{
					Random random = new Random();
					int millisecondsTimeout = random.Next(1000, 5001);
					if (_11() != 0 || _12() != 0 || _13() != 0)
					{
						this.m_b = (nint)this.m_b + 1;
						if ((nint)this.m_b >= 3)
						{
							((Control)this).Invoke((Delegate)(Action)(() =>
							{
								MessageBox.Show("电脑环境异常,检测到调试软件！请卸载后重试。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								((Control)this).Hide();
								Random random2 = new Random();
								int millisecondsTimeout2 = random2.Next(1000, 5000);
								Thread.Sleep(millisecondsTimeout2);
								Environment.Exit(0);
							}));
						}
					}
					else
					{
						this.m_b = (IntPtr)0;
					}
					Thread.Sleep(millisecondsTimeout);
				}
			}
			catch (Exception)
			{
				this.m_3 = (IntPtr)0;
				((Control)this).Invoke((Delegate)(Action)(() =>
				{
					_15();
				}));
			}
		}, token);
	}

	private void _18(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _22 != null)
		{
			((IDisposable)_22).Dispose();
		}
		base.Dispose(disposing);
	}

	private void _1a()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		_22 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(LoginFrom));
		_23 = (object)new UISymbolButton();
		_24 = (object)new UIPanel();
		_29 = (object)new Alert();
		_27 = new PictureBox();
		_28 = (object)new UICheckBox();
		_26 = (object)new UITextBox();
		_25 = (object)new UITextBox();
		_2a = new System.Windows.Forms.Timer((IContainer)_22);
		((Control)_24).SuspendLayout();
		((ISupportInitialize)_27).BeginInit();
		((Control)this).SuspendLayout();
		((Control)_23).Cursor = Cursors.Hand;
		((UIButton)_23).FillColor = Color.LightSkyBlue;
		((UIButton)_23).FillColor2 = Color.LightSkyBlue;
		((UIButton)_23).FillHoverColor = SystemColors.GradientActiveCaption;
		((Control)_23).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIButton)_23).LightColor = Color.FromArgb(14, 30, 63);
		((Control)_23).Location = new Point(204, 383);
		((Control)_23).MinimumSize = new Size(1, 1);
		((Control)_23).Name = "uiSymbolButton1";
		((UIButton)_23).RectColor = Color.FromArgb(192, 255, 255);
		((UIButton)_23).RectHoverColor = Color.FromArgb(224, 224, 224);
		((Control)_23).Size = new Size(322, 28);
		((UIControl)_23).Style = (UIStyle)0;
		((Control)_23).TabIndex = 0;
		((Control)_23).Text = "登录";
		((UIButton)_23).TipsFont = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_23).Click += _5;
		((Control)_24).Controls.Add((Control)_29);
		((Control)_24).Controls.Add((Control)_27);
		((Control)_24).Controls.Add((Control)_28);
		((Control)_24).Controls.Add((Control)_26);
		((Control)_24).Controls.Add((Control)_25);
		((Control)_24).Controls.Add((Control)_23);
		((UIUserControl)_24).FillColor = Color.White;
		((Control)_24).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_24).Location = new Point(26, 48);
		((Control)_24).Margin = new Padding(4, 5, 4, 5);
		((Control)_24).MinimumSize = new Size(1, 1);
		((Control)_24).Name = "uiPanel1";
		((Control)_24).Size = new Size(755, 484);
		((Control)_24).TabIndex = 1;
		((Control)_24).Text = null;
		((UIUserControl)_24).TextAlignment = ContentAlignment.MiddleCenter;
		((Control)_24).Click += _18;
		((Control)_29).BackColor = Color.Pink;
		((Control)_29).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_29).Location = new Point(30, 438);
		((Alert)_29).Loop = true;
		((Control)_29).Name = "alert9";
		((Control)_29).Size = new Size(704, 32);
		((Control)_29).TabIndex = 56;
		((Control)_29).Text = "专业人士使用,闲杂人等请在24小时内删除，请规范使用账户，所有刷机记录均可回溯！";
		((PictureBox)_27).Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
		((Control)_27).Location = new Point(206, 32);
		((Control)_27).Name = "pictureBox1";
		((Control)_27).Size = new Size(322, 218);
		((PictureBox)_27).SizeMode = PictureBoxSizeMode.Zoom;
		((PictureBox)_27).TabIndex = 4;
		((PictureBox)_27).TabStop = false;
		((Control)_27).Click += _10;
		((Control)_28).Cursor = Cursors.Hand;
		((Control)_28).Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_28).ForeColor = Color.FromArgb(48, 48, 48);
		((Control)_28).Location = new Point(204, 351);
		((Control)_28).MinimumSize = new Size(1, 1);
		((Control)_28).Name = "checkBox1";
		((Control)_28).Size = new Size(117, 26);
		((Control)_28).TabIndex = 3;
		((Control)_28).Text = "记住密码";
		((UICheckBox)_28).CheckedChanged += f;
		((Control)_26).Cursor = Cursors.IBeam;
		((Control)_26).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_26).ForeColor = Color.DeepSkyBlue;
		((Control)_26).Location = new Point(206, 320);
		((Control)_26).Margin = new Padding(4, 5, 4, 5);
		((Control)_26).MinimumSize = new Size(1, 16);
		((Control)_26).Name = "passwordTextBox2";
		((Control)_26).Padding = new Padding(5);
		((UITextBox)_26).PasswordChar = '*';
		((UIUserControl)_26).Radius = 10;
		((UIPanel)_26).ShowText = false;
		((Control)_26).Size = new Size(322, 23);
		((UITextBox)_26).Symbol = 61475;
		((Control)_26).TabIndex = 2;
		((UIUserControl)_26).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)_26).Watermark = "";
		((UITextBox)_26).KeyDown += _14;
		((Control)_25).Cursor = Cursors.IBeam;
		((Control)_25).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_25).ForeColor = Color.DeepSkyBlue;
		((Control)_25).Location = new Point(206, 280);
		((Control)_25).Margin = new Padding(4, 5, 4, 5);
		((Control)_25).MinimumSize = new Size(1, 16);
		((Control)_25).Name = "userTextBox";
		((Control)_25).Padding = new Padding(5);
		((UIUserControl)_25).Radius = 10;
		((UIPanel)_25).ShowText = false;
		((Control)_25).Size = new Size(322, 23);
		((UITextBox)_25).Symbol = 62144;
		((Control)_25).TabIndex = 1;
		((UIUserControl)_25).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)_25).Watermark = "";
		((ContainerControl)this).AutoScaleMode = AutoScaleMode.None;
		((Control)(object)this).BackColor = Color.White;
		((Form)this).ClientSize = new Size(806, 559);
		((Control)this).Controls.Add((Control)_24);
		((UIBaseForm)this).ExtendBox = true;
		((UIBaseForm)this).ExtendSymbol = 61459;
		((Control)(object)this).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((UIBaseForm)this).MaximizeBox = false;
		((Control)this).Name = "LoginFrom";
		((Control)this).Padding = new Padding(0, 29, 0, 0);
		((UIBaseForm)this).RectColor = Color.FromArgb(192, 255, 255);
		((Form)this).ShowIcon = false;
		((Control)(object)this).Text = "TMFTool Clinet";
		((UIBaseForm)this).TextAlignment = StringAlignment.Center;
		((UIBaseForm)this).TitleColor = Color.LightSkyBlue;
		((UIBaseForm)this).TitleFont = new Font("微软雅黑", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((UIBaseForm)this).TitleHeight = 29;
		((UIForm)this).ZoomScaleRect = new Rectangle(15, 15, 696, 474);
		((UIForm)this).ExtendBoxClick += _2;
		((Form)this).Load += e;
		((Control)_24).ResumeLayout(false);
		((ISupportInitialize)_27).EndInit();
		((Control)this).ResumeLayout(false);
	}

	static LoginFrom()
	{
		LoginFrom.m_8 = new HttpClient();
		LoginFrom.m_1c = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TMF_config.txt");
		_20 = "kygtamimlg13kdo3ndao2n5f23";
	}

	[CompilerGenerated]
	private void _1c(object sender, object e)
	{
		_15();
	}

	[CompilerGenerated]
	private void _1d(object sender, object e)
	{
		_17();
	}

	[CompilerGenerated]
	private async void _1e()
	{
		while (true)
		{
			await a();
			Thread.Sleep(20000);
		}
	}
}
