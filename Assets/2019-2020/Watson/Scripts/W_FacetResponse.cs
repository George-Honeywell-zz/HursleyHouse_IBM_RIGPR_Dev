using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(W_SetupAnalyser))]
public class W_FacetResponse : MonoBehaviour
{
    W_SetupAnalyser WSA;
    double[,] data = new double[5,7];
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

    public FACET Respond()
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
}
