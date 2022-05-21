using Scripts.Data;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Material _bgMaterial;
    [SerializeField] private LevelSettings _levelSettings;

    private Tangram _tangram;

    private LevelBGSwitcher _bgSwitcher;
    private LevelSpawner _spawner;

    private LevelSettingsItem _levelConfig;
    private WorldData _playerData;

    public event System.Action OnLevelCompleted;
    public event System.Action OnReadyLevelRestart;

    public static Level Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Initialize();

        SwitchBG();
        SpawnTangram();

        Subscribe();
    }

    private void OnDestroy()
    {
        Instance = null;
        Unsubscribe();
    }

    private void Initialize()
    {
        _playerData = PlayerProgress.GetData();
        _levelConfig = _levelSettings[_playerData.Level];

        _bgSwitcher = new LevelBGSwitcher(_bgMaterial);
        _spawner = new LevelSpawner();
    }

    private void SwitchBG()
    {
        _bgSwitcher.SetTexture(_levelConfig.BGTexture);
    }

    private void SpawnTangram()
    {
        _tangram = _spawner.Instantiate(_levelConfig.TangramPrefab, transform);
    }

    private void Subscribe()
    {
        _tangram.OnTangramAssembled += LevelCompleted;
    }

    private void Unsubscribe()
    {
        _tangram.OnTangramAssembled -= LevelCompleted;
    }

    private void LevelCompleted()
    {
        _playerData.CompleteLevel();
        OnLevelCompleted?.Invoke();

        // TODO: add vfx player

        OnReadyLevelRestart?.Invoke();
    }
}