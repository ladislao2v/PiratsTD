using System;
using UnityEngine.SceneManagement;

namespace Code.Services.SceneLoader
{
    public class SceneLoader : ISceneLoaderService
    {
        public void Load(string name, Action loaded = null)
        {
            var wait = SceneManager.LoadSceneAsync(name);
        }
    }
}