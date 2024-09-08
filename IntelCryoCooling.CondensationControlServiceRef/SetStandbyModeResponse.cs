using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetStandbyModeResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetStandbyModeResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public HwUpdateStatus SetStandbyModeResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public SetStandbyModeResponse()
	{
	}

	public SetStandbyModeResponse(HwUpdateStatus SetStandbyModeResult, string message)
	{
		this.SetStandbyModeResult = SetStandbyModeResult;
		this.message = message;
	}
}
