















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
	public partial class IMADTimeValues : Subrecord, ICloneable, IEquatable<IMADTimeValues>  
	{
		public List<IMADTimeValue> TimeValues { get; set; }


		public IMADTimeValues(string Tag = null)
			:base(Tag)
		{
			TimeValues = new List<IMADTimeValue>();

		}

		public IMADTimeValues(List<IMADTimeValue> TimeValues)
		{
			this.TimeValues = TimeValues;

		}

		public IMADTimeValues(IMADTimeValues copyObject)
		{
			if (copyObject.TimeValues != null)
				foreach(var temp in copyObject.TimeValues)
					TimeValues.Add((IMADTimeValue)temp.Clone());

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					for (int i = 0; i < size/8; i++)
					{
						var temp = new IMADTimeValue();
						temp.ReadBinary(subReader);
						TimeValues.Add(temp);
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
			foreach (var temp in TimeValues)
			{
				temp.WriteBinary(writer);
			}

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("TimeValues", true, out subEle);
			foreach (var temp in TimeValues)
			{
				XElement e = new XElement("TimeValue");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("TimeValues", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new IMADTimeValue();
					temp.ReadXML(e, master);
					TimeValues.Add(temp);
				}

		}

		public override object Clone()
		{
			return new IMADTimeValues(this);
		}



        public bool Equals(IMADTimeValues other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return TimeValues.SequenceEqual(other.TimeValues);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            IMADTimeValues other = obj as IMADTimeValues;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return TimeValues.GetHashCode();
        }

        public static bool operator ==(IMADTimeValues objA, IMADTimeValues objB)
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

        public static bool operator !=(IMADTimeValues objA, IMADTimeValues objB)
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