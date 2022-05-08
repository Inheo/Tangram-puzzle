using UnityEngine;

public class PieceOfTangram : MonoBehaviour
{
    private RightPointPieceOfTangram _rightPoint;
    private Transform _transform;

    public int ID => _transform.GetInstanceID();

    public void Initialize()
    {
        _transform = transform;
        _rightPoint = new RightPointPieceOfTangram(ID, _transform.position);
    }
}
