using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetTECPower", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetTECPowerRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint tec;

	public SetTECPowerRequest()
	{
	}

	public SetTECPowerRequest(uint tec)
	{
		this.tec = tec;
	}
}
