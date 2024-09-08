using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetTECPowerCap", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetTECPowerCapRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint tec;

	public SetTECPowerCapRequest()
	{
	}

	public SetTECPowerCapRequest(uint tec)
	{
		this.tec = tec;
	}
}
