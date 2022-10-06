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
	class GenStep_WerewolfLord : GenStep
	{
		public override int SeedPart
		{
			get
			{
				return 918672345;
			}
		}
		public override void Generate(Map map, GenStepParams parms)
		{
			TraverseParms traverseParams = TraverseParms.For(TraverseMode.NoPassClosedDoors, Danger.Deadly, false, false, false).WithFenceblocked(true);
			IntVec3 root;
			if (RCellFinder.TryFindRandomCellNearTheCenterOfTheMapWith((IntVec3 x) => x.Standable(map) && !x.Fogged(map) && map.reachability.CanReachMapEdge(x, traverseParams) && x.GetRoom(map).CellCount >= this.MinRoomCells, map, out root))
			{
				Faction faction = FactionUtility.DefaultFactionFrom(FactionDefOf.MorrowRim_HoundsOfHircine);

				IntVec3 loc = CellFinder.RandomSpawnCellForPawnNear(root, map, 10);
				Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDefOf.MorrowRim_WerewolfLord, null);
				pawn.SetFaction(faction);
				GenSpawn.Spawn(pawn, loc, map, Rot4.Random, WipeMode.Vanish, false);

				if (BloodmoonWorldComp.GetBloodStrength() != 0f)
				{
					pawn.health.AddHediff(HediffDefOf.MorrowRim_BloodOfHircine).Severity = BloodmoonWorldComp.GetBloodStrength();
				}
				pawn.health.AddHediff(Utility.ChoosesRandomGift()).Severity = 1f;
				pawn.health.AddHediff(Utility.ChoosesRandomGift()).Severity = 1f;
				pawn.health.AddHediff(HediffDefOf.MorrowRim_WerewolfLordPassive);
				LordMaker.MakeNewLord(faction, new LordJob_HuntColony(faction, false, true), pawn.Map, new List<Pawn> { pawn });
			}
		}

		private int MinRoomCells = 225;
	}
}
