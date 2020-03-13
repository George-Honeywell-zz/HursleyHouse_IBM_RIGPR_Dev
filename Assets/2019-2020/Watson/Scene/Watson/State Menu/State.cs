using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State <M> : MonoBehaviour
{
    M menu;
    public GameObject canvas;
    public bool input;
    public virtual void Activate()
    {
        // Show canvas
    }
    public virtual void Action()
    {
        // Return button input
    }
    public virtual void Deactivate()
    {
        // Hide canvas
    }
}
