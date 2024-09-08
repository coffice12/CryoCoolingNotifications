using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace IntelCryoCooling.CondensationControlServiceRef;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SetSetPointOffset", WrapperNamespace = "IntelCryoCooling", IsWrapped = true)]
public class SetSetPointOffsetRequest
{
	[MessageBodyMember(Namespace = "IntelCryoCooling", Order = 0)]
	public float setpoint;

	public SetSetPointOffsetRequest()
	{
	}

	public SetSetPointOffsetRequest(float setpoint)
	{
		this.setpoint = setpoint;
	}
}
