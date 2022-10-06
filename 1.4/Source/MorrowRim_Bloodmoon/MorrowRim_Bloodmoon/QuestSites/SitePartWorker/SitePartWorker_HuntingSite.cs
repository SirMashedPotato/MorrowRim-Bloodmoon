using System.Collections.Generic;
using RimWorld.Planet;
using RimWorld.QuestGen;
using UnityEngine;
using Verse;
using Verse.Grammar;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    class SitePartWorker_HuntingSite : SitePartWorker
    {
        public override bool IsAvailable()
        {
            return base.IsAvailable() && Bloodmoon_ModSettings.EnableHircineHunts && Utility.HoundsFactionFound(def.label);
        }

        public override void Init(Site site, SitePart sitePart)
        {
            base.Init(site, sitePart);

            sitePart.parms.animalKind = Find.WorldGrid[site.Tile].biome.AllWildAnimals.RandomElementByWeightWithFallback(x => x.combatPower, RimWorld.PawnKindDefOf.Thrumbo);
        }

        public override void Notify_GeneratedByQuestGen(SitePart part, Slate slate, List<Rule> outExtraDescriptionRules, Dictionary<string, string> outExtraDescriptionConstants)
        {
            base.Notify_GeneratedByQuestGen(part, slate, outExtraDescriptionRules, outExtraDescriptionConstants);
            outExtraDescriptionRules.Add(new Rule_String("animalKind_label", part.parms.animalKind.label));
        }

        public override string GetPostProcessedThreatLabel(Site site, SitePart sitePart)
		{
			return base.GetPostProcessedThreatLabel(site, sitePart) + ": "+ sitePart.parms.animalKind.label;
		}
    }
}
