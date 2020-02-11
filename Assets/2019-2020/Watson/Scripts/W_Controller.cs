using UnityEngine;
using IBM.Cloud.SDK.Utilities;
[RequireComponent(typeof(W_TwitterSetup))]
[RequireComponent(typeof(W_WatsonSetup))]
[RequireComponent(typeof(W_PentagonGraph))]
[RequireComponent(typeof(W_SpeechResponse))]
[RequireComponent(typeof(W_PersonalityPrefabs))]
public class W_Controller : MonoBehaviour
{
    W_TwitterSetup WTS;
    W_WatsonSetup WWS;
    W_PentagonGraph WPG;
    W_SpeechResponse WSR;
    W_PersonalityPrefabs WPP;

    public string stringToEdit = "Hello World";
    bool SearchBox = false;

    bool PCset = false;
    bool addNPC = false;
    bool setNPC = false;
    bool TwitterAccess = false;

    void Start()
    {
        WTS = gameObject.GetComponent<W_TwitterSetup>();
        WWS = gameObject.GetComponent<W_WatsonSetup>();
        WPG = gameObject.GetComponent<W_PentagonGraph>();
        WSR = gameObject.GetComponent<W_SpeechResponse>();
        WPP = gameObject.GetComponent<W_PersonalityPrefabs>();
    }
    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 16;
        if (!PCset)
            if (GUILayout.Button("Set Player Character Personality"))
                TwitterAccess = true;
        if (addNPC)
            if (GUILayout.Button("Add Non Player Character Personality"))
            {
                addNPC = false;
                setNPC = true;
                TwitterAccess = true;
            }

        if (TwitterAccess)
        {
            if (!SearchBox)
                if (GUILayout.Button("Open Search"))
                SearchBox = true;
            if (SearchBox)
            {
                stringToEdit = GUI.TextField(new Rect(100, 100, 200, 20), stringToEdit, 25);
                if (GUILayout.Button("Enter"))
                {
                    //if (WTS.)
                    if (!PCset)
                    {
                        Runnable.Run(WPP.SetPC(stringToEdit));
                        PCset = true;
                        
                    }
                    if (setNPC)
                    {
                        Runnable.Run(WPP.AddNPC(stringToEdit));
                        setNPC = false;
                    }
                    addNPC = true;
                    SearchBox = false;
                    TwitterAccess = false;
                }
            }   
        }
                

        if (WWS.GetAnalysisStatus())
        {
            WPG.GetPentagon(WPP.GetPCpersonality());
            if (GUILayout.Button("Show"))
                WPG.Show();
            if (GUILayout.Button("Hide"))
                WPG.Hide();
        }
    }

}
