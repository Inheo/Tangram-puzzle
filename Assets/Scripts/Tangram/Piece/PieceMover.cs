using Assets.Interfaces.Events;
using UnityEngine;

public class PieceMover : MonoBehaviour, IDragAndDropHandler
{
    [SerializeField] private Piece _piece;

    public void OnDrag(Vector3 position)
    {
        _piece.CachedTransform.position = position;
    }

    public void OnDrop(Vector3 position)
    {
        _piece.CachedTransform.position = position;
    }

    public void OnPickUp(Vector3 position)
    {
        _piece.CachedTransform.position = position;
    }
}