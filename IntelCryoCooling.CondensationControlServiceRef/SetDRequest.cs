using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetD", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetDRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float d;

	public SetDRequest()
	{
	}

	public SetDRequest(float d)
	{
		this.d = d;
	}
}
