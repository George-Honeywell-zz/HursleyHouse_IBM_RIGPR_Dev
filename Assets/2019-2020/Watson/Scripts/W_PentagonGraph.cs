using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_PentagonGraph : MonoBehaviour
{
    GameObject Axis;
    GameObject Graph;
    void Start()
    {
        Axis = new GameObject();
        Axis.name = "Big 5 Axis";
        Axis.transform.parent = this.gameObject.transform;
        Graph = new GameObject();
        Graph.name = "Big 5 Graph";
        Graph.transform.parent = this.gameObject.transform;
    }

    public void GetPentagon(Personality player)
    {
        Vector3[] pentagonA =
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

        Mesh axis = Axis.AddComponent<MeshFilter>().mesh;
        axis.vertices = pentagonA;
        axis.triangles = triangles;
        axis.normals = normals;
        Material material = Axis.AddComponent<MeshRenderer>().material;
        material.color = Color.green;
        Axis.transform.position = (this.gameObject.transform.forward * 2.01f) + this.gameObject.transform.position;
        Axis.SetActive(false);

        Personality p = player;
        Vector3[] pentagonG =
        {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(0.0f, p.personality[0].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -72.0f) * new Vector3(0.0f, p.personality[1].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -144.0f) * new Vector3(0.0f, p.personality[2].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -216.0f) * new Vector3(0.0f, p.personality[3].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -288.0f) * new Vector3(0.0f, p.personality[4].percentile, 0.0f),
        };
        Mesh graph = Graph.AddComponent<MeshFilter>().mesh;
        graph.vertices = pentagonG;
        graph.triangles = triangles;
        graph.normals = normals;
        Material mat = Graph.AddComponent<MeshRenderer>().material;
        mat.color = Color.red;
        Graph.transform.position = (this.gameObject.transform.forward * 2.0f) + this.gameObject.transform.position;
        Graph.SetActive(false);
    }

    public void Show()
    {
        Axis.SetActive(true);
        Graph.SetActive(true);
    }
    public void Hide()
    {
        Axis.SetActive(false);
        Graph.SetActive(false);
    }
}
