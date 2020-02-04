using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_PaintingInteraction : MonoBehaviour
{
    Personality initiator;
    Personality reactor;
    void Interaction(Personality Initiator, Personality Reactor)
    {
        initiator = Initiator;
        reactor = Reactor;
    }
}
