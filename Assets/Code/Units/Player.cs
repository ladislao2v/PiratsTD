using System;
using Code.Services.Trajectory;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Code.Units
{
    [RequireComponent(typeof(LineRenderer))]
    public class Player : MonoBehaviour
    {
        private LineRenderer _lineRenderer;
        private ITrajectoryDrawService _trajectoryDrawService;
        
        [Inject]
        private void Constructor(ITrajectoryDrawService trajectoryDrawService)
        {
            _trajectoryDrawService = trajectoryDrawService;
        }
        
        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            ShowTrajectory();
        }

        private void ShowTrajectory()
        {
            var positions = _trajectoryDrawService.Draw(transform.position+transform.forward);

            _lineRenderer.positionCount = positions.Length;
            _lineRenderer.SetPositions(positions);
        }
    }
}