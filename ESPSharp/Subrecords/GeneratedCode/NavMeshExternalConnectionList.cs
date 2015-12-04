















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
	public partial class NavMeshExternalConnectionList : Subrecord, ICloneable, IEquatable<NavMeshExternalConnectionList>, IReferenceContainer  
	{
		public List<NavMeshExternalConnection> ExternalConnections { get; set; }


		public NavMeshExternalConnectionList(string Tag = null)
			:base(Tag)
		{
			ExternalConnections = new List<NavMeshExternalConnection>();

		}

		public NavMeshExternalConnectionList(List<NavMeshExternalConnection> ExternalConnections)
		{
			this.ExternalConnections = ExternalConnections;

		}

		public NavMeshExternalConnectionList(NavMeshExternalConnectionList copyObject)
		{
			if (copyObject.ExternalConnections != null)
				foreach(var temp in copyObject.ExternalConnections)
					ExternalConnections.Add((NavMeshExternalConnection)temp.Clone());

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					for (int i = 0; i < size/10; i++)
					{
						var temp = new NavMeshExternalConnection();
						temp.ReadBinary(subReader);
						ExternalConnections.Add(temp);
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
			foreach (var temp in ExternalConnections)
			{
				temp.WriteBinary(writer);
			}

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("ExternalConnections", true, out subEle);
			foreach (var temp in ExternalConnections)
			{
				XElement e = new XElement("ExternalConnection");
				temp.WriteXML(e, master);
				subEle.Add(e);
			}

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("ExternalConnections", false, out subEle))
				foreach (XElement e in subEle.Elements())
				{
					var temp = new NavMeshExternalConnection();
					temp.ReadXML(e, master);
					ExternalConnections.Add(temp);
				}

		}

		public override object Clone()
		{
			return new NavMeshExternalConnectionList(this);
		}



        public bool Equals(NavMeshExternalConnectionList other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return ExternalConnections.SequenceEqual(other.ExternalConnections);
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            NavMeshExternalConnectionList other = obj as NavMeshExternalConnectionList;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return ExternalConnections.GetHashCode();
        }

        public static bool operator ==(NavMeshExternalConnectionList objA, NavMeshExternalConnectionList objB)
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

        public static bool operator !=(NavMeshExternalConnectionList objA, NavMeshExternalConnectionList objB)
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