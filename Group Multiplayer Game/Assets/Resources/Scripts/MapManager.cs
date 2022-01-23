using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class MapManager : MonoBehaviourPunCallbacks
{
    public int killerCount = 0;
    public int survivorCount = 0;

    public GameObject mainPanel;
    public GameObject survivorDeadPanel;

    public Camera mainCamera;

    public GameObject killerModel;
    public GameObject survivorModel;
    public Transform[] spawnPointsSurvivor;
    public Transform[] spawnPointsKiller;

    PhotonView view;

    SurvivorController survivorScript;

    public void Start()
    {
        int randNumPlayer = Random.Range(0, spawnPointsSurvivor.Length);
        int randNumKiller = Random.Range(0, spawnPointsKiller.Length);

        survivorScript = FindObjectOfType<SurvivorController>();

        mainCamera = GetComponent<Camera>();

        mainCamera.enabled = false;

        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    public void Update()
    {
        /*if(killerCount >= 1)
         {
             pv.RPC("killerLimitReached", RpcTarget.AllBufferedViaServer);
         }*/
    }

    public void KillerClicked()
    {
        int randNumKiller = Random.Range(0, spawnPointsSurvivor.Length);
        Transform killerSpawns = spawnPointsSurvivor[randNumKiller];
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "KillerModel"), killerSpawns.position, Quaternion.identity);

        killerCount++;

        mainPanel.SetActive(false);
    }

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

    public void QuitClicked()
    {
        Application.Quit();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        SceneManager.LoadScene("MainMenu");
    }

}