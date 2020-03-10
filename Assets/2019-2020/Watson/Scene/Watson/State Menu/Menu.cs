using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(M_Startup))]
[RequireComponent(typeof(M_Options))]
[RequireComponent(typeof(M_TextInput))]
[RequireComponent(typeof(M_Personality))]
public class Menu : MonoBehaviour
{
    State<Menu> current;
    M_Startup start;
    M_Options options;
    M_TextInput text;
    M_Personality personality;
    // Font & Backing Graphics
    void Start()
    {
        start = GetComponent<M_Startup>();
        start.Initialise();
        options = GetComponent<M_Options>();
        options.Initialise();
        text = GetComponent<M_TextInput>();
        text.Initialise();
        personality = GetComponent<M_Personality>();
        personality.Initialise();
    }
    public IEnumerator Instance()
    {
        current.Activate();
        while (!current.input)
            yield return null;
        current.Transition();
        
    }
}
