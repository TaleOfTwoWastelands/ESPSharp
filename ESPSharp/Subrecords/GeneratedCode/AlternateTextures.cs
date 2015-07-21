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
	public partial class AlternateTextures : Subrecord, ICloneable, IEquatable<AlternateTextures>, IReferenceContainer  
	{
		public List<AlternateTexture> Textures { get; set; }

		public AlternateTextures(string Tag = null)
			:base(Tag)
		{
			Textures = new List<AlternateTexture>();
		}

		public AlternateTextures(List<AlternateTexture> Textures)
		{
			this.Textures = Textures;
		}

		public AlternateTextures(AlternateTextures copyObject)
		{
			if (copyObject.Textures != null)
				foreach(var temp in copyObject.Textures)
					Textures.Add((AlternateTexture)temp.Clone());
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Int32 TexturesCount = subReader.ReadInt32();

					for (int i = 0; i < TexturesCount; i++)
					{
						var temp = new AlternateTexture();
						temp.ReadBinary(subReader);
						Textures.Add(temp);
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
			writer.Write((Int32)Textures.Count);
			Textures.Sort();
			foreach (var temp in Textures)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Textures", true, out subEle);
			Textures.Sort();
			foreach (var temp in Textures)
			{
				XElement e = new XElement("Texture");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Textures", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new AlternateTexture();
					temp.ReadXML(e, master);
					Textures.Add(temp);
				}
		}

		public override object Clone()
		{
			return new AlternateTextures(this);
		}

        public bool Equals(AlternateTextures other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Textures.SequenceEqual(other.Textures);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            AlternateTextures other = obj as AlternateTextures;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Textures.GetHashCode();
        }

        public static bool operator ==(AlternateTextures objA, AlternateTextures objB)
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

        public static bool operator !=(AlternateTextures objA, AlternateTextures objB)
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