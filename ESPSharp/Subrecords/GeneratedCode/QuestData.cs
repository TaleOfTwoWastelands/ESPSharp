
















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
	public partial class QuestData : Subrecord, ICloneable, IComparable<QuestData>, IEquatable<QuestData>  
	{
		public QuestFlags Flags { get; set; }
		public Byte Priority { get; set; }
		public Byte[] Unused { get; set; }
		public Single QuestDelay { get; set; }


		public QuestData(string Tag = null)
			:base(Tag)
		{
			Flags = new QuestFlags();
			Priority = new Byte();
			Unused = new byte[2];
			QuestDelay = new Single();

		}

		public QuestData(QuestFlags Flags, Byte Priority, Byte[] Unused, Single QuestDelay)
		{
			this.Flags = Flags;
			this.Priority = Priority;
			this.Unused = Unused;
			this.QuestDelay = QuestDelay;

		}

		public QuestData(QuestData copyObject)
		{
			Flags = copyObject.Flags;
			Priority = copyObject.Priority;
			if (copyObject.Unused != null)
				Unused = (Byte[])copyObject.Unused.Clone();
			QuestDelay = copyObject.QuestDelay;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Flags = subReader.ReadEnum<QuestFlags>();
					Priority = subReader.ReadByte();
					Unused = subReader.ReadBytes(2);
					QuestDelay = subReader.ReadSingle();

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
			writer.Write(Priority);
			if (Unused == null)
				writer.Write(new byte[2]);
			else
			writer.Write(Unused);
			writer.Write(QuestDelay);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Priority", true, out subEle);
			subEle.Value = Priority.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("QuestDelay", true, out subEle);
			subEle.Value = QuestDelay.ToString("G15");

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<QuestFlags>();

			if (ele.TryPathTo("Priority", false, out subEle))
				Priority = subEle.ToByte();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("QuestDelay", false, out subEle))
				QuestDelay = subEle.ToSingle();

		}

		public override object Clone()
		{
			return new QuestData(this);
		}


        public int CompareTo(QuestData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(QuestData objA, QuestData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(QuestData objA, QuestData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(QuestData objA, QuestData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(QuestData objA, QuestData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(QuestData other)
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
				Priority == other.Priority &&
				Unused.SequenceEqual(other.Unused) &&
				QuestDelay == other.QuestDelay;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            QuestData other = obj as QuestData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Priority.GetHashCode();
        }

        public static bool operator ==(QuestData objA, QuestData objB)
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

        public static bool operator !=(QuestData objA, QuestData objB)
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