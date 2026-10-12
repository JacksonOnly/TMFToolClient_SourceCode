using System;
using System.IO;
using System.Windows.Forms;
using TMF_ENt.AES;
using TMF_ENt.AES.HWID;

namespace qc.Password;

internal class PasswordHandler
{
	public string user;

	public string password;

	private object _2 = "TMFTool_user";

	public void ReadPassword()
	{
		try
		{
			string hWID = HWIDGenerator.GetHWID();
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path = Path.Combine(folderPath, (string)_2);
			if (!File.Exists(path))
			{
				return;
			}
			string cipherText = File.ReadAllText(path);
			string text = AesHelper.Decrypt(cipherText);
			string[] array = text.Split(':');
			if (array.Length == 3)
			{
				user = array[0];
				password = array[1];
				string text2 = array[2];
				if (text2 != hWID)
				{
					MessageBox.Show("无效的用户凭证，请重新登录！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					user = null;
					password = null;
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("读取保存的账号和密码时出错: " + ex.Message);
		}
	}

	public void Deleteuser()
	{
		try
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path = Path.Combine(folderPath, (string)_2);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			else
			{
				MessageBox.Show("没有找到保存的账户文件");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("删除账户文件时出错: " + ex.Message);
		}
	}

	public void SavePassword(string username, string password, string hwid)
	{
		try
		{
			string plainText = username + ":" + password + ":" + hwid;
			string value = AesHelper.Encrypt(plainText);
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string path = Path.Combine(folderPath, (string)_2);
			using (StreamWriter streamWriter = new StreamWriter(path, append: false))
			{
				streamWriter.WriteLine(value);
			}
			Console.WriteLine("Password saved successfully.");
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error occurred: " + ex.Message);
		}
	}
}
