using LD38.Objects;
using UnityEngine;

namespace LD38.Quests
{
    public class MeltTheOres : IQuest
    {
        #region PROTECTED_VARS

        protected Furnace Furnace;

        #endregion

        #region PUBLIC_METHODS

        public void Start(QuestLog log)
        {
            Furnace = Object.FindObjectOfType<Furnace>();
            Furnace.Enable();
        }

        public bool IsFinished(QuestLog log)
        {
            return false;
        }

        public void End(QuestLog log)
        {
            log.Start(Quest.RepairTheAntenna);
        }

        public string GetDescription()
        {
            return "Melt the ore in the base";
        }

        public string GetLongDescription()
        {
            return "Great! Now you need to melt the ore into metal bars.\n\n" +
                   "The old base does have a furnace.";
        }

        #endregion
    }
}