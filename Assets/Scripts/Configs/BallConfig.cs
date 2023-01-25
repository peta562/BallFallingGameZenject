using UnityEngine;

namespace Configs {
    [CreateAssetMenu(fileName = "BallConfig", menuName = "Configs/BallConfig", order = 1)]
    public class BallConfig : ScriptableObject {
        public float Speed;
        public float Scale;
    }
}