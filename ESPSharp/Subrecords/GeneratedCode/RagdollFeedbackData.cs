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
	public partial class RagdollFeedbackData : Subrecord, ICloneable<RagdollFeedbackData>
	{
		public Single Dynamic_KeyframeBlendAmount { get; set; }
		public Single HierarchyGain { get; set; }
		public Single PositionGain { get; set; }
		public Single VelocityGain { get; set; }
		public Single AccelerationGain { get; set; }
		public Single SnapGain { get; set; }
		public Single VelocityDamping { get; set; }
		public Single SnapMaxLinearVelocity { get; set; }
		public Single SnapMaxAngularVelocity { get; set; }
		public Single SnapMaxLinearDistance { get; set; }
		public Single SnapMaxAngularDistance { get; set; }
		public Single PositionMaxLinearVelocity { get; set; }
		public Single PositionMaxAngularVelocity { get; set; }
		public Single ProjectilePositionMaxVelocity { get; set; }
		public Single MeleePositionMaxVelocity { get; set; }

		public RagdollFeedbackData()
		{
			Dynamic_KeyframeBlendAmount = new Single();
			HierarchyGain = new Single();
			PositionGain = new Single();
			VelocityGain = new Single();
			AccelerationGain = new Single();
			SnapGain = new Single();
			VelocityDamping = new Single();
			SnapMaxLinearVelocity = new Single();
			SnapMaxAngularVelocity = new Single();
			SnapMaxLinearDistance = new Single();
			SnapMaxAngularDistance = new Single();
			PositionMaxLinearVelocity = new Single();
			PositionMaxAngularVelocity = new Single();
			ProjectilePositionMaxVelocity = new Single();
			MeleePositionMaxVelocity = new Single();
		}

		public RagdollFeedbackData(Single Dynamic_KeyframeBlendAmount, Single HierarchyGain, Single PositionGain, Single VelocityGain, Single AccelerationGain, Single SnapGain, Single VelocityDamping, Single SnapMaxLinearVelocity, Single SnapMaxAngularVelocity, Single SnapMaxLinearDistance, Single SnapMaxAngularDistance, Single PositionMaxLinearVelocity, Single PositionMaxAngularVelocity, Single ProjectilePositionMaxVelocity, Single MeleePositionMaxVelocity)
		{
			this.Dynamic_KeyframeBlendAmount = Dynamic_KeyframeBlendAmount;
			this.HierarchyGain = HierarchyGain;
			this.PositionGain = PositionGain;
			this.VelocityGain = VelocityGain;
			this.AccelerationGain = AccelerationGain;
			this.SnapGain = SnapGain;
			this.VelocityDamping = VelocityDamping;
			this.SnapMaxLinearVelocity = SnapMaxLinearVelocity;
			this.SnapMaxAngularVelocity = SnapMaxAngularVelocity;
			this.SnapMaxLinearDistance = SnapMaxLinearDistance;
			this.SnapMaxAngularDistance = SnapMaxAngularDistance;
			this.PositionMaxLinearVelocity = PositionMaxLinearVelocity;
			this.PositionMaxAngularVelocity = PositionMaxAngularVelocity;
			this.ProjectilePositionMaxVelocity = ProjectilePositionMaxVelocity;
			this.MeleePositionMaxVelocity = MeleePositionMaxVelocity;
		}

		public RagdollFeedbackData(RagdollFeedbackData copyObject)
		{
			Dynamic_KeyframeBlendAmount = copyObject.Dynamic_KeyframeBlendAmount;
			HierarchyGain = copyObject.HierarchyGain;
			PositionGain = copyObject.PositionGain;
			VelocityGain = copyObject.VelocityGain;
			AccelerationGain = copyObject.AccelerationGain;
			SnapGain = copyObject.SnapGain;
			VelocityDamping = copyObject.VelocityDamping;
			SnapMaxLinearVelocity = copyObject.SnapMaxLinearVelocity;
			SnapMaxAngularVelocity = copyObject.SnapMaxAngularVelocity;
			SnapMaxLinearDistance = copyObject.SnapMaxLinearDistance;
			SnapMaxAngularDistance = copyObject.SnapMaxAngularDistance;
			PositionMaxLinearVelocity = copyObject.PositionMaxLinearVelocity;
			PositionMaxAngularVelocity = copyObject.PositionMaxAngularVelocity;
			ProjectilePositionMaxVelocity = copyObject.ProjectilePositionMaxVelocity;
			MeleePositionMaxVelocity = copyObject.MeleePositionMaxVelocity;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Dynamic_KeyframeBlendAmount = subReader.ReadSingle();
					HierarchyGain = subReader.ReadSingle();
					PositionGain = subReader.ReadSingle();
					VelocityGain = subReader.ReadSingle();
					AccelerationGain = subReader.ReadSingle();
					SnapGain = subReader.ReadSingle();
					VelocityDamping = subReader.ReadSingle();
					SnapMaxLinearVelocity = subReader.ReadSingle();
					SnapMaxAngularVelocity = subReader.ReadSingle();
					SnapMaxLinearDistance = subReader.ReadSingle();
					SnapMaxAngularDistance = subReader.ReadSingle();
					PositionMaxLinearVelocity = subReader.ReadSingle();
					PositionMaxAngularVelocity = subReader.ReadSingle();
					ProjectilePositionMaxVelocity = subReader.ReadSingle();
					MeleePositionMaxVelocity = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Dynamic_KeyframeBlendAmount);			
			writer.Write(HierarchyGain);			
			writer.Write(PositionGain);			
			writer.Write(VelocityGain);			
			writer.Write(AccelerationGain);			
			writer.Write(SnapGain);			
			writer.Write(VelocityDamping);			
			writer.Write(SnapMaxLinearVelocity);			
			writer.Write(SnapMaxAngularVelocity);			
			writer.Write(SnapMaxLinearDistance);			
			writer.Write(SnapMaxAngularDistance);			
			writer.Write(PositionMaxLinearVelocity);			
			writer.Write(PositionMaxAngularVelocity);			
			writer.Write(ProjectilePositionMaxVelocity);			
			writer.Write(MeleePositionMaxVelocity);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Dynamic_KeyframeBlendAmount", true, out subEle);
			subEle.Value = Dynamic_KeyframeBlendAmount.ToString("G15");

			ele.TryPathTo("HierarchyGain", true, out subEle);
			subEle.Value = HierarchyGain.ToString("G15");

			ele.TryPathTo("PositionGain", true, out subEle);
			subEle.Value = PositionGain.ToString("G15");

			ele.TryPathTo("VelocityGain", true, out subEle);
			subEle.Value = VelocityGain.ToString("G15");

			ele.TryPathTo("AccelerationGain", true, out subEle);
			subEle.Value = AccelerationGain.ToString("G15");

			ele.TryPathTo("SnapGain", true, out subEle);
			subEle.Value = SnapGain.ToString("G15");

			ele.TryPathTo("VelocityDamping", true, out subEle);
			subEle.Value = VelocityDamping.ToString("G15");

			ele.TryPathTo("SnapMax/LinearVelocity", true, out subEle);
			subEle.Value = SnapMaxLinearVelocity.ToString("G15");

			ele.TryPathTo("SnapMax/AngularVelocity", true, out subEle);
			subEle.Value = SnapMaxAngularVelocity.ToString("G15");

			ele.TryPathTo("SnapMax/LinearDistance", true, out subEle);
			subEle.Value = SnapMaxLinearDistance.ToString("G15");

			ele.TryPathTo("SnapMax/AngularDistance", true, out subEle);
			subEle.Value = SnapMaxAngularDistance.ToString("G15");

			ele.TryPathTo("PositionMax/LinearVelocity", true, out subEle);
			subEle.Value = PositionMaxLinearVelocity.ToString("G15");

			ele.TryPathTo("PositionMax/AngularVelocity", true, out subEle);
			subEle.Value = PositionMaxAngularVelocity.ToString("G15");

			ele.TryPathTo("ProjectilePositionMaxVelocity", true, out subEle);
			subEle.Value = ProjectilePositionMaxVelocity.ToString("G15");

			ele.TryPathTo("MeleePositionMaxVelocity", true, out subEle);
			subEle.Value = MeleePositionMaxVelocity.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Dynamic_KeyframeBlendAmount", false, out subEle))
			{
				Dynamic_KeyframeBlendAmount = subEle.ToSingle();
			}

			if (ele.TryPathTo("HierarchyGain", false, out subEle))
			{
				HierarchyGain = subEle.ToSingle();
			}

			if (ele.TryPathTo("PositionGain", false, out subEle))
			{
				PositionGain = subEle.ToSingle();
			}

			if (ele.TryPathTo("VelocityGain", false, out subEle))
			{
				VelocityGain = subEle.ToSingle();
			}

			if (ele.TryPathTo("AccelerationGain", false, out subEle))
			{
				AccelerationGain = subEle.ToSingle();
			}

			if (ele.TryPathTo("SnapGain", false, out subEle))
			{
				SnapGain = subEle.ToSingle();
			}

			if (ele.TryPathTo("VelocityDamping", false, out subEle))
			{
				VelocityDamping = subEle.ToSingle();
			}

			if (ele.TryPathTo("SnapMax/LinearVelocity", false, out subEle))
			{
				SnapMaxLinearVelocity = subEle.ToSingle();
			}

			if (ele.TryPathTo("SnapMax/AngularVelocity", false, out subEle))
			{
				SnapMaxAngularVelocity = subEle.ToSingle();
			}

			if (ele.TryPathTo("SnapMax/LinearDistance", false, out subEle))
			{
				SnapMaxLinearDistance = subEle.ToSingle();
			}

			if (ele.TryPathTo("SnapMax/AngularDistance", false, out subEle))
			{
				SnapMaxAngularDistance = subEle.ToSingle();
			}

			if (ele.TryPathTo("PositionMax/LinearVelocity", false, out subEle))
			{
				PositionMaxLinearVelocity = subEle.ToSingle();
			}

			if (ele.TryPathTo("PositionMax/AngularVelocity", false, out subEle))
			{
				PositionMaxAngularVelocity = subEle.ToSingle();
			}

			if (ele.TryPathTo("ProjectilePositionMaxVelocity", false, out subEle))
			{
				ProjectilePositionMaxVelocity = subEle.ToSingle();
			}

			if (ele.TryPathTo("MeleePositionMaxVelocity", false, out subEle))
			{
				MeleePositionMaxVelocity = subEle.ToSingle();
			}
		}

		public RagdollFeedbackData Clone()
		{
			return new RagdollFeedbackData(this);
		}

	}
}
