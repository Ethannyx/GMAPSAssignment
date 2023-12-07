using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        Rotate(45f);
        Translate(1f, 1f);
    }


    void Translate(float x, float y)
    {
        //Reset the transformation matrix to the identity matrix
        transformMatrix.SetIdentity();
        //Use the transform matrix to tranform the position via the set x and y values
        transformMatrix.SetTranslationMat(x, y);
        //Apply the new translation to the vertices
        Transform();
        //Update the position after translating
        pos = transformMatrix * pos;
    }

    void Rotate(float angle)
    {
        //Create the translation matrices
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        //Bring to origin
        toOriginMatrix.SetTranslationMat(-pos.x, -pos.y);
        //Rotate around the origin
        rotateMatrix.SetRotationMat(angle);
        //Translate back from origin based on the initial x and y values
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y);
        //Combine the transformations in the correct order
        transformMatrix.SetIdentity();
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;
        //Apply the transformation to the vertices
        Transform();
    }

    private void Transform()
    {
        // Get the vertex positions from the cloned mesh
        vertices = meshManager.clonedMesh.vertices;
        //Go through each vertex
        for (int i = 0; i < vertices.Length; i++)
        {
            // Create a HVector2D point called vert using the x and y values of the current vertex
            HVector2D vert = new HVector2D (vertices[i].x, vertices[i].y);
            // Apply the transformation matrix to the point
            vert = transformMatrix * vert;
            // Update the original vertex with the transformed coordinates
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }
        // Update the vertices of the cloned mesh with the transformed vertices
        meshManager.clonedMesh.vertices = vertices;
    }
}
