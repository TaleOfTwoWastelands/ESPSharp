using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESPSharp
{
    public class TextureSet : Record, IEditorID
    {
        public string EditorID { get; set; }
        public ObjectBounds ObjectBounds { get; set; }
        public string BaseImage_Transparency { get; set; }
        public string NormalMap_Specular { get; set; }
        public string EnvironmentMapMask { get; set; }
        public string GlowMap { get; set; }
        public string ParallaxMap { get; set; }
        public string EnvironmentMap { get; set; }
        public DecalData DecalData { get; set; }
        public TXSTFlags Flags { get; set; }


        public override void ReadData(ESPReader reader, long dataEnd)
        {
            while (reader.BaseStream.Position < dataEnd)
            {
                string subTag = reader.PeekTag();

                switch (subTag)
                {
                    case "EDID":
                        EditorID = reader.ReadSimpleSubrecord<string>();
                        break;
                    case "OBND":
                        if (ObjectBounds == null)
                            ObjectBounds = new ObjectBounds();

                        ObjectBounds.ReadBinary(reader);
                        break;
                    case "TX00":
                        BaseImage_Transparency = reader.ReadSimpleSubrecord<string>();
                        break;
                    case "TX01":
                        NormalMap_Specular = reader.ReadSimpleSubrecord<string>();
                        break;
                    case "TX02":
                        EnvironmentMapMask = reader.ReadSimpleSubrecord<string>();
                        break;
                    case "TX03":
                        GlowMap = reader.ReadSimpleSubrecord<string>();
                        break;
                    case "TX04":
                        ParallaxMap = reader.ReadSimpleSubrecord<string>();
                        break;
                    case "TX05":
                        EnvironmentMap = reader.ReadSimpleSubrecord<string>();
                        break;
                    case "DODT":
                        if (DecalData == null)
                            DecalData = new DecalData();

                        DecalData.ReadBinary(reader);
                        break;
                    case "DNAM":
                        Flags = (TXSTFlags)reader.ReadSimpleSubrecord<UInt16>();
                        break;
                    default:
                        throw new Exception();
                }
            }
        }

        public override void WriteData(ESPWriter writer)
        {
            if (EditorID != null)
                writer.WriteSimpleSubrecord<string>(EditorID, "EDID");

            if (ObjectBounds != null)
                ObjectBounds.WriteBinary(writer);

            if (BaseImage_Transparency != null)
                writer.WriteSimpleSubrecord<string>(BaseImage_Transparency, "TX00");

            if (NormalMap_Specular != null)
                writer.WriteSimpleSubrecord<string>(NormalMap_Specular, "TX01");

            if (EnvironmentMapMask != null)
                writer.WriteSimpleSubrecord<string>(EnvironmentMapMask, "TX02");

            if (GlowMap != null)
                writer.WriteSimpleSubrecord<string>(GlowMap, "TX03");

            if (ParallaxMap != null)
                writer.WriteSimpleSubrecord<string>(ParallaxMap, "TX04");

            if (EnvironmentMap != null)
                writer.WriteSimpleSubrecord<string>(EnvironmentMap, "TX05");

            if (DecalData != null)
                DecalData.WriteBinary(writer);

            if (Flags != null)
                writer.WriteSimpleSubrecord<ushort>((ushort)Flags, "DNAM");
        }

        public override void WriteDataXML(XElement ele)
        {
            if (EditorID != null)
                ele.AddSimpleSubrecord("EditorID", "EDID", EditorID);

            if (ObjectBounds != null)
            {
                XElement subEle = new XElement("ObjectBounds");
                ObjectBounds.WriteXML(subEle);
                ele.Add(subEle);
            }

            if (BaseImage_Transparency != null)
                ele.AddSimpleSubrecord("BaseImage_Transparency", "TX00", BaseImage_Transparency);

            if (NormalMap_Specular != null)
                ele.AddSimpleSubrecord("NormalMap_Specular", "TX01", NormalMap_Specular);

            if (EnvironmentMapMask != null)
                ele.AddSimpleSubrecord("EnvironmentMapMask", "TX02", EnvironmentMapMask);

            if (GlowMap != null)
                ele.AddSimpleSubrecord("GlowMap", "TX03", GlowMap);

            if (ParallaxMap != null)
                ele.AddSimpleSubrecord("ParallaxMap", "TX04", ParallaxMap);

            if (EnvironmentMap != null)
                ele.AddSimpleSubrecord("EnvironmentMap", "TX05", EnvironmentMap);

            if (DecalData != null)
            {
                XElement subEle = new XElement("DecalData");
                DecalData.WriteXML(subEle);
                ele.Add(subEle);
            }

            ele.AddSimpleSubrecord("Flags", "DNAM", Flags.ToString());
        }

        public override void ReadDataXML(XElement ele)
        {
            foreach (var subEle in ele.Elements())
            {
                switch (subEle.Attribute("Tag").Value)
                {
                    case "EDID":
                        EditorID = subEle.Value;
                        break;
                    case "OBND":
                        if (ObjectBounds == null)
                            ObjectBounds = new ObjectBounds();

                        ObjectBounds.ReadXML(subEle);
                        break;
                    case "TX00":
                        BaseImage_Transparency = subEle.Value;
                        break;
                    case "TX01":
                        NormalMap_Specular = subEle.Value;
                        break;
                    case "TX02":
                        EnvironmentMapMask = subEle.Value;
                        break;
                    case "TX03":
                        GlowMap = subEle.Value;
                        break;
                    case "TX04":
                        ParallaxMap = subEle.Value;
                        break;
                    case "TX05":
                        EnvironmentMap = subEle.Value;
                        break;
                    case "DODT":
                        if (DecalData == null)
                            DecalData = new DecalData();

                        DecalData.ReadXML(subEle);
                        break;
                    case "DNAM":
                        Flags = subEle.ToEnum<TXSTFlags>();
                        break;
                }
            }
        }
    }

    [Flags]
    public enum TXSTFlags : ushort
    {
        NoSpecularMap   =   0x00000001,
        Unknown2	    =	0x00000002,
        Unknown4	    =	0x00000004,
        Unknown8	    =	0x00000008,
        Unknown10	    =	0x00000010,
        Unknown20	    =	0x00000020,
        Unknown40	    =	0x00000040,
        Unknown80	    =	0x00000080,
        Unknown100	    =	0x00000100,
        Unknown200	    =	0x00000200,
        Unknown400	    =	0x00000400,
        Unknown800	    =	0x00000800,
        Unknown1000	    =	0x00001000,
        Unknown2000	    =	0x00002000,
        Unknown4000	    =	0x00004000,
        Unknown8000	    =	0x00008000
    }
}
