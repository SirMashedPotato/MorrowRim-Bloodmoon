using Verse;

namespace MorrowRim_Bloodmoon
{
    class Bloodmoon_ModSettings : ModSettings
    {
        public static float SettingToFloat(int setting)
        {
            float f = setting;
            return f / 100;
        }

        private static Bloodmoon_ModSettings _instance;

        /* ==========[GETTERS]========== */

        /* Werewolves */
        public static float RaidModifier => _instance.raidModifier;
        public static int WerewolfStrength => _instance.werewolfStrength;
        public static int MinWerewolfNum => _instance.minWerewolfNum;
        public static int MaxWerewolfNum => _instance.maxWerewolfNum;
        public static int ChanceOfGiftedWerewolf => _instance.chanceOfGiftedWerewolf;

        /* Bloodmoon */
        //misc enables
        public static bool EnableBloodmoonAmbushes => _instance.enableBloodmoonAmbushes;
        public static bool EnableStrengthScaling => _instance.enableStrengthScaling;
        public static bool EnableBloodmoonTransforming => _instance.enableBloodmoonTransforming;

        //messages
        public static bool EnableBloodmoonTracker => _instance.enableBloodmoonTracker;
        public static bool EnableMessages => _instance.enableMessages;
        public static bool EnableLetters => _instance.enableLetters;

        //werewolf packs
       
        public static int MinTicksPerEvent => _instance.minTicksPerEvent;
        public static int MaxTicksPerEvent => _instance.maxTicksPerEvent;
        //avatars
        public static int ExtraAvatarChance => _instance.extraAvatarChance;
        //end rewards
        public static bool EnableLootDrops => _instance.enableLootDrops;
        public static int MinNumberOfLootDrops => _instance.minNumberOfLootDrops;
        public static int MaxNumberOfLootDrops => _instance.maxNumberOfLootDrops;
        //marked animals
        public static bool AnimalMarking => _instance.animalMarking;
        public static int MinTicksPerMark => _instance.minTicksPerMark;
        public static int MaxTicksPerMark => _instance.maxTicksPerMark;

        /* Lycanthropy & gifts */
        public static int InfectionChance => _instance.infectionChance;
        public static int ElixirFailChance => _instance.elixirFailChance;
        public static float HuntersGiftMaximum => _instance.huntersGiftMaximum;
        public static float HuntersGiftBuildup => _instance.huntersGiftBuildup;

        /* incidents/quests */
        //bloodmoon rogue
        public static bool EnableBloodmoonForAll => _instance.enableBloodmoonForAll;
        public static float IncidentIntervalRogue => _instance.incidentIntervalRogue;
        public static int IncidentMinimumDaysRogue => _instance.incidentMinimumDaysRogue;
        //bloodmoon cycle
        public static bool EnableBloodmoonCycleForAll => _instance.enableBloodmoonCycleForAll;
        public static float IncidentIntervalCycle => _instance.incidentIntervalCycle;
        public static int IncidentMinimumDaysCycle => _instance.incidentMinimumDaysCycle;
        //quests
        public static bool EnableWerewolfPack => _instance.enableWerewolfPack;
        public static bool EnableWerewolfLord => _instance.enableWerewolfLord;
        public static bool EnableHircineHunts => _instance.enableHircineHunts;

        /* ==========[VARIABLES]========== */

        /* Werewolves */
        public float raidModifier = raidModifier_def;
        public int werewolfStrength = werewolfStrength_def;
        public int minWerewolfNum = minWerewolfNum_def;
        public int maxWerewolfNum = maxWerewolfNum_def;
        public int chanceOfGiftedWerewolf = chanceOfGiftedWerewolf_def;

        /* Bloodmoon */
        //misc enables
        public bool enableBloodmoonAmbushes = enableBloodmoonAmbushes_def;
        public bool enableStrengthScaling = enableStrengthScaling_def;
        public bool enableBloodmoonTransforming = enableBloodmoonTransforming_def;
        //messages
        public bool enableBloodmoonTracker = enableBloodmoonTracker_def;
        public bool enableMessages = enableMessages_def;
        public bool enableLetters = enableLetters_def;
        //werewolf packs
        public int minTicksPerEvent = minTicksPerEvent_def;
        public int maxTicksPerEvent = maxTicksPerEvent_def;
        //avatars
        public int extraAvatarChance = extraAvatarChance_def;
        //end rewards
        public bool enableLootDrops = enableLootDrops_def;
        public int minNumberOfLootDrops = minNumberOfLootDrops_def;
        public int maxNumberOfLootDrops = maxNumberOfLootDrops_def;
        //marked animals
        public bool animalMarking = animalMarking_def;
        public int minTicksPerMark = minTicksPerMark_def;
        public int maxTicksPerMark = maxTicksPerMark_def;

        /* Lycanthropy & gifts */
        public int infectionChance = infectionChance_def;
        public int elixirFailChance = elixirFailChance_def;
        public float huntersGiftMaximum = huntersGiftMaximum_def;
        public float huntersGiftBuildup = huntersGiftBuildup_def;

        /* incidents/quests */
        //bloodmoon rogue
        public bool enableBloodmoonForAll = enableBloodmoonForAll_def;
        public float incidentIntervalRogue = incidentIntervalRogue_def;
        public int incidentMinimumDaysRogue = incidentMinimumDaysRogue_def;
        //bloodmoon cycle
        public bool enableBloodmoonCycleForAll = enableBloodmoonCycleForAll_def;
        public float incidentIntervalCycle = incidentIntervalCycle_def;
        public int incidentMinimumDaysCycle = incidentMinimumDaysCycle_def;
        //quests
        public bool enableWerewolfPack = enableWerewolfPack_def;
        public bool enableWerewolfLord = enableWerewolfLord_def;
        public bool enableHircineHunts = enableHircineHunts_def;

        /* ==========[DEFAULTS]========== */
        /* Werewolves */
        private static readonly float raidModifier_def = 0.5f;
        private static readonly int werewolfStrength_def = 0;
        private static readonly int minWerewolfNum_def = 1;
        private static readonly int maxWerewolfNum_def = 50;
        private static readonly int chanceOfGiftedWerewolf_def = 1;

        /* Bloodmoon */
        //misc enables
        private static readonly bool enableBloodmoonAmbushes_def = true;
        private static readonly bool enableStrengthScaling_def = true;
        private static readonly bool enableBloodmoonTransforming_def = true;
        //messages
        private static readonly bool enableBloodmoonTracker_def = true;
        private static readonly bool enableMessages_def = true;
        private static readonly bool enableLetters_def = false;
        //werewolf packs
        private static readonly int minTicksPerEvent_def = 20000;
        private static readonly int maxTicksPerEvent_def = 50000;
        //avatars
        private static readonly int extraAvatarChance_def = 10;
        //end rewards
        private static readonly bool enableLootDrops_def = true;
        private static readonly int minNumberOfLootDrops_def = 1;
        private static readonly int maxNumberOfLootDrops_def = 3;
        //marked animals
        private static readonly bool animalMarking_def = true;
        private static readonly int minTicksPerMark_def = 25000;
        private static readonly int maxTicksPerMark_def = 45000;

        /* Lycanthropy & gifts */
        private static readonly int infectionChance_def = 50;
        private static readonly int elixirFailChance_def = 10;
        private static readonly float huntersGiftMaximum_def = 1f;
        private static readonly float huntersGiftBuildup_def = 0.1f;

        /* incidents/quests */
        //bloodmoon rogue
        private static readonly bool enableBloodmoonForAll_def = false;
        private static readonly float incidentIntervalRogue_def = 60f;
        private static readonly int incidentMinimumDaysRogue_def = 40;
        //bloodmoon cycle
        private static readonly bool enableBloodmoonCycleForAll_def = false;
        private static readonly float incidentIntervalCycle_def = 30f;
        private static readonly int incidentMinimumDaysCycle_def = 30;
        //quests
        private static readonly bool enableWerewolfPack_def = true;
        private static readonly bool enableWerewolfLord_def = true;
        private static readonly bool enableHircineHunts_def = true;

        public Bloodmoon_ModSettings()
        {
            _instance = this;
        }

        /* ==========[SAVING]========== */
        public override void ExposeData()
        {
            /* Werewolves */
            Scribe_Values.Look(ref raidModifier, "Bloodmoon_raidModifier", raidModifier_def);
            Scribe_Values.Look(ref maxWerewolfNum, "Bloodmoon_maxWerewolfNum", maxWerewolfNum_def);
            Scribe_Values.Look(ref minWerewolfNum, "Bloodmoon_minWerewolfNum", minWerewolfNum_def);
            Scribe_Values.Look(ref werewolfStrength, "Bloodmoon_werewolfStrength", werewolfStrength_def);
            Scribe_Values.Look(ref chanceOfGiftedWerewolf, "Bloodmoon_chanceOfGiftedWerewolf", chanceOfGiftedWerewolf_def);

            /* Bloodmoon */
            //misc enables
            Scribe_Values.Look(ref enableBloodmoonAmbushes, "Bloodmoon_enableBloodmoonAmbushes", enableBloodmoonAmbushes_def);
            Scribe_Values.Look(ref enableStrengthScaling, "Bloodmoon_enableStrengthScaling", enableStrengthScaling_def);
            Scribe_Values.Look(ref enableBloodmoonTransforming, "Bloodmoon_enableBloodmoonTransforming", enableBloodmoonTransforming_def);
            //messages
            Scribe_Values.Look(ref enableBloodmoonTracker, "Bloodmoon_enableBloodmoonTracker", enableBloodmoonTracker_def);
            Scribe_Values.Look(ref enableMessages, "Bloodmoon_enableMessages", enableMessages_def);
            Scribe_Values.Look(ref enableLetters, "Bloodmoon_enableLetters", enableLetters_def);
            //werewolf packs
            Scribe_Values.Look(ref minTicksPerEvent, "Bloodmoon_minTicksPerEvent", minTicksPerEvent_def);
            Scribe_Values.Look(ref maxTicksPerEvent, "Bloodmoon_maxTicksPerEvent", maxTicksPerEvent_def);
           
            //avatars
            Scribe_Values.Look(ref extraAvatarChance, "Bloodmoon_extraAvatarChance", extraAvatarChance_def);
            //end rewards
            Scribe_Values.Look(ref enableLootDrops, "Bloodmoon_enableLootDrops", enableLootDrops_def);
            Scribe_Values.Look(ref minNumberOfLootDrops, "Bloodmoon_minNumberOfLootDrops", minNumberOfLootDrops_def);
            Scribe_Values.Look(ref maxNumberOfLootDrops, "Bloodmoon_maxNumberOfLootDrops", maxNumberOfLootDrops_def);
            //marked animals
            Scribe_Values.Look(ref animalMarking, "Bloodmoon_animalMarking", animalMarking_def);
            Scribe_Values.Look(ref minTicksPerMark, "Bloodmoon_minTicksPerMark", minTicksPerMark_def);
            Scribe_Values.Look(ref maxTicksPerMark, "Bloodmoon_maxTicksPerMark", maxTicksPerMark_def);

            /* Lycanthropy & gifts */
            Scribe_Values.Look(ref infectionChance, "Bloodmoon_infectionChance", infectionChance_def);
            Scribe_Values.Look(ref elixirFailChance, "Bloodmoon_elixirFailChance", elixirFailChance_def);
            Scribe_Values.Look(ref huntersGiftMaximum, "Bloodmoon_huntersGiftMaximum", huntersGiftMaximum_def);
            Scribe_Values.Look(ref huntersGiftBuildup, "Bloodmoon_huntersGiftBuildup", huntersGiftBuildup_def);

            /* incidents/quests */
            //bloodmoon rogue
            Scribe_Values.Look(ref enableBloodmoonForAll, "Bloodmoon_enableBloodmoonForAll", enableBloodmoonForAll_def);
            Scribe_Values.Look(ref incidentIntervalRogue, "Bloodmoon_incidentIntervalRogue", incidentIntervalRogue_def);
            Scribe_Values.Look(ref incidentMinimumDaysRogue, "Bloodmoon_incidentMinimumDaysRogue", incidentMinimumDaysRogue_def);
            //bloodmoon cycle
            Scribe_Values.Look(ref enableBloodmoonCycleForAll, "Bloodmoon_enableBloodmoonCycleForAll", enableBloodmoonCycleForAll_def);
            Scribe_Values.Look(ref incidentIntervalCycle, "Bloodmoon_incidentIntervalCycle", incidentIntervalCycle_def);
            Scribe_Values.Look(ref incidentMinimumDaysCycle, "Bloodmoon_incidentMinimumDaysCycle", incidentMinimumDaysCycle_def);
            //quests
            Scribe_Values.Look(ref enableWerewolfPack, "Bloodmoon_enableWerewolfPack", enableWerewolfPack_def);
            Scribe_Values.Look(ref enableWerewolfLord, "Bloodmoon_enableWerewolfLord", enableWerewolfLord_def);
            Scribe_Values.Look(ref enableHircineHunts, "Bloodmoon_enableHircineHunts", enableHircineHunts_def);

            base.ExposeData();
        }
        public static void ResetSettings()
        {
            ResetSettings_Werewolves();
            ResetSettings_Bloodmoon();
            ResetSettings_LycanthropyAndGifts();
            ResetSettings_IncidentsAndQuests();
        }

        public static void ResetSettings_Werewolves()
        {
            _instance.raidModifier = raidModifier_def;
            _instance.werewolfStrength = werewolfStrength_def;
            _instance.minWerewolfNum = minWerewolfNum_def;
            _instance.maxWerewolfNum = maxWerewolfNum_def;
            _instance.chanceOfGiftedWerewolf = chanceOfGiftedWerewolf_def;
        }

        public static void ResetSettings_Bloodmoon()
        {
            //misc
            _instance.enableBloodmoonAmbushes = enableBloodmoonAmbushes_def;
            _instance.enableStrengthScaling = enableStrengthScaling_def;
            _instance.enableBloodmoonTransforming = enableBloodmoonTransforming_def;
            //messages
            _instance.enableBloodmoonTracker = enableBloodmoonTracker_def;
            _instance.enableMessages = enableMessages_def;
            _instance.enableLetters = enableLetters_def;
            //werewolf packs
            _instance.minTicksPerEvent = minTicksPerEvent_def;
            _instance.maxTicksPerEvent = maxTicksPerEvent_def;
            //avatars
            _instance.extraAvatarChance = extraAvatarChance_def;
            //end rewards
            _instance.enableLootDrops = enableLootDrops_def;
            _instance.minNumberOfLootDrops = minNumberOfLootDrops_def;
            _instance.maxNumberOfLootDrops = maxNumberOfLootDrops_def;
            //marked animals
            _instance.animalMarking = animalMarking_def;
            _instance.minTicksPerMark = minTicksPerMark_def;
            _instance.maxTicksPerMark = maxTicksPerMark_def;
        }
        public static void ResetSettings_LycanthropyAndGifts()
        {
            _instance.infectionChance = infectionChance_def;
            _instance.elixirFailChance = elixirFailChance_def;
            _instance.huntersGiftMaximum = huntersGiftMaximum_def;
            _instance.huntersGiftBuildup = huntersGiftBuildup_def;
        }
        public static void ResetSettings_IncidentsAndQuests()
        {
            //bloodmoon rogue
            _instance.enableBloodmoonForAll = enableBloodmoonForAll_def;
            _instance.incidentIntervalRogue = incidentIntervalRogue_def;
            _instance.incidentMinimumDaysRogue = incidentMinimumDaysRogue_def;
            //bloodmoon cycle
            _instance.enableBloodmoonCycleForAll = enableBloodmoonCycleForAll_def;
            _instance.incidentIntervalCycle = incidentIntervalCycle_def;
            _instance.incidentMinimumDaysCycle = incidentMinimumDaysCycle_def;
            //quests
            _instance.enableWerewolfPack = enableWerewolfPack_def;
            _instance.enableWerewolfLord = enableWerewolfLord_def;
            _instance.enableHircineHunts = enableHircineHunts_def;
        }
    }
}
