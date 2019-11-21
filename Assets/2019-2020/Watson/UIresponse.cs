using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PImanager))]
[RequireComponent(typeof(VisualPI))]
public class UIresponse : MonoBehaviour
{
    PImanager pim;
    VisualPI vpi;
    Camera cam;
    private void Start()
    {
        pim = GetComponent<PImanager>();
        vpi = GetComponent<VisualPI>();
        cam = GetComponent<Camera>();
    }
    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 16;

        if (GUILayout.Button("Analyse"))
        {
            vpi.check = true;
            for (int l = 1; l <= 5; l++)
              for (int i = 1; i <= 7; i++)
                    Debug.Log(pim.pp.bigfive[l - 1].children[i - 1].name);
            vpi.SpawnGraph();
            
        }
        if (vpi.check)
        {

            /*for (int l = 0; l < 5; l++)
                for (int i = 1; i <= 7; i++)
                    if(pim.pp.bigfive[l].children[i - 1].percentile > 0.5f)
                    {
                        GUI.color = Color.green;
                        GUI.Label(new Rect(175 * l, i * 50, 200, 50), pim.pp.bigfive[l].children[i - 1].name, fontSize);
                    }
                    else
                    {
                        GUI.color = Color.red;
                        GUI.Label(new Rect(175 * l, i * 50, 200, 50), pim.pp.bigfive[l].children[i - 1].name, fontSize);
                    }*/

            



        }

    }
}
