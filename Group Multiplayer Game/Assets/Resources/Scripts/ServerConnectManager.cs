using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ServerConnectManager : MonoBehaviourPunCallbacks
{
    public InputField playerName;
    public TextMeshProUGUI connectButtonText;

    [SerializeField]
    private byte maxPlayerCount = 4;

    public void PlayClicked()
    {
        if(playerName.text.Length >= 1) // If the playerName input field is not empty then...
        {
            PhotonNetwork.NickName = playerName.text; // This sets the players nickname within photon as whatever was inputted within the playerName input field.
            connectButtonText.text = "Connecting to PUN";
            if (!PhotonNetwork.IsConnected)
                PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("You've connected to Photon!");
        playerJoinsRandomRoom();
    }

    public void playerJoinsRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom(); // This will join the player into a random room if there are any rooms with spaces.
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No rooms available, creating new room!");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayerCount }); // This will create a new room with a max player count of 4.
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Yep, you managed to join a room!");

        SceneManager.LoadScene("Map");
    }
}
