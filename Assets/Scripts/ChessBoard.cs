using System.Xml.Schema;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{

    void OnDrawGizmos()
    {
        int tilecolor = -1;
        for (float j = 3f; j >= -4; j--)
        {
            tilecolor = tilecolor * -1;
            for (float i = -3f; i <= 4; i++)
            {
                if (tilecolor == -1)
                {
                    Gizmos.color = new Color(0f, 0f, 0f);
                }
                else if (tilecolor == 1)
                {
                    Gizmos.color = new Color(1f, 1f, 1f);
                }
                Gizmos.DrawCube(new Vector2(i, j), Vector2.one);
                tilecolor = tilecolor * -1;
            }
        }
    }
}