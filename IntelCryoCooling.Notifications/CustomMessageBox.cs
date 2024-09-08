using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IntelCryoCooling.Notifications;

public class CustomMessageBox : Form
{
	private int _ButtonClickedValue;

	private IContainer components;

	private Button button1;

	private PictureBox pictureBox1;

	private RichTextBox textBox1;

	private Button button2;

	public int ButtonValue
	{
		get
		{
			return _ButtonClickedValue;
		}
		set
		{
			_ButtonClickedValue = value;
		}
	}

	public CustomMessageBox(string message, string application_name, string buttonText1, string buttonText2, MessageBoxIcon specifiedIcon)
	{
		InitializeComponent();
		Application.EnableVisualStyles();
		Image image = specifiedIcon switch
		{
			MessageBoxIcon.Hand => SystemIcons.Error.ToBitmap(), 
			MessageBoxIcon.Question => SystemIcons.Question.ToBitmap(), 
			MessageBoxIcon.Exclamation => SystemIcons.Warning.ToBitmap(), 
			MessageBoxIcon.Asterisk => SystemIcons.Information.ToBitmap(), 
			_ => SystemIcons.Information.ToBitmap(), 
		};
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = application_name;
		textBox1.Text = message;
		pictureBox1.Image = image;
		BringToFront();
		Focus();
		if (string.Compare(buttonText2, "") == 0)
		{
			button2.Visible = false;
		}
		else
		{
			button2.Visible = true;
			button2.Text = buttonText2;
		}
		button1.Text = buttonText1;
		base.ActiveControl = button1;
		BringToFront();
		Focus();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		ButtonValue = 1;
		Close();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		ButtonValue = 2;
		Close();
	}

	private void CustomMessageBox_FormClosed(object sender, FormClosedEventArgs e)
	{
		TrayIcon.messageboxform = null;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntelCryoCooling.Notifications.CustomMessageBox));
		this.button1 = new System.Windows.Forms.Button();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.textBox1 = new System.Windows.Forms.RichTextBox();
		this.button2 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.Location = new System.Drawing.Point(372, 118);
		this.button1.Margin = new System.Windows.Forms.Padding(4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(100, 28);
		this.button1.TabIndex = 0;
		this.button1.Text = "OK";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.pictureBox1.Location = new System.Drawing.Point(16, 15);
		this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(68, 62);
		this.pictureBox1.TabIndex = 2;
		this.pictureBox1.TabStop = false;
		this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
		this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.textBox1.DetectUrls = false;
		this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.textBox1.Location = new System.Drawing.Point(92, 15);
		this.textBox1.Margin = new System.Windows.Forms.Padding(4);
		this.textBox1.Name = "textBox1";
		this.textBox1.ReadOnly = true;
		this.textBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
		this.textBox1.Size = new System.Drawing.Size(380, 77);
		this.textBox1.TabIndex = 3;
		this.textBox1.Text = "";
		this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button2.Location = new System.Drawing.Point(264, 118);
		this.button2.Margin = new System.Windows.Forms.Padding(4);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(100, 28);
		this.button2.TabIndex = 2;
		this.button2.Text = "Cancel";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		base.AcceptButton = this.button1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		base.ClientSize = new System.Drawing.Size(479, 154);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.button1);
		this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "CustomMessageBox";
		this.Text = "Intel® Cryo Cooling";
		base.TopMost = true;
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
	}
}
