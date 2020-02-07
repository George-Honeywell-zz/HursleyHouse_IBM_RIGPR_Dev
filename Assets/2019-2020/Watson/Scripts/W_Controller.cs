using UnityEngine;

[RequireComponent(typeof(W_TwitterSetup))]
[RequireComponent(typeof(W_WatsonSetup))]
[RequireComponent(typeof(W_PentagonGraph))]
[RequireComponent(typeof(W_SpeechResponse))]
public class W_Controller : MonoBehaviour
{
    W_TwitterSetup WTS;
    W_WatsonSetup WWS;
    W_PentagonGraph WPG;
    W_SpeechResponse WSR;
    void Start()
    {
        WTS = gameObject.GetComponent<W_TwitterSetup>();
        WWS = gameObject.GetComponent<W_WatsonSetup>();
        WPG = gameObject.GetComponent<W_PentagonGraph>();
        WSR = gameObject.GetComponent<W_SpeechResponse>();
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
        if (WWS.GetAnalysisStatus())
            if (GUILayout.Button("Graph"))
                WPG.GetPentagon(WWS.GetWatsonProfile());
        if (GUILayout.Button("Show"))
            WPG.Show();
    }

}
