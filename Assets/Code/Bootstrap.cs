using System.Collections.Generic;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        private GameStateMachine _stateMachine;
        
        [Inject]
        private void Constact(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            SetupStateMachine();
            
            DontDestroyOnLoad(this);
        }

        private void SetupStateMachine()
        {
            _stateMachine.Enter<LoadLevelState>();
        }
    }
}