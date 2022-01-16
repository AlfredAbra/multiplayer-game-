using UnityEngine;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour
{
    public Text nameOfRoom;
    LobbyManager lobbyMan;

    private void Start()
    {
        lobbyMan = FindObjectOfType<LobbyManager>(); // This finds any game objects within the scene that are using the lobby manager script.
    }

    public void RoomName(string name)
    {
        nameOfRoom.text = name;
    }

    public void RoomClicked()
    {
        lobbyMan.JoiningRoom(nameOfRoom.text);
    }
}
