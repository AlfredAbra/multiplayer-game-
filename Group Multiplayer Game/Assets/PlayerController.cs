using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float turnSpeed = 180;
    public float tiltSpeed = 180;
    public float walkSpeed = 10;

    public Rigidbody rb;

    public CharacterController playerController;

    [SerializeField]
    private Transform fpcam;    // first person camera

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Confined;
        /*if (!photonView.IsMine)
        {
            this.gameObject.tag = "Enemy";
        }
        else
        {
            this.gameObject.tag = "Player";
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        /*if (photonView.IsMine)
        {
            float forward = Input.GetAxis("Vertical");
            float turn = Input.GetAxis("Horizontal") + Input.GetAxis("Mouse X");
            float tilt = Input.GetAxis("Mouse Y");
            transform.Translate(new Vector3(0, 0, forward * walkSpeed * Time.deltaTime));
            transform.Rotate(new Vector3(0, turn * turnSpeed * Time.deltaTime, 0));
            if (fpcam != null)
                fpcam.Rotate(new Vector3(-tilt * tiltSpeed * Time.deltaTime, 0));
        }*/

        if (photonView.IsMine)
        {
            float playerZ = Input.GetAxis("Vertical");
            float playerX = Input.GetAxis("Horizontal");

            Vector3 playerMovement = new Vector3(playerX, 0, playerZ);

            playerController.Move(playerMovement * walkSpeed * Time.deltaTime);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        

        
    }

    [PunRPC]
    void playerCollision()
    {

    }
}
