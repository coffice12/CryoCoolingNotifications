using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using IntelCryoCooling.CondensationControlServiceRef;
using IntelCryoCooling.Properties;
using NLog;

namespace IntelCryoCooling.Notifications;

public class DiagnosticTest : Form
{
	private static Logger log = LogManager.GetLogger("diagnose-test");

	private static CryoCoolingServiceClient formServiceHandle;

	private static OperationMode currentOperationMode = OperationMode.Pending;

	private Icon APPLICATION_LOGO = Resources.logo;

	private static int DeltaTecTemperature = 10;

	private static int MinimumTecPower = 150;

	private IContainer components;

	private ProgressBar progressBar1;

	private BackgroundWorker backgroundWorker1;

	private Label lblStatusValue;

	private Label lblResult;

	private Label lblHeader;

	private Button button1;

	private Label label1;

	private bool hastestPassed { get; set; }

	internal bool istestInProgress { get; set; }

	public DiagnosticTest(CryoCoolingServiceClient serviceHandle)
	{
		InitializeComponent();
		base.Icon = new Icon(APPLICATION_LOGO, APPLICATION_LOGO.Size);
		Text = "Intel® Cryo Cooling Technology";
		formServiceHandle = serviceHandle;
		currentOperationMode = TrayIcon.currentOperationMode;
		lblStatusValue.Visible = false;
		progressBar1.Visible = false;
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		log.Info("BGN: Cryo Cooling Diagnostic Test.");
		BackgroundWorker backgroundWorker = sender as BackgroundWorker;
		backgroundWorker.WorkerReportsProgress = true;
		istestInProgress = true;
		bool flag = true;
		float num = -1f;
		float num2 = -1f;
		float num3 = -1f;
		try
		{
			backgroundWorker.ReportProgress(5, "Collect system info...");
			string oSInfo = SystemInfoHelper.GetOSInfo();
			log.Info("OS: {}", oSInfo);
			string processor = SystemInfoHelper.GetProcessor();
			log.Info("Processor: {}", processor);
			string uSBDevicesFromRegistry = SystemInfoHelper.GetUSBDevicesFromRegistry();
			log.Info("USB Devices: {}", uSBDevicesFromRegistry);
			string swVersion = Program.GetSwVersion();
			log.Info("Cryo Cooling SW: {}", swVersion);
			string currentUserRegistrySetting = SystemInfoHelper.GetCurrentUserRegistrySetting("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\CryoMode", "RememberCryoMode");
			log.Info("Remember Cryo mode is set to: {}", currentUserRegistrySetting);
			string currentUserRegistrySetting2 = SystemInfoHelper.GetCurrentUserRegistrySetting("Software\\Intel Corporation\\Intel Cryo Cooling Technology\\Updates", "CheckForUpdates");
			log.Info("Check for software updates is set to: {}", currentUserRegistrySetting2);
			backgroundWorker.ReportProgress(5, "Starting test...");
			HwUpdateStatus success = HwUpdateStatus.unknown;
			string message = "";
			log.Info("Get FW version");
			string fWVersion = formServiceHandle.GetFWVersion(out success, out message);
			log.Info("FW Version result: {}, {}, {}", fWVersion, success, message);
			log.Info("Put cooler to Standby mode");
			success = formServiceHandle.InitStandbyMode();
			log.Info("Mode switching status: {}", success);
			string text = UIMode.Standby.ToString();
			if (success.Equals(HwUpdateStatus.success))
			{
				log.Info("Mode change from {0} to {1} is Successful.", currentOperationMode, text);
				Thread.Sleep(5000);
				backgroundWorker.ReportProgress(10, "Waiting for temperature to stabilize.");
				Thread.Sleep(5000);
				backgroundWorker.ReportProgress(15, "Waiting for temperature to stabilize..");
				Thread.Sleep(5000);
				backgroundWorker.ReportProgress(20, "Waiting for temperature to stabilize...");
				Thread.Sleep(5000);
				log.Info("Get cooler starting thermistor reading");
				num2 = formServiceHandle.GetTECTemperature(out success, out message);
				log.Info("Thermistor reading result: {}, {}, {}", num2, success, message);
				if (success.Equals(HwUpdateStatus.success))
				{
					num2 = (float)Math.Round(num2);
					log.Info("Initial thermistor temperature: {0}", num2);
				}
				else
				{
					flag = false;
					log.Error("Initial thermistor temperature: {0}. Status: {1}, Details: {2}", num2, success, message);
				}
				backgroundWorker.ReportProgress(40, "Testing TEC cooling response...");
				if (swVersion.StartsWith("2."))
				{
					log.Info("Put cooler to Pseudo mode");
					success = InitPseudoUnregulated();
					text = "Pseudo";
					log.Info("Mode switching status: {}", success);
				}
				else
				{
					log.Info("Put cooler to Unregulated mode");
					success = formServiceHandle.InitUnregulatedMode();
					text = UIMode.Unregulated.ToString();
					log.Info("Mode switching status: {}", success);
				}
				if (success.Equals(HwUpdateStatus.success))
				{
					log.Info("Mode change from {0} to {1} is Successful.", currentOperationMode, text);
					backgroundWorker.ReportProgress(60, "Checking power response...");
					Thread.Sleep(3000);
					log.Info("Get cooler first power consumption reading");
					num = formServiceHandle.GetTECPower(out success, out message);
					log.Info("Power result: {}, {}, {}", num, success, message);
					if (success.Equals(HwUpdateStatus.success))
					{
						log.Info("Power: {0}", num);
					}
					else
					{
						flag = false;
						log.Error("Power: {0}. Status: {1}, Details: {2}", num, success, message);
					}
					backgroundWorker.ReportProgress(80, "Getting current temperature...");
					Thread.Sleep(5000);
					log.Info("Get cooler current power reading");
					float tECPower = formServiceHandle.GetTECPower(out success, out message);
					log.Info("Second power reading: {}, {}, {}", tECPower, success, message);
					num = ((num >= tECPower) ? num : tECPower);
					log.Info("Power value will be set to the max power value: {}", num);
					if (success.Equals(HwUpdateStatus.success))
					{
						log.Debug("Power: {0}", num);
					}
					else
					{
						flag = false;
						log.Error("Power: {0}. Status: {1}, Details: {2}", num, success, message);
					}
					log.Info("Get cooler current thermistor reading");
					num3 = formServiceHandle.GetTECTemperature(out success, out message);
					log.Info("Second thermistor result: {}, {}, {}", num3, success, message);
					if (success.Equals(HwUpdateStatus.success))
					{
						num3 = (float)Math.Round(num3);
						log.Debug("Secondary thermistor temperature: {0}", num3);
					}
					else
					{
						flag = false;
						log.Error("Secondary thermistor temperature: {0}. Status: {1}, Details: {2}", num3, success, message);
					}
					if (Math.Abs(num2 - num3) >= (float)DeltaTecTemperature && num > (float)MinimumTecPower)
					{
						hastestPassed = true;
					}
					log.Info("Abs(Delta Thermistor Temp) = {}", Math.Abs(num2 - num3));
					log.Info("tecPower {} > MinimumTecPower {} = {}", num, MinimumTecPower, num > (float)MinimumTecPower);
					if (flag && num2 != -1f && num3 != -1f && num != -1f)
					{
						e.Result = $"Initial Temperature: {num2}C\n\nFinal Temperature: {num3}C\n\nMax Power: {num}W.";
					}
				}
				else
				{
					log.Warn("Mode change to {0} is Failed.", text);
					flag = false;
				}
			}
			else if (success.Equals(HwUpdateStatus.fail))
			{
				log.Warn("Mode change to {0} is Failed.", text);
				flag = false;
			}
		}
		catch (Exception ex)
		{
			flag = false;
			log.Error("TEST: Exception in Diagnostic test : {0}", ex.Message);
			e.Result = TrayIcon.GetEnumDescription(UIErrorCodes.DiagnosticTestError);
		}
		finally
		{
			if (!flag)
			{
				e.Result = TrayIcon.GetEnumDescription(UIErrorCodes.DiagnosticTestError);
			}
			log.Info("Final Test result: {}", e.Result);
			InitiateStandBy();
			backgroundWorker.ReportProgress(100);
			log.Info("END: Cryo Cooling Diagnostic Test.");
		}
	}

	private HwUpdateStatus InitPseudoUnregulated()
	{
		string message = "";
		HwUpdateStatus hwUpdateStatus = HwUpdateStatus.unknown;
		HwUpdateStatus hwUpdateStatus2 = HwUpdateStatus.success;
		try
		{
			hwUpdateStatus = formServiceHandle.SetSetPointOffset(-20f, out message);
			hwUpdateStatus2 = ((hwUpdateStatus != 0) ? hwUpdateStatus : hwUpdateStatus2);
			hwUpdateStatus = formServiceHandle.SetP(100f, out message);
			hwUpdateStatus2 = ((hwUpdateStatus != 0) ? hwUpdateStatus : hwUpdateStatus2);
			hwUpdateStatus = formServiceHandle.SetI(1f, out message);
			hwUpdateStatus2 = ((hwUpdateStatus != 0) ? hwUpdateStatus : hwUpdateStatus2);
			hwUpdateStatus = formServiceHandle.SetD(0f, out message);
			hwUpdateStatus2 = ((hwUpdateStatus != 0) ? hwUpdateStatus : hwUpdateStatus2);
			hwUpdateStatus = formServiceHandle.SetOp(24, 0u, out message);
			return (hwUpdateStatus != 0) ? hwUpdateStatus : hwUpdateStatus2;
		}
		catch (Exception)
		{
			return HwUpdateStatus.fail;
		}
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		if (e.UserState != null)
		{
			lblStatusValue.Text = e.UserState.ToString();
		}
		progressBar1.Value = e.ProgressPercentage;
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		istestInProgress = false;
		lblStatusValue.Text = e.Result.ToString();
	}

	private void DiagnosticTest_FormClosed(object sender, FormClosedEventArgs e)
	{
		TrayIcon.diagnosticform = null;
		backgroundWorker1.Dispose();
		if (istestInProgress)
		{
			InitiateStandBy();
		}
	}

	private void InitiateStandBy()
	{
		string text = UIMode.Standby.ToString();
		try
		{
			HwUpdateStatus hwUpdateStatus = formServiceHandle.InitStandbyMode();
			if (hwUpdateStatus.Equals(HwUpdateStatus.success))
			{
				log.Debug("Mode change from {0} to {1} is Successful.", currentOperationMode, text);
			}
			else if (hwUpdateStatus.Equals(HwUpdateStatus.fail))
			{
				log.Warn("Mode change to {0} is Failed.", text);
			}
		}
		catch (Exception ex)
		{
			log.Error("Mode change to {0} is Failed. Details: {1}", text, ex.Message);
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		lblStatusValue.Visible = true;
		progressBar1.Step = 1;
		progressBar1.Value = 0;
		progressBar1.Maximum = 100;
		progressBar1.Visible = true;
		button1.Hide();
		backgroundWorker1.RunWorkerAsync();
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
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.lblStatusValue = new System.Windows.Forms.Label();
		this.lblResult = new System.Windows.Forms.Label();
		this.lblHeader = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.progressBar1.Location = new System.Drawing.Point(27, 188);
		this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(374, 28);
		this.progressBar1.TabIndex = 0;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.lblStatusValue.AutoSize = true;
		this.lblStatusValue.ForeColor = System.Drawing.Color.Blue;
		this.lblStatusValue.Location = new System.Drawing.Point(25, 65);
		this.lblStatusValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblStatusValue.Name = "lblStatusValue";
		this.lblStatusValue.Size = new System.Drawing.Size(158, 17);
		this.lblStatusValue.TabIndex = 2;
		this.lblStatusValue.Text = "Running Diagnostics.....";
		this.lblResult.AutoSize = true;
		this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblResult.ForeColor = System.Drawing.Color.Blue;
		this.lblResult.Location = new System.Drawing.Point(24, 188);
		this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblResult.Name = "lblResult";
		this.lblResult.Size = new System.Drawing.Size(0, 17);
		this.lblResult.TabIndex = 3;
		this.lblHeader.AutoSize = true;
		this.lblHeader.ForeColor = System.Drawing.Color.ForestGreen;
		this.lblHeader.Location = new System.Drawing.Point(24, 17);
		this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(297, 17);
		this.lblHeader.TabIndex = 4;
		this.lblHeader.Text = "Make sure your PC is idle for at least a minute";
		this.button1.Location = new System.Drawing.Point(328, 17);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 30);
		this.button1.TabIndex = 5;
		this.button1.Text = "Run Test";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label1.AutoSize = true;
		this.label1.ForeColor = System.Drawing.Color.ForestGreen;
		this.label1.Location = new System.Drawing.Point(25, 35);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(184, 17);
		this.label1.TabIndex = 6;
		this.label1.Text = "prior to running diagnostics.";
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(445, 229);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.lblHeader);
		base.Controls.Add(this.lblResult);
		base.Controls.Add(this.lblStatusValue);
		base.Controls.Add(this.progressBar1);
		this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "DiagnosticTest";
		this.Text = "Cryo Cooling Diagnostic Test";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(DiagnosticTest_FormClosed);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
