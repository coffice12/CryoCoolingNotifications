using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetSetPointOffsetResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetSetPointOffsetResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public HwUpdateStatus SetSetPointOffsetResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public SetSetPointOffsetResponse()
	{
	}

	public SetSetPointOffsetResponse(HwUpdateStatus SetSetPointOffsetResult, string message)
	{
		this.SetSetPointOffsetResult = SetSetPointOffsetResult;
		this.message = message;
	}
}
