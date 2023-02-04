using DG.Tweening;
using Game.Level.PlayableObjects.PlayableObjectBehaviours.Interfaces;
using UnityEngine;

namespace Game.Level.PlayableObjects.PlayableObjectBehaviours {
    public sealed class DOTweenScaleEffectBehavior : IEffectBehavior {
        const float Duration = 0.5f;
        const float Strength = 0.25f;
        
        readonly Transform _transform;

        public DOTweenScaleEffectBehavior(Transform transform) {
            _transform = transform;
        }

        public void PlayEffect() {
            _transform.DOShakeScale(Duration, Strength)
                .OnComplete(() => _transform.DORewind())
                .OnKill(() => _transform.DORewind());
        }
    }
}