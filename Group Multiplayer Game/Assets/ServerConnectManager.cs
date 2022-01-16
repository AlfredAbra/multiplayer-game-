using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServerConnectManager : MonoBehaviourPunCallbacks
{
    public InputField playerName;
    public Text playButtonText;

    public void PlayClicked()
    {
        if(playerName.text.Length >= 1) // If the playerName input field is not empty then...
        {
            PhotonNetwork.NickName = playerName.text; // This sets the players nickname within photon as whatever was inputted within the playerName input field.
            playButtonText.text = "Connecting to PUN Server...";
            if (!PhotonNetwork.IsConnected)
                PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("RoomsScene");
    }
}
