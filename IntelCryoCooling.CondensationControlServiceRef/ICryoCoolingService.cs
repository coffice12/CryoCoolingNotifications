using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace IntelCryoCooling.CondensationControlServiceRef;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(Namespace = "IntelCryoCooling", ConfigurationName = "CondensationControlServiceRef.ICryoCoolingService")]
public interface ICryoCoolingService
{
	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetOperationMode", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetOperationModeResponse")]
	GetOperationModeResponse GetOperationMode(GetOperationModeRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetOperationMode", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetOperationModeResponse")]
	Task<GetOperationModeResponse> GetOperationModeAsync(GetOperationModeRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetServiceProfile", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetServiceProfileResponse")]
	string GetServiceProfile();

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetServiceProfile", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetServiceProfileResponse")]
	Task<string> GetServiceProfileAsync();

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetBoardStatus", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetBoardStatusResponse")]
	GetBoardStatusResponse GetBoardStatus(GetBoardStatusRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetBoardStatus", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetBoardStatusResponse")]
	Task<GetBoardStatusResponse> GetBoardStatusAsync(GetBoardStatusRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTECTemperature", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTECTemperatureResponse")]
	GetTECTemperatureResponse GetTECTemperature(GetTECTemperatureRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTECTemperature", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTECTemperatureResponse")]
	Task<GetTECTemperatureResponse> GetTECTemperatureAsync(GetTECTemperatureRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetOutPutLevel", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetOutPutLevelResponse")]
	GetOutPutLevelResponse GetOutPutLevel(GetOutPutLevelRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetOutPutLevel", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetOutPutLevelResponse")]
	Task<GetOutPutLevelResponse> GetOutPutLevelAsync(GetOutPutLevelRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetHumidity", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetHumidityResponse")]
	GetHumidityResponse GetHumidity(GetHumidityRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetHumidity", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetHumidityResponse")]
	Task<GetHumidityResponse> GetHumidityAsync(GetHumidityRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetSetPointOffset", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetSetPointOffsetResponse")]
	GetSetPointOffsetResponse GetSetPointOffset(GetSetPointOffsetRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetSetPointOffset", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetSetPointOffsetResponse")]
	Task<GetSetPointOffsetResponse> GetSetPointOffsetAsync(GetSetPointOffsetRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetDewPoint", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetDewPointResponse")]
	GetDewPointResponse GetDewPoint(GetDewPointRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetDewPoint", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetDewPointResponse")]
	Task<GetDewPointResponse> GetDewPointAsync(GetDewPointRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetP", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetPResponse")]
	GetPResponse GetP(GetPRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetP", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetPResponse")]
	Task<GetPResponse> GetPAsync(GetPRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetI", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetIResponse")]
	GetIResponse GetI(GetIRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetI", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetIResponse")]
	Task<GetIResponse> GetIAsync(GetIRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetD", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetDResponse")]
	GetDResponse GetD(GetDRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetD", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetDResponse")]
	Task<GetDResponse> GetDAsync(GetDRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetCalculatedTecTemperature", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetCalculatedTecTemperatureResponse")]
	GetCalculatedTecTemperatureResponse GetCalculatedTecTemperature(GetCalculatedTecTemperatureRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetCalculatedTecTemperature", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetCalculatedTecTemperatureResponse")]
	Task<GetCalculatedTecTemperatureResponse> GetCalculatedTecTemperatureAsync(GetCalculatedTecTemperatureRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetSystemInfo", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetSystemInfoResponse")]
	GetSystemInfoResponse GetSystemInfo(GetSystemInfoRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetSystemInfo", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetSystemInfoResponse")]
	Task<GetSystemInfoResponse> GetSystemInfoAsync(GetSystemInfoRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetSystemStat", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetSystemStatResponse")]
	GetSystemStatResponse GetSystemStat(GetSystemStatRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetSystemStat", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetSystemStatResponse")]
	Task<GetSystemStatResponse> GetSystemStatAsync(GetSystemStatRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetHWVersion", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetHWVersionResponse")]
	GetHWVersionResponse GetHWVersion(GetHWVersionRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetHWVersion", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetHWVersionResponse")]
	Task<GetHWVersionResponse> GetHWVersionAsync(GetHWVersionRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetFWVersion", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetFWVersionResponse")]
	GetFWVersionResponse GetFWVersion(GetFWVersionRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetFWVersion", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetFWVersionResponse")]
	Task<GetFWVersionResponse> GetFWVersionAsync(GetFWVersionRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetNTC", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetNTCResponse")]
	GetNTCResponse GetNTC(GetNTCRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetNTC", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetNTCResponse")]
	Task<GetNTCResponse> GetNTCAsync(GetNTCRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/ResetBoard", ReplyAction = "IntelCryoCooling/ICryoCoolingService/ResetBoardResponse")]
	ResetBoardResponse ResetBoard(ResetBoardRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/ResetBoard", ReplyAction = "IntelCryoCooling/ICryoCoolingService/ResetBoardResponse")]
	Task<ResetBoardResponse> ResetBoardAsync(ResetBoardRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetBoardTemperature", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetBoardTemperatureResponse")]
	GetBoardTemperatureResponse GetBoardTemperature(GetBoardTemperatureRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetBoardTemperature", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetBoardTemperatureResponse")]
	Task<GetBoardTemperatureResponse> GetBoardTemperatureAsync(GetBoardTemperatureRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTecVoltage", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTecVoltageResponse")]
	GetTecVoltageResponse GetTecVoltage(GetTecVoltageRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTecVoltage", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTecVoltageResponse")]
	Task<GetTecVoltageResponse> GetTecVoltageAsync(GetTecVoltageRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTecCurrent", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTecCurrentResponse")]
	GetTecCurrentResponse GetTecCurrent(GetTecCurrentRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTecCurrent", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTecCurrentResponse")]
	Task<GetTecCurrentResponse> GetTecCurrentAsync(GetTecCurrentRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTECPower", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTECPowerResponse")]
	GetTECPowerResponse GetTECPower(GetTECPowerRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTECPower", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTECPowerResponse")]
	Task<GetTECPowerResponse> GetTECPowerAsync(GetTECPowerRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetSetPointOffset", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetSetPointOffsetResponse")]
	SetSetPointOffsetResponse SetSetPointOffset(SetSetPointOffsetRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetSetPointOffset", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetSetPointOffsetResponse")]
	Task<SetSetPointOffsetResponse> SetSetPointOffsetAsync(SetSetPointOffsetRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetP", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetPResponse")]
	SetPResponse SetP(SetPRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetP", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetPResponse")]
	Task<SetPResponse> SetPAsync(SetPRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetI", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetIResponse")]
	SetIResponse SetI(SetIRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetI", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetIResponse")]
	Task<SetIResponse> SetIAsync(SetIRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetD", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetDResponse")]
	SetDResponse SetD(SetDRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetD", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetDResponse")]
	Task<SetDResponse> SetDAsync(SetDRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetStandbyMode", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetStandbyModeResponse")]
	SetStandbyModeResponse SetStandbyMode(SetStandbyModeRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetStandbyMode", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetStandbyModeResponse")]
	Task<SetStandbyModeResponse> SetStandbyModeAsync(SetStandbyModeRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetTECPower", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetTECPowerResponse")]
	SetTECPowerResponse SetTECPower(SetTECPowerRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetTECPower", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetTECPowerResponse")]
	Task<SetTECPowerResponse> SetTECPowerAsync(SetTECPowerRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/InitCryoMode", ReplyAction = "IntelCryoCooling/ICryoCoolingService/InitCryoModeResponse")]
	HwUpdateStatus InitCryoMode();

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/InitCryoMode", ReplyAction = "IntelCryoCooling/ICryoCoolingService/InitCryoModeResponse")]
	Task<HwUpdateStatus> InitCryoModeAsync();

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/InitUnregulatedMode", ReplyAction = "IntelCryoCooling/ICryoCoolingService/InitUnregulatedModeResponse")]
	HwUpdateStatus InitUnregulatedMode();

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/InitUnregulatedMode", ReplyAction = "IntelCryoCooling/ICryoCoolingService/InitUnregulatedModeResponse")]
	Task<HwUpdateStatus> InitUnregulatedModeAsync();

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/InitStandbyMode", ReplyAction = "IntelCryoCooling/ICryoCoolingService/InitStandbyModeResponse")]
	HwUpdateStatus InitStandbyMode();

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/InitStandbyMode", ReplyAction = "IntelCryoCooling/ICryoCoolingService/InitStandbyModeResponse")]
	Task<HwUpdateStatus> InitStandbyModeAsync();

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetVoltageAndCurrent", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetVoltageAndCurrentResponse")]
	GetVoltageAndCurrentResponse GetVoltageAndCurrent(GetVoltageAndCurrentRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetVoltageAndCurrent", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetVoltageAndCurrentResponse")]
	Task<GetVoltageAndCurrentResponse> GetVoltageAndCurrentAsync(GetVoltageAndCurrentRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTmSensorTwo", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTmSensorTwoResponse")]
	GetTmSensorTwoResponse GetTmSensorTwo(GetTmSensorTwoRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTmSensorTwo", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTmSensorTwoResponse")]
	Task<GetTmSensorTwoResponse> GetTmSensorTwoAsync(GetTmSensorTwoRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTmSensorThree", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTmSensorThreeResponse")]
	GetTmSensorThreeResponse GetTmSensorThree(GetTmSensorThreeRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetTmSensorThree", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetTmSensorThreeResponse")]
	Task<GetTmSensorThreeResponse> GetTmSensorThreeAsync(GetTmSensorThreeRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetFanRpm", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetFanRpmResponse")]
	GetFanRpmResponse GetFanRpm(GetFanRpmRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetFanRpm", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetFanRpmResponse")]
	Task<GetFanRpmResponse> GetFanRpmAsync(GetFanRpmRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetFanPwm", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetFanPwmResponse")]
	SetFanPwmResponse SetFanPwm(SetFanPwmRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetFanPwm", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetFanPwmResponse")]
	Task<SetFanPwmResponse> SetFanPwmAsync(SetFanPwmRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetPumpRpm", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetPumpRpmResponse")]
	GetPumpRpmResponse GetPumpRpm(GetPumpRpmRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetPumpRpm", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetPumpRpmResponse")]
	Task<GetPumpRpmResponse> GetPumpRpmAsync(GetPumpRpmRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetPumpPwm", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetPumpPwmResponse")]
	SetPumpPwmResponse SetPumpPwm(SetPumpPwmRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetPumpPwm", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetPumpPwmResponse")]
	Task<SetPumpPwmResponse> SetPumpPwmAsync(SetPumpPwmRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/Bist2", ReplyAction = "IntelCryoCooling/ICryoCoolingService/Bist2Response")]
	Bist2Response Bist2(Bist2Request request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/Bist2", ReplyAction = "IntelCryoCooling/ICryoCoolingService/Bist2Response")]
	Task<Bist2Response> Bist2Async(Bist2Request request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetTECPowerCap", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetTECPowerCapResponse")]
	SetTECPowerCapResponse SetTECPowerCap(SetTECPowerCapRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetTECPowerCap", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetTECPowerCapResponse")]
	Task<SetTECPowerCapResponse> SetTECPowerCapAsync(SetTECPowerCapRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetOp", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetOpResponse")]
	[ServiceKnownType(typeof(OperationMode))]
	[ServiceKnownType(typeof(HwUpdateStatus))]
	[ServiceKnownType(typeof(BoardRegisterMapping))]
	[ServiceKnownType(typeof(BoardRegisterMapping.RegisterMap))]
	[ServiceKnownType(typeof(float[]))]
	[ServiceKnownType(typeof(uint[]))]
	SetOpResponse SetOp(SetOpRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/SetOp", ReplyAction = "IntelCryoCooling/ICryoCoolingService/SetOpResponse")]
	Task<SetOpResponse> SetOpAsync(SetOpRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetOp", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetOpResponse")]
	[ServiceKnownType(typeof(OperationMode))]
	[ServiceKnownType(typeof(HwUpdateStatus))]
	[ServiceKnownType(typeof(BoardRegisterMapping))]
	[ServiceKnownType(typeof(BoardRegisterMapping.RegisterMap))]
	[ServiceKnownType(typeof(float[]))]
	[ServiceKnownType(typeof(uint[]))]
	GetOpResponse GetOp(GetOpRequest request);

	[OperationContract(Action = "IntelCryoCooling/ICryoCoolingService/GetOp", ReplyAction = "IntelCryoCooling/ICryoCoolingService/GetOpResponse")]
	Task<GetOpResponse> GetOpAsync(GetOpRequest request);
}
