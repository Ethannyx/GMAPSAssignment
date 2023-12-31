using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +(HVector2D a, HVector2D b)
        {
            return new HVector2D(a.x + b.x, a.y + b.y);
        }

        public static HVector2D operator -(HVector2D a, HVector2D b)
        {
            return new HVector2D(a.x - b.x, a.y - b.y);
        }



        public void Normalize()
        {
            float magnitude = Magnitude();
            x /= magnitude;
            y /= magnitude;
        }

        // Magnitude method
        public float Magnitude()
        {
            return Mathf.Sqrt(x * x + y * y);
        }

        public static HVector2D operator *(HVector2D vector, float scalar)
        {
            return new HVector2D(vector.x * scalar, vector.y * scalar);
        }

        public static HVector2D operator /(HVector2D vector, float scalar)
        {   
            return new HVector2D(vector.x / scalar, vector.y / scalar);
        }

        // Convert to Unity Vector3
        public Vector3 ToUnityVector3()
        {
            return new Vector3(x, y, 0);
        }

        public float DotProduct(HVector2D vec)
        {
            return(x * vec.x + y * vec.y);
        }
        public float FindAngle(HVector2D vec)
        {
            return (float)Mathf.Acos(DotProduct(vec) / (Magnitude() * vec.Magnitude()));
        }
        public HVector2D Projection(HVector2D b)
        {
            HVector2D proj = b * (DotProduct(b) / b.DotProduct(b));
            return proj;    
        }


}
