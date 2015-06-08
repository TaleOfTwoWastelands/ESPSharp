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

namespace ESPSharp.Records
{
    public partial class Script : Record, IEditorID
    {
        protected override void XMLPreProcessing(XElement root, string sourceFile)
        {
            XElement scriptSource;

            root.TryPathTo("Subrecords/Data/ScriptSource", false, out scriptSource);
            string file = Path.Combine(Path.GetDirectoryName(sourceFile), scriptSource.Attribute("External").Value);

            using (FileStream stream = new FileStream(file, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                string value = reader.ReadToEnd();
                scriptSource.Value = value;
            }
        }

        protected override void XMLPostProcessing(XElement root, string destinationFile)
        {
            XElement scriptSource;

            if (root.TryPathTo("Subrecords/Data/ScriptSource", false, out scriptSource))
            {
                using (FileStream stream = new FileStream(Path.ChangeExtension(destinationFile, "fnvscript"), FileMode.Create))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(scriptSource.Value);
                }

                XElement placeholder = new XElement(scriptSource.Name);
                placeholder.Add(scriptSource.Attributes());
                placeholder.Add(new XAttribute("External", Path.GetFileName(Path.ChangeExtension(destinationFile, "fnvscript"))));
                scriptSource.ReplaceWith(placeholder);
            }
        }
    }
}