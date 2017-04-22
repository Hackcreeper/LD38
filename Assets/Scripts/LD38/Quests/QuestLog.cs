using UnityEngine;
using UnityEngine.UI;

namespace LD38.Quests
{
    public class QuestLog
    {
        #region PROTECTED_VARS

        protected IQuest CurrentQuest;

        protected Text QuestInfo;

        protected Text LongQuestInfo;

        protected RectTransform QuestSidePanel;

        protected RectTransform QuestBigPanel;

        protected Button QuestButton;

        #endregion

        #region CONSTRUCTOR

        public QuestLog(RectTransform sidePanel, RectTransform bigPanel)
        {
            QuestSidePanel = sidePanel;
            QuestBigPanel = bigPanel;

            QuestInfo = sidePanel.FindChild("Quest_Description").GetComponent<Text>();
            LongQuestInfo = bigPanel.FindChild("Quest_Description").GetComponent<Text>();
            QuestButton = bigPanel.FindChild("Button").GetComponent<Button>();

            QuestButton.onClick.AddListener(() =>
            {
                QuestBigPanel.gameObject.SetActive(false);
                QuestSidePanel.gameObject.SetActive(true);

                Main.Get.SetLockedState(true);
            });
        }

        #endregion

        #region PUBLIC_METHODS

        public virtual void Start(Quest quest)
        {
            CurrentQuest = QuestFactory.Make(quest);
            CurrentQuest.Start(this);

            // Update the UI
            Main.Get.SetLockedState(false);
            QuestSidePanel.gameObject.SetActive(false);
            QuestBigPanel.gameObject.SetActive(true);

            LongQuestInfo.text = CurrentQuest.GetLongDescription();
            QuestInfo.text = CurrentQuest.GetDescription();
        }

        public virtual void Update()
        {
            if (CurrentQuest == null || !CurrentQuest.IsFinished(this)) return;

            var quest = CurrentQuest;
            QuestInfo.text = "All done!";
            CurrentQuest = null;
            quest.End(this);
        }

        #endregion
    }
}