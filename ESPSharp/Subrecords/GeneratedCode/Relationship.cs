using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;

namespace ESPSharp.Subrecords
{
	public partial class Relationship : Subrecord
	{
		public FormID Faction { get; set; }
		public Int32 Modifier { get; set; }
		public RelationshipCombatReaction CombatReaction { get; set; }
	
		protected override void ReadData(ESPReader reader)
		{
			Faction = reader.ReadFormID();
			Modifier = reader.ReadInt32();
			CombatReaction = reader.ReadEnum<RelationshipCombatReaction>();
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Faction);
			writer.Write(Modifier);
			writer.Write((UInt32)CombatReaction);
		}

		protected override void WriteDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("Faction", true, out subEle);
			subEle.Value = Faction.ToString();

			ele.TryPathTo("Modifier", true, out subEle);
			subEle.Value = Modifier.ToString();

			ele.TryPathTo("CombatReaction", true, out subEle);
			subEle.Value = CombatReaction.ToString();
		}

		protected override void ReadDataXML(XElement ele)
		{
			XElement subEle;

			ele.TryPathTo("Faction", false, out subEle);
			Faction = subEle.ToFormID();

			ele.TryPathTo("Modifier", false, out subEle);
			Modifier = subEle.ToInt32();

			ele.TryPathTo("CombatReaction", false, out subEle);
			CombatReaction = subEle.ToEnum<RelationshipCombatReaction>();
		}
	}
}
