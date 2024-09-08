using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetPumpRpmResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetPumpRpmResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint GetPumpRpmResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetPumpRpmResponse()
	{
	}

	public GetPumpRpmResponse(uint GetPumpRpmResult, HwUpdateStatus success, string message)
	{
		this.GetPumpRpmResult = GetPumpRpmResult;
		this.success = success;
		this.message = message;
	}
}
