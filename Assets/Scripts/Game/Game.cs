using UnityEngine;

public class Game : MonoBehaviour, IStartCoroutine
{
    [SerializeField] private FadePanel _fadePanel;
    
    private const string GAME_PARAMETER = "Game";
    private SceneLoader _sceneLoader;

    private Level _level;

    public event System.Action OnStartLevel;

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
        OnStartLevel?.Invoke();
        _fadePanel.Show();

        _sceneLoader.OnSceneLoaded += SceneLoaded;

        _sceneLoader.TryLoadLevel(GAME_PARAMETER);
    }

    private void SceneLoaded()
    {
        _sceneLoader.OnSceneLoaded -= SceneLoaded;

        _level = Level.Instance;
        _fadePanel.Hide();
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _level.OnLevelCompleted += StartLevel;
    }

    private void UnsubscribeEvent()
    {
        _level.OnLevelCompleted -= StartLevel;
    }
}
