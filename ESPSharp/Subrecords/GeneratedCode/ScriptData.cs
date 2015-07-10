
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
	public partial class ScriptData : Subrecord, ICloneable<ScriptData>, IComparable<ScriptData>, IEquatable<ScriptData>  
	{
		public Byte[] Unused { get; set; }
		public UInt32 ReferenceCount { get; set; }
		public UInt32 CompiledSize { get; set; }
		public UInt32 VariableCount { get; set; }
		public ScriptType Type { get; set; }
		public ScriptFlags Flags { get; set; }

		public ScriptData()
		{
			Unused = new byte[4];
			ReferenceCount = new UInt32();
			CompiledSize = new UInt32();
			VariableCount = new UInt32();
			Type = new ScriptType();
			Flags = new ScriptFlags();
		}

		public ScriptData(Byte[] Unused, UInt32 ReferenceCount, UInt32 CompiledSize, UInt32 VariableCount, ScriptType Type, ScriptFlags Flags)
		{
			this.Unused = Unused;
			this.ReferenceCount = ReferenceCount;
			this.CompiledSize = CompiledSize;
			this.VariableCount = VariableCount;
			this.Type = Type;
			this.Flags = Flags;
		}

		public ScriptData(ScriptData copyObject)
		{
			Unused = (Byte[])copyObject.Unused.Clone();
			ReferenceCount = copyObject.ReferenceCount;
			CompiledSize = copyObject.CompiledSize;
			VariableCount = copyObject.VariableCount;
			Type = copyObject.Type;
			Flags = copyObject.Flags;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Unused = subReader.ReadBytes(4);
					ReferenceCount = subReader.ReadUInt32();
					CompiledSize = subReader.ReadUInt32();
					VariableCount = subReader.ReadUInt32();
					Type = subReader.ReadEnum<ScriptType>();
					Flags = subReader.ReadEnum<ScriptFlags>();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			if (Unused == null)
				writer.Write(new byte[4]);
			else
			writer.Write(Unused);
			writer.Write(ReferenceCount);
			writer.Write(CompiledSize);
			writer.Write(VariableCount);
			writer.Write((UInt16)Type);
			writer.Write((UInt16)Flags);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			WriteUnusedXML(ele, master);

			ele.TryPathTo("ReferenceCount", true, out subEle);
			subEle.Value = ReferenceCount.ToString();

			ele.TryPathTo("CompiledSize", true, out subEle);
			subEle.Value = CompiledSize.ToString();

			ele.TryPathTo("VariableCount", true, out subEle);
			subEle.Value = VariableCount.ToString();

			ele.TryPathTo("Type", true, out subEle);
			subEle.Value = Type.ToString();

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("ReferenceCount", false, out subEle))
				ReferenceCount = subEle.ToUInt32();

			if (ele.TryPathTo("CompiledSize", false, out subEle))
				CompiledSize = subEle.ToUInt32();

			if (ele.TryPathTo("VariableCount", false, out subEle))
				VariableCount = subEle.ToUInt32();

			if (ele.TryPathTo("Type", false, out subEle))
				Type = subEle.ToEnum<ScriptType>();

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<ScriptFlags>();
		}

		public ScriptData Clone()
		{
			return new ScriptData(this);
		}

        public int CompareTo(ScriptData other)
        {
			return CompiledSize.CompareTo(other.CompiledSize);
        }

        public static bool operator >(ScriptData objA, ScriptData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ScriptData objA, ScriptData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ScriptData objA, ScriptData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ScriptData objA, ScriptData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(ScriptData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Unused.SequenceEqual(other.Unused) &&
				ReferenceCount == other.ReferenceCount &&
				CompiledSize == other.CompiledSize &&
				VariableCount == other.VariableCount &&
				Type == other.Type &&
				Flags == other.Flags;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ScriptData other = obj as ScriptData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return CompiledSize.GetHashCode();
        }

        public static bool operator ==(ScriptData objA, ScriptData objB)
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

        public static bool operator !=(ScriptData objA, ScriptData objB)
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

		partial void ReadUnusedXML(XElement ele, ElderScrollsPlugin master);

		partial void WriteUnusedXML(XElement ele, ElderScrollsPlugin master);
	}
}