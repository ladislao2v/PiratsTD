using Code.Services.EnemySpawner;

namespace Code.StateMachine.States
{
    public class GameplayState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IEnemySpawnerService _enemySpawner;
        private readonly ICoroutineRunner _corouctineRunner;

        public GameplayState(GameStateMachine gameStateMachine, IEnemySpawnerService enemySpawner, ICoroutineRunner corouctineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _enemySpawner = enemySpawner;
            _corouctineRunner = corouctineRunner;
        }

        public void Enter()
        {
            _corouctineRunner.StartCoroutine(_enemySpawner.Start());
        }

        public void Exit()
        {
            
        }
    }
}