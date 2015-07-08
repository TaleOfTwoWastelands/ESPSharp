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
	public partial class PackageUseWeaponData : Subrecord, ICloneable<PackageUseWeaponData>
	{
		public PackageUseWeaponFlags Flags { get; set; }
		public PackageUseWeaponFireRate FireRate { get; set; }
		public PackageUseWeaponFireCount FireCount { get; set; }
		public UInt16 NumberOfBursts { get; set; }
		public UInt16 ShotsPerVolleyMin { get; set; }
		public UInt16 ShotsPerVolleyMax { get; set; }
		public Single PauseBetweenVolleysMin { get; set; }
		public Single PauseBetweenVolleysMax { get; set; }
		public Byte[] Unused { get; set; }

		public PackageUseWeaponData()
		{
			Flags = new PackageUseWeaponFlags();
			FireRate = new PackageUseWeaponFireRate();
			FireCount = new PackageUseWeaponFireCount();
			NumberOfBursts = new UInt16();
			ShotsPerVolleyMin = new UInt16();
			ShotsPerVolleyMax = new UInt16();
			PauseBetweenVolleysMin = new Single();
			PauseBetweenVolleysMax = new Single();
			Unused = new byte[4];
		}

		public PackageUseWeaponData(PackageUseWeaponFlags Flags, PackageUseWeaponFireRate FireRate, PackageUseWeaponFireCount FireCount, UInt16 NumberOfBursts, UInt16 ShotsPerVolleyMin, UInt16 ShotsPerVolleyMax, Single PauseBetweenVolleysMin, Single PauseBetweenVolleysMax, Byte[] Unused)
		{
			this.Flags = Flags;
			this.FireRate = FireRate;
			this.FireCount = FireCount;
			this.NumberOfBursts = NumberOfBursts;
			this.ShotsPerVolleyMin = ShotsPerVolleyMin;
			this.ShotsPerVolleyMax = ShotsPerVolleyMax;
			this.PauseBetweenVolleysMin = PauseBetweenVolleysMin;
			this.PauseBetweenVolleysMax = PauseBetweenVolleysMax;
			this.Unused = Unused;
		}

		public PackageUseWeaponData(PackageUseWeaponData copyObject)
		{
			Flags = copyObject.Flags;
			FireRate = copyObject.FireRate;
			FireCount = copyObject.FireCount;
			NumberOfBursts = copyObject.NumberOfBursts;
			ShotsPerVolleyMin = copyObject.ShotsPerVolleyMin;
			ShotsPerVolleyMax = copyObject.ShotsPerVolleyMax;
			PauseBetweenVolleysMin = copyObject.PauseBetweenVolleysMin;
			PauseBetweenVolleysMax = copyObject.PauseBetweenVolleysMax;
			Unused = (Byte[])copyObject.Unused.Clone();
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					Flags = subReader.ReadEnum<PackageUseWeaponFlags>();
					FireRate = subReader.ReadEnum<PackageUseWeaponFireRate>();
					FireCount = subReader.ReadEnum<PackageUseWeaponFireCount>();
					NumberOfBursts = subReader.ReadUInt16();
					ShotsPerVolleyMin = subReader.ReadUInt16();
					ShotsPerVolleyMax = subReader.ReadUInt16();
					PauseBetweenVolleysMin = subReader.ReadSingle();
					PauseBetweenVolleysMax = subReader.ReadSingle();
					Unused = subReader.ReadBytes(4);
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write((UInt32)Flags);
			writer.Write((Byte)FireRate);
			writer.Write((Byte)FireCount);
			writer.Write(NumberOfBursts);			
			writer.Write(ShotsPerVolleyMin);			
			writer.Write(ShotsPerVolleyMax);			
			writer.Write(PauseBetweenVolleysMin);			
			writer.Write(PauseBetweenVolleysMax);			
			if (Unused == null)
				writer.Write(new byte[4]);
			else
				writer.Write(Unused);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("FireRate", true, out subEle);
			subEle.Value = FireRate.ToString();

			ele.TryPathTo("FireCount", true, out subEle);
			subEle.Value = FireCount.ToString();

			ele.TryPathTo("NumberOfBursts", true, out subEle);
			subEle.Value = NumberOfBursts.ToString();

			ele.TryPathTo("ShotsPerVolley/Min", true, out subEle);
			subEle.Value = ShotsPerVolleyMin.ToString();

			ele.TryPathTo("ShotsPerVolley/Max", true, out subEle);
			subEle.Value = ShotsPerVolleyMax.ToString();

			ele.TryPathTo("PauseBetweenVolleys/Min", true, out subEle);
			subEle.Value = PauseBetweenVolleysMin.ToString("G15");

			ele.TryPathTo("PauseBetweenVolleys/Max", true, out subEle);
			subEle.Value = PauseBetweenVolleysMax.ToString("G15");

			ele.TryPathTo("Unused", true, out subEle);
			subEle.Value = Unused.ToHex();
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<PackageUseWeaponFlags>();
			}

			if (ele.TryPathTo("FireRate", false, out subEle))
			{
				FireRate = subEle.ToEnum<PackageUseWeaponFireRate>();
			}

			if (ele.TryPathTo("FireCount", false, out subEle))
			{
				FireCount = subEle.ToEnum<PackageUseWeaponFireCount>();
			}

			if (ele.TryPathTo("NumberOfBursts", false, out subEle))
			{
				NumberOfBursts = subEle.ToUInt16();
			}

			if (ele.TryPathTo("ShotsPerVolley/Min", false, out subEle))
			{
				ShotsPerVolleyMin = subEle.ToUInt16();
			}

			if (ele.TryPathTo("ShotsPerVolley/Max", false, out subEle))
			{
				ShotsPerVolleyMax = subEle.ToUInt16();
			}

			if (ele.TryPathTo("PauseBetweenVolleys/Min", false, out subEle))
			{
				PauseBetweenVolleysMin = subEle.ToSingle();
			}

			if (ele.TryPathTo("PauseBetweenVolleys/Max", false, out subEle))
			{
				PauseBetweenVolleysMax = subEle.ToSingle();
			}

			if (ele.TryPathTo("Unused", false, out subEle))
			{
				Unused = subEle.ToBytes();
			}
		}

		public PackageUseWeaponData Clone()
		{
			return new PackageUseWeaponData(this);
		}

	}
}
