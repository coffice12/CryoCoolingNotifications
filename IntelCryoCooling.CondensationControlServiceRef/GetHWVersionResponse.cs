using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetHWVersionResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetHWVersionResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public string GetHWVersionResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetHWVersionResponse()
	{
	}

	public GetHWVersionResponse(string GetHWVersionResult, HwUpdateStatus success, string message)
	{
		this.GetHWVersionResult = GetHWVersionResult;
		this.success = success;
		this.message = message;
	}
}
