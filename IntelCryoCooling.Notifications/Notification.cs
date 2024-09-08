using System.Windows.Forms;

namespace IntelCryoCooling.Notifications;

internal class Notification
{
	internal string Message { get; set; }

	internal TrayIconColor TrayIconColor { get; set; }

	internal bool ShowBaloonTip { get; set; }

	internal ToolTipIcon ToolTipIcon { get; set; }
}
