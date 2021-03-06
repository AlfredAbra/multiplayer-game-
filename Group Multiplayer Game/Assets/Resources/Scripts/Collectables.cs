using UnityEngine;
using Photon.Pun;

public class Collectables : MonoBehaviour
{
    KeyCountManager keys;

    //PhotonView view;

    private void Start()
    {
        keys = FindObjectOfType<KeyCountManager>();
        //view = GetComponent<PhotonView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PhotonNetwork.IsMasterClient) // This will make sure that it is only executed once each time the collision happens.
        {
            if (other.tag == "Survivor")
            {
                keys.KeyCountTracker();
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }

}
