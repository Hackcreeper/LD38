namespace LD38.Quests
{
    public class TakeOresFromTheMine : IQuest
    {
        #region PUBLIC_METHODS

        public void Start(QuestLog log)
        {
        }

        public bool IsFinished(QuestLog log)
        {
            return Main.Get.Resources.Metal > 0;
        }

        public void End(QuestLog log)
        {
            log.Start(Quest.RepairTheAntenna);
        }

        public string GetDescription()
        {
            return "Take ores from the mine!";
        }

        public string GetLongDescription()
        {
            return "Mkay.. this is another quest.... oh oh!";
        }

        #endregion
    }
}