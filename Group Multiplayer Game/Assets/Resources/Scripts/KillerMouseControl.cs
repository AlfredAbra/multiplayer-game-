using UnityEngine;
using Photon.Pun;

public class KillerMouseControl : MonoBehaviourPun
{

    float mouseSens = 200f;

    public Transform killer;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            // Mouse Look
            float killerMouseX = Input.GetAxis("Mouse X") * Time.deltaTime;

            killer.Rotate(0f,killerMouseX * mouseSens,0f);
        }

    }
}
