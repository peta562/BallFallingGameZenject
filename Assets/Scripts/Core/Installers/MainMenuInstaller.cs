using Core.Services.Factories;
using Game.MainMenu;
using Game.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace Core.Installers {
    public sealed class MainMenuInstaller : MonoInstaller {
        [SerializeField] Transform UIRoot;
        
        public override void InstallBindings() {
            BindMainMenuManager();
            BindMainMenuUI();
        }

        void BindMainMenuManager() {
            Container
                .BindInterfacesAndSelfTo<MainMenuManager>()
                .AsSingle();
        }

        void BindMainMenuUI() {
            Container
                .Bind<MainMenuUI>()
                .FromComponentInNewPrefabResource(AssetPath.MainMenuUI)
                .UnderTransform(UIRoot)
                .AsSingle();
        }
    }
}