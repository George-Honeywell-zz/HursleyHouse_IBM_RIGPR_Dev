using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_AxisSetup : MonoBehaviour
{
    GameObject Axis;
    void Start()
    {
        Axis = new GameObject("Axis");
        Axis.transform.parent = this.gameObject.transform;
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
        // Axis Setup
        Mesh axis = Axis.AddComponent<MeshFilter>().mesh;
        axis.vertices = pentagon;
        axis.triangles = triangles;
        axis.normals = normals;
        Material materiala = Axis.AddComponent<MeshRenderer>().material;
        materiala.color = Color.grey;
        Axis.transform.position = this.gameObject.transform.position + (this.gameObject.transform.forward * 2.01f);
        Axis.SetActive(false);
    }
    public GameObject Get()
    {
        return Axis;
    }
}
