using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    [DefOf]
    public static class HediffDefOf
    {
        static HediffDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
        }
        public static HediffDef MorrowRim_SaniesLupinus;
        public static HediffDef MorrowRim_DormantSaniesLupinus;
        public static HediffDef MorrowRim_GiftOfSpeed;
        public static HediffDef MorrowRim_GiftOfStrength;
        public static HediffDef MorrowRim_GiftOfGuile;
        public static HediffDef MorrowRim_GiftOfSight;
        public static HediffDef MorrowRim_LycanthropicUnbinding;
        public static HediffDef MorrowRim_AssimilatedLycanthropy;
        public static HediffDef MorrowRim_WolfsbaneProtectionActive;
        public static HediffDef MorrowRim_WolfsbaneRetaliationActive;
        public static HediffDef MorrowRim_BloodOfHircine;
    }
}
