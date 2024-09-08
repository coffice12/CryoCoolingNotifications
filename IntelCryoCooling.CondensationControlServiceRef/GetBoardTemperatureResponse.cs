using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetBoardTemperatureResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetBoardTemperatureResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float GetBoardTemperatureResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetBoardTemperatureResponse()
	{
	}

	public GetBoardTemperatureResponse(float GetBoardTemperatureResult, HwUpdateStatus success, string message)
	{
		this.GetBoardTemperatureResult = GetBoardTemperatureResult;
		this.success = success;
		this.message = message;
	}
}
