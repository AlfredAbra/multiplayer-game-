using UnityEngine;
using Photon.Pun;

public class KillerController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    public Transform killer;

    public CharacterController killerController;

    public Animator killerAnim;

    Vector3 killerMovement;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        killerAnim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {

            // Player Input
            float killerZ = Input.GetAxisRaw("Vertical");
            float killerX = Input.GetAxisRaw("Horizontal");

            // Player Movement
            killerMovement = new Vector3(killerX, 0f, killerZ);

            killerController.Move(killerMovement * walkSpeed * Time.deltaTime);

            // Animations
            killerAnim.SetFloat("KillerVertical", Input.GetAxis("Vertical"), 0.05f, Time.deltaTime);
            killerAnim.SetFloat("KillerHorizontal", Input.GetAxis("Horizontal"), 0.05f, Time.deltaTime);
        }
    }

}
