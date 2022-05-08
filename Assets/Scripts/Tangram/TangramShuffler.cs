using UnityEngine;

public class TangramShuffler : MonoBehaviour
{
    [SerializeField] private InformationAboutPieceOfTangram _informationAboutPieceOfTangram;
    [SerializeField] private Tangram _tangram;

    private void Start()
    {
        _tangram.OnPiecesEndInitialize += Shuffle;
    }

    private void OnDestroy()
    {
        _tangram.OnPiecesEndInitialize -= Shuffle;
    }

    private void Shuffle()
    {
        var pieceInformation = _informationAboutPieceOfTangram.PieceInformations;
        for (var i = 0; i < pieceInformation.Count; i++)
        {
            pieceInformation[i].Piece.transform.position = pieceInformation[i].StartPoint.transform.position;
        }
    }
}