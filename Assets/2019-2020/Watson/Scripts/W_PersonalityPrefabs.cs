using UnityEngine;
using System.IO;
using System.Collections;




[RequireComponent(typeof(W_TwitterSetup))]
[RequireComponent(typeof(W_WatsonSetup))]
public class W_PersonalityPrefabs : MonoBehaviour
{
    W_TwitterSetup twitter;
    W_WatsonSetup watson;
    GamePersonality prefabs;
    void Start()
    {
        prefabs = new GamePersonality();
        //prefabs.PC = new PersonalityPainting();
        //prefabs.NPCs = new PaintingList();
        twitter = gameObject.GetComponent<W_TwitterSetup>();
        watson = gameObject.GetComponent<W_WatsonSetup>();
        //prefabs.NPCs.paintings = new PersonalityPainting[0];
    }
    void TopPersonality()
    {

    }
    public IEnumerator SetPC(string ScreenName)
    {
        twitter.SearchUserTimeline(ScreenName);
        while (!twitter.GetSearchStatus())
            yield return null;
        watson.GetPersonalityProfile();
        while (!watson.GetAnalysisStatus())
            yield return null;
        prefabs.PC.personality = watson.GetWatsonProfile();
        prefabs.PC.name = ScreenName;
    }
    public Personality GetPCpersonality()
    {
        return prefabs.PC.personality;
    }
    public string GetPCname()
    {
        return prefabs.PC.name;
    }
    public IEnumerator AddNPC(string ScreenName)
    {
        PaintingList newlist = new PaintingList();
        newlist.paintings = new PersonalityPainting[prefabs.NPCs.paintings.Length + 1];
        for (int p = 0; p < prefabs.NPCs.paintings.Length; p++)
            newlist.paintings[p] = prefabs.NPCs.paintings[p];
        twitter.SearchUserTimeline(ScreenName);
        while (!twitter.GetSearchStatus())
            yield return null;
        watson.GetPersonalityProfile();
        while (!watson.GetAnalysisStatus())
            yield return null;
        newlist.paintings[prefabs.NPCs.paintings.Length].personality = watson.GetWatsonProfile();
        newlist.paintings[prefabs.NPCs.paintings.Length].name = ScreenName;
        prefabs.NPCs.paintings = newlist.paintings;
    }
    public void DeleteNPC(string ScreenName)
    {
        PaintingList newlist = new PaintingList();
        newlist.paintings = new PersonalityPainting[prefabs.NPCs.paintings.Length - 1];
        int targetNPC = prefabs.NPCs.paintings.Length;
        bool passedtarget = false;
        for (int p = 0; p < targetNPC; p++)
            if (ScreenName == prefabs.NPCs.paintings[p].name)
                targetNPC = p;
        for (int p = 0; p < prefabs.NPCs.paintings.Length - 2; p++)
        {
            if (targetNPC == p)
                passedtarget = true;
            if (!passedtarget)
                newlist.paintings[p] = prefabs.NPCs.paintings[p];
            if (passedtarget)
                newlist.paintings[p] = prefabs.NPCs.paintings[p + 1];
        }
        prefabs.NPCs.paintings = newlist.paintings;
    }
    public Personality GetNPC(string ScreenName)
    {
        int targetNPC = prefabs.NPCs.paintings.Length;
        for (int p = 0; p < targetNPC; p++)
            if (ScreenName == prefabs.NPCs.paintings[p].name)
                targetNPC = p;
        return prefabs.NPCs.paintings[targetNPC].personality;
    }
    public void SavePrefabs(string filename)
    {
        string directory = "./Assets/2019-2020/Watson/" + filename + ".json";
        if (Directory.Exists(directory))
        {
            File.Delete(directory);
            File.WriteAllText(directory, JsonUtility.ToJson(prefabs));
        }
        if (!Directory.Exists(directory))
            File.WriteAllText(directory, JsonUtility.ToJson(prefabs));
    }
    void SavePrefabs(string filename, string folder)
    {
        string directory = "./Assets/2019-2020/Watson/" + folder + "/" + filename + ".json";
        if (Directory.Exists(directory))
        {
            File.Delete(directory);
            File.WriteAllText(directory, JsonUtility.ToJson(prefabs));
        }
        if (!Directory.Exists(directory))
            File.WriteAllText(directory, JsonUtility.ToJson(prefabs));
    }
    void SavePrefabs(string prefix, string filename, string folder)
    {
        string directory = prefix + folder + "/" + filename + ".json";
        if (Directory.Exists(directory))
        {
            File.Delete(directory);
            File.WriteAllText(directory, JsonUtility.ToJson(prefabs));
        }
        if (!Directory.Exists(directory))
            File.WriteAllText(directory, JsonUtility.ToJson(prefabs));
    }
    public void LoadPrefabs(string filename)
    {
        string directory = "./Assets/2019-2020/Watson/" + filename + ".json";
        prefabs = JsonUtility.FromJson<GamePersonality>(File.ReadAllText(directory));
        
    }
    void LoadPrefabs(string filename, string folder)
    {
        string directory = "./Assets/2019-2020/Watson/" + folder + "/" + filename + ".json";
        prefabs = JsonUtility.FromJson<GamePersonality>(File.ReadAllText(directory));
    }
    void LoadPrefabs(string prefix, string filename, string folder)
    {
        string directory = prefix + folder + "/" + filename + ".json";
        prefabs = JsonUtility.FromJson<GamePersonality>(File.ReadAllText(directory));
    }

}
