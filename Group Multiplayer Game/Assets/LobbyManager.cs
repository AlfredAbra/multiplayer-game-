using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public GameObject createRoom;
    public GameObject room;
    public InputField addRoomName;
    public Text nameOfRoom;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby(); // This joins the player into a lobby after the play button has been clicked in the main menu scene.
    }

    public void CreateRoom()
    {
        if(addRoomName.text.Length >= 1) // This makes sure the room name input field is not left empty when creating a room.
        {
            PhotonNetwork.CreateRoom(addRoomName.text, new RoomOptions(){ MaxPlayers = 4 }); // This creates a room with the name inputted and set's the maximum players count for the room to no more than 4.
        }
    }

    public override void OnJoinedRoom()
    {
        createRoom.SetActive(false); // This stops the room creation panel from being displayed.
        room.SetActive(true); // This then displays the room panel when a room has been joined.
        nameOfRoom.text = "Room: " + PhotonNetwork.CurrentRoom.Name; // This sets the nameOfRoom text element to display the name of the current room the player is in.
    }

}
