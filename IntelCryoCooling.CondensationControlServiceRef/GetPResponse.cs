using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetPResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetPResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetPResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetPResponse()
	{
	}

	public GetPResponse(float GetPResult, HwUpdateStatus success, string message)
	{
		this.GetPResult = GetPResult;
		this.success = success;
		this.message = message;
	}
}
