using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randonColourGeneration : MonoBehaviour
{
    //Variable Declerations
    int[] sequence;
    int currentDifficulty = 3;
    bool sequencePlayed = true;
    bool onePressed = false;
    bool twoPressed = false;
    bool threePressed = false;
    bool fourPressed = false;
    bool buttonDown = false;
    public int currentBlock;
    Renderer objectColour;


    void Start()
    {
        objectColour = gameObject.GetComponent<Renderer>();

        if (currentBlock == 5)
        {
            //Creating the array
            sequence = new int[10];

            //Assigning the array the values corresponding to the random colour order
            for (int i = 0; i < 10; i++)
            {
                sequence[i] = Random.Range(0, 4);
            }
        }

       
    }

   void Update()
    {
        //Plays the current colour sequence to the player when initiated 
        if (sequencePlayed && Input.GetKeyDown("5"))
        {
            StartCoroutine(ColourSequence());
            sequencePlayed = false;
        }

        if (!buttonDown)
        {
            //Code Detecting input from user
            if (Input.GetKeyDown("1") && currentBlock == 1)
            {
                Debug.Log("1 Is pressed");
                objectColour.material.SetColor("_Color", Color.white);
                onePressed = true;
                buttonDown = true;
                Debug.Log("Button down is " + buttonDown);
            }
            else if (Input.GetKeyDown("2") && currentBlock == 2)
            {
                Debug.Log("2 Is pressed");
                objectColour.material.SetColor("_Color", Color.white);
                twoPressed = true;
               buttonDown = true;
            }
            else if (Input.GetKeyDown("3") && currentBlock == 3)
            {
                Debug.Log("3 Is pressed");
                objectColour.material.SetColor("_Color", Color.white);
                threePressed = true;
                buttonDown = true;
            }
            else if (Input.GetKeyDown("4") && currentBlock == 4)
            {
                Debug.Log("4 Is pressed");
                objectColour.material.SetColor("_Color", Color.white);
                fourPressed = true;
                buttonDown = true;
            }
        }
     
        if (buttonDown)
        {
            if (Input.GetKeyUp("1") && currentBlock == 1 && onePressed)
            {
                Debug.Log("1 Is released");
                objectColour.material.SetColor("_Color", Color.red);
                onePressed = false;
                buttonDown = false;
            }
            else if (Input.GetKeyUp("2") && currentBlock == 2 && twoPressed)
            {
                Debug.Log("2 Is released");
                objectColour.material.SetColor("_Color", Color.yellow);
                twoPressed = false;
                buttonDown = false;
            }
            else if (Input.GetKeyUp("3") && currentBlock == 3 && threePressed)
            {
                Debug.Log("3 Is released");
                objectColour.material.SetColor("_Color", Color.blue);
                threePressed = false;
                buttonDown = false;
            }
            else if (Input.GetKeyUp("4") && currentBlock == 4 && fourPressed)
            {
                Debug.Log("4 Is released");
                objectColour.material.SetColor("_Color", Color.green);
                fourPressed = false;
                buttonDown = false;
            }
        }
    }

    IEnumerator ColourSequence()
    {
        //for loop that displays the random colour sequence to the player
        for (int i = 0; i < currentDifficulty; i++)
        {
            if (currentBlock == 5)
            {
                if (sequence[i] == 0)
                {
                    objectColour.material.SetColor("_Color", Color.red);
                    Debug.Log("Number " + (i + 1) + " in sequence is red");
                    yield return new WaitForSeconds(1);
                    objectColour.material.SetColor("_Color", Color.white);
                    yield return new WaitForSeconds(1);
                }
                if (sequence[i] == 1)
                {
                    objectColour.material.SetColor("_Color", Color.yellow);
                    Debug.Log("Number " + (i + 1) + " in sequence is yellow");
                    yield return new WaitForSeconds(1);
                    objectColour.material.SetColor("_Color", Color.white);
                    yield return new WaitForSeconds(1);
                }
                if (sequence[i] == 2)
                {
                    objectColour.material.SetColor("_Color", Color.blue);
                    Debug.Log("Number " + (i + 1) + " in sequence is blue");
                    yield return new WaitForSeconds(1);
                    objectColour.material.SetColor("_Color", Color.white);
                    yield return new WaitForSeconds(1);
                }
                if (sequence[i] == 3)
                {
                    objectColour.material.SetColor("_Color", Color.green);
                    Debug.Log("Number " + (i + 1) + " in sequence is green");
                    yield return new WaitForSeconds(1);
                    objectColour.material.SetColor("_Color", Color.white);
                    yield return new WaitForSeconds(1);
                }
            }

            if (currentBlock == 5)
            {
                if (i == (currentDifficulty - 1))
                {
                    objectColour.material.SetColor("_Color", Color.white);
                }
            }
        }

        sequencePlayed = true;
    }
}
