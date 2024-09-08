using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "Bist2Response", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class Bist2Response
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public uint Bist2Result;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 1)]
	public HwUpdateStatus success;

	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 2)]
	public string message;

	public Bist2Response()
	{
	}

	public Bist2Response(uint Bist2Result, HwUpdateStatus success, string message)
	{
		this.Bist2Result = Bist2Result;
		this.success = success;
		this.message = message;
	}
}
