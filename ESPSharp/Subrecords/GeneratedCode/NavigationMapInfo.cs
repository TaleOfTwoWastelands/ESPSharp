
















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
	public partial class NavigationMapInfo : Subrecord, ICloneable, IComparable<NavigationMapInfo>, IEquatable<NavigationMapInfo>  
	{
		public Byte[] Unknown1 { get; set; }
		public FormID NavigationMesh { get; set; }
		public FormID Location { get; set; }
		public Int16 GridX { get; set; }
		public Int16 GridY { get; set; }
		public Byte[] Unknown2 { get; set; }


		public NavigationMapInfo(string Tag = null)
			:base(Tag)
		{
			Unknown1 = new byte[4];
			NavigationMesh = new FormID();
			Location = new FormID();
			GridX = new Int16();
			GridY = new Int16();
			Unknown2 = new byte[4];

		}

		public NavigationMapInfo(Byte[] Unknown1, FormID NavigationMesh, FormID Location, Int16 GridX, Int16 GridY, Byte[] Unknown2)
		{
			this.Unknown1 = Unknown1;
			this.NavigationMesh = NavigationMesh;
			this.Location = Location;
			this.GridX = GridX;
			this.GridY = GridY;
			this.Unknown2 = Unknown2;

		}

		public NavigationMapInfo(NavigationMapInfo copyObject)
		{
			if (copyObject.Unknown1 != null)
				Unknown1 = (Byte[])copyObject.Unknown1.Clone();
			if (copyObject.NavigationMesh != null)
				NavigationMesh = (FormID)copyObject.NavigationMesh.Clone();
			if (copyObject.Location != null)
				Location = (FormID)copyObject.Location.Clone();
			GridX = copyObject.GridX;
			GridY = copyObject.GridY;
			if (copyObject.Unknown2 != null)
				Unknown2 = (Byte[])copyObject.Unknown2.Clone();

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Unknown1 = subReader.ReadBytes(4);
					NavigationMesh.ReadBinary(subReader);
					Location.ReadBinary(subReader);
					GridX = subReader.ReadInt16();
					GridY = subReader.ReadInt16();
					ReadUnknown2Binary(subReader);

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			if (Unknown1 == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unknown1);
			NavigationMesh.WriteBinary(writer);
			Location.WriteBinary(writer);
			writer.Write(GridX);
			writer.Write(GridY);
			if (Unknown2 == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unknown2);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Unknown1", true, out subEle);
			subEle.Value = Unknown1.ToHex();

			ele.TryPathTo("NavigationMesh", true, out subEle);
			NavigationMesh.WriteXML(subEle, master);

			ele.TryPathTo("Location", true, out subEle);
			Location.WriteXML(subEle, master);

			ele.TryPathTo("Grid/X", true, out subEle);
			subEle.Value = GridX.ToString();

			ele.TryPathTo("Grid/Y", true, out subEle);
			subEle.Value = GridY.ToString();

			ele.TryPathTo("Unknown2", true, out subEle);
			subEle.Value = Unknown2.ToHex();

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Unknown1", false, out subEle))
				Unknown1 = subEle.ToBytes();

			if (ele.TryPathTo("NavigationMesh", false, out subEle))
				NavigationMesh.ReadXML(subEle, master);

			if (ele.TryPathTo("Location", false, out subEle))
				Location.ReadXML(subEle, master);

			if (ele.TryPathTo("Grid/X", false, out subEle))
				GridX = subEle.ToInt16();

			if (ele.TryPathTo("Grid/Y", false, out subEle))
				GridY = subEle.ToInt16();

			if (ele.TryPathTo("Unknown2", false, out subEle))
				Unknown2 = subEle.ToBytes();

		}

		public override object Clone()
		{
			return new NavigationMapInfo(this);
		}


        public int CompareTo(NavigationMapInfo other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(NavigationMapInfo objA, NavigationMapInfo objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(NavigationMapInfo objA, NavigationMapInfo objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(NavigationMapInfo objA, NavigationMapInfo objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(NavigationMapInfo objA, NavigationMapInfo objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(NavigationMapInfo other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Unknown1.SequenceEqual(other.Unknown1) &&
				NavigationMesh == other.NavigationMesh &&
				Location == other.Location &&
				GridX == other.GridX &&
				GridY == other.GridY &&
				Unknown2.SequenceEqual(other.Unknown2);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            NavigationMapInfo other = obj as NavigationMapInfo;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return NavigationMesh.GetHashCode();
        }

        public static bool operator ==(NavigationMapInfo objA, NavigationMapInfo objB)
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

        public static bool operator !=(NavigationMapInfo objA, NavigationMapInfo objB)
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



		partial void ReadUnknown2Binary(ESPReader reader);




	}
}