using UnityEngine;
using Assets.Interfaces.Events;
using static GrabberHelper;

public class Grabber : MonoBehaviour
{
    private Transform _selectedObject;
    private IDragAndDropHandler _dragAndDropHandler;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickUpHandler();
        }

        if (Input.GetMouseButtonUp(0) && _selectedObject != null)
        {
            DropHandler();
        }

        if (_selectedObject != null)
        {
            OnDrag();
        }
    }

    private void TryPickUpHandler()
    {
        RaycastHit hit = CastRay();

        if (hit.rigidbody != null)
        {
            _selectedObject = hit.rigidbody.transform;
            
            if(_selectedObject.TryGetComponent(out _dragAndDropHandler) == true)
                _dragAndDropHandler.OnPickUp(GetWorldPositionMouse(_selectedObject));
            else
                _selectedObject = null;
        }
    }

    private void OnDrag()
    {
        Vector3 worldPosition = GetWorldPositionMouse(_selectedObject);

        _dragAndDropHandler.OnDrag(worldPosition);
    }

    private void DropHandler()
    {
        Vector3 worldPosition = GetWorldPositionMouse(_selectedObject);

        _dragAndDropHandler.OnDrag(worldPosition);

        _selectedObject = null;
        _dragAndDropHandler = null;
    }
}