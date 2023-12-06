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
    //Checks if left mouse button is pressed
    if (Input.GetMouseButtonDown(0))
    {
        //Gets the mouse position on the screen
        var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        // Check if the ball collides with the mouse position
        if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
        {
            //Draws a line from the ball to the mouse position
            drawnLine = lineFactory.GetLine(startLinePos, ball.Position.ToUnityVector3(), 0.5f, white);
            drawnLine.EnableDrawing(true);
        }
    }
    //If the left mouse button is released
    else if (Input.GetMouseButtonUp(0) && drawnLine != null)
    {
    //Stop the drawing of the line
    drawnLine.EnableDrawing(false);
    //Clear the lines
    Clear();
    //Update the velocity of the ball based on the drawn line
    HVector2D v = new HVector2D(ball.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition));
    ball.Velocity = v;         
    }

    //Updates the line based on the mouse position (makes it draggable)
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
    //Get all the active lines in the scene
    var activeLines = lineFactory.GetActive();
    //Deletes the lines
    foreach (var line in activeLines)
    {
        line.gameObject.SetActive(false);
    }
}
}
