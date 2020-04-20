using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ColourGeneration : MonoBehaviour
{
    //Set Arrays for SEQUENCE & PLAYER_SEQUENCE
    int[] sequence;
    int[] playerSequence;
    int playerSequencePosition = 0;

    //Setting this number will determine how many colours are in a sequence.
    int currentDifficulty = 3;
    bool sequencePlayed = true;

    //Button Presses
    bool onePressed = false;
    bool twoPressed = false;
    bool threePressed = false;
    bool fourPressed = false;
    bool buttonDown = false;

    //Player Marked or Passed
    bool playerMarked = false;
    bool playerPassed = true;

    //Public GameObjects
    public GameObject redBlock;
    public GameObject blueBlock;
    public GameObject yellowBlock;
    public GameObject greenBlock;
    

    //Block Renderers
    Renderer redBlockRenderer;
    Renderer blueBlockRenderer;
    Renderer yellowBlockRenderer;
    Renderer greenBlockRenderer;
    Renderer sequenceBlockRenderer;


    void Start()
    {
        //Getting the components from the scene
        redBlockRenderer = redBlock.GetComponent<Renderer>();
        yellowBlockRenderer = yellowBlock.GetComponent<Renderer>();
        blueBlockRenderer = blueBlock.GetComponent<Renderer>();
        greenBlockRenderer = greenBlock.GetComponent<Renderer>();

        //Creating the Sequence Arrays
        sequence = new int[10];
        playerSequence = new int[10];

        //Assigning the sequence array values corresponding to the random colour order
        for (int i = 0; i < 10; i++)
        {
            sequence[i] = Random.Range(0, 4);
        }
    }

    void Update()
    {
        PlayerInputSequence();
        CheckButtonsPressed(0);
        CheckButtonsReleased(0);
    }



    public void PlayerInputSequence()
    {

        if (playerSequencePosition == (currentDifficulty) && !playerMarked)
        {
            for(int i = 0; i < currentDifficulty; i++)
            {
                if(playerSequence[i] == sequence[i])
                {
                    Debug.Log("<color=green>Sequence Successfully Completed!</color>");
                    SteamVR_LoadLevel.Begin("Outdoor_Area");
                }
                else
                {
                    Debug.Log("<color=red>Sequence Unsuccessfully Completed!</color>");
                    playerPassed = false;
                }
            }

            playerMarked = true;

            if (playerPassed)
            {
                StartCoroutine(Victory());
            }
            else
            {
                StartCoroutine(Failure());
            }
        }

        else if (playerMarked)
        {
            if (playerPassed)
            {
                playerMarked = false;
                currentDifficulty++;
                playerSequence = new int[10];
                playerSequencePosition = 0;
                playerPassed = true;
            }
            else
            {
                playerMarked = false;
                playerSequence = new int[10];
                playerSequencePosition = 0;
                playerPassed = true;
            }
        }
    }

    public void CheckButtonsPressed(int buttonID)
    {
        if (buttonID == 5)
        {
            StartCoroutine(ColourSequence());
            sequencePlayed = false;
        }

        if (buttonID == 1)
        {
            Debug.Log("1 Is PRESSED");
            redBlockRenderer.material.SetColor("_Color", Color.white);
            onePressed = true;
            buttonDown = true;
            CheckButtonsReleased(1);
        }

        else if (buttonID == 2)
        {
            Debug.Log("2 Is PRESSED");
            yellowBlockRenderer.material.SetColor("_Color", Color.white);
            twoPressed = true;
            buttonDown = true;
            CheckButtonsReleased(2);
        }

        else if (buttonID == 3)
        {
            Debug.Log("3 Is PRESSED");
            blueBlockRenderer.material.SetColor("_Color", Color.white);
            threePressed = true;
            buttonDown = true;
            CheckButtonsReleased(3);
        }

        else if (buttonID == 4)
        {
            Debug.Log("4 Is PRESSED");
            greenBlockRenderer.material.SetColor("_Color", Color.white);
            fourPressed = true;
            buttonDown = true;
            CheckButtonsReleased(4);
        }
    }

    public void CheckButtonsReleased(int buttonID)
    {

        if (buttonID == 1 && onePressed)
        {
            Debug.Log("1 Is RELEASED");
            redBlockRenderer.material.SetColor("_Color", Color.red);
            onePressed = false;
            buttonDown = false;
            playerSequence[playerSequencePosition] = 0;
            playerSequencePosition++;
        }

        else if (buttonID == 2 && twoPressed)
        {
            Debug.Log("2 is RELEASED");
            yellowBlockRenderer.material.SetColor("_Color", Color.yellow);
            twoPressed = false;
            buttonDown = false;
            playerSequence[playerSequencePosition] = 1;
            playerSequencePosition++;
        }
        else if (buttonID == 3 && threePressed)
        {
            Debug.Log("3 is RELEASED");
            blueBlockRenderer.material.SetColor("_Color", Color.blue);
            threePressed = false;
            buttonDown = false;
            playerSequence[playerSequencePosition] = 2;
            playerSequencePosition++;
        }
        else if (buttonID == 4 && fourPressed)
        {
            Debug.Log("4 is RELEASED");
            greenBlockRenderer.material.SetColor("_Color", Color.green);
            fourPressed = false;
            buttonDown = false;
            playerSequence[playerSequencePosition] = 3;
            playerSequencePosition++;
        }
    }

    IEnumerator ColourSequence()
    {
        for(int i = 0; i < currentDifficulty; i++)
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
