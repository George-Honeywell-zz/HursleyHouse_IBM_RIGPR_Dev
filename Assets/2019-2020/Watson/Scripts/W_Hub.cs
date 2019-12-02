using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(W_SetupAnalyser))]
[RequireComponent(typeof(W_Big5Pentagon))]
public class W_Hub : MonoBehaviour
{
    W_SetupAnalyser WSA;
    W_Big5Pentagon WBP;
    void Start()
    {
        WSA = gameObject.GetComponent<W_SetupAnalyser>();
        WBP = gameObject.GetComponent<W_Big5Pentagon>();
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
    }
}
