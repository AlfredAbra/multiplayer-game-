using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Collectables : MonoBehaviour
{
    KeyCountManager keys;

    private void Start()
    {
        keys = FindObjectOfType<KeyCountManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PhotonNetwork.IsMasterClient) // This will make sure that it is only executed once each team the collision happens.
        {
            if (other.gameObject.tag == "Survivor")
            {
                keys.KeyCountTracker();
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}
