
















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
	public partial class IngredientData : Subrecord, ICloneable, IComparable<IngredientData>, IEquatable<IngredientData>  
	{
		public Int32 Value { get; set; }
		public IngredientFlags Flags { get; set; }
		public Byte[] Unused { get; set; }


		public IngredientData(string Tag = null)
			:base(Tag)
		{
			Value = new Int32();
			Flags = new IngredientFlags();
			Unused = new byte[3];

		}

		public IngredientData(Int32 Value, IngredientFlags Flags, Byte[] Unused)
		{
			this.Value = Value;
			this.Flags = Flags;
			this.Unused = Unused;

		}

		public IngredientData(IngredientData copyObject)
		{
			Value = copyObject.Value;
			Flags = copyObject.Flags;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Value = subReader.ReadInt32();
					Flags = subReader.ReadEnum<IngredientFlags>();
					Unused = subReader.ReadBytes(3);

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
			writer.Write((Byte)Flags);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Value", true, out subEle);
			subEle.Value = Value.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnusedXML(ele, master);

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Value", false, out subEle))
				Value = subEle.ToInt32();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<IngredientFlags>();

			ReadUnusedXML(ele, master);

		}

		public override object Clone()
		{
			return new IngredientData(this);
		}


        public int CompareTo(IngredientData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(IngredientData objA, IngredientData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(IngredientData objA, IngredientData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(IngredientData objA, IngredientData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(IngredientData objA, IngredientData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(IngredientData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Value == other.Value &&
				Flags == other.Flags &&
				Unused.SequenceEqual(other.Unused);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            IngredientData other = obj as IngredientData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(IngredientData objA, IngredientData objB)
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

        public static bool operator !=(IngredientData objA, IngredientData objB)
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





		partial void ReadUnusedXML(XElement ele, ElderScrollsPlugin master);



		partial void WriteUnusedXML(XElement ele, ElderScrollsPlugin master);

	}
}