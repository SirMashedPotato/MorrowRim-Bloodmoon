using RimWorld;
using Verse;

namespace MorrowRim_Bloodmoon
{
    class DamageWorker_HunterStab : DamageWorker_Stab
    {
		public override DamageWorker.DamageResult Apply(DamageInfo dinfo, Thing victim)
		{
			Pawn pawn = victim as Pawn;
			if (pawn != null && pawn.Faction == Faction.OfPlayer)
			{
				Find.TickManager.slower.SignalForceNormalSpeedShort();
			}
			DamageWorker.DamageResult damageResult = base.Apply(dinfo, victim);

			if (ValidTarget(pawn))
			{
				damageResult.totalDamageDealt *= 1.5f;
			}
			return damageResult;
		}

		public static bool ValidTarget(Pawn victim)
		{
			return victim != null && ((victim.RaceProps.IsFlesh && victim.AnimalOrWildMan()) || victim.def == ThingDefOf.MorrowRim_Werewolf);
		}
	}
}
