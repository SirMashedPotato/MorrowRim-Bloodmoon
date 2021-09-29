using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    [DefOf]
    class StorytellerDefOf : DefOf
    {
        static StorytellerDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(StorytellerDefOf));
        }
        public static StorytellerDef MorrowRim_Hircine;
    }
}
