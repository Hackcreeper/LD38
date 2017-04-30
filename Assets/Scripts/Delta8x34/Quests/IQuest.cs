namespace LD38.Quests
{
    /// <summary>
    /// This interface contains methods to start and end a quest.
    /// </summary>
    public interface IQuest
    {
        void Start(QuestLog log);

        bool IsFinished(QuestLog log);

        void End(QuestLog log);

        /// <summary>
        /// The description of the quest
        /// </summary>
        /// <returns></returns>
        string GetDescription();

        /// <summary>
        /// The long description with story / background
        /// </summary>
        /// <returns></returns>
        string GetLongDescription();
    }
}