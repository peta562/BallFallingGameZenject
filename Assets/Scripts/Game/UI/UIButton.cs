using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI {
    [RequireComponent(typeof(Button))]
    public sealed class UIButton : MonoBehaviour {
        Button _button;
        Action _action;

        void Start() {
            _button = GetComponent<Button>();
        }

        public void AddListener(Action action) {
            _action = action;
            _button.onClick.AddListener(OnButtonClicked);
        }

        public void RemoveListener() {
            _action = null;
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        void OnButtonClicked() {
            _action?.Invoke();
        }
    }
}