using System;
using UnityEngine;

namespace Code.Services.Aim
{
    public interface IAimService
    {
        event Action<Vector2> Shooted;
        Vector2 GetDirection(Vector2 at);
    }
}