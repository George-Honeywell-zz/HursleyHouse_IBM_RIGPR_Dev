using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzle2 : MonoBehaviour
{
    float clock1Z = 0;
    float clock2Z = 0;
    float clock3Z = 0;
    float clock4Z = 0;
    float clock5Z = 0;
    float clock6Z = 0;
    float clock7Z = 0;
    float clock8Z = 0;
    float clock9Z = 0;
    bool clock1Correct = false;
    bool clock2Correct = false;
    bool clock3Correct = false;
    bool clock4Correct = false;
    bool clock5Correct = false;
    bool clock6Correct = false;
    bool clock7Correct = false;
    bool clock8Correct = false;
    bool clock9Correct = false;
    public GameObject clock1;
    public GameObject clock2;
    public GameObject clock3;
    public GameObject clock4;
    public GameObject clock5;
    public GameObject clock6;
    public GameObject clock7;
    public GameObject clock8;
    public GameObject clock9;
    public GameObject completed;
    Renderer clock1Renderer;
    Renderer clock2Renderer;
    Renderer clock3Renderer;
    Renderer clock4Renderer;
    Renderer clock5Renderer;
    Renderer clock6Renderer;
    Renderer clock7Renderer;
    Renderer clock8Renderer;
    Renderer clock9Renderer;
    Renderer completedRenderer;

    void Start()
    {
        clock1Renderer = clock1.GetComponent<Renderer>();
        clock2Renderer = clock2.GetComponent<Renderer>();
        clock3Renderer = clock3.GetComponent<Renderer>();
        clock4Renderer = clock4.GetComponent<Renderer>();
        clock5Renderer = clock5.GetComponent<Renderer>();
        clock6Renderer = clock6.GetComponent<Renderer>();
        clock7Renderer = clock7.GetComponent<Renderer>();
        clock8Renderer = clock8.GetComponent<Renderer>();
        clock9Renderer = clock9.GetComponent<Renderer>();
        completedRenderer = completed.GetComponent<Renderer>();
    }

    void Update()
    {
        clock1Z = clock1.transform.rotation.eulerAngles.z;
        clock2Z = clock2.transform.rotation.eulerAngles.z;
        clock3Z = clock3.transform.rotation.eulerAngles.z;
        clock4Z = clock4.transform.rotation.eulerAngles.z;
        clock5Z = clock5.transform.rotation.eulerAngles.z;
        clock6Z = clock6.transform.rotation.eulerAngles.z;
        clock7Z = clock7.transform.rotation.eulerAngles.z;
        clock8Z = clock8.transform.rotation.eulerAngles.z;
        clock9Z = clock9.transform.rotation.eulerAngles.z;

        if (Input.GetKeyUp("1"))
        {
            clock1.transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("2"))
        {
            clock2.transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("3"))
        {
            clock3.transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("4"))
        {
            clock4.transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("5"))
        {
            clock5.transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("6"))
        {
            clock6.transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("7"))
        {
            clock7.transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("8"))
        {
            clock8.transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }
        else if (Input.GetKeyUp("9"))
        {
            clock9.transform.Rotate(0.0f, 0.0f, 45f, Space.Self);
        }

        if(clock1Z < 136 && clock1Z > 134)
        {
            clock1Renderer.material.SetColor("_Color", Color.green);
            clock1Correct = true;
        }
        else
        {
            clock1Renderer.material.SetColor("_Color", Color.red);
            clock1Correct = false;
        }

        if (clock2Z < 1 && clock2Z > -1)
        {
            clock2Renderer.material.SetColor("_Color", Color.green);
            clock2Correct = true;
        }
        else
        {
            clock2Renderer.material.SetColor("_Color", Color.red);
            clock2Correct = false;
        }

        if (clock3Z < 91 && clock3Z > 89)
        {
            clock3Renderer.material.SetColor("_Color", Color.green);
            clock3Correct = true;
        }
        else
        {
            clock3Renderer.material.SetColor("_Color", Color.red);
            clock3Correct = false;
        }

        if (clock4Z < 46 && clock4Z > 44)
        {
            clock4Renderer.material.SetColor("_Color", Color.green);
            clock4Correct = true;
        }
        else
        {
            clock4Renderer.material.SetColor("_Color", Color.red);
            clock4Correct = false;
        }

        if (clock5Z < 91 && clock5Z > 89)
        {
            clock5Renderer.material.SetColor("_Color", Color.green);
            clock5Correct = true;
        }
        else
        {
            clock5Renderer.material.SetColor("_Color", Color.red);
            clock5Correct = false;
        }

        if (clock6Z < 181 && clock6Z > 179)
        {
            clock6Renderer.material.SetColor("_Color", Color.green);
            clock6Correct = true;
        }
        else
        {
            clock6Renderer.material.SetColor("_Color", Color.red);
            clock6Correct = false;
        }

        if (clock7Z < 91 && clock7Z > 89)
        {
            clock7Renderer.material.SetColor("_Color", Color.green);
            clock7Correct = true;
        }
        else
        {
            clock7Renderer.material.SetColor("_Color", Color.red);
            clock7Correct = false;
        }

        if (clock8Z < 91 && clock8Z > 89)
        {
            clock8Renderer.material.SetColor("_Color", Color.green);
            clock8Correct = true;
        }
        else
        {
            
            clock8Correct = false;
        }

        if (clock9Z < 46 && clock9Z > 44)
        {
            clock9Renderer.material.SetColor("_Color", Color.green);
            clock9Correct = true;
        }
        else
        {
            clock9Renderer.material.SetColor("_Color", Color.red);
            clock9Correct = false;
        }

        if(clock1Correct && clock2Correct && clock3Correct && clock4Correct && clock5Correct && clock6Correct & clock7Correct && clock8Correct && clock9Correct)
        {
            completedRenderer.material.SetColor("_Color", Color.green);
        }
        else
        {
            completedRenderer.material.SetColor("_Color", Color.red);
        }
    }
}
