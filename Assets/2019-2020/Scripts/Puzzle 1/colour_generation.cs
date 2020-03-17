using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class colour_generation : MonoBehaviour
{
    SceneController scene;

    //Teleport Variables
    public GameObject teleportPoint_Unlocked;
    public GameObject teleportPoint_Locked;
    public GameObject sceneChanger;


    //Set Arrays for SEQUENCE & PLAYER_SEQUENCE
    int[] sequence;
    int[] player_sequence;
    int player_sequence_position = 0;

    //Setting this number will determine how many colours are in a sequence.
    int current_difficulty = 3;
    bool sequence_played = true;

    //Button Presses
    bool one_pressed = false;
    bool two_pressed = false;
    bool three_pressed = false;
    bool four_pressed = false;
    bool button_down = false;

    //Player Marked or Passed
    bool player_marked = false;
    bool player_passed = true;

    //Public GameObjects
    public GameObject red_block;
    public GameObject blue_block;
    public GameObject yellow_block;
    public GameObject green_block;
    

    //Block Renderers
    Renderer red_block_renderer;
    Renderer blue_block_renderer;
    Renderer yellow_block_renderer;
    Renderer green_block_renderer;
    Renderer sequence_block_renderer;

    //SteamVR Input Variables
    SteamVR_Input_Sources left_hand;
    SteamVR_Input_Sources right_hand;

    void Start()
    {
        //Getting the components from the scene
        red_block_renderer = red_block.GetComponent<Renderer>();
        yellow_block_renderer = yellow_block.GetComponent<Renderer>();
        blue_block_renderer = blue_block.GetComponent<Renderer>();
        green_block_renderer = green_block.GetComponent<Renderer>();

        //Creating the Sequence Arrays
        sequence = new int[10];
        player_sequence = new int[10];

        //Assigning the sequence array values corresponding to the random colour order
        for (int i = 0; i < 10; i++)
        {
            sequence[i] = Random.Range(0, 4);
        }
    }

    void Update()
    {
        player_input_sequence();
        check_buttons_pressed(0);
        check_buttons_released(0);

        //if (sequence_played && Input.GetKeyDown(KeyCode.O))
        if(sequence_played && SteamVR_Input.GetStateDown("LeftTrigger", left_hand) || Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(colour_sequence());
            sequence_played = false;
        }
    }



    public void player_input_sequence()
    {

        if (player_sequence_position == (current_difficulty) && !player_marked)
        {
            for(int i = 0; i < current_difficulty; i++)
            {
                if(player_sequence[i] == sequence[i])
                {
                    Debug.Log("<color=green>Sequence Successfully Completed!</color>");
                    SteamVR_LoadLevel.Begin("Outdoor_Area");
                    //teleportPoint_Locked.SetActive(false);
                    //teleportPoint_Unlocked.SetActive(true);
                    //sceneChanger.SetActive(true);
                }
                else
                {
                    Debug.Log("<color=red>Sequence Unsuccessfully Completed!</color>");
                    player_passed = false;
                }
            }

            player_marked = true;

            if (player_passed)
            {
                StartCoroutine(Victory());
            }
            else
            {
                StartCoroutine(Failure());
            }
        }

        else if (player_marked)
        {
            if (player_passed)
            {
                player_marked = false;
                current_difficulty++;
                player_sequence = new int[10];
                player_sequence_position = 0;
                player_passed = true;
            }
            else
            {
                player_marked = false;
                player_sequence = new int[10];
                player_sequence_position = 0;
                player_passed = true;
            }
        }
    }

    public void check_buttons_pressed(int button_id)
    {
        if (button_id == 1)
        {
            Debug.Log("1 Is PRESSED");
            red_block_renderer.material.SetColor("_Color", Color.white);
            one_pressed = true;
            button_down = true;
            check_buttons_released(1);
        }

        else if (button_id == 2)
        {
            Debug.Log("2 Is PRESSED");
            yellow_block_renderer.material.SetColor("_Color", Color.white);
            two_pressed = true;
            button_down = true;
            check_buttons_released(2);
        }

        else if (button_id == 3)
        {
            Debug.Log("3 Is PRESSED");
            blue_block_renderer.material.SetColor("_Color", Color.white);
            three_pressed = true;
            button_down = true;
            check_buttons_released(3);
        }

        else if (button_id == 4)
        {
            Debug.Log("4 Is PRESSED");
            green_block_renderer.material.SetColor("_Color", Color.white);
            four_pressed = true;
            button_down = true;
            check_buttons_released(4);
        }
    }

    public void check_buttons_released(int button_id)
    {

        if (button_id == 1 && one_pressed)
        {
            Debug.Log("1 Is RELEASED");
            red_block_renderer.material.SetColor("_Color", Color.red);
            one_pressed = false;
            button_down = false;
            player_sequence[player_sequence_position] = 0;
            player_sequence_position++;
        }

        else if (button_id == 2 && two_pressed)
        {
            Debug.Log("2 is RELEASED");
            yellow_block_renderer.material.SetColor("_Color", Color.yellow);
            two_pressed = false;
            button_down = false;
            player_sequence[player_sequence_position] = 1;
            player_sequence_position++;
        }
        else if (button_id == 3 && three_pressed)
        {
            Debug.Log("3 is RELEASED");
            blue_block_renderer.material.SetColor("_Color", Color.blue);
            three_pressed = false;
            button_down = false;
            player_sequence[player_sequence_position] = 2;
            player_sequence_position++;
        }
        else if (button_id == 4 && four_pressed)
        {
            Debug.Log("4 is RELEASED");
            green_block_renderer.material.SetColor("_Color", Color.green);
            four_pressed = false;
            button_down = false;
            player_sequence[player_sequence_position] = 3;
            player_sequence_position++;
        }
    }

    IEnumerator colour_sequence()
    {
        for(int i = 0; i < current_difficulty; i++)
        {
            if (sequence[i] == 0)
            {
                red_block_renderer.material.SetColor("_Color", Color.red);
                blue_block_renderer.material.SetColor("_Color", Color.red);
                yellow_block_renderer.material.SetColor("_Color", Color.red);
                green_block_renderer.material.SetColor("_Color", Color.red);
                Debug.Log("Number " + (i + 1) + " in sequence is red");
                yield return new WaitForSeconds(1);
            }
            if (sequence[i] == 1)
            {
                red_block_renderer.material.SetColor("_Color", Color.yellow);
                blue_block_renderer.material.SetColor("_Color", Color.yellow);
                yellow_block_renderer.material.SetColor("_Color", Color.yellow);
                green_block_renderer.material.SetColor("_Color", Color.yellow);
                Debug.Log("Number " + (i + 1) + " in sequence is yellow");
                yield return new WaitForSeconds(1);
            }
            if (sequence[i] == 2)
            {
                red_block_renderer.material.SetColor("_Color", Color.blue);
                blue_block_renderer.material.SetColor("_Color", Color.blue);
                yellow_block_renderer.material.SetColor("_Color", Color.blue);
                green_block_renderer.material.SetColor("_Color", Color.blue);
                Debug.Log("Number " + (i + 1) + " in sequence is blue");
                yield return new WaitForSeconds(1);
            }
            if (sequence[i] == 3)
            {
                red_block_renderer.material.SetColor("_Color", Color.green);
                blue_block_renderer.material.SetColor("_Color", Color.green);
                yellow_block_renderer.material.SetColor("_Color", Color.green);
                green_block_renderer.material.SetColor("_Color", Color.green);
                Debug.Log("Number " + (i + 1) + " in sequence is green");
                yield return new WaitForSeconds(1);
            }
        }
        red_block_renderer.material.SetColor("_Color", Color.red);
        blue_block_renderer.material.SetColor("_Color", Color.blue);
        yellow_block_renderer.material.SetColor("_Color", Color.yellow);
        green_block_renderer.material.SetColor("_Color", Color.green);
        //Sets the suquence boolean to true, allowing the player to replay the boolean
        sequence_played = true;
    }

    IEnumerator Failure()
    {
        //for loop that displays the random colour sequence to the player

        red_block_renderer.material.SetColor("_Color", Color.red);
        blue_block_renderer.material.SetColor("_Color", Color.red);
        yellow_block_renderer.material.SetColor("_Color", Color.red);
        green_block_renderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.white);
        blue_block_renderer.material.SetColor("_Color", Color.white);
        yellow_block_renderer.material.SetColor("_Color", Color.white);
        green_block_renderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.red);
        blue_block_renderer.material.SetColor("_Color", Color.red);
        yellow_block_renderer.material.SetColor("_Color", Color.red);
        green_block_renderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.white);
        blue_block_renderer.material.SetColor("_Color", Color.white);
        yellow_block_renderer.material.SetColor("_Color", Color.white);
        green_block_renderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.red);
        blue_block_renderer.material.SetColor("_Color", Color.red);
        yellow_block_renderer.material.SetColor("_Color", Color.red);
        green_block_renderer.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.white);
        blue_block_renderer.material.SetColor("_Color", Color.white);
        yellow_block_renderer.material.SetColor("_Color", Color.white);
        green_block_renderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.red);
        blue_block_renderer.material.SetColor("_Color", Color.blue);
        yellow_block_renderer.material.SetColor("_Color", Color.yellow);
        green_block_renderer.material.SetColor("_Color", Color.green);

    }

    IEnumerator Victory()
    {
        //for loop that displays the random colour sequence to the player

        red_block_renderer.material.SetColor("_Color", Color.green);
        blue_block_renderer.material.SetColor("_Color", Color.green);
        yellow_block_renderer.material.SetColor("_Color", Color.green);
        green_block_renderer.material.SetColor("_Color", Color.green);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.white);
        blue_block_renderer.material.SetColor("_Color", Color.white);
        yellow_block_renderer.material.SetColor("_Color", Color.white);
        green_block_renderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.green);
        blue_block_renderer.material.SetColor("_Color", Color.green);
        yellow_block_renderer.material.SetColor("_Color", Color.green);
        green_block_renderer.material.SetColor("_Color", Color.green);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.white);
        blue_block_renderer.material.SetColor("_Color", Color.white);
        yellow_block_renderer.material.SetColor("_Color", Color.white);
        green_block_renderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.green);
        blue_block_renderer.material.SetColor("_Color", Color.green);
        yellow_block_renderer.material.SetColor("_Color", Color.green);
        green_block_renderer.material.SetColor("_Color", Color.green);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.white);
        blue_block_renderer.material.SetColor("_Color", Color.white);
        yellow_block_renderer.material.SetColor("_Color", Color.white);
        green_block_renderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.5f);

        red_block_renderer.material.SetColor("_Color", Color.red);
        blue_block_renderer.material.SetColor("_Color", Color.blue);
        yellow_block_renderer.material.SetColor("_Color", Color.yellow);
        green_block_renderer.material.SetColor("_Color", Color.green);

    }
}
