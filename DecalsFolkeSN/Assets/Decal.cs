using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decal : MonoBehaviour
{
    Material decalMaterial;
    Mesh decalMesh;

    private Vector3[] newVertices =
        {
        new Vector3(0,0,0),
        new Vector3(1,0,0),
        new Vector3(1,1,0),
        new Vector3(0,1,0)
            };
    private int[] newTriangles = { 0, 1, 3, 1,2,3 };
    private const int indexsize = 1000;
    private int currIndex = 0;
    private Matrix4x4[] matrixList = new Matrix4x4[indexsize];

    void Start()
    {
        decalMaterial = GetComponent<MeshRenderer>().material;
        decalMesh = new Mesh();
        decalMesh.vertices = newVertices;
        decalMesh.triangles = newTriangles;
    }
    void Update()
    {
            Graphics.DrawMeshInstanced(decalMesh, 0, decalMaterial, matrixList);
    }
    public void DrawDecal(Vector3 position, Quaternion rotation)
    {
        matrixList[currIndex].SetTRS(position, rotation, Vector3.one);
        currIndex = (currIndex + 1) % matrixList.Length;
    }

}
