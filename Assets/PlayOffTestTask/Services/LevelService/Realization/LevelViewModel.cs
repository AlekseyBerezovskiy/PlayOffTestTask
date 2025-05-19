using PlayOffTestTask.Models;
using UniRx;

namespace PlayOffTestTask.Services.LevelService
{
    public class LevelViewModel : ILevelViewModel
    {
        public ReactiveProperty<string> CurrentLevelText { get; } = new();
        public ReactiveProperty<bool> IsPopupVisible { get; } = new();
        public ReactiveProperty<string> PopupLevelText { get; } = new();
        public ReactiveCollection<RewardModel> PopupRewards { get; } = new();

        private LevelModel _currentLevel;
        
        private readonly ILevelService _levelService;
        
        public LevelViewModel(
            ILevelService levelService)
        {
            _levelService = levelService;
            
            _currentLevel = _levelService.GenerateNextLevel();
            
            CurrentLevelText.Value = $"Level {_currentLevel.LevelNumber}";
        }

        public void RequestNextLevel()
        {
            _currentLevel = _levelService.GenerateNextLevel();
            
            PopupLevelText.Value = $"Level {_currentLevel.LevelNumber}";

            PopupRewards.Clear();
            foreach (var reward in _currentLevel.Rewards)
            {
                PopupRewards.Add(reward);
            }

            IsPopupVisible.Value = true;
        }

        public void ClosePopup()
        {
            CurrentLevelText.Value = $"Level {_currentLevel.LevelNumber}";
            
            IsPopupVisible.Value = false;
        }
    }
}