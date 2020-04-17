using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInput : MonoBehaviour
{
    bool Active = false;
    public string input;
    MenuController menucontroller;
    void Start()
    {
        menucontroller = GameObject.Find("MenuController").GetComponent<MenuController>();
    }
    public void Activate(bool BOOL)
    {
        Active = BOOL;
    }
    void OnGUI()
    {
        if (Active)
        {
            input = GUI.TextField(new Rect(10, 10, 200, 20), input, 25);
            if (GUILayout.Button("Enter"))
            {
                StartCoroutine(menucontroller.Add(input));
                menucontroller.GetWatson().SetActive(true);
                Activate(false);
            }
        }
    }
}
