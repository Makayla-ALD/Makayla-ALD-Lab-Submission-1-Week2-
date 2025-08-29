using UnityEngine;

public class ChessPieces : MonoBehaviour
{
  public ChessParts chessParts;


  public enum ChessParts
    {
        Bishop,
        King,
        Queen,
        Knight,
        Pawn,
        Rook
    }
}
