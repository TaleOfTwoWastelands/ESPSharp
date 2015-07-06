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
	public partial class PerkAbilityData : Subrecord, ICloneable<PerkAbilityData>, IReferenceContainer
	{
		public FormID Ability { get; set; }

		public PerkAbilityData()
		{
			Ability = new FormID();
		}

		public PerkAbilityData(FormID Ability)
		{
			this.Ability = Ability;
		}

		public PerkAbilityData(PerkAbilityData copyObject)
		{
			Ability = copyObject.Ability.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Ability.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Ability.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Ability", true, out subEle);
			Ability.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Ability", false, out subEle))
			{
				Ability.ReadXML(subEle, master);
			}
		}

		public PerkAbilityData Clone()
		{
			return new PerkAbilityData(this);
		}

	}
}
