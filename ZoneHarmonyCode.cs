using EmeraldSlime;
using HarmonyLib;
using MonomiPark.SlimeRancher.Regions;
using SimpleSRmodLibrary.Ids.testIds;

namespace OreSlimes
{
    [HarmonyPatch(typeof(ZoneDirector), nameof(ZoneDirector.GetRegionSetId))]
    internal static class ZoneDirector_GetRegionSetId_Patch
    {
        internal static bool Prefix(ZoneDirector.Zone zone, ref RegionRegistry.RegionSetId __result)
        {
            if (System.Environment.StackTrace.Split('\n').Length > 20)
                throw new System.Exception("Too much stack");

            if (zone == Ids.ORE_ZONE)
            {
                __result = RegionRegistry.RegionSetId.HOME;
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(PlayerZoneTracker), "OnEntered")]
    class Patch_ZoneTracker
    {
        static void Postfix(ZoneDirector.Zone zone)
        {
            if (System.Environment.StackTrace.Split('\n').Length > 20)
                throw new System.Exception("Too much stack");

            if (zone == Ids.ORE_ZONE)
                SceneContext.Instance.PediaDirector.MaybeShowPopup(Ids.PEDIA_ORE_ZONE);
        }
    }
}