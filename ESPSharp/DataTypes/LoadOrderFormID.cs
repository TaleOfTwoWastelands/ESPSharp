using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.DataTypes
{
    public class LoadOrderFormID : FormID
    {
        public LoadOrderFormID(FormID fileFormID, ElderScrollsPlugin file)
        {
            uint fileIndex = fileFormID.RawValue >> 24;
            uint recordIndex = fileFormID.RawValue & 0x00FFFFFF;

            string masterName = file.Masters[(int)fileIndex];
            ElderScrollsPlugin master = ElderScrollsPlugin.LoadedPlugins.FirstOrDefault(esp => esp.Name == masterName);

            if (master == null)
                throw new Exception();

            uint newFileIndex = (uint)(ElderScrollsPlugin.LoadedPlugins.IndexOf(master) << 24);

            RawValue = newFileIndex | recordIndex;
        }

        public RecordView GetWinningView()
        {
            return ElderScrollsPlugin.LoadedRecordViews[this].Last();
        }

        public List<RecordView> GetViews()
        {
            return ElderScrollsPlugin.LoadedRecordViews[this];
        }
    }
}
