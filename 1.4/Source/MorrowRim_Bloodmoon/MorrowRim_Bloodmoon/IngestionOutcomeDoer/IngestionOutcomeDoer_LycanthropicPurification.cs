using RimWorld;
using Verse;

namespace MorrowRim_Bloodmoon
{
    class IngestionOutcomeDoer_LycanthropicPurification : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            if(Utility.ROMWerewolvesLoaded())
            {
                if (pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_DormantSaniesLupinus) != null && !Utility.ROMWerewolves_CheckTrait(pawn))
                {
                    if (!Utility.ElixirQualityCheck(ingested))
                    {
                        Bloodmoon_Utility.ActivateLycanthropy(pawn);
                    } 
                    else
                    {
                        pawn.health.RemoveHediff(pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_DormantSaniesLupinus));
                        Utility.ROMWerewolves_GiveTrait(pawn);
                    }
                }
            }
        }
    }
}