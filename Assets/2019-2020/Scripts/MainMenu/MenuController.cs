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
}
