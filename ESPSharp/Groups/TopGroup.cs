using System;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;

namespace ESPSharp
{
    class TopGroup : Group
    {
        private Dictionary<string, string> tagToNameDictionary = new Dictionary<string, string>
        {
            {"GMST", "Game Settings"},
            {"TXST", "Texture Sets"},
            {"MICN", "Menu Icons"},
            {"GLOB", "Global Variables"},
            {"CLAS", "Classes"},
            {"FACT", "Factions"},
            {"HDPT", "Head Parts"},
            {"HAIR", "Hairs"},
            {"EYES", "Eyes"},
            {"RACE", "Races"},
            {"SOUN", "Sounds"},
            {"ASPC", "Acoustic Spaces"},
            {"MGEF", "Magic Effects"},
            {"SCPT", "Scripts"},
            {"LTEX", "Landscape Textures"},
            {"ENCH", "Object Effects"},
            {"SPEL", "Actor Effects"},
            {"ACTI", "Activators"},
            {"TACT", "Talking Activators"},
            {"TERM", "Terminals"},
            {"ARMO", "Armors"},
            {"BOOK", "Books"},
            {"CONT", "Containers"},
            {"DOOR", "Doors"},
            {"INGR", "Ingredients"},
            {"LIGH", "Lights"},
            {"MISC", "Misc Items"},
            {"STAT", "Statics"},
            {"SCOL", "Static Collections"},
            {"MSTT", "Movable Statics"},
            {"PWAT", "Placeable Waters"},
            {"GRAS", "Grasses"},
            {"TREE", "Trees"},
            {"FURN", "Furniture"},
            {"WEAP", "Weapons"},
            {"AMMO", "Ammunitions"},
            {"NPC_", "Non-Player Characters"},
            {"CREA", "Creatures"},
            {"LVLC", "Leveled Creatures"},
            {"LVLN", "Leveled NPCs"},
            {"KEYM", "Key Items"},
            {"ALCH", "Ingestibles"},
            {"IDLM", "Idle Markers"},
            {"NOTE", "Notes"},
            {"COBJ", "Constructble Objects"},
            {"PROJ", "Projectiles"},
            {"LVLI", "Leveled Items"},
            {"WTHR", "Weathers"},
            {"CLMT", "Climates"},
            {"REGN", "Regions"},
            {"NAVI", "NavMesh Info Map"},
            {"DIAL", "Dialog Topics"},
            {"QUST", "Quests"},
            {"IDLE", "Idle Animations"},
            {"PACK", "Packages"},
            {"CSTY", "Combat Style"},
            {"LSCR", "Loading Screens"},
            {"ANIO", "Animated Objects"},
            {"WATR", "Water Types"},
            {"EFSH", "Effect Shaders"},
            {"EXPL", "Explosions"},
            {"DEBR", "Debris"},
            {"IMGS", "Image Spaces"},
            {"IMAD", "Image Space Modifiers"},
            {"FLST", "Form Lists"},
            {"PERK", "Perks"},
            {"BPTD", "Body Part Data"},
            {"ADDN", "Addon Nodes"},
            {"AVIF", "Actor Value Info"},
            {"RADS", "Radiation Stages"},
            {"CAMS", "Camera Shots"},
            {"CPTH", "Camera Paths"},
            {"VTYP", "Voice Types"},
            {"IPCT", "Impacts"},
            {"IPDS", "Impact Data Sets"},
            {"ARMA", "Armor Addons"},
            {"ECZN", "Encounter Zones"},
            {"MESG", "Messages"},
            {"RGDL", "Ragdolls"},
            {"DOBJ", "Default Objects"},
            {"LGTM", "Lighting Templates"},
            {"MUSC", "Music"},
            {"IMOD", "Weapon Mods"},
            {"REPU", "Reputations"},
            {"RCPE", "Recipes"},
            {"RCCT", "Recipe Categories"},
            {"CHIP", "Casino Chips"},
            {"CSNO", "Casinos"},
            {"LSCT", "Load Screen Types"},
            {"MSET", "Media Sets"},
            {"ALOC", "Audio Location Controllers"},
            {"CHAL", "Challenges"},
            {"AMEF", "Ammo Effects"},
            {"CCRD", "Caravan Cards"},
            {"CMNY", "Caravan Money"},
            {"CDCK", "Caravan Decks"},
            {"DEHY", "Dehydration Stages"},
            {"HUNG", "Hunger Stages"},
            {"SLPD", "Sleep Deprivation Stages"},
            {"CELL", "Interior Cells"},
            {"WRLD", "Worldspaces"}
        };

        public string RecordType { get; protected set; }

        public TopGroup()
        {
            type = GroupType.TopGroup;
        }

        public override void WriteTypeData(ESPWriter writer)
        {
            writer.Write(RecordType.ToCharArray());
        }

        public override void ReadTypeData(ESPReader reader)
        {
            RecordType = reader.ReadTag();
        }

        public override XElement WriteTypeDataXML()
        {
            return new XElement("RecordType", RecordType);
        }

        public override void ReadTypeDataXML(XElement element)
        {
            RecordType = element.Element("RecordType").Value;
        }

        public override string ToString()
        {
            return tagToNameDictionary[RecordType];
        }
    }
}
