using UnityEngine;

namespace Core.Services.InputService {
    public sealed class StandaloneInputService : IInputService {
        public bool GetInputClick() {
            return Input.GetMouseButtonDown(0);
        }
    }
}