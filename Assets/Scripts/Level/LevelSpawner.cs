using UnityEngine;

public class LevelSpawner
{
    public T Instantiate<T>(T prefab, Transform parent) where T : MonoBehaviour
    {
        return GameObject.Instantiate(prefab, parent);
    }
}
