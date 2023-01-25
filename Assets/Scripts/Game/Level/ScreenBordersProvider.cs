using UnityEngine;
using Zenject;

namespace Game.Level {
    public sealed class ScreenBordersProvider : IInitializable {
        Vector2 _screenBorders;

        public void Initialize() {
            _screenBorders = Camera.main.ScreenToWorldPoint(
                new Vector2(Screen.width, Screen.height));
        }

        public Vector2 GetScreenBorders() =>
            _screenBorders;
    }
}