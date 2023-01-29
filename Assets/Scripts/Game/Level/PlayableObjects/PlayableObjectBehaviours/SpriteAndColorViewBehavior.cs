using Game.Level.PlayableObjects.PlayableObjectBehaviours.Interfaces;
using UnityEngine;

namespace Game.Level.PlayableObjects.PlayableObjectBehaviours {
    public sealed class SpriteAndColorViewBehavior : IViewBehavior {
        readonly Sprite _sprite;
        readonly Color _color;

        public SpriteAndColorViewBehavior(Sprite sprite, Color color) {
            _sprite = sprite;
            _color = color;
        }
        
        public void SetView(SpriteRenderer spriteRenderer) {
            spriteRenderer.sprite = _sprite;
            spriteRenderer.color = _color;
        }
    }
}