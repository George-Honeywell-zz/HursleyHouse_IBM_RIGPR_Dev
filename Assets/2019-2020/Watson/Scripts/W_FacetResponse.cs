using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(W_SetupAnalyser))]
public class W_FacetResponse : MonoBehaviour
{
    W_SetupAnalyser WSA;
    double[,] data = new double[5,7];
    public bool IsTalking = false;
    public string Text = "";
    void Start()
    {
        WSA = gameObject.GetComponent<W_SetupAnalyser>();
        for (int b5 = 0; b5 < 5; b5++)
        {
            data[b5, 0] = 0.0f;
            for (int f = 1; f < 7; f++)
                data[b5, f] = 0.0f;
        }
    }
    public FACET ResponseType()
    {
        for (int b5 = 0; b5 < 5; b5++)
        {
            data[b5, 0] += WSA.pp.bigfive[b5].children[0].percentile;
            for (int f = 1; f < 7; f++)
                data[b5, f] += WSA.pp.bigfive[b5].children[f].percentile;
        }

        int big5 = 0;
        for (int b5 = 0; b5 < 5; b5++)
        {
            if (data[big5, 0] < data[b5, 0])
                big5 = b5;
        }
        int facet = 1;
        for (int f = 1; f < 7; f++)
        {
            if (data[big5, facet] < data[big5, f])
                facet = f;
        }
        data[big5, facet] = 0.0f;
        data[big5, 0] = 0.0f;
        return WSA.pp.bigfive[big5].children[facet];
    }

    public string ResponseOutput(FACET facet)
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
