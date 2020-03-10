using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State <M> : MonoBehaviour
{
    M menu;
    public bool input;
    public virtual void Initialise()
    {
        // Set Up GameObject Buttons
        // Attach Components
    }
    public virtual void Activate()
    {
        // Show Buttons
    }
}
