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

namespace ESPSharp.DataTypes
{
	public partial class AlternateTexture : IESPSerializable, ICloneable, IComparable<AlternateTexture>, IEquatable<AlternateTexture>  
	{
		public String Name { get; set; }
		public FormID TextureSet { get; set; }
		public Int32 Index { get; set; }

		public AlternateTexture()
		{
			Name = "";
			TextureSet = new FormID();
			Index = new Int32();
		}

		public AlternateTexture(String Name, FormID TextureSet, Int32 Index)
		{
			this.Name = Name;
			this.TextureSet = TextureSet;
			this.Index = Index;
		}

		public AlternateTexture(AlternateTexture copyObject)
		{
			if (copyObject.Name != null)
				Name = (String)copyObject.Name.Clone();
			if (copyObject.TextureSet != null)
				TextureSet = (FormID)copyObject.TextureSet.Clone();
			Index = copyObject.Index;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				ReadNameBinary(reader);
					TextureSet.ReadBinary(reader);
					Index = reader.ReadInt32();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			WriteNameBinary(writer);
			TextureSet.WriteBinary(writer);
			writer.Write(Index);
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Name", true, out subEle);
			subEle.Value = Name.ToString();

			ele.TryPathTo("TextureSet", true, out subEle);
			TextureSet.WriteXML(subEle, master);

			ele.TryPathTo("Index", true, out subEle);
			subEle.Value = Index.ToString();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Name", false, out subEle))
				Name = subEle.Value;

			if (ele.TryPathTo("TextureSet", false, out subEle))
				TextureSet.ReadXML(subEle, master);

			if (ele.TryPathTo("Index", false, out subEle))
				Index = subEle.ToInt32();
		}

		public object Clone()
		{
			return new AlternateTexture(this);
		}

        public int CompareTo(AlternateTexture other)
        {
			return Index.CompareTo(other.Index);
        }

        public static bool operator >(AlternateTexture objA, AlternateTexture objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(AlternateTexture objA, AlternateTexture objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(AlternateTexture objA, AlternateTexture objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(AlternateTexture objA, AlternateTexture objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(AlternateTexture other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Name.SequenceEqual(other.Name) &&
				TextureSet == other.TextureSet &&
				Index == other.Index;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            AlternateTexture other = obj as AlternateTexture;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }

        public static bool operator ==(AlternateTexture objA, AlternateTexture objB)
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

        public static bool operator !=(AlternateTexture objA, AlternateTexture objB)
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

		partial void ReadNameBinary(ESPReader reader);

		partial void WriteNameBinary(ESPWriter writer);
	}
}