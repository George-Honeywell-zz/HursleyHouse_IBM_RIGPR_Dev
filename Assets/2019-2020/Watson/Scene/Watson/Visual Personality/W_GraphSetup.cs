using UnityEngine;
[RequireComponent(typeof(W_PaintingPerson))]
public class W_GraphSetup : MonoBehaviour
{
    GameObject Graph;
    void Start()
    {
        Personality personality = GetComponent<W_PaintingPerson>().GetPersonality();
        // Set Objects
        Graph = new GameObject("Graph");
        // Graph Specification
        Vector3[] pentagon =
        {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(0.0f, personality.personality[0].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -72.0f) * new Vector3(0.0f, personality.personality[1].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -144.0f) * new Vector3(0.0f, personality.personality[2].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -216.0f) * new Vector3(0.0f, personality.personality[3].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -288.0f) * new Vector3(0.0f, personality.personality[4].percentile, 0.0f),

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
        // Graph Setup
        Mesh graph = Graph.AddComponent<MeshFilter>().mesh;
        graph.vertices = pentagon;
        graph.triangles = triangles;
        graph.normals = normals;
        Material materiala = Graph.AddComponent<MeshRenderer>().material;
        materiala.color = Color.black;
        Graph.transform.position = GameObject.Find("WatsonPrePlayerCharacter").transform.position;
        Graph.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    public GameObject Get()
    {
        return Graph;
    }
}
