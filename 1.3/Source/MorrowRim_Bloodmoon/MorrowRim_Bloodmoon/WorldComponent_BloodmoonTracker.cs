using System;
using Verse;
using RimWorld;
using RimWorld.Planet;

namespace MorrowRim_Bloodmoon
{
    public static class BloodmoonWorldComp
    {
        public static void IncrementStrength()
        {
            World world = Find.World;
            if (world != null)
            {
                world.GetComponent<WorldComponent_BloodmoonTracker>().IncrementStrength();
            }
        }

        public static int GetStrength()
        {
            World world = Find.World;
            if (world != null)
            {
                return world.GetComponent<WorldComponent_BloodmoonTracker>().GetStrength();
            }
            return 0;
        }
    }

    class WorldComponent_BloodmoonTracker : WorldComponent
    {
        public WorldComponent_BloodmoonTracker(World world) : base(world)
        {
            
        }

        public override void WorldComponentTick()
        {
            base.WorldComponentTick();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref currentStrength, "Bloodmoon_currentStrength", 0);
            base.ExposeData();
        }

        public override void WorldComponentUpdate()
        {
            base.WorldComponentUpdate();
        }

        public void IncrementStrength()
        {
            currentStrength += 5;
            Find.LetterStack.ReceiveLetter("Bloodmoon_LetterLabelstrengthScaling".Translate(), "Bloodmoon_strengthScalingMessage".Translate(ModSettings_Utility.GetBloodStrength() * 100), LetterDefOf.NegativeEvent);
        }

        public int GetStrength()
        {
            return currentStrength;
        }

        public int currentStrength = 0;
    }
}
