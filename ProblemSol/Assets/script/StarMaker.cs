using System;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class StaticMeshGen : MonoBehaviour
{
    public Material toonMaterial;
    
    void Start()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[]
        {
            //star 1
            new Vector3(10, 0,0),
            new Vector3(3.09f,0, 9.511f),
            new Vector3(-8.09f,0, 5.878f),
            new Vector3(-8.09f,0, -5.878f),
            new Vector3(3.09f,0, -9.511f),

            new Vector3(-1.18f,0, 3.633f),
            new Vector3(3.09f,0, 2.245f),
            new Vector3(3.09f,0, -2.245f),
            new Vector3(-1.18f,0, -3.633f),
            new Vector3(-3.82f,0, 0),
            //star 2
            new Vector3(10,15, 0),
            new Vector3(3.09f,15, 9.511f),
            new Vector3(-8.09f,15, 5.878f),
            new Vector3(-8.09f,15, -5.878f),
            new Vector3(3.09f,15, -9.511f),

            new Vector3(-1.18f,15, 3.633f),
            new Vector3(3.09f,15, 2.245f),
            new Vector3(3.09f,15, -2.245f),
            new Vector3(-1.18f,15, -3.633f),
            new Vector3(-3.82f,15, 0)
        };
        mesh.vertices = vertices;
        int[] starpillar = new int[]
        {
            //star 1
            0,5,8,
            1,9,7,
            2,8,6,
            3,7,5,
            4,6,9,
            //star 2
            10,18,15,
            11,17,19,
            12,16,18,
            13,15,17,
            14,19,16,
            //bridge
            0,7,17,
            0,17,10,
            0,10,6,
            1,6,16,
            1,16,11,
            1,11,5,
            1,11,15,
            2,5,15,
            2,15,12,
            2,12,9,
            3,9,19,
            3,19,13,
            3,13,8,
            4,8,18,
            4,18,14,
            4,14,7,
            4,14,17,
            5,11,15,
            6,10,16,
            7,14,17,
            8,13,18,
            9,12,19,

        };

        mesh.triangles = starpillar;

        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();

        mf.mesh = mesh;

        mr.material = toonMaterial;
    }
    void Update()
    {

    }
}