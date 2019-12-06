using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(W_SetupAnalyser))]
[RequireComponent(typeof(W_Big5Pentagon))]
[RequireComponent(typeof(W_FacetResponse))]
public class W_Hub : MonoBehaviour
{
    W_SetupAnalyser WSA;
    W_Big5Pentagon WBP;
    W_FacetResponse WFR;
    void Start()
    {
        WSA = gameObject.GetComponent<W_SetupAnalyser>();
        WBP = gameObject.GetComponent<W_Big5Pentagon>();
        WFR = gameObject.GetComponent<W_FacetResponse>();
    }

    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 16;
        if (GUILayout.Button("Get Json"))
        {
            WSA.ReadJson("./Assets/2019-2020/Watson/unity-sdk-4.0.0/unity-sdk-4.0.0/Examples/TestData/PersonalityInsights/V3/personalityInsights.json");
        }
        if (GUILayout.Button("Watson's Analysis"))
        {
            WSA.WatsonAnalysis();
            
        }
        if (WSA.WatsonAnalysisDone)
        {
            if (GUILayout.Button("Graph Setup"))
            {
                WBP.GetPentagon(WSA.pp);
            }
            if (GUILayout.Button("Spawn Watson Graph"))
            {
                WBP.ShowGraph();
            }
            if (GUILayout.Button("Hide Watson Graph"))
            {
                WBP.HideGraph();
            }
            if (GUILayout.Button("Talk"))
            {
                Debug.Log(WFR.Respond().name);
            }
        }
    }
}
