﻿
















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
	public partial class BookData : Subrecord, ICloneable, IComparable<BookData>, IEquatable<BookData>  
	{
		public BookFlags Flags { get; set; }
		public ActorValuesByte Skill { get; set; }
		public Int32 Value { get; set; }
		public Single Weight { get; set; }


		public BookData(string Tag = null)
			:base(Tag)
		{
			Flags = new BookFlags();
			Skill = new ActorValuesByte();
			Value = new Int32();
			Weight = new Single();

		}

		public BookData(BookFlags Flags, ActorValuesByte Skill, Int32 Value, Single Weight)
		{
			this.Flags = Flags;
			this.Skill = Skill;
			this.Value = Value;
			this.Weight = Weight;

		}

		public BookData(BookData copyObject)
		{
			Flags = copyObject.Flags;
			Skill = copyObject.Skill;
			Value = copyObject.Value;
			Weight = copyObject.Weight;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Flags = subReader.ReadEnum<BookFlags>();
					Skill = subReader.ReadEnum<ActorValuesByte>();
					Value = subReader.ReadInt32();
					Weight = subReader.ReadSingle();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((Byte)Flags);
			writer.Write((SByte)Skill);
			writer.Write(Value);
			writer.Write(Weight);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Skill", true, out subEle);
			subEle.Value = Skill.ToString();

			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString();

			ele.TryPathTo("Weight", true, out subEle);
			subEle.Value = Weight.ToString("G15");

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<BookFlags>();

			if (ele.TryPathTo("Skill", false, out subEle))
				Skill = subEle.ToEnum<ActorValuesByte>();

			if (ele.TryPathTo("Value", false, out subEle))
				Value = subEle.ToInt32();

			if (ele.TryPathTo("Weight", false, out subEle))
				Weight = subEle.ToSingle();

		}

		public override object Clone()
		{
			return new BookData(this);
		}


        public int CompareTo(BookData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(BookData objA, BookData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(BookData objA, BookData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(BookData objA, BookData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(BookData objA, BookData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(BookData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Flags == other.Flags &&
				Skill == other.Skill &&
				Value == other.Value &&
				Weight == other.Weight;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            BookData other = obj as BookData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Skill.GetHashCode();
        }

        public static bool operator ==(BookData objA, BookData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return true;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return false;
			}

            return objA.Equals(objB);
        }

        public static bool operator !=(BookData objA, BookData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return false;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return true;
			}

            return !objA.Equals(objB);
        }





	}
}