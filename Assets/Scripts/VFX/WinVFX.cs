using UnityEngine;

public class WinVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _vfx;

    public float GetMiddleLifeTimeVFX()
    {
        float result = 0;

        for (var i = 0; i < _vfx.Length; i++)
        {
            result += _vfx[i].main.startLifetime.constant;
        }
        
        result /= _vfx.Length;

        return result;
    }

    public void Play()
    {
        for (var i = 0; i < _vfx.Length; i++)
        {
            _vfx[i].Play();
        }
    }
}
