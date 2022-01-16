using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Text nickname, status, room, players;
    [SerializeField]
    private Button buttonPlay, buttonLeave, killerRole, survivorRole;
    [SerializeField]
    private InputField playerName;

    [SerializeField]
    private byte maxPlayersPerRoom = 5;

    int killerCount = 0;

    int survivorCount = 0;

    public GameObject player;

    public GameObject exitDoor;

    public GameObject keys;

    public GameObject rock;

    // Start is called before the first frame update
    /*void Start()
    {
        status.text = "Connecting...";
        buttonPlay.gameObject.SetActive(false);
        buttonLeave.gameObject.SetActive(false);
        playerName.gameObject.SetActive(false);
        killerRole.gameObject.SetActive(true);
        survivorRole.gameObject.SetActive(true);

        if (!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
    }

    public void Play()
    {
        PlayerPrefs.SetString("PlayerName", playerName.text);
        PhotonNetwork.NickName = playerName.text;

        SceneManager.LoadScene("RoleSelectionScene");
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Oops, tried to join a room and failed. Calling CreateRoom!");

        // failed to join a random room, so create a new one
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Yep, you managed to join a room!");
        status.text = "Yep, you managed to join a room!";
        buttonPlay.gameObject.SetActive(false);
        playerName.gameObject.SetActive(false);
        buttonLeave.gameObject.SetActive(true);

        // Spawn's the player
        PhotonNetwork.Instantiate(player.name,
             new Vector3(Random.Range(-10, 10), 0.1f, Random.Range(-10, 10)),
             Quaternion.identity
             , 0);

        // Spawn Exit Door
        PhotonNetwork.InstantiateRoomObject(exitDoor.name, new Vector3(-15.01f, 0.25f, Random.Range(-15.15f, 13.017f)), Quaternion.Euler(-90,0,90), 0);

        // Spawn Keys
        for(int i = 0; i < 5; i++)
        {
            PhotonNetwork.InstantiateRoomObject(keys.name, new Vector3(Random.Range(-15f, 15f), 1.25f, Random.Range(-15f, 15f)), Quaternion.Euler(0, 0, 0), 0);
        }

        // Spawn Rock 
        GameObject rock1 = PhotonNetwork.InstantiateRoomObject(rock.name, new Vector3(Random.Range(-10f,10f), 0.25f, Random.Range(-10f, 10f)), Quaternion.Euler(0, 0, 0), 0);
        
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        status.text = newPlayer.NickName + " has just entered.";
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        status.text = otherPlayer.NickName + " has just left.";
    }

    public void PlayerRoleSelection()
    {

    }

    public void KillerRole()
    {
        //killerCount++;
        // Instantiate killer model for user that's chosen it.
    }

    public void SurvivorRole()
    {
        //survivorCount++;
        // Instantiate survivor model for user that's chosen it.
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            nickname.text = "Hello, " + PhotonNetwork.NickName;
            room.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
            players.text = "Players: " + PhotonNetwork.CurrentRoom.PlayerCount + " of " + PhotonNetwork.CurrentRoom.MaxPlayers;

            players.text += ":\n";
            Dictionary<int, Player> mydict = PhotonNetwork.CurrentRoom.Players;
            int i = 1;
            foreach (var item in mydict)
                players.text += string.Format("{0,2}. {1}\n", (i++), item.Value.NickName);
        }
        else if (PhotonNetwork.IsConnected)
        {
            nickname.text = "Type your name below and hit PLAY!";
            room.text = "Not yet in a room...";
            players.text = "Players: 0";
        }
        else
            nickname.text = room.text = players.text = "";

        if (killerCount == 1)
        {
            killerRole.gameObject.SetActive(false);
        }

        if (survivorCount == 4)
        {
            survivorRole.gameObject.SetActive(false);
        }
    }*/

}
