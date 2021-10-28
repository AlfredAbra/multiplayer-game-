using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Text nickname, status, room, players;
    [SerializeField]
    private Button buttonPlay, buttonLeave;
    [SerializeField]
    private InputField playerName;

    [SerializeField]
    private byte maxPlayersPerRoom = 20;

    // Start is called before the first frame update
    void Start()
    {
        status.text = "Connecting...";
        buttonPlay.gameObject.SetActive(false);
        buttonLeave.gameObject.SetActive(false);
        playerName.gameObject.SetActive(false);

        if (!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            nickname.text = "Hello, " + PhotonNetwork.NickName;
            room.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
            players.text = "Players: " + PhotonNetwork.CurrentRoom.PlayerCount + " of " + PhotonNetwork.CurrentRoom.MaxPlayers;
        }
        else if (PhotonNetwork.IsConnected)
        {
            nickname.text = "Type your name below and hit PLAY!";
            room.text = "Not yet in a room...";
            players.text = "Players: 0";
        }
        else
            nickname.text = room.text = players.text = "";
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster was called by PUN.");
        status.text = "Connected to Photon.";
        buttonPlay.gameObject.SetActive(true);
        playerName.gameObject.SetActive(true);
        buttonLeave.gameObject.SetActive(false);

        playerName.text = PlayerPrefs.GetString("PlayerName");
    }

    public void Play()
    {
        PlayerPrefs.SetString("PlayerName", playerName.text);
        PhotonNetwork.NickName = playerName.text;

        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Yep, you managed to join a room!");
        status.text = "Yep, you managed to join a room!";
        buttonPlay.gameObject.SetActive(false);
        playerName.gameObject.SetActive(false);
        buttonLeave.gameObject.SetActive(true);
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


}
