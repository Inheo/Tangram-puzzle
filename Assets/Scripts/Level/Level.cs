using Scripts.Data;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] Material _bgMaterial;

    private Tangram _tangram;

    private LevelBGSwitcher _bgSwitcher;
    private LevelSpawner _spawner;
    private LevelSettings _levelSettings;

    private LevelSettingsItem _levelConfig;
    private WorldData _playerData;

    private System.Action OnLevelCompleted;

    public static Level Instance { get; private set; }

    private void Awake()
    {
        Instance = null;
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
        _tangram = _spawner.Instantiate(_levelConfig.TangramPrefab);
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
    }
}