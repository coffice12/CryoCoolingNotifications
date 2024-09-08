using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetSystemStatResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetSystemStatResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public string GetSystemStatResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetSystemStatResponse()
	{
	}

	public GetSystemStatResponse(string GetSystemStatResult, HwUpdateStatus success, string message)
	{
		this.GetSystemStatResult = GetSystemStatResult;
		this.success = success;
		this.message = message;
	}
}
