using LD38.Objects;
using UnityEngine;

namespace LD38.Quests
{
    public class FindTheAntenna : IQuest
    {
        #region PROTECTED_VARS

        protected Antenna Antenna;

        #endregion

        #region PUBLIC_METHODS

        public void Start(QuestLog log)
        {
            Antenna = Object.FindObjectOfType<Antenna>();
        }

        public bool IsFinished(QuestLog log)
        {
            return Antenna.GetState() == AntennaState.Inspected;
        }

        public void End(QuestLog log)
        {
            Antenna.Disable();
            log.Start(Quest.TakeOresFromTheMine);
        }

        public string GetDescription()
        {
            return "Find the broken antenna!";
        }

        public string GetLongDescription()
        {
            return "You arrived [...] and so on [...] rubber [...] slave [...] BOOM!";
        }

        #endregion
    }
}