using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetHumidityResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetHumidityResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetHumidityResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetHumidityResponse()
	{
	}

	public GetHumidityResponse(float GetHumidityResult, HwUpdateStatus success, string message)
	{
		this.GetHumidityResult = GetHumidityResult;
		this.success = success;
		this.message = message;
	}
}
