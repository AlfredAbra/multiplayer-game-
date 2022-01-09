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

    public Animator playerAnim;

    [SerializeField]
    private Transform fpcam;    // first person camera

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Confined;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (photonView.IsMine)
        {
            // Player Input
            float playerZ = Input.GetAxis("Vertical");
            float playerX = Input.GetAxis("Horizontal");

            // Player Movement
            Vector3 playerMovement = new Vector3(playerX, 0, playerZ);

            playerController.Move(playerMovement * walkSpeed * Time.deltaTime);

            if(playerX == 0 && playerZ == 0)
            {
                playerAnim.SetBool("isMoving", false);
            }
            else
            {
                playerAnim.SetBool("isMoving", true);
            }

            // Animations
            playerAnim.SetFloat("PlayerVertical", Input.GetAxis("Vertical"));
            playerAnim.SetFloat("PlayerHorizontal", Input.GetAxis("Horizontal"));
        }
        
    }
}
