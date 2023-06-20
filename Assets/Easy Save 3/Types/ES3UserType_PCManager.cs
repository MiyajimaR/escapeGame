using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("mailContents")]
	public class ES3UserType_PCManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PCManager() : base(typeof(PCManager)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PCManager)obj;
			
			writer.WriteProperty("mailContents", instance.mailContents, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<UnityEngine.GameObject>)));
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PCManager)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "mailContents":
						instance.mailContents = reader.Read<System.Collections.Generic.List<UnityEngine.GameObject>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PCManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PCManagerArray() : base(typeof(PCManager[]), ES3UserType_PCManager.Instance)
		{
			Instance = this;
		}
	}
}