using UnityEditor;
using UnityEngine;

using UnityEngine;

public class ChessHandles : MonoBehaviour
{
    public enum ChessParts
    {
        Bishop,
        King,
        Queen,
        Knight,
        Pawn,
        Rook
    }
    //enum drop down
    public ChessParts piece = ChessParts.Queen;

    public string chessString;
    
    void OnDrawGizmos()
    {
        chessString = piece.ToString() + ".png";

        Gizmos.DrawIcon(transform.position, chessString, true, Color.red);
    }
}


[CustomEditor(typeof(ChessHandles))]
public class EChessHandles : Editor
{
    //this from unity documentation example
    public void OnSceneGUI()
    {
        var t = (ChessHandles)target;
        var tr = t.transform;
        var pos = tr.position;

        // style
        var color = new Color(.7f, 0.8f, 0.4f, 1);
        Handles.color = color;
        GUI.color = color;

       
        //adjusted to have the enum states
       
        switch (t.piece)
        {
            case ChessHandles.ChessParts.Queen:
                Handles.DrawLine(pos, (pos + Vector3.up *5), 5);           //up the *5 is to make that line longer
                Handles.DrawLine(pos, (pos + Vector3.right *5), 5);        //right
                Handles.DrawLine(pos, (pos + Vector3.left * 5), 5);         //left
                Handles.DrawLine(pos, (pos + Vector3.down * 5), 5);         //down

                Handles.DrawLine(pos, (pos + (Vector3.up + Vector3.right) * 5), 3);     //diag right
                Handles.DrawLine(pos, (pos + (Vector3.up + Vector3.left) * 5), 3);      //diag left
                Handles.DrawLine(pos, (pos + (Vector3.down + Vector3.right) * 5), 3);   // neg diag right
                Handles.DrawLine(pos, (pos + (Vector3.down + Vector3.left) * 5), 3);    // neg diag left
                break;

            case ChessHandles.ChessParts.Rook:
                Handles.DrawLine(pos, (pos + Vector3.up *5), 5);           //up
                Handles.DrawLine(pos, (pos + Vector3.right *5), 5);        //right
                Handles.DrawLine(pos, (pos + Vector3.left*5),5);         //left
                Handles.DrawLine(pos, (pos + Vector3.down * 5), 5);         //down
                break;

            case ChessHandles.ChessParts.Bishop:
                Handles.DrawLine(pos, (pos + (Vector3.up + Vector3.right) * 5), 3);     //diag right
                Handles.DrawLine(pos, (pos + (Vector3.up + Vector3.left) * 5), 3);      //diag left
                Handles.DrawLine(pos, (pos + (Vector3.down + Vector3.right) * 5), 3);   // neg diag right
                Handles.DrawLine(pos, (pos + (Vector3.down + Vector3.left) * 5), 3);    // neg diag left

                break;

            case ChessHandles.ChessParts.Knight:

               /* Handles.DrawLine(pos, pos + (Vector3.right * 1 + Vector3.up * 2), 5);      // ( +2 right, +3 up )
                Handles.DrawLine(pos, pos + (Vector3.left * 2 + Vector3.up * 2), 5);    // ( +2 left, +3 up )*/


                Vector3 rTarget = pos + (Vector3.right * 1 + Vector3.up * 2); //using the unit movement above I just draw disc at that (Vector3.right * 1 + Vector3.up *3)
                Handles.DrawWireDisc(rTarget, Vector3.forward, 0.2f);

                Vector3 lTarget = pos + (Vector3.left * 1 + Vector3.up * 2);
                Handles.DrawWireDisc(lTarget, Vector3.forward, 0.2f);

                Vector3 dLTarget = pos + (Vector3.left * 1 + Vector3.down * 2);
                Handles.DrawWireDisc(dLTarget, Vector3.forward, 0.2f);

                Vector3 dRTarget = pos + (Vector3.right * 1 + Vector3.down * 2); 
                Handles.DrawWireDisc(dRTarget, Vector3.forward, 0.2f);


                Vector3 rUTarget = pos + (Vector3.right * 2 + Vector3.up * 1);
                Handles.DrawWireDisc(rUTarget, Vector3.forward, 0.2f);

                Vector3 lUTarget = pos + (Vector3.left * 2 + Vector3.up * 1);
                Handles.DrawWireDisc(lUTarget, Vector3.forward, 0.2f);

                Vector3 rDTarget = pos + (Vector3.right * 2 + Vector3.down * 1);
                Handles.DrawWireDisc(rDTarget, Vector3.forward, 0.2f);

                Vector3 lDTarget = pos + (Vector3.left * 2 + Vector3.down * 1);
                Handles.DrawWireDisc(lDTarget, Vector3.forward, 0.2f);
                break;

            case ChessHandles.ChessParts.King:
                Handles.DrawLine(pos, (pos + Vector3.up), 5);           //up
                Handles.DrawLine(pos, (pos + Vector3.right), 5);        //right
                Handles.DrawLine(pos, (pos + Vector3.left), 5);         //left
                Handles.DrawLine(pos, (pos + Vector3.down), 5);         //down
                Handles.DrawLine(pos, (pos + (Vector3.up + Vector3.right)), 3);     //diag right
                Handles.DrawLine(pos, (pos + (Vector3.up + Vector3.left)), 3);      //diag left
                Handles.DrawLine(pos, (pos + (Vector3.down + Vector3.right)), 3);   // neg diag right
                Handles.DrawLine(pos, (pos + (Vector3.down + Vector3.left)), 3);    // neg diag left
                break;

            case ChessHandles.ChessParts.Pawn:
                
                Handles.DrawLine(pos, (pos + Vector3.up *2), 5);               //up
                break;
        }
    }

    


}