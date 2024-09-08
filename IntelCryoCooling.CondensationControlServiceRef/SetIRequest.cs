using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetI", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetIRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float i;

	public SetIRequest()
	{
	}

	public SetIRequest(float i)
	{
		this.i = i;
	}
}
