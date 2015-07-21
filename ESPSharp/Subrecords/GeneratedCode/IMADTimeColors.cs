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
	public partial class IMADTimeColors : Subrecord, ICloneable, IEquatable<IMADTimeColors>  
	{
		public List<IMADTimeColor> TimeColors { get; set; }

		public IMADTimeColors(string Tag = null)
			:base(Tag)
		{
			TimeColors = new List<IMADTimeColor>();
		}

		public IMADTimeColors(List<IMADTimeColor> TimeColors)
		{
			this.TimeColors = TimeColors;
		}

		public IMADTimeColors(IMADTimeColors copyObject)
		{
			if (copyObject.TimeColors != null)
				foreach(var temp in copyObject.TimeColors)
					TimeColors.Add((IMADTimeColor)temp.Clone());
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					for (int i = 0; i < size/20; i++)
					{
						var temp = new IMADTimeColor();
						temp.ReadBinary(subReader);
						TimeColors.Add(temp);
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
			foreach (var temp in TimeColors)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("TimeColors", true, out subEle);
			foreach (var temp in TimeColors)
			{
				XElement e = new XElement("TimeColor");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("TimeColors", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new IMADTimeColor();
					temp.ReadXML(e, master);
					TimeColors.Add(temp);
				}
		}

		public override object Clone()
		{
			return new IMADTimeColors(this);
		}

        public bool Equals(IMADTimeColors other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return TimeColors.SequenceEqual(other.TimeColors);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            IMADTimeColors other = obj as IMADTimeColors;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return TimeColors.GetHashCode();
        }

        public static bool operator ==(IMADTimeColors objA, IMADTimeColors objB)
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

        public static bool operator !=(IMADTimeColors objA, IMADTimeColors objB)
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