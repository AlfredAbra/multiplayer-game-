using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Collectables : MonoBehaviour
{
    KeyCountManager keys;

    public GameObject winPanel;

    PhotonView view;

    private void Start()
    {
        keys = FindObjectOfType<KeyCountManager>();
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        WinGame();
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

    public void WinGame()
    {
        view.RPC("WinGameRPC", RpcTarget.AllBufferedViaServer);
    }

    [PunRPC]
    void WinGameRPC()
    {
        if(keys.keyCount == 3)
        {
            winPanel.SetActive(true);
        }
    }
}
