using System;
using System.Globalization;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using NLog;

namespace IntelCryoCooling;

public static class SystemInfoHelper
{
	private static readonly Logger log = LogManager.GetCurrentClassLogger();

	private static readonly string MinimumMicrocodeVersion = "E2";

	private static ManagementObjectCollection GetQueryObject(string query)
	{
		ManagementObjectSearcher managementObjectSearcher = null;
		try
		{
			managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", query);
		}
		catch (Exception)
		{
			log.Error("Exception occured in getting WMI information");
		}
		return managementObjectSearcher.Get();
	}

	public static string GetOSInfo()
	{
		string empty = string.Empty;
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ManagementObject item in GetQueryObject("SELECT * FROM Win32_OperatingSystem"))
			{
				stringBuilder.Append("Build Number: " + item["BuildNumber"]);
				stringBuilder.Append(", Version: " + item["Version"]);
				stringBuilder.Append(", OSArchitecture: " + item["OSArchitecture"]);
			}
			CultureInfo installedUICulture = CultureInfo.InstalledUICulture;
			stringBuilder.Append(", Installed Language: " + installedUICulture.Name);
			installedUICulture = CultureInfo.CurrentUICulture;
			stringBuilder.Append(", UI Language: " + installedUICulture.Name);
			installedUICulture = CultureInfo.CurrentCulture;
			stringBuilder.Append(", Current Language: " + installedUICulture.Name);
			return stringBuilder.ToString();
		}
		catch (Exception)
		{
			log.Error("Exception occured in validating OS.");
			return empty;
		}
	}

	public static int GetProcessorCores()
	{
		try
		{
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = GetQueryObject("SELECT * FROM Win32_Processor").GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				return Convert.ToInt32(((ManagementObject)managementObjectEnumerator.Current)["NumberOfCores"].ToString());
			}
		}
		catch (Exception)
		{
			log.Error("Exception occured in getting processor details.");
		}
		return 0;
	}

	public static string GetProcessor()
	{
		string result = "";
		try
		{
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = GetQueryObject("SELECT * FROM Win32_Processor").GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				return ((ManagementObject)managementObjectEnumerator.Current)["Name"].ToString();
			}
		}
		catch (Exception)
		{
			log.Error("Exception occured in validating OS.");
		}
		return result;
	}

	public static string GetUSBDevicesFromRegistry()
	{
		StringBuilder stringBuilder = new StringBuilder();
		string[] subKeyNames = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\USB").GetSubKeyNames();
		foreach (string value in subKeyNames)
		{
			stringBuilder.AppendLine(value);
		}
		return stringBuilder.ToString();
	}

	public static bool CheckKSku(string cpuBrand, out string[] cpumodel)
	{
		string pattern = "(.*)Intel(.*)i([1-9])-([1-9])([0-9])([0-9]+)(K|KF|KS)(\\s|$)";
		cpumodel = new string[3];
		MatchCollection matchCollection = Regex.Matches(cpuBrand, pattern);
		if (matchCollection != null && matchCollection.Count > 0)
		{
			int num = 3;
			foreach (Match item in matchCollection)
			{
				GroupCollection groups = item.Groups;
				cpumodel[0] = groups[num].Value;
				cpumodel[1] = groups[num + 1].Value + groups[num + 2].Value;
				cpumodel[2] = groups[num + 4].Value;
			}
		}
		return Regex.IsMatch(cpuBrand, pattern);
	}

	public static bool CheckOcTvbStatus(string sysinfo, ref string microcodeVersion)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		string text = "";
		string text2 = "NA";
		string[] cpumodel = null;
		string[] array = sysinfo.Split(';');
		if (array.Length != 0)
		{
			string[] array2 = array;
			foreach (string text3 in array2)
			{
				string[] array3 = text3.Split(':');
				if (text3.IndexOf("CPU Brand String", StringComparison.CurrentCultureIgnoreCase) != -1)
				{
					text = array3[1];
					log.Debug("Cpu Brand is: {}", text);
					flag = CheckKSku(text, out cpumodel);
					log.Debug("SKU: {0}, CPU Family Gen: {1}", cpumodel[2], cpumodel[1]);
					int result = -1;
					if (int.TryParse(cpumodel[1], out result))
					{
						flag3 = result >= 12;
					}
				}
				else if (text3.IndexOf("Micro code", StringComparison.CurrentCultureIgnoreCase) != -1)
				{
					text2 = array3[1];
					string pattern = "^(0x)?0*";
					microcodeVersion = Regex.Replace(text2.Trim(), pattern, "");
					log.Debug("Detected micro code version - {0}", microcodeVersion);
					flag2 = !string.IsNullOrEmpty(microcodeVersion) && int.Parse(microcodeVersion, NumberStyles.HexNumber) >= int.Parse(MinimumMicrocodeVersion, NumberStyles.HexNumber);
				}
			}
		}
		bool flag4 = flag && (flag3 || flag2);
		log.Debug($"OC TVB Enabled? {flag4}: ADL? {flag3}, K/KF SKU? {flag}, Min Micro code Ver.? {flag2}");
		return flag4;
	}

	public static string GetCurrentUserRegistrySetting(string path, string param)
	{
		string result = "";
		try
		{
			using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(path);
			if (registryKey != null)
			{
				object value = registryKey.GetValue(param);
				if (value != null)
				{
					result = (string)value;
				}
			}
		}
		catch (Exception)
		{
			log.Debug("Exception reading cryo mode registry key.");
		}
		return result;
	}
}
