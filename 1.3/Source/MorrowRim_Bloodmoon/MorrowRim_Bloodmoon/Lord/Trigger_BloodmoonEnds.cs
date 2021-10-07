using System;
using Verse.AI.Group;

namespace MorrowRim_Bloodmoon
{
    class Trigger_BloodmoonEnds : Trigger
    {
        public override bool ActivateOn(Lord lord, TriggerSignal signal)
        {
            return !lord.Map.gameConditionManager.ConditionIsActive(GameConditionDefOf.MorrowRim_Bloodmoon);
        }
    }
}
