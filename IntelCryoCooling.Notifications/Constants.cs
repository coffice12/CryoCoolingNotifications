namespace IntelCryoCooling.Notifications;

internal class Constants
{
	internal const string APPLICATION_NAME = "Intel® Cryo Cooling Technology";

	internal const string SERVICE_NAME = "SacWindowsService";

	internal const string WIN32_SCOPE = "root\\CIMV2";

	internal const string WIN32_OPERATING_SYSTEM = "SELECT * FROM Win32_OperatingSystem";

	internal const string WIN32_PROCESSOR = "SELECT * FROM Win32_Processor";

	internal const int UPDATE_INTERVAL_IN_MS = 259200000;

	internal const string SWUPDATE_LANG = "en";

	internal const string SWUPDATE_PLATFORM = "x64";

	internal const string SWUPDATE_MANIFEST_URL = "https://downloadmirror.intel.com/715182/config.xml";

	internal const string SWUPDATE_PRODUCT_NAME = "Intel Cryo Cooling Technology";

	internal const string SWUPDATE_REGISTRY_PATH = "Software\\Intel Corporation\\Intel Cryo Cooling Technology\\Updates";

	internal const string SWUPDATE_ERROR_MESSAGE = "Intel(R) Cryo Cooling Technology Software update failed.";

	internal const string SWCRYOMODE_REGISTRY_PATH = "Software\\Intel Corporation\\Intel Cryo Cooling Technology\\CryoMode";

	internal const string FAQ_EK_URL = "https://www.ekwb.com/customer-support/";

	internal const string FAQ_CM_URL = "https://www.coolermaster.com/downloads/pl360-sub-zero-v2/";
}
