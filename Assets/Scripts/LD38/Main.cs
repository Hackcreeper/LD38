using System.Security.Policy;
using LD38.Quests;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace LD38
{
    public class Main : MonoBehaviour
    {
        #region PROTECTED_VARS

        protected QuestLog Log;

        protected ResourceManager ResourceManager;

        protected static Main Instance;

        protected bool IsLocked = false;

        [SerializeField] protected RectTransform QuestSidePanel;

        [SerializeField] protected RectTransform QuestBigPanel;

        [SerializeField] protected Text ObjectInfoText;

        [SerializeField] protected RectTransform WinPanel;

        #endregion

        #region PUBLIC_METHODS

        public virtual void SetObjectText(string txt)
        {
            ObjectInfoText.text = txt;
        }

        public static Main Get
        {
            get { return Instance;  }
        }

        public Transform Player
        {
            get { return GameObject.FindGameObjectWithTag("Player").transform;  }
        }

        public void SetLockedState(bool locked)
        {
            IsLocked = locked;

            Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !locked;
        }

        public bool GetLockedState()
        {
            return IsLocked;
        }

        public ResourceManager Resources
        {
            get { return ResourceManager; }
        }

        public void Win()
        {
            SetLockedState(false);
            WinPanel.gameObject.SetActive(true);
        }

        #endregion

        #region PROTECTED_METHODS

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Log = new QuestLog(QuestSidePanel, QuestBigPanel);
            Log.Start(Quest.FindTheAntenna);

            ResourceManager = new ResourceManager();
        }

        protected virtual void Update()
        {
            Log.Update();
        }

        #endregion
    }
}
