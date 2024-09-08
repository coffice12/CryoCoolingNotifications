using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetFanPwm", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetFanPwmRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint val;

	public SetFanPwmRequest()
	{
	}

	public SetFanPwmRequest(uint val)
	{
		this.val = val;
	}
}
