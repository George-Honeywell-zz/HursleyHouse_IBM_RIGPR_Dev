using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Personality : State<Menu>
{
    //Graphics
    W_VisualPentagon controller;
    public GameObject PrevButton;
    public GameObject NextButton;
    public GameObject SelectSelfButton;
    public GameObject NewButton;
    public GameObject SaveButton;
    public GameObject SaveAsButton;
    public GameObject DeleteButton;
    public GameObject LoadButton;
    public override void Initialise()
    {
        controller = GetComponent<W_VisualPentagon>();
    }
    public override void Activate()
    {
        controller.Show();
    }
}
