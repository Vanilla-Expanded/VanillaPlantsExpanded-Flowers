using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System;

namespace VanillaPlantsExpandedFlowers
{

    [HarmonyPatch(typeof(PlantUtility))]
    [HarmonyPatch("CanSowOnGrower")]
    public static class VanillaPlantsExpandedFlowers_PlantUtility_CanSowOnGrower_Patch
    {
        [HarmonyPostfix]
        public static void SowTagsOnBloomingPlants(ThingDef plantDef, object obj, ref bool __result)
        {
            if (obj is Zone_BloomingFlowerZone)
            {
                __result = plantDef.plant.sowTags.Contains("VPE_Blooming");
            }
          

        }


    }


}











