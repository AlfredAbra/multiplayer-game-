using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.IO;

public class MapManager : MonoBehaviourPunCallbacks
{
    public int killerCount = 0;
    public int survivorCount = 0;

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

        playButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(killerCount == 1)
        {
            killerButton.SetActive(false); // This stops displaying the button to become a killer if someone is already a killer in the room.
        }
        
    }

    public void KillerClicked()
    {
        killerCount++;

        mainPanel.SetActive(false);
    }

    public void SurvivorClicked()
    {
        int randNumSurvivor = Random.Range(0, spawnPointsSurvivor.Length);
        Transform survivorSpawns = spawnPointsSurvivor[randNumSurvivor];
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "SurvivorModel"), survivorSpawns.position, Quaternion.identity);
        
        survivorCount++;

        mainPanel.SetActive(false);
    }
}
