using UnityEngine;

[CreateAssetMenu(fileName = "level-settings", menuName = "LevelSettings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private LevelSettingsItem[] _levelSettings;

    public LevelSettingsItem this[int index]
    {
        get
        {
            index = index >= _levelSettings.Length ? index % _levelSettings.Length : index;
            return _levelSettings[index];
        }
    }
}
