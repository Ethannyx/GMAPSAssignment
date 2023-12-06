using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);
    
    [HideInInspector]
    public float Radius;

    private void Start()
    {
        //Setting ball's initial position
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        // Calculate the radius based on the Sprite size
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        HVector2D a = new HVector2D(8f, 5f);
        HVector2D b = new HVector2D(1f, 3f);
        //Calculating distance between the two points
        float distance = Util.FindDistance(a, b);
        // Check if the distance is less than or equal to the radius
        // If distance less than radius, that means that they are colliding
        return distance <= Radius;
    }

    //Checks if the cue ball is colliding with another ball
    public bool IsCollidingWith(Ball2D other)
    {
        //Calculates the distance between the centre of the colliding balls
        float distance = Util.FindDistance(Position, other.Position);
        //Check if the distance is less than or equal to the sum of their radii
        //If distance less than radius, that means that they are colliding
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        //Updating the position of the ball based on the elapsed time
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        //Calculate the x and y displacement using velocity * elapsed time
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        //Update position based on displacement
        Position.x += displacementX;
        Position.y += displacementY;

        //Update position based on the displacement
        transform.position = new Vector2(Position.x, Position.y);
    }
}

