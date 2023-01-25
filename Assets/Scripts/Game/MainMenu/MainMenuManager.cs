using System;
using Game.UI.MainMenu;
using Zenject;

namespace Game.MainMenu {
    public sealed class MainMenuManager : IInitializable, IDisposable {
        readonly MainMenuUI _mainMenuUI;
        
        public MainMenuManager(MainMenuUI mainMenuUI) {
            _mainMenuUI = mainMenuUI;
        }

        public void Initialize() {
            _mainMenuUI.Init();
        }

        public void Dispose() {
            _mainMenuUI.DeInit();
        }
    }
}