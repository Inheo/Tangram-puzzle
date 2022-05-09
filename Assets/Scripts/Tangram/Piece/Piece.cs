using Assets.Interfaces.Events.Emitters;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private float _pinDistance = 2;

    private IDragAndDropEventEmitter _dragAndDropEventEmitter;
    private RightPinPointPiece _rightPoint;
    private Transform _transform;

    public int ID => _transform.GetInstanceID();

    public void Initialize()
    {
        _transform = transform;
        _rightPoint = new RightPinPointPiece(ID, _transform.position);

        _dragAndDropEventEmitter = GetComponent<IDragAndDropEventEmitter>();

        _dragAndDropEventEmitter.OnPickUp += PickUp;
        _dragAndDropEventEmitter.OnDrop += Drop;
    }

    private void OnDestroy()
    {
        _dragAndDropEventEmitter.OnPickUp -= PickUp;
        _dragAndDropEventEmitter.OnDrop -= Drop;
    }

    public void PickUp()
    {
        _rightPoint.UnpinPieceOfTangram();
    }

    public void Drop()
    {
        if ((_rightPoint.Position - _transform.position).sqrMagnitude < _pinDistance)
        {
            Pin();
        }
    }

    private void Pin()
    {
        _rightPoint.PinPieceOfTangram(ID);
        _transform.position = _rightPoint.Position;
    }
}