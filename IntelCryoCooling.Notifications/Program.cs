using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using NLog;

namespace IntelCryoCooling.Notifications;

internal static class Program
{
	private static Logger log = LogManager.GetCurrentClassLogger();

	[STAThread]
	private static void Main()
	{
		try
		{
			if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1 && MessageBox.Show(GetEnumDescription(UIErrorCodes.MultipleProcessError), "Intel® Cryo Cooling Technology", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
			{
				log.Error("User accepted warning, Cryo Cooling Notifications is already running.");
				Process.GetCurrentProcess().Kill();
			}
			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
			string swVersion = GetSwVersion();
			log.Info("Cryo Cooling Notifications SW version : {0}", swVersion);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			using TrayIcon trayIcon = new TrayIcon();
			trayIcon.Display();
			Application.Run();
		}
		catch (Exception ex)
		{
			log.Error("Program : {ex}", ex.Message.ToString());
		}
		Console.WriteLine();
    }

	internal static string GetSwVersion()
	{
		return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
	}

	public static string GetEnumDescription(Enum value)
	{
		if (value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit: false) is DescriptionAttribute[] source && source.Any())
		{
			return source.First().Description;
		}
		return value.ToString();
	}
}
