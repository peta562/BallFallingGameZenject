using UnityEngine;
using Zenject;

namespace Game.Level {
    public class Ball : MonoBehaviour {
        float _speed;
        Vector2 _initialPosition;

        [Inject]
        public void Construct(float speed, Vector2 initialPosition) {
            _speed = speed;
            _initialPosition = initialPosition;

            transform.position = initialPosition;
        }
        
        public void Tick() {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }

        public bool CheckBallOutOfBorders(Vector2 screenBorders) {
            if (transform.position.y + transform.localScale.y < -screenBorders.y) {
                return true;
            }

            return false;
        }

        public void Destroy() {
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<float, Vector2, Ball>{}
    }
}