using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld.BaseGen;
using Verse;
using RimWorld;
using Verse.AI.Group;
using RimWorld.Planet;
using UnityEngine;

namespace MorrowRim_Bloodmoon
{
    class GenStep_WerewolfPack : GenStep
    {
		public override int SeedPart
		{
			get
			{
				return 658435124;
			}
		}

		public override void Generate(Map map, GenStepParams parms)
		{
			TraverseParms traverseParams = TraverseParms.For(TraverseMode.NoPassClosedDoors, Danger.Deadly, false, false, false).WithFenceblocked(true);
			IntVec3 root;
			if (RCellFinder.TryFindRandomCellNearTheCenterOfTheMapWith((IntVec3 x) => x.Standable(map) && !x.Fogged(map) && map.reachability.CanReachMapEdge(x, traverseParams) && x.GetRoom(map).CellCount >= this.MinRoomCells, map, out root))
			{
				//Log.Message("parms + " + parms.sitePart.expectedEnemyCount);
				//int num = GetEnemiesCount(parms.sitePart.parms);
				int num = parms.sitePart.expectedEnemyCount;
				List<Pawn> list = new List<Pawn>();
				Faction faction = FactionUtility.DefaultFactionFrom(FactionDefOf.MorrowRim_HoundsOfHircine);

				for (int i = 0; i < num; i++)
				{
					IntVec3 loc = CellFinder.RandomSpawnCellForPawnNear(root, map, 10);
					Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDefOf.MorrowRim_Werewolf, null);
					pawn.SetFaction(faction);
					GenSpawn.Spawn(pawn, loc, map, Rot4.Random, WipeMode.Vanish, false);

					if (ModSettings_Utility.SettingToFloat(ModSettings_Utility.WerewolfStrength_int()) != 0f)
					{
						pawn.health.AddHediff(HediffDefOf.MorrowRim_BloodOfHircine).Severity = ModSettings_Utility.SettingToFloat(ModSettings_Utility.WerewolfStrength_int());
					}
					if (Rand.Chance(ModSettings_Utility.SettingToFloat(ModSettings_Utility.GiftedWerewolfChance())))
					{
						pawn.health.AddHediff(Utility.ChoosesRandomGift()).Severity = 1f;
					}

					list.Add(pawn);
				}

				if (list.Any<Pawn>())
				{
					LordMaker.MakeNewLord(faction, new LordJob_HuntColony(faction, true, true), list.ElementAt(0).Map, list);
				}

			}
		}

		public FloatRange defaultPointsRange = new FloatRange(300f, 500f);

		private int MinRoomCells = 225;
	}
}
