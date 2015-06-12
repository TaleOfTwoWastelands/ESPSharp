using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum IngredientFlags : byte
    {
        NoAutoCalculation = 0x01,
        FoodItem = 0x02
    }
}
