using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    W_PaintingPerson painting;
    W_PaintingPerson player;
    void Start()
    {
        player = GameObject.Find("player").GetComponent<W_PaintingPerson>(); // Not set to actual player
        painting = this.gameObject.GetComponent<W_PaintingPerson>();
    }
    // string or string array
    public string Type1Success;
    public string Type1Failure;
    public string Type2;
    public string Type3Success;
    public string Type3Failure;
    public string Type4;
    public string Type5Success;
    public string Type5Failure;

    // Type 1
    public void WhoAreYou()
    {
        if (BroadPersonalTest())
            Debug.Log(Type1Success);
        else Debug.Log(Type1Failure);
    }
    // Type 2
    public void PuzzleDescription()
    {
        Debug.Log(Type2);
    }
    // Type 3
    public void Hint()
    {
        if (BroadPersonalTest())
            Debug.Log(Type3Success);
        else Debug.Log(Type3Failure);
    }
    // Type 4
    public void AboutHouse()
    {
        Debug.Log(Type4);
    }
    // Type 5
    public void Goodbye()
    {
        if (BroadPersonalTest())
            Debug.Log(Type5Success);
        else Debug.Log(Type5Failure);
    }

    public bool BroadPersonalTest()
    {
        int testParameter = player.Big5Selector();
        // player
        if (player.GetPersonality().personality[testParameter].percentile > painting.GetPersonality().personality[testParameter].percentile)
        {
            return true;
        }
        // painting
        if (player.GetPersonality().personality[testParameter].percentile < painting.GetPersonality().personality[testParameter].percentile)
        {
            return false;
        }
        return false;
    }
    public void NarrowPersonalTest(int BIG5)
    {
        
        int testParameter = player.FacetSelector(BIG5);
        // player
        if (player.GetPersonality().personality[BIG5].children[testParameter].percentile > painting.GetPersonality().personality[BIG5].children[testParameter].percentile)
        {

        }
        // painting
        if (player.GetPersonality().personality[BIG5].children[testParameter].percentile < painting.GetPersonality().personality[BIG5].children[testParameter].percentile)
        {

        }
    }
}
