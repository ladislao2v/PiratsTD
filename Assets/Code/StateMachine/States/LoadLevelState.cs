using Code.Services.SceneLoader;

namespace Code.StateMachine.States
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoaderService _sceneLoader;
        
        public LoadLevelState(GameStateMachine gameStateMachine, ISceneLoaderService sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(SceneNames.Game);
            
            _gameStateMachine.Enter<GameplayState>();
        }

        public void Exit()
        {
            
        }
    }
}