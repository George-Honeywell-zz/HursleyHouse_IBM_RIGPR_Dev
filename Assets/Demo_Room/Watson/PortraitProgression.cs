using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitProgression : MonoBehaviour
{
    public GameObject[] Portraits;
    int position = 0;
    bool[] NoRepeat = { false, false, false, false, false };
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && (position < Portraits.Length) && NoRepeat[0])
        {
            Portraits[position].GetComponent<Interaction>().WhoAreYou();
            NoRepeat[0] = true;
        }
        if (Input.GetKeyDown(KeyCode.X) && (position < Portraits.Length) && NoRepeat[1])
        {
            Portraits[position].GetComponent<Interaction>().PuzzleDescription();
            NoRepeat[1] = true;
        }
        if (Input.GetKeyDown(KeyCode.C) && (position < Portraits.Length) && NoRepeat[2])
        {
            Portraits[position].GetComponent<Interaction>().Hint();
            NoRepeat[2] = true;
        }
        if (Input.GetKeyDown(KeyCode.V) && (position < Portraits.Length) && NoRepeat[3])
        {
            Portraits[position].GetComponent<Interaction>().AboutHouse();
            NoRepeat[3] = true;
        }
        if (Input.GetKeyDown(KeyCode.B) && (position < Portraits.Length) && NoRepeat[4])
        {
            Portraits[position].GetComponent<Interaction>().Goodbye();
            NoRepeat[4] = true;
        }
        if (Input.GetKeyDown(KeyCode.V) && (position < Portraits.Length))
        {
            for (int a = 0; a < 5; a++)
            {
                NoRepeat[a] = false;
            }
            position++;
        }
    }
}
