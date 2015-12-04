
















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
	public partial class RaceDefaultVoices : Subrecord, ICloneable, IComparable<RaceDefaultVoices>, IEquatable<RaceDefaultVoices>  
	{
		public FormID MaleVoice { get; set; }
		public FormID FemaleVoice { get; set; }


		public RaceDefaultVoices(string Tag = null)
			:base(Tag)
		{
			MaleVoice = new FormID();
			FemaleVoice = new FormID();

		}

		public RaceDefaultVoices(FormID MaleVoice, FormID FemaleVoice)
		{
			this.MaleVoice = MaleVoice;
			this.FemaleVoice = FemaleVoice;

		}

		public RaceDefaultVoices(RaceDefaultVoices copyObject)
		{
			if (copyObject.MaleVoice != null)
				MaleVoice = (FormID)copyObject.MaleVoice.Clone();
			if (copyObject.FemaleVoice != null)
				FemaleVoice = (FormID)copyObject.FemaleVoice.Clone();

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					MaleVoice.ReadBinary(subReader);
					FemaleVoice.ReadBinary(subReader);

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			MaleVoice.WriteBinary(writer);
			FemaleVoice.WriteBinary(writer);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Male", true, out subEle);
			MaleVoice.WriteXML(subEle, master);

			ele.TryPathTo("Female", true, out subEle);
			FemaleVoice.WriteXML(subEle, master);

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Male", false, out subEle))
				MaleVoice.ReadXML(subEle, master);

			if (ele.TryPathTo("Female", false, out subEle))
				FemaleVoice.ReadXML(subEle, master);

		}

		public override object Clone()
		{
			return new RaceDefaultVoices(this);
		}


        public int CompareTo(RaceDefaultVoices other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(RaceDefaultVoices objA, RaceDefaultVoices objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RaceDefaultVoices objA, RaceDefaultVoices objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RaceDefaultVoices objA, RaceDefaultVoices objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RaceDefaultVoices objA, RaceDefaultVoices objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(RaceDefaultVoices other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return MaleVoice == other.MaleVoice &&
				FemaleVoice == other.FemaleVoice;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RaceDefaultVoices other = obj as RaceDefaultVoices;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return MaleVoice.GetHashCode();
        }

        public static bool operator ==(RaceDefaultVoices objA, RaceDefaultVoices objB)
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

        public static bool operator !=(RaceDefaultVoices objA, RaceDefaultVoices objB)
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