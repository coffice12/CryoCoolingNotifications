using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetPumpPwmResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetPumpPwmResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public HwUpdateStatus SetPumpPwmResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public SetPumpPwmResponse()
	{
	}

	public SetPumpPwmResponse(HwUpdateStatus SetPumpPwmResult, string message)
	{
		this.SetPumpPwmResult = SetPumpPwmResult;
		this.message = message;
	}
}
