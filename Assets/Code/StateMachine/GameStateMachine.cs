using System;
using System.Collections.Generic;
using Code.Services.EnemySpawner;
using Code.Services.SceneLoader;
using Code.StateMachine.States;

namespace Code.StateMachine
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;

        public GameStateMachine(
            ICoroutineRunner coroutineRunner, 
            ISceneLoaderService sceneLoader, 
            IEnemySpawnerService enemySpawner)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader),
                [typeof(GameplayState)] = new GameplayState(this, enemySpawner, coroutineRunner),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            if (_states.ContainsKey(typeof(TState)) == false)
                throw new ArgumentException("State "+ nameof(TState) + "is not exist");
            
            _currentState?.Exit();
            
            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }
}