using PlayOffTestTask.Services.LevelService;
using PlayOffTestTask.UI;
using Zenject;

namespace PlayOffTestTask.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        private const string RewardItemViewPoolContainerName = "MainScene";
        
        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<RewardItemView, RewardItemView.Pool>()
                .FromComponentInNewPrefabResource(nameof(RewardItemView))
                .UnderTransformGroup(RewardItemViewPoolContainerName);

            Container
                .Bind<ILevelService>()
                .To<LevelService>()
                .AsSingle();
            
            Container
                .Bind<ILevelViewModel>()
                .To<LevelViewModel>()
                .AsSingle();
        }
    }
}