using UnityEngine;
using System.Collections;

public class Move
{
    public Tile firstPosition = null;
    public Tile secondPosition = null;
    public PieceAI pieceMoved = null;
    public PieceAI pieceKilled = null;
    public int score = -100000000;
}
