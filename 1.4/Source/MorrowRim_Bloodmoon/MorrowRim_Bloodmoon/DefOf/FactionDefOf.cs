using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    [DefOf]
    public static class FactionDefOf
    {
        static FactionDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(FactionDefOf));
        }
        public static FactionDef MorrowRim_HoundsOfHircine;
    }
}
