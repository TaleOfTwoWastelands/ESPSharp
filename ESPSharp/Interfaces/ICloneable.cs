using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESPSharp.Interfaces
{
    public interface ICloneable<T>
    {
        T Clone();
    }
}
