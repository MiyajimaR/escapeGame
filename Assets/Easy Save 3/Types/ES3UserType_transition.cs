using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Hol", "Ver")]
	public class ES3UserType_transition : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_transition() : base(typeof(transition)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (transition)obj;
			
			writer.WritePrivateField("Hol", instance);
			writer.WritePrivateField("Ver", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (transition)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Hol":
					instance = (transition)reader.SetPrivateField("Hol", reader.Read<System.Int32>(), instance);
					break;
					case "Ver":
					instance = (transition)reader.SetPrivateField("Ver", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_transitionArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_transitionArray() : base(typeof(transition[]), ES3UserType_transition.Instance)
		{
			Instance = this;
		}
	}
}