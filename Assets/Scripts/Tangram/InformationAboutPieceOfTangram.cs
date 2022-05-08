using System.Collections.Generic;
using UnityEngine;

public class InformationAboutPieceOfTangram : MonoBehaviour
{
    [System.Serializable]
    public struct PieceInformation
    {
        [SerializeField] private PieceOfTangram _piece;
        [SerializeField] private Transform _startPoint;

        public PieceOfTangram Piece => _piece;
        public Transform StartPoint => _startPoint;
    }

    [SerializeField] private PieceInformation[] _pieceInformation;

    public IReadOnlyList<PieceInformation> PieceInformations => _pieceInformation;
}