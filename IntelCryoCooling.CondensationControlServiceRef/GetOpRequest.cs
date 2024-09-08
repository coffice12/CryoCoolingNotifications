using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetOp", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetOpRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public int op;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string rtype;

	public GetOpRequest()
	{
	}

	public GetOpRequest(int op, string rtype)
	{
		this.op = op;
		this.rtype = rtype;
	}
}
