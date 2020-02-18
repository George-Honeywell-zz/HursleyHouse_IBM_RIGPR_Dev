using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_SpeechResponse : MonoBehaviour
{
    string[] Blank = { "" };

    // Big5
    string[] Openness = { "" }; // 0
    string[] Conscientiousness = { "" }; // 1
    string[] Extraversion = { "" }; // 2
    string[] Agreeableness = { "" }; // 3
    string[] EmotionalRange = { "" }; // 4

    // Openness
    string[] Adventurousness = { "" };
    string[] ArtisticInerests = { "" };
    string[] Emotionality = { "" };
    string[] Imagination = { "" };
    string[] Intellect = { "" };
    string[] AuthorityChallenging = { "" };

    // Conscientiousness
    string[] AchievementStriving = { "" };
    string[] Cautiousness = { "" };
    string[] Dutifulness = { "" };
    string[] Orderliness = { "" };
    string[] SelfDiscipline = { "" };
    string[] SelfEfficacy = { "" };

    // Extraversion
    string[] ActivityLevel = { "" };
    string[] Assertiveness = { "" };
    string[] Cheerfulness = { "" };
    string[] ExcitementSeeking = { "" };
    string[] Outgoing = { "" };
    string[] Gregariousness = { "" };

    // Agreeableness
    string[] Altruism = { "" };
    string[] Cooperation = { "" };
    string[] Modesty = { "" };
    string[] Uncompromising = { "" };
    string[] Sympathy = { "" };
    string[] Trust = { "" };

    // Emotional Range
    string[] Fiery = { "" };
    string[] ProneToWorry = { "" };
    string[] Melancholy = { "" };
    string[] Immoderation = { "" };
    string[] SelfConsciousness = { "" };
    string[] SusceptibleToStress = { "" };

    public string[] GetSpeechArray(int Big5)
    {
        switch (Big5)
        {
            case 0:
                return Openness;
            case 1:
                return Conscientiousness;
            case 2:
                return Extraversion;
            case 3:
                return Agreeableness;
            case 4:
                return EmotionalRange;
            default:
                return Blank;
        }
    }
    public string[] GetSpeechArray(int Big5, int Facet)
    {
        if (Big5 == 0)
        {
            switch (Facet)
            {
                case 0:
                    return Adventurousness;
                case 1:
                    return ArtisticInerests;
                case 2:
                    return Emotionality;
                case 3:
                    return Imagination;
                case 4:
                    return Intellect;
                case 5:
                    return AuthorityChallenging;
                default:
                    return Blank;
            }
        }
        else if (Big5 == 1)
        {
            switch (Facet)
            {
                case 0:
                    return AchievementStriving;
                case 1:
                    return Cautiousness;
                case 2:
                    return Dutifulness;
                case 3:
                    return Orderliness;
                case 4:
                    return SelfDiscipline;
                case 5:
                    return SelfEfficacy;
                default:
                    return Blank;
            }
        }
        else if (Big5 == 2)
        {
            switch (Facet)
            {
                case 0:
                    return ActivityLevel;
                case 1:
                    return Assertiveness;
                case 2:
                    return Cheerfulness;
                case 3:
                    return ExcitementSeeking;
                case 4:
                    return Outgoing;
                case 5:
                    return Gregariousness;
                default:
                    return Blank;
            }
        }
        else if (Big5 == 3)
        {
            switch (Facet)
            {
                case 0:
                    return Altruism;
                case 1:
                    return Cooperation;
                case 2:
                    return Modesty;
                case 3:
                    return Uncompromising;
                case 4:
                    return Sympathy;
                case 5:
                    return Trust;
                default:
                    return Blank;
            }
        }
        else if (Big5 == 4)
        {
            switch (Facet)
            {
                case 0:
                    return Fiery;
                case 1:
                    return ProneToWorry;
                case 2:
                    return Melancholy;
                case 3:
                    return Immoderation;
                case 4:
                    return SelfConsciousness;
                case 5:
                    return SusceptibleToStress;
                default:
                    return Blank;
            }
        }
        else
            return Blank;
    }
    public string RandomSelect(string[] Phrases)
    {
        return Phrases[Random.Range(0, Phrases.Length)];
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
        
    

    
