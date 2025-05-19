using System.Collections.Generic;
using PlayOffTestTask.Services.LevelService;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PlayOffTestTask.UI
{
    public class LevelPopupView : MonoBehaviour
    {
        [SerializeField] private GameObject popupRoot;
        [SerializeField] private Transform rewardsContainer;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private Button closeButton;

        private RewardItemView.Pool _rewardItemViewPool;
        
        private readonly CompositeDisposable _disposables = new();
        private readonly List<RewardItemView> _spawnedRewardItemViews = new List<RewardItemView>();
        
        [Inject]
        private void Inject(
            ILevelViewModel levelViewModel,
            RewardItemView.Pool rewardItemViewPool)
        {
            _rewardItemViewPool = rewardItemViewPool;
            
            levelViewModel.IsPopupVisible
                .Subscribe(visible =>
                {
                    popupRoot.SetActive(visible);

                    if (!visible)
                    {
                        for (int i = 0; i < _spawnedRewardItemViews.Count; i++)
                        {
                            _rewardItemViewPool.Despawn(_spawnedRewardItemViews[i]);
                        }
                        _spawnedRewardItemViews.Clear();
                    }
                })
                .AddTo(_disposables);

            levelViewModel.PopupLevelText
                .Subscribe(text => levelText.text = text)
                .AddTo(_disposables);

            levelViewModel.PopupRewards
                .ObserveAdd()
                .Subscribe(addEvent =>
                {
                    var rewardItemView = _rewardItemViewPool.Spawn();
                    
                    rewardItemView.transform.SetParent(rewardsContainer, false);
                    
                    rewardItemView.SetData(addEvent.Value);
                    
                    _spawnedRewardItemViews.Add(rewardItemView);
                })
                .AddTo(_disposables);
            
            closeButton.OnClickAsObservable()
                .Subscribe(_ => levelViewModel.ClosePopup())
                .AddTo(_disposables);
        }

        private void OnDestroy()
        {
            _disposables.Dispose();

            foreach (var rewardItemView in _spawnedRewardItemViews)
            {
                _rewardItemViewPool.Despawn(rewardItemView);
            }
            _spawnedRewardItemViews.Clear();
        }
    }
}