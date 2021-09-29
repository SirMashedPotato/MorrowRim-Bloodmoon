using RimWorld;
using Verse;

namespace MorrowRim_Bloodmoon
{
    class IngestionOutcomeDoer_LycanthropicAssimilation : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            if (pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_DormantSaniesLupinus) != null)
            {
                if (!Utility.ElixirQualityCheck(ingested))
                {
                    Bloodmoon_Utility.ActivateLycanthropy(pawn);
                }
                else
                {
                    pawn.health.RemoveHediff(pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_DormantSaniesLupinus));
                    pawn.health.AddHediff(HediffDefOf.MorrowRim_AssimilatedLycanthropy);
                }
            }
        }
    }
}