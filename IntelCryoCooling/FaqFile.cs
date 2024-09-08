using System;
using System.Diagnostics;
using System.IO;
using IntelCryoCooling.Properties;
using NLog;

namespace IntelCryoCooling;

internal class FaqFile : IFaq
{
	private static Logger log = LogManager.GetCurrentClassLogger();

	public bool Launch(string fwVersion, ref string msg)
	{
		bool result = true;
		msg = "";
		try
		{
			string text = Path.GetTempPath() + "\\faq.pdf";
			byte[] array = null;
			if (fwVersion.EndsWith("A0") || fwVersion.EndsWith("A1"))
			{
				array = Resources.FAQ_CM;
			}
			else if (fwVersion.EndsWith("B0") || fwVersion.EndsWith("B1") || fwVersion.EndsWith("B2"))
			{
				array = (fwVersion.EndsWith("B0") ? Resources.FAQ_EK : Resources.FAQ_EK_Gen2);
			}
			else if (fwVersion.EndsWith("E1"))
			{
				array = Resources.FAQ_CM;
			}
			else
			{
				result = false;
				msg = "Invalid firmware version detected. FAQ is not available.";
				log.Warn("Invalid fw version : {0}. FAQ request failed", fwVersion);
			}
			if (array != null && array.Length != 0)
			{
				File.WriteAllBytes(text, array);
				if (true)
				{
					Process.Start(text);
				}
			}
		}
		catch (Exception ex)
		{
			result = false;
			msg = ex.Message;
			log.Error("Exception occured in opening help file. Details: {0}", ex.Message);
		}
		return result;
	}
}
