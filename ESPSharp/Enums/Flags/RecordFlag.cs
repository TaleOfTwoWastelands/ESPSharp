using System;

namespace ESPSharp.Enums.Flags
{
    [Flags]
    public enum RecordFlag : uint
    {
        IsMasterFile        =   0x00000001,
        Unknown2	    =	0x00000002,
        Unknown4	    =	0x00000004,
        Unknown8	    =	0x00000008,
        FormInitialized	    =	0x00000010,
        Deleted	    =	0x00000020,
        BorderRegion_HasTreeLOD_Constant_HiddenFromLocalMap	    =	0x00000040,
        TurnOffFire	    =	0x00000080,
        Inaccessible	    =	0x00000100,
        CastsShadows_OnLocalMap_MotionBlur	    =	0x00000200,
        QuestItem_PersistentReference	    =	0x00000400,
        InitiallyDisabled	    =	0x00000800,
        Ignored	    =	0x00001000,
        NoVoiceFilter	    =	0x00002000,
        CannotSave	    =	0x00004000,
        VisibleWhenDistant	    =	0x00008000,
        RandomAnimStart_HighPriorityLOD	=	0x00010000,
        Dangerous_OffLimits_RadioStation	=	0x00020000,
        Compressed	=	0x00040000,
        CantWait_PlatformSpecificTexture_Dead	=	0x00080000,
        Unknown100000	=	0x00100000,
        Unknown200000	=	0x00200000,
        Unknown400000	=	0x00400000,
        Unknown800000	=	0x00800000,
        Destructible	=	0x01000000,
        Obstacle_NoAIAcquire	=	0x02000000,
        NavMeshGenerationFilter	=	0x04000000,
        NavMeshGenerationBoundingBox	=   0x08000000,
        NonPipboy_ReflectedByAutoWater	=   0x10000000,
        ChildCanUse_RefractedByAutoWater	=   0x20000000,
        NavMeshGenerationGround	=   0x40000000,
        Unknown80000000	=   0x80000000
    }
}
