using UnityEngine;
public class W_PaintingPerson : MonoBehaviour
{
    Personality personality;
    public void SetPersonality(Personality Profile)
    {
        personality = Profile;
    }
    public Personality GetPersonality()
    {
        return personality;
    }
}
