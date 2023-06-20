using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("objID")]
	public class ES3UserType_TapEffectScript : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TapEffectScript() : base(typeof(TapEffectScript)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TapEffectScript)obj;
			
			writer.WriteProperty("objID", instance.objID, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TapEffectScript)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "objID":
						instance.objID = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TapEffectScriptArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TapEffectScriptArray() : base(typeof(TapEffectScript[]), ES3UserType_TapEffectScript.Instance)
		{
			Instance = this;
		}
	}
}