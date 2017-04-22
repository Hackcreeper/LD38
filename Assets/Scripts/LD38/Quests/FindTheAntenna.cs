using UnityEngine;

namespace LD38.Quests
{
    public class FindTheAntenna : IQuest
    {
        #region PROTECTED_VARS

        protected Transform Antenna;

        #endregion

        #region PUBLIC_METHODS

        public void Start()
        {
            Antenna = GameObject.FindGameObjectWithTag("Antenna").transform;
            Player
        }

        public bool IsFinished(Transform player)
        {

        }

        public void End()
        {
        }

        public string GetDescription()
        {
            return "Find the broken antenna!";
        }

        #endregion
    }
}