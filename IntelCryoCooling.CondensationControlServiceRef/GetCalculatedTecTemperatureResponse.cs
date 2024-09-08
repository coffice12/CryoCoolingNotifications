using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetCalculatedTecTemperatureResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetCalculatedTecTemperatureResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetCalculatedTecTemperatureResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetCalculatedTecTemperatureResponse()
	{
	}

	public GetCalculatedTecTemperatureResponse(float GetCalculatedTecTemperatureResult, HwUpdateStatus success, string message)
	{
		this.GetCalculatedTecTemperatureResult = GetCalculatedTecTemperatureResult;
		this.success = success;
		this.message = message;
	}
}
