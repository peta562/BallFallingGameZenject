using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Core.Services.TimerProvider {
    public sealed class Timer {
        readonly ICoroutineRunner _coroutineRunner;
        readonly float _time;
        readonly Action _onTimerEnd;
        readonly Action<int> _onTimerChange;
        readonly bool _repeat;
        
        float _timer;
        Coroutine _timeCoroutine;

        public Timer(ICoroutineRunner coroutineRunner, float time, Action onTimerEnd, Action<int> onTimerChange = null,
            bool repeat = false) {
            _coroutineRunner = coroutineRunner;
            _time = time;
            _onTimerEnd = onTimerEnd;
            _onTimerChange = onTimerChange;
            _repeat = repeat;
        }
        
        public void StartTimer() {
            _timer = _time;
            _timeCoroutine = _coroutineRunner.StartCoroutine(Start());
        }

        public void StopTimer() {
            _coroutineRunner.StopCoroutine(_timeCoroutine);
        }

        IEnumerator Start() {
            while ( true ) {
                _timer -= Time.deltaTime;
                _onTimerChange?.Invoke((int)_timer);

                yield return null;

                if ( _timer <= 0f ) {
                    _onTimerEnd();
                    if ( !_repeat ) {
                        break;
                    }

                    _timer = _time;
                }
            }
        }
        
        public class Factory : PlaceholderFactory<float, Action, Action<int>, bool, Timer>{}
    }
}