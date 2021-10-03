using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    class CompProperties_UseEffect_Totem : CompProperties_UseEffect
    {
        public CompProperties_UseEffect_Totem()
        {
            this.compClass = typeof(Comp_UseEffect_Totem);
        }
        public HediffDef hediffToApply = null;
    }
}