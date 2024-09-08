using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetNTCResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetNTCResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint GetNTCResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetNTCResponse()
	{
	}

	public GetNTCResponse(uint GetNTCResult, HwUpdateStatus success, string message)
	{
		this.GetNTCResult = GetNTCResult;
		this.success = success;
		this.message = message;
	}
}
