using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_PaintingPerson : MonoBehaviour
{
    public GameObject blank;
    GameObject painting;
    Personality personality;
    public W_PaintingPerson(string Name, Personality Profile)
    {
        painting = Instantiate(blank);
        painting.name = Name;
        personality = Profile;
        painting.AddComponent<W_SpeechResponse>();
        painting.AddComponent<W_PentagonGraph>();
    }
    public Personality GetPersonality()
    {
        return personality;
    }
}
