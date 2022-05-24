using UnityEngine;
using TMPro;
using Scripts.Data;

public class LevelViewer : MonoBehaviour
{
    private const string LEVEL_PARAMETER = "Level: ";
    [SerializeField] private Game _game;
    private TextMeshProUGUI _levelViewText;

    private void Awake()
    {
        _levelViewText = GetComponent<TextMeshProUGUI>();

        _game.OnStartLevel += UpdateUI;
    }

    private void OnDestroy()
    {
        _game.OnStartLevel -= UpdateUI;
    }

    private void UpdateUI()
    {
        _levelViewText.text = LEVEL_PARAMETER + (PlayerProgress.GetData().Level + 1);
    }
}
