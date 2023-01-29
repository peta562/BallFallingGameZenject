using Game.Level.PlayableObjects.PlayableObjectBehaviours.Interfaces;
using UnityEngine;

namespace Game.Level.PlayableObjects.PlayableObjectBehaviours {
    public sealed class FallDownOutOfBordersBehavior : IOutOfBordersBehavior {
        readonly Transform _transform;
        readonly float _scale;

        public FallDownOutOfBordersBehavior(Transform transform, float scale) {
            _transform = transform;
            _scale = scale;
        }
        
        public bool CheckOutOfBorders(Vector2 borders) {
            return _transform.position.y < (-borders.y - _scale);
        }
    }
}