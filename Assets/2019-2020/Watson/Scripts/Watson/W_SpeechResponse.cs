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
}
        
    

    
