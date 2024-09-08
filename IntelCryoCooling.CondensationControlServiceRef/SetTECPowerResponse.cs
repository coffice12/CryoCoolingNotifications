using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetTECPowerResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetTECPowerResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public HwUpdateStatus SetTECPowerResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public SetTECPowerResponse()
	{
	}

	public SetTECPowerResponse(HwUpdateStatus SetTECPowerResult, string message)
	{
		this.SetTECPowerResult = SetTECPowerResult;
		this.message = message;
	}
}
