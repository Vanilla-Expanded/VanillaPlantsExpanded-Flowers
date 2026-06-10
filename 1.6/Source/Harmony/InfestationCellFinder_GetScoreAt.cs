using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System;
using VEF.Plants;

namespace VanillaPlantsExpandedFlowers
{

    [HarmonyPatch(typeof(InfestationCellFinder))]
    [HarmonyPatch("GetScoreAt")]
    public static class VanillaPlantsExpandedFlowers_InfestationCellFinder_GetScoreAt_Patch
    {
        [HarmonyPostfix]
        public static void DetectBloomingMarigold(IntVec3 cell, Map map, ref float __result)
        {
            Region region = cell.GetRegion(map);
            if (region != null)
            {
                if (region.ListerThings.AnyThingWithDef(InternalDefOf.VPEF_Plant_Marigold)){

                    foreach(Thing thing in region.ListerThings.ThingsOfDef(InternalDefOf.VPEF_Plant_Marigold))
                    {
                        Plant_Blooming plantBlooming = thing as Plant_Blooming;
                        if(plantBlooming?.isBlooming == true)
                        {
                            __result = 0;
                        }
                    }

                }
            }

        }


    }


}











