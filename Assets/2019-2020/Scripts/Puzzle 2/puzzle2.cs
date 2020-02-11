using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzle2 : MonoBehaviour
{
    float[] clockZAngle = new float[9];
    bool[] clockPosition = new bool[9];
    public GameObject[] clocks = new GameObject[10];
    Renderer[] clockRenderer = new Renderer[10];

    void Start()
    {
        clockRenderer[0] = clocks[0].GetComponent<Renderer>();
        clockRenderer[1] = clocks[1].GetComponent<Renderer>();
        clockRenderer[2] = clocks[2].GetComponent<Renderer>();
        clockRenderer[3] = clocks[3].GetComponent<Renderer>();
        clockRenderer[4] = clocks[4].GetComponent<Renderer>();
        clockRenderer[5] = clocks[5].GetComponent<Renderer>();
        clockRenderer[6] = clocks[6].GetComponent<Renderer>();
        clockRenderer[7] = clocks[7].GetComponent<Renderer>();
        clockRenderer[8] = clocks[8].GetComponent<Renderer>();
        clockRenderer[9] = clocks[9].GetComponent<Renderer>();
    }

    void Update()
    {
        clockZAngle[0] = clocks[0].transform.rotation.eulerAngles.z;
        clockZAngle[1] = clocks[1].transform.rotation.eulerAngles.z;
        clockZAngle[2] = clocks[2].transform.rotation.eulerAngles.z;
        clockZAngle[3] = clocks[3].transform.rotation.eulerAngles.z;
        clockZAngle[4] = clocks[4].transform.rotation.eulerAngles.z;
        clockZAngle[5] = clocks[5].transform.rotation.eulerAngles.z;
        clockZAngle[6] = clocks[6].transform.rotation.eulerAngles.z;
        clockZAngle[7] = clocks[7].transform.rotation.eulerAngles.z;
        clockZAngle[8] = clocks[8].transform.rotation.eulerAngles.z;

        if (Input.GetKeyUp("1"))
        {
            clocks[0].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("2"))
        {
            clocks[1].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("3"))
        {
            clocks[2].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("4"))
        {
            clocks[3].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("5"))
        {
            clocks[4].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("6"))
        {
            clocks[5].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("7"))
        {
            clocks[6].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("8"))
        {
            clocks[7].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("9"))
        {
            clocks[8].transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }

        //Code which checks 
        if(clockZAngle[0] < 136 && clockZAngle[0] > 134)
        {
            clockRenderer[0].material.SetColor("_Color", Color.green);
            clockPosition[0] = true;
        }
        else
        {
            clockRenderer[0].material.SetColor("_Color", Color.red);
            clockPosition[0] = false;
        }

        if (clockZAngle[1] < 1 && clockZAngle[1] > -1)
        {
            clockRenderer[1].material.SetColor("_Color", Color.green);
            clockPosition[1] = true;
        }
        else
        {
            clockRenderer[1].material.SetColor("_Color", Color.red);
            clockPosition[1] = false;
        }

        if (clockZAngle[2] < 91 && clockZAngle[2] > 89)
        {
            clockRenderer[2].material.SetColor("_Color", Color.green);
            clockPosition[2] = true;
        }
        else
        {
            clockRenderer[2].material.SetColor("_Color", Color.red);
            clockPosition[2] = false;
        }

        if (clockZAngle[3] < 46 && clockZAngle[3] > 44)
        {
            clockRenderer[3].material.SetColor("_Color", Color.green);
            clockPosition[3] = true;
        }
        else
        {
            clockRenderer[3].material.SetColor("_Color", Color.red);
            clockPosition[3] = false;
        }

        if (clockZAngle[4] < 91 && clockZAngle[4] > 89)
        {
            clockRenderer[4].material.SetColor("_Color", Color.green);
            clockPosition[4] = true;
        }
        else
        {
            clockRenderer[4].material.SetColor("_Color", Color.red);
            clockPosition[4] = false;
        }

        if (clockZAngle[5] < 181 && clockZAngle[5] > 179)
        {
            clockRenderer[5].material.SetColor("_Color", Color.green);
            clockPosition[5] = true;
        }
        else
        {
            clockRenderer[5].material.SetColor("_Color", Color.red);
            clockPosition[5] = false;
        }

        if (clockZAngle[6] < 91 && clockZAngle[6] > 89)
        {
            clockRenderer[6].material.SetColor("_Color", Color.green);
            clockPosition[6] = true;
        }
        else
        {
            clockRenderer[6].material.SetColor("_Color", Color.red);
            clockPosition[6] = false;
        }

        if (clockZAngle[7] < 91 && clockZAngle[7] > 89)
        {
            clockRenderer[7].material.SetColor("_Color", Color.green);
            clockPosition[7] = true;
        }
        else
        {
            clockRenderer[7].material.SetColor("_Color", Color.red);
            clockPosition[7] = false;
        }

        if (clockZAngle[8] < 46 && clockZAngle[8] > 44)
        {
            clockRenderer[8].material.SetColor("_Color", Color.green);
            clockPosition[8] = true;
        }
        else
        {
            clockRenderer[8].material.SetColor("_Color", Color.red);
            clockPosition[8] = false;
        }

        if (clockPosition[0] && clockPosition[1] && clockPosition[2] && clockPosition[3] && clockPosition[4] && clockPosition[5] && clockPosition[6] && clockPosition[7] && clockPosition[8])
        {
            clockRenderer[9].material.SetColor("_Color", Color.green);
        }
        else
        {
            clockRenderer[9].material.SetColor("_Color", Color.red);
        }
    }
}
