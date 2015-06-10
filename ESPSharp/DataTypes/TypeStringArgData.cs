using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.DataTypes
{
    public struct TypeStringArgData
    {
        public Type Arg1Type;
        public string Arg1Label;
        public Type Arg2Type;
        public string Arg2Label;
        public Type Arg3Type;
        public string Arg3Label;

        public TypeStringArgData(Type Arg1Type = null, string Arg1Label = "", Type Arg2Type = null, string Arg2Label = "", Type Arg3Type = null, string Arg3Label = "")
        {
            this.Arg1Type = Arg1Type;
            this.Arg1Label = Arg1Label;
            this.Arg2Type = Arg2Type;
            this.Arg2Label = Arg2Label;
            this.Arg3Type = Arg3Type;
            this.Arg3Label = Arg3Label;
        }
    }
}
