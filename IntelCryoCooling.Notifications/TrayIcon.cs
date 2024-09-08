using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using IntelCryoCooling.CondensationControlServiceRef;
using IntelCryoCooling.Properties;
using Microsoft.Win32;
using NLog;
using SoftwareUpdateLib;

namespace IntelCryoCooling.Notifications;

public class TrayIcon : Form, IDisposable
{
	public sealed class MyCustomMessageBox
	{
		private static volatile MyCustomMessageBox _instance = null;

		private static object padlock = new object();

		public static MyCustomMessageBox Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (padlock)
					{
						if (_instance == null)
						{
							_instance = new MyCustomMessageBox();
						}
					}
				}
				return _instance;
			}
		}

		private MyCustomMessageBox()
		{
		}

		public int ShowMe(string message, string aPPLICATION_NAME, string button1, string button2, MessageBoxIcon icon)
		{
			try
			{
				using CustomMessageBox customMessageBox = new CustomMessageBox(message, aPPLICATION_NAME, button1, button2, icon);
				_isMessageVisible = true;
				customMessageBox.ShowDialog();
				_isMessageVisible = false;
			}
			catch (Exception)
			{
			}
			finally
			{
				_isMessageVisible = false;
			}
			return 0;
		}
	}

	private delegate void ShowMyCustomMessageBoxDelegate(string strMessage, string strCaption, MessageBoxButtons mbButtons, MessageBoxIcon mbIcon);

	private NotifyIcon ni;

	private static Logger log = LogManager.GetCurrentClassLogger();

	private static EndpointAddress endpointAdress = new EndpointAddress("net.pipe://localhost/IntelCryoCooling/ctrlservice");

	private static System.ServiceModel.Channels.Binding binding = new NetNamedPipeBinding();

	private static CryoCoolingServiceClient serviceHandle;

	private System.Threading.Timer RefreshTrayTimer;

	private System.Threading.Timer SoftwareUpdateTimer;

	internal static DiagnosticTest diagnosticform;

	private static int BaloonTipTimeOutInMS = 2000;

	private static int DefaultTimerIntervalInMS = 2450;

	private static int TrayPipeWaitTimeInMS = 3500;

	private static string QueryCommunicationPipe = "Intel.CryoCooling.QueryPipe";

	private static string SWUPDATE_MANIFEST_URL = "https://downloadmirror.intel.com/715182/config.xml";

	private string SwVersion;

	internal static OperationMode currentOperationMode = OperationMode.Pending;

	private TrayIconColor previousIconColor = TrayIconColor.BLUE;

	private string previousMessage = string.Empty;

	private string previousPollErrorMessage = string.Empty;

	private string fwVersion = string.Empty;

	private string microcodeVersion = string.Empty;

	private static IFaq faq = new FaqWeb();

	private Icon ICON_BLUE = Resources.alert_blue;

	private Icon ICON_GREEN = Resources.alert_green;

	private Icon ICON_PURPLE = Resources.alert_purple;

	private Icon ICON_RED = Resources.alert_red;

	private Icon ICON_YELLOW = Resources.alert_yellow;

	private MenuItem currentStatusMessage = new MenuItem();

	private MenuItem statsMessage = new MenuItem();

	private MenuItem statsMessage2 = new MenuItem();

	private MenuItem menuSeparator = new MenuItem();

	private MenuItem selectMode = new MenuItem();

	private MenuItem standByMode = new MenuItem();

	private MenuItem cryoMode = new MenuItem();

	private MenuItem unRegulatedMode = new MenuItem();

	private MenuItem manualMode = new MenuItem();

	private MenuItem about = new MenuItem();

	private MenuItem swVersionMenuItem = new MenuItem();

	private MenuItem fwVersionMenuItem = new MenuItem();

	private MenuItem mcVersionMenuItem = new MenuItem();

	private MenuItem swUpdatesMenuItem = new MenuItem();

	private MenuItem swRememberCryoMenuItem = new MenuItem();

	private MenuItem helpMenuItem = new MenuItem();

	private MenuItem faqMenuItem = new MenuItem();

	private MenuItem testMenuItem = new MenuItem();

	private MenuItem exitMenuItem = new MenuItem();

	internal static MyCustomMessageBox messageboxform;

	private bool IsCoolerReady;

	private bool OnStartupResumeCryoSuccess;

	private bool RememberCryoSetting;

	private IContainer components;

	private bool hasTimerDisabled { get; set; }

	public static bool _isMessageVisible { get; set; }

	private static void ShowMyCustomMessageBox(string strMessage, string strCaption, MessageBoxButtons mbButtons, MessageBoxIcon mbIcon)
	{
		try
		{
			int num = -1;
			if (!_isMessageVisible)
			{
				if (messageboxform == null)
				{
					messageboxform = MyCustomMessageBox.Instance;
				}
				num = ((mbButtons != 0) ? messageboxform.ShowMe(strMessage, strCaption, "OK", "Cancel", mbIcon) : messageboxform.ShowMe(strMessage, strCaption, "OK", "", mbIcon));
			}
			if (num != -1)
			{
				_isMessageVisible = false;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			_isMessageVisible = false;
		}
	}

	public static void ShowMyCustomMessageBoxAsync(string strMessage, string strCaption, MessageBoxButtons mbButtons, MessageBoxIcon mbIcon)
	{
		new ShowMyCustomMessageBoxDelegate(ShowMyCustomMessageBox).BeginInvoke(strMessage, strCaption, mbButtons, mbIcon, null, null);
	}

	public static void ShowMyCustomMessageBoxAsync(string strMessage, string strCaption, MessageBoxButtons mbButtons, MessageBoxIcon mbIcon, ref IAsyncResult asyncResult)
	{
		if (asyncResult == null || asyncResult.IsCompleted)
		{
			ShowMyCustomMessageBoxDelegate showMyCustomMessageBoxDelegate = ShowMyCustomMessageBox;
			asyncResult = showMyCustomMessageBoxDelegate.BeginInvoke(strMessage, strCaption, mbButtons, mbIcon, null, null);
		}
	}

	public TrayIcon()
	{
		InitializeComponent();
		try
		{
			string oSInfo = SystemInfoHelper.GetOSInfo();
			log.Info("Running on windows {0}", oSInfo);
			SwVersion = Program.GetSwVersion();
			log.Info("Running on SW {0}", SwVersion);
			ni = new NotifyIcon
			{
				Text = "Intel® Cryo Cooling Technology"
			};
			SystemEvents.PowerModeChanged += OnPowerChange;
		}
		catch (Exception ex)
		{
			log.Error("Init : {ex}", ex.ToString());
		}
	}

	public void Display()
	{
		try
		{
			ni.Icon = new Icon(ICON_BLUE, ICON_BLUE.Size);
			currentStatusMessage = new MenuItem("Intel® Cryo Cooling Technology");
			currentStatusMessage.Name = "Status";
			currentStatusMessage.Enabled = false;
			statsMessage.Name = "Stats";
			statsMessage.Visible = false;
			statsMessage.Enabled = false;
			statsMessage2.Name = "Stats2";
			statsMessage2.Visible = false;
			statsMessage2.Enabled = false;
			menuSeparator = new MenuItem("-");
			selectMode = new MenuItem("Mode");
			standByMode = new MenuItem(UIMode.Standby.ToString(), ChangeOperationMode);
			cryoMode = new MenuItem(UIMode.Cryo.ToString(), ChangeOperationMode);
			unRegulatedMode = new MenuItem(UIMode.Unregulated.ToString(), ChangeOperationMode);
			manualMode = new MenuItem(UIMode.Manual.ToString(), ChangeOperationMode);
			manualMode.Enabled = false;
			manualMode.BarBreak = true;
			manualMode.Visible = false;
			selectMode.MenuItems.Add(manualMode);
			selectMode.MenuItems.Add(standByMode);
			selectMode.MenuItems.Add(cryoMode);
			selectMode.MenuItems.Add(unRegulatedMode);
			helpMenuItem = new MenuItem("Help");
			testMenuItem = new MenuItem("Run Diagnostic test", RunDiagnosticTest);
			faqMenuItem = new MenuItem("FAQ", OpenFAQ);
			helpMenuItem.MenuItems.Add(faqMenuItem);
			helpMenuItem.MenuItems.Add(testMenuItem);
			swVersionMenuItem = new MenuItem($"SW Version : {SwVersion}");
			about = new MenuItem("About");
			about.Name = "About";
			about.MenuItems.Add(swVersionMenuItem);
			about.MenuItems.Add(fwVersionMenuItem);
			about.MenuItems.Add(mcVersionMenuItem);
			swUpdatesMenuItem = new MenuItem("Check for updates...", ToggleUISoftwareUpdates);
			about.MenuItems.Add(swUpdatesMenuItem);
			swVersionMenuItem.Enabled = false;
			swUpdatesMenuItem.Checked = IsUpdateEnabled();
			fwVersionMenuItem.Name = "FWVersion";
			fwVersionMenuItem.Enabled = false;
			fwVersionMenuItem.Visible = false;
			mcVersionMenuItem.Name = "MCVersion";
			mcVersionMenuItem.Enabled = false;
			mcVersionMenuItem.Visible = false;
			swRememberCryoMenuItem = new MenuItem("Remember Cryo Mode", ToggleRememberCryoForSleep);
			about.MenuItems.Add(swRememberCryoMenuItem);
			RememberCryoSetting = IsRememberCryoEnabled();
			swRememberCryoMenuItem.Checked = RememberCryoSetting;
			exitMenuItem = new MenuItem("Exit", Exit);
			ni.ContextMenu = new ContextMenu(new MenuItem[8] { currentStatusMessage, statsMessage, statsMessage2, menuSeparator, selectMode, helpMenuItem, about, exitMenuItem });
			ni.Visible = true;
			ni.MouseUp -= IconMouseUp;
			ni.MouseUp += IconMouseUp;
			RefreshTrayTimer = new System.Threading.Timer(RunTimerTask, null, 0, -1);
			SoftwareUpdateTimer = new System.Threading.Timer(RunSoftwareUpdateTask, null, 0, -1);
		}
		catch (Exception ex)
		{
			log.Error("Display : {ex}", ex.ToString());
		}
	}

	private bool IsUpdateEnabled()
	{
		string param = "CheckForUpdates";
		return SystemInfoHelper.GetCurrentUserRegistrySetting("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\Updates", param).Equals("True", StringComparison.CurrentCultureIgnoreCase);
	}

	private bool IsRememberCryoEnabled()
	{
		string param = "RememberCryoMode";
		return SystemInfoHelper.GetCurrentUserRegistrySetting("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\CryoMode", param).Equals("True", StringComparison.CurrentCultureIgnoreCase);
	}

	private void RunSoftwareUpdateTask(object state)
	{
		try
		{
			log.Debug("BGN Software Update Task");
			if (!hasTimerDisabled && IsUpdateEnabled())
			{
				string text = SWUPDATE_MANIFEST_URL;
				string text2 = ConfigurationManager.AppSettings["SWUPDATE_MANIFEST_URL"];
				if (!string.IsNullOrEmpty(text2))
				{
					text = text2;
				}
				log.Debug("Checking software update with server {}.", text);
				string swUpdatePath = GetSwUpdatePath();
				string swVersion = Program.GetSwVersion();
				SoftwareUpdateInformation softwareUpdateInformation = new SoftwareUpdateInformation();
				softwareUpdateInformation.currentVersion = new Version(swVersion);
				softwareUpdateInformation.language = new CultureInfo("en");
				softwareUpdateInformation.tempFilePath = swUpdatePath;
				softwareUpdateInformation.platform = "x64";
				softwareUpdateInformation.manifestUrl = text;
				softwareUpdateInformation.productName = "Intel Cryo Cooling Technology";
				softwareUpdateInformation.registryPath = "Software\\Intel Corporation\\Intel Cryo Cooling Technology\\Updates";
				softwareUpdateInformation.errorMessage = "Intel(R) Cryo Cooling Technology Software update failed.";
				softwareUpdateInformation.callback = SWUpdateCallback;
				new SoftwareUpdate(softwareUpdateInformation).RunUpdateCheckWithUI();
			}
		}
		catch (Exception ex)
		{
			log.Error("An exception occured in fetching updates : {0}", ex.Message);
		}
		finally
		{
			int dueTime = 259200000;
			SoftwareUpdateTimer.Change(dueTime, -1);
			log.Debug("END Software Update Task");
		}
	}

	private string GetSwUpdatePath()
	{
		string text = Path.Combine(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)), "Intel");
		if (!Directory.Exists(text))
		{
			try
			{
				log.Debug("{UPDATE_DIR} not found. Creating DIR", text);
				Directory.CreateDirectory(text);
			}
			catch (Exception ex)
			{
				log.Warn("Failed to create {UPDATE_DIR}. Details {error}", text, ex.Message);
				text = Path.GetTempPath();
			}
		}
		log.Debug("Save software update to {UPDATE_DIR}", text);
		return text;
	}

	private static void SWUpdateCallback(SoftwareUpdate.UpdateProgressStatus status, string newVersion)
	{
		try
		{
			log.Info("SW Update Version - {0} : {1} ", newVersion, status);
		}
		catch (Exception ex)
		{
			log.Error("SWUpdateCallback : {0} ", ex.Message);
		}
	}

	private void RunTimerTask(object stateInfo)
	{
		if (hasTimerDisabled)
		{
			RefreshTrayTimer.Change(DefaultTimerIntervalInMS, -1);
			return;
		}
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		if (!IsCoolerReady || serviceHandle == null)
		{
			RecycleServiceHandle();
		}
		if (serviceHandle != null)
		{
			try
			{
				HwUpdateStatus success;
				string message;
				BoardRegisterMapping boardStatus = serviceHandle.GetBoardStatus(out success, out message);
				if (boardStatus != null)
				{
					IsCoolerReady = boardStatus.BoardInitCompleted.Value;
				}
				if (string.IsNullOrEmpty(fwVersion))
				{
					GetFWVersion();
				}
				if (string.IsNullOrEmpty(microcodeVersion) || microcodeVersion.Equals("NA"))
				{
					UpdateOcTvbMenuStatus();
				}
			}
			catch (Exception ex)
			{
				log.Warn(ex.Message);
			}
		}
		if (!IsCoolerReady || serviceHandle == null)
		{
			string message2 = ((serviceHandle == null) ? "Waiting for Cryo service to start" : "Waiting for Cryo cooler to start up");
			log.Info(message2);
			UpdateTrayNotificationItems(new Notification
			{
				Message = message2,
				TrayIconColor = TrayIconColor.YELLOW,
				ToolTipIcon = ToolTipIcon.Info,
				ShowBaloonTip = false
			});
		}
		else
		{
			CheckResumeCryoOperation();
			if (PollMessages())
			{
				GetCurrentOperationMode();
			}
			else
			{
				log.Warn("Failed to call PollMessages");
			}
		}
		RefreshTrayTimer.Change(Math.Max(0L, DefaultTimerIntervalInMS - stopwatch.ElapsedMilliseconds), -1L);
		log.Debug("Timertask executed in {0}ms", stopwatch.ElapsedMilliseconds);
		stopwatch.Stop();
	}

	private void CheckResumeCryoOperation()
	{
		if (OnStartupResumeCryoSuccess)
		{
			return;
		}
		if (RememberCryoSetting)
		{
			log.Debug("On Tray UI startup, Resume Cryo mode");
			ResumeCryoMode();
			if (currentOperationMode.Equals(OperationMode.Cryo))
			{
				OnStartupResumeCryoSuccess = true;
			}
		}
		else
		{
			OnStartupResumeCryoSuccess = true;
		}
	}

	private void GetCurrentOperationMode()
	{
		try
		{
			HwUpdateStatus success;
			string message;
			OperationMode operationMode = serviceHandle.GetOperationMode(out success, out message);
			if (success.Equals(HwUpdateStatus.success))
			{
				if (!operationMode.Equals(currentOperationMode))
				{
					log.Debug("Detected mode change from {0} to {1}.", currentOperationMode, operationMode);
					UpdateUIModes(operationMode);
				}
				else
				{
					log.Debug("Detected mode - {0}", operationMode);
				}
			}
			else
			{
				log.Debug("Detected mode - {0} : {1}. Details: {2}", operationMode, success, message);
			}
		}
		catch (Exception ex)
		{
			UpdateUIModes(OperationMode.Pending);
			log.Error("An exception occured in retreiving mode: {0}", ex.Message.ToString());
			RecycleServiceHandle();
		}
	}

	private void GetFWVersion()
	{
		try
		{
			fwVersion = serviceHandle.GetFWVersion(out var success, out var message);
			if (success.Equals(HwUpdateStatus.success))
			{
				log.Info("Detected firmware version : {0} ", fwVersion);
				ni.ContextMenu.MenuItems["About"].MenuItems["FWVersion"].Text = $"FW Version : {fwVersion}";
				fwVersionMenuItem.Visible = true;
			}
			else
			{
				log.Warn("Detected firmware version - {0} : {1}. Details: {2}", fwVersion, success, message);
			}
		}
		catch (Exception ex)
		{
			log.Error("Unable to detect firmware version: {0}", ex.Message.ToString());
		}
	}

	private void UpdateOcTvbMenuStatus()
	{
		try
		{
			HwUpdateStatus success;
			string message;
			string systemInfo = serviceHandle.GetSystemInfo(out success, out message);
			if (!success.Equals(HwUpdateStatus.success) || string.IsNullOrEmpty(systemInfo))
			{
				log.Error("Failed to get system info. status: " + message);
				return;
			}
			string format = (SystemInfoHelper.CheckOcTvbStatus(systemInfo, ref microcodeVersion) ? "OC TVB capable" : "OC TVB not available");
			ni.ContextMenu.MenuItems["About"].MenuItems["MCVersion"].Text = string.Format(format);
			mcVersionMenuItem.Visible = true;
		}
		catch (Exception ex)
		{
			log.Error("Failed to update OC TVB status", ex.Message);
		}
	}

	private void RecycleServiceHandle()
	{
		try
		{
			log.Debug("Begin recycling service handle.");
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			if ((CheckServiceRunning() && serviceHandle == null) || (serviceHandle != null && serviceHandle.State == CommunicationState.Faulted))
			{
				serviceHandle = new CryoCoolingServiceClient(binding, endpointAdress);
				OnStartupResumeCryoSuccess = false;
			}
			log.Debug("RecycleServiceHandle executed in {0}ms", stopwatch.ElapsedMilliseconds);
			stopwatch.Stop();
		}
		catch (Exception ex)
		{
			log.Error(GetEnumDescription(UIErrorCodes.ServiceConnectionFailed));
			log.Error("RecycleServiceHandle : {ex}", ex.ToString());
		}
	}

	private void ChangeOperationMode(object sender, EventArgs e)
	{
		hasTimerDisabled = true;
		MenuItem menuItem = (MenuItem)sender;
		try
		{
			log.Debug("User initiated mode change to {0}", menuItem.Text);
			if (serviceHandle == null)
			{
				RecycleServiceHandle();
			}
			HwUpdateStatus success = HwUpdateStatus.unknown;
			string text = string.Empty;
			if (menuItem == standByMode)
			{
				text = UIMode.Standby.ToString();
				success = serviceHandle.InitStandbyMode();
			}
			else if (menuItem == cryoMode)
			{
				text = UIMode.Cryo.ToString();
				success = serviceHandle.InitCryoMode();
			}
			else if (menuItem == unRegulatedMode)
			{
				if (!ShowPopupMessage(GetEnumDescription(UIErrorCodes.WarnUnregulated), MessageBoxIcon.Exclamation, MessageBoxButtons.OKCancel))
				{
					return;
				}
				text = UIMode.Unregulated.ToString();
				success = serviceHandle.InitUnregulatedMode();
			}
			Notification notification = new Notification();
			notification.ShowBaloonTip = true;
			if (success == HwUpdateStatus.success)
			{
				string message;
				OperationMode operationMode = serviceHandle.GetOperationMode(out success, out message);
				if (operationMode.Equals(OperationMode.Standby))
				{
					notification.TrayIconColor = TrayIconColor.BLUE;
				}
				else if (operationMode.Equals(OperationMode.Cryo))
				{
					notification.TrayIconColor = TrayIconColor.GREEN;
				}
				else if (operationMode.Equals(OperationMode.Unregulated))
				{
					notification.TrayIconColor = TrayIconColor.PURPLE;
				}
				string text2 = "Set mode to " + text;
				if (success.Equals(HwUpdateStatus.success))
				{
					log.Debug("Mode change from {0} to {1} is successful.", currentOperationMode, operationMode);
					UpdateUIModes(operationMode);
					notification.Message = text2 + " : Success";
					notification.ToolTipIcon = ToolTipIcon.Info;
				}
				else if (success.Equals(HwUpdateStatus.fail))
				{
					log.Warn("Mode change from {0} to {1} failed. Details : {2}", currentOperationMode, operationMode, message);
					notification.Message = text2 + " : Failed";
					notification.ToolTipIcon = ToolTipIcon.Error;
					notification.TrayIconColor = TrayIconColor.RED;
				}
				if (success.Equals(HwUpdateStatus.success))
				{
					currentOperationMode = operationMode;
				}
			}
			else
			{
				string message2;
				OperationMode operationMode2 = serviceHandle.GetOperationMode(out success, out message2);
				string text3 = "Set mode to " + text;
				if (success.Equals(HwUpdateStatus.success))
				{
					currentOperationMode = operationMode2;
				}
				log.Debug("Mode change failed. Details : {0}", message2);
				notification.Message = text3 + " : Failed";
				notification.ToolTipIcon = ToolTipIcon.Info;
				notification.TrayIconColor = previousIconColor;
			}
			UpdateTrayNotificationItems(notification);
		}
		catch (Exception ex)
		{
			log.Error("Mode change to {0} failed. Details: {1}", menuItem.Text, ex.Message);
		}
		finally
		{
			hasTimerDisabled = false;
		}
	}

	public bool PollMessages()
	{
		log.Debug("Begin polling messages.");
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		bool result = false;
		string text = string.Empty;
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			using NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", QueryCommunicationPipe, PipeDirection.In);
			namedPipeClientStream.Connect(TrayPipeWaitTimeInMS);
			using (StreamReader streamReader = new StreamReader(namedPipeClientStream))
			{
				string value;
				while ((value = streamReader.ReadLine()) != null)
				{
					stringBuilder.Append(value);
				}
			}
			log.Debug("sbGetCurrentStatus: {}", stringBuilder.ToString());
			StringBuilder stringBuilder2 = new StringBuilder();
			StringBuilder stringBuilder3 = new StringBuilder();
			string[] array = stringBuilder.ToString().Split(';');
			if (array.Length != 0)
			{
				text = array[0];
				for (int i = 1; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(':');
					if (array2.Length == 2)
					{
						if (array2[0].IndexOf("DewPoint") != -1)
						{
							stringBuilder2.Append($"Dew Point: {array2[1]}°C; ");
						}
						else if (array2[0].IndexOf("TecPower") != -1)
						{
							stringBuilder2.Append($"Power: {array2[1]}W; ");
						}
						else if (array2[0].IndexOf("TecTemp") != -1)
						{
							stringBuilder2.Append($"Cooler Temp: {array2[1]}°C; ");
						}
						else if (array2[0].IndexOf("Fan") != -1 || array2[0].IndexOf("Pump") != -1)
						{
							stringBuilder3.Append(array2[0] + ": " + array2[1] + "; ");
						}
					}
				}
			}
			result = true;
			string text2 = stringBuilder2.ToString();
			string text3 = stringBuilder3.ToString();
			log.Debug("Message details : {}, stats : {}, stats2: {}", text, text2, text3);
			if (!string.IsNullOrEmpty(text))
			{
				bool flag = previousMessage != text;
				ProcessTheReceivedMessageFromTheService(text, flag);
				previousMessage = (flag ? text : previousMessage);
			}
			previousPollErrorMessage = string.Empty;
			UpdateTrayStats(text2, text3, showStats: true);
		}
		catch (Exception ex)
		{
			bool flag2 = false;
			bool flag3 = CheckServiceRunning();
			string empty = string.Empty;
			string message = ex.Message;
			log.Error("Poll Messages: {0}", message);
			UpdateTrayStats("Stats unknown");
			UpdateUIModes(OperationMode.Pending);
			DisableUIModes(hasDisabled: true);
			if (!flag3)
			{
				log.Warn("Cryo Cooling Technology Service is not running.");
				empty = GetEnumDescription(UIErrorCodes.ServiceStopped);
				OnStartupResumeCryoSuccess = false;
			}
			else if (flag3 && message.ToLower().Contains("the operation has timed out"))
			{
				flag2 = true;
				empty = GetEnumDescription(UIErrorCodes.NoCooler);
			}
			else
			{
				empty = GetEnumDescription(UIErrorCodes.NoCooler);
			}
			UpdateTrayNotificationItems(new Notification
			{
				Message = empty,
				TrayIconColor = TrayIconColor.RED,
				ToolTipIcon = ToolTipIcon.Error,
				ShowBaloonTip = false
			});
			if (!flag2 && !previousMessage.Equals(empty) && !previousPollErrorMessage.Equals(message) && !hasTimerDisabled)
			{
				ShowPopupMessage2(empty, MessageBoxIcon.Hand);
				previousPollErrorMessage = message;
			}
			previousMessage = empty;
		}
		finally
		{
			log.Debug("Pollmessages executed in {0}ms", stopwatch.ElapsedMilliseconds);
			stopwatch.Stop();
		}
		return result;
	}

	private void ProcessTheReceivedMessageFromTheService(string message, bool notify)
	{
		string[] array = message.Split(':');
		string text = array[0].ToLower().Trim();
		string message2 = array[1].Trim();
		Notification notification = new Notification();
		notification.Message = message2;
		if (message.Contains(":") && text == "error")
		{
			notification.ShowBaloonTip = false;
			notification.ToolTipIcon = ToolTipIcon.Error;
			notification.TrayIconColor = TrayIconColor.RED;
			string text2 = message;
			string text3 = message.ToLower();
			if (text3.Contains("failed to get board status registers") || text3.Contains("failed to initialize controller"))
			{
				UpdateTrayStats("Stats unknown");
				UpdateUIModes(OperationMode.Pending);
				text2 = GetEnumDescription(UIErrorCodes.NoCooler);
			}
			else if (text3.Contains("invalidprocessor"))
			{
				UpdateTrayStats("Stats unknown");
				UpdateUIModes(OperationMode.Pending);
				text2 = GetEnumDescription(UIErrorCodes.InvalidCPU);
				hasTimerDisabled = true;
			}
			else if (text3.Contains("invalidfw"))
			{
				UpdateTrayStats("Stats unknown");
				UpdateUIModes(OperationMode.Pending);
				text2 = GetEnumDescription(UIErrorCodes.InvalidFW);
			}
			else
			{
				text2 = message.Substring(message.IndexOf(':') + 1);
			}
			DisableUIModes(hasDisabled: true);
			notification.Message = text2;
			log.Debug("Popup should show with : {0}", text2);
			if (!message.Equals(previousMessage))
			{
				ShowPopupMessage2(text2, MessageBoxIcon.Hand);
			}
			previousMessage = message;
		}
		else if (message.Contains(":") && text == "success")
		{
			notification.ShowBaloonTip = notify;
			notification.ToolTipIcon = ToolTipIcon.Info;
			notification.ShowBaloonTip = false;
			switch (currentOperationMode)
			{
			case OperationMode.Unregulated:
				notification.TrayIconColor = TrayIconColor.PURPLE;
				break;
			case OperationMode.Standby:
				notification.TrayIconColor = TrayIconColor.BLUE;
				break;
			default:
				notification.TrayIconColor = TrayIconColor.GREEN;
				break;
			}
			DisableUIModes(hasDisabled: false);
		}
		else if (message.Contains(":") && text == "warn")
		{
			notification.ShowBaloonTip = notify;
			notification.ToolTipIcon = ToolTipIcon.Warning;
			notification.TrayIconColor = TrayIconColor.BLUE;
			DisableUIModes(hasDisabled: false);
		}
		else
		{
			notification.Message = message;
		}
		UpdateTrayNotificationItems(notification);
	}

	private void DisableUIModes(bool hasDisabled)
	{
		if (diagnosticform != null && diagnosticform.istestInProgress)
		{
			selectMode.Enabled = false;
		}
		else
		{
			selectMode.Enabled = !hasDisabled;
		}
	}

	private void UpdateUIModes(OperationMode mode)
	{
		manualMode.Visible = false;
		standByMode.Checked = false;
		cryoMode.Checked = false;
		unRegulatedMode.Checked = false;
		manualMode.Checked = false;
		standByMode.Enabled = true;
		cryoMode.Enabled = true;
		unRegulatedMode.Enabled = true;
		manualMode.Enabled = true;
		if (mode.Equals(OperationMode.Standby))
		{
			standByMode.Checked = true;
			standByMode.Enabled = false;
			SaveUserCryoSelection(status: false);
		}
		else if (mode.Equals(OperationMode.Cryo))
		{
			cryoMode.Checked = true;
			cryoMode.Enabled = false;
			if (swRememberCryoMenuItem.Checked)
			{
				SaveUserCryoSelection(status: true);
			}
			else
			{
				SaveUserCryoSelection(status: false);
			}
		}
		else if (mode.Equals(OperationMode.Unregulated))
		{
			unRegulatedMode.Checked = true;
			unRegulatedMode.Enabled = false;
			SaveUserCryoSelection(status: false);
		}
		else if (mode.Equals(OperationMode.Manual))
		{
			manualMode.Checked = true;
			manualMode.Visible = true;
			manualMode.Enabled = false;
			SaveUserCryoSelection(status: false);
		}
		currentOperationMode = mode;
	}

	private void UpdateTrayNotificationItems(Notification notification)
	{
		UpdateTrayStatus(notification.Message);
		UpdateTrayIcon(notification.TrayIconColor);
		if (notification.ShowBaloonTip)
		{
			SendMessagetoNotificationCenter(notification.Message, notification.ToolTipIcon);
		}
	}

	private void UpdateTrayIcon(TrayIconColor color)
	{
		log.Debug("Icon color : {0}", color.ToString());
		if (!previousIconColor.Equals(color))
		{
			previousIconColor = color;
			switch (color)
			{
			case TrayIconColor.RED:
				ni.Icon = new Icon(ICON_RED, ICON_RED.Size);
				break;
			case TrayIconColor.BLUE:
				ni.Icon = new Icon(ICON_BLUE, ICON_BLUE.Size);
				break;
			case TrayIconColor.GREEN:
				ni.Icon = new Icon(ICON_GREEN, ICON_GREEN.Size);
				break;
			case TrayIconColor.PURPLE:
				ni.Icon = new Icon(ICON_PURPLE, ICON_PURPLE.Size);
				break;
			case TrayIconColor.YELLOW:
				ni.Icon = new Icon(ICON_YELLOW, ICON_YELLOW.Size);
				break;
			default:
				ni.Icon = new Icon(ICON_RED, ICON_RED.Size);
				break;
			}
		}
	}

	private void UpdateTrayStats(string stats, string stats2 = "", bool showStats = false)
	{
		if (showStats)
		{
			if (!string.IsNullOrEmpty(stats))
			{
				statsMessage.Visible = true;
				ni.ContextMenu.MenuItems["Stats"].Text = stats;
			}
			else
			{
				statsMessage.Visible = false;
				ni.ContextMenu.MenuItems["Stats"].Text = "";
			}
			if (!string.IsNullOrEmpty(stats2))
			{
				statsMessage2.Visible = true;
				ni.ContextMenu.MenuItems["Stats2"].Text = stats2;
			}
			else
			{
				statsMessage2.Visible = false;
				ni.ContextMenu.MenuItems["Stats2"].Text = "";
			}
		}
		else
		{
			statsMessage.Visible = false;
			statsMessage2.Visible = false;
		}
	}

	private void UpdateTrayStatus(string desiredText)
	{
		if (!string.IsNullOrEmpty(desiredText))
		{
			ni.ContextMenu.MenuItems["Status"].Text = desiredText;
			SetTrayMouseOverText(desiredText);
		}
	}

	private void SetTrayMouseOverText(string desiredText)
	{
		if (desiredText.Length > 63)
		{
			ni.Text = "Check the Notification Title for more details.";
			ni.ContextMenu.MenuItems["Status"].Text = desiredText;
		}
		else
		{
			ni.Text = desiredText;
		}
	}

	private void SendMessagetoNotificationCenter(string desiredText, ToolTipIcon icon)
	{
		log.Debug("Sending {0} notification to UI : {1}", icon.ToString(), desiredText);
		switch (icon)
		{
		case ToolTipIcon.Info:
			ni.BalloonTipIcon = ToolTipIcon.Info;
			break;
		case ToolTipIcon.Error:
			ni.BalloonTipIcon = ToolTipIcon.Error;
			break;
		case ToolTipIcon.Warning:
			ni.BalloonTipIcon = ToolTipIcon.Warning;
			break;
		default:
			ni.BalloonTipIcon = ToolTipIcon.Error;
			break;
		}
		ni.BalloonTipTitle = "Intel® Cryo Cooling Technology";
		ni.BalloonTipText = desiredText;
		ni.ShowBalloonTip(BaloonTipTimeOutInMS);
	}

	private bool ShowPopupMessage(string message, MessageBoxIcon icon, MessageBoxButtons buttons)
	{
		log.Debug("Sending {0} popup to UI : {1}", icon.ToString(), message);
		if (MessageBox.Show(message, "Intel® Cryo Cooling Technology", buttons, icon, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
		{
			log.Debug("User clicked OK to popup message : {0}", message);
			Close();
			return true;
		}
		log.Debug("User clicked cancel popup message : {0}", message);
		return false;
	}

	private bool ShowPopupMessage(string message, MessageBoxIcon icon)
	{
		log.Debug("Sending {0} popup to UI : {1}", icon.ToString(), message);
		MessageBoxButtons buttons = MessageBoxButtons.OK;
		if (MessageBox.Show(message, "Intel® Cryo Cooling Technology", buttons, icon, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
		{
			log.Debug("User clicked OK to popup message : {0}", message);
			Close();
			return true;
		}
		return false;
	}

	private bool ShowPopupMessage2(string message, MessageBoxIcon icon, MessageBoxButtons buttons)
	{
		log.Debug("Sending {0} popup to UI : {1}", icon.ToString(), message);
		ShowMyCustomMessageBoxAsync(message, "Intel® Cryo Cooling Technology", buttons, icon);
		return true;
	}

	private bool ShowPopupMessage2(string message, MessageBoxIcon icon)
	{
		log.Debug("Sending {0} popup to UI : {1}", icon.ToString(), message);
		ShowMyCustomMessageBoxAsync(message, "Intel® Cryo Cooling Technology", MessageBoxButtons.OK, icon);
		return true;
	}

	private void IconMouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button != MouseButtons.Left)
		{
			return;
		}
		log.Debug("IconMouseUp called");
		try
		{
			log.Debug("Look for method (ShowContextMenu)");
			MethodInfo method = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
			if (method != null)
			{
				log.Debug(method.DeclaringType.FullName);
				method.Invoke(ni, null);
			}
			else
			{
				log.Debug("Method not found!");
			}
		}
		catch (Exception value)
		{
			log.Error(value);
		}
	}

	private void OpenFAQ(object sender, EventArgs e)
	{
		string msg = "";
		if (!faq.Launch(fwVersion, ref msg))
		{
			ShowPopupMessage(msg, MessageBoxIcon.Exclamation, MessageBoxButtons.OKCancel);
		}
	}

	private void RunDiagnosticTest(object sender, EventArgs e)
	{
		if (diagnosticform != null)
		{
			diagnosticform.BringToFront();
			return;
		}
		diagnosticform = new DiagnosticTest(serviceHandle);
		diagnosticform.Show();
	}

	private void Exit(object sender, EventArgs e)
	{
		try
		{
			if (!ShowPopupMessage(GetEnumDescription(UIErrorCodes.WarnExit), MessageBoxIcon.Exclamation, MessageBoxButtons.OKCancel))
			{
				return;
			}
			if (serviceHandle != null && serviceHandle.State.Equals(CommunicationState.Opened))
			{
				HwUpdateStatus hwUpdateStatus = serviceHandle.InitStandbyMode();
				string text = UIMode.Standby.ToString();
				if (hwUpdateStatus.Equals(HwUpdateStatus.success))
				{
					log.Debug("Mode change from {0} to {1} is Successful.", currentOperationMode, text);
				}
				else if (hwUpdateStatus.Equals(HwUpdateStatus.fail))
				{
					log.Warn("Mode change to {0} is Failed.", text);
				}
				Thread.Sleep(100);
				serviceHandle.Close();
			}
			RefreshTrayTimer.Dispose();
			if (ni != null)
			{
				ni.Visible = false;
				if (ni.Icon != null)
				{
					ni.Icon = null;
				}
				ni.Dispose();
				ni = null;
			}
			log.Debug("Exiting the tray. Bye.");
			Application.ExitThread();
			Environment.Exit(0);
		}
		catch (Exception ex)
		{
			log.Error("Exception in EXIT : {0}", ex.Message);
		}
	}

	private bool CheckIfUpdatesEnabled()
	{
		using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\Updates", writable: true))
		{
			if (registryKey == null)
			{
				using RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\Updates");
				registryKey2.SetValue("CheckForUpdates", "True");
				swUpdatesMenuItem.Checked = true;
			}
			else if (registryKey.GetValue("CheckForUpdates") == null)
			{
				swUpdatesMenuItem.Checked = true;
			}
			else
			{
				swUpdatesMenuItem.Checked = Convert.ToBoolean(registryKey.GetValue("CheckForUpdates"));
			}
		}
		log.Debug("Software updates enabled : {0}", swUpdatesMenuItem.Checked);
		return swUpdatesMenuItem.Checked;
	}

	private void ToggleUISoftwareUpdates(object sender, EventArgs e)
	{
		MenuItem menuItem = (MenuItem)sender;
		menuItem.Checked = !menuItem.Checked;
		using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\Updates", writable: true))
		{
			if (registryKey == null)
			{
				using RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\Updates");
				registryKey2.SetValue("CheckForUpdates", menuItem.Checked.ToString());
			}
			else
			{
				registryKey.SetValue("CheckForUpdates", menuItem.Checked.ToString());
			}
		}
		if (menuItem.Checked)
		{
			log.Debug("Check for updates enabled");
			SendMessagetoNotificationCenter("Check for updates enabled", ToolTipIcon.Info);
			SoftwareUpdateTimer.Change(2000, -1);
		}
		else
		{
			log.Debug("Check for updates disabled");
			SendMessagetoNotificationCenter("Check for updates disabled", ToolTipIcon.Warning);
		}
	}

	public static string GetEnumDescription(Enum value)
	{
		if (value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit: false) is DescriptionAttribute[] source && source.Any())
		{
			return source.First().Description;
		}
		return value.ToString();
	}

	private void OnPowerChange(object s, PowerModeChangedEventArgs e)
	{
		log.Debug("Power event change detected : {0}", e.Mode.ToString());
		switch (e.Mode)
		{
		case PowerModes.Resume:
			Thread.Sleep(3000);
			log.Debug("Sleep for 3 sec to avoid resuming before service");
			hasTimerDisabled = false;
			OnStartupResumeCryoSuccess = false;
			RememberCryoSetting = IsRememberCryoEnabled();
			CheckResumeCryoOperation();
			break;
		case PowerModes.Suspend:
			if (swRememberCryoMenuItem.Checked)
			{
				if (cryoMode.Checked)
				{
					SaveUserCryoSelection(status: true);
				}
				else
				{
					SaveUserCryoSelection(status: false);
				}
			}
			else
			{
				SaveUserCryoSelection(status: false);
			}
			hasTimerDisabled = true;
			break;
		default:
			SaveUserCryoSelection(status: false);
			break;
		}
	}

	private void ToggleRememberCryoForSleep(object sender, EventArgs e)
	{
		MenuItem menuItem = (MenuItem)sender;
		menuItem.Checked = !menuItem.Checked;
		using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\CryoMode", writable: true))
		{
			if (registryKey == null)
			{
				using RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\CryoMode");
				registryKey2.SetValue("RememberCryoMode", menuItem.Checked.ToString());
			}
			else
			{
				registryKey.SetValue("RememberCryoMode", menuItem.Checked.ToString());
			}
		}
		if (menuItem.Checked)
		{
			swRememberCryoMenuItem.Checked = true;
			log.Debug("Remember Cryo Mode enabled");
			SendMessagetoNotificationCenter("Remember Cryo Mode saved", ToolTipIcon.Info);
		}
		else
		{
			swRememberCryoMenuItem.Checked = false;
			log.Debug("Remember Cryo Mode disabled");
			SendMessagetoNotificationCenter("Remember Cryo Mode removed", ToolTipIcon.Info);
		}
	}

	private void SaveUserCryoSelection(bool status)
	{
		try
		{
			using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\CryoMode", writable: true);
			if (registryKey == null)
			{
				using (RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\CryoMode"))
				{
					registryKey2.SetValue("CurrentlyInCryoMode", status);
					return;
				}
			}
			registryKey.SetValue("CurrentlyInCryoMode", status);
		}
		catch (Exception)
		{
			log.Debug("Exception saving cryo mode to registry failed.");
		}
	}

	private void ResumeCryoMode()
	{
		try
		{
			log.Debug("BGN ResumeCryoMode with RememberCryoSetting = {}", RememberCryoSetting);
			if (RememberCryoSetting)
			{
				cryoMode.Checked = true;
				log.Debug("Simulate a click");
				cryoMode.PerformClick();
			}
		}
		catch (Exception)
		{
			log.Debug("Exception trying to resume cryo mode.");
		}
	}

	public bool CheckServiceRunning()
	{
		try
		{
			ServiceController[] services = ServiceController.GetServices();
			foreach (ServiceController serviceController in services)
			{
				if (serviceController.ServiceName == "SacWindowsService")
				{
					return serviceController.Status == ServiceControllerStatus.Running;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			log.Error(ex.Message);
			return false;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(800, 450);
		this.Text = "Form1";
	}
}
