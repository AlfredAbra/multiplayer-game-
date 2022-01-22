using UnityEngine;
using Photon.Pun;

public class KillerMouseControl : MonoBehaviourPun
{

    float mouseSens = 300f;

    public Transform killer;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            // Mouse Look
            float killerMouseX = Input.GetAxis("Mouse X");

            killer.Rotate(Vector3.up * killerMouseX);
        }

    }
}
