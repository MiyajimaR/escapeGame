using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("_openLock", "firstUse")]
	public class ES3UserType_Mystery2 : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Mystery2() : base(typeof(Mystery2)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Mystery2)obj;
			
			writer.WritePrivateField("_openLock", instance);
			writer.WriteProperty("firstUse", instance.firstUse, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Mystery2)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "_openLock":
					instance = (Mystery2)reader.SetPrivateField("_openLock", reader.Read<System.Boolean>(), instance);
					break;
					case "firstUse":
						instance.firstUse = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_Mystery2Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_Mystery2Array() : base(typeof(Mystery2[]), ES3UserType_Mystery2.Instance)
		{
			Instance = this;
		}
	}
}