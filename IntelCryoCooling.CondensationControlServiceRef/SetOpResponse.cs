using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetOpResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetOpResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public HwUpdateStatus SetOpResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public SetOpResponse()
	{
	}

	public SetOpResponse(HwUpdateStatus SetOpResult, string message)
	{
		this.SetOpResult = SetOpResult;
		this.message = message;
	}
}
