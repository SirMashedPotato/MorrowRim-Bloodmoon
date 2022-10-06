using System;
using Verse;
using RimWorld;
using RimWorld.Planet;

namespace MorrowRim_Bloodmoon
{
    class HediffCompProperties_HircineMarked : HediffCompProperties
    {
        public HediffCompProperties_HircineMarked()
        {
            this.compClass = typeof(HediffComp_HircineMarked);
        }

        public bool displayMessage = true;
        public bool questEnd = false;
        public bool sendRewards = true;
        public int numRewards = 1;
    }
}
