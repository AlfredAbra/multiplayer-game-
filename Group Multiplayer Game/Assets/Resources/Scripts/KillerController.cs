using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class KillerController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    public CharacterController killerController;

    public Animator killerAnim;

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Confined;
        killerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (photonView.IsMine)
        {
            // Player Input
            float killerZ = Input.GetAxisRaw("Vertical");
            float killerX = Input.GetAxisRaw("Horizontal");

            // Player Movement
            Vector3 killerMovement = new Vector3(killerX, 0, killerZ).normalized;

            killerController.Move(killerMovement * walkSpeed * Time.deltaTime);

            killerAnim.SetFloat("KillerHorizontal", Input.GetAxisRaw("Horizontal"), 0.08f, Time.deltaTime);
            killerAnim.SetFloat("KillerVertical", Input.GetAxisRaw("Vertical"), 0.08f, Time.deltaTime);
        }
        
    }
}
