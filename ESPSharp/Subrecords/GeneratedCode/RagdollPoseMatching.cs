
















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
	public partial class RagdollPoseMatching : Subrecord, ICloneable, IComparable<RagdollPoseMatching>, IEquatable<RagdollPoseMatching>  
	{
		public UInt16 MatchBone1 { get; set; }
		public UInt16 MatchBone2 { get; set; }
		public UInt16 MatchBone3 { get; set; }
		public NoYesByte DisableOnMove { get; set; }
		public Byte Unused { get; set; }
		public Single MotorsStrength { get; set; }
		public Single PoseActivationDelayTime { get; set; }
		public Single MatchErrorAllowance { get; set; }
		public Single DisplacementToDisable { get; set; }


		public RagdollPoseMatching(string Tag = null)
			:base(Tag)
		{
			MatchBone1 = new UInt16();
			MatchBone2 = new UInt16();
			MatchBone3 = new UInt16();
			DisableOnMove = new NoYesByte();
			Unused = new Byte();
			MotorsStrength = new Single();
			PoseActivationDelayTime = new Single();
			MatchErrorAllowance = new Single();
			DisplacementToDisable = new Single();

		}

		public RagdollPoseMatching(UInt16 MatchBone1, UInt16 MatchBone2, UInt16 MatchBone3, NoYesByte DisableOnMove, Byte Unused, Single MotorsStrength, Single PoseActivationDelayTime, Single MatchErrorAllowance, Single DisplacementToDisable)
		{
			this.MatchBone1 = MatchBone1;
			this.MatchBone2 = MatchBone2;
			this.MatchBone3 = MatchBone3;
			this.DisableOnMove = DisableOnMove;
			this.Unused = Unused;
			this.MotorsStrength = MotorsStrength;
			this.PoseActivationDelayTime = PoseActivationDelayTime;
			this.MatchErrorAllowance = MatchErrorAllowance;
			this.DisplacementToDisable = DisplacementToDisable;

		}

		public RagdollPoseMatching(RagdollPoseMatching copyObject)
		{
			MatchBone1 = copyObject.MatchBone1;
			MatchBone2 = copyObject.MatchBone2;
			MatchBone3 = copyObject.MatchBone3;
			DisableOnMove = copyObject.DisableOnMove;
			Unused = copyObject.Unused;
			MotorsStrength = copyObject.MotorsStrength;
			PoseActivationDelayTime = copyObject.PoseActivationDelayTime;
			MatchErrorAllowance = copyObject.MatchErrorAllowance;
			DisplacementToDisable = copyObject.DisplacementToDisable;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					MatchBone1 = subReader.ReadUInt16();
					MatchBone2 = subReader.ReadUInt16();
					MatchBone3 = subReader.ReadUInt16();
					DisableOnMove = subReader.ReadEnum<NoYesByte>();
					Unused = subReader.ReadByte();
					MotorsStrength = subReader.ReadSingle();
					PoseActivationDelayTime = subReader.ReadSingle();
					MatchErrorAllowance = subReader.ReadSingle();
					DisplacementToDisable = subReader.ReadSingle();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(MatchBone1);
			writer.Write(MatchBone2);
			writer.Write(MatchBone3);
			writer.Write((Byte)DisableOnMove);
			writer.Write(Unused);
			writer.Write(MotorsStrength);
			writer.Write(PoseActivationDelayTime);
			writer.Write(MatchErrorAllowance);
			writer.Write(DisplacementToDisable);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("MatchBone1", true, out subEle);
			subEle.Value = MatchBone1.ToString();

			ele.TryPathTo("MatchBone2", true, out subEle);
			subEle.Value = MatchBone2.ToString();

			ele.TryPathTo("MatchBone3", true, out subEle);
			subEle.Value = MatchBone3.ToString();

			ele.TryPathTo("DisableOnMove", true, out subEle);
			subEle.Value = DisableOnMove.ToString();

			WriteUnusedXML(ele, master);

			ele.TryPathTo("MotorsStrength", true, out subEle);
			subEle.Value = MotorsStrength.ToString("G15");

			ele.TryPathTo("PoseActivationDelayTime", true, out subEle);
			subEle.Value = PoseActivationDelayTime.ToString("G15");

			ele.TryPathTo("MatchErrorAllowance", true, out subEle);
			subEle.Value = MatchErrorAllowance.ToString("G15");

			ele.TryPathTo("DisplacementToDisable", true, out subEle);
			subEle.Value = DisplacementToDisable.ToString("G15");

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("MatchBone1", false, out subEle))
				MatchBone1 = subEle.ToUInt16();

			if (ele.TryPathTo("MatchBone2", false, out subEle))
				MatchBone2 = subEle.ToUInt16();

			if (ele.TryPathTo("MatchBone3", false, out subEle))
				MatchBone3 = subEle.ToUInt16();

			if (ele.TryPathTo("DisableOnMove", false, out subEle))
				DisableOnMove = subEle.ToEnum<NoYesByte>();

			ReadUnusedXML(ele, master);

			if (ele.TryPathTo("MotorsStrength", false, out subEle))
				MotorsStrength = subEle.ToSingle();

			if (ele.TryPathTo("PoseActivationDelayTime", false, out subEle))
				PoseActivationDelayTime = subEle.ToSingle();

			if (ele.TryPathTo("MatchErrorAllowance", false, out subEle))
				MatchErrorAllowance = subEle.ToSingle();

			if (ele.TryPathTo("DisplacementToDisable", false, out subEle))
				DisplacementToDisable = subEle.ToSingle();

		}

		public override object Clone()
		{
			return new RagdollPoseMatching(this);
		}


        public int CompareTo(RagdollPoseMatching other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(RagdollPoseMatching objA, RagdollPoseMatching objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(RagdollPoseMatching objA, RagdollPoseMatching objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(RagdollPoseMatching objA, RagdollPoseMatching objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(RagdollPoseMatching objA, RagdollPoseMatching objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(RagdollPoseMatching other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return MatchBone1 == other.MatchBone1 &&
				MatchBone2 == other.MatchBone2 &&
				MatchBone3 == other.MatchBone3 &&
				DisableOnMove == other.DisableOnMove &&
				Unused == other.Unused &&
				MotorsStrength == other.MotorsStrength &&
				PoseActivationDelayTime == other.PoseActivationDelayTime &&
				MatchErrorAllowance == other.MatchErrorAllowance &&
				DisplacementToDisable == other.DisplacementToDisable;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            RagdollPoseMatching other = obj as RagdollPoseMatching;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return MatchBone1.GetHashCode();
        }

        public static bool operator ==(RagdollPoseMatching objA, RagdollPoseMatching objB)
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

        public static bool operator !=(RagdollPoseMatching objA, RagdollPoseMatching objB)
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