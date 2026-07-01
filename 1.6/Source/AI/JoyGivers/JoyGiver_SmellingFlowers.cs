using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using VEF.Plants;
using Verse;
using Verse.AI;

namespace VanillaPlantsExpandedFlowers
{
    public class JoyGiver_SmellingFlowers : JoyGiver
    {
        private static readonly List<Thing> candidates = new List<Thing>();

        public override Job TryGiveJob(Pawn pawn)
        {
          
            bool allowedOutside = JoyUtility.EnjoyableOutsideNow(pawn);
            try
            {
                candidates.AddRange(pawn.Map.listerThings.ThingsInGroup(ThingRequestGroup.Plant).Where(delegate (Thing thing)
                {
                    if (!Validator(thing))
                    {
                        
                        return false;
                    }               
                  
                    return true;
                }));
                if (!candidates.TryRandomElementByWeight((Thing target) => Math.Max(target.GetStatValue(StatDefOf.Beauty), 0.5f), out var result))
                {
                    return null;
                }
                return JobMaker.MakeJob(def.jobDef, result);
            }
            finally
            {
                candidates.Clear();
            }
            bool Validator(Thing thing)
            {
               
                Plant_Blooming plant = thing as Plant_Blooming;
                if (plant is null) return false; 
                if (!plant.isBlooming || plant.LeaflessNow || plant.GetExtension.DisableJoyGiver) return false;
                
                if (!thing.Fogged()  && pawn.CanReserveAndReach(thing, PathEndMode.Touch, Danger.None))
                {
                  
                    return !thing.IsForbidden(pawn);
                }
                return false;
            }
        }
    }
}