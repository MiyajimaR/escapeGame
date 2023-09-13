using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_FillAmount", "sprite", "enabled")]
	public class ES3UserType_Image : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Image() : base(typeof(UnityEngine.UI.Image)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Image)obj;
			
			writer.WritePrivateField("m_FillAmount", instance);
			writer.WritePropertyByRef("sprite", instance.sprite);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Image)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_FillAmount":
					instance = (UnityEngine.UI.Image)reader.SetPrivateField("m_FillAmount", reader.Read<System.Single>(), instance);
					break;
					case "sprite":
						instance.sprite = reader.Read<UnityEngine.Sprite>(ES3Type_Sprite.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ImageArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ImageArray() : base(typeof(UnityEngine.UI.Image[]), ES3UserType_Image.Instance)
		{
			Instance = this;
		}
	}
}