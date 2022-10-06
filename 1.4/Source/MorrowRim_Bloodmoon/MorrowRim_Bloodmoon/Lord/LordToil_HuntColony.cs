using System;
using Verse.AI;
using Verse.AI.Group;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
	// Token: 0x020007A8 RID: 1960
	public class LordToil_HuntColony : LordToil
	{
		// Token: 0x1700095E RID: 2398
		// (get) Token: 0x0600339B RID: 13211 RVA: 0x00010451 File Offset: 0x0000E651
		public override bool ForceHighStoryDanger
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600339C RID: 13212 RVA: 0x0011F1A9 File Offset: 0x0011D3A9
		public LordToil_HuntColony(bool attackDownedIfStarving = false)
		{
			this.attackDownedIfStarving = attackDownedIfStarving;
		}

		// Token: 0x1700095F RID: 2399
		// (get) Token: 0x0600339D RID: 13213 RVA: 0x000104CA File Offset: 0x0000E6CA
		public override bool AllowSatisfyLongNeeds
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600339E RID: 13214 RVA: 0x0011F1B8 File Offset: 0x0011D3B8
		public override void Init()
		{
			base.Init();
			LessonAutoActivator.TeachOpportunity(ConceptDefOf.Drafting, OpportunityType.Critical);
		}

		// Token: 0x0600339F RID: 13215 RVA: 0x0011F1CC File Offset: 0x0011D3CC
		public override void UpdateAllDuties()
		{
			for (int i = 0; i < this.lord.ownedPawns.Count; i++)
			{
				this.lord.ownedPawns[i].mindState.duty = new PawnDuty(DutyDefOf.MorrowRim_HuntColony);
				this.lord.ownedPawns[i].mindState.duty.attackDownedIfStarving = this.attackDownedIfStarving;
			}
		}

		// Token: 0x04001BF8 RID: 7160
		private bool attackDownedIfStarving;
	}
}
