using LD38.Objects;
using UnityEngine;

namespace LD38.Quests
{
    /// <summary>
    /// Quest: Search and find the antenna.
    /// Goal: Interact with the broken antenna
    /// </summary>
    public class FindTheAntenna : IQuest
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
            return "Find the broken antenna!";
        }

        /// <summary>
        /// The long description with story / background
        /// </summary>
        /// <returns></returns>
        public string GetLongDescription()
        {
            return "You are landed on the micro planet \"Delta-8X34\".\n" +
                   "Your mission: Find and repair a broken antenna for military purposes.\n\n" +
                   "This was once an old military base. After the war of the chicken, this base " +
                   "was empty but since 4 days the contact to an observation antenna is lost.\n\n" +
                   "You need to find and repair the broken antenna.";
        }

        #endregion
    }
}