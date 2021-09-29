using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
	public class IngestionOutcomeDoer_GiveHediff : IngestionOutcomeDoer
	{
		protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
		{
			float q = 1;
			ingested.TryGetQuality(out QualityCategory qc);
			if (qc != QualityCategory.Legendary)
			{
				q = (float)qc + 1;
				q /= 10;
			}
			Hediff hediff = HediffMaker.MakeHediff(Hediff, pawn, null);
			hediff.Severity = q;
			pawn.health.AddHediff(hediff, null, null, null);

		}

		public HediffDef Hediff;

	}
}
