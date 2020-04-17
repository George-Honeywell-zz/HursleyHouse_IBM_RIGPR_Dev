using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{

    //public Transform teleportOut;
    //public Transform teleportIn; 
    //public GameObject player;

    //public GameObject mainMenu;
    //public GameObject optionsMenu;
    W_TwitterSetup twitter;
    W_WatsonSetup watson;
    W_PaintingPerson consciousness;
    GameObject mainmenu;
    GameObject watsonmenu;
    TextInput twitterInput;
    public GameObject prefab;
    public GameObject NewBlank()
    {
        return Instantiate(prefab);
    }
    void Start()
    {
        twitter = gameObject.GetComponent<W_TwitterSetup>();
        watson = gameObject.GetComponent<W_WatsonSetup>();
        mainmenu = GameObject.Find("MainMenu");
        watsonmenu = GameObject.Find("WatsonMenu");
        watsonmenu.SetActive(false);
        twitterInput = GameObject.Find("Main Camera").GetComponent<TextInput>();
    }
    public IEnumerator Add(string ScreenName)
    {
        twitter.SearchUserTimeline(ScreenName);
        while (!twitter.GetSearchStatus())
            yield return null;
        watson.GetPersonalityProfile();
        while (!watson.GetAnalysisStatus())
            yield return null;
        consciousness = NewBlank().AddComponent<W_PaintingPerson>();
        consciousness.gameObject.name = "Player";
        consciousness.SetPersonality(watson.GetWatsonProfile());
    }
    public GameObject GetWatson()
    {
        return watsonmenu;
    }
    public void MenuButtons(int sceneIndex)
    {

        //Debug.Log("Button Pressed");
        //SteamVR_LoadLevel.Begin("TheLab");
        SceneManager.LoadScene(sceneIndex);
        

        //if(buttonID == 2)
        //{
        //    mainMenu.transform.position = teleportOut.transform.position;
        //    optionsMenu.transform.position = teleportIn.transform.position;
        //}

        //if (buttonID == 3)
        //{
        //    Application.Quit();
        //}

        ////Options Menu
        //if (buttonID == 4)
        //{
        //    mainMenu.transform.position = teleportIn.transform.position;
        //    optionsMenu.transform.position = teleportOut.transform.position;
        //}
    }
    public void WatsonActivation()
    {
        mainmenu.SetActive(false);
        twitterInput.Activate(true);
    }
}
