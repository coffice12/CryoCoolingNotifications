using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetFWVersionResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetFWVersionResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public string GetFWVersionResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetFWVersionResponse()
	{
	}

	public GetFWVersionResponse(string GetFWVersionResult, HwUpdateStatus success, string message)
	{
		this.GetFWVersionResult = GetFWVersionResult;
		this.success = success;
		this.message = message;
	}
}
