using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{

    public SteamVR_Input_Sources leftHand;
    public SteamVR_Input_Sources rightHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SteamVR_Input.GetStateDown("A", leftHand))
        {
            Debug.Log("Button A Pressed.");
        }
    }
}
