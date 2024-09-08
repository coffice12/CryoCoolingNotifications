using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetFanPwmResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetFanPwmResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public HwUpdateStatus SetFanPwmResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public string message;

	public SetFanPwmResponse()
	{
	}

	public SetFanPwmResponse(HwUpdateStatus SetFanPwmResult, string message)
	{
		this.SetFanPwmResult = SetFanPwmResult;
		this.message = message;
	}
}
