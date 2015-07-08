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

namespace ESPSharp.SubrecordCollections
{
    public partial class Card : SubrecordCollection, ICloneable<Card>
    {
        public SimpleSubrecord<CardSuit> Suit { get; set; }
        public SimpleSubrecord<CardValue> Value { get; set; }

        public Card()
        {
            Suit = new SimpleSubrecord<CardSuit>();
            Value = new SimpleSubrecord<CardValue>();
        }

        public Card(SimpleSubrecord<CardSuit> Suit, SimpleSubrecord<CardValue> Value)
        {
            this.Suit = Suit;
            this.Value = Value;
        }

        public Card(Card copyObject)
        {
            Suit = copyObject.Suit.Clone();
            Value = copyObject.Value.Clone();
        }

        public override void ReadBinary(ESPReader reader)
        {
            List<string> readTags = new List<string>();

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                string subTag = reader.PeekTag();

                switch (subTag)
                {
                    case "INTV":
                        if (readTags.Contains("INTV"))
                        {
                            Value.ReadBinary(reader);
                            return;
                        }
                        Suit.ReadBinary(reader);
                        break;
                    default:
                        return;
                }

                readTags.Add(subTag);
            }
        }

        public override void WriteBinary(ESPWriter writer)
        {
            if (Suit != null)
                Suit.WriteBinary(writer);
            if (Value != null)
                Value.WriteBinary(writer);
        }

        public override void WriteXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (Suit != null)
            {
                ele.TryPathTo("Suit", true, out subEle);
                Suit.WriteXML(subEle, master);
            }
            if (Value != null)
            {
                ele.TryPathTo("Value", true, out subEle);
                Value.WriteXML(subEle, master);
            }
        }

        public override void ReadXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Suit", false, out subEle))
            {
                if (Suit == null)
                    Suit = new SimpleSubrecord<CardSuit>();

                Suit.ReadXML(subEle, master);
            }
            if (ele.TryPathTo("Value", false, out subEle))
            {
                if (Value == null)
                    Value = new SimpleSubrecord<CardValue>();

                Value.ReadXML(subEle, master);
            }
        }

        public Card Clone()
        {
            return new Card(this);
        }

    }
}