using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace MorrowRim_Bloodmoon
{
    class Bloodmoon_ModSettings : ModSettings
    {
        //Settings
        public float raidModifier = raidModifier_def;
        public int minTicksPerEvent = minTicksPerEvent_def;
        public int maxTicksPerEvent = maxTicksPerEvent_def;
        public int extraAvatarChance = extraAvatarChance_def;
        public int minNumberOfLootDrops = minNumberOfLootDrops_def;
        public int maxNumberOfLootDrops = maxNumberOfLootDrops_def;
        public bool enableBloodmoonForAll = enableBloodmoonForAll_def;
        public bool enableMessages = enableMessages_def;
        public int chanceOfGiftedWerewolf = chanceOfGiftedWerewolf_def;
        public int infectionChance = infectionChance_def;
        public bool enableBloodmoonCycleForAll = enableBloodmoonCycleForAll_def;
        public bool enableLootDrops = enableLootDrops_def;
        public int elixirFailChance = elixirFailChance_def;
        public int maxWerewolfNum = maxWerewolfNum_def;
        public int minWerewolfNum = minWerewolfNum_def;
        public int werewolfStrength = werewolfStrength_def;
        //public int raidBalance = raidBalance_def;

        //default values
        private static readonly float raidModifier_def = 1f;
        private static readonly int minTicksPerEvent_def = 10000;
        private static readonly int maxTicksPerEvent_def = 20000;
        private static readonly int extraAvatarChance_def = 10;
        private static readonly int minNumberOfLootDrops_def = 3;
        private static readonly int maxNumberOfLootDrops_def = 5;
        private static readonly bool enableBloodmoonForAll_def = false;
        private static readonly bool enableMessages_def = true;
        private static readonly int chanceOfGiftedWerewolf_def = 5;
        private static readonly int infectionChance_def = 50;
        private static readonly bool enableBloodmoonCycleForAll_def = false;
        private static readonly bool enableLootDrops_def = false;
        private static readonly int elixirFailChance_def = 10;
        private static readonly int maxWerewolfNum_def = 100;
        private static readonly int minWerewolfNum_def = 1;
        private static readonly int werewolfStrength_def = 0;
        //private static readonly int raidBalance_def = 70;

        //save settings
        public override void ExposeData()
        {
            Scribe_Values.Look(ref raidModifier, "Bloodmoon_raidModifier", raidModifier_def);
            Scribe_Values.Look(ref minTicksPerEvent, "Bloodmoon_minTicksPerEvent", minTicksPerEvent_def);
            Scribe_Values.Look(ref maxTicksPerEvent, "Bloodmoon_maxTicksPerEvent", maxTicksPerEvent_def);
            Scribe_Values.Look(ref extraAvatarChance, "Bloodmoon_extraAvatarChance", extraAvatarChance_def);
            Scribe_Values.Look(ref minNumberOfLootDrops, "Bloodmoon_minNumberOfLootDrops", minNumberOfLootDrops_def);
            Scribe_Values.Look(ref maxNumberOfLootDrops, "Bloodmoon_maxNumberOfLootDrops", maxNumberOfLootDrops_def);
            Scribe_Values.Look(ref enableBloodmoonForAll, "Bloodmoon_enableBloodmoonForAll", enableBloodmoonForAll_def);
            Scribe_Values.Look(ref enableMessages, "Bloodmoon_enableMessages", enableMessages_def);
            Scribe_Values.Look(ref chanceOfGiftedWerewolf, "Bloodmoon_chanceOfGiftedWerewolf", chanceOfGiftedWerewolf_def);
            Scribe_Values.Look(ref infectionChance, "Bloodmoon_infectionChance", infectionChance_def);
            Scribe_Values.Look(ref infectionChance, "Bloodmoon_infectionChance", infectionChance_def);
            Scribe_Values.Look(ref enableBloodmoonCycleForAll, "Bloodmoon_enableBloodmoonCycleForAll", enableBloodmoonCycleForAll_def);
            Scribe_Values.Look(ref enableLootDrops, "Bloodmoon_enableLootDrops", enableLootDrops_def);
            Scribe_Values.Look(ref elixirFailChance, "Bloodmoon_elixirFailChance", elixirFailChance_def);
            Scribe_Values.Look(ref maxWerewolfNum, "Bloodmoon_minWerewolfNum", maxWerewolfNum_def);
            Scribe_Values.Look(ref minWerewolfNum, "Bloodmoon_maxWerewolfNum", minWerewolfNum_def);
            Scribe_Values.Look(ref werewolfStrength, "Bloodmoon_werewolfStrength", werewolfStrength_def);
            //Scribe_Values.Look(ref raidBalance, "Bloodmoon_raidBalance", raidBalance_def);
            base.ExposeData();
        }
        public static void resetSettings(Bloodmoon_ModSettings settings)
        {
            settings.raidModifier = raidModifier_def;
            settings.minTicksPerEvent = minTicksPerEvent_def;
            settings.maxTicksPerEvent = maxTicksPerEvent_def;
            settings.extraAvatarChance = extraAvatarChance_def;
            settings.minNumberOfLootDrops = minNumberOfLootDrops_def;
            settings.maxNumberOfLootDrops = maxNumberOfLootDrops_def;
            settings.enableBloodmoonForAll = enableBloodmoonForAll_def;
            settings.enableMessages = enableMessages_def;
            settings.chanceOfGiftedWerewolf = chanceOfGiftedWerewolf_def;
            settings.infectionChance = infectionChance_def;
            settings.enableBloodmoonCycleForAll = enableBloodmoonCycleForAll_def;
            settings.enableLootDrops = enableLootDrops_def;
            settings.elixirFailChance = elixirFailChance_def;
            settings.maxWerewolfNum = maxWerewolfNum_def;
            settings.minWerewolfNum = minWerewolfNum_def;
            settings.werewolfStrength = werewolfStrength_def;
            //settings.raidBalance = raidBalance_def;
        }
    }
}
