using UnityEngine;
using Photon.Pun;

public class SurvivorController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    Vector3 survivorMovement;

    public CharacterController survivorController;

    public Animator survivorAnim;

    PhotonView view;

    public Transform survivorCam;

    float mouseSens = 300f;

    float survivorTurnSpeed = 300f;

    public Camera survivorCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        survivorAnim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();

        if (!photonView.IsMine)
        {
            survivorCamera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {

            // Player Input
            float survivorZ = Input.GetAxisRaw("Vertical");
            //float survivorX = Input.GetAxisRaw("Horizontal");

            float survivorTurn = Input.GetAxis("Mouse X");

            float mouseMovementY = Input.GetAxis("Mouse Y");

            /*// Player Movement
            survivorMovement = new Vector3(survivorX,0f,survivorZ);

            survivorController.Move(survivorMovement * walkSpeed * Time.deltaTime);*/

            transform.Translate(new Vector3(0, 0, survivorZ * walkSpeed * Time.deltaTime));
            transform.Rotate(new Vector3(0, survivorTurn * survivorTurnSpeed * Time.deltaTime, 0));

            if (survivorCam != null)
            {
                survivorCam.Rotate(new Vector3(-mouseMovementY * mouseSens * Time.deltaTime, 0));
            }

            // Animations
            survivorAnim.SetFloat("SurvivorVertical", Input.GetAxis("Vertical"), 0.05f, Time.deltaTime);
            //survivorAnim.SetFloat("SurvivorHorizontal", Input.GetAxis("Horizontal"), 0.05f, Time.deltaTime);

        }
    }

}

