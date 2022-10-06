using System;
using Verse.AI;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    [DefOf]
    class DutyDefOf : DefOf
    {
        static DutyDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(DutyDefOf));
        }
        public static DutyDef MorrowRim_HuntColony;
    }
}
