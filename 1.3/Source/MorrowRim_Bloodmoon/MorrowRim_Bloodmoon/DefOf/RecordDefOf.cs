using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    [DefOf]
    public static class RecordDefOf
    {
        static RecordDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(RecordDefOf));
        }
        public static RecordDef MorrowRim_BloodmoonsSurvived;
    }
}