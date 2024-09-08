using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetSystemInfoResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetSystemInfoResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public string GetSystemInfoResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetSystemInfoResponse()
	{
	}

	public GetSystemInfoResponse(string GetSystemInfoResult, HwUpdateStatus success, string message)
	{
		this.GetSystemInfoResult = GetSystemInfoResult;
		this.success = success;
		this.message = message;
	}
}
