using UnityEngine;

namespace LD38.Quests
{
    public class FindTheBase : IQuest
    {
        #region PROTECTED_VARS

        protected Transform Base;

        #endregion

        #region PUBLIC_METHODS

        public void Start(QuestLog log)
        {
            Base = GameObject.FindGameObjectWithTag("Base").transform;
        }

        public bool IsFinished(QuestLog log)
        {
            return Vector3.Distance(Main.Get.Player.position, Base.position) <= 10f;
        }

        public void End(QuestLog log)
        {
            log.Start(Quest.AnalyseTheAntenna);
        }

        public string GetDescription()
        {
            return "Find the base!";
        }

        public string GetLongDescription()
        {
            return "You are landed on the micro planet \"Delta-8X34\".\n" +
                   "Your mission: Find and repair a broken antenna for military purposes.\n\n" +
                   "This was once an old military base. After the war of the chicken, this base " +
                   "was empty but since 4 days the contact to an observation antenna is lost.\n\n" +
                   "You should start by finding the old military base.";
        }

        #endregion
    }
}