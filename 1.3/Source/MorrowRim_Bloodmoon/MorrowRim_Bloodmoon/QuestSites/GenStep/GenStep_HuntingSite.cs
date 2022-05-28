using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    class GenStep_HuntingSite : GenStep
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
				IntVec3 loc = CellFinder.RandomSpawnCellForPawnNear(root, map, 10);
				Pawn pawn = PawnGenerator.GeneratePawn(parms.sitePart.parms.animalKind, null);
				GenSpawn.Spawn(pawn, loc, map, Rot4.Random, WipeMode.Vanish, false);

				pawn.health.hediffSet.hediffs.Clear();

				pawn.health.AddHediff(HediffDefOf.MorrowRim_HircineGreatBeast).TryGetComp<HediffComp_HircineMarked>().site = parms.sitePart.site;

				int num = Rand.RangeInclusive(3, 7);
				for(int i = 0; i < num; i++)
                {
					pawn.health.AddHediff(HediffDefOf.MorrowRim_HircineBattleScar, pawn.health.hediffSet.GetRandomNotMissingPart(Rand.Chance(0.5f) ? DamageDefOf.Stab : DamageDefOf.Cut));
                }

                if (Rand.Chance(0.25f))
                {
					pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent);
				}
			}
		}

		private int MinRoomCells = 225;
	}
}
