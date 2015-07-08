using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Interfaces;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;
using ESPSharp.DataTypes;

namespace ESPSharp.Subrecords
{
	public partial class WeaponData : Subrecord, ICloneable<WeaponData>
	{
		public Int32 Value { get; set; }
		public Int32 Health { get; set; }
		public Single Weight { get; set; }
		public Int16 BaseDamage { get; set; }
		public Byte ClipSize { get; set; }

		public WeaponData()
		{
			Value = new Int32();
			Health = new Int32();
			Weight = new Single();
			BaseDamage = new Int16();
			ClipSize = new Byte();
		}

		public WeaponData(Int32 Value, Int32 Health, Single Weight, Int16 BaseDamage, Byte ClipSize)
		{
			this.Value = Value;
			this.Health = Health;
			this.Weight = Weight;
			this.BaseDamage = BaseDamage;
			this.ClipSize = ClipSize;
		}

		public WeaponData(WeaponData copyObject)
		{
			Value = copyObject.Value;
			Health = copyObject.Health;
			Weight = copyObject.Weight;
			BaseDamage = copyObject.BaseDamage;
			ClipSize = copyObject.ClipSize;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Value = subReader.ReadInt32();
					Health = subReader.ReadInt32();
					Weight = subReader.ReadSingle();
					BaseDamage = subReader.ReadInt16();
					ClipSize = subReader.ReadByte();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Value);			
			writer.Write(Health);			
			writer.Write(Weight);			
			writer.Write(BaseDamage);			
			writer.Write(ClipSize);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString();

			ele.TryPathTo("Health", true, out subEle);
			subEle.Value = Health.ToString();

			ele.TryPathTo("Weight", true, out subEle);
			subEle.Value = Weight.ToString("G15");

			ele.TryPathTo("BaseDamage", true, out subEle);
			subEle.Value = BaseDamage.ToString();

			ele.TryPathTo("ClipSize", true, out subEle);
			subEle.Value = ClipSize.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Value", false, out subEle))
			{
				Value = subEle.ToInt32();
			}

			if (ele.TryPathTo("Health", false, out subEle))
			{
				Health = subEle.ToInt32();
			}

			if (ele.TryPathTo("Weight", false, out subEle))
			{
				Weight = subEle.ToSingle();
			}

			if (ele.TryPathTo("BaseDamage", false, out subEle))
			{
				BaseDamage = subEle.ToInt16();
			}

			if (ele.TryPathTo("ClipSize", false, out subEle))
			{
				ClipSize = subEle.ToByte();
			}
		}

		public WeaponData Clone()
		{
			return new WeaponData(this);
		}

	}
}
