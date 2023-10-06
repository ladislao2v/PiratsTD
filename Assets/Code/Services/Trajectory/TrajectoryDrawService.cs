using System.Collections.Generic;
using Code.Services.Aim;
using UnityEngine;

namespace Code.Services.Trajectory
{
    public class TrajectoryDrawService : ITrajectoryDrawService
    {
        private readonly float _distance = 3f;
        private readonly int _reflections = 2;
        private readonly IAimService _aimService;

        public TrajectoryDrawService(IAimService aimService)
        {
            _aimService = aimService;
        }

        public Vector3[] Draw(Vector2 at)
        {
            List<Vector3> points = new List<Vector3>();
            points.Add(at);
            
            Vector2 position = at;
            Vector2 direction = _aimService.GetDirection(at);
            
            for(int i = 0; i <= _reflections; ++i)
            {
                RaycastHit2D hit = Physics2D.Raycast(position, direction, _distance); 
                
                if (hit) { 
                    position = hit.point + hit.normal * 0.00001f;
                    direction = Vector2.Reflect(direction, hit.normal);
                }
                else
                {
                    position = direction * _distance;
                }
                
                points.Add(position);
            }
            
            return points.ToArray();
        }
    }
}