using System;
using Verse;
using Verse.AI;
using Verse.AI.Group;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
	// Token: 0x0200077E RID: 1918
	public class LordJob_HuntColony : LordJob
	{
		// Token: 0x17000925 RID: 2341
		// (get) Token: 0x0600328A RID: 12938 RVA: 0x00010451 File Offset: 0x0000E651
		public override bool GuiltyOnDowned
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600328B RID: 12939 RVA: 0x001198AE File Offset: 0x00117AAE
		public LordJob_HuntColony()
		{
		}

		// Token: 0x0600328C RID: 12940 RVA: 0x001198CC File Offset: 0x00117ACC
		public LordJob_HuntColony(SpawnedPawnParams parms)
		{
			this.assaulterFaction = parms.spawnerThing.Faction;
			this.canTimeoutOrFlee = false;
		}

		// Token: 0x0600328D RID: 12941 RVA: 0x0011991C File Offset: 0x00117B1C
		public LordJob_HuntColony(Faction assaulterFaction, bool canTimeoutOrFlee = true, bool useAvoidGridSmart = false)
		{
			this.assaulterFaction = assaulterFaction;
			this.canTimeoutOrFlee = canTimeoutOrFlee;
			this.useAvoidGridSmart = useAvoidGridSmart;
		}

		// Token: 0x0600328E RID: 12942 RVA: 0x00119974 File Offset: 0x00117B74
		public override StateGraph CreateGraph()
		{
			StateGraph stateGraph = new StateGraph();
			LordToil lordToil = null;
			
			LordToil lordToil2 = new LordToil_HuntColony(true);
			if (this.useAvoidGridSmart)
			{
				lordToil2.useAvoidGrid = true;
			}
			stateGraph.AddToil(lordToil2);
			LordToil_ExitMap lordToil_ExitMap = new LordToil_ExitMap(LocomotionUrgency.Sprint, false, true);
			lordToil_ExitMap.useAvoidGrid = true;
			stateGraph.AddToil(lordToil_ExitMap);
			if (true)
			{
				if (this.canTimeoutOrFlee)
				{
					Transition transition3 = new Transition(lordToil2, lordToil_ExitMap, false, true);
					if (lordToil != null)
					{
						transition3.AddSource(lordToil);
					}
					transition3.AddTrigger(new Trigger_TicksPassed(AssaultTimeBeforeGiveUp.RandomInRange));
					transition3.AddPreAction(new TransitionAction_Message("MessageRaidersGivenUpLeaving".Translate(this.assaulterFaction.def.pawnsPlural.CapitalizeFirst(), this.assaulterFaction.Name), null, 1f));
					stateGraph.AddTransition(transition3, false);
					Transition transition4 = new Transition(lordToil2, lordToil_ExitMap, false, true);
					if (lordToil != null)
					{
						transition4.AddSource(lordToil);
					}
					FloatRange floatRange = new FloatRange(0.25f, 0.35f);
					float randomInRange = floatRange.RandomInRange;
					transition4.AddTrigger(new Trigger_FractionColonyDamageTaken(randomInRange, 900f));
					transition4.AddPreAction(new TransitionAction_Message("MessageRaidersSatisfiedLeaving".Translate(this.assaulterFaction.def.pawnsPlural.CapitalizeFirst(), this.assaulterFaction.Name), null, 1f));
					stateGraph.AddTransition(transition4, false);
				}
			}
			Transition transition7 = new Transition(lordToil2, lordToil_ExitMap, false, true);
			if (lordToil != null)
			{
				transition7.AddSource(lordToil);
			}
			transition7.AddTrigger(new Trigger_BecameNonHostileToPlayer());
			transition7.AddPreAction(new TransitionAction_Message("MessageRaidersLeaving".Translate(this.assaulterFaction.def.pawnsPlural.CapitalizeFirst(), this.assaulterFaction.Name), null, 1f));
			stateGraph.AddTransition(transition7, false);

			return stateGraph;
		}

		// Token: 0x0600328F RID: 12943 RVA: 0x00119D28 File Offset: 0x00117F28
		public override void ExposeData()
		{
			Scribe_References.Look<Faction>(ref this.assaulterFaction, "assaulterFaction", false);
			Scribe_Values.Look<bool>(ref this.canTimeoutOrFlee, "canTimeoutOrFlee", true, false);
			Scribe_Values.Look<bool>(ref this.useAvoidGridSmart, "useAvoidGridSmart", false, false);
		}

		// Token: 0x04001B92 RID: 7058
		private Faction assaulterFaction;

		// Token: 0x04001B94 RID: 7060
		private bool canTimeoutOrFlee = true;

		// Token: 0x04001B96 RID: 7062
		private bool useAvoidGridSmart;

		// Token: 0x04001B98 RID: 7064
		private static readonly IntRange AssaultTimeBeforeGiveUp = new IntRange(18000, 28000);

		// Token: 0x04001B99 RID: 7065
		private static readonly IntRange SapTimeBeforeGiveUp = new IntRange(23000, 28000);
	}
}
