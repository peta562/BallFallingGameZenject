using Core.Services.Factories;
using Game.Level;
using Game.Level.Balls;
using Game.UI.Level;
using UnityEngine;
using Zenject;

namespace Core.Installers {
    public sealed class LevelInstaller : MonoInstaller {
        [SerializeField] Transform UIRoot;
        [SerializeField] Transform BallRoot;
        
        public override void InstallBindings() {
            BindScreenBordersProvider();
            
            BindLevelManager();
            BindHUD();

            BindBallSpawner();
            BindBallFactory();
            BindBallsController();
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

        void BindScreenBordersProvider() {
            Container
                .BindInterfacesAndSelfTo<ScreenBordersProvider>()
                .AsSingle();
        }

        void BindBallSpawner() {
            Container
                .Bind<BallSpawner>()
                .AsSingle();
        }

        void BindBallFactory() {
            Container
                .BindFactory<int, Vector2, float, Sprite, Color, Ball, Ball.Factory>()
                .FromMonoPoolableMemoryPool(x => x
                    .WithInitialSize(10)
                    .FromComponentInNewPrefabResource(AssetPath.Ball)
                    .UnderTransform(BallRoot)
                );
        }

        void BindBallsController() {
            Container
                .Bind<BallsController>()
                .AsSingle();
        }
    }
}