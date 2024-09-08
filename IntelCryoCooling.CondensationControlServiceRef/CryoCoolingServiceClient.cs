using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class CryoCoolingServiceClient : ClientBase<ICryoCoolingService>, ICryoCoolingService
{
	public CryoCoolingServiceClient()
	{
	}

	public CryoCoolingServiceClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public CryoCoolingServiceClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public CryoCoolingServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public CryoCoolingServiceClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetOperationModeResponse ICryoCoolingService.GetOperationMode(GetOperationModeRequest request)
	{
		return base.Channel.GetOperationMode(request);
	}

	public OperationMode GetOperationMode(out HwUpdateStatus success, out string message)
	{
		GetOperationModeRequest request = new GetOperationModeRequest();
		GetOperationModeResponse operationMode = ((ICryoCoolingService)this).GetOperationMode(request);
		success = operationMode.success;
		message = operationMode.message;
		return operationMode.GetOperationModeResult;
	}

	public Task<GetOperationModeResponse> GetOperationModeAsync(GetOperationModeRequest request)
	{
		return base.Channel.GetOperationModeAsync(request);
	}

	public string GetServiceProfile()
	{
		return base.Channel.GetServiceProfile();
	}

	public Task<string> GetServiceProfileAsync()
	{
		return base.Channel.GetServiceProfileAsync();
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetBoardStatusResponse ICryoCoolingService.GetBoardStatus(GetBoardStatusRequest request)
	{
		return base.Channel.GetBoardStatus(request);
	}

	public BoardRegisterMapping GetBoardStatus(out HwUpdateStatus success, out string message)
	{
		GetBoardStatusRequest request = new GetBoardStatusRequest();
		GetBoardStatusResponse boardStatus = ((ICryoCoolingService)this).GetBoardStatus(request);
		success = boardStatus.success;
		message = boardStatus.message;
		return boardStatus.GetBoardStatusResult;
	}

	public Task<GetBoardStatusResponse> GetBoardStatusAsync(GetBoardStatusRequest request)
	{
		return base.Channel.GetBoardStatusAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTECTemperatureResponse ICryoCoolingService.GetTECTemperature(GetTECTemperatureRequest request)
	{
		return base.Channel.GetTECTemperature(request);
	}

	public float GetTECTemperature(out HwUpdateStatus success, out string message)
	{
		GetTECTemperatureRequest request = new GetTECTemperatureRequest();
		GetTECTemperatureResponse tECTemperature = ((ICryoCoolingService)this).GetTECTemperature(request);
		success = tECTemperature.success;
		message = tECTemperature.message;
		return tECTemperature.GetTECTemperatureResult;
	}

	public Task<GetTECTemperatureResponse> GetTECTemperatureAsync(GetTECTemperatureRequest request)
	{
		return base.Channel.GetTECTemperatureAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetOutPutLevelResponse ICryoCoolingService.GetOutPutLevel(GetOutPutLevelRequest request)
	{
		return base.Channel.GetOutPutLevel(request);
	}

	public uint GetOutPutLevel(out HwUpdateStatus success, out string message)
	{
		GetOutPutLevelRequest request = new GetOutPutLevelRequest();
		GetOutPutLevelResponse outPutLevel = ((ICryoCoolingService)this).GetOutPutLevel(request);
		success = outPutLevel.success;
		message = outPutLevel.message;
		return outPutLevel.GetOutPutLevelResult;
	}

	public Task<GetOutPutLevelResponse> GetOutPutLevelAsync(GetOutPutLevelRequest request)
	{
		return base.Channel.GetOutPutLevelAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetHumidityResponse ICryoCoolingService.GetHumidity(GetHumidityRequest request)
	{
		return base.Channel.GetHumidity(request);
	}

	public float GetHumidity(out HwUpdateStatus success, out string message)
	{
		GetHumidityRequest request = new GetHumidityRequest();
		GetHumidityResponse humidity = ((ICryoCoolingService)this).GetHumidity(request);
		success = humidity.success;
		message = humidity.message;
		return humidity.GetHumidityResult;
	}

	public Task<GetHumidityResponse> GetHumidityAsync(GetHumidityRequest request)
	{
		return base.Channel.GetHumidityAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetSetPointOffsetResponse ICryoCoolingService.GetSetPointOffset(GetSetPointOffsetRequest request)
	{
		return base.Channel.GetSetPointOffset(request);
	}

	public float GetSetPointOffset(out HwUpdateStatus success, out string message)
	{
		GetSetPointOffsetRequest request = new GetSetPointOffsetRequest();
		GetSetPointOffsetResponse setPointOffset = ((ICryoCoolingService)this).GetSetPointOffset(request);
		success = setPointOffset.success;
		message = setPointOffset.message;
		return setPointOffset.GetSetPointOffsetResult;
	}

	public Task<GetSetPointOffsetResponse> GetSetPointOffsetAsync(GetSetPointOffsetRequest request)
	{
		return base.Channel.GetSetPointOffsetAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetDewPointResponse ICryoCoolingService.GetDewPoint(GetDewPointRequest request)
	{
		return base.Channel.GetDewPoint(request);
	}

	public float GetDewPoint(out HwUpdateStatus success, out string message)
	{
		GetDewPointRequest request = new GetDewPointRequest();
		GetDewPointResponse dewPoint = ((ICryoCoolingService)this).GetDewPoint(request);
		success = dewPoint.success;
		message = dewPoint.message;
		return dewPoint.GetDewPointResult;
	}

	public Task<GetDewPointResponse> GetDewPointAsync(GetDewPointRequest request)
	{
		return base.Channel.GetDewPointAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetPResponse ICryoCoolingService.GetP(GetPRequest request)
	{
		return base.Channel.GetP(request);
	}

	public float GetP(out HwUpdateStatus success, out string message)
	{
		GetPRequest request = new GetPRequest();
		GetPResponse p = ((ICryoCoolingService)this).GetP(request);
		success = p.success;
		message = p.message;
		return p.GetPResult;
	}

	public Task<GetPResponse> GetPAsync(GetPRequest request)
	{
		return base.Channel.GetPAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetIResponse ICryoCoolingService.GetI(GetIRequest request)
	{
		return base.Channel.GetI(request);
	}

	public float GetI(out HwUpdateStatus success, out string message)
	{
		GetIRequest request = new GetIRequest();
		GetIResponse i = ((ICryoCoolingService)this).GetI(request);
		success = i.success;
		message = i.message;
		return i.GetIResult;
	}

	public Task<GetIResponse> GetIAsync(GetIRequest request)
	{
		return base.Channel.GetIAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetDResponse ICryoCoolingService.GetD(GetDRequest request)
	{
		return base.Channel.GetD(request);
	}

	public float GetD(out HwUpdateStatus success, out string message)
	{
		GetDRequest request = new GetDRequest();
		GetDResponse d = ((ICryoCoolingService)this).GetD(request);
		success = d.success;
		message = d.message;
		return d.GetDResult;
	}

	public Task<GetDResponse> GetDAsync(GetDRequest request)
	{
		return base.Channel.GetDAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCalculatedTecTemperatureResponse ICryoCoolingService.GetCalculatedTecTemperature(GetCalculatedTecTemperatureRequest request)
	{
		return base.Channel.GetCalculatedTecTemperature(request);
	}

	public float GetCalculatedTecTemperature(out HwUpdateStatus success, out string message)
	{
		GetCalculatedTecTemperatureRequest request = new GetCalculatedTecTemperatureRequest();
		GetCalculatedTecTemperatureResponse calculatedTecTemperature = ((ICryoCoolingService)this).GetCalculatedTecTemperature(request);
		success = calculatedTecTemperature.success;
		message = calculatedTecTemperature.message;
		return calculatedTecTemperature.GetCalculatedTecTemperatureResult;
	}

	public Task<GetCalculatedTecTemperatureResponse> GetCalculatedTecTemperatureAsync(GetCalculatedTecTemperatureRequest request)
	{
		return base.Channel.GetCalculatedTecTemperatureAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetSystemInfoResponse ICryoCoolingService.GetSystemInfo(GetSystemInfoRequest request)
	{
		return base.Channel.GetSystemInfo(request);
	}

	public string GetSystemInfo(out HwUpdateStatus success, out string message)
	{
		GetSystemInfoRequest request = new GetSystemInfoRequest();
		GetSystemInfoResponse systemInfo = ((ICryoCoolingService)this).GetSystemInfo(request);
		success = systemInfo.success;
		message = systemInfo.message;
		return systemInfo.GetSystemInfoResult;
	}

	public Task<GetSystemInfoResponse> GetSystemInfoAsync(GetSystemInfoRequest request)
	{
		return base.Channel.GetSystemInfoAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetSystemStatResponse ICryoCoolingService.GetSystemStat(GetSystemStatRequest request)
	{
		return base.Channel.GetSystemStat(request);
	}

	public string GetSystemStat(out HwUpdateStatus success, out string message)
	{
		GetSystemStatRequest request = new GetSystemStatRequest();
		GetSystemStatResponse systemStat = ((ICryoCoolingService)this).GetSystemStat(request);
		success = systemStat.success;
		message = systemStat.message;
		return systemStat.GetSystemStatResult;
	}

	public Task<GetSystemStatResponse> GetSystemStatAsync(GetSystemStatRequest request)
	{
		return base.Channel.GetSystemStatAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetHWVersionResponse ICryoCoolingService.GetHWVersion(GetHWVersionRequest request)
	{
		return base.Channel.GetHWVersion(request);
	}

	public string GetHWVersion(out HwUpdateStatus success, out string message)
	{
		GetHWVersionRequest request = new GetHWVersionRequest();
		GetHWVersionResponse hWVersion = ((ICryoCoolingService)this).GetHWVersion(request);
		success = hWVersion.success;
		message = hWVersion.message;
		return hWVersion.GetHWVersionResult;
	}

	public Task<GetHWVersionResponse> GetHWVersionAsync(GetHWVersionRequest request)
	{
		return base.Channel.GetHWVersionAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetFWVersionResponse ICryoCoolingService.GetFWVersion(GetFWVersionRequest request)
	{
		return base.Channel.GetFWVersion(request);
	}

	public string GetFWVersion(out HwUpdateStatus success, out string message)
	{
		GetFWVersionRequest request = new GetFWVersionRequest();
		GetFWVersionResponse fWVersion = ((ICryoCoolingService)this).GetFWVersion(request);
		success = fWVersion.success;
		message = fWVersion.message;
		return fWVersion.GetFWVersionResult;
	}

	public Task<GetFWVersionResponse> GetFWVersionAsync(GetFWVersionRequest request)
	{
		return base.Channel.GetFWVersionAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetNTCResponse ICryoCoolingService.GetNTC(GetNTCRequest request)
	{
		return base.Channel.GetNTC(request);
	}

	public uint GetNTC(out HwUpdateStatus success, out string message)
	{
		GetNTCRequest request = new GetNTCRequest();
		GetNTCResponse nTC = ((ICryoCoolingService)this).GetNTC(request);
		success = nTC.success;
		message = nTC.message;
		return nTC.GetNTCResult;
	}

	public Task<GetNTCResponse> GetNTCAsync(GetNTCRequest request)
	{
		return base.Channel.GetNTCAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ResetBoardResponse ICryoCoolingService.ResetBoard(ResetBoardRequest request)
	{
		return base.Channel.ResetBoard(request);
	}

	public uint ResetBoard(out HwUpdateStatus success, out string message)
	{
		ResetBoardRequest request = new ResetBoardRequest();
		ResetBoardResponse resetBoardResponse = ((ICryoCoolingService)this).ResetBoard(request);
		success = resetBoardResponse.success;
		message = resetBoardResponse.message;
		return resetBoardResponse.ResetBoardResult;
	}

	public Task<ResetBoardResponse> ResetBoardAsync(ResetBoardRequest request)
	{
		return base.Channel.ResetBoardAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetBoardTemperatureResponse ICryoCoolingService.GetBoardTemperature(GetBoardTemperatureRequest request)
	{
		return base.Channel.GetBoardTemperature(request);
	}

	public float GetBoardTemperature(out HwUpdateStatus success, out string message)
	{
		GetBoardTemperatureRequest request = new GetBoardTemperatureRequest();
		GetBoardTemperatureResponse boardTemperature = ((ICryoCoolingService)this).GetBoardTemperature(request);
		success = boardTemperature.success;
		message = boardTemperature.message;
		return boardTemperature.GetBoardTemperatureResult;
	}

	public Task<GetBoardTemperatureResponse> GetBoardTemperatureAsync(GetBoardTemperatureRequest request)
	{
		return base.Channel.GetBoardTemperatureAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTecVoltageResponse ICryoCoolingService.GetTecVoltage(GetTecVoltageRequest request)
	{
		return base.Channel.GetTecVoltage(request);
	}

	public float GetTecVoltage(out HwUpdateStatus success, out string message)
	{
		GetTecVoltageRequest request = new GetTecVoltageRequest();
		GetTecVoltageResponse tecVoltage = ((ICryoCoolingService)this).GetTecVoltage(request);
		success = tecVoltage.success;
		message = tecVoltage.message;
		return tecVoltage.GetTecVoltageResult;
	}

	public Task<GetTecVoltageResponse> GetTecVoltageAsync(GetTecVoltageRequest request)
	{
		return base.Channel.GetTecVoltageAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTecCurrentResponse ICryoCoolingService.GetTecCurrent(GetTecCurrentRequest request)
	{
		return base.Channel.GetTecCurrent(request);
	}

	public float GetTecCurrent(out HwUpdateStatus success, out string message)
	{
		GetTecCurrentRequest request = new GetTecCurrentRequest();
		GetTecCurrentResponse tecCurrent = ((ICryoCoolingService)this).GetTecCurrent(request);
		success = tecCurrent.success;
		message = tecCurrent.message;
		return tecCurrent.GetTecCurrentResult;
	}

	public Task<GetTecCurrentResponse> GetTecCurrentAsync(GetTecCurrentRequest request)
	{
		return base.Channel.GetTecCurrentAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTECPowerResponse ICryoCoolingService.GetTECPower(GetTECPowerRequest request)
	{
		return base.Channel.GetTECPower(request);
	}

	public float GetTECPower(out HwUpdateStatus success, out string message)
	{
		GetTECPowerRequest request = new GetTECPowerRequest();
		GetTECPowerResponse tECPower = ((ICryoCoolingService)this).GetTECPower(request);
		success = tECPower.success;
		message = tECPower.message;
		return tECPower.GetTECPowerResult;
	}

	public Task<GetTECPowerResponse> GetTECPowerAsync(GetTECPowerRequest request)
	{
		return base.Channel.GetTECPowerAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SetSetPointOffsetResponse ICryoCoolingService.SetSetPointOffset(SetSetPointOffsetRequest request)
	{
		return base.Channel.SetSetPointOffset(request);
	}

	public HwUpdateStatus SetSetPointOffset(float setpoint, out string message)
	{
		SetSetPointOffsetRequest setSetPointOffsetRequest = new SetSetPointOffsetRequest();
		setSetPointOffsetRequest.setpoint = setpoint;
		SetSetPointOffsetResponse setSetPointOffsetResponse = ((ICryoCoolingService)this).SetSetPointOffset(setSetPointOffsetRequest);
		message = setSetPointOffsetResponse.message;
		return setSetPointOffsetResponse.SetSetPointOffsetResult;
	}

	public Task<SetSetPointOffsetResponse> SetSetPointOffsetAsync(SetSetPointOffsetRequest request)
	{
		return base.Channel.SetSetPointOffsetAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SetPResponse ICryoCoolingService.SetP(SetPRequest request)
	{
		return base.Channel.SetP(request);
	}

	public HwUpdateStatus SetP(float p, out string message)
	{
		SetPRequest setPRequest = new SetPRequest();
		setPRequest.p = p;
		SetPResponse setPResponse = ((ICryoCoolingService)this).SetP(setPRequest);
		message = setPResponse.message;
		return setPResponse.SetPResult;
	}

	public Task<SetPResponse> SetPAsync(SetPRequest request)
	{
		return base.Channel.SetPAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SetIResponse ICryoCoolingService.SetI(SetIRequest request)
	{
		return base.Channel.SetI(request);
	}

	public HwUpdateStatus SetI(float i, out string message)
	{
		SetIRequest setIRequest = new SetIRequest();
		setIRequest.i = i;
		SetIResponse setIResponse = ((ICryoCoolingService)this).SetI(setIRequest);
		message = setIResponse.message;
		return setIResponse.SetIResult;
	}

	public Task<SetIResponse> SetIAsync(SetIRequest request)
	{
		return base.Channel.SetIAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SetDResponse ICryoCoolingService.SetD(SetDRequest request)
	{
		return base.Channel.SetD(request);
	}

	public HwUpdateStatus SetD(float d, out string message)
	{
		SetDRequest setDRequest = new SetDRequest();
		setDRequest.d = d;
		SetDResponse setDResponse = ((ICryoCoolingService)this).SetD(setDRequest);
		message = setDResponse.message;
		return setDResponse.SetDResult;
	}

	public Task<SetDResponse> SetDAsync(SetDRequest request)
	{
		return base.Channel.SetDAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SetStandbyModeResponse ICryoCoolingService.SetStandbyMode(SetStandbyModeRequest request)
	{
		return base.Channel.SetStandbyMode(request);
	}

	public HwUpdateStatus SetStandbyMode(uint lp, out string message)
	{
		SetStandbyModeRequest setStandbyModeRequest = new SetStandbyModeRequest();
		setStandbyModeRequest.lp = lp;
		SetStandbyModeResponse setStandbyModeResponse = ((ICryoCoolingService)this).SetStandbyMode(setStandbyModeRequest);
		message = setStandbyModeResponse.message;
		return setStandbyModeResponse.SetStandbyModeResult;
	}

	public Task<SetStandbyModeResponse> SetStandbyModeAsync(SetStandbyModeRequest request)
	{
		return base.Channel.SetStandbyModeAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SetTECPowerResponse ICryoCoolingService.SetTECPower(SetTECPowerRequest request)
	{
		return base.Channel.SetTECPower(request);
	}

	public HwUpdateStatus SetTECPower(uint tec, out string message)
	{
		SetTECPowerRequest setTECPowerRequest = new SetTECPowerRequest();
		setTECPowerRequest.tec = tec;
		SetTECPowerResponse setTECPowerResponse = ((ICryoCoolingService)this).SetTECPower(setTECPowerRequest);
		message = setTECPowerResponse.message;
		return setTECPowerResponse.SetTECPowerResult;
	}

	public Task<SetTECPowerResponse> SetTECPowerAsync(SetTECPowerRequest request)
	{
		return base.Channel.SetTECPowerAsync(request);
	}

	public HwUpdateStatus InitCryoMode()
	{
		return base.Channel.InitCryoMode();
	}

	public Task<HwUpdateStatus> InitCryoModeAsync()
	{
		return base.Channel.InitCryoModeAsync();
	}

	public HwUpdateStatus InitUnregulatedMode()
	{
		return base.Channel.InitUnregulatedMode();
	}

	public Task<HwUpdateStatus> InitUnregulatedModeAsync()
	{
		return base.Channel.InitUnregulatedModeAsync();
	}

	public HwUpdateStatus InitStandbyMode()
	{
		return base.Channel.InitStandbyMode();
	}

	public Task<HwUpdateStatus> InitStandbyModeAsync()
	{
		return base.Channel.InitStandbyModeAsync();
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetVoltageAndCurrentResponse ICryoCoolingService.GetVoltageAndCurrent(GetVoltageAndCurrentRequest request)
	{
		return base.Channel.GetVoltageAndCurrent(request);
	}

	public float[] GetVoltageAndCurrent(out HwUpdateStatus status, out string message)
	{
		GetVoltageAndCurrentRequest request = new GetVoltageAndCurrentRequest();
		GetVoltageAndCurrentResponse voltageAndCurrent = ((ICryoCoolingService)this).GetVoltageAndCurrent(request);
		status = voltageAndCurrent.status;
		message = voltageAndCurrent.message;
		return voltageAndCurrent.GetVoltageAndCurrentResult;
	}

	public Task<GetVoltageAndCurrentResponse> GetVoltageAndCurrentAsync(GetVoltageAndCurrentRequest request)
	{
		return base.Channel.GetVoltageAndCurrentAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTmSensorTwoResponse ICryoCoolingService.GetTmSensorTwo(GetTmSensorTwoRequest request)
	{
		return base.Channel.GetTmSensorTwo(request);
	}

	public float GetTmSensorTwo(out HwUpdateStatus success, out string message)
	{
		GetTmSensorTwoRequest request = new GetTmSensorTwoRequest();
		GetTmSensorTwoResponse tmSensorTwo = ((ICryoCoolingService)this).GetTmSensorTwo(request);
		success = tmSensorTwo.success;
		message = tmSensorTwo.message;
		return tmSensorTwo.GetTmSensorTwoResult;
	}

	public Task<GetTmSensorTwoResponse> GetTmSensorTwoAsync(GetTmSensorTwoRequest request)
	{
		return base.Channel.GetTmSensorTwoAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTmSensorThreeResponse ICryoCoolingService.GetTmSensorThree(GetTmSensorThreeRequest request)
	{
		return base.Channel.GetTmSensorThree(request);
	}

	public float GetTmSensorThree(out HwUpdateStatus success, out string message)
	{
		GetTmSensorThreeRequest request = new GetTmSensorThreeRequest();
		GetTmSensorThreeResponse tmSensorThree = ((ICryoCoolingService)this).GetTmSensorThree(request);
		success = tmSensorThree.success;
		message = tmSensorThree.message;
		return tmSensorThree.GetTmSensorThreeResult;
	}

	public Task<GetTmSensorThreeResponse> GetTmSensorThreeAsync(GetTmSensorThreeRequest request)
	{
		return base.Channel.GetTmSensorThreeAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetFanRpmResponse ICryoCoolingService.GetFanRpm(GetFanRpmRequest request)
	{
		return base.Channel.GetFanRpm(request);
	}

	public uint GetFanRpm(out HwUpdateStatus success, out string message)
	{
		GetFanRpmRequest request = new GetFanRpmRequest();
		GetFanRpmResponse fanRpm = ((ICryoCoolingService)this).GetFanRpm(request);
		success = fanRpm.success;
		message = fanRpm.message;
		return fanRpm.GetFanRpmResult;
	}

	public Task<GetFanRpmResponse> GetFanRpmAsync(GetFanRpmRequest request)
	{
		return base.Channel.GetFanRpmAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SetFanPwmResponse ICryoCoolingService.SetFanPwm(SetFanPwmRequest request)
	{
		return base.Channel.SetFanPwm(request);
	}

	public HwUpdateStatus SetFanPwm(uint val, out string message)
	{
		SetFanPwmRequest setFanPwmRequest = new SetFanPwmRequest();
		setFanPwmRequest.val = val;
		SetFanPwmResponse setFanPwmResponse = ((ICryoCoolingService)this).SetFanPwm(setFanPwmRequest);
		message = setFanPwmResponse.message;
		return setFanPwmResponse.SetFanPwmResult;
	}

	public Task<SetFanPwmResponse> SetFanPwmAsync(SetFanPwmRequest request)
	{
		return base.Channel.SetFanPwmAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetPumpRpmResponse ICryoCoolingService.GetPumpRpm(GetPumpRpmRequest request)
	{
		return base.Channel.GetPumpRpm(request);
	}

	public uint GetPumpRpm(out HwUpdateStatus success, out string message)
	{
		GetPumpRpmRequest request = new GetPumpRpmRequest();
		GetPumpRpmResponse pumpRpm = ((ICryoCoolingService)this).GetPumpRpm(request);
		success = pumpRpm.success;
		message = pumpRpm.message;
		return pumpRpm.GetPumpRpmResult;
	}

	public Task<GetPumpRpmResponse> GetPumpRpmAsync(GetPumpRpmRequest request)
	{
		return base.Channel.GetPumpRpmAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SetPumpPwmResponse ICryoCoolingService.SetPumpPwm(SetPumpPwmRequest request)
	{
		return base.Channel.SetPumpPwm(request);
	}

	public HwUpdateStatus SetPumpPwm(uint val, out string message)
	{
		SetPumpPwmRequest setPumpPwmRequest = new SetPumpPwmRequest();
		setPumpPwmRequest.val = val;
		SetPumpPwmResponse setPumpPwmResponse = ((ICryoCoolingService)this).SetPumpPwm(setPumpPwmRequest);
		message = setPumpPwmResponse.message;
		return setPumpPwmResponse.SetPumpPwmResult;
	}

	public Task<SetPumpPwmResponse> SetPumpPwmAsync(SetPumpPwmRequest request)
	{
		return base.Channel.SetPumpPwmAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Bist2Response ICryoCoolingService.Bist2(Bist2Request request)
	{
		return base.Channel.Bist2(request);
	}

	public uint Bist2(out HwUpdateStatus success, out string message)
	{
		Bist2Request request = new Bist2Request();
		Bist2Response bist2Response = ((ICryoCoolingService)this).Bist2(request);
		success = bist2Response.success;
		message = bist2Response.message;
		return bist2Response.Bist2Result;
	}

	public Task<Bist2Response> Bist2Async(Bist2Request request)
	{
		return base.Channel.Bist2Async(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SetTECPowerCapResponse ICryoCoolingService.SetTECPowerCap(SetTECPowerCapRequest request)
	{
		return base.Channel.SetTECPowerCap(request);
	}

	public HwUpdateStatus SetTECPowerCap(uint tec, out string message)
	{
		SetTECPowerCapRequest setTECPowerCapRequest = new SetTECPowerCapRequest();
		setTECPowerCapRequest.tec = tec;
		SetTECPowerCapResponse setTECPowerCapResponse = ((ICryoCoolingService)this).SetTECPowerCap(setTECPowerCapRequest);
		message = setTECPowerCapResponse.message;
		return setTECPowerCapResponse.SetTECPowerCapResult;
	}

	public Task<SetTECPowerCapResponse> SetTECPowerCapAsync(SetTECPowerCapRequest request)
	{
		return base.Channel.SetTECPowerCapAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SetOpResponse ICryoCoolingService.SetOp(SetOpRequest request)
	{
		return base.Channel.SetOp(request);
	}

	public HwUpdateStatus SetOp(int op, object val, out string message)
	{
		SetOpRequest setOpRequest = new SetOpRequest();
		setOpRequest.op = op;
		setOpRequest.val = val;
		SetOpResponse setOpResponse = ((ICryoCoolingService)this).SetOp(setOpRequest);
		message = setOpResponse.message;
		return setOpResponse.SetOpResult;
	}

	public Task<SetOpResponse> SetOpAsync(SetOpRequest request)
	{
		return base.Channel.SetOpAsync(request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetOpResponse ICryoCoolingService.GetOp(GetOpRequest request)
	{
		return base.Channel.GetOp(request);
	}

	public object GetOp(int op, string rtype, out string message)
	{
		GetOpRequest getOpRequest = new GetOpRequest();
		getOpRequest.op = op;
		getOpRequest.rtype = rtype;
		GetOpResponse op2 = ((ICryoCoolingService)this).GetOp(getOpRequest);
		message = op2.message;
		return op2.GetOpResult;
	}

	public Task<GetOpResponse> GetOpAsync(GetOpRequest request)
	{
		return base.Channel.GetOpAsync(request);
	}
}
