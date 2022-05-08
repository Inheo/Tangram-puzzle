using Assets.Interfaces.Events;
using UnityEngine;

public class PieceOfTangram : MonoBehaviour, IDragAndDropHandler
{
    private RightPointPieceOfTangram _rightPoint;
    private Transform _transform;

    public int ID => _transform.GetInstanceID();

    public void Initialize()
    {
        _transform = transform;
        _rightPoint = new RightPointPieceOfTangram(ID, _transform.position);
    }

    public void OnDrag(Vector3 position)
    {
        _transform.position = position;
    }

    public void OnDrop(Vector3 position)
    {
        _transform.position = position;
    }

    public void OnPickUp(Vector3 position)
    {
        _transform.position = position;
    }
}
