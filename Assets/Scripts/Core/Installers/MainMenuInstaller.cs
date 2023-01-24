using Core.Services.Factories;
using Game.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace Core.Installers {
    public sealed class MainMenuInstaller : MonoInstaller {
        [SerializeField] Transform UIRoot;
        
        public override void InstallBindings() {
            Container
                .Bind<MainMenuUI>()
                .FromComponentInNewPrefabResource(AssetPath.MainMenuUI)
                .UnderTransform(UIRoot)
                .AsSingle();
        }
    }
}