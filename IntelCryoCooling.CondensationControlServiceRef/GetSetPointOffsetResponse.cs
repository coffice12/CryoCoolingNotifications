using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetSetPointOffsetResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetSetPointOffsetResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetSetPointOffsetResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetSetPointOffsetResponse()
	{
	}

	public GetSetPointOffsetResponse(float GetSetPointOffsetResult, HwUpdateStatus success, string message)
	{
		this.GetSetPointOffsetResult = GetSetPointOffsetResult;
		this.success = success;
		this.message = message;
	}
}
