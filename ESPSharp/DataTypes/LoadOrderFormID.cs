using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.DataTypes
{
    public class LoadOrderFormID : FormID
    {
        public ElderScrollsPlugin Master { get; protected set; }
        public LoadOrderFormID(FormID fileFormID, ElderScrollsPlugin file)
        {
            uint fileIndex = fileFormID.RawValue >> 24;
            uint recordIndex = fileFormID.RawValue & 0x00FFFFFF;

            if (fileIndex >= file.Masters.Count)
                fileIndex = (uint)(file.Masters.Count - 1);

            string masterName = file.Masters[(int)fileIndex];
            ElderScrollsPlugin master = ElderScrollsPlugin.LoadedPlugins.FirstOrDefault(esp => esp.Name == masterName);

            if (master == null)
                throw new Exception();

            Master = master;

            uint newFileIndex = (uint)(ElderScrollsPlugin.LoadedPlugins.IndexOf(master) << 24);

            RawValue = newFileIndex | recordIndex;
        }

        public RecordView GetWinningView()
        {
            return ElderScrollsPlugin.LoadedRecordViews[RawValue].Last();
        }

        public RecordView GetOriginalView()
        {
            return ElderScrollsPlugin.LoadedRecordViews[RawValue].First();
        }

        public List<RecordView> GetViews()
        {
            return ElderScrollsPlugin.LoadedRecordViews[RawValue];
        }
    }
}
