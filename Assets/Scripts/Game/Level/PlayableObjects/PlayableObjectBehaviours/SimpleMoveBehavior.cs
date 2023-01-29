using Game.Level.PlayableObjects.PlayableObjectBehaviours.Interfaces;
using UnityEngine;

namespace Game.Level.PlayableObjects.PlayableObjectBehaviours {
    public sealed class SimpleMoveBehavior : IMoveBehaviour {
        readonly Transform _transform;

        public SimpleMoveBehavior(Transform transform) {
            _transform = transform;
        }
        
        public void Move( Vector3 direction, float speed) {
            _transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}