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

        public void Start()
        {
            Antenna = Object.FindObjectOfType<Antenna>();
        }

        public bool IsFinished()
        {
            return Antenna.GetState() == AntennaState.Inspected;
        }

        public void End()
        {
            Antenna.Disable();
        }

        public string GetDescription()
        {
            return "Find the broken antenna!";
        }

        #endregion
    }
}