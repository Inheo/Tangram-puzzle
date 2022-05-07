using UnityEngine;

public static class Helper
{
    private static Camera _cameraMain;

    public static Camera CameraMain
    {
        get
        {
            if (_cameraMain == null)
                _cameraMain = Camera.main;

            return _cameraMain;
        }
    }
}
