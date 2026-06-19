using System;
using UnityEngine;
using Verse;
using RimWorld;

namespace VanillaPlantsExpandedFlowers
{
    public class Designator_BloomingFlowerGrowingZone : Designator_ZoneAdd
    {
        protected override string NewZoneLabel
        {
            get
            {
                return "VPE_BloomingFlowerZone".Translate();
            }
        }

        public Designator_BloomingFlowerGrowingZone()
        {

            this.zoneTypeToPlace = typeof(Zone_BloomingFlowerZone);
            this.defaultLabel = "VPE_BloomingFlowerZone".Translate();
            this.defaultDesc = "VPE_BloomingFlowerZoneDesc".Translate();
            this.icon = ContentFinder<Texture2D>.Get("UI/Designators/MakeFlowerZone", true);
            this.hotKey = KeyBindingDefOf.Misc2;

            this.tutorTag = "ZoneAdd_Growing";
        }

        public override AcceptanceReport CanDesignateCell(IntVec3 c)
        {
            if (!base.CanDesignateCell(c).Accepted)
            {
                return false;
            }
            float num = (ModsConfig.BiotechActive ? 0.5f : InternalDefOf.VPEF_Plant_RedRoseBush.plant.fertilityMin);
            if (ModsConfig.IdeologyActive && BuildCopyCommandUtility.FindAllowedDesignator(TerrainDefOf.FungalGravel) != null)
            {
                num = Mathf.Min(num, ThingDefOf.Plant_Nutrifungus.plant.fertilityMin);
            }
            if (c.GetFertility(Map) < num)
            {
                return false;
            }
            return true;
        }

        protected override Zone MakeNewZone()
        {
            PlayerKnowledgeDatabase.KnowledgeDemonstrated(ConceptDefOf.GrowingFood, KnowledgeAmount.Total);
            return new Zone_BloomingFlowerZone(Find.CurrentMap.zoneManager);
        }
    }
}
