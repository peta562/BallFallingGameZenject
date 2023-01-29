using UnityEngine;

namespace Game.Level.PlayableObjects.PlayableObjectBehaviours.Interfaces {
    public interface IOutOfBordersBehavior {
        public bool CheckOutOfBorders(Vector2 borders);
    }
}