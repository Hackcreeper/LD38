using System;

namespace LD38.Quests
{
    public static class QuestFactory
    {
        public static IQuest Make(Quest quest)
        {
            switch (quest)
            {
                case Quest.FindTheAntenna:
                    return new FindTheAntenna();

                default:
                    throw new ArgumentOutOfRangeException("quest", quest, null);
            }
        }
    }
}