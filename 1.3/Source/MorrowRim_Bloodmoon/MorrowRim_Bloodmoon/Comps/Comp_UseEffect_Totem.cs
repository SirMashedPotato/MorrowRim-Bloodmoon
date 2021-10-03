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
				usedBy.health.AddHediff(Props.hediffToApply).Severity = ModSettings_Utility.HuntersGiftBuildup();
			}
			else
			{
				Hediff hediff = usedBy.health.hediffSet.GetFirstHediffOfDef(Props.hediffToApply);

				if (hediff.Severity + ModSettings_Utility.HuntersGiftBuildup() >= ModSettings_Utility.HuntersGiftMaximum())
                {
					hediff.Severity = ModSettings_Utility.HuntersGiftMaximum();
				} 
				else
                {
					hediff.Severity += ModSettings_Utility.HuntersGiftBuildup();
				}
			}
		}

        public override bool CanBeUsedBy(Pawn p, out string failReason)
        {
			Hediff h = p.health.hediffSet.GetFirstHediffOfDef(Props.hediffToApply);
			if (h != null && h.Severity >= ModSettings_Utility.HuntersGiftMaximum())
            {
				failReason = "Bloodmoon_capacityMaxed".Translate(p.Name, h.Label);
				return false;
            }
            return base.CanBeUsedBy(p, out failReason);
        }
    }
}