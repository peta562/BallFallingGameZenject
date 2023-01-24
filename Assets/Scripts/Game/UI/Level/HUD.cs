using UnityEngine;
using Zenject;

namespace Game.UI.Level {
    public sealed class HUD : MonoBehaviour {
        
        public class Factory : PlaceholderFactory<HUD> { }
    }
}