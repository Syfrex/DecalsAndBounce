using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decal : MonoBehaviour
{
    Material decalMaterial;
    public Mesh decalMesh;

    public Vector3[] newVertices =
        {
        new Vector3(0,0,0),
        new Vector3(1,0,0),
        new Vector3(1,1,0),
        new Vector3(0,1,0)
            };
    public int[] newTriangles = { 0, 2, 1 };
    List<Matrix4x4> matrixList = new List<Matrix4x4>();

    void Start()
    {
        decalMaterial = GetComponent<MeshRenderer>().material;
        decalMesh = new Mesh();
        //GetComponent<MeshFilter>().mesh = decalMesh;
        decalMesh.vertices = newVertices;
        decalMesh.triangles = newTriangles;

    }
    void Update()
    {
        if(matrixList.Count > 0)
        {
            Matrix4x4[] matricies = matrixList.ToArray();
            DrawDecal(decalMesh, matricies);
        }
    }

    public void AddDecals(Matrix4x4 matrix)
    {
        matrixList.Add(matrix);
    }

    void DrawDecal(Mesh mesh, Matrix4x4[] matricies)
    {
        Graphics.DrawMeshInstanced(mesh, 0, decalMaterial, matricies);
    }
}
