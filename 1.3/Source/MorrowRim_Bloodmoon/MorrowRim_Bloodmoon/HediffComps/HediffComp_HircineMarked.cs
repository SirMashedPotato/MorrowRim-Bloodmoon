using Verse;
using RimWorld;
using UnityEngine;
using System.Collections.Generic;

namespace MorrowRim_Bloodmoon
{
    class HediffComp_HircineMarked : HediffComp
    {

		public HediffCompProperties_HircineMarked Props
		{
			get
			{
				return (HediffCompProperties_HircineMarked)this.props;
			}
		}

        public override void Notify_PawnKilled()
        {
            base.Notify_PawnKilled();
            Pawn pawn = parent.pawn;
            FleckMaker.AttachedOverlay(pawn, FleckDefOf.PsycastAreaEffect, Vector3.zero, 1f, -1f);
            IncidentParms incidentParms = StorytellerUtility.DefaultParmsNow(IncidentDefOf.ResourcePodCrash.category, pawn.Map);
            IncidentDef incidentDef = IncidentDefOf.ResourcePodCrash;
            incidentDef.Worker.TryExecute(incidentParms);
        }

        public override void CompPostPostRemoved()
        {
            Pawn pawn = parent.pawn;
            base.CompPostPostRemoved();
            Messages.Message("Bloodmoon_animalLostMarked".Translate(pawn), pawn, MessageTypeDefOf.NeutralEvent, true);
        }

        private int ticks = 0;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            ticks++;
            if (ticks >= 150)
            {
                if (!parent.pawn.Spawned)
                {
                    parent.pawn.health.RemoveHediff(this.parent);
                }
                FleckMaker.AttachedOverlay(parent.pawn, FleckDefOf.MicroSparks, Vector3.zero, 1f, -1f);
                ticks = 0;
            }
        }
    }
}
