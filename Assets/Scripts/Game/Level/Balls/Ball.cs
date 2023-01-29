using System;
using Game.Level.PlayableObjects.PlayableObjectBehaviours;
using Game.Level.PlayableObjects.PlayableObjectBehaviours.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Level.Balls {
    public sealed class Ball : MonoBehaviour, IPoolable<int, Vector2, float, Sprite, Color, IMemoryPool>, IDisposable {
        Transform _transform;
        SpriteRenderer _spriteRenderer;
        float _scale;
        Sprite _sprite;
        Color _color;
        IMemoryPool _pool;

        IMoveBehaviour _moveBehaviour;
        IViewBehavior _viewBehavior;
        IParticleEffectBehavior _dieParticleEffectBehavior;
        IEffectBehavior _hitEffectBehavior;
        IOutOfBordersBehavior _outOfBordersBehavior;

        public int Health { get; private set; }

        public void OnSpawned(int health, Vector2 initialPosition, float scale, Sprite sprite, Color color,
            IMemoryPool pool) {
            _transform = transform;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            Health = health;

            _transform.position = initialPosition;

            _scale = scale;
            _transform.localScale = new Vector2(scale, scale);

            _sprite = sprite;
            _color = color;
            
            _pool = pool;

            InitBehaviors();
        }

        public void OnDespawned() {
            _pool = null;
        }

        public void Dispose() {
            _pool.Despawn(this);
        }

        public void TakeDamage(int damage) {
            Health -= damage;
        }

        public void Move(Vector2 direction, float speed) {
            _moveBehaviour.Move(direction, speed);
        }

        public bool CheckOutOfBorders(Vector2 screenBorders) {
            return _outOfBordersBehavior.CheckOutOfBorders(screenBorders);
        }

        public void SetView() {
            _viewBehavior.SetView(_spriteRenderer);
        }

        void InitBehaviors() {
            _moveBehaviour = new SimpleMoveBehavior(_transform);
            _viewBehavior = new SpriteAndColorViewBehavior(_sprite, _color);
            _dieParticleEffectBehavior = new ParticleSystemWithScaleAndColorEffectBehavior(_color, _scale);
            _hitEffectBehavior = new DOTweenScaleEffectBehavior(_transform);
            _outOfBordersBehavior = new FallDownOutOfBordersBehavior(_transform, _scale);
        }

        public class Factory : PlaceholderFactory<int, Vector2, float, Sprite, Color, Ball> { }
    }
}