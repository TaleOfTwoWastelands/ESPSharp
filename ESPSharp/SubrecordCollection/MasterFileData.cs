using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ESPSharp
{
    public class MasterFileData : SubrecordCollection
    {
        public override void ReadBinary(ESPReader reader)
        {
            throw new NotImplementedException();
        }

        public override void WriteBinary(ESPWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void WriteXML(XElement root)
        {
            throw new NotImplementedException();
        }

        public override void ReadXML(XElement ele)
        {
            throw new NotImplementedException();
        }
    }
}
