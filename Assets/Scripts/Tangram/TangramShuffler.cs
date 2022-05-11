using UnityEngine;

public class TangramShuffler : MonoBehaviour
{
    [SerializeField] private PieceMover[] _pieceMovers;
    [SerializeField] private Tangram _tangram;

    private void Awake()
    {
        _tangram.OnPiecesEndInitialize += Shuffle;
    }

    private void OnDestroy()
    {
        _tangram.OnPiecesEndInitialize -= Shuffle;
    }

    private void Shuffle()
    {
        for (var i = 0; i < _pieceMovers.Length; i++)
        {
            _pieceMovers[i].MoveToShufflePoint();
        }
    }
}