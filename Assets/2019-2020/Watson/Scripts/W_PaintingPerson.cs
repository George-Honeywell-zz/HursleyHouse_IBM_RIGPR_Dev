using UnityEngine;
public class W_PaintingPerson : MonoBehaviour
{
    Personality personality;
    double[] Big5Accumulate = new double[5];
    double[,] FacetAccumulate = new double[5, 6];
    W_PentagonGraph graph;
    W_SpeechResponse parentspeech;
    public void SetPersonality(Personality Profile)
    {
        personality = Profile;
        // Set Accumulators to Zero
        for (int b5 = 0; b5 < 5; b5++)
        {
            Big5Accumulate[b5] = 0.0f;
            for (int f = 0; f < 6; f++)
                FacetAccumulate[b5, f] = 0.0f;
        }
        graph = gameObject.AddComponent<W_PentagonGraph>();
        graph.GetPentagon(Profile);
        parentspeech = GetComponentInParent<W_SpeechResponse>();
    }
    public Personality GetPersonality()
    {
        return personality;
    }
    public W_PentagonGraph GetGraph()
    {
        return graph;
    }
    public double GetAccumulate(int Big5)
    {
        return Big5Accumulate[Big5];
    }
    public double GetAccumulate(int Big5, int Facet)
    {
        return FacetAccumulate[Big5, Facet];
    }
    public void Accumulate()
    {
        // Accumulate percentiles
        for (int b5 = 0; b5 < 5; b5++)
        {
            Big5Accumulate[b5] += personality.personality[b5].percentile;
            for (int f = 0; f < 6; f++)
                FacetAccumulate[b5, f] += personality.personality[b5].children[f].percentile;
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
    /*public void InitiateInteraction(W_PaintingPerson other)
    {
        // Accumulate
        Accumulate();
        other.Accumulate();

        int big5 = Big5Selector();
        if (GetAccumulate(big5) > other.GetAccumulate(big5))
        {

        }

    }*/
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
}
