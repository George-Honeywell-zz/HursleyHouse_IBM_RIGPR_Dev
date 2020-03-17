using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Personality : State<Menu>
{
    public override void Activate()
    {
        canvas.SetActive(true);
    }
    public override void Action()
    {
        // Return button input
        input = true;
    }
    public override void Deactivate()
    {
        input = false;
        canvas.SetActive(false);
    }
}
