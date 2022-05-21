using UnityEngine;

[CreateAssetMenu(fileName = "level-settings", menuName = "LevelSettings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private LevelSettingsItem[] _levelSettings;

    public LevelSettingsItem this[int index]
    {
        get
        {
            index = index >= _levelSettings.Length ? _levelSettings.Length - 1 : index;
            return _levelSettings[index];
        }
    }
}
