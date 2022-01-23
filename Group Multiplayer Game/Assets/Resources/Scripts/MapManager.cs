using UnityEngine;
using Photon.Pun;
using System.IO;

public class MapManager : MonoBehaviourPun, IPunObservable
{
    public int killerCount = 0;
    public int survivorCount = 0;

    public GameObject mainPanel;
    public GameObject survivorDeadPanel;
    public GameObject killerWinPanel;
    public GameObject roleSelectionPanel;

    public GameObject killerButton;
    public GameObject survivorButton;

    public Camera mainCamera;

    public GameObject killerModel;
    public GameObject survivorModel;
    public Transform[] spawnPointsSurvivor;
    public Transform[] spawnPointsKiller;

    SurvivorController survivorScript;

    ServerConnectManager serverConnect;

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
        if(killerCount == 1)
         {
            KillerLimitReached();
         }

        /*if(serverConnect.playerCount == 4)
        {
            DisplayRoleButtons();
        }*/
    }

    public void KillerClicked()
    {
        int randNumKiller = Random.Range(0, spawnPointsSurvivor.Length);
        Transform killerSpawns = spawnPointsSurvivor[randNumKiller];
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "KillerModel"), killerSpawns.position, Quaternion.identity);

        killerCount++;

        //playerCount++;

        killerButton.SetActive(false);

        survivorButton.SetActive(false);

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

    /*public void DisplayRoleButtons()
    {
        photonView.RPC("DisplayRoleButtonsRPC", RpcTarget.All);
    }

    [PunRPC]
    void DisplayRoleButtonsRPC()
    {
        roleSelectionPanel.SetActive(true);
    }*/

    public void SurvivorClicked()
    {
        int randNumSurvivor = Random.Range(0, spawnPointsSurvivor.Length);
        Transform survivorSpawns = spawnPointsSurvivor[randNumSurvivor];
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "SurvivorModel"), survivorSpawns.position, Quaternion.identity);

        //survivorCount++;

        //playerCount++;

        survivorButton.SetActive(false);

        killerButton.SetActive(false);

        mainPanel.SetActive(false);
    }

    public void QuitClicked()
    {
        Application.Quit();
    }

    public void PlayClicked()
    {
        mainPanel.SetActive(false);
    }


    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}