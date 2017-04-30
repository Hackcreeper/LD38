using System;

namespace LD38.Quests
{
    /// <summary>
    /// This factory converts a "Quest" enum value to a new object.
    /// </summary>
    public static class QuestFactory
    {
        public static IQuest Make(Quest quest)
        {
            switch (quest)
            {
                case Quest.AnalyseTheAntenna:
                    return new AnalyseTheAntenna();

                case Quest.TakeOresFromTheMine:
                    return new TakeOresFromTheMine();

                case Quest.RepairTheAntenna:
                    return new RepairTheAntenna();

                case Quest.GoBackToSpaceship:
                    return new GoBackToSpaceship();

                case Quest.FindTheBase:
                    return new FindTheBase();

                case Quest.MeltTheOres:
                    return new MeltTheOres();

                default:
                    throw new ArgumentOutOfRangeException("quest", quest, null);
            }
        }
    }
}