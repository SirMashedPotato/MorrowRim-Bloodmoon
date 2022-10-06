using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    class CompTargetEffect_Lycanthropy : CompTargetEffect
    {
		public override void DoEffectOn(Pawn user, Thing target)
		{
			Pawn pawn = (Pawn)target;
			if (pawn.Dead || pawn.NonHumanlikeOrWildMan())
			{
				return;
			}
			Bloodmoon_Utility.ActivateLycanthropy(pawn, false);
			Find.BattleLog.Add(new BattleLogEntry_ItemUsed(user, target, this.parent.def, RulePackDefOf.Event_ItemUsed));
			
		}
	}
}