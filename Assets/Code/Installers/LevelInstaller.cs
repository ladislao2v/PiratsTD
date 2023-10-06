using Code.Services.Aim;
using Code.Services.Trajectory;
using Code.Units;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [Header("Main Camera")] 
        [SerializeField] private Camera _camera;
        
        [Header("Player")]
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Transform _spawnPosition;

        public override void InstallBindings()
        {
            RegisterMainCamera();
            RegisterPlayerServices();
            RegisterPlayer();
        }

        private void RegisterMainCamera()
        {
            Container
                .Bind<Camera>()
                .FromInstance(_camera)
                .AsSingle();
        }
        
        private void RegisterPlayerServices()
        {
            Container
                .Bind<IAimService>()
                .To<MouseAimService>()
                .AsSingle();
            
            Container
                .Bind<ITrajectoryDrawService>()
                .To<TrajectoryDrawService>()
                .AsSingle();
        }

        private void RegisterPlayer()
        {
            var player = Container
                .InstantiatePrefabForComponent<Player>(
                    _playerPrefab, 
                    _spawnPosition.position, 
                    Quaternion.identity, 
                    null);
            
            Container
                .Bind<Player>()
                .FromInstance(player)
                .AsSingle();
        }
    }
}