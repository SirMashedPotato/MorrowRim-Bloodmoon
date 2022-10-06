using RimWorld;
using Verse;
using System.Collections.Generic;
using Verse.AI.Group;
using UnityEngine;

namespace MorrowRim_Bloodmoon
{
    class IngestionOutcomeDoer_LycanthropicSeparation : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested)
        {
            if(pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_DormantSaniesLupinus) != null)
            {
                pawn.health.RemoveHediff(pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_DormantSaniesLupinus));

                IntVec3 loc = CellFinder.RandomSpawnCellForPawnNear(pawn.Position, pawn.Map);
                Pawn werewolf = PawnGenerator.GeneratePawn(PawnKindDefOf.MorrowRim_Werewolf, null);
                GenSpawn.Spawn(werewolf, loc, pawn.Map, Rot4.Random, WipeMode.Vanish, false);
                werewolf.health.AddHediff(HediffDefOf.MorrowRim_LycanthropicUnbinding);

                //MoteMaker.MakeAttachedOverlay(werewolf, RimWorld.FleckDefOf.PsycastPsychicLine, Vector3.zero, 1f, -1f);

                Faction faction = FactionUtility.DefaultFactionFrom(FactionDefOf.MorrowRim_HoundsOfHircine);
                werewolf.SetFactionDirect(faction);
                List<Pawn> list = new List<Pawn> { werewolf };
                LordMaker.MakeNewLord(faction, new LordJob_HuntColony(faction, true, true), werewolf.Map, list);
            }
        }
    }
}