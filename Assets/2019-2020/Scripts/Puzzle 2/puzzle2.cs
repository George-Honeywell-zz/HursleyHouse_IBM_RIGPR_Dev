using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzle2 : MonoBehaviour
{
    //Variable decleration
    float[] clockZAngle = new float[9];
    bool[] clockPosition = new bool[9];
    public GameObject[] clocks = new GameObject[10];
    Renderer[] clockRenderer = new Renderer[10];

    //Start function which runs when the script is initialized
    void Start()
    {
        //Assigns the Renderer objects based on the assigned game objects in Unity
        clockRenderer[0] = clocks[0].GetComponentInChildren<Renderer>();
        clockRenderer[1] = clocks[1].GetComponentInChildren<Renderer>();
        clockRenderer[2] = clocks[2].GetComponentInChildren<Renderer>();
        clockRenderer[3] = clocks[3].GetComponentInChildren<Renderer>();
        clockRenderer[4] = clocks[4].GetComponentInChildren<Renderer>();
        clockRenderer[5] = clocks[5].GetComponentInChildren<Renderer>();
        clockRenderer[6] = clocks[6].GetComponentInChildren<Renderer>();
        clockRenderer[7] = clocks[7].GetComponentInChildren<Renderer>();
        clockRenderer[8] = clocks[8].GetComponentInChildren<Renderer>();
        clockRenderer[9] = clocks[9].GetComponentInChildren<Renderer>();
    }

    //Update function which is ran every frame
    void Update()
    {
        //Checks to see if the "1" button is being released
        if (Input.GetKeyUp("1"))
        {
            //Rotates the clock on the z axis
            clocks[0].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        //Checks to see if the "2" button is being released
        else if (Input.GetKeyUp("2"))
        {
            //Rotates the clock on the z axis
            clocks[1].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        //Checks to see if the "3" button is being released
        else if (Input.GetKeyUp("3"))
        {
            //Rotates the clock on the z axis
            clocks[2].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        //Checks to see if the "4" button is being released
        else if (Input.GetKeyUp("4"))
        {
            //Rotates the clock on the z axis
            clocks[3].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        //Checks to see if the "5" button is being released
        else if (Input.GetKeyUp("5"))
        {
            //Rotates the clock on the z axis
            clocks[4].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        //Checks to see if the "6" button is being released
        else if (Input.GetKeyUp("6"))
        {
            //Rotates the clock on the z axis
            clocks[5].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        //Checks to see if the "7" button is being released
        else if (Input.GetKeyUp("7"))
        {
            //Rotates the clock on the z axis
            clocks[6].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        //Checks to see if the "8" button is being released
        else if (Input.GetKeyUp("8"))
        {
            //Rotates the clock on the z axis
            clocks[7].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        //Checks to see if the "9" button is being released
        else if (Input.GetKeyUp("9"))
        {
            //Rotates the clock on the z axis
            clocks[8].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }

        //Retrieves the current Z rotation of each clock GameObject 
        clockZAngle[0] = clocks[0].transform.rotation.eulerAngles.z;
        clockZAngle[1] = clocks[1].transform.rotation.eulerAngles.z;
        clockZAngle[2] = clocks[2].transform.rotation.eulerAngles.z;
        clockZAngle[3] = clocks[3].transform.rotation.eulerAngles.z;
        clockZAngle[4] = clocks[4].transform.rotation.eulerAngles.z;
        clockZAngle[5] = clocks[5].transform.rotation.eulerAngles.z;
        clockZAngle[6] = clocks[6].transform.rotation.eulerAngles.z;
        clockZAngle[7] = clocks[7].transform.rotation.eulerAngles.z;
        clockZAngle[8] = clocks[8].transform.rotation.eulerAngles.z;

        //Checks if the clocks z axis is the correct rotation
        if (clockZAngle[0] < 136 && clockZAngle[0] > 134)
        {
            //Changes the clocks colour to green 
            clockRenderer[0].material.SetColor("_Color", Color.green);
            //Sets the clockPosition to true to show it is in the correct position
            clockPosition[0] = true;
        }
        else
        {
            //Changes the clocks colour to red
            clockRenderer[0].material.SetColor("_Color", Color.red);
            //Sets the clockPosition to true to show it is in the wrong position
            clockPosition[0] = false;
        }

        //Checks if the clocks z axis is the correct rotation
        if (clockZAngle[1] < 1 && clockZAngle[1] > -1)
        {
            //Changes the clocks colour to green 
            clockRenderer[1].material.SetColor("_Color", Color.green);
            //Sets the clockPosition to true to show it is in the correct position
            clockPosition[1] = true;
        }
        else
        {
            //Changes the clocks colour to red
            clockRenderer[1].material.SetColor("_Color", Color.red);
            //Sets the clockPosition to true to show it is in the wrong position
            clockPosition[1] = false;
        }

        //Checks if the clocks z axis is the correct rotation
        if (clockZAngle[2] < 91 && clockZAngle[2] > 89)
        {
            //Changes the clocks colour to green 
            clockRenderer[2].material.SetColor("_Color", Color.green);
            //Sets the clockPosition to true to show it is in the correct position
            clockPosition[2] = true;
        }
        else
        {
            //Changes the clocks colour to red
            clockRenderer[2].material.SetColor("_Color", Color.red);
            //Sets the clockPosition to true to show it is in the wrong position
            clockPosition[2] = false;
        }

        //Checks if the clocks z axis is the correct rotation
        if (clockZAngle[3] < 46 && clockZAngle[3] > 44)
        {
            //Changes the clocks colour to green 
            clockRenderer[3].material.SetColor("_Color", Color.green);
            //Sets the clockPosition to true to show it is in the correct position
            clockPosition[3] = true;
        }
        else
        {
            //Changes the clocks colour to red
            clockRenderer[3].material.SetColor("_Color", Color.red);
            //Sets the clockPosition to true to show it is in the wrong position
            clockPosition[3] = false;
        }

        //Checks if the clocks z axis is the correct rotation
        if (clockZAngle[4] < 91 && clockZAngle[4] > 89)
        {
            //Changes the clocks colour to green 
            clockRenderer[4].material.SetColor("_Color", Color.green);
            //Sets the clockPosition to true to show it is in the correct position
            clockPosition[4] = true;
        }
        else
        {
            //Changes the clocks colour to red
            clockRenderer[4].material.SetColor("_Color", Color.red);
            //Sets the clockPosition to true to show it is in the wrong position
            clockPosition[4] = false;
        }

        //Checks if the clocks z axis is the correct rotation
        if (clockZAngle[5] < 181 && clockZAngle[5] > 179)
        {
            //Changes the clocks colour to green 
            clockRenderer[5].material.SetColor("_Color", Color.green);
            //Sets the clockPosition to true to show it is in the correct position
            clockPosition[5] = true;
        }
        else
        {
            //Changes the clocks colour to red
            clockRenderer[5].material.SetColor("_Color", Color.red);
            //Sets the clockPosition to true to show it is in the wrong position
            clockPosition[5] = false;
        }

        //Checks if the clocks z axis is the correct rotation
        if (clockZAngle[6] < 91 && clockZAngle[6] > 89)
        {
            //Changes the clocks colour to green 
            clockRenderer[6].material.SetColor("_Color", Color.green);
            //Sets the clockPosition to true to show it is in the correct position
            clockPosition[6] = true;
        }
        else
        {
            //Changes the clocks colour to red
            clockRenderer[6].material.SetColor("_Color", Color.red);
            //Sets the clockPosition to true to show it is in the wrong position
            clockPosition[6] = false;
        }

        //Checks if the clocks z axis is the correct rotation
        if (clockZAngle[7] < 91 && clockZAngle[7] > 89)
        {
            //Changes the clocks colour to green 
            clockRenderer[7].material.SetColor("_Color", Color.green);
            //Sets the clockPosition to true to show it is in the correct position
            clockPosition[7] = true;
        }
        else
        {
            //Changes the clocks colour to red
            clockRenderer[7].material.SetColor("_Color", Color.red);
            //Sets the clockPosition to true to show it is in the wrong position
            clockPosition[7] = false;
        }

        //Checks if the clocks z axis is the correct rotation
        if (clockZAngle[8] < 46 && clockZAngle[8] > 44)
        {
            //Changes the clocks colour to green 
            clockRenderer[8].material.SetColor("_Color", Color.green);
            //Sets the clockPosition to true to show it is in the correct position
            clockPosition[8] = true;
        }
        else
        {
            //Changes the clocks colour to red
            clockRenderer[8].material.SetColor("_Color", Color.red);
            //Sets the clockPosition to true to show it is in the wrong position
            clockPosition[8] = false;
        }

        //Checks if the clocks are all in the right position
        if (clockPosition[0] && clockPosition[1] && clockPosition[2] && clockPosition[3] && clockPosition[4] && clockPosition[5] && clockPosition[6] && clockPosition[7] && clockPosition[8])
        {
            //Changes the puzzle marker colour to green
            clockRenderer[9].material.SetColor("_Color", Color.green);
        }
        else
        {
            //Changes the puzzle marker colour to red
            clockRenderer[9].material.SetColor("_Color", Color.red);
        }
    }
}
