using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetP", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetPRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float p;

	public SetPRequest()
	{
	}

	public SetPRequest(float p)
	{
		this.p = p;
	}
}
