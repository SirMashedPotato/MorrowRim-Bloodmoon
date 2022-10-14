using Verse;
using RimWorld;
using UnityEngine;
using System.Collections.Generic;
using RimWorld.Planet;

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

        public Site site;

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_References.Look(ref site, "markedAnimal_site");
        }

        public override void Notify_PawnKilled()
        {
            base.Notify_PawnKilled();
            Pawn pawn = parent.pawn;
            FleckMaker.AttachedOverlay(pawn, FleckDefOf.PsycastAreaEffect, Vector3.zero, 1f, -1f);
            if (Props.sendRewards)
            {
                for(int i = 0; i < Props.numRewards; i++)
                {
                    IncidentParms incidentParms = StorytellerUtility.DefaultParmsNow(IncidentDefOf.ResourcePodCrash.category, pawn.Map);
                    IncidentDef incidentDef = IncidentDefOf.ResourcePodCrash;
                    incidentDef.Worker.TryExecute(incidentParms);
                }
            }
            if (Props.questEnd && site != null)
            {
                QuestUtility.SendQuestTargetSignals(site.questTags, "GreatBeastSlain", this.Named("SUBJECT"));
            }
        }

        public override void CompPostPostRemoved()
        {
            Pawn pawn = parent.pawn;
            base.CompPostPostRemoved();
            if (Props.displayMessage)
            {
                Messages.Message("Bloodmoon_animalLostMarked".Translate(pawn), pawn, MessageTypeDefOf.NeutralEvent, true);
            }
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
