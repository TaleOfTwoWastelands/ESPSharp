
















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
	public partial class NavigationDoorLink : Subrecord, ICloneable, IComparable<NavigationDoorLink>, IEquatable<NavigationDoorLink>  
	{
		public FormID NavigationMesh { get; set; }
		public UInt32 Unknown { get; set; }


		public NavigationDoorLink(string Tag = null)
			:base(Tag)
		{
			NavigationMesh = new FormID();
			Unknown = new UInt32();

		}

		public NavigationDoorLink(FormID NavigationMesh, UInt32 Unknown)
		{
			this.NavigationMesh = NavigationMesh;
			this.Unknown = Unknown;

		}

		public NavigationDoorLink(NavigationDoorLink copyObject)
		{
			if (copyObject.NavigationMesh != null)
				NavigationMesh = (FormID)copyObject.NavigationMesh.Clone();
			Unknown = copyObject.Unknown;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					NavigationMesh.ReadBinary(subReader);
					Unknown = subReader.ReadUInt32();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			NavigationMesh.WriteBinary(writer);
			writer.Write(Unknown);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("NavigationMesh", true, out subEle);
			NavigationMesh.WriteXML(subEle, master);

			ele.TryPathTo("Unknown", true, out subEle);
			subEle.Value = Unknown.ToString();

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("NavigationMesh", false, out subEle))
				NavigationMesh.ReadXML(subEle, master);

			if (ele.TryPathTo("Unknown", false, out subEle))
				Unknown = subEle.ToUInt32();

		}

		public override object Clone()
		{
			return new NavigationDoorLink(this);
		}


        public int CompareTo(NavigationDoorLink other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(NavigationDoorLink objA, NavigationDoorLink objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(NavigationDoorLink objA, NavigationDoorLink objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(NavigationDoorLink objA, NavigationDoorLink objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(NavigationDoorLink objA, NavigationDoorLink objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(NavigationDoorLink other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return NavigationMesh == other.NavigationMesh &&
				Unknown == other.Unknown;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            NavigationDoorLink other = obj as NavigationDoorLink;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return NavigationMesh.GetHashCode();
        }

        public static bool operator ==(NavigationDoorLink objA, NavigationDoorLink objB)
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

        public static bool operator !=(NavigationDoorLink objA, NavigationDoorLink objB)
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