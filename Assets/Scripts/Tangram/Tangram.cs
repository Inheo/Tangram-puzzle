using UnityEngine;

public class Tangram : MonoBehaviour
{
    [SerializeField] private Piece[] _pieces;

    public event System.Action OnPiecesEndInitialize;

    private void Start()
    {
        InitializePieces();
    }

    private void InitializePieces()
    {
        for (var i = 0; i < _pieces.Length; i++)
        {
            _pieces[i].Initialize();
        }

        OnPiecesEndInitialize?.Invoke();
    }
}