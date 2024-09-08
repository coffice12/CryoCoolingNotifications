using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetOp", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetOpRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public int op;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public object val;

	public SetOpRequest()
	{
	}

	public SetOpRequest(int op, object val)
	{
		this.op = op;
		this.val = val;
	}
}
