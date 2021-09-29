using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    [DefOf]
    public static class PawnKindDefOf
    {
        static PawnKindDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(PawnKindDefOf));
        }
        public static PawnKindDef MorrowRim_Werewolf;
        public static PawnKindDef MorrowRim_AvatarOfHircine;
        //public static PawnKindDef MorrowRim_Draugr;
    }
}
