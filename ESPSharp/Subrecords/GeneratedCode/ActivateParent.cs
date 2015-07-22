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
	public partial class ActivateParent : Subrecord, ICloneable, IComparable<ActivateParent>, IEquatable<ActivateParent>  
	{
		public FormID Parent { get; set; }
		public Single Delay { get; set; }

		public ActivateParent(string Tag = null)
			:base(Tag)
		{
			Parent = new FormID();
			Delay = new Single();
		}

		public ActivateParent(FormID Parent, Single Delay)
		{
			this.Parent = Parent;
			this.Delay = Delay;
		}

		public ActivateParent(ActivateParent copyObject)
		{
			if (copyObject.Parent != null)
				Parent = (FormID)copyObject.Parent.Clone();
			Delay = copyObject.Delay;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Parent.ReadBinary(subReader);
					Delay = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Parent.WriteBinary(writer);
			writer.Write(Delay);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Parent", true, out subEle);
			Parent.WriteXML(subEle, master);

			ele.TryPathTo("Delay", true, out subEle);
			subEle.Value = Delay.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Parent", false, out subEle))
				Parent.ReadXML(subEle, master);

			if (ele.TryPathTo("Delay", false, out subEle))
				Delay = subEle.ToSingle();
		}

		public override object Clone()
		{
			return new ActivateParent(this);
		}

        public int CompareTo(ActivateParent other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(ActivateParent objA, ActivateParent objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ActivateParent objA, ActivateParent objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ActivateParent objA, ActivateParent objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ActivateParent objA, ActivateParent objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(ActivateParent other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Parent == other.Parent &&
				Delay == other.Delay;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ActivateParent other = obj as ActivateParent;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Parent.GetHashCode();
        }

        public static bool operator ==(ActivateParent objA, ActivateParent objB)
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

        public static bool operator !=(ActivateParent objA, ActivateParent objB)
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