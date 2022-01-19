using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class KeyCountManager : MonoBehaviour
{
    int keyCount = 0;

    public Text keyCountText;

    PhotonView view;

    public GameObject winPanel;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void KeyCountTracker()
    {
        view.RPC("KeyCountTrackerRPC", RpcTarget.All);
    }

    [PunRPC]
    void KeyCountTrackerRPC()
    {
        keyCount++;
        keyCountText.text = "Key Count: " + keyCount.ToString();

        if (keyCount == 5)
        {
            winPanel.SetActive(true);
        }
    }
}
