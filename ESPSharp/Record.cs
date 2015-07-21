using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Records;
using ESPSharp.DataTypes;

namespace ESPSharp
{
    public abstract class Record
    {
        public string Tag { get; protected set; }
        public uint Size { get; protected set; }
        public RecordFlag Flags { get; set; }
        public FormID FormID { get; set; }
        public DateStamp LastModified { get; set; }
        public ushort FormVersion { get; protected set; }

        protected bool compressionCorrupted = false;
        protected byte[] corruptedBytes;

        public Record()
        {
            FormID = new FormID();
        }

        public void WriteXML(string destinationFile, ElderScrollsPlugin master)
        {
            XDocument doc = new XDocument();

            XElement root = new XElement("Record", 
                                new XAttribute("Tag", Tag));

            doc.Add(root);

            root.Add(
                new XElement("Flags", Flags),
                new XElement("FormID"),
                new XElement("FormVersion", FormVersion),
                new XElement("CompressionCorrupted", compressionCorrupted)
                );

            FormID.WriteXML(root.Element("FormID"), master);

            if (compressionCorrupted)
                root.Add(new XElement("CorruptedBytes"), corruptedBytes.ToBase64());
            else
            {
                XElement ele = new XElement("Subrecords");
                root.Add(ele);
                WriteDataXML(ele, master);
            }

            XMLPostProcessing(root, destinationFile);

            doc.Save(destinationFile);
        }

        public static Record ReadXML(string sourceFile, ElderScrollsPlugin master)
        {
            XDocument doc = XDocument.Load(sourceFile);
            XElement root = (XElement)doc.FirstNode;

            Record outRecord = Record.CreateRecord(root.Attribute("Tag").Value);

            outRecord.Flags = root.Element("Flags").ToEnum<RecordFlag>();
            outRecord.FormID.ReadXML(root.Element("FormID"), master);
            outRecord.FormVersion = root.Element("FormVersion").ToUInt16();
            outRecord.compressionCorrupted = root.Element("CompressionCorrupted").ToBoolean();

            if (outRecord.compressionCorrupted)
                outRecord.corruptedBytes = root.Element("CorruptedBytes").ToBytes();
            else
            {
                outRecord.XMLPreProcessing(root, sourceFile);
                outRecord.ReadDataXML(root.Element("Subrecords"), master);
            }

            return outRecord;
        }

        public void WriteBinary(ESPWriter writer)
        {
            writer.Write(Utility.DesanitizeTag(Tag).ToCharArray());
            writer.Write((uint)0);
            writer.Write((uint)Flags);
            writer.Write(FormID);
            DateStamp.Now.WriteBinary(writer);
            writer.Write((ushort)0); //padding
            writer.Write(FormVersion);
            writer.Write((ushort)0); //padding

            long dataStart = writer.BaseStream.Position;

            if (Flags.HasFlag(RecordFlag.Compressed))
            {
                if (compressionCorrupted)
                    writer.Write(corruptedBytes);
                else
                {
                    using (MemoryStream stream = new MemoryStream())
                    using (ESPWriter subWriter = new ESPWriter(stream))
                    {
                        WriteData(subWriter);
                        stream.Position = 0;
                        writer.Write((uint)stream.Length);
                        writer.Write(Zlib.Compress(stream));
                    }
                }
            }
            else
                WriteData(writer);

            long dataEnd = writer.BaseStream.Position;

            writer.BaseStream.Seek(dataStart - 20, SeekOrigin.Begin);
            writer.Write((uint)(dataEnd - dataStart));
            writer.BaseStream.Seek(dataEnd, SeekOrigin.Begin);
        }

        public void ReadBinary(ESPReader reader)
        {
            Tag = reader.ReadTag();
            Size = reader.ReadUInt32();
            Flags = (RecordFlag)reader.ReadUInt32();
            FormID = reader.Read<FormID>();
            LastModified = new DateStamp();
            LastModified.ReadBinary(reader);
            reader.ReadBytes(2);
            FormVersion = reader.ReadUInt16();
            reader.ReadBytes(2);

            if (Flags.HasFlag(RecordFlag.Compressed))
            {
                byte[] outBytes;
                compressionCorrupted = !TryDecompressData(reader, out outBytes);

                if (compressionCorrupted)
                    corruptedBytes = outBytes;
                else
                    using (MemoryStream stream = new MemoryStream(outBytes))
                    using (ESPReader subReader = new ESPReader(stream))
                        ReadData(subReader, stream.Length);
            }
            else
            {
                ReadData(reader, reader.BaseStream.Position + Size);
            }
        }

        bool TryDecompressData(ESPReader reader, out byte[] outBytes)
        {
            uint origSize = reader.ReadUInt32();
            byte[] compressedBytes = reader.ReadBytes((int)Size - 4);

            try
            {
                using (MemoryStream stream = new MemoryStream(compressedBytes))
                    outBytes = Zlib.Decompress(stream, origSize - 4);

                return true;
            }
            catch
            {
                List<byte> temp = BitConverter.GetBytes(origSize).ToList();
                temp.AddRange(compressedBytes);
                outBytes = temp.ToArray();

                return false;
            }
        }

        byte[] CompressData(byte[] data)
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(data.Length));

            byteList.AddRange(Zlib.Compress(data));

            return byteList.ToArray();
        }

        public abstract void ReadData(ESPReader reader, long dataEnd);

        public abstract void WriteData(ESPWriter writer);

        public abstract void WriteDataXML(XElement ele, ElderScrollsPlugin master);

        public abstract void ReadDataXML(XElement ele, ElderScrollsPlugin master);

        protected virtual void XMLPreProcessing(XElement root, string sourceFile) { }
        protected virtual void XMLPostProcessing(XElement root, string destinationFile) { }

        public static Record CreateRecord(string Tag)
        {
            Record outRecord;

            switch (Tag)
            {
                case "TES4":
                    outRecord = new Header();
                    break;
                case "GMST":
                    outRecord = new GameSetting();
                    break;
                case "TXST":
                    outRecord = new TextureSet();
                    break;
                case "MICN":
                    outRecord = new MenuIcon();
                    break;
                case "GLOB":
                    outRecord = new GlobalVariable();
                    break;
                case "CLAS":
                    outRecord = new Class();
                    break;
                case "FACT":
                    outRecord = new Faction();
                    break;
                case "HDPT":
                    outRecord = new HeadPart();
                    break;
                case "HAIR":
                    outRecord = new Hair();
                    break;
                case "EYES":
                    outRecord = new Eyes();
                    break;
                case "RACE":
                    outRecord = new Race();
                    break;
                case "SOUN":
                    outRecord = new Sound();
                    break;
                case "ASPC":
                    outRecord = new AcousticSpace();
                    break;
                case "MGEF":
                    outRecord = new MagicEffect();
                    break;
                case "SCPT":
                    outRecord = new Script();
                    break;
                case "LTEX":
                    outRecord = new LandscapeTexture();
                    break;
                case "ENCH":
                    outRecord = new ObjectEffect();
                    break;
                case "SPEL":
                    outRecord = new ActorEffect();
                    break;
                case "ACTI":
                    outRecord = new ESPSharp.Records.Activator();
                    break;
                case "TACT":
                    outRecord = new TalkingActivator();
                    break;
                case "TERM":
                    outRecord = new Terminal();
                    break;
                case "ARMO":
                    outRecord = new Armor();
                    break;
                case "BOOK":
                    outRecord = new Book();
                    break;
                case "CONT":
                    outRecord = new Container();
                    break;
                case "DOOR":
                    outRecord = new Door();
                    break;
                case "INGR":
                    outRecord = new Ingredient();
                    break;
                case "LIGH":
                    outRecord = new Light();
                    break;
                case "MISC":
                    outRecord = new MiscItem();
                    break;
                case "STAT":
                    outRecord = new Static();
                    break;
                case "SCOL":
                    outRecord = new StaticCollection();
                    break;
                case "MSTT":
                    outRecord = new MoveableStatic();
                    break;
                case "PWAT":
                    outRecord = new PlaceableWater();
                    break;
                case "GRAS":
                    outRecord = new Grass();
                    break;
                case "TREE":
                    outRecord = new Tree();
                    break;
                case "FURN":
                    outRecord = new Furniture();
                    break;
                case "WEAP":
                    outRecord = new Weapon();
                    break;
                case "AMMO":
                    outRecord = new Ammunition();
                    break;
                case "NPC_":
                    outRecord = new NonPlayerCharacter();
                    break;
                case "CREA":
                    outRecord = new Creature();
                    break;
                case "LVLC":
                    outRecord = new LeveledCreature();
                    break;
                case "LVLN":
                    outRecord = new LeveledNPC();
                    break;
                case "KEYM":
                    outRecord = new Key();
                    break;
                case "ALCH":
                    outRecord = new Ingestible();
                    break;
                case "IDLM":
                    outRecord = new IdleMarker();
                    break;
                case "NOTE":
                    outRecord = new Note();
                    break;
                case "COBJ":
                    outRecord = new ConstructibleObject();
                    break;
                case "PROJ":
                    outRecord = new Projectile();
                    break;
                case "LVLI":
                    outRecord = new LeveledItem();
                    break;
                case "WTHR":
                    outRecord = new Weather();
                    break;
                case "CLMT":
                    outRecord = new Climate();
                    break;
                case "REGN":
                    outRecord = new Region();
                    break;
                case "NAVI":
                    outRecord = new NavigationMeshInfoMap();
                    break;
                case "DIAL":
                    outRecord = new DialogTopic();
                    break;
                case "QUST":
                    outRecord = new Quest();
                    break;
                case "IDLE":
                    outRecord = new IdleAnimation();
                    break;
                case "PACK":
                    outRecord = new Package();
                    break;
                case "CSTY":
                    outRecord = new CombatStyle();
                    break;
                case "LSCR":
                    outRecord = new LoadScreen();
                    break;
                case "ANIO":
                    outRecord = new AnimatedObject();
                    break;
                case "WATR":
                    outRecord = new Water();
                    break;
                case "EFSH":
                    outRecord = new EffectShader();
                    break;
                case "EXPL":
                    outRecord = new Explosion();
                    break;
                case "DEBR":
                    outRecord = new Debris();
                    break;
                case "IMGS":
                    outRecord = new ImageSpace();
                    break;
                case "IMAD":
                    outRecord = new ImageSpaceAdapter();
                    break;
                case "FLST":
                    outRecord = new FormList();
                    break;
                case "PERK":
                    outRecord = new Perk();
                    break;
                case "BPTD":
                    outRecord = new BodyPartData();
                    break;
                case "ADDN":
                    outRecord = new AddonNode();
                    break;
                case "AVIF":
                    outRecord = new ActorValueInformation();
                    break;
                case "RADS":
                    outRecord = new RadiationStage();
                    break;
                case "CAMS":
                    outRecord = new CameraShot();
                    break;
                case "CPTH":
                    outRecord = new CameraPath();
                    break;
                case "VTYP":
                    outRecord = new VoiceType();
                    break;
                case "IPCT":
                    outRecord = new Impact();
                    break;
                case "IPDS":
                    outRecord = new ImpactDataSet();
                    break;
                case "ARMA":
                    outRecord = new ArmorAddon();
                    break;
                case "ECZN":
                    outRecord = new EncounterZone();
                    break;
                case "MESG":
                    outRecord = new Message();
                    break;
                case "RGDL":
                    outRecord = new Ragdoll();
                    break;
                case "DOBJ":
                    outRecord = new DefaultObjectManager();
                    break;
                case "LGTM":
                    outRecord = new LightingTemplate();
                    break;
                case "MUSC":
                    outRecord = new MusicType();
                    break;
                case "IMOD":
                    outRecord = new ItemMod();
                    break;
                case "REPU":
                    outRecord = new Reputation();
                    break;
                case "RCPE":
                    outRecord = new Recipe();
                    break;
                case "RCCT":
                    outRecord = new RecipeCategory();
                    break;
                case "CHIP":
                    outRecord = new CasinoChip();
                    break;
                case "CSNO":
                    outRecord = new Casino();
                    break;
                case "LSCT":
                    outRecord = new LoadScreenType();
                    break;
                case "MSET":
                    outRecord = new MediaSet();
                    break;
                case "ALOC":
                    outRecord = new MediaLocationController();
                    break;
                case "CHAL":
                    outRecord = new Challenge();
                    break;
                case "AMEF":
                    outRecord = new AmmoEffect();
                    break;
                case "CCRD":
                    outRecord = new CaravanCard();
                    break;
                case "CMNY":
                    outRecord = new CaravanMoney();
                    break;
                case "CDCK":
                    outRecord = new CaravanDeck();
                    break;
                case "DEHY":
                    outRecord = new DehydrationStage();
                    break;
                case "HUNG":
                    outRecord = new HungerStage();
                    break;
                case "SLPD":
                    outRecord = new SleepDeprivationStage();
                    break;
                case "CELL":
                    outRecord = new Cell();
                    break;
                case "WRLD":
                    outRecord = new Worldspace();
                    break;
                case "LAND":
                    outRecord = new GenericRecord();
                    break;
                case "NAVM":
                    outRecord = new NavigationMesh();
                    break;
                case "INFO":
                    outRecord = new DialogResponse();
                    break;
                case "REFR":
                    outRecord = new Reference();
                    break;
                case "ACHR":
                    outRecord = new PlacedNPC();
                    break;
                case "ACRE":
                    outRecord = new PlacedCreature();
                    break;
                case "PGRE":
                    outRecord = new PlacedGrenade();
                    break;
                case "PMIS":
                    outRecord = new PlacedMissile();
                    break;
                default:
                    Console.WriteLine("Encountered unknown record: " + Tag);
                    outRecord = new GenericRecord();
                    break;
            }

            outRecord.Tag = Tag;

            return outRecord;
        }

        public static Record CreateRecord(ESPReader reader)
        {
            return CreateRecord(reader.PeekTag());
        }

        public static Record CreateRecord(XDocument doc)
        {
            return Record.CreateRecord(doc.Element("Record").Attribute("Tag").Value);
        }

        public override string ToString()
        {
            if (this is IEditorID && (this as IEditorID).EditorID != null && (this as IEditorID).EditorID.Value != "")
                return (this as IEditorID).EditorID.Value;
            else
                return String.Format("{0} - {1}", Tag, FormID.ToString());
        }
    }
}
