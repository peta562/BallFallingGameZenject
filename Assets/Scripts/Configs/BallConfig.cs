using UnityEngine;

namespace Configs {
    [CreateAssetMenu(fileName = "BallConfig", menuName = "Configs/BallConfig", order = 1)]
    public class BallConfig : ScriptableObject {
        public float Scale;
        public int Health;
        public Sprite Sprite;
    }
}