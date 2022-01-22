using UnityEngine;
using Photon.Pun;

public class KillerController : MonoBehaviourPun
{
    public float walkSpeed = 10f;

    public Transform killer;

    public Animator killerAnim;

    PhotonView view;

    public Transform killerCam;

    float mouseSens = 300f;

    float killerTurnSpeed = 300f;

    public Camera killerCamera;

    public CharacterController killerCC;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        killerAnim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();

        if (!photonView.IsMine)
        {
            killerCamera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {

            // Player Input
            float killerZ = Input.GetAxis("Vertical");
            float killerX = Input.GetAxisRaw("Horizontal");

            Vector3 killerMovement = new Vector3(killerX, 0, killerZ);

            killerCC.Move(killerMovement * walkSpeed * Time.deltaTime);

            /*float killerTurn = Input.GetAxis("Mouse X");

            float mouseMovementY = Input.GetAxis("Mouse Y");

            transform.Translate(new Vector3(0, 0, killerZ * walkSpeed * Time.deltaTime));
            transform.Rotate(new Vector3(0, killerTurn * killerTurnSpeed * Time.deltaTime, 0));

            if(killerCam != null)
            {
                killerCam.Rotate(new Vector3(-mouseMovementY * mouseSens * Time.deltaTime, 0));
            }*/

            // Animations
            killerAnim.SetFloat("KillerVertical", Input.GetAxis("Vertical"), 0.05f, Time.deltaTime);
            killerAnim.SetFloat("KillerHorizontal", Input.GetAxis("Horizontal"), 0.05f, Time.deltaTime);
        }
    }

}
