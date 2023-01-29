using Game.Level.PlayableObjects.PlayableObjectBehaviours.Interfaces;
using UnityEngine;

namespace Game.Level.PlayableObjects.PlayableObjectBehaviours {
    public sealed class SpriteViewBehavior : IViewBehavior {
        readonly Sprite _sprite;

        public SpriteViewBehavior(Sprite sprite) {
            _sprite = sprite;
        }
        
        public void SetView(SpriteRenderer spriteRenderer) {
            spriteRenderer.sprite = _sprite;
        }
    }
}