using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using System.Collections.ObjectModel;

public class randomColourGeneration : MonoBehaviour
{
    //Variable Declerations
    int[] sequence;
    int[] playerSequence;
    int playerSequencePos = 0;
    int currentDifficulty = 3;
    bool sequencePlayed = true;
    bool onePressed = false;
    bool twoPressed = false;
    bool threePressed = false;
    bool fourPressed = false;
    bool buttonDown = false;
    bool playerMarked = false;
    bool playerPassed = true;
    public GameObject redBlock;
    public GameObject blueBlock;
    public GameObject yellowBlock;
    public GameObject greenBlock;
    Renderer redBlockRenderer;
    Renderer blueBlockRenderer;
    Renderer yellowBlockRenderer;
    Renderer greenBlockRenderer;
    Renderer sequenceBlockRenderer;
    Text sequenceText;
    Text victoryText;

    SteamVR_Input_Sources leftHand;
    //SteamVR_Input_Sources rightHand;
    Button red_button;
    Button yellow_button;
    Button blue_button;
    Button green_button;
    

    

    //Start function which runs when the script is initialized
    void Start()
    {
        //Getting components from the scene
        redBlockRenderer = redBlock.GetComponent<Renderer>();
        yellowBlockRenderer = yellowBlock.GetComponent<Renderer>();
        blueBlockRenderer = blueBlock.GetComponent<Renderer>();
        greenBlockRenderer = greenBlock.GetComponent<Renderer>();

        //Creating the sequence arrays
        sequence = new int[10];
        playerSequence = new int[10];

        //Assigning the sequence array the values corresponding to the random colour order
        for (int i = 0; i < 10; i++)
        {
            sequence[i] = Random.Range(0, 4);
        }
    }

    public void checkColour()
    {
        //Plays the current colour sequence to the player when initiated 
        //if (sequencePlayed && Input.GetKeyDown("5"))
        //{
        //    StartCoroutine(ColourSequence());
        //    sequencePlayed = false;
        //}

        //---------------------------------------------------------------------------------------//
        //~~~ Debugging for PC Testing                                                           //
        //~~~ Uncomment this out, and comment the 'IF' statement below to use the VR Controller. //
        //---------------------------------------------------------------------------------------//
        //if(sequencePlayed && SteamVR_Input.GetStateDown("LeftTrigger", leftHand))
        //{
        //    StartCoroutine(ColourSequence());
        //    sequencePlayed = false;
        //}

        //---------------------------------------------------------------------------------------//
        //~~~ Debugging for PC Testing                                                           //
        //~~~ Comment this out, and uncomment the 'IF' statement above to use the VR Controller. //
        //---------------------------------------------------------------------------------------//
        if (sequencePlayed && Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(ColourSequence());
            sequencePlayed = false;
        }


        //Runs this code when the player inputs the sequence
        if (playerSequencePos == (currentDifficulty) && !playerMarked)
        {
            //Checks the players sequence against the correct one
            for (int i = 0; i < currentDifficulty; i++)
            {
                if (playerSequence[i] == sequence[i])
                {

                }
                else
                {
                    playerPassed = false;
                }
            }

            //Stores that the players sequence has been "Marked"
            playerMarked = true;

            //Displays that the player passed
            if (playerPassed)
            {
                StartCoroutine(Victory());
            }
            //Displays that the player failed
            else
            {
                StartCoroutine(Failure());
            }
        }

        //Runs this code when the player has finished the sequence
        else if (playerMarked)
        {

            //If the player passed the previous difficulty, proceeds to the next
            if (playerPassed)
            {
                playerMarked = false;
                currentDifficulty++;
                playerSequence = new int[10];
                playerSequencePos = 0;
                playerPassed = true;
            }
            //If the player failed the difficulty, repeats it
            else
            {
                playerMarked = false;
                playerSequence = new int[10];
                playerSequencePos = 0;
                playerPassed = true;
            }

        }

        //Runs this code if no other conditions are met
        else
        {
            if (!buttonDown)
            {
                //Code Detecting when the user presses down a button
                if (SteamVR_Input.GetStateDown("Y", leftHand))
                {
                    Debug.Log("1 Is pressed");
                    redBlockRenderer.material.SetColor("_Color", Color.white);
                    onePressed = true;
                    buttonDown = true;
                }



                //else if (SteamVR_Input.GetStateDown("X", leftHand))
                //{
                //    Debug.Log("2 Is pressed");
                //    yellowBlockRenderer.material.SetColor("_Color", Color.white);
                //    twoPressed = true;
                //    buttonDown = true;
                //}
                //else if (SteamVR_Input.GetStateDown("B", rightHand))
                //{
                //    Debug.Log("3 Is pressed");
                //    blueBlockRenderer.material.SetColor("_Color", Color.white);
                //    threePressed = true;
                //    buttonDown = true;
                //}
                //else if (SteamVR_Input.GetStateDown("A", rightHand))
                //{
                //    Debug.Log("4 Is pressed");
                //    greenBlockRenderer.material.SetColor("_Color", Color.white);
                //    fourPressed = true;
                //    buttonDown = true;
                //}
            }

            if (buttonDown)
            {
                //Code Dettecting when the user releases a button
                //if (SteamVR_Input.GetStateDown("Y", leftHand) && onePressed)
                //{
                //    Debug.Log("1 Is released");
                //    redBlockRenderer.material.SetColor("_Color", Color.red);
                //    onePressed = false;
                //    buttonDown = false;
                //    playerSequence[playerSequencePos] = 0;
                //    playerSequencePos++;
                //}

                if (red_button)
                {
                    Debug.Log("Test");
                }

                //else if (SteamVR_Input.GetStateDown("X", leftHand) && twoPressed)
                //{
                //    Debug.Log("2 Is released");
                //    yellowBlockRenderer.material.SetColor("_Color", Color.yellow);
                //    twoPressed = false;
                //    buttonDown = false;
                //    playerSequence[playerSequencePos] = 1;
                //    playerSequencePos++;
                //}
                //else if (SteamVR_Input.GetStateDown("B", rightHand) && threePressed)
                //{
                //    Debug.Log("3 Is released");
                //    blueBlockRenderer.material.SetColor("_Color", Color.blue);
                //    threePressed = false;
                //    buttonDown = false;
                //    playerSequence[playerSequencePos] = 2;
                //    playerSequencePos++;
                //}
                //else if (SteamVR_Input.GetStateDown("A", rightHand) && fourPressed)
                //{
                //    Debug.Log("4 Is released");
                //    greenBlockRenderer.material.SetColor("_Color", Color.green);
                //    fourPressed = false;
                //    buttonDown = false;
                //    playerSequence[playerSequencePos] = 3;
                //    playerSequencePos++;
                //}
            }
        }
    }

    //Update function which is ran every frame
    void Update()
    {
        checkColour();
    }

    //CoRoutine that displays the current sequence
    IEnumerator ColourSequence()
    {
        //for loop that displays the random colour sequence to the player
        for (int i = 0; i < currentDifficulty; i++)
        {
            if (sequence[i] == 0)
            {
                redBlockRenderer.material.SetColor("_Color", Color.red);
                blueBlockRenderer.material.SetColor("_Color", Color.red);
                yellowBlockRenderer.material.SetColor("_Color", Color.red);
                greenBlockRenderer.material.SetColor("_Color", Color.red);
                Debug.Log("Number " + (i + 1) + " in sequence is red");
                yield return new WaitForSeconds(1);
            }
            if (sequence[i] == 1)
            {
                redBlockRenderer.material.SetColor("_Color", Color.yellow);
                blueBlockRenderer.material.SetColor("_Color", Color.yellow);
                yellowBlockRenderer.material.SetColor("_Color", Color.yellow);
                greenBlockRenderer.material.SetColor("_Color", Color.yellow);
                Debug.Log("Number " + (i + 1) + " in sequence is yellow");
                yield return new WaitForSeconds(1);
            }
            if (sequence[i] == 2)
            {
                redBlockRenderer.material.SetColor("_Color", Color.blue);
                blueBlockRenderer.material.SetColor("_Color", Color.blue);
                yellowBlockRenderer.material.SetColor("_Color", Color.blue);
                greenBlockRenderer.material.SetColor("_Color", Color.blue);
                Debug.Log("Number " + (i + 1) + " in sequence is blue");
                yield return new WaitForSeconds(1);
            }
            if (sequence[i] == 3)
            {
                redBlockRenderer.material.SetColor("_Color", Color.green);
                blueBlockRenderer.material.SetColor("_Color", Color.green);
                yellowBlockRenderer.material.SetColor("_Color", Color.green);
                greenBlockRenderer.material.SetColor("_Color", Color.green);
                Debug.Log("Number " + (i + 1) + " in sequence is green");
                yield return new WaitForSeconds(1);
            }
        }
        redBlockRenderer.material.SetColor("_Color", Color.red);
        blueBlockRenderer.material.SetColor("_Color", Color.blue);
        yellowBlockRenderer.material.SetColor("_Color", Color.yellow);
        greenBlockRenderer.material.SetColor("_Color", Color.green);
        //Sets the suquence boolean to true, allowing the player to replay the boolean
        sequencePlayed = true;
    }

    IEnumerator Failure()
    {
        //for loop that displays the random colour sequence to the player
        
        redBlockRenderer.material.SetColor("_Color", Color.red);
        blueBlockRenderer.material.SetColor("_Color", Color.red);
        yellowBlockRenderer.material.SetColor("_Color", Color.red);
        greenBlockRenderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.5f);
            
        redBlockRenderer.material.SetColor("_Color", Color.white);
        blueBlockRenderer.material.SetColor("_Color", Color.white);
        yellowBlockRenderer.material.SetColor("_Color", Color.white);
        greenBlockRenderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.red);
        blueBlockRenderer.material.SetColor("_Color", Color.red);
        yellowBlockRenderer.material.SetColor("_Color", Color.red);
        greenBlockRenderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.white);
        blueBlockRenderer.material.SetColor("_Color", Color.white);
        yellowBlockRenderer.material.SetColor("_Color", Color.white);
        greenBlockRenderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.red);
        blueBlockRenderer.material.SetColor("_Color", Color.red);
        yellowBlockRenderer.material.SetColor("_Color", Color.red);
        greenBlockRenderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.white);
        blueBlockRenderer.material.SetColor("_Color", Color.white);
        yellowBlockRenderer.material.SetColor("_Color", Color.white);
        greenBlockRenderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.red);
        blueBlockRenderer.material.SetColor("_Color", Color.blue);
        yellowBlockRenderer.material.SetColor("_Color", Color.yellow);
        greenBlockRenderer.material.SetColor("_Color", Color.green);
        
    }

    IEnumerator Victory()
    {
        //for loop that displays the random colour sequence to the player

        redBlockRenderer.material.SetColor("_Color", Color.green);
        blueBlockRenderer.material.SetColor("_Color", Color.green);
        yellowBlockRenderer.material.SetColor("_Color", Color.green);
        greenBlockRenderer.material.SetColor("_Color", Color.green);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.white);
        blueBlockRenderer.material.SetColor("_Color", Color.white);
        yellowBlockRenderer.material.SetColor("_Color", Color.white);
        greenBlockRenderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.green);
        blueBlockRenderer.material.SetColor("_Color", Color.green);
        yellowBlockRenderer.material.SetColor("_Color", Color.green);
        greenBlockRenderer.material.SetColor("_Color", Color.green);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.white);
        blueBlockRenderer.material.SetColor("_Color", Color.white);
        yellowBlockRenderer.material.SetColor("_Color", Color.white);
        greenBlockRenderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.green);
        blueBlockRenderer.material.SetColor("_Color", Color.green);
        yellowBlockRenderer.material.SetColor("_Color", Color.green);
        greenBlockRenderer.material.SetColor("_Color", Color.green);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.white);
        blueBlockRenderer.material.SetColor("_Color", Color.white);
        yellowBlockRenderer.material.SetColor("_Color", Color.white);
        greenBlockRenderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        redBlockRenderer.material.SetColor("_Color", Color.red);
        blueBlockRenderer.material.SetColor("_Color", Color.blue);
        yellowBlockRenderer.material.SetColor("_Color", Color.yellow);
        greenBlockRenderer.material.SetColor("_Color", Color.green);

    }
}
