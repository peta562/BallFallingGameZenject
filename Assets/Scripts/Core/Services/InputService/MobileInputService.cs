using UnityEngine;

namespace Core.Services.InputService {
    public sealed class MobileInputService : IInputService {
        public bool GetInputClick() {
            if ( Input.touchCount > 0 ) {
                var touch = Input.GetTouch(0);
                return touch.phase == TouchPhase.Began;
            }

            return false;
        }
    }
}