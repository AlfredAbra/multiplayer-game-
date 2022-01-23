using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class MapManager : MonoBehaviourPun, IPunObservable
{
    public int killerCount = 0;
    public int survivorCount = 0;
    public int playerCount = 0;

    public GameObject mainPanel;
    public GameObject survivorDeadPanel;
    public GameObject killerWinPanel;

    public GameObject killerButton;

    public Camera mainCamera;

    public GameObject killerModel;
    public GameObject survivorModel;
    public Transform[] spawnPointsSurvivor;
    public Transform[] spawnPointsKiller;

    SurvivorController survivorScript;

    public void Start()
    {
        int randNumPlayer = Random.Range(0, spawnPointsSurvivor.Length);
        int randNumKiller = Random.Range(0, spawnPointsKiller.Length);

        survivorScript = FindObjectOfType<SurvivorController>();

        mainCamera = GetComponent<Camera>();

        mainCamera.enabled = false;

        killerWinPanel.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if(killerCount >= 1)
         {
            KillerLimitReached();
         }
    }

    public void KillerClicked()
    {
        int randNumKiller = Random.Range(0, spawnPointsSurvivor.Length);
        Transform killerSpawns = spawnPointsSurvivor[randNumKiller];
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "KillerModel"), killerSpawns.position, Quaternion.identity);

        killerCount++;

        playerCount++;

        mainPanel.SetActive(false);
    }

    public void KillerLimitReached()
    {
        photonView.RPC("KillerLimitReachedRPC", RpcTarget.All);
    }

    [PunRPC]
    void KillerLimitReachedRPC()
    {
        killerButton.SetActive(false); // This stops displaying the button to become a killer if someone is already a killer in the room.
    }

    public void SurvivorClicked()
    {
        int randNumSurvivor = Random.Range(0, spawnPointsSurvivor.Length);
        Transform survivorSpawns = spawnPointsSurvivor[randNumSurvivor];
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "SurvivorModel"), survivorSpawns.position, Quaternion.identity);

        playerCount++;

        mainPanel.SetActive(false);
    }

    public void QuitClicked()
    {
        Application.Quit();
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}