namespace LD38.Quests
{
    public interface IQuest
    {
        void Start(QuestLog log);

        bool IsFinished(QuestLog log);

        void End(QuestLog log);

        string GetDescription();

        string GetLongDescription();
    }
}