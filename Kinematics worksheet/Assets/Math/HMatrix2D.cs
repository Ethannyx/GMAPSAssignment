using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
// creating a 3x3 matrix called entries
public float[,] entries { get; set; } = new float[3, 3];

public HMatrix2D()
{
    // your code here
}

public HMatrix2D(float[,] multiArray)
{
//Goes through and gets the input from each row from the multi array
for (int x = 0; x < 3; x++)
    {
        //Goes through and gets the input from each coloumn from the multi array
        for (int y = 0; y < 3; y++)
        {
            //Copy the inputs from the multi array to the entries array
            entries[x, y] = multiArray[x, y];
        }
    }
}

public HMatrix2D(float m00, float m01, float m02,
            float m10, float m11, float m12,
            float m20, float m21, float m22)
{
//Assigning values to the individual spots of the 3x3 matrix
{
    // First row
    entries[0, 0] = m00; // Input 1 at row 0, column 0
    entries[0, 1] = m01; // Input 2 at row 0, column 1
    entries[0, 2] = m02; // Input 3 at row 0, column 2

    // Second row
    entries[1, 0] = m10; // Does the same thing as stated in the about comments
    entries[1, 1] = m11; 
    entries[1, 2] = m12; 

    // Third row
    entries[2, 0] = m20; // Does the same thing as stated in the about comments
    entries[2, 1] = m21; 
    entries[2, 2] = m22; 
}
}

//Defines the + operator to allow for addition of matrices
public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
{
    //Creates a new HMatrix2D to store the result
    HMatrix2D result = new HMatrix2D();
    //Goes through the inputs for each row for both matrices
    for (int x = 0; x < 3; x++)
    {
        //Goes through the inputs for each column for both matrices
        for (int y = 0; y < 3; y++)
        {
            //Adds the individual corresponding elements together and the result in the result matrix
            result.entries[x, y] = left.entries[x, y] + right.entries[x, y];
        }
    }
    //Returns the end product after adding
    return result;
}

//Defines the - operator to allow for addition of matrices
public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
{
    //Creates a new HMatrix2D to store the result
    HMatrix2D result = new HMatrix2D();
    //Goes through the inputs for each row for both matrices
    for (int x = 0; x < 3; x++)
    {
        //Goes through the inputs for each column for both matrices
        for (int y = 0; y < 3; y++)
        {
            //Subtracts the individual corresponding elements together and the result in the result matrix
            result.entries[x, y] = left.entries[x, y] - right.entries[x, y];
        }
    }
    //Returns the end product after subtracting
    return result; 
}   

//Allows us to use the * operator to multiply an instance of HMatrix2D by a scalar
public static HMatrix2D operator *(HMatrix2D left, float scalar)
{
    //Creates a new HMatrix2D to store the result
    HMatrix2D result = new HMatrix2D();
    //Goes through the inputs for each row for both matrices
    for (int x = 0; x < 3; x++)
    {
        //Goes through the inputs for each column for both matrices
        for (int y = 0; y < 3; y++)
        {
            //Multiplies the individual corresponding elements together and the result in the result matrix
            result.entries[x, y] = left.entries[x, y] * scalar;
        }
    }
    //Returns the end product after subtracting
    return result; 
}

// Note that the second argument is a HVector2D object
// Overloading of the * operator
public static HVector2D operator *(HMatrix2D left, HVector2D right)
{
    // Create a new HVector2D to store the result
    return new HVector2D
    (
        //calculates the x and y components of the result
        left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h,
        left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * right.h
    );
}

// Note that the second argument is a HMatrix2D object
// Overloading of the * operator
public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
{
    return new HMatrix2D
    (
        // First row of result matrix
        left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
        left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
        left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

        // Second row of result matrix
        left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
        left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
        left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

        // Third row of result matrix
        left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
        left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
        left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]
);
}

public static bool operator ==(HMatrix2D left, HMatrix2D right)
{
    //Checks through each row and column
    for (int x = 0; x < 3; x++)
    {
        for (int y = 0; y < 3; y++)
        {
            // Check if the corresponding inputs are not equal
            if(left.entries[x, y] != right.entries[x, y])
            {
                //if they are not equal then return false
                return false;
            }
        }
    }
    //if they are equal then return true
    return true;
}

public static bool operator !=(HMatrix2D left, HMatrix2D right)
{
    //Checks through each row and column
    for (int x = 0; x < 3; x++)
    {
        for (int y = 0; y < 3; y++)
        {
            // Check if the corresponding inputs are not equal
            if(left.entries[x, y] != right.entries[x, y])
            {
                //if they are not equal then return true
                return true;
            }
        }
    }
    //if they are equal then return false
    return false;
}

/*public HMatrix2D transpose()
{
    return; // your code here
}

public float GetDeterminant()
{
    return; // your code here
}*/

   public void SetIdentity()
{
    
    /*
    //Goes through and checks each row
    for (int x = 0; x < 3; x++)
    {
        //Goes through and checks each coloumn
        for (int y = 0; y < 3; y++)
        {
            if (x == y)
            {
                //If number of rows = number of columns set the identity to 1
                entries[x, y] = 1;
            }
            else
            {
                //If number of rows != number of columns set the identity to 0
                entries[x, y] = 0f;
            }
        }
    }*/

    //Ternary operator version
    //Goes through and checks each row
    for (int x = 0; x < 3; x++)
    {
        //Goes through and checks each coloumn
        for (int y = 0; y < 3; y++)
        {
            //Ternary operator is (x == y) ? 1.0f : 0.0f 
            //(x == y) checks if number of rows = number of columns
            //? checks if true and 1 will be outcome of true and 0 will be outcome of false
            entries[x, y] = x == y ? 1 : 0;
        }
    }
}

//Movement matrix
public void SetTranslationMat(float transX, float transY)
{
    //Resets matrix to identity matrix
    SetIdentity();
    //Sets translation components
    entries[0, 2] = transX; //Translate along x axis
    entries[1, 2] = transY; //Translate along y axis
}

//Rotation around origin
public void SetRotationMat(float rotDeg)
{
    //Resets matrix to identity matrix
    SetIdentity();
    // Convert the rotation angle from degrees to radians
    float rad = rotDeg * Mathf.Deg2Rad;
    //Setting cosine and sin of the rotation matrix based on the rotation angle
    entries[0, 0] = Mathf.Cos(rad); 
    entries[0, 1] = -Mathf.Sin(rad);
    entries[1, 0] = Mathf.Sin(rad); 
    entries[1, 1] = Mathf.Cos(rad);
}

public void SetScalingMat(float scaleX, float scaleY)
{
    // your code here
}

public void Print()
{
    string result = "";
    for (int r = 0; r < 3; r++)
    {
        for (int c = 0; c < 3; c++)
        {
            result += entries[r, c] + "  ";
        }
        result += "\n";
    }
    Debug.Log(result);
}
}
