using PlayOffTestTask.Models;
using UniRx;

namespace PlayOffTestTask.Services.LevelService
{
    public interface ILevelViewModel
    {
        ReactiveProperty<string> CurrentLevelText { get; }
        ReactiveProperty<bool> IsPopupVisible { get; }
        ReactiveProperty<string> PopupLevelText { get; }
        ReactiveCollection<RewardModel> PopupRewards { get; }
        void RequestNextLevel();
        void ClosePopup();
    }
}