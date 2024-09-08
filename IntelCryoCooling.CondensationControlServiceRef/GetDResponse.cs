using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetDResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetDResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetDResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetDResponse()
	{
	}

	public GetDResponse(float GetDResult, HwUpdateStatus success, string message)
	{
		this.GetDResult = GetDResult;
		this.success = success;
		this.message = message;
	}
}
