using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    [DefOf]
    public static class ThingDefOf
    {
        static ThingDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
        }
        public static ThingDef MorrowRim_Werewolf;
        public static ThingDef MorrowRim_AvatarOfHircine;
        public static ThingDef MorrowRim_WerewolfLord;

        public static ThingDef MorrowRim_TotemGuile;
        public static ThingDef MorrowRim_TotemSight;
        public static ThingDef MorrowRim_TotemSpeed;
        public static ThingDef MorrowRim_TotemStrength;
        public static ThingDef MorrowRim_TotemWerewolfLord;
    }
}
