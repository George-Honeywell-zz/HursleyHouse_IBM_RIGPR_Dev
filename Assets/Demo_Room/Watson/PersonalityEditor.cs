using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(W_PaintingPerson))]
public class PersonalityEditor : MonoBehaviour
{
    public string PaintingName;
    public float BIG5_Openness;
    public float Adventurousness;
    public float ArtisticInterests;
    public float Emotionality;
    public float Imagination;
    public float Intellect;
    public float AuthorityChallenging;

    public float BIG5_Conscientiousness;
    public float AchievementStriving;
    public float Cautiousness;
    public float Dutifulness;
    public float Orderliness;
    public float SelfDiscipline;
    public float SelfEfficacy;

    public float BIG5_Extraversion;
    public float ActivityLevel;
    public float Assertiveness;
    public float Cheerfulness;
    public float ExcitementSeeking;
    public float Outgoing;
    public float Gregariousness;

    public float BIG5_EmotionalRange;
    public float Anger;
    public float Anxiety;
    public float Melancholy;
    public float Immoderation;
    public float SelfConsciousness;
    public float Vulnerability;

    public float BIG5_Agreeableness;
    public float Altruism;
    public float Cooperation;
    public float Modesty;
    public float Uncompromising;
    public float Sympathy;
    public float Trust;

    Personality consciousness;
    W_PaintingPerson painting;
    void Start()
    {
        //
        consciousness.personality[0].name = "Openness";
        consciousness.personality[0].percentile = BIG5_Openness;
        //
        consciousness.personality[0].children[0].name = "Adventurousness";
        consciousness.personality[0].children[0].percentile = Adventurousness;
        consciousness.personality[0].children[1].name = "Artistic interests";
        consciousness.personality[0].children[1].percentile = ArtisticInterests;
        consciousness.personality[0].children[2].name = "Emotionality";
        consciousness.personality[0].children[2].percentile = Emotionality;
        consciousness.personality[0].children[3].name = "Imagination";
        consciousness.personality[0].children[3].percentile = Imagination;
        consciousness.personality[0].children[4].name = "Intellect";
        consciousness.personality[0].children[4].percentile = Intellect;
        consciousness.personality[0].children[5].name = "Authority-challenging";
        consciousness.personality[0].children[5].percentile = AuthorityChallenging;
        //
        //
        consciousness.personality[1].name = "Conscientiousness";
        consciousness.personality[1].percentile = BIG5_Conscientiousness;
        //
        consciousness.personality[1].children[0].name = "Achievement striving";
        consciousness.personality[1].children[0].percentile = AchievementStriving;
        consciousness.personality[1].children[1].name = "Cautiousness";
        consciousness.personality[1].children[1].percentile = Cautiousness;
        consciousness.personality[1].children[2].name = "Dutifulness";
        consciousness.personality[1].children[2].percentile = Dutifulness;
        consciousness.personality[1].children[3].name = "Orderliness";
        consciousness.personality[1].children[3].percentile = Orderliness;
        consciousness.personality[1].children[4].name = "Self-discipline";
        consciousness.personality[1].children[4].percentile = SelfDiscipline;
        consciousness.personality[1].children[5].name = "Self-efficacy";
        consciousness.personality[1].children[5].percentile = SelfEfficacy;
        //
        //
        consciousness.personality[2].name = "Extraversion";
        consciousness.personality[2].percentile = BIG5_Extraversion;
        //
        consciousness.personality[2].children[0].name = "Activity level";
        consciousness.personality[2].children[0].percentile = ActivityLevel;
        consciousness.personality[2].children[1].name = "Assertiveness";
        consciousness.personality[2].children[1].percentile = Assertiveness;
        consciousness.personality[2].children[2].name = "Cheerfulness";
        consciousness.personality[2].children[2].percentile = Cheerfulness;
        consciousness.personality[2].children[3].name = "Excitement-seeking";
        consciousness.personality[2].children[3].percentile = ExcitementSeeking;
        consciousness.personality[2].children[4].name = "Outgoing";
        consciousness.personality[2].children[4].percentile = Outgoing;
        consciousness.personality[2].children[5].name = "Gregariousness";
        consciousness.personality[2].children[5].percentile = Gregariousness;
        //
        //
        consciousness.personality[3].name = "Agreeableness";
        consciousness.personality[3].percentile = BIG5_Agreeableness;
        //
        consciousness.personality[3].children[0].name = "Altruism";
        consciousness.personality[3].children[0].percentile = Altruism;
        consciousness.personality[3].children[1].name = "Cooperation";
        consciousness.personality[3].children[1].percentile = Cooperation;
        consciousness.personality[3].children[2].name = "Modesty";
        consciousness.personality[3].children[2].percentile = Modesty;
        consciousness.personality[3].children[3].name = "Uncompromising";
        consciousness.personality[3].children[3].percentile = Uncompromising;
        consciousness.personality[3].children[4].name = "Sympathy";
        consciousness.personality[3].children[4].percentile = Sympathy;
        consciousness.personality[3].children[5].name = "Trust";
        consciousness.personality[3].children[5].percentile = Trust;
        //
        //
        consciousness.personality[4].name = "Emotional range";
        consciousness.personality[4].percentile = BIG5_EmotionalRange;
        //
        consciousness.personality[4].children[0].name = "Fiery";
        consciousness.personality[4].children[0].percentile = Anger;
        consciousness.personality[4].children[1].name = "Prone to worry";
        consciousness.personality[4].children[1].percentile = Anxiety;
        consciousness.personality[4].children[2].name = "Melancholy";
        consciousness.personality[4].children[2].percentile = Melancholy;
        consciousness.personality[4].children[3].name = "Immoderation";
        consciousness.personality[4].children[3].percentile = Immoderation;
        consciousness.personality[4].children[4].name = "Self-consciousness";
        consciousness.personality[4].children[4].percentile = SelfConsciousness;
        consciousness.personality[4].children[5].name = "Susceptible to stress";
        consciousness.personality[4].children[5].percentile = Vulnerability;
        //
        //
        gameObject.name = PaintingName;
        painting.SetPersonality(consciousness);
        //
    }
}
