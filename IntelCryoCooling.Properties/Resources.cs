using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace IntelCryoCooling.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("IntelCryoCooling.Properties.Resources", typeof(Resources).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Icon alert_blue => (Icon)ResourceManager.GetObject("alert_blue", resourceCulture);

	internal static Icon alert_green => (Icon)ResourceManager.GetObject("alert_green", resourceCulture);

	internal static Icon alert_purple => (Icon)ResourceManager.GetObject("alert_purple", resourceCulture);

	internal static Icon alert_red => (Icon)ResourceManager.GetObject("alert_red", resourceCulture);

	internal static Icon alert_yellow => (Icon)ResourceManager.GetObject("alert_yellow", resourceCulture);

	internal static byte[] FAQ_CM => (byte[])ResourceManager.GetObject("FAQ_CM", resourceCulture);

	internal static byte[] FAQ_EK => (byte[])ResourceManager.GetObject("FAQ_EK", resourceCulture);

	internal static byte[] FAQ_EK_Gen2 => (byte[])ResourceManager.GetObject("FAQ_EK_Gen2", resourceCulture);

	internal static Icon logo => (Icon)ResourceManager.GetObject("logo", resourceCulture);

	internal Resources()
	{
	}
}
