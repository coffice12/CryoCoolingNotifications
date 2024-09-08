using System;
using System.Diagnostics;
using NLog;

namespace IntelCryoCooling;

internal class FaqWeb : IFaq
{
	private static Logger log = LogManager.GetCurrentClassLogger();

	public bool Launch(string fwVersion, ref string msg)
	{
		bool result = true;
		msg = "";
		try
		{
			if (fwVersion.EndsWith("A0") || fwVersion.EndsWith("A1"))
			{
				Process.Start("https://www.coolermaster.com/downloads/pl360-sub-zero-v2/");
			}
			else if (fwVersion.EndsWith("B0") || fwVersion.EndsWith("B1") || fwVersion.EndsWith("B2"))
			{
				Process.Start("https://www.ekwb.com/customer-support/");
			}
			else if (fwVersion.EndsWith("E1"))
			{
				Process.Start("https://www.coolermaster.com/downloads/pl360-sub-zero-v2/");
			}
			else
			{
				result = false;
				msg = "Invalid firmware version detected. Support link is not available.";
				log.Warn("Invalid fw version : {0}. Support link is not available.", fwVersion);
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
