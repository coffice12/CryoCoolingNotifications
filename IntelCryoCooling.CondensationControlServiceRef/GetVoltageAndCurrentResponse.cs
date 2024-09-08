using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetVoltageAndCurrentResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetVoltageAndCurrentResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float[] GetVoltageAndCurrentResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus status;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetVoltageAndCurrentResponse()
	{
	}

	public GetVoltageAndCurrentResponse(float[] GetVoltageAndCurrentResult, HwUpdateStatus status, string message)
	{
		this.GetVoltageAndCurrentResult = GetVoltageAndCurrentResult;
		this.status = status;
		this.message = message;
	}
}
