namespace LD38.Quests
{
    public interface IQuest
    {
        void Start();
        bool IsFinished();
        void End();

        string GetDescription();
    }
}