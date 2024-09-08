using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace IntelCryoCooling.CondensationControlServiceRef;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "BoardRegisterMapping", Namespace = "http://schemas.datacontract.org/2004/07/IntelCryoCooling")]
public class BoardRegisterMapping : IExtensibleDataObject, INotifyPropertyChanged
{
	[Serializable]
	[DebuggerStepThrough]
	[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
	[DataContract(Name = "BoardRegisterMapping.RegisterMap", Namespace = "http://schemas.datacontract.org/2004/07/IntelCryoCooling")]
	public class RegisterMap : IExtensibleDataObject, INotifyPropertyChanged
	{
		[NonSerialized]
		private ExtensionDataObject extensionDataField;

		[OptionalField]
		private int BitField;

		[OptionalField]
		private string DecriptionField;

		[OptionalField]
		private bool ValueField;

		public ExtensionDataObject ExtensionData
		{
			get
			{
				return extensionDataField;
			}
			set
			{
				extensionDataField = value;
			}
		}

		[DataMember]
		public int Bit
		{
			get
			{
				return BitField;
			}
			set
			{
				if (!BitField.Equals(value))
				{
					BitField = value;
					RaisePropertyChanged("Bit");
				}
			}
		}

		[DataMember]
		public string Decription
		{
			get
			{
				return DecriptionField;
			}
			set
			{
				if ((object)DecriptionField != value)
				{
					DecriptionField = value;
					RaisePropertyChanged("Decription");
				}
			}
		}

		[DataMember]
		public bool Value
		{
			get
			{
				return ValueField;
			}
			set
			{
				if (!ValueField.Equals(value))
				{
					ValueField = value;
					RaisePropertyChanged("Value");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	[NonSerialized]
	private ExtensionDataObject extensionDataField;

	[OptionalField]
	private RegisterMap BoardInitCompletedField;

	[OptionalField]
	private RegisterMap BoardTempInRangeField;

	[OptionalField]
	private RegisterMap FailSafeActiveField;

	[OptionalField]
	private RegisterMap FanBistField;

	[OptionalField]
	private RegisterMap HumiditySensorInRangeField;

	[OptionalField]
	private RegisterMap LastRxCmdBadCRCField;

	[OptionalField]
	private RegisterMap LastRxCmdInCompleteField;

	[OptionalField]
	private RegisterMap LastRxCmdOKField;

	[OptionalField]
	private RegisterMap LowPowerEnabledField;

	[OptionalField]
	private RegisterMap OvercurrentTriggeredField;

	[OptionalField]
	private RegisterMap PidRunningField;

	[OptionalField]
	private RegisterMap PowerSupplyDetectedField;

	[OptionalField]
	private RegisterMap PowerSupplySenseField;

	[OptionalField]
	private RegisterMap PumpBistField;

	[OptionalField]
	private RegisterMap SetPointDefaultLoadedField;

	[OptionalField]
	private RegisterMap SetPointOutOfRangeField;

	[OptionalField]
	private RegisterMap TecConnectionOkField;

	[OptionalField]
	private RegisterMap TempModeNTCEnabledField;

	[OptionalField]
	private RegisterMap ThermistorInRangeField;

	[Browsable(false)]
	public ExtensionDataObject ExtensionData
	{
		get
		{
			return extensionDataField;
		}
		set
		{
			extensionDataField = value;
		}
	}

	[DataMember]
	public RegisterMap BoardInitCompleted
	{
		get
		{
			return BoardInitCompletedField;
		}
		set
		{
			if (BoardInitCompletedField != value)
			{
				BoardInitCompletedField = value;
				RaisePropertyChanged("BoardInitCompleted");
			}
		}
	}

	[DataMember]
	public RegisterMap BoardTempInRange
	{
		get
		{
			return BoardTempInRangeField;
		}
		set
		{
			if (BoardTempInRangeField != value)
			{
				BoardTempInRangeField = value;
				RaisePropertyChanged("BoardTempInRange");
			}
		}
	}

	[DataMember]
	public RegisterMap FailSafeActive
	{
		get
		{
			return FailSafeActiveField;
		}
		set
		{
			if (FailSafeActiveField != value)
			{
				FailSafeActiveField = value;
				RaisePropertyChanged("FailSafeActive");
			}
		}
	}

	[DataMember]
	public RegisterMap FanBist
	{
		get
		{
			return FanBistField;
		}
		set
		{
			if (FanBistField != value)
			{
				FanBistField = value;
				RaisePropertyChanged("FanBist");
			}
		}
	}

	[DataMember]
	public RegisterMap HumiditySensorInRange
	{
		get
		{
			return HumiditySensorInRangeField;
		}
		set
		{
			if (HumiditySensorInRangeField != value)
			{
				HumiditySensorInRangeField = value;
				RaisePropertyChanged("HumiditySensorInRange");
			}
		}
	}

	[DataMember]
	public RegisterMap LastRxCmdBadCRC
	{
		get
		{
			return LastRxCmdBadCRCField;
		}
		set
		{
			if (LastRxCmdBadCRCField != value)
			{
				LastRxCmdBadCRCField = value;
				RaisePropertyChanged("LastRxCmdBadCRC");
			}
		}
	}

	[DataMember]
	public RegisterMap LastRxCmdInComplete
	{
		get
		{
			return LastRxCmdInCompleteField;
		}
		set
		{
			if (LastRxCmdInCompleteField != value)
			{
				LastRxCmdInCompleteField = value;
				RaisePropertyChanged("LastRxCmdInComplete");
			}
		}
	}

	[DataMember]
	public RegisterMap LastRxCmdOK
	{
		get
		{
			return LastRxCmdOKField;
		}
		set
		{
			if (LastRxCmdOKField != value)
			{
				LastRxCmdOKField = value;
				RaisePropertyChanged("LastRxCmdOK");
			}
		}
	}

	[DataMember]
	public RegisterMap LowPowerEnabled
	{
		get
		{
			return LowPowerEnabledField;
		}
		set
		{
			if (LowPowerEnabledField != value)
			{
				LowPowerEnabledField = value;
				RaisePropertyChanged("LowPowerEnabled");
			}
		}
	}

	[DataMember]
	public RegisterMap OvercurrentTriggered
	{
		get
		{
			return OvercurrentTriggeredField;
		}
		set
		{
			if (OvercurrentTriggeredField != value)
			{
				OvercurrentTriggeredField = value;
				RaisePropertyChanged("OvercurrentTriggered");
			}
		}
	}

	[DataMember]
	public RegisterMap PidRunning
	{
		get
		{
			return PidRunningField;
		}
		set
		{
			if (PidRunningField != value)
			{
				PidRunningField = value;
				RaisePropertyChanged("PidRunning");
			}
		}
	}

	[DataMember]
	public RegisterMap PowerSupplyDetected
	{
		get
		{
			return PowerSupplyDetectedField;
		}
		set
		{
			if (PowerSupplyDetectedField != value)
			{
				PowerSupplyDetectedField = value;
				RaisePropertyChanged("PowerSupplyDetected");
			}
		}
	}

	[DataMember]
	public RegisterMap PowerSupplySense
	{
		get
		{
			return PowerSupplySenseField;
		}
		set
		{
			if (PowerSupplySenseField != value)
			{
				PowerSupplySenseField = value;
				RaisePropertyChanged("PowerSupplySense");
			}
		}
	}

	[DataMember]
	public RegisterMap PumpBist
	{
		get
		{
			return PumpBistField;
		}
		set
		{
			if (PumpBistField != value)
			{
				PumpBistField = value;
				RaisePropertyChanged("PumpBist");
			}
		}
	}

	[DataMember]
	public RegisterMap SetPointDefaultLoaded
	{
		get
		{
			return SetPointDefaultLoadedField;
		}
		set
		{
			if (SetPointDefaultLoadedField != value)
			{
				SetPointDefaultLoadedField = value;
				RaisePropertyChanged("SetPointDefaultLoaded");
			}
		}
	}

	[DataMember]
	public RegisterMap SetPointOutOfRange
	{
		get
		{
			return SetPointOutOfRangeField;
		}
		set
		{
			if (SetPointOutOfRangeField != value)
			{
				SetPointOutOfRangeField = value;
				RaisePropertyChanged("SetPointOutOfRange");
			}
		}
	}

	[DataMember]
	public RegisterMap TecConnectionOk
	{
		get
		{
			return TecConnectionOkField;
		}
		set
		{
			if (TecConnectionOkField != value)
			{
				TecConnectionOkField = value;
				RaisePropertyChanged("TecConnectionOk");
			}
		}
	}

	[DataMember]
	public RegisterMap TempModeNTCEnabled
	{
		get
		{
			return TempModeNTCEnabledField;
		}
		set
		{
			if (TempModeNTCEnabledField != value)
			{
				TempModeNTCEnabledField = value;
				RaisePropertyChanged("TempModeNTCEnabled");
			}
		}
	}

	[DataMember]
	public RegisterMap ThermistorInRange
	{
		get
		{
			return ThermistorInRangeField;
		}
		set
		{
			if (ThermistorInRangeField != value)
			{
				ThermistorInRangeField = value;
				RaisePropertyChanged("ThermistorInRange");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
