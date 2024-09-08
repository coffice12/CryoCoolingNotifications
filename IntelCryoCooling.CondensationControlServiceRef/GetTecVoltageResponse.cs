using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetTecVoltageResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetTecVoltageResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetTecVoltageResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetTecVoltageResponse()
	{
	}

	public GetTecVoltageResponse(float GetTecVoltageResult, HwUpdateStatus success, string message)
	{
		this.GetTecVoltageResult = GetTecVoltageResult;
		this.success = success;
		this.message = message;
	}
}
