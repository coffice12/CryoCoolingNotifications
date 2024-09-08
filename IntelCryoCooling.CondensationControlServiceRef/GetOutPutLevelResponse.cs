using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "GetOutPutLevelResponse", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class GetOutPutLevelResponse
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint GetOutPutLevelResult;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public GetOutPutLevelResponse()
	{
	}

	public GetOutPutLevelResponse(uint GetOutPutLevelResult, HwUpdateStatus success, string message)
	{
		this.GetOutPutLevelResult = GetOutPutLevelResult;
		this.success = success;
		this.message = message;
	}
}
