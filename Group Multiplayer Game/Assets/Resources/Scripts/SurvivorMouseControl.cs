using UnityEngine;
using Photon.Pun;

public class SurvivorMouseControl : MonoBehaviourPun
{

    public Transform survivor;

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
            float survivorMouseX = Input.GetAxis("Mouse X");

            survivor.Rotate(Vector3.up * survivorMouseX);
        }

    }
}
