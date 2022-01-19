using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.IO;

public class MapManager : MonoBehaviourPunCallbacks
{
    public int killerCount = 0;
    public int survivorCount = 0;

    //public PhotonView pv;

    public GameObject killerButton;
    public GameObject survivorButton;
    public GameObject playButton;

    public GameObject mainPanel;

    public GameObject killerModel;
    public GameObject survivorModel;
    public Transform[] spawnPointsSurvivor;
    public Transform[] spawnPointsKiller;

    void Start()
    {
        int randNumPlayer = Random.Range(0, spawnPointsSurvivor.Length);
        int randNumKiller = Random.Range(0, spawnPointsKiller.Length);

        //pv = GetComponent<PhotonView>();

        playButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       /*if(killerCount >= 1)
        {
            pv.RPC("killerLimitReached", RpcTarget.AllBufferedViaServer);
        }*/
    }

    /*public void KillerClicked()
    {
        int randNumKiller = Random.Range(0, spawnPointsSurvivor.Length);
        Transform killerSpawns = spawnPointsSurvivor[randNumKiller];
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"), killerSpawns.position, Quaternion.identity);

        killerCount++;
    }*/

    /*[PunRPC]
    public void killerLimitReached()
    {
        killerButton.SetActive(false); // This stops displaying the button to become a killer if someone is already a killer in the room.
    }*/

    public void SurvivorClicked()
    {
        int randNumSurvivor = Random.Range(0, spawnPointsSurvivor.Length);
        Transform survivorSpawns = spawnPointsSurvivor[randNumSurvivor];
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "SurvivorModel"), survivorSpawns.position, Quaternion.identity);
        
        survivorCount++;

        mainPanel.SetActive(false);
    }
}
