using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTeleport : MonoBehaviour
{
    public GameObject teleportPoint;
    public Transform teleportSpawn;

    // Update is called once per frame

    public void TeleportSpawn()
    {
        Instantiate(teleportPoint, teleportSpawn.position, teleportSpawn.rotation);
    }
}
