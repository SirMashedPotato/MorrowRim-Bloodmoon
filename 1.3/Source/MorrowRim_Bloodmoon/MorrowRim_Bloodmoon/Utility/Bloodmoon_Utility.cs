using RimWorld;
using Verse;
using System.Linq;
using System.Collections.Generic;
using System;
using Verse.AI.Group;
using UnityEngine;

namespace MorrowRim_Bloodmoon
{
    class Bloodmoon_Utility
    {
        public static Pawn ActivateLycanthropy(Pawn target)
        {
            //do things to old pawn
            target.DropAndForbidEverything();
            target.Strip();
            target.Kill(null);

            //create new pawn
            Pawn newPawn = PawnGenerator.GeneratePawn(PawnKindDefOf.MorrowRim_Werewolf, FactionUtility.DefaultFactionFrom(FactionDefOf.MorrowRim_HoundsOfHircine));
            PawnUtility.TrySpawnHatchedOrBornPawn(newPawn, target.Corpse);
            newPawn.gender = target.gender;
            newPawn.Name = target.Name;
            Faction faction = FactionUtility.DefaultFactionFrom(FactionDefOf.MorrowRim_HoundsOfHircine);
            List<Pawn> list = new List<Pawn>{newPawn};
            if (Bloodmoon_ModSettings.SettingToFloat(Bloodmoon_ModSettings.WerewolfStrength) != 0f)
            {
                newPawn.health.AddHediff(HediffDefOf.MorrowRim_BloodOfHircine).Severity = Bloodmoon_ModSettings.SettingToFloat(Bloodmoon_ModSettings.WerewolfStrength);
            }
            LordMaker.MakeNewLord(faction, new LordJob_HuntColony(faction, true, true), newPawn.Map, list);
            target.Corpse.Destroy();
            return newPawn;
        }

        public static void DoBloodmoonRaid(Map map, PawnKindDef pawnKind)
        {
            if (!Utility.HoundsFactionFound("Werewolf attack"))
            {
                return;
            }
            if (!map.mapPawns.AnyColonistSpawned)
            {
                return;
            }
            if (!RCellFinder.TryFindRandomPawnEntryCell(out IntVec3 intVec, map, CellFinder.EdgeRoadChance_Animal, false, null))
            {
                return;
            }

            int num = GenMath.RoundRandom(Mathf.Clamp((StorytellerUtility.DefaultThreatPointsNow(map) / 30) * Bloodmoon_ModSettings.RaidModifier, Bloodmoon_ModSettings.MinWerewolfNum, Bloodmoon_ModSettings.MaxWerewolfNum));
            IntVec3 invalid = IntVec3.Invalid;
            if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(intVec, map, 10f, out invalid))
            {
                invalid = IntVec3.Invalid;
            }
            List<Pawn> list = new List<Pawn>();
            Faction faction = FactionUtility.DefaultFactionFrom(FactionDefOf.MorrowRim_HoundsOfHircine);
            for (int i = 0; i != num; i++)
            {
                IntVec3 loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10, null);
                Pawn pawn = PawnGenerator.GeneratePawn(pawnKind, null);
                pawn.SetFaction(faction);
                GenSpawn.Spawn(pawn, loc, map, Rot4.Random, WipeMode.Vanish, false);
                if (invalid.IsValid)
                {
                    pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(invalid, map, 10, null);
                }
                if (pawnKind == PawnKindDefOf.MorrowRim_Werewolf)
                {
                    //settings checks
                    if (BloodmoonWorldComp.GetBloodStrength() != 0f)
                    {
                        pawn.health.AddHediff(HediffDefOf.MorrowRim_BloodOfHircine).Severity = BloodmoonWorldComp.GetBloodStrength();
                    }
                    if (Rand.Chance(Bloodmoon_ModSettings.SettingToFloat(Bloodmoon_ModSettings.ChanceOfGiftedWerewolf)))
                    {
                    pawn.health.AddHediff(Utility.ChoosesRandomGift()).Severity = 1f;
                    }
                }
                list.Add(pawn);
            }
            if (list.Any<Pawn>())
            {
                LordMaker.MakeNewLord(faction, new LordJob_HuntColony(faction, true, true), list.ElementAt(0).Map, list);
            }

            //send message
            if (Bloodmoon_ModSettings.EnableMessages)
            {
                Messages.Message("Bloodmoon_werewolvesAppear".Translate(), list, MessageTypeDefOf.NegativeEvent, true);
            }
            //send letter
            if (Bloodmoon_ModSettings.EnableLetters)
            {
                Find.LetterStack.ReceiveLetter("Bloodmoon_LetterLabelwerewolvesAppear".Translate(), "Bloodmoon_werewolvesAppear".Translate(), LetterDefOf.ThreatBig, list);
            }
        }

        public static void SpawnAvatarOfHircine(Map map)
        {
            int num = GenMath.RoundRandom(StorytellerUtility.DefaultThreatPointsNow(map) / 100);
            int max = Rand.RangeInclusive(1, 5);
            num = Mathf.Clamp(num, 1, max);
            int num2 = Rand.RangeInclusive(10000, 20000);

            Pawn pawn = null;
            for (int i = 0; i < num; i++)
            {
                if (!RCellFinder.TryFindRandomPawnEntryCell(out IntVec3 intVec, map, CellFinder.EdgeRoadChance_Animal, false, null))
                {
                    return;
                }
                IntVec3 loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10, null);
                pawn = PawnGenerator.GeneratePawn(PawnKindDefOf.MorrowRim_AvatarOfHircine, null);
                GenSpawn.Spawn(pawn, loc, map, Rot4.Random, WipeMode.Vanish, false);
                pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + num2;
                pawn.health.AddHediff(Utility.ChoosesRandomGift()).Severity = 1;
            }
        }

        public static void DestroyAvatarsOnMap(Map map)
        {
            try
            {
                foreach (Pawn pawn in Utility.GetAvatarsOnMap(map))
                {
                    Vector3 vector = pawn.Position.ToVector3Shifted();
                    FleckMaker.ThrowDustPuffThick(new Vector3(vector.x, 0f, vector.z)
                    {
                        y = AltitudeLayer.MoteOverhead.AltitudeFor()
                    }, pawn.Map, Rand.Range(1.5f, 3f), new Color(1f, 1f, 1f, 2.5f));
                    pawn.Destroy();
                }
            }
            catch (System.InvalidOperationException)
            {
                DestroyAvatarsOnMap(map);
            }
        }

        public static void DoLootDrops(Map map)
        {
            IncidentParms incidentParms = StorytellerUtility.DefaultParmsNow(IncidentDefOf.ResourcePodCrash.category, map);
            int num = Rand.RangeInclusive(Bloodmoon_ModSettings.MinNumberOfLootDrops, Bloodmoon_ModSettings.MaxNumberOfLootDrops);
            for (int i = 0; i != num; i++)
            {
                IncidentDef incidentDef = IncidentDefOf.ResourcePodCrash;
                incidentDef.Worker.TryExecute(incidentParms);
            }
        }

        public static bool CanInfectPawn(Pawn pawn)
        {
            if (!pawn.RaceProps.Animal && !pawn.RaceProps.IsMechanoid && pawn.def != ThingDefOf.MorrowRim_Werewolf &&
                pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_DormantSaniesLupinus) == null &&
                pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_SaniesLupinus) == null
                //other mods
                && pawn.RaceProps.FleshType.defName != "ESCP_FleshSload" && !pawn.def.defName.Contains("Android")
                && !pawn.def.defName.Contains("android"))
            {
                /* mod specific checks */
                if(Utility.ROMWerewolvesLoaded() && Utility.ROMWerewolves_CheckTrait(pawn))
                {
                    return false;
                }
                return Rand.Chance(Bloodmoon_ModSettings.SettingToFloat(Bloodmoon_ModSettings.InfectionChance));
            }
            return false;
        }

        public static void IncrementBloodmoonRecord(Map map)
        {
            foreach(Pawn pawn in Utility.GetColonyPawn(map))
            {
                pawn.records.Increment(RecordDefOf.MorrowRim_BloodmoonsSurvived);
            }

        }

        /* Marked animals */

        public static void AttemptToMarkAnimal(Map map)
        {
            if (MarkedAnimalsOnMap(map))
            {
                return;
            }
            Pawn target = map.mapPawns.AllPawnsSpawned.Where(x => x.AnimalOrWildMan() && x.kindDef.combatPower >= 50 && x.Faction == null && !x.Position.Fogged(map) && x.def != ThingDefOf.MorrowRim_AvatarOfHircine).RandomElement();
            if(target != null)
            {
                FleckMaker.AttachedOverlay(target, FleckDefOf.PsycastAreaEffect, Vector3.zero, 1f, -1f);
                target.health.RemoveAllHediffs();
                target.health.AddHediff(HediffDefOf.MorrowRim_HircineMarked);
                Messages.Message("Bloodmoon_animalMarked".Translate(target), target, MessageTypeDefOf.NeutralEvent, true);
            }
        }

        public static void ClearMarksOnMap(Map map)
        {
            foreach(Pawn pawn in map.mapPawns.AllPawns.Where(x => x.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_HircineMarked) != null))
            {
                pawn.health.RemoveHediff(pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_HircineMarked));
            }
        }

        public static bool MarkedAnimalsOnMap(Map map)
        {
            return map.mapPawns.AllPawns.Where(x => x.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_HircineMarked) != null).Any();
        }
    }
}
