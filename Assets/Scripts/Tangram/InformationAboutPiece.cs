using System.Collections.Generic;
using UnityEngine;

public class InformationAboutPiece : MonoBehaviour
{
    [System.Serializable]
    public struct PieceInformation
    {
        [SerializeField] private Piece _piece;
        [SerializeField] private Transform _startPoint;

        public Piece Piece => _piece;
        public Transform StartPoint => _startPoint;
    }

    [SerializeField] private PieceInformation[] _pieceInformation;

    public IReadOnlyList<PieceInformation> PieceInformations => _pieceInformation;
}