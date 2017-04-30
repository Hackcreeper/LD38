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
            log.Start(Quest.MeltTheOres);
        }

        public string GetDescription()
        {
            return "Take ores from the mine!";
        }

        public string GetLongDescription()
        {
            return "The antenna has taken more damage than expected.\n" +
                   "You need to find additional resources to repair it.\n\n" +
                   "This planet does have an old mine. Maybe there is enough " +
                   "ore to repair the antenna.";
        }

        #endregion
    }
}