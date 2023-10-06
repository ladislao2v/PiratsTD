using Code.Services.Aim;
using Code.Services.SceneLoader;
using Code.Services.Trajectory;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterSceneLoaderService();
            RegisterStateMachine();
        }

        private void RegisterSceneLoaderService()
        {
            Container
                .Bind<ISceneLoaderService>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void RegisterStateMachine()
        {
            Container
                .Bind<GameStateMachine>()
                .AsSingle();
            
            Container
                .Bind<LoadLevelState>()
                .AsSingle();
        }
    }
}