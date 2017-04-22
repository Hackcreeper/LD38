using UnityEngine;
using UnityEngine.UI;

namespace LD38.Quests
{
    public class QuestLog
    {
        #region PROTECTED_VARS

        protected IQuest CurrentQuest;

        protected Text QuestInfo;

        #endregion

        #region CONSTRUCTOR

        public QuestLog(Text infoText)
        {
            QuestInfo = infoText;
        }

        #endregion

        #region PUBLIC_METHODS

        public virtual void Start(Quest quest)
        {
            CurrentQuest = QuestFactory.Make(quest);
            CurrentQuest.Start();

            // Update the UI
            QuestInfo.text = CurrentQuest.GetDescription();
        }

        public virtual void Update()
        {
            if (CurrentQuest == null || !CurrentQuest.IsFinished()) return;

            Debug.Log("FINISHED!!!!");

            var quest = CurrentQuest;
            QuestInfo.text = "All done!";
            CurrentQuest = null;
            quest.End();
        }

        #endregion
    }
}