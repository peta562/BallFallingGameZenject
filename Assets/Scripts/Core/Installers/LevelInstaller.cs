using Core.Services.Factories;
using Game.Level;
using Game.UI.Level;
using UnityEngine;
using Zenject;

namespace Core.Installers {
    public sealed class LevelInstaller : MonoInstaller {
        [SerializeField] Transform UIRoot;
        [SerializeField] Transform BallRoot;
        
        public override void InstallBindings() {
            BindLevelManager();
            BindHUD();

            BindScreenBordersProvider();
            
            BindBallsController();
            BindBallsSpawner();
            BindBallFactory();
        }

        void BindLevelManager() {
            Container
                .BindInterfacesAndSelfTo<LevelManager>()
                .AsSingle();
        }

        void BindHUD() {
            Container
                .Bind<HUD>()
                .FromComponentInNewPrefabResource(AssetPath.HUD)
                .UnderTransform(UIRoot)
                .AsSingle();
        }

        void BindBallsController() {
            Container
                .Bind<BallsController>()
                .AsSingle();
        }

        void BindScreenBordersProvider() {
            Container
                .BindInterfacesAndSelfTo<ScreenBordersProvider>()
                .AsSingle();
        }

        void BindBallsSpawner() {
            Container
                .Bind<BallsSpawner>()
                .AsSingle();
        }

        void BindBallFactory() {
            Container
                .BindFactory<float, Vector2, Ball, Ball.Factory>()
                .FromComponentInNewPrefabResource(AssetPath.Ball)
                .UnderTransform(BallRoot);
        }
    }
}