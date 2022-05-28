using Verse;
using RimWorld;
using UnityEngine;
using System.Collections.Generic;

namespace MorrowRim_Bloodmoon
{
    class DeathActionWorker_AvatarOfHircine : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse)
        {
            Pawn pawn = corpse.InnerPawn;
            bool gift = false;
            //check = hediffs, spawn totem
            if (pawn.health.hediffSet.HasHediff(HediffDefOf.MorrowRim_GiftOfGuile))
            {
                GenSpawn.Spawn(ThingDefOf.MorrowRim_TotemGuile, corpse.Position, corpse.Map);
                gift = true;
            }
            if (pawn.health.hediffSet.HasHediff(HediffDefOf.MorrowRim_GiftOfSpeed))
            {
                GenSpawn.Spawn(ThingDefOf.MorrowRim_TotemSpeed, corpse.Position, corpse.Map);
                gift = true;
            }
            if (pawn.health.hediffSet.HasHediff(HediffDefOf.MorrowRim_GiftOfStrength))
            {
                GenSpawn.Spawn(ThingDefOf.MorrowRim_TotemStrength, corpse.Position, corpse.Map);
                gift = true;
            }
            if (pawn.health.hediffSet.HasHediff(HediffDefOf.MorrowRim_GiftOfSight))
            {
                GenSpawn.Spawn(ThingDefOf.MorrowRim_TotemSight, corpse.Position, corpse.Map);
                gift = true;
            }
            if (pawn.def == ThingDefOf.MorrowRim_WerewolfLord)
            {
                GenSpawn.Spawn(ThingDefOf.MorrowRim_TotemWerewolfLord, corpse.Position, corpse.Map);
                gift = true;
                BloodmoonWorldComp.DecreaseStrength();
            }

            if (gift)
            {
                Vector3 vector = corpse.Position.ToVector3Shifted();
                FleckMaker.ThrowDustPuffThick(new Vector3(vector.x, 0f, vector.z)
                {
                    y = AltitudeLayer.MoteOverhead.AltitudeFor()
                }, corpse.Map, Rand.Range(1.5f, 3f), new Color(1f, 1f, 1f, 2.5f));

                corpse.Destroy();
            }
        }
    }
}