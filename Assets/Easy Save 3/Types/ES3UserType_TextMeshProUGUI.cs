using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_text")]
	public class ES3UserType_TextMeshProUGUI : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TextMeshProUGUI() : base(typeof(TMPro.TextMeshProUGUI)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TMPro.TextMeshProUGUI)obj;
			
			writer.WritePrivateField("m_text", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TMPro.TextMeshProUGUI)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_text":
					instance = (TMPro.TextMeshProUGUI)reader.SetPrivateField("m_text", reader.Read<System.String>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TextMeshProUGUIArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TextMeshProUGUIArray() : base(typeof(TMPro.TextMeshProUGUI[]), ES3UserType_TextMeshProUGUI.Instance)
		{
			Instance = this;
		}
	}
}