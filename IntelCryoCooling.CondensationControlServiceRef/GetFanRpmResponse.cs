using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetFanRpmResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetFanRpmResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint GetFanRpmResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetFanRpmResponse()
	{
	}

	public GetFanRpmResponse(uint GetFanRpmResult, HwUpdateStatus success, string message)
	{
		this.GetFanRpmResult = GetFanRpmResult;
		this.success = success;
		this.message = message;
	}
}
