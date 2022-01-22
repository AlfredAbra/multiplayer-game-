using UnityEngine;
using Photon.Pun;

public class KillerController : MonoBehaviourPun
{
    public float walkSpeed = 10f;

    public Transform killer;

    public Animator killerAnim;

    PhotonView view;

    public Transform killerCam;

    public Camera killerCamera;

    public CharacterController killerCC;

    float killerRotationX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
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

            Vector3 killerMovement = transform.right * killerX + transform.forward * killerZ;

            killerCC.Move(killerMovement * walkSpeed * Time.deltaTime);

            // Animations
            killerAnim.SetFloat("KillerVertical", Input.GetAxis("Vertical"), 0.05f, Time.deltaTime);
            killerAnim.SetFloat("KillerHorizontal", Input.GetAxis("Horizontal"), 0.05f, Time.deltaTime);
        }
    }

}
