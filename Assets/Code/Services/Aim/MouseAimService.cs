using System;
using UnityEngine;

namespace Code.Services.Aim
{
    public class MouseAimService : IAimService
    {
        private readonly Camera _camera;

        public event Action<Vector2> Shooted;

        public MouseAimService(Camera camera)
        {
            _camera = camera;
        }

        public Vector2 GetDirection(Vector2 at)
        {
            var mousePosition = (Vector2) _camera.ScreenToWorldPoint(Input.mousePosition);
            var direction = Vector3.Normalize(mousePosition - at);

            if (Input.GetMouseButtonDown(0))
            {
                Shooted?.Invoke(direction);
            }
            
            return direction;
        }
    }
}