using UnityEngine;

public class LevelBGSwitcher
{
    private const string BASE_MAP_PARAMETER = "_BaseMap";

    private Material _material;

    public LevelBGSwitcher(Material material, Texture2D texture)
    {
        _material = material;
        SetTexture(texture);
    }

    public void SetTexture(Texture2D texture)
    {
        _material.SetTexture(BASE_MAP_PARAMETER, texture);
    }
}