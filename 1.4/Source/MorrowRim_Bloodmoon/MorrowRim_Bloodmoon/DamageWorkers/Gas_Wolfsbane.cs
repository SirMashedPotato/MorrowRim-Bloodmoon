using System;
using Verse;
using RimWorld;
using System.Collections.Generic;
using UnityEngine;

namespace MorrowRim_Bloodmoon
{
    class Gas_Wolfsbane : Gas
    {
        private int tickerInterval = 0;
        private int tickerMax = 120;
        public override void Tick()
        {
            base.Tick();
            try
            {
                if (tickerInterval >= tickerMax)
                {
                    HashSet<Thing> hashSet = new HashSet<Thing>(this.Position.GetThingList(this.Map));
                    if (hashSet != null)
                    {
                        foreach (Thing thing in hashSet)
                        {
                            //check if is pawn
                            if (thing != null && thing is Pawn)
                            {
                                Pawn p = thing as Pawn;
                                if (p.def == ThingDefOf.MorrowRim_Werewolf || (Utility.ROMWerewolvesLoaded() && Utility.ROMWerewolves_CheckTrait(p)))
                                {
                                    Utility.BurnWerewolf(p);
                                }
                            }
                        }
                    }
                    tickerInterval = 0;
                }
                tickerInterval++;
            }
            catch (NullReferenceException e)
            {

            }
        }
    }
}
