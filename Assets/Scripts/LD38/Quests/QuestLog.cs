using UnityEngine;
using UnityEngine.UI;

namespace LD38.Quests
{
    /// <summary>
    /// This class handles all active quests and the UI
    /// </summary>
    public class QuestLog
    {
        #region PROTECTED_VARS

        /// <summary>
        /// The current quest
        /// </summary>
        protected IQuest CurrentQuest;

        /// <summary>
        /// The text that shows the short description of the active quest
        /// </summary>
        protected Text QuestInfo;

        /// <summary>
        /// The text that shows the long description of the current quest
        /// </summary>
        protected Text LongQuestInfo;

        /// <summary>
        /// The panel which is shown at the right top side
        /// </summary>
        protected RectTransform QuestSidePanel;

        /// <summary>
        /// The panel which is shown in the middle of the screen
        /// </summary>
        protected RectTransform QuestBigPanel;

        /// <summary>
        /// The button that the player needs to press to continue the game
        /// </summary>
        protected Button QuestButton;

        protected bool DialogOpen;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Find all references that are necessary
        /// </summary>
        /// <param name="sidePanel"></param>
        /// <param name="bigPanel"></param>
        public QuestLog(RectTransform sidePanel, RectTransform bigPanel)
        {
            QuestSidePanel = sidePanel;
            QuestBigPanel = bigPanel;

            QuestInfo = sidePanel.FindChild("Quest_Description").GetComponent<Text>();
            LongQuestInfo = bigPanel.FindChild("Quest_Description").GetComponent<Text>();
            QuestButton = bigPanel.FindChild("Button").GetComponent<Button>();

            AddButtonClickListener();
        }

        #endregion

        #region PUBLIC_METHODS

        /// <summary>
        /// Start a new quest:
        /// - Fetch a quest object from the factory
        /// - Start this quest
        /// - Update the UI texts and panels
        /// </summary>
        /// <param name="quest"></param>
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

            DialogOpen = true;
        }

        /// <summary>
        /// Should be called every frame. Checks if the current quest has finished. If so, the "End" method
        /// will be called and the current quest will be reseted.
        /// </summary>
        public virtual void Update()
        {
            if (CurrentQuest == null || !CurrentQuest.IsFinished(this)) return;

            var quest = CurrentQuest;
            QuestInfo.text = "All done!";
            CurrentQuest = null;
            quest.End(this);
        }

        public bool IsDialogOpen
        {
            get { return DialogOpen;  }
        }

        #endregion

        #region PROTECTED_METHODS

        protected void AddButtonClickListener()
        {
            QuestButton.onClick.AddListener(() =>
            {
                QuestBigPanel.gameObject.SetActive(false);
                QuestSidePanel.gameObject.SetActive(true);

                DialogOpen = false;

                Main.Get.SetLockedState(true);
            });
        }

        #endregion
    }
}