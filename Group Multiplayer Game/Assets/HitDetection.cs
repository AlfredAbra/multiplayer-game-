using UnityEngine;
using Photon.Pun;

public class HitDetection : MonoBehaviour
{
    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if(other.gameObject.tag == "Survivor")
            {
                PhotonNetwork.Destroy(other.gameObject);
            }
        }
    }
}


