using System.Collections.Generic;
using PlayOffTestTask.Models;
using UnityEngine;

namespace PlayOffTestTask.Services.LevelService
{
    public class LevelService : ILevelService
    {
        private static readonly string[] RewardTypes = { "Gold", "Gem", "Potion", "Key", "Scroll" };
    
        private const int MinRewardCount = 1;
        private const int MaxRewardCount = 5;

        private const int MinRewardAmount = 1;
        private const int MaxRewardAmount = 100;

        private int _currentLevel = 1;
        
        private readonly System.Random _random = new();

        public LevelModel GenerateNextLevel()
        {
            var rewards = GenerateRandomRewards();
            var level = new LevelModel(_currentLevel, rewards);

            _currentLevel++;
            return level;
        }

        private List<RewardModel> GenerateRandomRewards()
        {
            var rewardCount = _random.Next(MinRewardCount, MaxRewardCount + 1);
            var rewards = new List<RewardModel>(rewardCount);

            for (int i = 0; i < rewardCount; i++)
            {
                var type = GetRandomRewardType();
                var amount = _random.Next(MinRewardAmount, MaxRewardAmount + 1);
                rewards.Add(new RewardModel(type, amount));
            }

            return rewards;
        }

        private string GetRandomRewardType()
        {
            var index = _random.Next(RewardTypes.Length);
            return RewardTypes[index];
        }
    }
}