using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scripts.Data;

public class LevelViewer : MonoBehaviour
{
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
        _levelViewText.text = "Level: " + (PlayerProgress.GetData().Level + 1);
    }
}
