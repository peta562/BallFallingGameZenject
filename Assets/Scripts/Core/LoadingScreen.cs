using Unity.VisualScripting;
using UnityEngine;

namespace Core {
    public sealed class LoadingScreen : MonoBehaviour {
        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}