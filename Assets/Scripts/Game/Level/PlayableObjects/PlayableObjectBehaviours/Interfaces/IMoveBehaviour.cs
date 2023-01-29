using UnityEngine;

namespace Game.Level.PlayableObjects.PlayableObjectBehaviours.Interfaces {
    public interface IMoveBehaviour {
        public void Move(Vector3 direction, float speed);
    }
}