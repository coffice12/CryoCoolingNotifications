using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetDResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetDResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public HwUpdateStatus SetDResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public SetDResponse()
	{
	}

	public SetDResponse(HwUpdateStatus SetDResult, string message)
	{
		this.SetDResult = SetDResult;
		this.message = message;
	}
}
