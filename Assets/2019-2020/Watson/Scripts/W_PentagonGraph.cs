using UnityEngine;

public class W_PentagonGraph : MonoBehaviour
{
    GameObject prefab;
    Mesh graph;
    void Start()
    {
        // Set Objects
        prefab = new GameObject("Graph");
        prefab.transform.parent = this.gameObject.transform;
        GameObject Axis = new GameObject("Axis");
        Axis.transform.parent = prefab.transform;
        // Graph Specification
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
        materiala.color = Color.green;
        Axis.transform.position += (this.gameObject.transform.forward * 0.01f);
        //Axis.SetActive(false);
        // Pre-prefab setup
        graph = prefab.AddComponent<MeshFilter>().mesh;
        //graph.MarkDynamic();
        graph.vertices = pentagon;
        graph.triangles = triangles;
        graph.normals = normals;
        Material materialp = prefab.AddComponent<MeshRenderer>().material;
        materialp.color = Color.red;
        prefab.transform.position = (this.gameObject.transform.forward * 2.0f) + this.gameObject.transform.position;
        prefab.SetActive(false);
    }

    public void GetPentagon(Personality personality)
    {
        // Graph filler setup
        Personality p = personality;
        Vector3[] personalpentagon =
        {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(0.0f, p.personality[0].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -72.0f) * new Vector3(0.0f, p.personality[1].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -144.0f) * new Vector3(0.0f, p.personality[2].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -216.0f) * new Vector3(0.0f, p.personality[3].percentile, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, -288.0f) * new Vector3(0.0f, p.personality[4].percentile, 0.0f),
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
        Mesh mesh = new Mesh();
        mesh.vertices = personalpentagon;
        mesh.triangles = triangles;
        mesh.normals = normals;
        graph.Clear();
        graph = mesh;
    }

    public void Show()
    {
        prefab.SetActive(true);
    }
    public void Hide()
    {
        prefab.SetActive(false);
    }
}
