using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class KillerController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    public float mouseSens = 300f;

    public float rotClamp = 90f;

    float rotationX;

    float rotationY;

    public CharacterController killerController;

    public Animator killerAnim;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        killerAnim = GetComponent<Animator>();

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
            float killerZ = Input.GetAxisRaw("Vertical");
            float killerX = Input.GetAxisRaw("Horizontal");

            // Player Movement
            Vector3 killerMovement = new Vector3(killerX, 0, killerZ).normalized;

            killerController.Move(killerMovement * walkSpeed * Time.deltaTime);

            killerAnim.SetFloat("KillerHorizontal", Input.GetAxisRaw("Horizontal"), 0.08f, Time.deltaTime);
            killerAnim.SetFloat("KillerVertical", Input.GetAxisRaw("Vertical"), 0.08f, Time.deltaTime);

            // Mouse Input
            float lookX = Input.GetAxis("Mouse X");
            float lookY = Input.GetAxis("Mouse Y");

            rotationX -= lookY * mouseSens * Time.deltaTime;
            rotationY += lookX * mouseSens * Time.deltaTime;

            rotationX = Mathf.Clamp(rotationX, -rotClamp, rotClamp);

            Quaternion killerRotation = Quaternion.Euler(rotationX, rotationY, 0f);
            transform.rotation = killerRotation;
        }
        
    }
}
