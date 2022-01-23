using UnityEngine;
using Photon.Pun;

public class SurvivorMouseControl : MonoBehaviourPun
{
    public Transform survivor;

    float mouseSens = 200f;

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
            float survivorMouseX = Input.GetAxis("Mouse X") * Time.deltaTime;

            survivor.Rotate(0,survivorMouseX * mouseSens,0f);
        }

    }
}
