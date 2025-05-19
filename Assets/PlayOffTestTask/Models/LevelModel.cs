using System.Collections.Generic;

namespace PlayOffTestTask.Models
{
    public class LevelModel
    {
        public int LevelNumber { get; }
        public List<RewardModel> Rewards { get; }

        public LevelModel(int levelNumber, List<RewardModel> rewards)
        {
            LevelNumber = levelNumber;
            Rewards = rewards;
        }
    }
}