using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetStandbyMode", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetStandbyModeRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint lp;

	public SetStandbyModeRequest()
	{
	}

	public SetStandbyModeRequest(uint lp)
	{
		this.lp = lp;
	}
}
