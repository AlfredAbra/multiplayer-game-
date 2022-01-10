using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    public CharacterController playerController;

    bool isMoving;

    public Animator playerAnim;

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
            float playerZ = Input.GetAxisRaw("Vertical");
            float playerX = Input.GetAxisRaw("Horizontal");

            // Player Movement
            Vector3 playerMovement = new Vector3(playerX, 0, playerZ).normalized;

            playerController.Move(playerMovement * walkSpeed * Time.deltaTime);

            playerAnim.SetFloat("PlayerHorizontal", Input.GetAxisRaw("Horizontal"), 0.08f, Time.deltaTime);
            playerAnim.SetFloat("PlayerVertical", Input.GetAxisRaw("Vertical"), 0.08f, Time.deltaTime);
        }
        
    }
}
