using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_SpeechResponse : MonoBehaviour
{
    // Entities
    double[] Big5Accumulate = new double[5];
    double[,] FacetAccumulate = new double[5, 6];
    public double GetBigAccumulate(int big5)
    {
        return Big5Accumulate[big5];
    }
    void Start()
    {
        // Set Accumulators to Zero
        for (int b5 = 0; b5 < 5; b5++)
        {
            Big5Accumulate[b5] = 0.0f;
            for (int f = 0; f < 6; f++)
                FacetAccumulate[b5, f] = 0.0f;
        }
    }
    public void ResponseSelector(Personality player)
    {
        Personality p = player;
        // Accumulate percentiles
        for (int b5 = 0; b5 < 5; b5++)
        {
            Big5Accumulate[b5] += p.personality[b5].percentile;
            for (int f = 0; f < 6; f++)
                FacetAccumulate[b5, f] += p.personality[b5].children[f].percentile;
        }
    }
    public int Big5Selector()
    {
        // Big 5 Accumulators Highest Value
        int big5 = 0;
        for (int b5 = 1; b5 < 5; b5++)
        {
            if (Big5Accumulate[big5] < Big5Accumulate[b5])
                big5 = b5;
        }
        return big5;
    }
    public int FacetSelector(int big5)
    {
        // Facets of a single big 5, Accumulators Highest Value
        int facet = 0;
        for (int f = 1; f < 6; f++)
        {
            if (FacetAccumulate[big5, facet] < FacetAccumulate[big5, f])
                facet = f;
        }
        return facet;
    }
    public void ClearAllAccumulators()
    {
        // Set Accumulators to Zero
        for (int b5 = 0; b5 < 5; b5++)
        {
            Big5Accumulate[b5] = 0.0f;
            for (int f = 0; f < 6; f++)
                FacetAccumulate[b5, f] = 0.0f;
        }
    }
    public string PersonalityChallenge(Personality player, W_SpeechResponse target)
    {
        ResponseSelector(player);
        int big5 = Big5Selector();
        int facet;
        // Dialogue
        if (Big5Accumulate[big5] > target.GetBigAccumulate(big5))
        {
            facet = FacetSelector(big5);
            Big5Accumulate[big5] = 0.0f;
            FacetAccumulate[big5, facet] = 0.0f;
            return SpeechOutput(big5, facet);
        } 
        // Debate
        //if (Big5Accumulate[big5] <= target.GetBigAccumulate(big5))
        return "No!";
    }
    public string PersonalityOutburst(Personality player)
    {
        ResponseSelector(player);
        int big5 = Big5Selector();
        int facet = FacetSelector(big5);
        Big5Accumulate[big5] = 0.0f;
        FacetAccumulate[big5, facet] = 0.0f;
        return SpeechOutput(big5, facet);
    }
    public string SpeechOutput(Trait facet)
    {
        string returnSpeech = "";
        //Blank
        if (facet == null)
            returnSpeech = "";

        //Openness
        if (facet.name == "Adventurousness")
            returnSpeech = "Adventure!";
        if (facet.name == "Artistic interests")
            returnSpeech = "Art!";
        if (facet.name == "Emotionality")
            returnSpeech = "Emotion!";
        if (facet.name == "Imagination")
            returnSpeech = "Imagine!";
        if (facet.name == "Intellect")
            returnSpeech = "Smart Boi";
        if (facet.name == "Authority-challenging")
            returnSpeech = "Rah Authority";

        //Conscientiousness
        if (facet.name == "Achievement striving")
            returnSpeech = "Yay Success";
        if (facet.name == "Cautiousness")
            returnSpeech = "Danger?";
        if (facet.name == "Dutifulness")
            returnSpeech = "I have job to do!";
        if (facet.name == "Orderliness")
            returnSpeech = "Orderly Fashion... Nice";
        if (facet.name == "Self-discipline")
            returnSpeech = "Inner Strength";
        if (facet.name == "Self-efficacy")
            returnSpeech = "Inner Speed";

        //Extraversion
        if (facet.name == "Activity level")
            returnSpeech = "ENERGY!";
        if (facet.name == "Assertiveness")
            returnSpeech = "My way or the highway.";
        if (facet.name == "Cheerfulness")
            returnSpeech = "Wahoo!";
        if (facet.name == "Excitement-seeking")
            returnSpeech = "the call for Excitement, it speaks to me!";
        if (facet.name == "Outgoing")
            returnSpeech = "Hey.";
        if (facet.name == "Gregariousness")
            returnSpeech = "Where's my followers?";

        //Agreeableness
        if (facet.name == "Altruism")
            returnSpeech = "I shall die for the player.";
        if (facet.name == "Cooperation")
            returnSpeech = "Now that's teamwork.";
        if (facet.name == "Modesty")
            returnSpeech = "Could always puzzled faster.";
        if (facet.name == "Uncompromising")
            returnSpeech = "I'm always right!";
        if (facet.name == "Sympathy")
            returnSpeech = "I'm sorry.";
        if (facet.name == "Trust")
            returnSpeech = "You believe what I say, right?";

        //Emotional range
        if (facet.name == "Fiery")
            returnSpeech = "AHHHHHH!";
        if (facet.name == "Prone to worry")
            returnSpeech = "Am I doing the right thing?";
        if (facet.name == "Melancholy")
            returnSpeech = "SADNESS!... It overwelms thy self...";
        if (facet.name == "Immoderation")
            returnSpeech = "I do what I want, when I want";
        if (facet.name == "Self-consciousness")
            returnSpeech = "Is my body beautiful?... Do I even have a body?";
        if (facet.name == "Susceptible to stress")
            returnSpeech = "STRESSFUL!";

        return returnSpeech;
    }
    public string SpeechOutput(int big5, int facet)
    {
        string returnSpeech = "";
        //Openness
        if (big5 == 0)
        {
            if (facet == 0)
                returnSpeech = "Adventure!";
            if (facet == 1)
                returnSpeech = "Art!";
            if (facet == 2)
                returnSpeech = "Emotion!";
            if (facet == 3)
                returnSpeech = "Imagine!";
            if (facet == 4)
                returnSpeech = "Smart Boi";
            if (facet == 5)
                returnSpeech = "Rah Authority";
        }
        

        //Conscientiousness
        if (big5 == 1)
        {
            if (facet == 0)
                returnSpeech = "Yay Success";
            if (facet == 1)
                returnSpeech = "Danger?";
            if (facet == 2)
                returnSpeech = "I have job to do!";
            if (facet == 3)
                returnSpeech = "Orderly Fashion... Nice";
            if (facet == 4)
                returnSpeech = "Inner Strength";
            if (facet == 5)
                returnSpeech = "Inner Speed";
        }

        //Extraversion
        if (big5 == 2)
        {
            if (facet == 0)
                returnSpeech = "ENERGY!";
            if (facet == 1)
                returnSpeech = "My way or the highway.";
            if (facet == 2)
                returnSpeech = "Wahoo!";
            if (facet == 3)
                returnSpeech = "the call for Excitement, it speaks to me!";
            if (facet == 4)
                returnSpeech = "Hey.";
            if (facet == 5)
                returnSpeech = "Where's my followers?";
        }

        //Agreeableness
        if (big5 == 3)
        {
            if (facet == 0)
                returnSpeech = "I shall die for the player.";
            if (facet == 1)
                returnSpeech = "Now that's teamwork.";
            if (facet == 2)
                returnSpeech = "Could always puzzled faster.";
            if (facet == 3)
                returnSpeech = "I'm always right!";
            if (facet == 4)
                returnSpeech = "I'm sorry.";
            if (facet == 5)
                returnSpeech = "You believe what I say, right?";
        }

        //Emotional range
        if (big5 == 4)
        {
            if (facet == 0)
                returnSpeech = "AHHHHHH!";
            if (facet == 1)
                returnSpeech = "Am I doing the right thing?";
            if (facet == 2)
                returnSpeech = "SADNESS!... It overwelms thy self...";
            if (facet == 3)
                returnSpeech = "I do what I want, when I want";
            if (facet == 4)
                returnSpeech = "Is my body beautiful?... Do I even have a body?";
            if (facet == 5)
                returnSpeech = "STRESSFUL!";
        }

        return returnSpeech;
    }
}
        
    

    
