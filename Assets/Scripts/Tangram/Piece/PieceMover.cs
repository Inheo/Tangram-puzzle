using Assets.Interfaces.Events.Handlers;
using Assets.Interfaces.Events.Emitters;
using UnityEngine;

public class PieceMover : MonoBehaviour, IDragAndDropHandler, IDragAndDropEventEmitter
{
    [SerializeField] private float _dragYOffset = 0.4f;
    [SerializeField] private float _dragZOffset = 0.4f;
    
    [SerializeField] private Transform _shufflePoint;

    private Vector3 _startDragPosition;
    private Vector3 _offset;

    private Transform _transform;

    public event System.Action OnPickUp;
    public event System.Action OnDrag;
    public event System.Action OnDrop;

    private void Awake()
    {
        _transform = transform;
    }

    public void MoveToShufflePoint()
    {
        _transform.position = _shufflePoint.position;
    }

    public void PickUp(Vector3 position)
    {
        _startDragPosition = _transform.position;
        _offset = _transform.position - position;

        _transform.position = ConvertPosition(position);
        OnPickUp?.Invoke();
    }

    public void Drag(Vector3 position)
    {
        _transform.position = ConvertPosition(position);
        OnDrag?.Invoke();
    }

    public void Drop(Vector3 position)
    {
        position = ConvertPosition(position);
        position.y = _startDragPosition.y;
        
        _transform.position = position;
        OnDrop?.Invoke();
    }

    private Vector3 ConvertPosition(Vector3 position)
    {
        position += _offset;
        position.y = _startDragPosition.y + _dragYOffset;
        position.z += _dragZOffset;
        return position;
    }
}