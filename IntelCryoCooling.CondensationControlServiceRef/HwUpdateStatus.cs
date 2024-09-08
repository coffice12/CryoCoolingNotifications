using System;
using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace IntelCryoCooling.CondensationControlServiceRef;

[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[Flags]
[DataContract(Name = "HwUpdateStatus", Namespace = "http://schemas.datacontract.org/2004/07/IntelCryoCooling")]
public enum HwUpdateStatus
{
	[EnumMember]
	success = 0,
	[EnumMember]
	fail = 1,
	[EnumMember]
	unknown = 2,
	[EnumMember]
	bad_request = 3
}
