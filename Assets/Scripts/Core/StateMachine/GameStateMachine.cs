using System;
using System.Collections.Generic;
using Core.StateMachine.States;

namespace Core.StateMachine {
    public sealed class GameStateMachine {
        readonly Dictionary<Type, IExitableState> _states;

        IExitableState _activeState;

        public GameStateMachine(BootstrapState.Factory bootstrapStateFactory,
            LoadConfigsState.Factory loadConfigsStateFactory,
            LoadProgressState.Factory loadProgressStateFactory,
            MainMenuState.Factory mainMenuStateFactory,
            LoadLevelState.Factory loadLevelStateFactory,
            LevelLoopState.Factory levelLoopStateFactory) {
            
            _states = new Dictionary<Type, IExitableState> {
                [typeof(BootstrapState)] =
                    bootstrapStateFactory.Create(this),
                [typeof(LoadConfigsState)] =
                    loadConfigsStateFactory.Create(this),
                [typeof(LoadProgressState)] =
                    loadProgressStateFactory.Create(this),
                [typeof(MainMenuState)] =
                    mainMenuStateFactory.Create(this),
                [typeof(LoadLevelState)] =
                    loadLevelStateFactory.Create(this),
                [typeof(LevelLoopState)] =
                    levelLoopStateFactory.Create(this)
            };
        }

        public void Enter<T>() where T : class, IState {
            var state = ChangeState<T>();
            state.Enter();
        }

        public void Enter<T, TP>(TP payload) where T : class, IPayloadedState<TP> {
            var state = ChangeState<T>();
            state.Enter(payload);
        }

        T ChangeState<T>() where T : class, IExitableState {
            _activeState?.Exit();

            var state = GetState<T>();
            _activeState = state;

            return state;
        }

        T GetState<T>() where T : class, IExitableState => _states[typeof(T)] as T;
    }
}