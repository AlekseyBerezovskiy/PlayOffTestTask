
using PlayOffTestTask.Services.LevelService;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PlayOffTestTask.UI
{
    public class MainUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private Button levelUpButton;

        private ILevelViewModel _viewModel;
        
        private readonly CompositeDisposable _disposables = new();

        [Inject]
        public void Construct(ILevelViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private void Start()
        {
            _viewModel.CurrentLevelText
                .Subscribe(text => levelText.text = text)
                .AddTo(_disposables);

            levelUpButton.OnClickAsObservable()
                .Subscribe(_ => _viewModel.RequestNextLevel())
                .AddTo(_disposables);
        }

        private void OnDestroy() => _disposables.Dispose();
    }
}