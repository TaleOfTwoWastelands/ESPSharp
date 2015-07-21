﻿using System;
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
	public partial class NavMeshTriangleList : Subrecord, ICloneable, IEquatable<NavMeshTriangleList>  
	{
		public List<NavMeshTriangle> Triangles { get; set; }

		public NavMeshTriangleList(string Tag = null)
			:base(Tag)
		{
			Triangles = new List<NavMeshTriangle>();
		}

		public NavMeshTriangleList(List<NavMeshTriangle> Triangles)
		{
			this.Triangles = Triangles;
		}

		public NavMeshTriangleList(NavMeshTriangleList copyObject)
		{
			if (copyObject.Triangles != null)
				foreach(var temp in copyObject.Triangles)
					Triangles.Add((NavMeshTriangle)temp.Clone());
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					for (int i = 0; i < size/16; i++)
					{
						var temp = new NavMeshTriangle();
						temp.ReadBinary(subReader);
						Triangles.Add(temp);
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
			foreach (var temp in Triangles)
			{
				temp.WriteBinary(writer);
			}
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Triangles", true, out subEle);
			foreach (var temp in Triangles)
			{
				XElement e = new XElement("Triangle");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Triangles", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new NavMeshTriangle();
					temp.ReadXML(e, master);
					Triangles.Add(temp);
				}
		}

		public override object Clone()
		{
			return new NavMeshTriangleList(this);
		}

        public bool Equals(NavMeshTriangleList other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Triangles.SequenceEqual(other.Triangles);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            NavMeshTriangleList other = obj as NavMeshTriangleList;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Triangles.GetHashCode();
        }

        public static bool operator ==(NavMeshTriangleList objA, NavMeshTriangleList objB)
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

        public static bool operator !=(NavMeshTriangleList objA, NavMeshTriangleList objB)
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