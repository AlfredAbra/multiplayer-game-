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

    }

    // Update is called once per frame
    void Update()
    {

        if (photonView.IsMine)
        {
            float playerZ = Input.GetAxis("Vertical");
            float playerX = Input.GetAxis("Horizontal");

            Vector3 playerMovement = new Vector3(playerX, 0, playerZ);

            playerController.Move(playerMovement * walkSpeed * Time.deltaTime);
        }
        
    }
}
