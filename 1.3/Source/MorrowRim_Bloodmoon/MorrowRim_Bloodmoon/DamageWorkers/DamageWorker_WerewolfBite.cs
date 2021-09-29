using Verse;

namespace MorrowRim_Bloodmoon
{
    public class DamageWorker_WerewolfBite : DamageWorker_AddInjury
    {
		protected override BodyPartRecord ChooseHitPart(DamageInfo dinfo, Pawn pawn)
		{
			if (Bloodmoon_Utility.CanInfectPawn(pawn) && Utility.CheckAssimilatedLycanthropy(pawn) && Utility.CheckWolfsBane_Protection(pawn))
			{
				pawn.health.AddHediff(HediffDefOf.MorrowRim_SaniesLupinus).Severity = 0.01f;
			}
			if (Utility.CheckWolfsBane_Retaliation(pawn))
			{
				Utility.BurnWerewolf(dinfo.Instigator as Pawn);
			}
			return pawn.health.hediffSet.GetRandomNotMissingPart(dinfo.Def, dinfo.Height, BodyPartDepth.Outside, null);
		}
	}
}