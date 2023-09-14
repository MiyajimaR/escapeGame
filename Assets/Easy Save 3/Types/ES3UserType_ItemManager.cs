using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Item0_inWater", "_Item1_canGet", "_mirrorIsCrashed", "_showerIsCrashed", "_stickHook")]
	public class ES3UserType_ItemManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ItemManager() : base(typeof(ItemManager)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ItemManager)obj;
			
			writer.WriteProperty("Item0_inWater", instance.Item0_inWater, ES3Type_bool.Instance);
			writer.WritePrivateField("_Item1_canGet", instance);
			writer.WritePrivateField("_mirrorIsCrashed", instance);
			writer.WritePrivateField("_showerIsCrashed", instance);
			writer.WritePrivateField("_stickHook", instance);
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
					case "_Item1_canGet":
					instance = (ItemManager)reader.SetPrivateField("_Item1_canGet", reader.Read<System.Boolean>(), instance);
					break;
					case "_mirrorIsCrashed":
					instance = (ItemManager)reader.SetPrivateField("_mirrorIsCrashed", reader.Read<System.Boolean>(), instance);
					break;
					case "_showerIsCrashed":
					instance = (ItemManager)reader.SetPrivateField("_showerIsCrashed", reader.Read<System.Boolean>(), instance);
					break;
					case "_stickHook":
					instance = (ItemManager)reader.SetPrivateField("_stickHook", reader.Read<System.Boolean>(), instance);
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