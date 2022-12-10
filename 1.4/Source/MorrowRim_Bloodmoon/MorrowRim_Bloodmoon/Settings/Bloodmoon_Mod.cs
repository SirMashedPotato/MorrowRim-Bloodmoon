using RimWorld;
using UnityEngine;
using Verse;
using System.Collections.Generic;
using System;

namespace MorrowRim_Bloodmoon
{
    class Bloodmoon_Mod : Mod
    {

        Bloodmoon_ModSettings settings;

        public Bloodmoon_Mod(ModContentPack contentPack) : base(contentPack)
        {
            this.settings = GetSettings<Bloodmoon_ModSettings>();
        }

        public override string SettingsCategory() => "Bloodmoon_ModName".Translate();

        private int page = 1;

        private static Vector2 scrollPosition = Vector2.zero;

        /* ==========[Main Navigation]========== */

        public override void DoSettingsWindowContents(Rect inRect)
        {

            var firstColumnWidth = (inRect.width - Listing.ColumnSpacing) * 3.5f / 5f;
            var secondColumnWidth = inRect.width - Listing.ColumnSpacing - firstColumnWidth;

            var outerRect = new Rect(inRect.x, inRect.y, firstColumnWidth, inRect.height);
            var innerRect = new Rect(0f, 0f, firstColumnWidth - 24f, inRect.height * 2);
            Widgets.BeginScrollView(outerRect, ref scrollPosition, innerRect, true);

            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            switch (page)
            {
                case 1:
                    listing_Standard = SettingsPage_Bloodmoon(listing_Standard);
                    break;
                case 2:
                    listing_Standard = SettingsPage_Werewolves(listing_Standard);
                    break;
                case 3:
                    listing_Standard = SettingsPage_Incidents(listing_Standard);
                    break;
                case 4:
                    listing_Standard = SettingsPage_Lycanthropy(listing_Standard);
                    break;
                default:
                    listing_Standard = SettingsPage_Werewolves(listing_Standard);
                    break;
            }

            listing_Standard.End();
            Widgets.EndScrollView();
            base.DoSettingsWindowContents(inRect);

            //buttons pane
            outerRect.x += firstColumnWidth + Listing.ColumnSpacing;
            outerRect.width = secondColumnWidth;

            listing_Standard = new Listing_Standard();
            listing_Standard.Begin(outerRect);
            SettingsButtons(listing_Standard);
            listing_Standard.End();
        }

        private Listing_Standard SettingsButtons(Listing_Standard listing_Standard)
        {
            listing_Standard.Gap();

            Rect recPage2 = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(recPage2, "Bloodmoon_PageBloodmoon".Translate());
            if (Widgets.ButtonText(recPage2, "Bloodmoon_PageBloodmoon".Translate(), true, true, true))
            {
                page = 1;
            }
            listing_Standard.Gap();

            Rect recPage1 = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(recPage1, "Bloodmoon_PageWerewolves".Translate());
            if (Widgets.ButtonText(recPage1, "Bloodmoon_PageWerewolves".Translate(), true, true, true))
            {
                page = 2;
            }
            listing_Standard.Gap();

            Rect recPage3 = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(recPage3, "Bloodmoon_PageIncidents".Translate());
            if (Widgets.ButtonText(recPage3, "Bloodmoon_PageIncidents".Translate(), true, true, true))
            {
                page = 3;
            }
            listing_Standard.Gap();

            Rect recPage4 = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(recPage4, "Bloodmoon_PageLycanthropy".Translate());
            if (Widgets.ButtonText(recPage4, "Bloodmoon_PageLycanthropy".Translate(), true, true, true))
            {
                page = 4;
            }
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* Resets */
            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "Bloodmoon_default".Translate());
            if (Widgets.ButtonText(rectDefault, "Bloodmoon_default".Translate(), true, true, true))
            {
                Bloodmoon_ModSettings.ResetSettings();
            }
            listing_Standard.Gap();
            ResetButtonForPage(listing_Standard);
            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* Presets */
            Rect rectPresetPeaceful = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPresetPeaceful, "Bloodmoon_classicTooltip".Translate());
            if (Widgets.ButtonText(rectPresetPeaceful, "Bloodmoon_classic".Translate(), true, true, true))
            {
                PresetSettings.Preset_Classic(settings);
            }
            listing_Standard.Gap();

            return listing_Standard;
        }

        private void ResetButtonForPage(Listing_Standard listing_Standard)
        {
            Rect rectDefault = listing_Standard.GetRect(30f);
            switch (page)
            {
                case 1:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "Bloodmoon_default_page".Translate());
                    if (Widgets.ButtonText(rectDefault, "Bloodmoon_default_page".Translate(), true, true, true))
                    {
                        Bloodmoon_ModSettings.ResetSettings_Bloodmoon();
                    }
                    break;
                case 2:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "Bloodmoon_default_page".Translate());
                    if (Widgets.ButtonText(rectDefault, "Bloodmoon_default_page".Translate(), true, true, true))
                    {
                        Bloodmoon_ModSettings.ResetSettings_Werewolves();
                    }
                    break;

                case 3:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "Bloodmoon_default_page".Translate());
                    if (Widgets.ButtonText(rectDefault, "Bloodmoon_default_page".Translate(), true, true, true))
                    {
                        Bloodmoon_ModSettings.ResetSettings_IncidentsAndQuests();
                    }
                    break;
                case 4:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "Bloodmoon_default_page".Translate());
                    if (Widgets.ButtonText(rectDefault, "Bloodmoon_default_page".Translate(), true, true, true))
                    {
                        Bloodmoon_ModSettings.ResetSettings_LycanthropyAndGifts();
                    }
                    break;
                default:
                    break;
            }
        }

        /* ==========[Individual Pages]========== */

        private Listing_Standard SettingsPage_Werewolves(Listing_Standard listing_Standard)
        {

            listing_Standard.Label("Bloodmoon_PageWerewolves".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_raidModifier".Translate() + " (" + settings.raidModifier + "x)");
            settings.raidModifier = (float)Mathf.Round(listing_Standard.Slider(settings.raidModifier, 0.1f, 10f) * 10) / 10;
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_minWerewolfNum".Translate() + " (" + settings.minWerewolfNum + ")");
            settings.minWerewolfNum = (int)listing_Standard.Slider(settings.minWerewolfNum, 1, settings.maxWerewolfNum);
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_maxWerewolfNum".Translate() + " (" + settings.maxWerewolfNum + ")");
            settings.maxWerewolfNum = (int)listing_Standard.Slider(settings.maxWerewolfNum, settings.minWerewolfNum, 500);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_werewolfStrength".Translate() + " (" + settings.werewolfStrength + "%)");
            settings.werewolfStrength = (int)Math.Round(listing_Standard.Slider(settings.werewolfStrength, 0.0f, 100) / 5) * 5;
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_chanceOfGiftedWerewolf".Translate() + " (" + (settings.chanceOfGiftedWerewolf) + "%)");
            settings.chanceOfGiftedWerewolf = (int)listing_Standard.Slider(settings.chanceOfGiftedWerewolf, 0, 100);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        private Listing_Standard SettingsPage_Bloodmoon(Listing_Standard listing_Standard)
        {

            listing_Standard.Label("Bloodmoon_PageBloodmoon".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* ===== Misc ===== */

            listing_Standard.CheckboxLabeled("Bloodmoon_enableStrengthScaling".Translate(), ref settings.enableStrengthScaling, "Bloodmoon_enableStrengthScalingTooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Bloodmoon_enableBloodmoonAmbushes".Translate(), ref settings.enableBloodmoonAmbushes);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Bloodmoon_enableBloodmoonTransforming".Translate(), ref settings.enableBloodmoonTransforming);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* ===== Notifications ===== */

            listing_Standard.CheckboxLabeled("Bloodmoon_enableBloodmoonTracker".Translate(), ref settings.enableBloodmoonTracker);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Bloodmoon_enableMessages".Translate(), ref settings.enableMessages);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("Bloodmoon_enableLetters".Translate(), ref settings.enableLetters);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* ===== Werewolf Packs ===== */

            listing_Standard.Label("Bloodmoon_minTicksPerEvent".Translate() + " (" + settings.minTicksPerEvent + ")");
            settings.minTicksPerEvent = (int)Math.Round(listing_Standard.Slider(settings.minTicksPerEvent, 0, settings.maxTicksPerEvent) / 50) * 50;
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_maxTicksPerEvent".Translate() + " (" + settings.maxTicksPerEvent + ")");
            settings.maxTicksPerEvent = (int)Math.Round(listing_Standard.Slider(settings.maxTicksPerEvent, settings.minTicksPerEvent, 50000) / 50) * 50;
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* ===== Avatars ===== */

            listing_Standard.Label("Bloodmoon_extraAvatarChance".Translate() + " (" + (settings.extraAvatarChance) + "%)");
            settings.extraAvatarChance = (int)listing_Standard.Slider(settings.extraAvatarChance, 0, 100);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* ===== Marked Animals ===== */

            listing_Standard.CheckboxLabeled("Bloodmoon_enableMarking".Translate(), ref settings.animalMarking);
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_minTicksPerMark".Translate() + " (" + settings.minTicksPerMark + ")");
            settings.minTicksPerMark = (int)Math.Round(listing_Standard.Slider(settings.minTicksPerMark, 0, settings.maxTicksPerMark) / 50) * 50;
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_maxTicksPerMark".Translate() + " (" + settings.maxTicksPerMark + ")");
            settings.maxTicksPerMark = (int)Math.Round(listing_Standard.Slider(settings.maxTicksPerMark, settings.minTicksPerMark, 50000) / 50) * 50;
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* ===== Loot Drops ===== */

            listing_Standard.CheckboxLabeled("Bloodmoon_enableLootDrops".Translate(), ref settings.enableLootDrops);
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_minNumberOfLootDrops".Translate() + " (" + settings.minNumberOfLootDrops + ")");
            settings.minNumberOfLootDrops = (int)listing_Standard.Slider(settings.minNumberOfLootDrops, 0, settings.maxNumberOfLootDrops);
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_maxNumberOfLootDrops".Translate() + " (" + settings.maxNumberOfLootDrops + ")");
            settings.maxNumberOfLootDrops = (int)listing_Standard.Slider(settings.maxNumberOfLootDrops, settings.minNumberOfLootDrops, 50);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        private Listing_Standard SettingsPage_Lycanthropy(Listing_Standard listing_Standard)
        {

            listing_Standard.Label("Bloodmoon_PageLycanthropy".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //infectionChance
            listing_Standard.Label("Bloodmoon_infectionChance".Translate() + " (" + settings.infectionChance + "%)");
            settings.infectionChance = (int)(listing_Standard.Slider(settings.infectionChance, 0, 100));
            listing_Standard.Gap();

            //elixirFailChance
            listing_Standard.Label("Bloodmoon_elixirFailChance".Translate() + " (" + settings.elixirFailChance + "%)");
            settings.elixirFailChance = (int)listing_Standard.Slider(settings.elixirFailChance, 1, 100);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_huntersGiftBuildup".Translate() + " (" + (settings.huntersGiftBuildup * 100) + "%)");
            settings.huntersGiftBuildup = (float)Math.Round(listing_Standard.Slider(settings.huntersGiftBuildup, 0.05f, 1f) * 20) / 20;
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_huntersGiftMaximum".Translate() + " (" + (settings.huntersGiftMaximum * 100) + "%)");
            settings.huntersGiftMaximum = (float)Math.Round(listing_Standard.Slider(settings.huntersGiftMaximum, 0f, 1f) * 10) / 10;
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        private Listing_Standard SettingsPage_Incidents(Listing_Standard listing_Standard)
        {

            listing_Standard.Label("Bloodmoon_PageIncidents".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //Cycle
            listing_Standard.CheckboxLabeled("Bloodmoon_enableBloodmoonCycleForAll".Translate(), ref settings.enableBloodmoonCycleForAll);
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_incidentMinimumDaysCycle".Translate() + " (" + settings.incidentMinimumDaysCycle + " days)");
            settings.incidentMinimumDaysCycle = (int)listing_Standard.Slider(settings.incidentMinimumDaysCycle, 1, 180);
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_incidentIntervalCycle".Translate() + " (" + settings.incidentIntervalCycle + " days)");
            settings.incidentIntervalCycle = (float)Math.Round(listing_Standard.Slider(settings.incidentIntervalCycle, 1, 180), 0);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            //Rogue
            listing_Standard.CheckboxLabeled("Bloodmoon_enableBloodmoonForAll".Translate(), ref settings.enableBloodmoonForAll);
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_incidentMinimumDaysRogue".Translate() + " (" + settings.incidentMinimumDaysRogue + " days)");
            settings.incidentMinimumDaysRogue = (int)listing_Standard.Slider(settings.incidentMinimumDaysRogue, 1, 180);
            listing_Standard.Gap();

            listing_Standard.Label("Bloodmoon_incidentIntervalRogue".Translate() + " (" + settings.incidentIntervalRogue + " days)");
            settings.incidentIntervalRogue = (float)Math.Round(listing_Standard.Slider(settings.incidentIntervalRogue, 1, 180), 0);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            //enableWerewolfPack
            listing_Standard.CheckboxLabeled("Bloodmoon_enableWerewolfPack".Translate(), ref settings.enableWerewolfPack);
            listing_Standard.Gap();

            //enableWerewolfLord
            listing_Standard.CheckboxLabeled("Bloodmoon_enableWerewolfLord".Translate(), ref settings.enableWerewolfLord);
            listing_Standard.Gap();

            //enableHircineHunt
            listing_Standard.CheckboxLabeled("Bloodmoon_enableHircineHunts".Translate(), ref settings.enableHircineHunts);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }
    }
}
