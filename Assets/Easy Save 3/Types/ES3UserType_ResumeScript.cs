using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("eduText", "motivaText", "reqText", "_eduSelect", "_motivaSelect", "_reqSelect")]
	public class ES3UserType_ResumeScript : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ResumeScript() : base(typeof(ResumeScript)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ResumeScript)obj;
			
			writer.WritePrivateFieldByRef("eduText", instance);
			writer.WritePrivateFieldByRef("motivaText", instance);
			writer.WritePrivateFieldByRef("reqText", instance);
			writer.WritePrivateField("_eduSelect", instance);
			writer.WritePrivateField("_motivaSelect", instance);
			writer.WritePrivateField("_reqSelect", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ResumeScript)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "eduText":
					instance = (ResumeScript)reader.SetPrivateField("eduText", reader.Read<TMPro.TextMeshProUGUI>(), instance);
					break;
					case "motivaText":
					instance = (ResumeScript)reader.SetPrivateField("motivaText", reader.Read<TMPro.TextMeshProUGUI>(), instance);
					break;
					case "reqText":
					instance = (ResumeScript)reader.SetPrivateField("reqText", reader.Read<TMPro.TextMeshProUGUI>(), instance);
					break;
					case "_eduSelect":
					instance = (ResumeScript)reader.SetPrivateField("_eduSelect", reader.Read<System.Int32>(), instance);
					break;
					case "_motivaSelect":
					instance = (ResumeScript)reader.SetPrivateField("_motivaSelect", reader.Read<System.Int32>(), instance);
					break;
					case "_reqSelect":
					instance = (ResumeScript)reader.SetPrivateField("_reqSelect", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ResumeScriptArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ResumeScriptArray() : base(typeof(ResumeScript[]), ES3UserType_ResumeScript.Instance)
		{
			Instance = this;
		}
	}
}