using System.Collections;
using Assets.Interfaces.Events.Emitters;
using UnityEngine;

[RequireComponent(typeof(PieceMover))]
public class Piece : MonoBehaviour
{
    [SerializeField] private float _pinDistance = 2;

    private bool _canCollision = false;

    private PieceMover _pieceMover;
    private Transform _transform;

    private IDragAndDropEventEmitter _dragAndDropEventEmitter;
    private RightPinPointPiece _rightPoint;

    public event System.Action OnPin;

    public int ID => _transform.GetInstanceID();

    public void Initialize()
    {
        _transform = transform;
        _rightPoint = new RightPinPointPiece(ID, _transform.position);

        _pieceMover = GetComponent<PieceMover>();
        _dragAndDropEventEmitter = GetComponent<IDragAndDropEventEmitter>();

        _dragAndDropEventEmitter.OnPickUp += PickUp;
        _dragAndDropEventEmitter.OnDrop += Drop;
    }

    private void OnDestroy()
    {
        _dragAndDropEventEmitter.OnPickUp -= PickUp;
        _dragAndDropEventEmitter.OnDrop -= Drop;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_canCollision && other.attachedRigidbody.TryGetComponent(out Piece piece))
        {
            _pieceMover.MoveToShufflePoint();
            _rightPoint.UnpinPieceOfTangram();
        }
    }

    private void PickUp()
    {
        _rightPoint.UnpinPieceOfTangram();
    }

    private void Drop()
    {
        if ((_rightPoint.Position - _transform.position).sqrMagnitude < _pinDistance)
        {
            Pin();
        }
        else
        {
            _pieceMover.MoveToShufflePoint();
        }

        StartCoroutine(EnableCanCollision());
    }

    private void Pin()
    {
        _rightPoint.PinPieceOfTangram(ID);
        _transform.position = _rightPoint.Position;
        OnPin.Invoke();
    }

    private IEnumerator EnableCanCollision()
    {
        _canCollision = true;

        yield return DelayFrame(5);

        _canCollision = false;
    }

    private IEnumerator DelayFrame(int countFrame)
    {
        for (var i = 0; i < countFrame; i++)
        {
            yield return null;
        }
    }
}