using Infrastructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.UnityContext.SceneManagment
{
    public class SceneLoader : IUpdateProgress
    {
        private readonly ICoroutineRunner CoroutineRunner;

        public event Action<float> OnProgressUpdated;

        public SceneLoader(ICoroutineRunner runner)
        {
            CoroutineRunner = runner;
        }

        public void Load(string sceneName, Action onLoad)
        {
            CoroutineRunner.StartCoroutine(LoadSceneAsync(sceneName, onLoad));
        }

        private IEnumerator LoadSceneAsync(string sceneName, Action onLoad)
        {
            var currentSceneName = SceneManager.GetActiveScene().name;
            if (currentSceneName == sceneName)
            {
                onLoad?.Invoke();
                yield break;
            }

            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            while(!asyncOperation.isDone)
            {
                yield return null;
                OnProgressUpdated?.Invoke(asyncOperation.progress);
            }
            onLoad?.Invoke();
        }
    }
}
