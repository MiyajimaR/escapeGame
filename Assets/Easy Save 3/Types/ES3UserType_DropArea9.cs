using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("openLock", "firstUse")]
	public class ES3UserType_DropArea9 : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_DropArea9() : base(typeof(DropArea9)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (DropArea9)obj;
			
			writer.WritePrivateField("openLock", instance);
			writer.WritePrivateField("firstUse", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (DropArea9)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "openLock":
					instance = (DropArea9)reader.SetPrivateField("openLock", reader.Read<System.Boolean>(), instance);
					break;
					case "firstUse":
					instance = (DropArea9)reader.SetPrivateField("firstUse", reader.Read<System.Boolean>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_DropArea9Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DropArea9Array() : base(typeof(DropArea9[]), ES3UserType_DropArea9.Instance)
		{
			Instance = this;
		}
	}
}