using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int sceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(sceneIndex);
            Debug.Log("New scene loaded");
        }
    }
}
