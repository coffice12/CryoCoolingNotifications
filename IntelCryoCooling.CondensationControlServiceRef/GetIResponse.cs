using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetIResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetIResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetIResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetIResponse()
	{
	}

	public GetIResponse(float GetIResult, HwUpdateStatus success, string message)
	{
		this.GetIResult = GetIResult;
		this.success = success;
		this.message = message;
	}
}
