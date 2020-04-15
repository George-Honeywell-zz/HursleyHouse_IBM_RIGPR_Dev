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

