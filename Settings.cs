using System.IO;
using System.Reflection;
using UnityEngine;
using ModSettings;

namespace Settings
{
	internal class AstridPaperdollSettingsMain : JsonModSettings
	{
		protected override void OnConfirm()
		{
			AstridPaperdoll.Astrid_Melon.UpdateAppearance();
			base.OnConfirm();
		}

		[Section("General")]

		[Name("Enable Mod")]
		[Description("Vanilla or Custom Appearance")]
		public bool enabled = true;


		[Name("Eyeliner")]
		[Description("Eyeliner on or off.")]
		public bool Eyeliner = true;

		[Name("Lipstick Shade")]
		[Description("Light, Medium, or Dark")]
		[Choice("Light", "Medium", "Dark")]
		public int lipstick = 1;

	}

	internal static class Settings
	{
		public static AstridPaperdollSettingsMain options;

		public static void OnLoad()
		{
			options = new AstridPaperdollSettingsMain();
			options.AddToModSettings("Astrid Makeover Settings");
		}


	}


}
