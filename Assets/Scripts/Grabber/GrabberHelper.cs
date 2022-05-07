using UnityEngine;
using static Helper;

public static class GrabberHelper
{
    public static RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3
        (
            Input.mousePosition.x,
            Input.mousePosition.y,
            CameraMain.farClipPlane
        );

        Vector3 screenMousePosNear = new Vector3
        (
            Input.mousePosition.x,
            Input.mousePosition.y,
            CameraMain.nearClipPlane
        );

        Vector3 worldMousePosFar = CameraMain.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = CameraMain.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.MaxValue);

        return hit;
    }

    public static Vector3 GetWorldPositionMouse(Transform selectedObject)
    {
        Vector3 position = new Vector3
                            (
                                Input.mousePosition.x,
                                Input.mousePosition.y,
                                CameraMain.WorldToScreenPoint(selectedObject.position).z
                            );

        return CameraMain.ScreenToWorldPoint(position);
    }
}