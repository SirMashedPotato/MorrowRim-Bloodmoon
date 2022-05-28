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
				usedBy.health.AddHediff(Props.hediffToApply).Severity = Bloodmoon_ModSettings.HuntersGiftBuildup;
			}
			else
			{
				Hediff hediff = usedBy.health.hediffSet.GetFirstHediffOfDef(Props.hediffToApply);

				if (hediff.Severity + Bloodmoon_ModSettings.HuntersGiftBuildup >= Bloodmoon_ModSettings.HuntersGiftMaximum)
                {
					hediff.Severity = Bloodmoon_ModSettings.HuntersGiftMaximum;
				} 
				else
                {
					hediff.Severity += Bloodmoon_ModSettings.HuntersGiftBuildup;
				}
			}
		}

        public override bool CanBeUsedBy(Pawn p, out string failReason)
        {
			Hediff h = p.health.hediffSet.GetFirstHediffOfDef(Props.hediffToApply);
			if (h != null && h.Severity >= Bloodmoon_ModSettings.HuntersGiftMaximum)
            {
				failReason = "Bloodmoon_capacityMaxed".Translate(p.Name, h.Label);
				return false;
            }
            return base.CanBeUsedBy(p, out failReason);
        }
    }
}