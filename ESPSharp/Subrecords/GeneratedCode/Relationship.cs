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
	public partial class Relationship : Subrecord, ICloneable<Relationship>, IReferenceContainer
	{
		public FormID Faction { get; set; }
		public Int32 Modifier { get; set; }
		public RelationshipCombatReaction CombatReaction { get; set; }

		public Relationship()
		{
			Faction = new FormID();
			Modifier = new Int32();
			CombatReaction = new RelationshipCombatReaction();
		}

		public Relationship(FormID Faction, Int32 Modifier, RelationshipCombatReaction CombatReaction)
		{
			this.Faction = Faction;
			this.Modifier = Modifier;
			this.CombatReaction = CombatReaction;
		}

		public Relationship(Relationship copyObject)
		{
			Faction = copyObject.Faction.Clone();
			Modifier = copyObject.Modifier;
			CombatReaction = copyObject.CombatReaction;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Master))
			{
				try
				{
					Faction.ReadBinary(subReader);
					Modifier = subReader.ReadInt32();
					CombatReaction = subReader.ReadEnum<RelationshipCombatReaction>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Faction.WriteBinary(writer);
			writer.Write(Modifier);			
			writer.Write((UInt32)CombatReaction);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Faction", true, out subEle);
			Faction.WriteXML(subEle, master);

			ele.TryPathTo("Modifier", true, out subEle);
			subEle.Value = Modifier.ToString();

			ele.TryPathTo("CombatReaction", true, out subEle);
			subEle.Value = CombatReaction.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Faction", false, out subEle))
			{
				Faction.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Modifier", false, out subEle))
			{
				Modifier = subEle.ToInt32();
			}

			if (ele.TryPathTo("CombatReaction", false, out subEle))
			{
				CombatReaction = subEle.ToEnum<RelationshipCombatReaction>();
			}
		}

		public Relationship Clone()
		{
			return new Relationship(this);
		}
	}
}
