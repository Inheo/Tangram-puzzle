using UnityEngine;

[CreateAssetMenu(fileName = "level-settings-item", menuName = "LevelSettingsItem")]
public class LevelSettingsItem : ScriptableObject
{
    [SerializeField] private Tangram _tangramPrefab;
    [SerializeField] private Texture2D _bgTexture;

    public Tangram TangramPrefab => _tangramPrefab;
    public Texture2D BGTexture => _bgTexture;
}