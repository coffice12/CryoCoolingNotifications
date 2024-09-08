using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetOpResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetOpResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public object GetOpResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public GetOpResponse()
	{
	}

	public GetOpResponse(object GetOpResult, string message)
	{
		this.GetOpResult = GetOpResult;
		this.message = message;
	}
}
