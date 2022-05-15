using System;
using UnityEngine;

public class Game : MonoBehaviour, IStartCoroutine
{
    private const string GAME_PARAMETER = "Game";
    private SceneLoader _sceneLoader;

    private Level _level;

    private void Start()
    {
        Initialize();

        StartLevel();
    }

    private void OnDestroy()
    {
        UnsubscribeEvent();
    }

    private void Initialize()
    {
        _sceneLoader = new SceneLoader(this);
    }

    private void StartLevel()
    {
        _sceneLoader.OnSceneLoaded += SceneLoaded;

        _sceneLoader.TryLoadLevel(GAME_PARAMETER);
    }

    private void SceneLoaded()
    {
        _sceneLoader.OnSceneLoaded -= SceneLoaded;

        _level = Level.Instance;
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {

    }

    private void UnsubscribeEvent()
    {
        
    }
}
