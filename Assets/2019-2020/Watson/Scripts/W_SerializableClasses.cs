using System;
[Serializable]
public class Trait
{
    public string name;
    public float percentile;
    public bool significant;
}
[Serializable]
public class Humour
{
    public string name;
    public float percentile;
    public bool significant;
    public Trait[] children = new Trait[6];
}
[Serializable]
public class Personality
{
    public Humour[] personality = new Humour[5];
}
[Serializable]
public class PersonalityPainting
{
    public string name;
    public Personality personality;
}
[Serializable]
public class PaintingList
{
    public PersonalityPainting[] paintings;
}
[Serializable]
public class GamePersonality
{
    public PersonalityPainting PC;
    public PaintingList NPCs;
}
