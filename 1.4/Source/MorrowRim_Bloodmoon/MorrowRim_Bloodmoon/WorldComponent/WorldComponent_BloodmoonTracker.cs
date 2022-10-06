using System;
using Verse;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;

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

        public static void DecreaseStrength()
        {
            World world = Find.World;
            if (world != null)
            {
                world.GetComponent<WorldComponent_BloodmoonTracker>().DecreaseStrength();
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

        public static float GetBloodStrength()
        {
            if (Bloodmoon_ModSettings.EnableStrengthScaling)
            {
                float sev = Bloodmoon_ModSettings.SettingToFloat(Bloodmoon_ModSettings.WerewolfStrength + GetStrength());
                return sev > 1f ? 1f : sev;
            }
            return Bloodmoon_ModSettings.SettingToFloat(Bloodmoon_ModSettings.WerewolfStrength);
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
            Find.LetterStack.ReceiveLetter("Bloodmoon_LetterLabelstrengthScaling".Translate(), "Bloodmoon_strengthScalingMessage".Translate(BloodmoonWorldComp.GetBloodStrength() * 100), LetterDefOf.NegativeEvent);
        }

        public void DecreaseStrength()
        {
            int original = currentStrength;
            currentStrength = Mathf.Clamp(currentStrength - 10, 0, 100);
            if (original != currentStrength)
            {
                Find.LetterStack.ReceiveLetter("Bloodmoon_LetterLabelstrengthWeakened".Translate(), "Bloodmoon_strengthWeakenedMessage".Translate(BloodmoonWorldComp.GetBloodStrength() * 100), LetterDefOf.PositiveEvent);
            }
        }

        public int GetStrength()
        {
            return currentStrength;
        }

        public int currentStrength = 0;
    }
}
