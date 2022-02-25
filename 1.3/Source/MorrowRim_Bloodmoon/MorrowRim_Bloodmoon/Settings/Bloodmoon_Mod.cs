﻿using RimWorld;
using UnityEngine;
using Verse;
using System.Collections.Generic;

using System;
using System.IO;
using RimWorld.IO;
using RuntimeAudioClipLoader;

namespace MorrowRim_Bloodmoon
{
    class Bloodmoon_Mod : Mod
    {

        Bloodmoon_ModSettings settings;

        public Bloodmoon_Mod(ModContentPack contentPack) : base(contentPack)
        {
            this.settings = GetSettings<Bloodmoon_ModSettings>();
        }

        public override string SettingsCategory() => "MorrowRim - Bloodmoon";

        private static Vector2 scrollPosition = Vector2.zero;

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            Rect rect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
            Rect rect2 = new Rect(0f, 0f, inRect.width - 30, inRect.height + (inRect.height / 3)*5);
            Widgets.BeginScrollView(rect, ref scrollPosition, rect2);
            listing_Standard.Begin(rect2);

            /* specific settings */

            //enableWerewolfPack
            listing_Standard.CheckboxLabeled("Bloodmoon_enableWerewolfPack".Translate(), ref settings.enableWerewolfPack);
            listing_Standard.Gap();

            //enableWerewolfPack
            listing_Standard.CheckboxLabeled("Bloodmoon_enableBloodmoonAmbushes".Translate(), ref settings.enableBloodmoonAmbushes);
            listing_Standard.Gap();

            //enableMessages
            listing_Standard.CheckboxLabeled("Bloodmoon_enableMessages".Translate(), ref settings.enableMessages);
            listing_Standard.Gap();

            //enableLetters
            listing_Standard.CheckboxLabeled("Bloodmoon_enableLetters".Translate(), ref settings.enableLetters);
            listing_Standard.Gap();

            //enableBloodmoonTracker
            listing_Standard.CheckboxLabeled("Bloodmoon_enableBloodmoonTracker".Translate(), ref settings.enableBloodmoonTracker);
            listing_Standard.Gap();

            listing_Standard.GapLine();

            //enableBloodmoonForAll
            listing_Standard.CheckboxLabeled("Bloodmoon_enableBloodmoonForAll".Translate(), ref settings.enableBloodmoonForAll);
            listing_Standard.Gap();

            //incidentMinimumDaysRogue
            listing_Standard.Label("Bloodmoon_incidentMinimumDaysRogue".Translate() + " (" + settings.incidentMinimumDaysRogue + " days)");
            settings.incidentMinimumDaysRogue = (int)listing_Standard.Slider(settings.incidentMinimumDaysRogue, 1, 180);

            //incidentIntervalRogue
            listing_Standard.Label("Bloodmoon_incidentIntervalRogue".Translate() + " (" + settings.incidentIntervalRogue + " days)");
            settings.incidentIntervalRogue = (float)Math.Round(listing_Standard.Slider(settings.incidentIntervalRogue, 1, 180), 0);

            listing_Standard.GapLine();

            //enableBloodmoonCycleForAll
            listing_Standard.CheckboxLabeled("Bloodmoon_enableBloodmoonCycleForAll".Translate(), ref settings.enableBloodmoonCycleForAll);
            listing_Standard.Gap();

            //incidentMinimumDaysRogue
            listing_Standard.Label("Bloodmoon_incidentMinimumDaysCycle".Translate() + " (" + settings.incidentMinimumDaysCycle + " days)");
            settings.incidentMinimumDaysCycle = (int)listing_Standard.Slider(settings.incidentMinimumDaysCycle, 1, 180);

            //incidentIntervalRogue
            listing_Standard.Label("Bloodmoon_incidentIntervalCycle".Translate() + " (" + settings.incidentIntervalCycle + " days)");
            settings.incidentIntervalCycle = (float)Math.Round(listing_Standard.Slider(settings.incidentIntervalCycle, 1, 180), 0);

            listing_Standard.GapLine();

            //enableStrengthScaling
            listing_Standard.CheckboxLabeled("Bloodmoon_enableStrengthScaling".Translate(), ref settings.enableStrengthScaling, "Bloodmoon_enableStrengthScalingTooltip".Translate());
            listing_Standard.Gap();

            //werewolfStrength
            listing_Standard.Label("Bloodmoon_werewolfStrength".Translate() + " (" + settings.werewolfStrength + "%)");
            settings.werewolfStrength = (int)Math.Round(listing_Standard.Slider(settings.werewolfStrength, 0.0f, 100) / 5) * 5;

            //raidModifier
            listing_Standard.Label("Bloodmoon_raidModifier".Translate() + " (" + settings.raidModifier + "x)");
            settings.raidModifier = (float)Mathf.Round(listing_Standard.Slider(settings.raidModifier, 0.1f, 10f) * 10) / 10;

            //minWerewolfNum
            listing_Standard.Label("Bloodmoon_minWerewolfNum".Translate() + " (" + settings.minWerewolfNum + ")");
            settings.minWerewolfNum = (int)listing_Standard.Slider(settings.minWerewolfNum, 1, settings.maxWerewolfNum);

            //maxWerewolfNum
            listing_Standard.Label("Bloodmoon_maxWerewolfNum".Translate() + " (" + settings.maxWerewolfNum + ")");
            settings.maxWerewolfNum = (int)listing_Standard.Slider(settings.maxWerewolfNum, settings.minWerewolfNum, 500);

            listing_Standard.GapLine();

            //minTicksPerEvent
            listing_Standard.Label("Bloodmoon_minTicksPerEvent".Translate() + " (" + settings.minTicksPerEvent + ")");
            settings.minTicksPerEvent = (int)Math.Round(listing_Standard.Slider(settings.minTicksPerEvent, 0, settings.maxTicksPerEvent) / 50) * 50;

            //maxTicksPerEvent
            listing_Standard.Label("Bloodmoon_maxTicksPerEvent".Translate() + " (" + settings.maxTicksPerEvent + ")");
            settings.maxTicksPerEvent = (int)Math.Round(listing_Standard.Slider(settings.maxTicksPerEvent, settings.minTicksPerEvent, 50000) / 50) * 50;

            listing_Standard.GapLine();

            //Mark settings
            listing_Standard.CheckboxLabeled("Bloodmoon_enableMarking".Translate(), ref settings.animalMarking);
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_minTicksPerMark".Translate() + " (" + settings.minTicksPerMark + ")");
            settings.minTicksPerMark = (int)Math.Round(listing_Standard.Slider(settings.minTicksPerMark, 0, settings.maxTicksPerMark) / 50) * 50;

            //maxTicksPerMark
            listing_Standard.Label("Bloodmoon_maxTicksPerMark".Translate() + " (" + settings.maxTicksPerMark + ")");
            settings.maxTicksPerMark = (int)Math.Round(listing_Standard.Slider(settings.maxTicksPerMark, settings.minTicksPerMark, 50000) / 50) * 50;

            listing_Standard.GapLine();

            /* loot drops */
            //enableBloodmoonCycleForAll
            listing_Standard.CheckboxLabeled("Bloodmoon_enableLootDrops".Translate(), ref settings.enableLootDrops);
            listing_Standard.Gap();

            //minNumberOfLootDrops
            listing_Standard.Label("Bloodmoon_minNumberOfLootDrops".Translate() + " (" + settings.minNumberOfLootDrops + ")");
            settings.minNumberOfLootDrops = (int)listing_Standard.Slider(settings.minNumberOfLootDrops, 0, settings.maxNumberOfLootDrops);

            //maxNumberOfLootDrops
            listing_Standard.Label("Bloodmoon_maxNumberOfLootDrops".Translate() + " (" + settings.maxNumberOfLootDrops + ")");
            settings.maxNumberOfLootDrops = (int)listing_Standard.Slider(settings.maxNumberOfLootDrops, settings.minNumberOfLootDrops, 50);

            listing_Standard.GapLine();

            //extraAvatarChance
            listing_Standard.Label("Bloodmoon_extraAvatarChance".Translate() + " (" + (settings.extraAvatarChance) + "%)");
            settings.extraAvatarChance = (int)listing_Standard.Slider(settings.extraAvatarChance, 0, 100);

            //chanceOfGiftedWerewolf
            listing_Standard.Label("Bloodmoon_chanceOfGiftedWerewolf".Translate() + " (" + (settings.chanceOfGiftedWerewolf) + "%)");
            settings.chanceOfGiftedWerewolf = (int)listing_Standard.Slider(settings.chanceOfGiftedWerewolf, 0, 100);

            listing_Standard.Label("Bloodmoon_huntersGiftBuildup".Translate() + " (" + (settings.huntersGiftBuildup * 100) + "%)");
            settings.huntersGiftBuildup = (float)Math.Round(listing_Standard.Slider(settings.huntersGiftBuildup, 0.05f, 1f) * 20) / 20;

            listing_Standard.Label("Bloodmoon_huntersGiftMaximum".Translate() + " (" + (settings.huntersGiftMaximum * 100 ) + "%)");
            settings.huntersGiftMaximum = (float)Math.Round(listing_Standard.Slider(settings.huntersGiftMaximum, 0.05f, 1f) * 10) / 10;

            listing_Standard.GapLine();

            //infectionChance
            listing_Standard.Label("Bloodmoon_infectionChance".Translate() + " (" + settings.infectionChance + "%)");
            settings.infectionChance = (int)(listing_Standard.Slider(settings.infectionChance, 0, 100));

            //elixirFailChance
            listing_Standard.Label("Bloodmoon_elixirFailChance".Translate() + " (" + settings.elixirFailChance + "%)");
            settings.elixirFailChance = (int)listing_Standard.Slider(settings.elixirFailChance, 1, 100);

            listing_Standard.GapLine();

            //reset
            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "Bloodmoon_default".Translate());
            if(Widgets.ButtonText(rectDefault, "Bloodmoon_default".Translate(), true, true, true))
            {
                Bloodmoon_ModSettings.resetSettings(settings);
            }

            listing_Standard.Gap();

            //reset
            Rect rectPresetClassic = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPresetClassic, "Bloodmoon_classicTooltip".Translate());
            if (Widgets.ButtonText(rectPresetClassic, "Bloodmoon_classic".Translate(), true, true, true))
            {
                PresetSettings.Preset_Classic(settings);
            }

            listing_Standard.End();
            Widgets.EndScrollView();
            base.DoSettingsWindowContents(inRect);
        }
    }
}
