using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetTECTemperatureResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetTECTemperatureResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetTECTemperatureResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetTECTemperatureResponse()
	{
	}

	public GetTECTemperatureResponse(float GetTECTemperatureResult, HwUpdateStatus success, string message)
	{
		this.GetTECTemperatureResult = GetTECTemperatureResult;
		this.success = success;
		this.message = message;
	}
}
