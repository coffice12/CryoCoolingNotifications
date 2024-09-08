using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetBoardStatusResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetBoardStatusResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public BoardRegisterMapping GetBoardStatusResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetBoardStatusResponse()
	{
	}

	public GetBoardStatusResponse(BoardRegisterMapping GetBoardStatusResult, HwUpdateStatus success, string message)
	{
		this.GetBoardStatusResult = GetBoardStatusResult;
		this.success = success;
		this.message = message;
	}
}
