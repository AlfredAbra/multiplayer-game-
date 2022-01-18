using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.IO;

public class MapManager : MonoBehaviour
{
    int killerCount = 0;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(killerCount == 1)
        {
            killerButton.SetActive(false); // This stops displaying the button to become a killer if someone is already a killer in the room.
        }

        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == 4 && killerCount == 1)
        {
            playButton.SetActive(true); // If the there are 4 people in the room and there is a player who has chosen to be the killer. Then, the master client (player who created the room) will be able to see and click on the play button to start the game.
        }
        else
        {
            playButton.SetActive(false);
        }
    }

    public void KillerClicked()
    {
        killerCount++;
    }

    public void SurvivorClicked()
    {
        int randNumSurvivor = Random.Range(0, spawnPointsSurvivor.Length);
        Transform survivorSpawns = spawnPointsSurvivor[randNumSurvivor];
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "SurvivorModel"), survivorSpawns.position, Quaternion.identity);
    }

    public void PlayClicked()
    {
        mainPanel.SetActive(false);
    }
}
