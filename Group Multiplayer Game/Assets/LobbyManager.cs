using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public GameObject createRoomPanel;
    public GameObject roomPanel;
    public InputField roomNameInput;
    public Text nameOfRoom;

    List<RoomListItem> roomList = new List<RoomListItem>();
    public RoomListItem room;
    public Transform roomListContent;

    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.JoinLobby(); // This joins the player into a lobby after the play button has been clicked in the main menu scene. This then allows the player to create a room.
        createRoomPanel.SetActive(true);
        roomPanel.SetActive(false);
    }

    public void CreateRoomClicked()
    {
        if(roomNameInput.text.Length >= 1){
            PhotonNetwork.CreateRoom(roomNameInput.text, new RoomOptions() { MaxPlayers = 4 }); // This creates a room with the name that was in the input field and the maximum player count for the room is set as 4.
        }
    }

    public override void OnJoinedRoom()
    {
        createRoomPanel.SetActive(false); // This stops displaying the createRoomPanel game object.
        roomPanel.SetActive(true); // This then displays the roomPanel game object.
        nameOfRoom.text = PhotonNetwork.CurrentRoom.Name; // This sets the name of the room to be whatever the current name of the room that has been joined is.
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateServerRooms(roomList);
    }

    public void UpdateServerRooms(List<RoomInfo> rooms)
    {
        foreach (RoomListItem createdRoom in roomList) // This for each loop ensures that all previous rooms in the roomList are removed and the list is cleared completely.
        {
            Destroy(createdRoom.gameObject);
        }
        roomList.Clear();

        foreach (RoomInfo gameRoom in rooms)
        {
            RoomListItem newRoom = Instantiate(room, roomListContent, false);
            newRoom.RoomName(gameRoom.Name);
            roomList.Add(newRoom);
        }
    }

    public void JoiningRoom(string name)
    {
        PhotonNetwork.JoinRoom(name);
    }

    public void PlayerLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        createRoomPanel.SetActive(true);
        roomPanel.SetActive(false);
    }
}
