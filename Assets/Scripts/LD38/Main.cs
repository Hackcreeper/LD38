using LD38.Quests;
using UnityEngine;
using UnityEngine.UI;

namespace LD38
{
    public class Main : MonoBehaviour
    {
        #region PROTECTED_VARS

        protected QuestLog Log;

        [SerializeField] protected Text QuestInfoText;

        #endregion

        #region PROTECTED_METHODS

        protected virtual void Awake()
        {
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
