using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SurvivorController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    public CharacterController survivorController;

    public Animator survivorAnim;

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Confined;
        survivorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (photonView.IsMine)
        {
            // Player Input
            float survivorZ = Input.GetAxisRaw("Vertical");
            float survivorX = Input.GetAxisRaw("Horizontal");

            // Player Movement
            Vector3 survivorMovement = new Vector3(survivorX, 0, survivorZ).normalized;

            survivorController.Move(survivorMovement * walkSpeed * Time.deltaTime);

            survivorAnim.SetFloat("SurvivorHorizontal", Input.GetAxisRaw("Horizontal"), 0.08f, Time.deltaTime);
            survivorAnim.SetFloat("SurvivorVertical", Input.GetAxisRaw("Vertical"), 0.08f, Time.deltaTime);
        }
        
    }
}
