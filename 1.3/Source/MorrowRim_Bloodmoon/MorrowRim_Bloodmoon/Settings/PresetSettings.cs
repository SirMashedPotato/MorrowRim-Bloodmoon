using RimWorld;
using Verse;
using Verse.Sound;

namespace MorrowRim_Bloodmoon
{
    static class PresetSettings
    {

        static readonly SoundDef sound = RimWorld.SoundDefOf.TinyBell;

        public static void Preset_Classic(Bloodmoon_ModSettings settings)
        {
            Bloodmoon_ModSettings.resetSettings(settings);

            settings.raidModifier = 1f;
            settings.minTicksPerEvent = 10000;
            settings.maxTicksPerEvent = 20000;
            settings.extraAvatarChance = 10;
            settings.minNumberOfLootDrops = 1;
            settings.maxNumberOfLootDrops = 3;
            settings.enableBloodmoonForAll = false;
            settings.enableMessages = true;
            settings.chanceOfGiftedWerewolf = 5;
            settings.infectionChance = 50;
            settings.enableBloodmoonCycleForAll = false;
            settings.enableLootDrops = true;
            settings.elixirFailChance = 10;
            settings.maxWerewolfNum = 100;
            settings.minWerewolfNum = 1;
            settings.werewolfStrength = 0;
            settings.animalMarking = true;
            settings.minTicksPerMark = 15000;
            settings.maxTicksPerMark = 30000;
            settings.incidentIntervalCycle = 10f;
            settings.incidentIntervalRogue = 15f;
            settings.enableWerewolfPack = true;
            settings.incidentMinimumDaysCycle = 10;
            settings.incidentMinimumDaysRogue = 15;
            settings.enableLetters = false;
            settings.huntersGiftMaximum = 1f;
            settings.huntersGiftBuildup = 0.1f;
            settings.enableStrengthScaling = false;
            settings.enableBloodmoonAmbushes = true;

            sound.PlayOneShotOnCamera();
        }
    }
}
