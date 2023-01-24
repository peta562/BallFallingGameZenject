using System;
using Game.UI.MainMenu;
using Zenject;

namespace Game.MainMenu {
    public sealed class MainMenuManager : IInitializable, IDisposable {
        MainMenuUI _mainMenuUI;

        [Inject]
        public void Construct(MainMenuUI mainMenuUI) {
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