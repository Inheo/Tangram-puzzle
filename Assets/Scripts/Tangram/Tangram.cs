using UnityEngine;
using System.Linq;

public class Tangram : MonoBehaviour
{
    [SerializeField] private Piece[] _pieces;

    public event System.Action OnPiecesEndInitialize;

    public event System.Action OnTangramAssembled;

    private void Start()
    {
        InitializePieces();
        SubscribeEvent();
    }

    private void OnDestroy()
    {
        UnsubscribeEvent();
    }

    private void InitializePieces()
    {
        for (var i = 0; i < _pieces.Length; i++)
        {
            _pieces[i].Initialize();
        }

        OnPiecesEndInitialize?.Invoke();
    }

    private void SubscribeEvent()
    {
        for (var i = 0; i < _pieces.Length; i++)
        {
            _pieces[i].OnPin += CheckWin;
        }
    }

    private void UnsubscribeEvent()
    {
        for (var i = 0; i < _pieces.Length; i++)
        {
            _pieces[i].OnPin -= CheckWin;
        }
    }

    private void CheckWin()
    {
        bool isWin = _pieces.Count(x => x.PinRight == false) == 0;

        if (isWin == true)
        {
            OnTangramAssembled?.Invoke();
        }
    }
}