using UnityEngine;

public class LevelBGSwitcher
{
    private const string BASE_MAP_PARAMETER = "_BaseMap";

    private Material _material;

    public LevelBGSwitcher(Material material)
    {
        _material = material;
    }

    public void SetTexture(Texture2D texture)
    {
        _material.SetTexture(BASE_MAP_PARAMETER, texture);
    }
}