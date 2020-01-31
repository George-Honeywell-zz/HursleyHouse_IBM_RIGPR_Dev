using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_PentagonGraph : MonoBehaviour
{
    GameObject Graph;
    void Start()
    {
        Graph = new GameObject();
    }

    public void GetPentagon()
    {
        Vector3[] pentagon =
        {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -72.0f) * new Vector3(0.0f, 1.0f, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -144.0f) * new Vector3(0.0f, 1.0f, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -216.0f) * new Vector3(0.0f, 1.0f, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -288.0f) * new Vector3(0.0f, 1.0f, 0.0f),
        };
        int[] triangles = {
            0, 1, 2,
            0, 2, 3,
            0, 3, 4,
            0, 4, 5,
            0, 5, 1
        };
        Vector3[] normals =
        {
            Vector3.back,
            Vector3.back,
            Vector3.back,
            Vector3.back,
            Vector3.back,
            Vector3.back,
        };
        Mesh mesh = Graph.AddComponent<MeshFilter>().mesh;
        mesh.vertices = pentagon;
        mesh.triangles = triangles;
        mesh.normals = normals;
        Material material = Graph.AddComponent<MeshRenderer>().material;
        material.color = Color.green;
        Graph.transform.position = (this.gameObject.transform.forward * 2.0f) + this.gameObject.transform.position;
        Graph.transform.parent = this.gameObject.transform;
        Graph.name = "Big 5 Graph";
        //Graph.SetActive(false);
    }
}
