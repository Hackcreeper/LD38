using LD38.Objects;
using UnityEngine;

namespace LD38.Quests
{
    /// <summary>
    /// Quest: Analyse the broken antenna.
    /// Goal: Interact with the broken antenna
    /// </summary>
    public class AnalyseTheAntenna : IQuest
    {
        #region PROTECTED_VARS

        /// <summary>
        /// The antenna instance
        /// </summary>
        protected Antenna Antenna;

        /// <summary>
        /// The ore instance
        /// </summary>
        protected Ore Ore;

        #endregion

        #region PUBLIC_METHODS

        /// <summary>
        /// When the quests starts the antenna will be fetched
        /// </summary>
        /// <param name="log">The active quest log</param>
        public void Start(QuestLog log)
        {
            Antenna = Object.FindObjectOfType<Antenna>();
            Ore = Object.FindObjectOfType<Ore>();
        }

        /// <summary>
        /// The quests is finished if the antenna state is 'Inspected'
        /// </summary>
        /// <param name="log">The active quest log</param>
        /// <returns></returns>
        public bool IsFinished(QuestLog log)
        {
            return Antenna.GetState() == AntennaState.Inspected;
        }

        /// <summary>
        /// After the quest is finished, the antenna will be deactivated and the next quest:
        /// 'Take Ores from the mine' starts.
        /// </summary>
        /// <param name="log">The active quest log</param>
        public void End(QuestLog log)
        {
            Antenna.Disable();
            Ore.Enable();

            log.Start(Quest.TakeOresFromTheMine);
        }

        /// <summary>
        /// The description of the quest
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return "Analyse the broken antenna!";
        }

        /// <summary>
        /// The long description with story / background
        /// </summary>
        /// <returns></returns>
        public string GetLongDescription()
        {
            return "The base is still intact. You should begin to analyse the broken antenna.";
        }

        #endregion
    }
}