using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetOperationModeResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetOperationModeResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public OperationMode GetOperationModeResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetOperationModeResponse()
	{
	}

	public GetOperationModeResponse(OperationMode GetOperationModeResult, HwUpdateStatus success, string message)
	{
		this.GetOperationModeResult = GetOperationModeResult;
		this.success = success;
		this.message = message;
	}
}
