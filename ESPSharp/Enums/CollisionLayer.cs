using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPSharp.Enums
{
    public enum CollisionLayer : uint
    {
        Unidentified,
        Static,
        AnimStatic,
        Transparent,
        Clutter,
        Weapon,
        Projectile,
        Spell,
        Biped,
        Trees,
        Props,
        Water,
        Trigger,
        Terrain,
        Trap,
        NonCollidable,
        CloudTrap,
        Ground,
        Portal,
        DebrisSmall,
        DebrisLarge,
        AcousticSpace,
        ActorZone,
        ProjectileZone,
        GasTrap,
        ShellCasing,
        TransparentSmall,
        InvisibleWall,
        TransparentSmallAnim,
        DeadBip,
        CharController,
        AvoidBox,
        CollisionBox,
        CameraSphere,
        DoorDetection,
        CameraPick,
        ItemPick,
        LineOfSight,
        PathPick,
        CustomPick1,
        CustomPick2,
        SpellExplosion,
        DroppingPick
    }
}
