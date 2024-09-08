using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IntelCryoCooling.CondensationControlServiceRef;

[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "OperationMode", Namespace = "http://schemas.datacontract.org/2004/07/IntelCryoCooling")]
public enum OperationMode
{
	[EnumMember]
	Pending,
	[EnumMember]
	Standby,
	[EnumMember]
	Manual,
	[EnumMember]
	Cryo,
	[EnumMember]
	Unregulated
}
