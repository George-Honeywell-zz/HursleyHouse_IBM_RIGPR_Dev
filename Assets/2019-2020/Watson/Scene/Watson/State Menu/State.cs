using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State <M> : MonoBehaviour
{
    M menu;
    public GameObject canvas;
    public virtual void Initialise()
    {
        // Set Up GameObject Buttons
        // Attach Components
    }
    public virtual void Activate()
    {
        // Show Buttons
    }
    public virtual void Deactivate()
    {

    }
}
