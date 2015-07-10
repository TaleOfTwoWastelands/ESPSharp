
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
	public partial class LightingTemplateData : Subrecord, ICloneable<LightingTemplateData>, IComparable<LightingTemplateData>, IEquatable<LightingTemplateData>  
	{
		public Color ColorAmbient { get; set; }
		public Color ColorDirectional { get; set; }
		public Color FogColor { get; set; }
		public Single FogNear { get; set; }
		public Single FogFar { get; set; }
		public Int32 DirectionalRotationXY { get; set; }
		public Int32 DirectionalRotationZ { get; set; }
		public Single DirectionalFade { get; set; }
		public Single FogClipDistance { get; set; }
		public Single FogPower { get; set; }

		public LightingTemplateData()
		{
			ColorAmbient = new Color();
			ColorDirectional = new Color();
			FogColor = new Color();
			FogNear = new Single();
			FogFar = new Single();
			DirectionalRotationXY = new Int32();
			DirectionalRotationZ = new Int32();
			DirectionalFade = new Single();
			FogClipDistance = new Single();
			FogPower = new Single();
		}

		public LightingTemplateData(Color ColorAmbient, Color ColorDirectional, Color FogColor, Single FogNear, Single FogFar, Int32 DirectionalRotationXY, Int32 DirectionalRotationZ, Single DirectionalFade, Single FogClipDistance, Single FogPower)
		{
			this.ColorAmbient = ColorAmbient;
			this.ColorDirectional = ColorDirectional;
			this.FogColor = FogColor;
			this.FogNear = FogNear;
			this.FogFar = FogFar;
			this.DirectionalRotationXY = DirectionalRotationXY;
			this.DirectionalRotationZ = DirectionalRotationZ;
			this.DirectionalFade = DirectionalFade;
			this.FogClipDistance = FogClipDistance;
			this.FogPower = FogPower;
		}

		public LightingTemplateData(LightingTemplateData copyObject)
		{
			ColorAmbient = copyObject.ColorAmbient.Clone();
			ColorDirectional = copyObject.ColorDirectional.Clone();
			FogColor = copyObject.FogColor.Clone();
			FogNear = copyObject.FogNear;
			FogFar = copyObject.FogFar;
			DirectionalRotationXY = copyObject.DirectionalRotationXY;
			DirectionalRotationZ = copyObject.DirectionalRotationZ;
			DirectionalFade = copyObject.DirectionalFade;
			FogClipDistance = copyObject.FogClipDistance;
			FogPower = copyObject.FogPower;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					ColorAmbient.ReadBinary(subReader);
					ColorDirectional.ReadBinary(subReader);
					FogColor.ReadBinary(subReader);
					FogNear = subReader.ReadSingle();
					FogFar = subReader.ReadSingle();
					DirectionalRotationXY = subReader.ReadInt32();
					DirectionalRotationZ = subReader.ReadInt32();
					DirectionalFade = subReader.ReadSingle();
					FogClipDistance = subReader.ReadSingle();
					FogPower = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			ColorAmbient.WriteBinary(writer);
			ColorDirectional.WriteBinary(writer);
			FogColor.WriteBinary(writer);
			writer.Write(FogNear);
			writer.Write(FogFar);
			writer.Write(DirectionalRotationXY);
			writer.Write(DirectionalRotationZ);
			writer.Write(DirectionalFade);
			writer.Write(FogClipDistance);
			writer.Write(FogPower);
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Color/Ambient", true, out subEle);
			ColorAmbient.WriteXML(subEle, master);

			ele.TryPathTo("Color/Directional", true, out subEle);
			ColorDirectional.WriteXML(subEle, master);

			ele.TryPathTo("Fog/Color", true, out subEle);
			FogColor.WriteXML(subEle, master);

			ele.TryPathTo("Fog/Near", true, out subEle);
			subEle.Value = FogNear.ToString("G15");

			ele.TryPathTo("Fog/Far", true, out subEle);
			subEle.Value = FogFar.ToString("G15");

			ele.TryPathTo("DirectionalRotation/XY", true, out subEle);
			subEle.Value = DirectionalRotationXY.ToString();

			ele.TryPathTo("DirectionalRotation/Z", true, out subEle);
			subEle.Value = DirectionalRotationZ.ToString();

			ele.TryPathTo("DirectionalFade", true, out subEle);
			subEle.Value = DirectionalFade.ToString("G15");

			ele.TryPathTo("Fog/ClipDistance", true, out subEle);
			subEle.Value = FogClipDistance.ToString("G15");

			ele.TryPathTo("Fog/Power", true, out subEle);
			subEle.Value = FogPower.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Color/Ambient", false, out subEle))
				ColorAmbient.ReadXML(subEle, master);

			if (ele.TryPathTo("Color/Directional", false, out subEle))
				ColorDirectional.ReadXML(subEle, master);

			if (ele.TryPathTo("Fog/Color", false, out subEle))
				FogColor.ReadXML(subEle, master);

			if (ele.TryPathTo("Fog/Near", false, out subEle))
				FogNear = subEle.ToSingle();

			if (ele.TryPathTo("Fog/Far", false, out subEle))
				FogFar = subEle.ToSingle();

			if (ele.TryPathTo("DirectionalRotation/XY", false, out subEle))
				DirectionalRotationXY = subEle.ToInt32();

			if (ele.TryPathTo("DirectionalRotation/Z", false, out subEle))
				DirectionalRotationZ = subEle.ToInt32();

			if (ele.TryPathTo("DirectionalFade", false, out subEle))
				DirectionalFade = subEle.ToSingle();

			if (ele.TryPathTo("Fog/ClipDistance", false, out subEle))
				FogClipDistance = subEle.ToSingle();

			if (ele.TryPathTo("Fog/Power", false, out subEle))
				FogPower = subEle.ToSingle();
		}

		public LightingTemplateData Clone()
		{
			return new LightingTemplateData(this);
		}

        public int CompareTo(LightingTemplateData other)
        {
			return ColorAmbient.CompareTo(other.ColorAmbient);
        }

        public static bool operator >(LightingTemplateData objA, LightingTemplateData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(LightingTemplateData objA, LightingTemplateData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(LightingTemplateData objA, LightingTemplateData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(LightingTemplateData objA, LightingTemplateData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(LightingTemplateData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return ColorAmbient == other.ColorAmbient &&
				ColorDirectional == other.ColorDirectional &&
				FogColor == other.FogColor &&
				FogNear == other.FogNear &&
				FogFar == other.FogFar &&
				DirectionalRotationXY == other.DirectionalRotationXY &&
				DirectionalRotationZ == other.DirectionalRotationZ &&
				DirectionalFade == other.DirectionalFade &&
				FogClipDistance == other.FogClipDistance &&
				FogPower == other.FogPower;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            LightingTemplateData other = obj as LightingTemplateData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return ColorAmbient.GetHashCode();
        }

        public static bool operator ==(LightingTemplateData objA, LightingTemplateData objB)
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

        public static bool operator !=(LightingTemplateData objA, LightingTemplateData objB)
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