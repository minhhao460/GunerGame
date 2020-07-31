using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAfterIn : MonoBehaviour
{
    public bool PlayerIn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            PlayerIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            PlayerIn = false;
    }
}
