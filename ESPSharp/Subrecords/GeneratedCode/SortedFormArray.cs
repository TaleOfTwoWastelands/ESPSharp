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
	public partial class SortedFormArray : Subrecord, ICloneable, IEquatable<SortedFormArray>  
	{
		public List<FormID> Forms { get; set; }

		public SortedFormArray(string Tag = null)
			:base(Tag)
		{
			Forms = new List<FormID>();
		}

		public SortedFormArray(List<FormID> Forms)
		{
			this.Forms = Forms;
		}

		public SortedFormArray(SortedFormArray copyObject)
		{
			if (copyObject.Forms != null)
				foreach(var temp in copyObject.Forms)
					Forms.Add((FormID)temp.Clone());
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					for (int i = 0; i < size/4; i++)
					{
						var temp = new FormID();
						temp.ReadBinary(subReader);
						Forms.Add(temp);
					}
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Forms.Sort();
			foreach (var temp in Forms)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Forms", true, out subEle);
			Forms.Sort();
			foreach (var temp in Forms)
			{
				XElement e = new XElement("Form");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Forms", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new FormID();
					temp.ReadXML(e, master);
					Forms.Add(temp);
				}
		}

		public override object Clone()
		{
			return new SortedFormArray(this);
		}

        public bool Equals(SortedFormArray other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Forms.SequenceEqual(other.Forms);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            SortedFormArray other = obj as SortedFormArray;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Forms.GetHashCode();
        }

        public static bool operator ==(SortedFormArray objA, SortedFormArray objB)
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

        public static bool operator !=(SortedFormArray objA, SortedFormArray objB)
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