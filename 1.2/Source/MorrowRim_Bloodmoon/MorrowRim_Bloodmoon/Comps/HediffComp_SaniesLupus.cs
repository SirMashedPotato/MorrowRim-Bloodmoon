using Verse;

namespace MorrowRim_Bloodmoon
{
    class HediffComp_SaniesLupus : HediffComp
    {
        public HediffCompProperties_SaniesLupus Props
        {
            get
            {
                return (HediffCompProperties_SaniesLupus)this.props;
            }
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            Pawn pawn = parent.pawn;
            Hediff hediff = parent;
            if(hediff.Severity + severityAdjustment >= 1.0f && !hediff.FullyImmune())
            {
                pawn.health.RemoveHediff(pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_SaniesLupinus, false));
                pawn.health.AddHediff(HediffDefOf.MorrowRim_DormantSaniesLupinus);
            }
            base.CompPostTick(ref severityAdjustment);
        }
    }
}
