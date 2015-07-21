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

namespace ESPSharp.DataTypes
{
    public class Function : IESPSerializable, ICloneable, IComparable<Function>, IEquatable<Function>, IReferenceContainer
    {
        #region Dictionary
        private static Dictionary<FunctionType, TypeStringArgData> Metadata = new Dictionary<FunctionType, TypeStringArgData>()
        {
            {FunctionType.GetDistance, new TypeStringArgData(typeof(FormID), "ObjectReferences", null, "UnusedArg2")},
            {FunctionType.GetLocked, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetPOS, new TypeStringArgData(typeof(Axis), "Axis", null, "UnusedArg2")},
            {FunctionType.GetAngle, new TypeStringArgData(typeof(Axis), "Axis", null, "UnusedArg2")},
            {FunctionType.GetStartingPos, new TypeStringArgData(typeof(Axis), "Axis", null, "UnusedArg2")},
            {FunctionType.GetStartingAngle, new TypeStringArgData(typeof(Axis), "Axis", null, "UnusedArg2")},
            {FunctionType.GetSecondsPassed, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetActorValue, new TypeStringArgData(typeof(ActorValues), "ActorValue", null, "UnusedArg2")},
            {FunctionType.GetCurrentTime, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetScale, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsMoving, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsTurning, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetLineOfSight, new TypeStringArgData(typeof(FormID), "ObjectReferences", null, "UnusedArg2")},
            {FunctionType.GetInSameCell, new TypeStringArgData(typeof(FormID), "ObjectReferences", null, "UnusedArg2")},
            {FunctionType.GetDisabled, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.MenuMode, new TypeStringArgData(typeof(MenuMode), "Mode", null, "UnusedArg2")},
            {FunctionType.GetDisease, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetVampire, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetClothingValue, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.SameFaction, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.SameRace, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.SameSex, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.GetDetected, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.GetDead, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetItemCount, new TypeStringArgData(typeof(FormID), "InventoryObject", null, "Unused")},
            {FunctionType.GetGold, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetSleeping, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetTalkedToPC, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetScriptVar, new TypeStringArgData(typeof(FormID), "Quest", typeof(uint), "VariableIndex")},
            {FunctionType.GetQuestRunning, new TypeStringArgData(typeof(FormID), "Quest", null, "UnusedArg2")},
            {FunctionType.GetStage, new TypeStringArgData(typeof(FormID), "Quest", null, "UnusedArg2")},
            {FunctionType.GetStageDone, new TypeStringArgData(typeof(FormID), "Quest", typeof(uint), "QuestStage")},
            {FunctionType.GetFactionRankDifference, new TypeStringArgData(typeof(FormID), "Faction", typeof(FormID), "Actor")},
            {FunctionType.IsAlarmed, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsRaining, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetAttacked, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIsCreature, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetLockLevel, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetShouldAttack, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.GetInCell, new TypeStringArgData(typeof(FormID), "Cell", null, "UnusedArg2")},
            {FunctionType.GetIsClass, new TypeStringArgData(typeof(FormID), "Class", null, "UnusedArg2")},
            {FunctionType.GetIsRace, new TypeStringArgData(typeof(FormID), "Race", null, "UnusedArg2")},
            {FunctionType.GetIsSex, new TypeStringArgData(typeof(Gender), "Sex", null, "UnusedArg2")},
            {FunctionType.GetInFaction, new TypeStringArgData(typeof(FormID), "Faction", null, "UnusedArg2")},
            {FunctionType.GetIsID, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetFactionRank, new TypeStringArgData(typeof(FormID), "Faction", null, "UnusedArg2")},
            {FunctionType.GetGlobalValue, new TypeStringArgData(typeof(FormID), "Global", null, "UnusedArg2")},
            {FunctionType.IsSnowing, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetDisposition, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.GetRandomPercent, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetQuestVariable, new TypeStringArgData(typeof(FormID), "Quest", typeof(uint), "VariableIndex")},
            {FunctionType.GetLevel, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetArmorRating, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetDeadCount, new TypeStringArgData(typeof(FormID), "ActorBase", null, "UnusedArg2")},
            {FunctionType.GetIsAlerted, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetPlayerControlsDisabled, new TypeStringArgData(typeof(uint), "Arg1", null, "UnusedArg2")},
            {FunctionType.GetHeadingAngle, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.IsWeaponOut, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsTorchOut, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsShieldOut, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsFacingUp, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetKnockedState, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetWeaponAnimType, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsWeaponSkillType, new TypeStringArgData(typeof(ActorValues), "Skill", null, "UnusedArg2")},
            {FunctionType.GetCurrentAIPackage, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.IsWaiting, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsIdlePlaying, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetMinorCrimeCount, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetMajorCrimeCount, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetActorAggroRadiusViolated, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetCrime, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.IsGreetingPlayer, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsGuard, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.HasBeenEaten, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetFatiguePercentage, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetPCIsClass, new TypeStringArgData(typeof(FormID), "Class", null, "UnusedArg2")},
            {FunctionType.GetPCIsRace, new TypeStringArgData(typeof(FormID), "Race", null, "UnusedArg2")},
            {FunctionType.GetPCIsSex, new TypeStringArgData(typeof(Gender), "Sex", null, "UnusedArg2")},
            {FunctionType.GetPCInFaction, new TypeStringArgData(typeof(FormID), "Faction", null, "UnusedArg2")},
            {FunctionType.SameFactionAsPC, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.SameRaceAsPC, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.SameSexAsPC, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIsReference, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.IsTalking, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetWalkSpeed, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetCurrentAIProcedure, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetTrespassWarningLevel, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsTrespassing, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsInMyOwnedCell, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetWindSpeed, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetCurrentWeatherPercent, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIsCurrentWeather, new TypeStringArgData(typeof(FormID), "Weather", null, "UnusedArg2")},
            {FunctionType.IsContinuingPackagePCNear, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.CanHaveFlames, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.HasFlames, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetOpenState, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetSitting, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetFurnitureMarkerID, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIsCurrentPackage, new TypeStringArgData(typeof(FormID), "Package", null, "UnusedArg2")},
            {FunctionType.IsCurrentFurnitureRef, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.IsCurrentFurnitureObj, new TypeStringArgData(typeof(FormID), "Furniture", null, "UnusedArg2")},
            {FunctionType.GetDayOfWeek, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetTalkedToPCParam, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.IsPCSleeping, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsPCAMurderer, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetDetectionLevel, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.GetEquipped, new TypeStringArgData(typeof(FormID), "InventoryObject", null, "UnusedArg2")},
            {FunctionType.IsSwimming, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetAmountSoldStolen, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIgnoreCrime, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetPCExpelled, new TypeStringArgData(typeof(FormID), "Faction", null, "UnusedArg2")},
            {FunctionType.GetPCFactionMurder, new TypeStringArgData(typeof(FormID), "Faction", null, "UnusedArg2")},
            {FunctionType.GetPCEnemyofFaction, new TypeStringArgData(typeof(FormID), "Faction", null, "UnusedArg2")},
            {FunctionType.GetPCFactionAttack, new TypeStringArgData(typeof(FormID), "Faction", null, "UnusedArg2")},
            {FunctionType.GetDestroyed, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.HasMagicEffect, new TypeStringArgData(typeof(FormID), "BaseEffect", null, "UnusedArg2")},
            {FunctionType.GetDefaultOpen, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetAnimation, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsSpellTarget, new TypeStringArgData(typeof(FormID), "EffectItem", null, "UnusedArg2")},
            {FunctionType.GetVATSMode, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetPersuasionNumber, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetSandman, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetCannibal, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIsClassDefault, new TypeStringArgData(typeof(FormID), "Class", null, "UnusedArg2")},
            {FunctionType.GetClassDefaultMatch, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetInCellParam, new TypeStringArgData(typeof(FormID), "Cell", null, "UnusedArg2")},
            {FunctionType.GetVatsTargetHeight, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIsGhost, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetUnconscious, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetRestrained, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIsUsedItem, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetIsUsedItemType, new TypeStringArgData(typeof(FormType), "FormType", null, "UnusedArg2")},
            {FunctionType.GetIsPlayableRace, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetOffersServicesNow, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetUsedItemLevel, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetUsedItemActivate, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetBarterGold, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsTimePassing, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsPleasant, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsCloudy, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetArmorRatingUpperBody, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetBaseActorValue, new TypeStringArgData(typeof(ActorValues), "ActorValue", null, "UnusedArg2")},
            {FunctionType.IsOwner, new TypeStringArgData(typeof(FormID), "Owner", null, "UnusedArg2")},
            {FunctionType.IsCellOwner, new TypeStringArgData(typeof(FormID), "Cell", null, "UnusedArg2")},
            {FunctionType.IsHorseStolen, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsLeftUp, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsSneaking, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsRunning, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetFriendHit, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsInCombat, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsInInterior, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsWaterObject, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsActorUsingATorch, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsXBox, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetInWorldspace, new TypeStringArgData(typeof(FormID), "Worldspace", null, "UnusedArg2")},
            {FunctionType.GetPCMiscStat, new TypeStringArgData(typeof(MiscStat), "Stat", null, "UnusedArg2")},
            {FunctionType.IsActorEvil, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsActorAVictim, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetTotalPersuasionNumber, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIdleDoneOnce, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetNoRumors, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.WhichServiceMenu, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsRidingHorse, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsInDangerousWater, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIgnoreFriendlyHits, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsPlayersLastRiddenHorse, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsActor, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsEssential, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsPlayerMovingIntoNewSpace, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetTimeDead, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetPlayerHasLastRiddenHorse, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsChild, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetLastPlayerAction, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsPlayerActionActive, new TypeStringArgData(typeof(PlayerAction), "Action", null, "UnusedArg2")},
            {FunctionType.IsTalkingActivatorActor, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.IsInList, new TypeStringArgData(typeof(FormID), "List", null, "UnusedArg2")},
            {FunctionType.GetHasNote, new TypeStringArgData(typeof(FormID), "Note", null, "UnusedArg2")},
            {FunctionType.GetHitLocation, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsPC1stPerson, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetCauseofDeath, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsLimbGone, new TypeStringArgData(typeof(BodyLocation), "Part", null, "UnusedArg2")},
            {FunctionType.IsWeaponInList, new TypeStringArgData(typeof(FormID), "List", null, "UnusedArg2")},
            {FunctionType.HasFriendDisposition, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetVATSValue, new TypeStringArgData(typeof(VATSValue), "VATSValue")},    //Special case, the second value varies based on the first value
            {FunctionType.IsKiller, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.IsKillerObject, new TypeStringArgData(typeof(FormID), "List", null, "UnusedArg2")},
            {FunctionType.GetFactionCombatReaction, new TypeStringArgData(typeof(FormID), "Faction1", typeof(FormID), "Faction2")},
            {FunctionType.Exists, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetGroupMemberCount, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetGroupTargetCount, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetObjectiveCompleted, new TypeStringArgData(typeof(FormID), "Quest", typeof(uint), "ObjetiveIndex")},
            {FunctionType.GetObjectiveDisplayed, new TypeStringArgData(typeof(FormID), "Quest", typeof(uint), "ObjetiveIndex")},
            {FunctionType.GetIsVoiceType, new TypeStringArgData(typeof(FormID), "VoiceType", null, "UnusedArg2")},
            {FunctionType.GetPlantedExplosive, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsActorTalkingThroughActivator, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetHealthPercentage, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIsObjectType, new TypeStringArgData(typeof(FormType), "FormType", null, "UnusedArg2")},
            {FunctionType.GetDialogueEmotion, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetDialogueEmotionValue, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIsCreatureType, new TypeStringArgData(typeof(CreatureType), "CreatureType", null, "UnusedArg2")},
            {FunctionType.GetInZone, new TypeStringArgData(typeof(FormID), "EncounterZone", null, "UnusedArg2")},
            {FunctionType.HasPerk, new TypeStringArgData(typeof(FormID), "Perk", typeof(uint), "Rank")},
            {FunctionType.GetFactionRelation, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.IsLastIdlePlayed, new TypeStringArgData(typeof(FormID), "Idle", null, "UnusedArg2")},
            {FunctionType.GetPlayerTeammate, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetPlayerTeammateCount, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetActorCrimePlayerEnemy, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetActorFactionPlayerEnemy, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsPlayerTagSkill, new TypeStringArgData(typeof(FormID), "Skill", null, "UnusedArg2")},
            {FunctionType.IsPlayerGrabbedRef, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetDestructionStage, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetIsAlignment, new TypeStringArgData(typeof(Alignment), "Alignment", null, "UnusedArg2")},
            {FunctionType.GetThreatRatio, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.GetIsUsedItemEquipType, new TypeStringArgData(typeof(EquipmentType), "EquipmentType", null, "UnusedArg2")},
            {FunctionType.GetConcussed, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetMapMarkerVisible, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetPermanentActorValue, new TypeStringArgData(typeof(ActorValues), "ActorValue", null, "UnusedArg2")},
            {FunctionType.GetKillingBlowLimb, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetWeaponHealthPerc, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetRadiationLevel, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetLastHitCritical, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsCombatTarget, new TypeStringArgData(typeof(FormID), "Actor", null, "UnusedArg2")},
            {FunctionType.GetVATSRightAreaFree, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetVATSLeftAreaFree, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetVATSBackAreaFree, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetVATSFrontAreaFree, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetIsLockBroken, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsPS3, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.IsWin32, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetVATSRightTargetVisible, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetVATSLeftTargetVisible, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetVATSBackTargetVisible, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.GetVATSFrontTargetVisible, new TypeStringArgData(typeof(FormID), "ObjectReference", null, "UnusedArg2")},
            {FunctionType.IsInCriticalStage, new TypeStringArgData(typeof(CriticalStage), "Stage", null, "UnusedArg2")},
            {FunctionType.GetXPForNextLevel, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetQuestCompleted, new TypeStringArgData(typeof(FormID), "Quest", null, "UnusedArg2")},
            {FunctionType.IsGoreDisabled, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetSpellUsageNum, new TypeStringArgData(typeof(FormID), "EffectItem", null, "UnusedArg2")},
            {FunctionType.GetActorsInHigh, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.HasLoaded3D, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetReputation, new TypeStringArgData(typeof(FormID), "Reputation", null, "UnusedArg2")},
            {FunctionType.GetReputationPct, new TypeStringArgData(typeof(FormID), "Reputation", null, "UnusedArg2")},
            {FunctionType.GetReputationThreshold, new TypeStringArgData(typeof(FormID), "Reputation", null, "UnusedArg2")},
            {FunctionType.IsHardcore, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.GetForceHitReaction, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")},
            {FunctionType.ChallengeLocked, new TypeStringArgData(typeof(FormID), "Challenge", null, "UnusedArg2")},
            {FunctionType.GetCasinoWinningStage, new TypeStringArgData(typeof(FormID), "Casino", null, "UnusedArg2")},
            {FunctionType.PlayerInRegion, new TypeStringArgData(typeof(FormID), "Region", null, "UnusedArg2")},
            {FunctionType.GetChallengeCompleted, new TypeStringArgData(typeof(FormID), "Challenge", null, "UnusedArg2")},
            {FunctionType.IsAlwaysHardcore, new TypeStringArgData(null, "UnusedArg1", null, "UnusedArg2")}
        };
        #endregion

        #region VATSValues
        private static Dictionary<VATSValue, TypeStringArgData> VATSMetadata = new Dictionary<VATSValue, TypeStringArgData>()
        {
            {VATSValue.WeaponIs, new TypeStringArgData(typeof(FormID), "Weapon")},
            {VATSValue.WeaponInList, new TypeStringArgData(typeof(FormID), "List")},
            {VATSValue.TargetIs, new TypeStringArgData(typeof(FormID), "BaseActor")},
            {VATSValue.TargetInList, new TypeStringArgData(typeof(FormID), "List")},
            {VATSValue.TargetDistance, new TypeStringArgData(null, "UnusedArg2")},
            {VATSValue.TargetPart, new TypeStringArgData(typeof(ActorValues), "TargetPart")},
            {VATSValue.VATSAction, new TypeStringArgData(typeof(VATSAction), "Action")},
            {VATSValue.IsSuccess, new TypeStringArgData(null, "UnusedArg2")},
            {VATSValue.IsCritical, new TypeStringArgData(null, "UnusedArg2")},
            {VATSValue.CriticalEffectIs, new TypeStringArgData(typeof(FormID), "Effect")},
            {VATSValue.CriticalEffectInList, new TypeStringArgData(typeof(FormID), "List")},
            {VATSValue.IsFatal, new TypeStringArgData(null, "UnusedArg2")},
            {VATSValue.ExplodePart, new TypeStringArgData(null, "UnusedArg2")},
            {VATSValue.DismemberPart, new TypeStringArgData(null, "UnusedArg2")},
            {VATSValue.CripplePart, new TypeStringArgData(null, "UnusedArg2")},
            {VATSValue.WeaponTypeIs, new TypeStringArgData(typeof(WeaponCategory), "Category")},
            {VATSValue.IsStranger, new TypeStringArgData(null, "UnusedArg2")},
            {VATSValue.IsParalyzingPalm, new TypeStringArgData(null, "UnusedArg2")}
        };
        #endregion

        public FunctionType Type { get; set; }
        public dynamic Argument1 { get; set; }
        public string Arg1Label { get; set; }
        public Type Arg1Type { get; set; }
        public dynamic Argument2 { get; set; }
        public string Arg2Label { get; set; }
        public Type Arg2Type { get; set; }

        public Function()
        {
            Type = new FunctionType();
            Argument1 = 0;
            Argument2 = 0;
        }

        public Function(FunctionType Type, dynamic Argument1 = null, dynamic Argument2 = null)
        {
            this.Type = Type;

            Arg1Label = Metadata[Type].Arg1Label;
            Arg1Type = Metadata[Type].Arg1Type;
            if (Arg1Type != null)
                if (Argument1.GetType() == Arg1Type)
                    this.Argument1 = Argument1;
                else throw new Exception("Argument1 is not " + Arg1Type);

            Arg2Label = Metadata[Type].Arg2Label;
            Arg2Type = Metadata[Type].Arg2Type;
            if (Arg2Type != null)
                if (Argument2.GetType() == Arg2Type)
                    this.Argument2 = Argument2;
                else throw new Exception("Argument2 is not " + Arg2Type);
        }

        public Function(Function copyObject)
        {
            Type = copyObject.Type;

            Argument1 = copyObject.Argument1;
            Arg1Label = Metadata[Type].Arg1Label;
            Arg1Type = Metadata[Type].Arg1Type;

            Argument2 = copyObject.Argument2;
            Arg2Label = Metadata[Type].Arg2Label;
            Arg2Type = Metadata[Type].Arg2Type;
        }

        public void ReadBinary(ESPReader reader)
        {
            Type = (FunctionType)reader.ReadUInt32();

            TypeStringArgData data;

            if (Metadata.TryGetValue(Type, out data))
            {
                Arg1Label = data.Arg1Label;
                Arg2Label = data.Arg2Label;
                Arg1Type = data.Arg1Type;
                Arg2Type = data.Arg2Type;

                if (Arg1Type == null)
                    Argument1 = reader.ReadBytes(4);
                else if (Arg1Type == typeof(FormID))
                    Argument1 = new FormID(reader.ReadUInt32());
                else if (Arg1Type == typeof(VATSValue))
                {
                    Argument1 = (VATSValue)reader.ReadUInt32();

                    TypeStringArgData tempData;
                    VATSMetadata.TryGetValue(Argument1, out tempData);

                    Arg2Type = tempData.Arg1Type;
                    Arg2Label = tempData.Arg1Label;
                }
                else if (Arg1Type.IsEnum)
                    Argument1 = Enum.ToObject(Arg1Type, reader.ReadUInt32());
                else throw new ArgumentException(Arg1Type.ToString() + " is not handled.");

                if (Arg2Type == null)
                    Argument2 = reader.ReadBytes(4);
                else if (Arg2Type == typeof(FormID))
                    Argument2 = new FormID(reader.ReadUInt32());
                else if (Arg2Type.IsEnum)
                    Argument2 = Enum.ToObject(Arg2Type, reader.ReadUInt32());
                else if (Arg2Type == typeof(uint))
                    Argument2 = reader.ReadUInt32();
                else throw new ArgumentException(Arg2Type.ToString() + " is not handled.");
            }
            else throw new Exception(Type.ToString() + " was not in the dictionary.");
        }

        public void WriteBinary(ESPWriter writer)
        {
            writer.Write((uint)Type);

            if (Arg1Type == null)
                writer.Write(Argument1);
            else if (Arg1Type == typeof(FormID))
                Argument1.WriteBinary(writer);
            else if (Arg1Type.IsEnum)
                writer.Write((int)Argument1);
            else throw new ArgumentException(Arg1Type.ToString() + " is not handled.");

            if (Arg2Type == null)
                writer.Write(Argument2);
            else if (Arg2Type == typeof(FormID))
                writer.Write((FormID)Argument2);
            else if (Arg2Type.IsEnum)
                writer.Write((int)Argument2);
            else if (Arg2Type == typeof(uint))
                writer.Write(Argument2);
            else throw new ArgumentException(Arg2Type.ToString() + " is not handled.");
        }

        public void WriteXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            ele.TryPathTo("Type", true, out subEle);
            subEle.Value = Type.ToString();

            ele.TryPathTo(Arg1Label, true, out subEle);
            if (Arg1Type == null)
                subEle.Value = ((byte[])Argument1).ToHex();
            else if (Arg1Type == typeof(FormID))
                Argument1.WriteXML(subEle, master);
            else if (Arg1Type.IsEnum)
                subEle.Value = Argument1.ToString();
            else throw new ArgumentException(Arg1Type.ToString() + " is not handled.");

            ele.TryPathTo(Arg2Label, true, out subEle);
            if (Arg2Type == null)
                subEle.Value = ((byte[])Argument2).ToHex();
            else if (Arg2Type == typeof(FormID))
                Argument2.WriteXML(subEle, master);
            else if (Arg2Type.IsEnum)
                subEle.Value = Argument2.ToString();
            else if (Arg2Type == typeof(uint))
                subEle.Value = Argument2.ToString();
            else throw new ArgumentException(Arg2Type.ToString() + " is not handled.");
        }

        public void ReadXML(XElement ele, ElderScrollsPlugin master)
        {
            XElement subEle;

            if (ele.TryPathTo("Type", false, out subEle))
            {
                Type = subEle.ToEnum<FunctionType>();
            }

            TypeStringArgData data;

            if (Metadata.TryGetValue(Type, out data))
            {
                Arg1Label = data.Arg1Label;
                Arg2Label = data.Arg2Label;
                Arg1Type = data.Arg1Type;
                Arg2Type = data.Arg2Type;

                if (ele.TryPathTo(Arg1Label, false, out subEle))
                {
                    if (Arg1Type == null)
                        Argument1 = subEle.ToBytes();
                    else if (Arg1Type == typeof(FormID))
                    {
                        Argument1 = new FormID();
                        Argument1.ReadXML(subEle, master);
                    }
                    else if (Arg1Type == typeof(VATSValue))
                    {
                        Argument1 = subEle.ToEnum<VATSValue>();

                        TypeStringArgData tempData;

                        if (VATSMetadata.TryGetValue(Argument1, out tempData))
                        {
                            Arg2Type = tempData.Arg1Type;
                            Arg2Label = tempData.Arg1Label;
                        }
                        else throw new ArgumentException("VATSValue " + Argument1.ToString() + " is not handled.");
                    }
                    else if (Arg1Type.IsEnum)
                        Argument1 = Enum.Parse(Arg1Type, subEle.Value);
                    else throw new ArgumentException(Arg1Type.ToString() + " is not handled.");
                }
                
                if (ele.TryPathTo(Arg2Label, false, out subEle))
                {
                    if (Arg2Type == null)
                        Argument2 = subEle.ToBytes();
                    else if (Arg2Type == typeof(FormID))
                    {
                        Argument2 = new FormID();
                        Argument2.ReadXML(subEle, master);
                    }
                    else if (Arg2Type.IsEnum)
                        Argument2 = Enum.Parse(Arg2Type, subEle.Value);
                    else if (Arg2Type == typeof(uint))
                        Argument2 = subEle.ToUInt32();
                    else throw new ArgumentException(Arg2Type.ToString() + " is not handled.");
                }
            }
            else throw new Exception(Type.ToString() + " was not in the dictionary.");
        }

        public object Clone()
        {
            return new Function(this);
        }

        public int CompareTo(Function other)
        {
            return Type.CompareTo(other.Type);
        }

        public static bool operator >(Function objA, Function objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(Function objA, Function objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(Function objA, Function objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(Function objA, Function objB)
        {
            return objA.CompareTo(objB) <= 0;
        }

        public bool Equals(Function other)
        {
            return Type == other.Type &&
                Argument1 == other.Argument1 &&
                Arg1Label == other.Arg1Label &&
                Arg1Type == other.Arg1Type &&
                Argument2 == other.Argument2 &&
                Arg2Label == other.Arg2Label &&
                Arg2Type == other.Arg2Type;
        }

        public override bool Equals(object obj)
        {
            Function other = obj as Function;
            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(Function objA, Function objB)
        {
            return objA.Equals(objB);
        }

        public static bool operator !=(Function objA, Function objB)
        {
            return !objA.Equals(objB);
        }
    }
}
