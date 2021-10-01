using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld.Planet;
using RimWorld.QuestGen;
using UnityEngine;
using Verse;
using Verse.Grammar;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    class SitePartWorker_WerewolfPack : SitePartWorker
    {

        public override bool IsAvailable()
        {
            return base.IsAvailable() && ModSettings_Utility.EnableWerewolfPack();
        }

        public override void Init(Site site, SitePart sitePart)
        {
            base.Init(site, sitePart);

			sitePart.expectedEnemyCount = this.GetEnemiesCount(sitePart.parms);
		}

        public override string GetArrivedLetterPart(Map map, out LetterDef preferredLetterDef, out LookTargets lookTargets)
		{
			string arrivedLetterPart = base.GetArrivedLetterPart(map, out preferredLetterDef, out lookTargets);
			lookTargets = new LookTargets(map.Parent);
			return arrivedLetterPart;
		}

		public override void Notify_GeneratedByQuestGen(SitePart part, Slate slate, List<Rule> outExtraDescriptionRules, Dictionary<string, string> outExtraDescriptionConstants)
		{
			base.Notify_GeneratedByQuestGen(part, slate, outExtraDescriptionRules, outExtraDescriptionConstants);
			outExtraDescriptionRules.Add(new Rule_String("enemiesCount", part.expectedEnemyCount.ToString()));
			outExtraDescriptionRules.Add(new Rule_String("enemiesLabel", this.GetEnemiesLabel(part.site, part.expectedEnemyCount)));
		}

		public override string GetPostProcessedThreatLabel(Site site, SitePart sitePart)
		{
			return base.GetPostProcessedThreatLabel(site, sitePart) + ": " + "KnownSiteThreatEnemyCountAppend".Translate(sitePart.expectedEnemyCount, GetEnemiesLabel(site, sitePart.expectedEnemyCount));
		}

		public override SitePartParams GenerateDefaultParams(float myThreatPoints, int tile, Faction faction)
		{
			SitePartParams sitePartParams = base.GenerateDefaultParams(myThreatPoints, tile, faction);
			sitePartParams.lootMarketValue = SitePartWorker_Outpost.ThreatPointsLootMarketValue.Evaluate(sitePartParams.threatPoints);
			return sitePartParams;
		}

		protected int GetEnemiesCount(SitePartParams parms)
		{
			return GenMath.RoundRandom(Mathf.Clamp((parms.threatPoints / 30) * ModSettings_Utility.RaidModifier(), ModSettings_Utility.MinWerewolfNum(), ModSettings_Utility.MaxWerewolfNum()));
		}

		protected string GetEnemiesLabel(Site site, int enemiesCount)
		{
			return (enemiesCount == 1) ? FactionDefOf.MorrowRim_HoundsOfHircine.pawnSingular : FactionDefOf.MorrowRim_HoundsOfHircine.pawnsPlural;
		}

		public static readonly SimpleCurve ThreatPointsLootMarketValue = new SimpleCurve
		{
			{
				new CurvePoint(100f, 200f),
				true
			},
			{
				new CurvePoint(250f, 450f),
				true
			},
			{
				new CurvePoint(800f, 1000f),
				true
			},
			{
				new CurvePoint(10000f, 2000f),
				true
			}
		};
	}
}
