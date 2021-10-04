using RimWorld;
using Verse;
using System.Linq;
using System.Collections.Generic;
using Verse.AI.Group;
using UnityEngine;

namespace MorrowRim_Bloodmoon
{
    public class Utility
    {
        public static IEnumerable<Pawn> GetColonyPawnDormantLycanthropy(Map map)
        {
            return map.mapPawns.FreeColonistsAndPrisoners.Where(x => x.health.hediffSet.HasHediff(HediffDefOf.MorrowRim_DormantSaniesLupinus));
        }

        public static IEnumerable<Pawn> AllPawnsOnMap(Map map)
        {
            return map.mapPawns.AllPawnsSpawned;
        }

        public static IEnumerable<Pawn> GetColonyPawn(Map map)
        {
            return map.mapPawns.FreeColonistsAndPrisoners;
        }

        public static bool CheckStoryteller()
        {
            return Current.Game.storyteller.def == StorytellerDefOf.MorrowRim_Hircine || ModSettings_Utility.EnableBloodMoonForAll();
        }

        public static bool HircineIncidentCheck()
        {
            return CheckStoryteller();
        }

        public static IEnumerable<Pawn> GetWerewolvesOnMap(Map map)
        {
            return map.mapPawns.AllPawnsSpawned.Where(x => x.kindDef == PawnKindDefOf.MorrowRim_Werewolf);
        }

        public static IEnumerable<Pawn> GetAvatarsOnMap(Map map)
        {
            return map.mapPawns.AllPawnsSpawned.Where(x => x.kindDef == PawnKindDefOf.MorrowRim_AvatarOfHircine);
        }

        /* Chooses a random gift */
        public static HediffDef ChoosesRandomGift()
        {
            int rand = Rand.RangeInclusive(0, 3);
            switch (rand)
            {
                case 1:
                    return HediffDefOf.MorrowRim_GiftOfSight;
                case 2:
                    return HediffDefOf.MorrowRim_GiftOfSpeed;
                case 3:
                    return HediffDefOf.MorrowRim_GiftOfStrength;
                default:
                    return HediffDefOf.MorrowRim_GiftOfGuile;
            }
        }

        public static bool CheckAssimilatedLycanthropy(Pawn pawn)
        {
            if (pawn.health.hediffSet.HasHediff(HediffDefOf.MorrowRim_AssimilatedLycanthropy)){
                pawn.health.RemoveHediff(pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_AssimilatedLycanthropy));
                pawn.health.AddHediff(HediffDefOf.MorrowRim_DormantSaniesLupinus);
                return false;
            }
            return true;
        }

        /* Elixir Checks */

        public static bool CheckWolfsBane_Protection(Pawn pawn)
        {
            if (pawn.health.hediffSet.HasHediff(HediffDefOf.MorrowRim_WolfsbaneProtectionActive))
            {
                pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_WolfsbaneProtectionActive).Severity -= 0.05f;
                return false;
            }
            return true;
        }

        public static bool CheckWolfsBane_Retaliation(Pawn pawn)
        {
            if (pawn.health.hediffSet.HasHediff(HediffDefOf.MorrowRim_WolfsbaneRetaliationActive))
            {
                pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_WolfsbaneRetaliationActive).Severity -= 0.05f;
                return true;
            }
            return false;
        }

        public static bool ElixirQualityCheck(Thing ingested)
        {
            ingested.TryGetQuality(out QualityCategory qc);
            if (qc == QualityCategory.Legendary)
            {
                return true;
            }
            var qual = ingested.TryGetComp<CompQuality>();
            float q = (float)qc;
            if (Rand.Chance(ModSettings_Utility.SettingToFloat(ModSettings_Utility.ElixirFailChance()) - (q * (ModSettings_Utility.SettingToFloat(ModSettings_Utility.ElixirFailChance() / 10)))))
            {
                return false;
            }
            return true;
        }

        public static void BurnWerewolf(Pawn pawn)
        {
            DamageInfo dinfo = new DamageInfo(DamageDefOf.Burn, 5, 0, -1, null, GetBurnPart(pawn));
            pawn.TakeDamage(dinfo);
        }

        public static BodyPartRecord GetBurnPart(Pawn p)
        {
            return p.RaceProps.body.AllPartsVulnerableToFrostbite.RandomElement();
        }

        public static bool HoundsFactionFound(string str)
        {
            if(FactionUtility.DefaultFactionFrom(FactionDefOf.MorrowRim_HoundsOfHircine) == null)
            {
                Messages.Message("Bloodmoon_houndsFactionNotFound".Translate(str), null, MessageTypeDefOf.RejectInput, true);
                return false;
            }

            return true;
        }

        /* === ROM werewolves === */
       
        public static bool ROMWerewolvesLoaded()
        {
            return LoadedModManager.RunningModsListForReading.Any(x => x.Name == "Rim of Madness - Werewolves (Continued)" || x.Name == "Rim of Madness - Werewolves");
        }

        public static bool ROMWerewolves_CheckTrait(Pawn pawn)
        {
            TraitDef trait = DefDatabase<TraitDef>.GetNamed("ROM_Werewolf");
            return pawn.story != null && pawn.story.traits != null && pawn.story.traits.HasTrait(trait);
        }

        public static void ROMWerewolves_GiveTrait(Pawn pawn)
        {
            TraitDef trait = DefDatabase<TraitDef>.GetNamed("ROM_Werewolf");
            pawn.story.traits.GainTrait(new Trait(trait));
        }
    }
}