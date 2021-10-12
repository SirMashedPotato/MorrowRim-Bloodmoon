using System;
using System.Collections.Generic;
using RimWorld.Planet;
using Verse;
using Verse.AI;
using Verse.AI.Group;
using RimWorld;
using System.Linq;
using UnityEngine;

namespace MorrowRim_Bloodmoon
{
    class IncidentWorker_Ambush_Bloodmoon : IncidentWorker_Ambush
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return base.CanFireNowSub(parms) && ModSettings_Utility.EnableBloodmoonAmbushes() && Find.World.gameConditionManager.ConditionIsActive(GameConditionDefOf.MorrowRim_Bloodmoon);
        }

        protected override List<Pawn> GeneratePawns(IncidentParms parms)
        {

            int num = GenMath.RoundRandom(Mathf.Clamp((parms.points / 40) * ModSettings_Utility.RaidModifier(), ModSettings_Utility.MinWerewolfNum(), ModSettings_Utility.MaxWerewolfNum()));

            List<Pawn> list = new List<Pawn>();
            Faction faction = FactionUtility.DefaultFactionFrom(FactionDefOf.MorrowRim_HoundsOfHircine);
            for (int i = 0; i != num; i++)
            {
                Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDefOf.MorrowRim_Werewolf, null);
                pawn.SetFaction(faction);

                //settings checks
                if (ModSettings_Utility.GetBloodStrength() != 0f)
                {
                    pawn.health.AddHediff(HediffDefOf.MorrowRim_BloodOfHircine).Severity = ModSettings_Utility.GetBloodStrength();
                }
                if (Rand.Chance(ModSettings_Utility.SettingToFloat(ModSettings_Utility.GiftedWerewolfChance())))
                {
                    pawn.health.AddHediff(Utility.ChoosesRandomGift()).Severity = 1f;
                }

                list.Add(pawn);
            }

            return list;
        }

        protected override LordJob CreateLordJob(List<Pawn> generatedPawns, IncidentParms parms)
        {
            return new LordJob_HuntColony(FactionUtility.DefaultFactionFrom(FactionDefOf.MorrowRim_HoundsOfHircine), true, true);
        }

        protected override string GetLetterText(Pawn anyPawn, IncidentParms parms)
        {
            Caravan caravan = parms.target as Caravan;
            return string.Format(this.def.letterText, (caravan != null) ? caravan.Name : "yourCaravan".TranslateSimple()).CapitalizeFirst();
        }
    }
}
