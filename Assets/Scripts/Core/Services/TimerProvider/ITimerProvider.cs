using System;

namespace Core.Services.TimerProvider {
    public interface ITimerProvider {
        public void CreateTimer(string name, float time, Action onTimerEnd, Action<int> onTimerChange = null,
            bool repeat = false);

        public void StartTimer(string name);

        public void StopTimer(string name);

        public void RemoveTimer(string name);
    }
}