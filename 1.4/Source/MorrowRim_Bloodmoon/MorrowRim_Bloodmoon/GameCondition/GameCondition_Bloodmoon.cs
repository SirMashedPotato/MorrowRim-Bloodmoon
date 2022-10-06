using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.Sound;
using RimWorld;
using RimWorld.Planet;
using Verse.AI.Group;
using System.Linq;


namespace MorrowRim_Bloodmoon
{
    class GameCondition_Bloodmoon : GameCondition
    {
		//baesd on GameCondition_NoSunlight
		public override int TransitionTicks
		{
			get
			{
				return 300;
			}
		}

        public override string Description
        {
			get
            {
                if (Bloodmoon_ModSettings.EnableStrengthScaling)
                {
					return "Bloodmoon_bloodmoonDescription".Translate(BloodmoonWorldComp.GetBloodStrength() * 100f);
				}
				return def.description;
			}
        }

        public override float SkyTargetLerpFactor(Map map)
		{
			return GameConditionUtility.LerpInOutValue(this, (float)this.TransitionTicks, 1f);
		}

		public override SkyTarget? SkyTarget(Map map)
		{
			return new SkyTarget?(new SkyTarget(0.8f, this.BloodmoonSkyColors, 1f, 0f));
		}

		private SkyColorSet BloodmoonSkyColors = new SkyColorSet(new Color(0.682f, 0.403f, 0.482f), Color.white, new Color(0.6f, 0.6f, 0.6f), 1f);
		/* 0.482f, 0.603f, 0.682f */

		//Special stuff
		private int currentTicks = 0;
		private int ticksPerEvent = 3000;
		private int markedTicks = 0;
		private int ticksPerMark = 2500;
		private bool bloodmoonBegun = false;


		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<int>(ref this.currentTicks, "currentTicks", 0, false);
			Scribe_Values.Look<int>(ref this.ticksPerEvent, "ticksPerEvent", 3000, false);
			Scribe_Values.Look<int>(ref this.markedTicks, "markedTicks", 0, false);
			Scribe_Values.Look<int>(ref this.ticksPerEvent, "ticksPerMark", 2500, false);
			Scribe_Values.Look<bool>(ref this.bloodmoonBegun, "bloodmoonBegun", false, false);
		}

		public override void GameConditionTick()
		{
			//do one off events
			if (!bloodmoonBegun && currentTicks >= this.TransitionTicks)
			{
                if (Bloodmoon_ModSettings.EnableBloodmoonTransforming)
                {
					ActivateLycanthropy();
				}
				foreach (Map map in AffectedMaps)
				{
					Bloodmoon_Utility.SpawnAvatarOfHircine(map);
				}
				bloodmoonBegun = true;
			}
			//do continuous events
			if(currentTicks >= ticksPerEvent)
			{
                if (this.AffectedMaps.Where(x => x != null && x.mapPawns != null && x.mapPawns.AnyColonistSpawned).Any())
                {
					Bloodmoon_Utility.DoBloodmoonRaid(this.AffectedMaps.Where(x => x != null && x.mapPawns != null && x.mapPawns.AnyColonistSpawned).RandomElement(), PawnKindDefOf.MorrowRim_Werewolf);
				}
				else if(CaravanUtility.PlayerHasAnyCaravan() && Bloodmoon_ModSettings.EnableBloodmoonAmbushes)
                {
					Caravan caravan = Find.WorldObjects.Caravans.RandomElement();
					if (caravan != null)
					{
						IncidentParms incidentParms = StorytellerUtility.DefaultParmsNow(IncidentDefOf.MorrowRim_BloodmoonCaravanAmbush.category, caravan);
						IncidentDef incidentDef = IncidentDefOf.MorrowRim_BloodmoonCaravanAmbush;
						incidentDef.Worker.TryExecute(incidentParms);
					}
				}
				

				if (Rand.Chance(Bloodmoon_ModSettings.SettingToFloat(Bloodmoon_ModSettings.ExtraAvatarChance)))
				{
					Bloodmoon_Utility.SpawnAvatarOfHircine(this.AffectedMaps.RandomElement());
				}
				currentTicks = 0;
				ticksPerEvent = Rand.RangeInclusive(Bloodmoon_ModSettings.MinTicksPerEvent, Bloodmoon_ModSettings.MaxTicksPerEvent);
			}
			if (Bloodmoon_ModSettings.AnimalMarking && markedTicks >= ticksPerMark)
			{
				Bloodmoon_Utility.AttemptToMarkAnimal(this.AffectedMaps.RandomElement());
				markedTicks = 0;
				ticksPerMark = Rand.RangeInclusive(Bloodmoon_ModSettings.MinTicksPerMark, Bloodmoon_ModSettings.MaxTicksPerMark);

			}
			markedTicks++;
			currentTicks++;
		}

		public override void End()
		{
			if (!AffectedMaps.NullOrEmpty()) 
			{
				foreach (Map map in AffectedMaps)
				{
					Bloodmoon_Utility.IncrementBloodmoonRecord(map);
					Bloodmoon_Utility.DestroyAvatarsOnMap(map);
					Bloodmoon_Utility.ClearMarksOnMap(map);

				}
				if (Bloodmoon_ModSettings.EnableLootDrops)
				{
					Map target = this.AffectedMaps.Where(x => x != null && x.mapPawns != null && x.mapPawns.AnyColonistSpawned).RandomElement();
					if (target != null)
					{
						Bloodmoon_Utility.DoLootDrops(target);
					}
				}
			}
            if (Bloodmoon_ModSettings.EnableStrengthScaling && this.AffectedMaps.Where(x => x != null && x.mapPawns != null && x.mapPawns.AnyColonistSpawned).Any())
            {
				BloodmoonWorldComp.IncrementStrength();
			}

			//send trigger


			base.End();
		}

		//function to activate all dormant lycanthropy
		private int ActivateLycanthropy()
		{
			int num = 0;
			foreach(Map map in this.AffectedMaps)
			{
				IEnumerable<Pawn> targets = Utility.GetColonyPawnDormantLycanthropy(map);
				if (!targets.EnumerableNullOrEmpty())
				{
					foreach (Pawn pawn in targets)
					{
						Bloodmoon_Utility.ActivateLycanthropy(pawn);
					}
				}
			}

			return num;
		}
	}
}
