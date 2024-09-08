using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetPumpPwm", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetPumpPwmRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint val;

	public SetPumpPwmRequest()
	{
	}

	public SetPumpPwmRequest(uint val)
	{
		this.val = val;
	}
}
