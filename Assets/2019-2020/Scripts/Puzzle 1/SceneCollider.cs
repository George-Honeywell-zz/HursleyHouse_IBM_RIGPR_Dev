using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SceneCollider : MonoBehaviour
{
    public SceneController scene;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SteamVR_LoadLevel.Begin("VR_Test_Scene");
        }   
    }
}
