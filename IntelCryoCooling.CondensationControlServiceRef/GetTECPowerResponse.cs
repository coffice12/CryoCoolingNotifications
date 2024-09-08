using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetTECPowerResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetTECPowerResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetTECPowerResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetTECPowerResponse()
	{
	}

	public GetTECPowerResponse(float GetTECPowerResult, HwUpdateStatus success, string message)
	{
		this.GetTECPowerResult = GetTECPowerResult;
		this.success = success;
		this.message = message;
	}
}
