using DG.Tweening;
using Game.Level.PlayableObjects.PlayableObjectBehaviours.Interfaces;
using UnityEngine;

namespace Game.Level.PlayableObjects.PlayableObjectBehaviours {
    public sealed class DOTweenScaleEffectBehavior : IEffectBehavior {
        readonly Transform _transform;

        public DOTweenScaleEffectBehavior(Transform transform) {
            _transform = transform;
        }

        public void PlayEffect() {
            _transform.DOShakeScale(0.5f, 0.25f)
                .OnComplete(() => _transform.DORewind())
                .OnKill(() => _transform.DORewind());
        }
    }
}