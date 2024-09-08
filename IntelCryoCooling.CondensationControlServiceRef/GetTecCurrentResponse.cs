using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetTecCurrentResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetTecCurrentResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetTecCurrentResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetTecCurrentResponse()
	{
	}

	public GetTecCurrentResponse(float GetTecCurrentResult, HwUpdateStatus success, string message)
	{
		this.GetTecCurrentResult = GetTecCurrentResult;
		this.success = success;
		this.message = message;
	}
}
