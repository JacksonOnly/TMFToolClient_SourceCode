using StyleLine = AntdUI.Tabs.StyleLine;
using IStyle = AntdUI.Tabs.IStyle;
using Button = AntdUI.Button;
using ContextMenuStrip = System.Windows.Forms.ContextMenuStrip;
using Message = AntdUI.Message;
using TabPage = AntdUI.TabPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SLA_Challenge;
using Sunny.UI;

namespace qc;

public class Authe : Window
{
	private static object _0;

	private static object _1;

	public static string BaseUrl = "http://api.auth-xiaomi.com";

	public static string WumingeUrl = "https://api.wutools.net";





	public string _username;

	private object m_7;

	private static readonly object m_8;

	private IntPtr m_9 = (IntPtr)0;

	private IntPtr m_a = (IntPtr)0;

	private IntPtr m_b = (IntPtr)0;

	private static object m_c;

	private static object m_d;

	private IntPtr e = (IntPtr)1;

	public static string sBasesUrl;

	private object m_10 = null;

	private object m_11;

	private object m_12;

	private object m_13;

	private object _14;

	private object m_15;

	private object m_16;

	private object m_17;

	private object m_18;

	private object m_19;

	private object m_1a;

	private object m_1b;

	private object m_1c;

	private object m_1d;

	private object m_1e;

	private object _1f;

	private object _20;

	private object m_21;

	private object m_22;

	private object m_23;

	private object m_24;

	private object m_25;

	private object m_26;

	private object m_27;

	private object m_28;

	private object m_29;

	private object _2a;

	private object m_2b;

	private object _2c;

	private object _2d;

	private object _2e;

	private object _2f;

	private object _30;

	private object _31;

	private object _32;

	private object _33;

	private object _34;

	private object _35;

	private object _36;

	private object _37;

	private object _38;

	private object _39;

	private object _3a;

	private object _3b;

	private object _3c;

	private object _3d;

	public string Sig
	{
		get
		{
			return (string)_0;
		}
		set
		{
			_0 = value;
		}
	}

	private string Blob => ((Control)_35).Text;

	public Authe(string username, string api)
	{
		_username = username;
		_2b();
		this.m_7 = api;
		((UITextBox)_35).DoubleClick += _12;
		if (!string.IsNullOrEmpty((string)_1))
		{
			((Control)this.m_11).Text = (string)_1;
		}
	}

	public static void SetPortValue(string port)
	{
		_1 = port;
	}

	private void _4(object msg)
	{
		((Input)_20).AppendText((string)msg + "\r\n");
	}

	private void _5(object msg)
	{
		((Input)this.m_25).AppendText((string)msg + "\r\n");
	}

	public void SetTextBoxValue(string sigValue)
	{
		((Control)_35).Text = sigValue;
	}

	private void _7(object sender, EventArgs e)
	{
	}

	private async void _8(object sender, object e)
	{
		object obj = Application.OpenForms.OfType<Form1>().FirstOrDefault();
		object obj2 = ((Control)_14).Text.Trim();
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
		object text = ((Control)this.m_11).Text;
		object text2 = ((Control)_14).Text;
		object fileName = Path.Combine("C:\\TMFTool", "qcedlcmdhelper.exe");
		object arguments = "-p " + (string)text + " -m sig -d \"" + (string)text2 + "\"";
		try
		{
			object text3 = await (Task<string>)_9(fileName, arguments);
			((Control)_14).Text = (string)text3;
		}
		catch (Exception ex)
		{
			object obj3 = ex;
			((Control)_14).Text = "Error: " + ((Exception)obj3).Message;
		}
		((Control)this).Hide();
		if (obj != null)
		{
			if (((Control)_14).Text.Contains("Signature Verification Failed"))
			{
				((Form1)obj).UpdateRichTextBox("设备鉴权失败！请等待重新输入", Color.Black);
				((Form1)obj).UpdateRichTextBox("等待重新输入！\n", Color.Red);
				await Task.Delay(2000);
				((Input)_14).Clear();
				((Control)this).Show();
			}
			else
			{
				((Form1)obj).EnableButtons2();
				((Form1)obj).EnableButtons();
				((Form1)obj).UpdateRichTextBox("设备鉴权成功！", Color.LimeGreen);
				((Form1)obj).ReexecuteLastClickedButton();
				((Form1)obj).kuaijie();
				((Form)this).Close();
			}
		}
	}

	private object _9(object fileName, object arguments)
	{
		TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
		Process process = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = (string)fileName,
				Arguments = (string)arguments,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			},
			EnableRaisingEvents = true
		};
		StringBuilder output = new StringBuilder();
		process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
		{
			if (e.Data != null)
			{
				output.AppendLine(e.Data);
			}
		};
		process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
		{
			if (e.Data != null)
			{
				output.AppendLine("ERROR: " + e.Data);
			}
		};
		process.Exited += (object sender, EventArgs e) =>
		{
			if (process.ExitCode == 0)
			{
				tcs.SetResult(output.ToString());
			}
			else
			{
				tcs.SetException(new InvalidOperationException($"The process exited with code {process.ExitCode}."));
			}
			process.Dispose();
		};
		try
		{
			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
		}
		catch (Exception exception)
		{
			tcs.SetException(exception);
		}
		return tcs.Task;
	}

	private void a(object sender, object e)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected Obj, but got Unknown
		Config.ShowInWindow = true;
		Config.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_14).Text = "";
		JObject val = new JObject();
		if (((Control)this).Tag is string textBoxValue)
		{
			SetTextBoxValue(textBoxValue);
		}
		if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\weilin_user"))
		{
			return;
		}
		try
		{
			val = JObject.Parse(Utlis.AesDecrypt(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\weilin_user"), "zappxankacctecwdelkhkuovxtbuedab"));
			string text = ((object)val["user"]).ToString();
			string text2 = ((object)val["password"]).ToString();
			if (text.IsNotNullOrEmpty())
			{
				((Control)this.m_19).Text = text;
			}
			if (text2.IsNotNullOrEmpty())
			{
				((Control)this.m_1b).Text = text2;
			}
		}
		catch (Exception)
		{
		}
	}

	private void b(object sender, EventArgs e)
	{
	}

	private void c()
	{
		((Input)_20).Clear();
		((Input)this.m_25).Clear();
	}

	private async void d(object sender, object e)
	{
		object text = ((Control)this.m_19).Text;
		object text2 = ((Control)this.m_1b).Text;
		if ((string)text == "" || (string)text2 == "")
		{
			c();
			_4("请填写账号或密码");
			return;
		}
		c();
		object obj = JObject.Parse(await Utlis.Request(BaseUrl + "/api/v1/Login?user=" + (string)text + "&password=" + (string)text2));
		if (((object)((JObject)obj)["code"]).ToString() == "200")
		{
			c();
			this.m_9 = (IntPtr)1;
			_4("登录成功");
			_4("高通点数：[" + ((object)((JObject)obj)["creditqc"]).ToString() + "]");
			Thread.Sleep(200);
		}
		else
		{
			_4(((object)((JObject)obj)["msg"]).ToString());
		}
	}

	private async void f(object sender, object e)
	{
		object text = ((Control)this.m_19).Text;
		object text2 = ((Control)this.m_1b).Text;
		if (this.m_9 == (IntPtr)0)
		{
			c();
			_4("请先登录账号!");
			return;
		}
		object obj = JObject.Parse(await Utlis.Request(BaseUrl + "/api/v1/Auth?user=" + (string)text + "&password=" + (string)text2 + "&blob=" + Blob + "&soc=qc"));
		_4(((object)((JObject)obj)["msg"]).ToString());
		if (((object)((JObject)obj)["code"]).ToString() == "200")
		{
			((Control)_14).Text = ((object)((JObject)obj)["sign"]).ToString();
			_8(null, null);
		}
		else
		{
			_4(((object)((JObject)obj)["msg"]).ToString());
		}
	}

	private async void _10(object sender, object e)
	{
		object text = ((Control)this.m_1e).Text;
		if (((Control)this.m_1e).Text == "")
		{
			c();
			_4("请填写卡密");
			return;
		}
		c();
		Thread.Sleep(200);
		object obj = JObject.Parse(await Utlis.Request(BaseUrl + "/api/v1/tLogin?token=" + (string)text));
		if (((object)((JObject)obj)["code"]).ToString() == "200")
		{
			this.m_a = (IntPtr)1;
			_4(((object)((JObject)obj)["msg"]).ToString());
		}
		else
		{
			_4(((object)((JObject)obj)["msg"]).ToString());
		}
	}

	private async void _11(object sender, object e)
	{
		object text = ((Control)this.m_1e).Text;
		if (this.m_a == (IntPtr)0)
		{
			c();
			_4("请先验证卡密!");
			return;
		}
		c();
		_4("发送到服务器...");
		object obj = JObject.Parse(await Utlis.Request(BaseUrl + "/api/v1/TAuth?token=" + (string)text + "&blob=" + Blob + "&soc=qc"));
		_4(((object)((JObject)obj)["msg"]).ToString());
		if (((object)((JObject)obj)["code"]).ToString() == "200")
		{
			((Control)_14).Text = ((object)((JObject)obj)["sign"]).ToString();
			_8(null, null);
		}
		else
		{
			_4(((object)((JObject)obj)["msg"]).ToString());
		}
	}

	private void _12(object sender, object e)
	{
		Clipboard.SetText(((Control)_35).Text);
	}

	private void _13(object sender, FormClosingEventArgs e)
	{
	}

	public string post(string url, string data)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
		httpWebRequest.Method = "POST";
		httpWebRequest.ContentType = "application/x-www-form-urlencoded";
		using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			streamWriter.Write(data);
		}
		try
		{
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
			return streamReader.ReadToEnd();
		}
		catch (Exception ex)
		{
			string message = ex.Message;
			return "500";
		}
	}

	private void _15(object sender, EventArgs e)
	{
	}

	private void _16(object sender, object e)
	{
		if (Sig == null || Sig == string.Empty)
		{
			Sig = "443ac7893e267d33069ae26854ff9e92ebd41f0956459658a47df22a5ec7e72332a80d5b9c3228696cdf5d3cecbd81f0f022c3d8428933a128854ba9bb380873e066c1adfe31201e0132479d3df709bf70e93852ebab63e5863e09e6e2cf3ace24c7106b0d24faa14b0d4d0f8427a206cb1d30336f1c34f0f2f8605253ec07ccd79c9a7e2bc76e51652fd2832cee0f8aa78c2826474c95d82ade39ac98da9d4f89c27f3055e640ca60354b1961c82927f445cbb2377c36891f4e6fcf98dc6b0a613f9cba43f8e5b595e8320710bfdfc2ca56228e0b27791deb6356cfbf7a0c7435b832f2aa44e0e8d2a04f268361f8b4199e0d8e3d2004588df4645975a1b26";
			((Form)this).Close();
		}
		if (Sig.Length != 512)
		{
			Sig = "443ac7893e267d33069ae26854ff9e92ebd41f0956459658a47df22a5ec7e72332a80d5b9c3228696cdf5d3cecbd81f0f022c3d8428933a128854ba9bb380873e066c1adfe31201e0132479d3df709bf70e93852ebab63e5863e09e6e2cf3ace24c7106b0d24faa14b0d4d0f8427a206cb1d30336f1c34f0f2f8605253ec07ccd79c9a7e2bc76e51652fd2832cee0f8aa78c2826474c95d82ade39ac98da9d4f89c27f3055e640ca60354b1961c82927f445cbb2377c36891f4e6fcf98dc6b0a613f9cba43f8e5b595e8320710bfdfc2ca56228e0b27791deb6356cfbf7a0c7435b832f2aa44e0e8d2a04f268361f8b4199e0d8e3d2004588df4645975a1b26";
		}
		((Form)this).Close();
	}

	private async void _17(object sender, object e)
	{
		object text = ((Control)this.m_29).Text;
		object text2 = ((Control)_2a).Text;
		if ((string)text == "" || (string)text2 == "")
		{
			c();
			_5("请填写账号或密码");
			return;
		}
		c();
		object obj = JObject.Parse(await Utlis.wumingRequest(WumingeUrl + "/api.php?user=" + (string)text + "&password=" + (string)text2));
		object obj2 = ((object)((JObject)obj)["code"]).ToString();
		if ((string)obj2 == "200")
		{
			this.m_b = (IntPtr)1;
			c();
			_5("登录成功");
			_5("高通点数：[" + ((object)((JObject)obj)["price"]).ToString() + "]");
			Thread.Sleep(200);
		}
		else
		{
			_5(((object)((JObject)obj)["msg"]).ToString());
		}
	}

	private async void _18(object sender, object e)
	{
		object text = ((Control)this.m_29).Text;
		object text2 = ((Control)_2a).Text;
		if (this.m_b == (IntPtr)0)
		{
			c();
			_5("请先登录账号!");
			return;
		}
		object obj = JObject.Parse(await Utlis.wumingRequest(WumingeUrl + "/api.php?user=" + (string)text + "&password=" + (string)text2 + "&blob=" + Blob));
		if (((object)((JObject)obj)["code"]).ToString() == "200")
		{
			((Control)_14).Text = ((object)((JObject)obj)["sig"]).ToString();
			_5(((object)((JObject)obj)["msg"]).ToString());
			_8(null, null);
		}
		else
		{
			_5(((object)((JObject)obj)["msg"]).ToString());
		}
	}

	private void _19(object sender, EventArgs e)
	{
	}

	private void _1a(object sender, IntEventArgs e)
	{
	}

	private void _1b()
	{
		((Input)_2d).SelectionColor = Color.LimeGreen;
	}

	private void _1c()
	{
		((Input)_2d).SelectionColor = Color.Red;
	}

	private void _1d(object msg)
	{
		((Input)_2d).AppendText((string)msg);
		((Input)_2d).ScrollToCaret();
	}

	private void _1e(object msg)
	{
		((Input)_2d).AppendText((string)msg);
		((Input)_2d).ScrollToCaret();
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
			string text2 = AesDecrypt(text, (string)Authe.m_c, (string)Authe.m_d);
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

	private async void _21(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((Control)_35).Text))
		{
			_1d("Blob不能为空，请输入有效的Blob值\n");
			return;
		}
		((Input)_2d).Clear();
		((Steps)_30).Current = 0;
		if (string.IsNullOrWhiteSpace(_username))
		{
			_1d("用户名未设置，请登录。\n");
			return;
		}
		((Control)_2c).Enabled = false;
		object obj = new HttpClient();
		try
		{
			object nameValueCollection = new Dictionary<string, string> { { "username", _username } };
			object obj2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(await (await ((HttpClient)obj).PostAsync(content: (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)nameValueCollection), requestUri: (string)this.m_7 + "/validate_user.php")).Content.ReadAsStringAsync());
			if (obj2 == null || ((Dictionary<string, string>)obj2)["status"] != "success")
			{
				_1c();
				_1d("您不是特权会员，无法使用该功能\n");
				((Control)_2c).Enabled = true;
				return;
			}
			_1b();
			_1d("尊贵的特权会员，正在为你查询\n");
			((Steps)_30).Current = 1;
			((Control)_2f).Text = "";
			object text = ((Control)_35).Text;
			_1d("请求中...");
			this.e = (IntPtr)0;
			object requestUri = "http://auth.llxll.cn/api/v1/fmi?blob=" + (string)text;
			object obj3 = new HttpClient();
			try
			{
				object obj4 = await ((HttpClient)obj).GetAsync((string)requestUri);
				((HttpResponseMessage)obj4).EnsureSuccessStatusCode();
				object obj5 = JObject.Parse(await ((HttpResponseMessage)obj4).Content.ReadAsStringAsync());
				JToken val = ((JObject)obj5)["code"];
				nint num = ((val != null) ? Extensions.Value<int>((IEnumerable<JToken>)val) : 0);
				if (num == 200)
				{
					object obj6 = ((object)((JObject)obj5)["msg"])?.ToString();
					((Input)_2d).AppendText((string)obj6 + "\n");
					((Control)_2c).Enabled = true;
					((Steps)_30).Current = 2;
					return;
				}
				object obj7 = ((object)((JObject)obj5)["msg"])?.ToString();
				MessageBox.Show((string)(obj7 ?? ""), "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				((Control)_2c).Enabled = true;
				((Steps)_30).Current = 0;
			}
			catch (Exception ex)
			{
				object obj8 = ex;
				UIMessageBox.ShowError(((Exception)obj8).Message, true, 0);
				((Control)_2c).Enabled = true;
				((Steps)_30).Current = 0;
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
	}

	private void _22(object sender, object e)
	{
		Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
		form.EnableButtons();
	}

	private void _23(object sender, object e)
	{
		Clipboard.SetText(((Control)_35).Text);
	}

	private void _24(object sender, CancelEventArgs e)
	{
	}

	private void _25(object sender, object e)
	{
		string text = Clipboard.GetText();
		((Control)_14).Text = text;
	}

	private void _26(object sender, EventArgs e)
	{
	}

	private void _27(object sender, object e)
	{
		Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
		Clipboard.SetText(((Control)_35).Text);
		Message.success((Form)(object)form, "已复制剪切板！", (Font)null, (int?)null);
	}

	private async void _28(object sender, object e)
	{
		if (string.IsNullOrEmpty(((Control)_3c).Text) || string.IsNullOrEmpty(((Control)_3d).Text))
		{
			((Control)_38).Text = "用户名与密码是必填的";
			return;
		}
		object text = ((Control)_3c).Text;
		object text2 = ((Control)_3d).Text;
		_ = ((Control)_35).Text;
		object requestUri = "https://cr.xmgsm.com/api/Submit?username=" + (string)text + "&password=" + (string)text2;
		object obj = new HttpClient();
		try
		{
			object obj2 = await ((HttpClient)obj).GetAsync((string)requestUri);
			((HttpResponseMessage)obj2).EnsureSuccessStatusCode();
			object obj3 = JObject.Parse(await ((HttpResponseMessage)obj2).Content.ReadAsStringAsync());
			JToken val = ((JObject)obj3)["code"];
			nint num = ((val != null) ? Extensions.Value<int>((IEnumerable<JToken>)val) : 0);
			if (num == 200)
			{
				object obj4 = ((object)((JObject)obj3)["data"])?.ToString();
				((Control)_38).Text = "登录成功 点数:" + (string)obj4;
				return;
			}
			object text3 = ((object)((JObject)obj3)["message"])?.ToString();
			((Control)_38).Text = (string)text3;
		}
		catch (Exception ex)
		{
			object obj5 = ex;
			((Control)_38).Text = ((Exception)obj5).Message;
		}
		finally
		{
			((IDisposable)obj)?.Dispose();
		}
	}

	private async void _29(object sender, object e)
	{
		if (string.IsNullOrEmpty(((Control)_3c).Text) || string.IsNullOrEmpty(((Control)_3d).Text))
		{
			((Control)_38).Text = "用户名与密码是必填的";
			return;
		}
		object text = ((Control)_3c).Text;
		object text2 = ((Control)_3d).Text;
		object text3 = ((Control)_35).Text;
		object obj = "qc";
		object requestUri = "https://cr.xmgsm.com/api/Submit?username=" + (string)text + "&password=" + (string)text2 + "&blob=" + (string)text3 + "&type=" + (string)obj;
		object obj2 = new HttpClient();
		try
		{
			object obj3 = await ((HttpClient)obj2).GetAsync((string)requestUri);
			((HttpResponseMessage)obj3).EnsureSuccessStatusCode();
			object obj4 = JObject.Parse(await ((HttpResponseMessage)obj3).Content.ReadAsStringAsync());
			JToken val = ((JObject)obj4)["code"];
			nint num = ((val != null) ? Extensions.Value<int>((IEnumerable<JToken>)val) : 0);
			if (num == 200)
			{
				object text4 = ((object)((JObject)obj4)["data"])?.ToString();
				((Control)_14).Text = (string)text4;
				_8(null, null);
				return;
			}
			object text5 = ((object)((JObject)obj4)["message"])?.ToString();
			((Control)_38).Text = (string)text5;
		}
		catch (Exception ex)
		{
			object obj5 = ex;
			((Control)_38).Text = ((Exception)obj5).Message;
		}
		finally
		{
			((IDisposable)obj2)?.Dispose();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_10 != null)
		{
			((IDisposable)this.m_10).Dispose();
		}
		base.Dispose(disposing);
	}

	private void _2b()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected Obj, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected Obj, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected Obj, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected Obj, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected Obj, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected Obj, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected Obj, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected Obj, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected Obj, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected Obj, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected Obj, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected Obj, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected Obj, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected Obj, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected Obj, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected Obj, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected Obj, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected Obj, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected Obj, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected Obj, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected Obj, but got Unknown
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected Obj, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected Obj, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected Obj, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected Obj, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected Obj, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected Obj, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected Obj, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected Obj, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected Obj, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected Obj, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected Obj, but got Unknown
		//IL_077e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0788: Expected Obj, but got Unknown
		this.m_10 = new Container();
		StyleLine style = new StyleLine();
		StepsItem val = new StepsItem();
		StepsItem val2 = new StepsItem();
		StepsItem val3 = new StepsItem();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Authe));
		this.m_11 = new TextBox();
		this.m_12 = (object)new WindowBar();
		this.m_13 = (object)new Button();
		_31 = new ContextMenuStrip((IContainer)this.m_10);
		_32 = new ToolStripMenuItem();
		_14 = (object)new Input();
		_33 = new ContextMenuStrip((IContainer)this.m_10);
		_34 = new ToolStripMenuItem();
		this.m_15 = (object)new Tabs();
		this.m_16 = (object)new TabPage();
		_35 = (object)new UITextBox();
		this.m_2b = (object)new TabPage();
		_30 = (object)new Steps();
		_2c = (object)new Button();
		_2d = (object)new Input();
		_2e = (object)new Badge();
		_2f = new RichTextBox();
		this.m_17 = (object)new TabPage();
		this.m_22 = (object)new Button();
		this.m_23 = (object)new Button();
		_20 = (object)new Input();
		this.m_21 = (object)new Badge();
		_1f = (object)new Button();
		this.m_1d = (object)new Badge();
		this.m_1e = (object)new Input();
		this.m_1c = (object)new Badge();
		this.m_1a = (object)new Button();
		this.m_19 = (object)new Input();
		this.m_1b = (object)new Input();
		this.m_18 = (object)new TabPage();
		this.m_24 = (object)new Button();
		this.m_25 = (object)new Input();
		this.m_26 = (object)new Badge();
		this.m_27 = (object)new Badge();
		this.m_28 = (object)new Button();
		this.m_29 = (object)new Input();
		_2a = (object)new Input();
		_36 = (object)new TabPage();
		_37 = (object)new Button();
		_38 = (object)new Input();
		_39 = (object)new Badge();
		_3a = (object)new Badge();
		_3b = (object)new Button();
		_3c = (object)new Input();
		_3d = (object)new Input();
		((Control)_31).SuspendLayout();
		((Control)_33).SuspendLayout();
		((Control)this.m_15).SuspendLayout();
		((Control)this.m_16).SuspendLayout();
		((Control)this.m_2b).SuspendLayout();
		((Control)this.m_17).SuspendLayout();
		((Control)this.m_18).SuspendLayout();
		((Control)_36).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)this.m_11).Location = new Point(342, 472);
		((Control)this.m_11).Name = "textBox3";
		((Control)this.m_11).Size = new Size(100, 21);
		((Control)this.m_11).TabIndex = 3;
		((Control)this.m_11).Visible = false;
		((Control)this.m_12).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((WindowBar)this.m_12).IsMax = false;
		((Control)this.m_12).Location = new Point(3, -3);
		((WindowBar)this.m_12).MaximizeBox = false;
		((Control)this.m_12).Name = "windowBar1";
		((Control)this.m_12).Size = new Size(457, 32);
		((WindowBar)this.m_12).SubText = "TMFTool";
		((Control)this.m_12).TabIndex = 67;
		((Control)this.m_12).Text = "Devices Auth ..";
		((Control)this.m_13).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_13).Location = new Point(0, 282);
		((Control)this.m_13).Name = "button1";
		((Control)this.m_13).Size = new Size(434, 32);
		((Control)this.m_13).TabIndex = 68;
		((Control)this.m_13).Text = "Auth";
		((Button)this.m_13).Type = (TTypeMini)1;
		((Button)this.m_13).WaveSize = 0;
		((Control)this.m_13).Click += _8;
		((ToolStrip)_31).Items.AddRange(new ToolStripItem[1] { (ToolStripItem)_32 });
		((Control)_31).Name = "copy";
		((Control)_31).Size = new Size(101, 26);
		((ToolStripDropDown)_31).Opening += _23;
		((ToolStripItem)_32).Name = "复制ToolStripMenuItem";
		((ToolStripItem)_32).Size = new Size(100, 22);
		((ToolStripItem)_32).Text = "复制";
		((ToolStripItem)_32).Click += _26;
		((IControl)_14).Badge = "";
		((Control)_14).ContextMenuStrip = (ContextMenuStrip)_33;
		((Control)_14).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_14).Location = new Point(0, 50);
		((Input)_14).Multiline = true;
		((Control)_14).Name = "textBox2";
		((Input)_14).PlaceholderText = "Sign Key";
		((Control)_14).Size = new Size(432, 224);
		((Control)_14).TabIndex = 70;
		((Input)_14).WaveSize = 0;
		((ToolStrip)_33).Items.AddRange(new ToolStripItem[1] { (ToolStripItem)_34 });
		((Control)_33).Name = "contextMenuStrip1";
		((Control)_33).Size = new Size(101, 26);
		((ToolStripDropDown)_33).Opening += _24;
		((ToolStripItem)_34).Name = "粘贴ToolStripMenuItem";
		((ToolStripItem)_34).Size = new Size(100, 22);
		((ToolStripItem)_34).Text = "粘贴";
		((ToolStripItem)_34).Click += _25;
		((Control)this.m_15).Cursor = Cursors.Default;
		((Control)this.m_15).Font = new Font("Microsoft YaHei UI", 9f);
		((Control)this.m_15).Location = new Point(8, 35);
		((Control)this.m_15).Name = "tabs1";
		((iCollection<TabPage>)(object)((Tabs)this.m_15).Pages).Add((TabPage)this.m_16);
		((iCollection<TabPage>)(object)((Tabs)this.m_15).Pages).Add((TabPage)this.m_2b);
		((iCollection<TabPage>)(object)((Tabs)this.m_15).Pages).Add((TabPage)this.m_17);
		((iCollection<TabPage>)(object)((Tabs)this.m_15).Pages).Add((TabPage)this.m_18);
		((iCollection<TabPage>)(object)((Tabs)this.m_15).Pages).Add((TabPage)_36);
		((Control)this.m_15).Size = new Size(440, 345);
		((Tabs)this.m_15).Style = (IStyle)(object)style;
		((Control)this.m_15).TabIndex = 71;
		((Control)this.m_15).Text = "tabs1";
		((Tabs)this.m_15).SelectedIndexChanged += _1a;
		((Control)this.m_16).Controls.Add((Control)_35);
		((Control)this.m_16).Controls.Add((Control)this.m_13);
		((Control)this.m_16).Controls.Add((Control)_14);
		((Control)this.m_16).Dock = DockStyle.Fill;
		((Control)this.m_16).Location = new Point(3, 28);
		((Control)this.m_16).Name = "tabPagemal";
		((Control)this.m_16).Size = new Size(434, 314);
		((Control)this.m_16).TabIndex = 0;
		((Control)this.m_16).Text = "计算";
		((UITextBox)_35).ButtonSymbol = 557677;
		((Control)_35).Cursor = Cursors.Default;
		((Control)_35).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_35).Location = new Point(0, 9);
		((Control)_35).Margin = new Padding(4, 5, 4, 5);
		((Control)_35).MinimumSize = new Size(1, 16);
		((Control)_35).Name = "textBox1";
		((Control)_35).Padding = new Padding(5);
		((UITextBox)_35).ReadOnly = true;
		((UIUserControl)_35).RectColor = Color.FromArgb(224, 224, 224);
		((UITextBox)_35).ShowButton = true;
		((UIPanel)_35).ShowText = false;
		((Control)_35).Size = new Size(434, 33);
		((Control)_35).TabIndex = 75;
		((UIUserControl)_35).TextAlignment = ContentAlignment.MiddleLeft;
		((UITextBox)_35).Watermark = "";
		((UITextBox)_35).ButtonClick += _27;
		((Control)this.m_2b).Controls.Add((Control)_30);
		((Control)this.m_2b).Controls.Add((Control)_2c);
		((Control)this.m_2b).Controls.Add((Control)_2d);
		((Control)this.m_2b).Controls.Add((Control)_2e);
		((Control)this.m_2b).Controls.Add((Control)_2f);
		((Control)this.m_2b).Dock = DockStyle.Fill;
		((Control)this.m_2b).Location = new Point(3, 28);
		((Control)this.m_2b).Name = "tabPage1";
		((Control)this.m_2b).Size = new Size(434, 314);
		((Control)this.m_2b).TabIndex = 0;
		((Control)this.m_2b).Text = "查找检查FMi";
		((Control)this.m_2b).Visible = false;
		((Control)_30).Font = new Font("Microsoft YaHei UI", 9f);
		val.Description = "验证你的设备";
		val.Title = "发送请求";
		val2.Description = "验证FMi";
		val2.Title = "等待服务器响应";
		val3.Description = "得到结果";
		val3.Title = "查询完毕";
		((iCollection<StepsItem>)(object)((Steps)_30).Items).Add(val);
		((iCollection<StepsItem>)(object)((Steps)_30).Items).Add(val2);
		((iCollection<StepsItem>)(object)((Steps)_30).Items).Add(val3);
		((Control)_30).Location = new Point(2, 34);
		((Control)_30).Name = "steph";
		((Control)_30).RightToLeft = RightToLeft.No;
		((Control)_30).Size = new Size(421, 58);
		((Control)_30).TabIndex = 82;
		((Control)_30).Text = "steps1";
		((Control)_2c).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_2c).Location = new Point(4, 285);
		((Control)_2c).Name = "fmibutton2";
		((Control)_2c).Size = new Size(418, 32);
		((Control)_2c).TabIndex = 80;
		((Control)_2c).Text = "检查";
		((Button)_2c).Type = (TTypeMini)1;
		((Button)_2c).WaveSize = 0;
		((Control)_2c).Click += _21;
		((IControl)_2d).Badge = "";
		((Control)_2d).Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_2d).Location = new Point(4, 149);
		((Input)_2d).Multiline = true;
		((Control)_2d).Name = "input1";
		((Input)_2d).PlaceholderText = "";
		((Input)_2d).ReadOnly = true;
		((Control)_2d).Size = new Size(420, 124);
		((Input)_2d).Status = (TType)1;
		((Control)_2d).TabIndex = 79;
		((Input)_2d).WaveSize = 0;
		((Control)_2e).Font = new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_2e).Location = new Point(5, 111);
		((Control)_2e).Name = "badge5";
		((Control)_2e).Size = new Size(120, 32);
		((Badge)_2e).State = (TState)5;
		((Control)_2e).TabIndex = 78;
		((Control)_2e).Text = "日志";
		((Control)_2f).Location = new Point(308, 149);
		((Control)_2f).Name = "qingqiu";
		((Control)_2f).Size = new Size(113, 114);
		((Control)_2f).TabIndex = 81;
		((Control)_2f).Text = "";
		((Control)_2f).Visible = false;
		((Control)this.m_17).Controls.Add((Control)this.m_22);
		((Control)this.m_17).Controls.Add((Control)this.m_23);
		((Control)this.m_17).Controls.Add((Control)_20);
		((Control)this.m_17).Controls.Add((Control)this.m_21);
		((Control)this.m_17).Controls.Add((Control)_1f);
		((Control)this.m_17).Controls.Add((Control)this.m_1d);
		((Control)this.m_17).Controls.Add((Control)this.m_1e);
		((Control)this.m_17).Controls.Add((Control)this.m_1c);
		((Control)this.m_17).Controls.Add((Control)this.m_1a);
		((Control)this.m_17).Controls.Add((Control)this.m_19);
		((Control)this.m_17).Controls.Add((Control)this.m_1b);
		((Control)this.m_17).Dock = DockStyle.Fill;
		((Control)this.m_17).Location = new Point(3, 28);
		((Control)this.m_17).Name = "tabPagetimi";
		((Control)this.m_17).Size = new Size(434, 314);
		((Control)this.m_17).TabIndex = 0;
		((Control)this.m_17).Text = "TiMi Auth";
		((Control)this.m_17).Visible = false;
		((Control)this.m_22).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_22).Location = new Point(329, 126);
		((Control)this.m_22).Name = "button7";
		((Control)this.m_22).Size = new Size(95, 32);
		((Control)this.m_22).TabIndex = 79;
		((Control)this.m_22).Text = "开始签名";
		((Button)this.m_22).Type = (TTypeMini)1;
		((Button)this.m_22).WaveSize = 0;
		((Control)this.m_22).Click += _11;
		((Control)this.m_23).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_23).Location = new Point(108, 126);
		((Control)this.m_23).Name = "button4";
		((Control)this.m_23).Size = new Size(95, 32);
		((Control)this.m_23).TabIndex = 78;
		((Control)this.m_23).Text = "开始签名";
		((Button)this.m_23).Type = (TTypeMini)1;
		((Button)this.m_23).WaveSize = 0;
		((Control)this.m_23).Click += f;
		((IControl)_20).Badge = "";
		((Control)_20).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_20).Location = new Point(3, 202);
		((Input)_20).Multiline = true;
		((Control)_20).Name = "richTextBox2";
		((Input)_20).PlaceholderText = "";
		((Input)_20).ReadOnly = true;
		((Control)_20).Size = new Size(421, 108);
		((Input)_20).Status = (TType)1;
		((Control)_20).TabIndex = 77;
		((Input)_20).WaveSize = 0;
		((Control)this.m_21).Font = new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_21).Location = new Point(3, 164);
		((Control)this.m_21).Name = "badge3";
		((Control)this.m_21).Size = new Size(120, 32);
		((Badge)this.m_21).State = (TState)5;
		((Control)this.m_21).TabIndex = 76;
		((Control)this.m_21).Text = "日志";
		((Control)_1f).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_1f).Location = new Point(221, 126);
		((Control)_1f).Name = "button6";
		((Control)_1f).Size = new Size(95, 32);
		((Control)_1f).TabIndex = 75;
		((Control)_1f).Text = "登录TiMi卡密";
		((Button)_1f).Type = (TTypeMini)1;
		((Button)_1f).WaveSize = 0;
		((Control)_1f).Click += _10;
		((Control)this.m_1d).Font = new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_1d).Location = new Point(221, 12);
		((Control)this.m_1d).Name = "badge1";
		((Control)this.m_1d).Size = new Size(120, 32);
		((Badge)this.m_1d).State = (TState)2;
		((Control)this.m_1d).TabIndex = 74;
		((Control)this.m_1d).Text = "卡密登录";
		((IControl)this.m_1e).Badge = "";
		((Control)this.m_1e).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_1e).Location = new Point(221, 50);
		((Input)this.m_1e).Multiline = true;
		((Control)this.m_1e).Name = "textBox8";
		((Input)this.m_1e).PlaceholderText = "卡密";
		((Control)this.m_1e).Size = new Size(200, 70);
		((Input)this.m_1e).Status = (TType)1;
		((Control)this.m_1e).TabIndex = 73;
		((Input)this.m_1e).WaveSize = 0;
		((Control)this.m_1c).Font = new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_1c).Location = new Point(3, 12);
		((Control)this.m_1c).Name = "badge2";
		((Control)this.m_1c).Size = new Size(120, 32);
		((Badge)this.m_1c).State = (TState)2;
		((Control)this.m_1c).TabIndex = 72;
		((Control)this.m_1c).Text = "账号登录";
		((Control)this.m_1c).Click += _19;
		((Control)this.m_1a).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_1a).Location = new Point(3, 126);
		((Control)this.m_1a).Name = "button5";
		((Control)this.m_1a).Size = new Size(95, 32);
		((Control)this.m_1a).TabIndex = 72;
		((Control)this.m_1a).Text = "登录TiMi账号";
		((Button)this.m_1a).Type = (TTypeMini)1;
		((Button)this.m_1a).WaveSize = 0;
		((Control)this.m_1a).Click += d;
		((IControl)this.m_19).Badge = "";
		((Control)this.m_19).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_19).Location = new Point(3, 50);
		((Control)this.m_19).Name = "textBox7";
		((Input)this.m_19).PlaceholderText = "账号";
		((Control)this.m_19).Size = new Size(200, 32);
		((Input)this.m_19).Status = (TType)1;
		((Control)this.m_19).TabIndex = 69;
		((Input)this.m_19).WaveSize = 0;
		((IControl)this.m_1b).Badge = "";
		((Control)this.m_1b).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_1b).Location = new Point(3, 88);
		((Control)this.m_1b).Name = "textBox6";
		((Input)this.m_1b).PasswordChar = '~';
		((Input)this.m_1b).PlaceholderText = "密码";
		((Control)this.m_1b).Size = new Size(200, 32);
		((Input)this.m_1b).Status = (TType)1;
		((Control)this.m_1b).TabIndex = 70;
		((Input)this.m_1b).WaveSize = 0;
		((Control)this.m_18).Controls.Add((Control)this.m_24);
		((Control)this.m_18).Controls.Add((Control)this.m_25);
		((Control)this.m_18).Controls.Add((Control)this.m_26);
		((Control)this.m_18).Controls.Add((Control)this.m_27);
		((Control)this.m_18).Controls.Add((Control)this.m_28);
		((Control)this.m_18).Controls.Add((Control)this.m_29);
		((Control)this.m_18).Controls.Add((Control)_2a);
		((Control)this.m_18).Dock = DockStyle.Fill;
		((Control)this.m_18).Location = new Point(3, 28);
		((Control)this.m_18).Name = "tabPagewm";
		((Control)this.m_18).Size = new Size(434, 314);
		((Control)this.m_18).TabIndex = 0;
		((Control)this.m_18).Text = "Wuming Auth";
		((Control)this.m_18).Visible = false;
		((Control)this.m_24).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_24).Location = new Point(221, 126);
		((Control)this.m_24).Name = "button11";
		((Control)this.m_24).Size = new Size(200, 32);
		((Control)this.m_24).TabIndex = 89;
		((Control)this.m_24).Text = "开始签名";
		((Button)this.m_24).Type = (TTypeMini)1;
		((Button)this.m_24).WaveSize = 0;
		((Control)this.m_24).Click += _18;
		((IControl)this.m_25).Badge = "";
		((Control)this.m_25).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_25).Location = new Point(3, 202);
		((Input)this.m_25).Multiline = true;
		((Control)this.m_25).Name = "richTextBox3";
		((Input)this.m_25).PlaceholderText = "";
		((Input)this.m_25).ReadOnly = true;
		((Control)this.m_25).Size = new Size(418, 108);
		((Input)this.m_25).Status = (TType)1;
		((Control)this.m_25).TabIndex = 88;
		((Input)this.m_25).WaveSize = 0;
		((Control)this.m_26).Font = new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_26).Location = new Point(3, 164);
		((Control)this.m_26).Name = "badge4";
		((Control)this.m_26).Size = new Size(120, 32);
		((Badge)this.m_26).State = (TState)5;
		((Control)this.m_26).TabIndex = 87;
		((Control)this.m_26).Text = "日志";
		((Control)this.m_27).Font = new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_27).Location = new Point(3, 12);
		((Control)this.m_27).Name = "badge6";
		((Control)this.m_27).Size = new Size(120, 32);
		((Badge)this.m_27).State = (TState)2;
		((Control)this.m_27).TabIndex = 82;
		((Control)this.m_27).Text = "账号登录";
		((Control)this.m_28).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_28).Location = new Point(3, 126);
		((Control)this.m_28).Name = "button12";
		((Control)this.m_28).Size = new Size(200, 32);
		((Control)this.m_28).TabIndex = 83;
		((Control)this.m_28).Text = "登录Wuming账号";
		((Button)this.m_28).Type = (TTypeMini)1;
		((Button)this.m_28).WaveSize = 0;
		((Control)this.m_28).Click += _17;
		((IControl)this.m_29).Badge = "";
		((Control)this.m_29).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)this.m_29).Location = new Point(3, 50);
		((Control)this.m_29).Name = "textBox12";
		((Input)this.m_29).PlaceholderText = "账号";
		((Control)this.m_29).Size = new Size(418, 32);
		((Input)this.m_29).Status = (TType)1;
		((Control)this.m_29).TabIndex = 80;
		((Input)this.m_29).WaveSize = 0;
		((IControl)_2a).Badge = "";
		((Control)_2a).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_2a).Location = new Point(3, 88);
		((Control)_2a).Name = "textBox11";
		((Input)_2a).PasswordChar = '~';
		((Input)_2a).PlaceholderText = "密码";
		((Control)_2a).Size = new Size(418, 32);
		((Input)_2a).Status = (TType)1;
		((Control)_2a).TabIndex = 81;
		((Input)_2a).WaveSize = 0;
		((Control)_36).Controls.Add((Control)_37);
		((Control)_36).Controls.Add((Control)_38);
		((Control)_36).Controls.Add((Control)_39);
		((Control)_36).Controls.Add((Control)_3a);
		((Control)_36).Controls.Add((Control)_3b);
		((Control)_36).Controls.Add((Control)_3c);
		((Control)_36).Controls.Add((Control)_3d);
		((Control)_36).Dock = DockStyle.Fill;
		((Control)_36).Location = new Point(3, 28);
		((Control)_36).Name = "tabPage2";
		((Control)_36).Size = new Size(434, 314);
		((Control)_36).TabIndex = 0;
		((Control)_36).Text = "Crasher Auth";
		((Control)_36).Visible = false;
		((Control)_37).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_37).Location = new Point(221, 124);
		((Control)_37).Name = "CrAuthBt";
		((Control)_37).Size = new Size(200, 32);
		((Control)_37).TabIndex = 96;
		((Control)_37).Text = "开始签名";
		((Button)_37).Type = (TTypeMini)1;
		((Button)_37).WaveSize = 0;
		((Control)_37).Click += _29;
		((IControl)_38).Badge = "";
		((Control)_38).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_38).Location = new Point(3, 200);
		((Input)_38).Multiline = true;
		((Control)_38).Name = "Crlog";
		((Input)_38).PlaceholderText = "";
		((Input)_38).ReadOnly = true;
		((Control)_38).Size = new Size(418, 108);
		((Input)_38).Status = (TType)1;
		((Control)_38).TabIndex = 95;
		((Input)_38).WaveSize = 0;
		((Control)_39).Font = new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_39).Location = new Point(3, 162);
		((Control)_39).Name = "badge7";
		((Control)_39).Size = new Size(120, 32);
		((Badge)_39).State = (TState)5;
		((Control)_39).TabIndex = 94;
		((Control)_39).Text = "日志";
		((Control)_3a).Font = new Font("Microsoft YaHei UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_3a).Location = new Point(3, 10);
		((Control)_3a).Name = "badge8";
		((Control)_3a).Size = new Size(120, 32);
		((Badge)_3a).State = (TState)2;
		((Control)_3a).TabIndex = 92;
		((Control)_3a).Text = "账号登录";
		((Control)_3b).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_3b).Location = new Point(3, 124);
		((Control)_3b).Name = "CrLoginBut";
		((Control)_3b).Size = new Size(200, 32);
		((Control)_3b).TabIndex = 93;
		((Control)_3b).Text = "登录Crasher Auth账号";
		((Button)_3b).Type = (TTypeMini)1;
		((Button)_3b).WaveSize = 0;
		((Control)_3b).Click += _28;
		((IControl)_3c).Badge = "";
		((Control)_3c).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_3c).Location = new Point(3, 48);
		((Control)_3c).Name = "CRusertext";
		((Input)_3c).PlaceholderText = "账号";
		((Control)_3c).Size = new Size(418, 32);
		((Input)_3c).Status = (TType)1;
		((Control)_3c).TabIndex = 90;
		((Input)_3c).WaveSize = 0;
		((IControl)_3d).Badge = "";
		((Control)_3d).Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		((Control)_3d).Location = new Point(3, 86);
		((Control)_3d).Name = "Crpassword";
		((Input)_3d).PasswordChar = '~';
		((Input)_3d).PlaceholderText = "密码";
		((Control)_3d).Size = new Size(418, 32);
		((Input)_3d).Status = (TType)1;
		((Control)_3d).TabIndex = 91;
		((Input)_3d).WaveSize = 0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 12f);
		((ContainerControl)this).AutoScaleMode = AutoScaleMode.Font;
		((Form)this).ClientSize = new Size(455, 388);
		((Control)this).Controls.Add((Control)this.m_15);
		((Control)this).Controls.Add((Control)this.m_12);
		((Control)this).Controls.Add((Control)this.m_11);
		((Form)this).FormBorderStyle = FormBorderStyle.FixedDialog;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Authe";
		((Window)this).Resizable = false;
		((Form)this).StartPosition = FormStartPosition.CenterScreen;
		((Control)(object)this).Text = "小米高通授权弹窗 ";
		((Form)this).TopMost = true;
		((Form)this).FormClosing += _22;
		((Form)this).Load += a;
		((Control)_31).ResumeLayout(false);
		((Control)_33).ResumeLayout(false);
		((Control)this.m_15).ResumeLayout(false);
		((Control)this.m_16).ResumeLayout(false);
		((Control)this.m_2b).ResumeLayout(false);
		((Control)this.m_17).ResumeLayout(false);
		((Control)this.m_18).ResumeLayout(false);
		((Control)_36).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static Authe()
	{
		Authe.m_8 = new HttpClient();
		Authe.m_c = "vUMOvZPH8wjmmExm0QbAcsBwVY6TYBU9";
		Authe.m_d = "1234567890123456";
		sBasesUrl = "http://apis-xiaomi.com";
	}
}
