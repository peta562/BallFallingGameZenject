using System;
using System.Collections.Generic;

namespace Core.Services.TimerProvider {
    public sealed class TimerProvider : ITimerProvider {
        readonly Timer.Factory _timerFactory;

        readonly Dictionary<string, Timer> _timers = new();

        public TimerProvider(Timer.Factory timerFactory) {
            _timerFactory = timerFactory;
        }

        public void CreateTimer(string name, float time, Action onTimerEnd, Action<int> onTimerChange = null,
            bool repeat = false) {
            var timer = _timerFactory.Create(time, onTimerEnd, onTimerChange, repeat);

            _timers.Add(name, timer);
        }

        public void StartTimer(string name) {
            var timer = _timers[name];
            timer.StartTimer();
        }

        public void StopTimer(string name) {
            var timer = _timers[name];
            timer.StopTimer();
        }

        public void RemoveTimer(string name) {
            _timers.Remove(name);
        }
    }
}