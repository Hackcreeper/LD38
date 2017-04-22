using LD38.Objects;
using UnityEngine;

namespace LD38.Quests
{
    public class RepairTheAntenna : IQuest
    {
        #region PROTECTED_VARS

        protected Antenna Antenna;

        #endregion

        #region PUBLIC_METHODS

        public void Start(QuestLog log)
        {
            Antenna = Object.FindObjectOfType<Antenna>();
            Antenna.Enable();
        }

        public bool IsFinished(QuestLog log)
        {
            return Antenna.GetState() == AntennaState.Repaired;
        }

        public void End(QuestLog log)
        {
            Antenna.Disable();
        }

        public string GetDescription()
        {
            return "Repair the broken antenna!";
        }

        public string GetLongDescription()
        {
            return "Oh yeah.. i like it!";
        }

        #endregion
    }
}