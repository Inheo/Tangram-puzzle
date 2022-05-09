using UnityEngine;

public class Piece : MonoBehaviour
{
    private RightPinPointPiece _rightPoint;
    public Transform CachedTransform { get; private set; }

    public int ID => CachedTransform.GetInstanceID();

    public void Initialize()
    {
        CachedTransform = transform;
        _rightPoint = new RightPinPointPiece(ID, CachedTransform.position);
    }
}