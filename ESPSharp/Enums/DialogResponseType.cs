using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum DialogResponseType : byte
    {
        Topic,
        Conversation,
        Combat,
        Persuasion,
        Detection,
        Service,
        Miscellaneous,
        Radio
    }
}
