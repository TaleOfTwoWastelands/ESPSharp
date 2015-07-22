
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
	public partial class TreeData : Subrecord, ICloneable, IComparable<TreeData>, IEquatable<TreeData>  
	{
		public Single LeafCurvature { get; set; }
		public Single MinLeafAngle { get; set; }
		public Single MaxLeafAngle { get; set; }
		public Single BranchDimmingValue { get; set; }
		public Single LeafDimmingValue { get; set; }
		public Int32 ShadowRadius { get; set; }
		public Single RockSpeed { get; set; }
		public Single RustleSpeed { get; set; }

		public TreeData(string Tag = null)
			:base(Tag)
		{
			LeafCurvature = new Single();
			MinLeafAngle = new Single();
			MaxLeafAngle = new Single();
			BranchDimmingValue = new Single();
			LeafDimmingValue = new Single();
			ShadowRadius = new Int32();
			RockSpeed = new Single();
			RustleSpeed = new Single();
		}

		public TreeData(Single LeafCurvature, Single MinLeafAngle, Single MaxLeafAngle, Single BranchDimmingValue, Single LeafDimmingValue, Int32 ShadowRadius, Single RockSpeed, Single RustleSpeed)
		{
			this.LeafCurvature = LeafCurvature;
			this.MinLeafAngle = MinLeafAngle;
			this.MaxLeafAngle = MaxLeafAngle;
			this.BranchDimmingValue = BranchDimmingValue;
			this.LeafDimmingValue = LeafDimmingValue;
			this.ShadowRadius = ShadowRadius;
			this.RockSpeed = RockSpeed;
			this.RustleSpeed = RustleSpeed;
		}

		public TreeData(TreeData copyObject)
		{
			LeafCurvature = copyObject.LeafCurvature;
			MinLeafAngle = copyObject.MinLeafAngle;
			MaxLeafAngle = copyObject.MaxLeafAngle;
			BranchDimmingValue = copyObject.BranchDimmingValue;
			LeafDimmingValue = copyObject.LeafDimmingValue;
			ShadowRadius = copyObject.ShadowRadius;
			RockSpeed = copyObject.RockSpeed;
			RustleSpeed = copyObject.RustleSpeed;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					LeafCurvature = subReader.ReadSingle();
					MinLeafAngle = subReader.ReadSingle();
					MaxLeafAngle = subReader.ReadSingle();
					BranchDimmingValue = subReader.ReadSingle();
					LeafDimmingValue = subReader.ReadSingle();
					ShadowRadius = subReader.ReadInt32();
					RockSpeed = subReader.ReadSingle();
					RustleSpeed = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(LeafCurvature);
			writer.Write(MinLeafAngle);
			writer.Write(MaxLeafAngle);
			writer.Write(BranchDimmingValue);
			writer.Write(LeafDimmingValue);
			writer.Write(ShadowRadius);
			writer.Write(RockSpeed);
			writer.Write(RustleSpeed);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Leaf/Curvature", true, out subEle);
			subEle.Value = LeafCurvature.ToString("G15");

			ele.TryPathTo("Leaf/Angle/Min", true, out subEle);
			subEle.Value = MinLeafAngle.ToString("G15");

			ele.TryPathTo("Leaf/Angle/Max", true, out subEle);
			subEle.Value = MaxLeafAngle.ToString("G15");

			ele.TryPathTo("BranchDimmingValue", true, out subEle);
			subEle.Value = BranchDimmingValue.ToString("G15");

			ele.TryPathTo("Leaf/DimmingValue", true, out subEle);
			subEle.Value = LeafDimmingValue.ToString("G15");

			ele.TryPathTo("ShadowRadius", true, out subEle);
			subEle.Value = ShadowRadius.ToString();

			ele.TryPathTo("RockSpeed", true, out subEle);
			subEle.Value = RockSpeed.ToString("G15");

			ele.TryPathTo("RustleSpeed", true, out subEle);
			subEle.Value = RustleSpeed.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Leaf/Curvature", false, out subEle))
				LeafCurvature = subEle.ToSingle();

			if (ele.TryPathTo("Leaf/Angle/Min", false, out subEle))
				MinLeafAngle = subEle.ToSingle();

			if (ele.TryPathTo("Leaf/Angle/Max", false, out subEle))
				MaxLeafAngle = subEle.ToSingle();

			if (ele.TryPathTo("BranchDimmingValue", false, out subEle))
				BranchDimmingValue = subEle.ToSingle();

			if (ele.TryPathTo("Leaf/DimmingValue", false, out subEle))
				LeafDimmingValue = subEle.ToSingle();

			if (ele.TryPathTo("ShadowRadius", false, out subEle))
				ShadowRadius = subEle.ToInt32();

			if (ele.TryPathTo("RockSpeed", false, out subEle))
				RockSpeed = subEle.ToSingle();

			if (ele.TryPathTo("RustleSpeed", false, out subEle))
				RustleSpeed = subEle.ToSingle();
		}

		public override object Clone()
		{
			return new TreeData(this);
		}

        public int CompareTo(TreeData other)
        {
			int result = 0;

			return result;
		}

        public static bool operator >(TreeData objA, TreeData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(TreeData objA, TreeData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(TreeData objA, TreeData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(TreeData objA, TreeData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(TreeData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return LeafCurvature == other.LeafCurvature &&
				MinLeafAngle == other.MinLeafAngle &&
				MaxLeafAngle == other.MaxLeafAngle &&
				BranchDimmingValue == other.BranchDimmingValue &&
				LeafDimmingValue == other.LeafDimmingValue &&
				ShadowRadius == other.ShadowRadius &&
				RockSpeed == other.RockSpeed &&
				RustleSpeed == other.RustleSpeed;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            TreeData other = obj as TreeData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return LeafCurvature.GetHashCode();
        }

        public static bool operator ==(TreeData objA, TreeData objB)
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

        public static bool operator !=(TreeData objA, TreeData objB)
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