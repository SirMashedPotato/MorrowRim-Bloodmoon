using System;
using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace MorrowRim_Bloodmoon
{
    class Alert_BloodmoonTracker : Alert
    {
        public Alert_BloodmoonTracker()
        {
            this.defaultLabel = "Bloodmoon_Alert_TrackerLabel".Translate();
            this.defaultPriority = AlertPriority.Medium;
        }

        public override AlertReport GetReport()
        {
            return ModSettings_Utility.EnableStrengthScaling() ? AlertReport.Active : AlertReport.Inactive;
        }

        public override TaggedString GetExplanation()
        {
            return "Bloodmoon_Alert_WerewolfTrackerDescription".Translate(ModSettings_Utility.GetBloodStrength() * 100);
        }
    }
}
