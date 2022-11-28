using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld.Planet;
using Verse;
using RimWorld;

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
            return Bloodmoon_ModSettings.EnableBloodmoonTracker ? AlertReport.Active : AlertReport.Inactive;
        }

        public override TaggedString GetExplanation()
        {
            string description = "";
            bool flag = false;
            if (Bloodmoon_ModSettings.EnableStrengthScaling)
            {
                description += "Bloodmoon_Alert_WerewolfTrackerDescription".Translate(BloodmoonWorldComp.GetBloodStrength() * 100);
                flag = true;
            }
            if (Utility.CheckStoryteller())
            {
                if (flag)
                {
                    description += "\n\n";
                }
                int num = GetExpectednextDays();
                description += "Bloodmoon_Alert_BloodmoonTrackerDescription".Translate(num < 0 ? 0 : num);
            }

            return description;
        }

        public int GetExpectednextDays()
        {

            Dictionary<IncidentDef, int> lastFireTicks = Find.World.StoryState.lastFireTicks;
            int num;
            if (lastFireTicks.TryGetValue(IncidentDefOf.MorrowRim_Bloodmoon, out num))
            {
                return (int)(num.TicksToDays() + Bloodmoon_ModSettings.IncidentIntervalCycle) - GenDate.DaysPassedSinceSettle;
            }
            //not sure if this bit is acutally necessary
            List<IncidentDef> refireCheckIncidents = IncidentDefOf.MorrowRim_Bloodmoon.RefireCheckIncidents;
            if (refireCheckIncidents != null)
            {
                for (int i = 0; i < refireCheckIncidents.Count; i++)
                {
                    if (lastFireTicks.TryGetValue(refireCheckIncidents[i], out num))
                    {
                        return (int)(num.TicksToDays() + Bloodmoon_ModSettings.IncidentIntervalCycle) - GenDate.DaysPassedSinceSettle;
                    }
                }
            }

            return Bloodmoon_ModSettings.IncidentMinimumDaysCycle - GenDate.DaysPassedSinceSettle;
        }
    }
}
