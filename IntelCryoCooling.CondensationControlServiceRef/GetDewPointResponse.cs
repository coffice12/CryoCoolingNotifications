using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetDewPointResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetDewPointResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetDewPointResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetDewPointResponse()
	{
	}

	public GetDewPointResponse(float GetDewPointResult, HwUpdateStatus success, string message)
	{
		this.GetDewPointResult = GetDewPointResult;
		this.success = success;
		this.message = message;
	}
}
