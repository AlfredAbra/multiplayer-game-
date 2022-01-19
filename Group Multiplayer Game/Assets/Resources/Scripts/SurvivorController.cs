using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SurvivorController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    public float mouseSens = 300f;

    public float rotClamp = 90f;

    float rotationX;

    float rotationY;

    public CharacterController survivorController;

    public Animator survivorAnim;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        survivorAnim = GetComponent<Animator>();

        Vector3 mouseRotation = transform.localRotation.eulerAngles;

        rotationX = mouseRotation.x;
        rotationY = mouseRotation.y;
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

            // Mouse Input
            float lookX = Input.GetAxis("Mouse X");
            float lookY = Input.GetAxis("Mouse Y");

            rotationX -= lookY * mouseSens * Time.deltaTime;
            rotationY += lookX * mouseSens * Time.deltaTime;

            rotationX = Mathf.Clamp(rotationX, -rotClamp, rotClamp);

            Quaternion survivorRotation = Quaternion.Euler(rotationX, rotationY, 0f);
            transform.rotation = survivorRotation;
        }
        
    }
}
