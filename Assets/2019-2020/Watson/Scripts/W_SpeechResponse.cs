using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_SpeechResponse : MonoBehaviour
{
    double[,] accumulator = new double[5, 7];
    void Start()
    {
        for (int b5 = 0; b5 < 5; b5++)
        {
            accumulator[b5, 0] = 0.0f;
            for (int f = 1; f < 7; f++)
                accumulator[b5, f] = 0.0f;
        }
    }
    public Trait ResponseSelector(Personality player)
    {
        Personality p = player;
        for (int b5 = 0; b5 < 5; b5++)
        {
            accumulator[b5, 0] += p.personality[b5].percentile;
            for (int f = 1; f < 7; f++)
                accumulator[b5, f] += p.personality[b5].children[f - 1].percentile;
        }

        int big5 = 0;
        for (int b5 = 0; b5 < 5; b5++)
        {
            if (accumulator[big5, 0] < accumulator[b5, 0])
                big5 = b5;
        }
        int facet = 1;
        for (int f = 1; f < 7; f++)
        {
            if (accumulator[big5, facet] < accumulator[big5, f])
                facet = f;
        }
        accumulator[big5, facet] = 0.0f;
        accumulator[big5, 0] = 0.0f;
        return p.personality[big5].children[facet - 1];
    }
    public string SpeechOutput(Trait facet)
    {
        string returnSpeach = "";
        //Blank
        if (facet == null)
            returnSpeach = "";

        //Openness
        if (facet.name == "Adventurousness")
            returnSpeach = "Adventure!";
        if (facet.name == "Artistic interests")
            returnSpeach = "Art!";
        if (facet.name == "Emotionality")
            returnSpeach = "Emotion!";
        if (facet.name == "Imagination")
            returnSpeach = "Imagine!";
        if (facet.name == "Intellect")
            returnSpeach = "Smart Boi";
        if (facet.name == "Authority-challenging")
            returnSpeach = "Rah Authority";

        //Conscientiousness
        if (facet.name == "Achievement striving")
            returnSpeach = "Yay Success";
        if (facet.name == "Cautiousness")
            returnSpeach = "Danger?";
        if (facet.name == "Dutifulness")
            returnSpeach = "I have job to do!";
        if (facet.name == "Orderliness")
            returnSpeach = "Orderly Fashion... Nice";
        if (facet.name == "Self-discipline")
            returnSpeach = "Inner Strength";
        if (facet.name == "Self-efficacy")
            returnSpeach = "Inner Speed";

        //Extraversion
        if (facet.name == "Activity level")
            returnSpeach = "ENERGY!";
        if (facet.name == "Assertiveness")
            returnSpeach = "My way or the highway.";
        if (facet.name == "Cheerfulness")
            returnSpeach = "Wahoo!";
        if (facet.name == "Excitement-seeking")
            returnSpeach = "the call for Excitement, it speaks to me!";
        if (facet.name == "Outgoing")
            returnSpeach = "Hey.";
        if (facet.name == "Gregariousness")
            returnSpeach = "Where's my followers?";

        //Agreeableness
        if (facet.name == "Altruism")
            returnSpeach = "I shall die for the player.";
        if (facet.name == "Cooperation")
            returnSpeach = "Now that's teamwork.";
        if (facet.name == "Modesty")
            returnSpeach = "Could always puzzled faster.";
        if (facet.name == "Uncompromising")
            returnSpeach = "I'm always right!";
        if (facet.name == "Sympathy")
            returnSpeach = "I'm sorry.";
        if (facet.name == "Trust")
            returnSpeach = "You believe what I say, right?";

        //Emotional range
        if (facet.name == "Fiery")
            returnSpeach = "AHHHHHH!";
        if (facet.name == "Prone to worry")
            returnSpeach = "Am I doing the right thing?";
        if (facet.name == "Melancholy")
            returnSpeach = "SADNESS!... It overwelms thy self...";
        if (facet.name == "Immoderation")
            returnSpeach = "I do what I want, when I want";
        if (facet.name == "Self-consciousness")
            returnSpeach = "Is my body beautiful?... Do I even have a body?";
        if (facet.name == "Susceptible to stress")
            returnSpeach = "STRESSFUL!";

        return returnSpeach;
    }
}
