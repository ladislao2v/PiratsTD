using UnityEngine;

namespace Code.Services.Trajectory
{
    public interface ITrajectoryDrawService
    {
        Vector3[] Draw(Vector2 at);
    }
}