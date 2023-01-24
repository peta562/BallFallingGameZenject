using Game.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace Core.Starters {
    public sealed class MainMenuStarter : MonoBehaviour {
        MainMenuUI _mainMenuUI;

        [Inject]
        public void Construct(MainMenuUI mainMenuUI) {
            _mainMenuUI = mainMenuUI;
        }

        void Start() {
            _mainMenuUI.Init();
        }

        void OnDestroy() {
            _mainMenuUI.DeInit();
        }
    }
}