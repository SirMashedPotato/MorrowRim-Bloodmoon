using RimWorld;

namespace MorrowRim_Bloodmoon
{
    class SitePartWorker_WerewolfLord : SitePartWorker
	{
		public override bool IsAvailable()
		{
			return base.IsAvailable() && Bloodmoon_ModSettings.EnableWerewolfLord && Utility.HoundsFactionFound(def.label);
		}
	}
}
