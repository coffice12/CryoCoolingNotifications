using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetTmSensorThreeResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetTmSensorThreeResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetTmSensorThreeResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetTmSensorThreeResponse()
	{
	}

	public GetTmSensorThreeResponse(float GetTmSensorThreeResult, HwUpdateStatus success, string message)
	{
		this.GetTmSensorThreeResult = GetTmSensorThreeResult;
		this.success = success;
		this.message = message;
	}
}
