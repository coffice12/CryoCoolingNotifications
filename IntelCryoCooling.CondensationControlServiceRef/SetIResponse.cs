using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetIResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetIResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public HwUpdateStatus SetIResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public SetIResponse()
	{
	}

	public SetIResponse(HwUpdateStatus SetIResult, string message)
	{
		this.SetIResult = SetIResult;
		this.message = message;
	}
}
