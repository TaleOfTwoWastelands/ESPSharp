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
	public partial class NavMeshVertexList : Subrecord, ICloneable, IEquatable<NavMeshVertexList>  
	{
		public List<XYZFloat> Vertices { get; set; }

		public NavMeshVertexList(string Tag = null)
			:base(Tag)
		{
			Vertices = new List<XYZFloat>();
		}

		public NavMeshVertexList(List<XYZFloat> Vertices)
		{
			this.Vertices = Vertices;
		}

		public NavMeshVertexList(NavMeshVertexList copyObject)
		{
			if (copyObject.Vertices != null)
				foreach(var temp in copyObject.Vertices)
					Vertices.Add((XYZFloat)temp.Clone());
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					for (int i = 0; i < size/52; i++)
					{
						var temp = new XYZFloat();
						temp.ReadBinary(subReader);
						Vertices.Add(temp);
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
			foreach (var temp in Vertices)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Vertices", true, out subEle);
			foreach (var temp in Vertices)
			{
				XElement e = new XElement("Vertex");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Vertices", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new XYZFloat();
					temp.ReadXML(e, master);
					Vertices.Add(temp);
				}
		}

		public override object Clone()
		{
			return new NavMeshVertexList(this);
		}

        public bool Equals(NavMeshVertexList other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Vertices.SequenceEqual(other.Vertices);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            NavMeshVertexList other = obj as NavMeshVertexList;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Vertices.GetHashCode();
        }

        public static bool operator ==(NavMeshVertexList objA, NavMeshVertexList objB)
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

        public static bool operator !=(NavMeshVertexList objA, NavMeshVertexList objB)
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