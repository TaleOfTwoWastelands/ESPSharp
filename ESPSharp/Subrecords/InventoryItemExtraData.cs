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
    public partial class InventoryItemExtraData
    {
        partial void ReadOwnerDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle; 
            
            ele.TryPathTo("Owner", false, out subEle);
            OwnerData = subEle.Elements().First().ToUInt32();
        }

        partial void WriteOwnerDataXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (Owner.RawValue != 0)
            {
                switch (new LoadOrderFormID(Owner, master).GetOriginalView().Tag)
                {
                    case "NPC_":
                        ele.TryPathTo("Owner", true, out subEle);
                        subEle.Add(new XElement("Unused", OwnerData)); 
                        break;
                    case "FACT":
                        ele.TryPathTo("Owner", true, out subEle);
                        subEle.Add(new XElement("RequiredRank", OwnerData)); 
                        break;
                    default:
                        ele.TryPathTo("Owner", true, out subEle);
                        subEle.Add(new XElement("Unknown", OwnerData)); 
                        break;
                }
            }
            else
            {
                ele.TryPathTo("Owner", true, out subEle);
                subEle.Add(new XElement("Unused", OwnerData));
            }
        }
    }
}