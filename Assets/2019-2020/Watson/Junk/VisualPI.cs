using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PImanager))]
public class VisualPI : MonoBehaviour
{
    PImanager pim;
    GameObject Big5GO;
    Mesh Graph;
    GameObject Big5Backing;
    Mesh Backing;
    MeshRenderer MR;

    Vector3[] BIG5v;
    Vector3[] BIG5n;
    public bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        pim = GetComponent<PImanager>();

        Big5GO = new GameObject();
        Big5GO.name = "Big5 Graph";
        Graph = Big5GO.AddComponent<MeshFilter>().mesh;
        Big5GO.AddComponent<MeshRenderer>();


        Big5Backing = new GameObject();
        Big5Backing.name = "Backing";
        Backing = Big5Backing.AddComponent<MeshFilter>().mesh;
        MR = Big5Backing.AddComponent<MeshRenderer>();
        MR.material.color = Color.black;
        

    }

    void CalculateGraph()
    {
        BIG5v = new Vector3[6];
        BIG5v[0] = Vector3.zero;
        BIG5v[1] = BIG5v[0] + new Vector3(0.0f, 1.0f, 0.0f);
        for (int b = 2; b < 6; b++)
        BIG5v[b] = Quaternion.Euler(0.0f, 0.0f, -72.0f) * BIG5v[b-1];
        BIG5n = new Vector3[6];
        BIG5n[0] = Vector3.zero;
        for (int n = 1; n < 6; n++)
            BIG5n[n] = BIG5v[n].normalized;
        for (int p = 0; p < 5; p++)
            BIG5v[p + 1] = BIG5n[p+1] * (float)pim.pp.bigfive[p].children[0].percentile / 2.0f;
        int[] triangles = {
            0, 1, 2,
            0, 2, 3,
            0, 3, 4,
            0, 4, 5,
            0, 5, 1
        };
        Graph.vertices = BIG5v;
        Graph.triangles = triangles;
        Backing.vertices = BIG5n;
        Backing.triangles = triangles;
        Big5GO.transform.localScale = new Vector3(0.5f, 0.5f);
        Big5Backing.transform.localScale = new Vector3(0.5f, 0.5f);
        Big5GO.transform.position = this.gameObject.transform.forward + this.gameObject.transform.position;
        Big5Backing.transform.position = Big5GO.transform.position + Big5GO.transform.forward;
        

    }
    public void SpawnGraph()
    {
        CalculateGraph();
        Big5GO.SetActive(true);
    }
    void OnGUI()
    {
        if (check)
        {
            Vector2[] WS = //Word Size
                {
                new Vector2(60, 25),
                new Vector2(110, 25),
                new Vector2(80, 25),
                new Vector2(90, 25),
                new Vector2(100, 25),
            };
            GUI.color = Color.magenta;
            for (int s = 0; s < 5; s++)
                GUI.Label(new Rect(((Screen.width - WS[s].x) / 2.0f) - (BIG5n[s + 1].x * 115), ((Screen.height - WS[s].y) / 2.0f) - (BIG5n[s + 1].y * 115), WS[s].x, WS[s].y) , pim.pp.bigfive[s].children[0].name);
            
        }
        
    }
}
