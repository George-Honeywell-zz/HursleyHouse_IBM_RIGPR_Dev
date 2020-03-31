using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Cloud.SDK.Utilities;
using Valve.VR;
[RequireComponent(typeof(W_TwitterSetup))]
[RequireComponent(typeof(W_WatsonSetup))]
[RequireComponent(typeof(W_PaintingPerson))]
public class W_MenuFunctionality : MonoBehaviour
{
    int CurrentIndex;
    // Watson Controller
    public GameObject prefab;
    public GameObject NewBlank()
    {
        return Instantiate(prefab);
    }

    W_TwitterSetup twitter;
    W_WatsonSetup watson;
    W_PaintingPerson consciousness;
    GameObject parent;
    // Menus
    GameObject startmenu;
    GameObject optionsmenu;
    GameObject personalitymenu;
    void Start()
    {
        // Watson
        twitter = gameObject.GetComponent<W_TwitterSetup>();
        watson = gameObject.GetComponent<W_WatsonSetup>();
        consciousness = gameObject.GetComponent<W_PaintingPerson>();
        parent = new GameObject("Personality List");
        parent.AddComponent<W_SpeechResponse>();
        // Menu
        startmenu = GameObject.Find("Start");
        optionsmenu = GameObject.Find("Options");
        optionsmenu.gameObject.SetActive(false);
        personalitymenu = GameObject.Find("Personality");
        personalitymenu.gameObject.SetActive(false);
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
    }
    // Start Menu
    public void StartBF()
    {
        // If no personality selected; go to creation
        // Scene Transition to Tutorial Screne
        SteamVR_LoadLevel.Begin("Outdoor_Area");
    }
    public void OptionsBF()
    {
        // Menu Transition to Options Menu
        startmenu.gameObject.SetActive(false);
        optionsmenu.gameObject.SetActive(true);

    }
    public void QuitBF()
    {
        // Exit Game
        Application.Quit();
    }
    // Options Menu
    public void GameplayTF()
    {
        // Tab Transition to Gameplay Personality Menu
        //settingsmenu.gameObject.SetActive(false);
        personalitymenu.gameObject.SetActive(true);
        if (CurrentIndex != 0)
            parent.transform.GetChild(CurrentIndex).GetComponent<W_PaintingPerson>().GetGraph().Show();
    }
    public void SettingsTF()
    {
        // Tab Transition to Other Settings (typical game settings)
    }
    public void BackBF()
    {
        // Menu Transition to Start Menu
        optionsmenu.gameObject.SetActive(false);
        startmenu.gameObject.SetActive(true);
        if (personalitymenu.activeInHierarchy)
            personalitymenu.SetActive(false);
    }
    // Gameplay Personality Menu
    public void NextBF()
    {
        // Cycle forward through personalities list
        parent.transform.GetChild(CurrentIndex).GetComponent<W_PaintingPerson>().GetGraph().Hide();
        CurrentIndex++;
        if (CurrentIndex >= parent.transform.childCount)
            CurrentIndex = 0;
        parent.transform.GetChild(CurrentIndex).GetComponent<W_PaintingPerson>().GetGraph().Show();
    }
    public void PrevBF()
    {
        // Cycle backwards through personalities list
        parent.transform.GetChild(CurrentIndex).GetComponent<W_PaintingPerson>().GetGraph().Hide();
        CurrentIndex--;
        if (CurrentIndex < 0)
            CurrentIndex = parent.transform.childCount - 1;
        parent.transform.GetChild(CurrentIndex).GetComponent<W_PaintingPerson>().GetGraph().Show();
    }
    public void SetSelfBF()
    {
        // select personality for play

    }
    public void NewPersonBF()
    {

    }
    public void SaveBF()
    {
        // Save All personalities
    }
    public void SaveAsBF()
    {
        // Save personalities under different folder
    }
    public void LoadBF()
    {
        // Load personalities
    }
    public void DeleteBF()
    {
        // Delete personality
    }
}
