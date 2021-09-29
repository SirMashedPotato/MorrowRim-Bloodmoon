using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    class Comp_UseEffect_Totem : CompUseEffect
    {
		public CompProperties_UseEffect_Totem Props
		{
			get
			{
				return (CompProperties_UseEffect_Totem)this.props;
			}
		}

		public override void DoEffect(Pawn usedBy)
		{
			base.DoEffect(usedBy);
			if (!usedBy.health.hediffSet.HasHediff(Props.hediffToApply)){
				usedBy.health.AddHediff(Props.hediffToApply).Severity = Props.increase;
			}
			else
			{
				usedBy.health.hediffSet.GetFirstHediffOfDef(Props.hediffToApply).Severity += Props.increase;
			}
		}

        public override bool CanBeUsedBy(Pawn p, out string failReason)
        {
			Hediff h = p.health.hediffSet.GetFirstHediffOfDef(Props.hediffToApply);
			if (h != null && h.Severity >= 1f)
            {
				failReason = "Bloodmoon_capacityMaxed".Translate(p.Name, h.Label);
				return false;
            }
            return base.CanBeUsedBy(p, out failReason);
        }
    }
}