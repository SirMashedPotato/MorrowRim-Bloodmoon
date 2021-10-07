using System;
using Verse;
using RimWorld;
using RimWorld.Planet;

namespace MorrowRim_Bloodmoon
{
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

        public static void IncrementStrength()
        {
            currentStrength += 5;
            Messages.Message("Bloodmoon_strengthScalingMessage".Translate(ModSettings_Utility.GetBloodStrength()), null, MessageTypeDefOf.CautionInput, true);
        }

        public static int GetStrength()
        {
            return currentStrength;
        }

        public static int currentStrength = 0;
    }
}
