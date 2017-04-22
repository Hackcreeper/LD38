using LD38.Quests;
using UnityEngine;
using UnityEngine.UI;

namespace LD38
{
    public class Main : MonoBehaviour
    {
        #region PROTECTED_VARS

        protected QuestLog Log;

        protected static Main Instance;

        [SerializeField] protected Text QuestInfoText;

        [SerializeField] protected Text ObjectInfoText;

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

        #endregion

        #region PROTECTED_METHODS

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            Log = new QuestLog(QuestInfoText);
            Log.Start(Quest.FindTheAntenna);
        }

        protected virtual void Update()
        {
            Log.Update();
        }

        #endregion
    }
}
