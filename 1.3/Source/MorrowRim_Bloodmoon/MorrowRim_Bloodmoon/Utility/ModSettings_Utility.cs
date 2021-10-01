using Verse;

namespace MorrowRim_Bloodmoon
{
    class ModSettings_Utility
    {

        //

        public static float SettingToFloat(int setting)
        {
            float f = setting;
            return f / 100;
        }

        //

        public static bool EnableBloodMoonForAll()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().enableBloodmoonCycleForAll;
        }

        public static bool EnableRogueBloodMoon()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().enableBloodmoonForAll;
        }

        public static bool EnableMessages()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().enableMessages;
        }

        public static float RaidModifier()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().raidModifier;
        }

        /* raid decider */

        /*public static int RaidBalance()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().raidBalance;
        }

        public static float RaidBalance_Float()
        {
            float f = RaidBalance();
            return f / 100;
        }*/

        public static bool IsWerewolfRaid()
        {
            return true;
            //return Rand.Chance(RaidBalance_Float());
        }


        public static bool AnimalMarking()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().animalMarking;
        }

        /* InfectionChance */

        public static int InfectionChance()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().infectionChance;
        }

        public static float InfectionChance_Float()
        {
            float f = InfectionChance();
            return f / 100;
        }


        /* avatar chance */

        public static int ExtraAvatarChance()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().extraAvatarChance;
        }

        /* gifted werewolf chance */

        public static int GiftedWerewolfChance()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().chanceOfGiftedWerewolf;
        }

        /* ticks per event */

        public static int MinTicksPerEvent()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().minTicksPerEvent;
        }

        public static int MaxTicksPerEvent()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().maxTicksPerEvent;
        }

        public static int NextTicksPerEvent()
        {
            return Rand.RangeInclusive(MinTicksPerEvent(), MaxTicksPerEvent());
        }

        /* ticks per mark */

        public static int MinTicksPerMark()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().minTicksPerMark;
        }

        public static int MaxTicksPerMark()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().maxTicksPerMark;
        }

        public static int NextTicksPerMark()
        {
            return Rand.RangeInclusive(MinTicksPerMark(), MaxTicksPerMark());
        }

        /* loot drops */

        public static bool EnableLootDrops()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().enableLootDrops;
        }

        public static int MinNumberOfLootDrops()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().minNumberOfLootDrops;
        }

        public static int MaxNumberOfLootDrops()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().maxNumberOfLootDrops;
        }

        public static int NumberOfLootDrops()
        {
            return Rand.RangeInclusive(MinNumberOfLootDrops(), MaxNumberOfLootDrops());
        }

        /* elixir fail chance */

        public static int ElixirFailChance()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().elixirFailChance;
        }

        /* werewolf limits */

        public static int MinWerewolfNum()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().minWerewolfNum;
        }

        public static int MaxWerewolfNum()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().maxWerewolfNum;
        }

        public static int WerewolfStrength_int()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().werewolfStrength;
        }

        /* intervals */

        public static float IntervalCycle()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().incidentIntervalCycle;
        }

        public static float IntervalRogue()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().incidentIntervalRogue;
        }

        /* werewolf pack */

        public static bool EnableWerewolfPack()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().enableWerewolfPack;
        }

        /* minimum days */

        public static int MinimumDaysCycle()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().incidentMinimumDaysCycle;
        }

        public static int MinimumDaysRogue()
        {
            return LoadedModManager.GetMod<Bloodmoon_Mod>().GetSettings<Bloodmoon_ModSettings>().incidentMinimumDaysRogue;
        }
    }
}
