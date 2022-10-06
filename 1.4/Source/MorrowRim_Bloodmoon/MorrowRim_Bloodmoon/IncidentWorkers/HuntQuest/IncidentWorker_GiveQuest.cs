using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bloodmoon
{
    class IncidentWorker_GiveQuest : IncidentWorker
    {
        /*
         * A simplified version of GiveQuest, added to ensure the VEA tab doesn't run like shit
         */
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            if (!base.CanFireNowSub(parms) && !Utility.HoundsFactionFound(def.label))
            {
                return false;
            }

            return PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists_NoCryptosleep.Any<Pawn>();
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Quest quest = QuestUtility.GenerateQuestAndMakeAvailable(this.def.questScriptDef, parms.points);
            QuestUtility.SendLetterQuestAvailable(quest);
            return true;
        }
    }
}
