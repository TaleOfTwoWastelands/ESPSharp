
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
	public partial class Condition : Subrecord, ICloneable, IComparable<Condition>, IEquatable<Condition>  
	{
		public Comparison Comparison { get; set; }
		public Function Function { get; set; }
		public FunctionTarget RunOn { get; set; }
		public FormID RunOnReference { get; set; }

		public Condition(string Tag = null)
			:base(Tag)
		{
			Comparison = new Comparison();
			Function = new Function();
			RunOn = new FunctionTarget();
			RunOnReference = new FormID();
		}

		public Condition(Comparison Comparison, Function Function, FunctionTarget RunOn, FormID RunOnReference)
		{
			this.Comparison = Comparison;
			this.Function = Function;
			this.RunOn = RunOn;
			this.RunOnReference = RunOnReference;
		}

		public Condition(Condition copyObject)
		{
			if (copyObject.Comparison != null)
				Comparison = (Comparison)copyObject.Comparison.Clone();
			if (copyObject.Function != null)
				Function = (Function)copyObject.Function.Clone();
			RunOn = copyObject.RunOn;
			if (copyObject.RunOnReference != null)
				RunOnReference = (FormID)copyObject.RunOnReference.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Comparison.ReadBinary(subReader);
					Function.ReadBinary(subReader);
					RunOn = subReader.ReadEnum<FunctionTarget>();
					RunOnReference.ReadBinary(subReader);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			Comparison.WriteBinary(writer);
			Function.WriteBinary(writer);
			writer.Write((UInt32)RunOn);
			RunOnReference.WriteBinary(writer);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Comparison", true, out subEle);
			Comparison.WriteXML(subEle, master);

			ele.TryPathTo("Function", true, out subEle);
			Function.WriteXML(subEle, master);

			ele.TryPathTo("RunOn", true, out subEle);
			subEle.Value = RunOn.ToString();

			ele.TryPathTo("RunOnReference", true, out subEle);
			RunOnReference.WriteXML(subEle, master);
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Comparison", false, out subEle))
				Comparison.ReadXML(subEle, master);

			if (ele.TryPathTo("Function", false, out subEle))
				Function.ReadXML(subEle, master);

			if (ele.TryPathTo("RunOn", false, out subEle))
				RunOn = subEle.ToEnum<FunctionTarget>();

			if (ele.TryPathTo("RunOnReference", false, out subEle))
				RunOnReference.ReadXML(subEle, master);
		}

		public override object Clone()
		{
			return new Condition(this);
		}

        public int CompareTo(Condition other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(Condition objA, Condition objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(Condition objA, Condition objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(Condition objA, Condition objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(Condition objA, Condition objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(Condition other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Comparison == other.Comparison &&
				Function == other.Function &&
				RunOn == other.RunOn &&
				RunOnReference == other.RunOnReference;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            Condition other = obj as Condition;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Function.GetHashCode();
        }

        public static bool operator ==(Condition objA, Condition objB)
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

        public static bool operator !=(Condition objA, Condition objB)
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