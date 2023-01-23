using UnityEngine;

namespace Scripts.Utils {
    public sealed class CameraResizer : MonoBehaviour {
        [SerializeField] Vector2 DefaultResolution = new Vector2(1200, 1600);

        [Range(0f, 1f)] 
        [SerializeField] float WidthOrHeight;

        Camera _camera;

        float _initialSize;
        float _targetAspect;

        float _initialFov;
        float _horizontalFov = 120f;

        void Awake() {
            _camera = GetComponent<Camera>();
            _initialSize = _camera.orthographicSize;

            _targetAspect = DefaultResolution.x / DefaultResolution.y;

            _initialFov = _camera.fieldOfView;
            _horizontalFov = CalculateVerticalFov(_initialFov, 1 / _targetAspect);

            ResizeCamera();
        }

#if UNITY_EDITOR
        void Update() {
            ResizeCamera();
        }
#endif

        void ResizeCamera() {
            if ( _camera.orthographic ) {
                var constantWidthSize = _initialSize * (_targetAspect / _camera.aspect);
                _camera.orthographicSize = Mathf.Lerp(constantWidthSize, _initialSize, WidthOrHeight);
            }
            else {
                var constantWidthFov = CalculateVerticalFov(_horizontalFov, _camera.aspect);
                _camera.fieldOfView = Mathf.Lerp(constantWidthFov, _initialFov, WidthOrHeight);
            }
        }

        float CalculateVerticalFov(float hFovInDeg, float aspectRatio) {
            var hFovInRads = hFovInDeg * Mathf.Deg2Rad;

            var vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);

            return vFovInRads * Mathf.Rad2Deg;
        }
    }
}