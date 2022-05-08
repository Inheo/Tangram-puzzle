using UnityEngine;

public class RightPointPieceOfTangram
{
    public readonly int PieceID;
    public readonly Vector3 Position;

    private int _currentPieceID = -1;

    public RightPointPieceOfTangram(int pieceID, Vector3 position, int currentPieceID = -1)
    {
        PieceID = pieceID;
        Position = position;
        _currentPieceID = currentPieceID;
    }

    public bool IsRightPin => _currentPieceID == PieceID;

    public void PinPieceOfTangram(int pieceID)
    {
        _currentPieceID = pieceID;
    }

    public void UnpinPieceOfTangram()
    {
        _currentPieceID = -1;
    }
}