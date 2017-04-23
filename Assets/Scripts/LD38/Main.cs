using LD38.Quests;
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

        protected bool IsLocked;

        [SerializeField] protected RectTransform QuestSidePanel;

        [SerializeField] protected RectTransform QuestBigPanel;

        [SerializeField] protected Text ObjectInfoText;

        [SerializeField] protected RectTransform WinPanel;

        [SerializeField] protected GameObject RepairedAntenna;

        [SerializeField] protected GameObject BrokenAntenna;

        [SerializeField] protected Transform Laser;

        protected bool Started;

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

        public void RepairAntenna()
        {
            BrokenAntenna.SetActive(false);
            RepairedAntenna.SetActive(true);
        }

        public bool HasGameStarted
        {
            get { return Started; }
        }

        public void StartGame()
        {
            Player.gameObject.SetActive(true);
            Camera.main.transform.SetParent(Player);
            Camera.main.transform.localPosition = new Vector3(0, 1, 0);
            Laser.gameObject.SetActive(true);

            Log.Start(Quest.FindTheAntenna);
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

            ResourceManager = new ResourceManager();
        }

        protected virtual void Update()
        {
            Log.Update();
        }

        #endregion
    }
}
