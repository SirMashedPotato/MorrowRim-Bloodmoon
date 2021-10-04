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
            settings.chanceOfGiftedWerewolf = 5;
            settings.incidentIntervalCycle = 10f;
            settings.incidentMinimumDaysCycle = 10;
            settings.incidentIntervalRogue = 15f;
            settings.incidentMinimumDaysRogue = 15;
            settings.minTicksPerMark = 15000;
            settings.maxTicksPerMark = 30000;
            settings.maxWerewolfNum = 100;
            settings.chanceOfGiftedWerewolf = 5;

            settings.enableStrengthScaling = false;

            sound.PlayOneShotOnCamera();
        }
    }
}
