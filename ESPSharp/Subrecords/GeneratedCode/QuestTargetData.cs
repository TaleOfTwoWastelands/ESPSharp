
















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
	public partial class QuestTargetData : Subrecord, ICloneable, IComparable<QuestTargetData>, IEquatable<QuestTargetData>  
	{
		public FormID Target { get; set; }
		public QuestTargetFlags Flags { get; set; }
		public Byte[] Unused { get; set; }


		public QuestTargetData(string Tag = null)
			:base(Tag)
		{
			Target = new FormID();
			Flags = new QuestTargetFlags();
			Unused = new byte[3];

		}

		public QuestTargetData(FormID Target, QuestTargetFlags Flags, Byte[] Unused)
		{
			this.Target = Target;
			this.Flags = Flags;
			this.Unused = Unused;

		}

		public QuestTargetData(QuestTargetData copyObject)
		{
			if (copyObject.Target != null)
				Target = (FormID)copyObject.Target.Clone();
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
					Target.ReadBinary(subReader);
					Flags = subReader.ReadEnum<QuestTargetFlags>();
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
			Target.WriteBinary(writer);
			writer.Write((Byte)Flags);
			if (Unused == null)
				writer.Write(new byte[3]);
			else
			writer.Write(Unused);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Target", true, out subEle);
			Target.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			WriteUnusedXML(ele, master);

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Target", false, out subEle))
				Target.ReadXML(subEle, master);

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<QuestTargetFlags>();

			ReadUnusedXML(ele, master);

		}

		public override object Clone()
		{
			return new QuestTargetData(this);
		}


        public int CompareTo(QuestTargetData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(QuestTargetData objA, QuestTargetData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(QuestTargetData objA, QuestTargetData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(QuestTargetData objA, QuestTargetData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(QuestTargetData objA, QuestTargetData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(QuestTargetData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Target == other.Target &&
				Flags == other.Flags &&
				Unused.SequenceEqual(other.Unused);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            QuestTargetData other = obj as QuestTargetData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Target.GetHashCode();
        }

        public static bool operator ==(QuestTargetData objA, QuestTargetData objB)
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

        public static bool operator !=(QuestTargetData objA, QuestTargetData objB)
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