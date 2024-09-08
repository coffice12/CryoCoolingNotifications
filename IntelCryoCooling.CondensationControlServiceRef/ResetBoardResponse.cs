using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "ResetBoardResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class ResetBoardResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint ResetBoardResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public ResetBoardResponse()
	{
	}

	public ResetBoardResponse(uint ResetBoardResult, HwUpdateStatus success, string message)
	{
		this.ResetBoardResult = ResetBoardResult;
		this.success = success;
		this.message = message;
	}
}
