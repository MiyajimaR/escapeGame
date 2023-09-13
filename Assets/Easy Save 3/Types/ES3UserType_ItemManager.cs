using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Item0_inWater", "_mirrorIsCrashed")]
	public class ES3UserType_ItemManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ItemManager() : base(typeof(ItemManager)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ItemManager)obj;
			
			writer.WriteProperty("Item0_inWater", instance.Item0_inWater, ES3Type_bool.Instance);
			writer.WritePrivateField("_mirrorIsCrashed", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ItemManager)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Item0_inWater":
						instance.Item0_inWater = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "_mirrorIsCrashed":
					instance = (ItemManager)reader.SetPrivateField("_mirrorIsCrashed", reader.Read<System.Boolean>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ItemManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ItemManagerArray() : base(typeof(ItemManager[]), ES3UserType_ItemManager.Instance)
		{
			Instance = this;
		}
	}
}