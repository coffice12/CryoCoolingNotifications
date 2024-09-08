using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetPResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetPResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public HwUpdateStatus SetPResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public SetPResponse()
	{
	}

	public SetPResponse(HwUpdateStatus SetPResult, string message)
	{
		this.SetPResult = SetPResult;
		this.message = message;
	}
}
