using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetTmSensorTwoResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetTmSensorTwoResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetTmSensorTwoResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetTmSensorTwoResponse()
	{
	}

	public GetTmSensorTwoResponse(float GetTmSensorTwoResult, HwUpdateStatus success, string message)
	{
		this.GetTmSensorTwoResult = GetTmSensorTwoResult;
		this.success = success;
		this.message = message;
	}
}
