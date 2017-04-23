using LD38.Spaceship;
using UnityEngine;

namespace LD38.Quests
{
    public class GoBackToSpaceship : IQuest
    {
        #region PROTECTED_VARS

        protected Ship Spaceship;

        #endregion

        #region PUBLIC_METHODS

        public void Start(QuestLog log)
        {
            Spaceship = Object.FindObjectOfType<Ship>();
            Spaceship.Enable();
        }

        public bool IsFinished(QuestLog log)
        {
            return false;
        }

        public void End(QuestLog log)
        {
            Main.Get.Win();
        }

        public string GetDescription()
        {
            return "Go back to your spaceship!";
        }

        public string GetLongDescription()
        {
            return "The antenna is repaired! Good job!\n\n" +
                   "You should now go to your spaceship and leave this planet.";
        }

        #endregion
    }
}