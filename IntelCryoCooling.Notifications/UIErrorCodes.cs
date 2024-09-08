using System.ComponentModel;

namespace IntelCryoCooling.Notifications;

internal enum UIErrorCodes
{
	[Description("Cryo Cooling Notifications is already running either by you or another user.")]
	MultipleProcessError,
	[Description("An error occured while running the test")]
	DiagnosticTestError,
	[Description("Cooler working OK")]
	DiagnosticTestPassed,
	[Description("Cooler not working as expected")]
	DiagnosticTestFailed,
	[Description("This cooling solution is not supported on this processor. Please uninstall the application.")]
	InvalidCPU,
	[Description("Invalid configuration detected, please contact cooler manufacturer support")]
	InvalidFW,
	[Description("Unable to establish connection with cooler")]
	NoCooler,
	[Description("Unable to establish connection with service")]
	ServiceConnectionFailed,
	[Description("Cryo Cooling service is not running. Please start the service.")]
	ServiceStopped,
	[Description("Unregulated Mode may cause condensation, which could result in an electrical short circuit that can cause damage to your computer or create a safety hazard. To minimize this risk, be sure the CPU shroud embedded with your Cryo Cooler is securely fitted and forms an airtight seal between the motherboard and the cooler waterblock. You acknowledge and accept all the risks associated with operating in this mode. Do you want to proceed?")]
	WarnUnregulated,
	[Description("Exiting the tray utility will put the Cryo Cooler in standby mode. You will NOT be able to monitor or use the Cryo cooler anymore.  This action is NOT recommended.")]
	WarnExit
}
