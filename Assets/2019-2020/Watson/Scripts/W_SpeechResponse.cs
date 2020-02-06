using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_SpeechResponse : MonoBehaviour
{
    // Entities
    double[] Big5Accumulate = new double[5];
    double[,] FacetAccumulate = new double[5, 6];
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
    public void Big5Selector()
    {
        // Big 5 Accumulators Highest Value
        int big5 = 0;
        for (int b5 = 0; b5 < 5; b5++)
        {
            if (Big5Accumulate[big5] < Big5Accumulate[b5])
                big5 = b5;
        }
    }
    public void FacetSelector(int big5)
    {
        // Facets of a single big 5, Accumulators Highest Value
        int facet = 0;
        for (int f = 0; f < 6; f++)
        {
            if (FacetAccumulate[big5, facet] < FacetAccumulate[big5, f])
                facet = f;
        }
    }
    public void FacetSelector(Humour big5)
    {
        int b5 = 5;
        if (big5.name == "Openness")
            b5 = 0;
        if (big5.name == "Conscientiousness")
            b5 = 1;
        if (big5.name == "Extraversion")
            b5 = 2;
        if (big5.name == "Agreeableness")
            b5 = 3;
        if (big5.name == "Emotional range")
            b5 = 4;
        // Facets of a single big 5, Accumulators Highest Value
        int facet = 0;
        for (int f = 0; f < 6; f++)
        {
            if (FacetAccumulate[b5, facet] < FacetAccumulate[b5, f])
                facet = f;
        }
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
    public void PersonalitiesInteraction(Personality challenger, Personality target)
    {

    }
    public int ReturnHumourInteger(Trait facet)
    {
        int big5 = 5;
        if (facet.name == "Adventurousness" ||
            facet.name == "Artistic interests" ||
            facet.name == "Emotionality" ||
            facet.name == "Imagination" ||
            facet.name == "Intellect" ||
            facet.name == "Authority-challenging")
            big5 = 0;
        if (facet.name == "Achievement striving" ||
            facet.name == "Cautiousness" ||
            facet.name == "Dutifulness" ||
            facet.name == "Orderliness" ||
            facet.name == "Self-discipline" ||
            facet.name == "Self-efficacy")
            big5 = 1;
        if (facet.name == "Activity level" ||
            facet.name == "Assertiveness" ||
            facet.name == "Cheerfulness" ||
            facet.name == "Excitement-seeking" ||
            facet.name == "Outgoing" ||
            facet.name == "Gregariousness")
            big5 = 2;
        if (facet.name == "Altruism" ||
            facet.name == "Cooperation" ||
            facet.name == "Modesty" ||
            facet.name == "Uncompromising" ||
            facet.name == "Sympathy" ||
            facet.name == "Trust")
            big5 = 3;
        if (facet.name == "Fiery" ||
            facet.name == "Prone to worry" ||
            facet.name == "Melancholy" ||
            facet.name == "Immoderation" ||
            facet.name == "Self-consciousness" ||
            facet.name == "Susceptible to stress")
            big5 = 4;
        return big5;
    }
    public string ReturnHumourName(Trait facet)
    {
        string big5 = "";
        if (facet.name == "Adventurousness" ||
            facet.name == "Artistic interests" ||
            facet.name == "Emotionality" ||
            facet.name == "Imagination" ||
            facet.name == "Intellect" ||
            facet.name == "Authority-challenging")
            big5 = "Openness";
        if (facet.name == "Achievement striving" ||
            facet.name == "Cautiousness" ||
            facet.name == "Dutifulness" ||
            facet.name == "Orderliness" ||
            facet.name == "Self-discipline" ||
            facet.name == "Self-efficacy")
            big5 = "Conscientiousness";
        if (facet.name == "Activity level" ||
            facet.name == "Assertiveness" ||
            facet.name == "Cheerfulness" ||
            facet.name == "Excitement-seeking" ||
            facet.name == "Outgoing" ||
            facet.name == "Gregariousness")
            big5 = "Extraversion";
        if (facet.name == "Altruism" ||
            facet.name == "Cooperation" ||
            facet.name == "Modesty" ||
            facet.name == "Uncompromising" ||
            facet.name == "Sympathy" ||
            facet.name == "Trust")
            big5 = "Agreeableness";
        if (facet.name == "Fiery" ||
            facet.name == "Prone to worry" ||
            facet.name == "Melancholy" ||
            facet.name == "Immoderation" ||
            facet.name == "Self-consciousness" ||
            facet.name == "Susceptible to stress")
            big5 = "Emotional range";
        return big5;
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

}
        
    

    
