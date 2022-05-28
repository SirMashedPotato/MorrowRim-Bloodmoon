using RimWorld;
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
            return Bloodmoon_ModSettings.EnableBloodmoonTracker ? AlertReport.Active : AlertReport.Inactive;
        }

        public override TaggedString GetExplanation()
        {
            return "Bloodmoon_Alert_WerewolfTrackerDescription".Translate(BloodmoonWorldComp.GetBloodStrength() * 100);
        }
    }
}
