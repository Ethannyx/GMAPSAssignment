using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        mat.SetIdentity();
        mat.Print();
    }

    void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D();
        HMatrix2D mat2 = new HMatrix2D();
        HMatrix2D resultMat = new HMatrix2D();

        HVector2D vec1 = new HVector2D();
    }
}
