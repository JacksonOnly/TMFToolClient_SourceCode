using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Sunny.UI;

namespace qc;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, args) => ReportError(args.Exception);
        AppDomain.CurrentDomain.UnhandledException += (_, args) => WriteError(args.ExceptionObject as Exception);
        using Mutex mutex = new Mutex(false, "{b19b2e0f-1f6c-4ec1-a5d1-1c5b6e6e5b80}");
        bool acquired = false;
        try
        {
            try { acquired = mutex.WaitOne(TimeSpan.Zero); }
            catch (AbandonedMutexException) { acquired = true; }
            if (!acquired)
            {
                UIMessageBox.Show("TMFTool已在运行中!", "小提示", (UIStyle)4, (UIMessageBoxButtons)0, false, true, 0);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using LoginFrom loginFrom = new LoginFrom();
            if (loginFrom.ShowDialog() == DialogResult.OK)
            {
                using Form1 mainForm = new Form1(loginFrom.token, loginFrom.name, loginFrom.sapi, loginFrom.logintimer, loginFrom.PASS, loginFrom.Tile, loginFrom.token, loginFrom.type, loginFrom.role, loginFrom.Steer, loginFrom.Lang, loginFrom.modules);
                Application.Run(mainForm);
            }
        }
        catch (Exception exception) { ReportError(exception); }
        finally { if (acquired) mutex.ReleaseMutex(); }
    }

    private static string WriteError(Exception exception)
    {
        try
        {
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TMFTool", "logs");
            Directory.CreateDirectory(directory);
            string path = Path.Combine(directory, "startup.log");
            File.AppendAllText(path, $"{DateTime.Now:O}{Environment.NewLine}{exception}{Environment.NewLine}");
            return path;
        }
        catch { return "日志写入失败"; }
    }

    private static void ReportError(Exception exception)
    {
        string path = WriteError(exception);
        MessageBox.Show($"程序遇到错误：{exception.Message}{Environment.NewLine}详细日志：{path}", "TMFTool", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
