using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
public LineFactory lineFactory;
public GameObject ballObject;
private Line drawnLine;
private Ball2D ball;
Color white = Color.white;

private void Start()
{
    ball = ballObject.GetComponent<Ball2D>();
}

void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
        if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
        {
            drawnLine = lineFactory.GetLine(startLinePos, ball.Position.ToUnityVector3(), 0.5f, white);
            drawnLine.EnableDrawing(true);
        }
    }
    else if (Input.GetMouseButtonUp(0) && drawnLine != null)
    {
    drawnLine.EnableDrawing(false);

    //update the velocity of the white ball.
    HVector2D v = new HVector2D(ball.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition));
    ball.Velocity = v;
    drawnLine = null; 
    // End line drawing            
    }

    if (drawnLine != null)
    {
        HVector2D cursor = new HVector2D(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        drawnLine.end = cursor.ToUnityVector3();
    }
}

// 	/// <summary>
// 	/// Get a list of active lines and deactivates them.
// 	/// </summary>
public void Clear()
{
    var activeLines = lineFactory.GetActive();

    foreach (var line in activeLines)
    {
        line.gameObject.SetActive(false);
    }
}
}
