using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum PackageLocationType : uint
    {
        NearReference,
        InCell,
        NearCurrentLocation,
        NearEditorLocation,
        ObjectID,
        ObjectType,
        NearLinkedReference,
        AtPackageLocation
    }
}
