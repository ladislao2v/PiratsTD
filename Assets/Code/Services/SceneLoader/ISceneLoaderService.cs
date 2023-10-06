using System;

namespace Code.Services.SceneLoader
{
    public interface ISceneLoaderService
    {
        void Load(string name, Action loaded = null);
    }
}