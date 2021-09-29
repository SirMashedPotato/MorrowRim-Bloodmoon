using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    class IncidentWorker_MakeGameCondition : IncidentWorker
	{
		protected override bool CanFireNowSub(IncidentParms parms)
		{
			if (!base.CanFireNowSub(parms) || !Utility.HircineIncidentCheck() || FiredTooRecently_Setting(parms.target))
			{
				return false;
			}
			GameConditionManager gameConditionManager = parms.target.GameConditionManager;
			if (gameConditionManager == null)
			{
				Log.ErrorOnce(string.Format("Couldn't find condition manager for incident target {0}", parms.target), 70849667);
				return false;
			}
			if (gameConditionManager.ConditionIsActive(this.def.gameCondition))
			{
				return false;
			}
			List<GameCondition> activeConditions = gameConditionManager.ActiveConditions;
			for (int i = 0; i < activeConditions.Count; i++)
			{
				if (!this.def.gameCondition.CanCoexistWith(activeConditions[i].def))
				{
					return false;
				}
			}
			return true;
		}

		public bool FiredTooRecently_Setting(IIncidentTarget target)
        {
			Dictionary<IncidentDef, int> lastFireTicks = target.StoryState.lastFireTicks;
			int ticksGame = Find.TickManager.TicksGame;
			int num;
			if (lastFireTicks.TryGetValue(this.def, out num) && (float)(ticksGame - num) / 60000f < ModSettings_Utility.IntervalCycle())
			{
				return true;
			}
			List<IncidentDef> refireCheckIncidents = this.def.RefireCheckIncidents;
			if (refireCheckIncidents != null)
			{
				for (int i = 0; i < refireCheckIncidents.Count; i++)
				{
					if (lastFireTicks.TryGetValue(refireCheckIncidents[i], out num) && (float)(ticksGame - num) / 60000f < ModSettings_Utility.IntervalCycle())
					{
						return true;
					}
				}
			}
			return false;
		}

		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			GameConditionManager gameConditionManager = parms.target.GameConditionManager;
			int duration = Mathf.RoundToInt(this.def.durationDays.RandomInRange * 60000f);
			GameCondition gameCondition = GameConditionMaker.MakeCondition(this.def.gameCondition, duration);
			gameConditionManager.RegisterCondition(gameCondition);
			parms.letterHyperlinkThingDefs = gameCondition.def.letterHyperlinks;
			base.SendStandardLetter(this.def.letterLabel, gameCondition.LetterText, this.def.letterDef, parms, LookTargets.Invalid);
			return true;
		}
	}
}
