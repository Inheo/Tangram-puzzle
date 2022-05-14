using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner
{
    public T Instantiate<T>(T prefab) where T : MonoBehaviour
    {
        return GameObject.Instantiate(prefab);
    }
}
