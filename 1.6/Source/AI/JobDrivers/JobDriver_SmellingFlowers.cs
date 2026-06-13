using RimWorld;
using Verse;
using Verse.AI;

namespace VanillaPlantsExpandedFlowers
{
    public class JobDriver_SmellingFlowers : JobDriver_VisitJoyThing
    {
        private Thing Flower => job.GetTarget(TargetIndex.A).Thing;

        protected override void WaitTickAction(int delta)
        {
            float num = Flower.GetStatValue(StatDefOf.Beauty) / Flower.def.GetStatValueAbstract(StatDefOf.Beauty);
            float extraJoyGainFactor = ((num > 0f) ? num : 0f);
            pawn.GainComfortFromCellIfPossible(delta);
            JoyUtility.JoyTickCheckEnd(pawn, delta, JoyTickFullJoyAction.EndJob, extraJoyGainFactor);
        }
    }
}
