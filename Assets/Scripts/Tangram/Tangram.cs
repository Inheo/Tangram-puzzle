using UnityEngine;

public class Tangram : MonoBehaviour
{
    [SerializeField] private InformationAboutPieceOfTangram _informationAboutPieceOfTangram;

    public event System.Action OnPiecesEndInitialize;

    private void Start()
    {
        InitializePieces();
    }

    private void InitializePieces()
    {
        var information = _informationAboutPieceOfTangram.PieceInformations;

        for (var i = 0; i < information.Count; i++)
        {
            information[i].Piece.Initialize();
        }

        OnPiecesEndInitialize?.Invoke();
    }
}