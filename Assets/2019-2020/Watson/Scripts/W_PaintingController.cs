using System.Collections;
using System.IO;
using UnityEngine;
using IBM.Cloud.SDK.Utilities;
[RequireComponent(typeof(W_TwitterSetup))]
[RequireComponent(typeof(W_WatsonSetup))]
[RequireComponent(typeof(W_PaintingPerson))]
public class W_PaintingController : MonoBehaviour
{
    public GameObject prefab;
    public GameObject NewBlank()
    {
        return Instantiate(prefab);
    }
    W_TwitterSetup twitter;
    W_WatsonSetup watson;
    W_PaintingPerson consciousness;
    GameObject parent;
    string stringToEdit = "Hello World";
    bool TextBox = false;
    bool AddedSelf = false;
    bool AddedOther = false;
    bool GraphActive = false;
    int CurrentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.name = "Controller";
        twitter = gameObject.GetComponent<W_TwitterSetup>();
        watson = gameObject.GetComponent<W_WatsonSetup>();
        consciousness = gameObject.GetComponent<W_PaintingPerson>();
        parent = new GameObject("Personality List");
        parent.AddComponent<W_SpeechResponse>();
    }
    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 16;
        
        if (!TextBox)
            if (GUILayout.Button("ADD"))
                TextBox = true;
        
        if (TextBox)
        {
            stringToEdit = GUI.TextField(new Rect(100, 100, 200, 20), stringToEdit, 25);
            if (GUILayout.Button("Set Self"))
            {
                Runnable.Run(SetSelf(stringToEdit));
                TextBox = false;
            }
            if (GUILayout.Button("Add Other"))
            {
                Runnable.Run(Add(stringToEdit));
                TextBox = false;
            }
        }
        if (AddedSelf || AddedOther)
        {
            if (!GraphActive)
            if (GUILayout.Button("Show Graph"))
            {
                if (AddedSelf)
                {
                    transform.SetAsFirstSibling();
                    consciousness.GetGraph().Show();
                    GraphActive = true;
                }
                if (AddedOther && !AddedSelf)
                {
                    parent.transform.GetChild(0).GetComponent<W_PaintingPerson>().GetGraph().Show();
                    GraphActive = true;
                }
            }
            if (GraphActive)
            {
                if (GUILayout.Button("Next"))
                {
                    parent.transform.GetChild(CurrentIndex).GetComponent<W_PaintingPerson>().GetGraph().Hide();
                    CurrentIndex++;
                    if (CurrentIndex >= parent.transform.childCount)
                        CurrentIndex = 0;
                    parent.transform.GetChild(CurrentIndex).GetComponent<W_PaintingPerson>().GetGraph().Show();
                }
                if (GUILayout.Button("Back"))
                {
                    parent.transform.GetChild(CurrentIndex).GetComponent<W_PaintingPerson>().GetGraph().Hide();
                    CurrentIndex--;
                    if (CurrentIndex >= parent.transform.childCount)
                        CurrentIndex = 0;
                    parent.transform.GetChild(CurrentIndex).GetComponent<W_PaintingPerson>().GetGraph().Show();
                }
                if (GUILayout.Button("Hide Graph"))
                {
                    parent.transform.GetChild(CurrentIndex).GetComponent<W_PaintingPerson>().GetGraph().Hide();
                }
            }
            
                
        }


        /*if (WWS.GetAnalysisStatus())
        {
            WPG.GetPentagon(WPP.GetPCpersonality());
            if (GUILayout.Button("Show"))
                WPG.Show();
            if (GUILayout.Button("Hide"))
                WPG.Hide();
        }*/
    }
    public IEnumerator SetSelf(string ScreenName)
    {
        twitter.SearchUserTimeline(ScreenName);
        while (!twitter.GetSearchStatus())
            yield return null;
        watson.GetPersonalityProfile();
        while (!watson.GetAnalysisStatus())
            yield return null;
        this.name = ScreenName;
        consciousness.transform.SetParent(parent.transform);
        consciousness.SetPersonality(watson.GetWatsonProfile());
        AddedSelf = true;
    }
    public IEnumerator Add(string ScreenName)
    {
        twitter.SearchUserTimeline(ScreenName);
        while (!twitter.GetSearchStatus())
            yield return null;
        watson.GetPersonalityProfile();
        while (!watson.GetAnalysisStatus())
            yield return null;
        W_PaintingPerson NPC = NewBlank().AddComponent<W_PaintingPerson>();
        NPC.name = ScreenName;
        NPC.transform.SetParent(parent.transform);
        NPC.SetPersonality(watson.GetWatsonProfile());
        AddedOther = true;
    }
    public void SavePrefabs()
    {
        string[] directory = new string[parent.transform.childCount];
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            directory[i] = "./Assets/2019-2020/Watson/" + parent.transform.GetChild(i).name + ".json";
            Personality personality = GameObject.Find(parent.transform.GetChild(i).name).GetComponent<W_PaintingPerson>().GetPersonality();
            if (Directory.Exists(directory[i]))
            {
                File.Delete(directory[i]);
                File.WriteAllText(directory[i], JsonUtility.ToJson(personality));
            }
            if (!Directory.Exists(directory[i]))
                File.WriteAllText(directory[i], JsonUtility.ToJson(personality));
        }
    }
    void SavePrefabs(string folder)
    {
        string[] directory = new string[parent.transform.childCount];
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            directory[i] = "./Assets/2019-2020/Watson/" + folder + "/" + parent.transform.GetChild(i).name + ".json";
            Personality personality = GameObject.Find(parent.transform.GetChild(i).name).GetComponent<W_PaintingPerson>().GetPersonality();
            if (Directory.Exists(directory[i]))
            {
                File.Delete(directory[i]);
                File.WriteAllText(directory[i], JsonUtility.ToJson(personality));
            }
            if (!Directory.Exists(directory[i]))
                File.WriteAllText(directory[i], JsonUtility.ToJson(personality));
        }
    }
    void SavePrefabs(string prefix, string folder)
    {
        string[] directory = new string[parent.transform.childCount];
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            directory[i] = prefix + folder + "/" + parent.transform.GetChild(i).name + ".json";
            Personality personality = GameObject.Find(parent.transform.GetChild(i).name).GetComponent<W_PaintingPerson>().GetPersonality();
            if (Directory.Exists(directory[i]))
            {
                File.Delete(directory[i]);
                File.WriteAllText(directory[i], JsonUtility.ToJson(personality));
            }
            if (!Directory.Exists(directory[i]))
                File.WriteAllText(directory[i], JsonUtility.ToJson(personality));
        }
    }
    public void LoadPrefab(string filename)
    {
        string directory = "./Assets/2019-2020/Watson/" + filename + ".json";
        //W_PaintingPerson painting = new W_PaintingPerson(filename, JsonUtility.FromJson<Personality>(File.ReadAllText(directory)));
        //painting.gameObject.transform.SetParent(parent.transform);
    }
    void LoadPrefab(string filename, string folder)
    {
        string directory = "./Assets/2019-2020/Watson/" + folder + "/" + filename + ".json";
        //W_PaintingPerson painting = new W_PaintingPerson(filename, JsonUtility.FromJson<Personality>(File.ReadAllText(directory)));
        //painting.gameObject.transform.SetParent(parent.transform);
    }
    void LoadPrefab(string prefix, string filename, string folder)
    {
        string directory = prefix + folder + "/" + filename + ".json";
        //W_PaintingPerson painting = new W_PaintingPerson(filename, JsonUtility.FromJson<Personality>(File.ReadAllText(directory)));
        //painting.gameObject.transform.SetParent(parent.transform);
    }
}
