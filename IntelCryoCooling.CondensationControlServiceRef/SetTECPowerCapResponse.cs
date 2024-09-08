using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetTECPowerCapResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetTECPowerCapResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public HwUpdateStatus SetTECPowerCapResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public SetTECPowerCapResponse()
	{
	}

	public SetTECPowerCapResponse(HwUpdateStatus SetTECPowerCapResult, string message)
	{
		this.SetTECPowerCapResult = SetTECPowerCapResult;
		this.message = message;
	}
}
