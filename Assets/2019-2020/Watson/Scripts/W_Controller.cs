using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(W_TwitterSetup))]
[RequireComponent(typeof(W_WatsonSetup))]
public class W_Controller : MonoBehaviour
{
    W_TwitterSetup WTS;
    W_WatsonSetup WWS;
    void Start()
    {
        WTS = gameObject.GetComponent<W_TwitterSetup>();
        WWS = gameObject.GetComponent<W_WatsonSetup>();
    }
    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 16;

        if (GUILayout.Button("Twitter"))
            WTS.SearchUserTimeline("Oprah");

        if (WTS.GetSearchStatus())
            if (GUILayout.Button("Watson"))
                WWS.GetPersonalityProfile();
    }
}
