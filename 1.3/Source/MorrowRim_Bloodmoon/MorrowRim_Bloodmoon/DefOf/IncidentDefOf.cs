using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    [DefOf]
    public static class IncidentDefOf
    {
        static IncidentDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(IncidentDefOf));
        }
        public static IncidentDef ResourcePodCrash;

        public static IncidentDef MorrowRim_Bloodmoon;
    }
}
