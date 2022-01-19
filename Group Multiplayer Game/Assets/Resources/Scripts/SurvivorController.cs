using UnityEngine;
using Photon.Pun;

public class SurvivorController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    Vector2 survivorRotation;

    public Transform survivor;

    public CharacterController survivorController;

    public Animator survivorAnim;

    Vector3 survivorMovement;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        survivorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            // Player Input
            float survivorZ = Input.GetAxisRaw("Vertical");

            // Player Movement
            survivorMovement = survivorController.transform.forward * survivorZ;

            survivorController.Move(survivorMovement * walkSpeed * Time.deltaTime);

            // Mouse Control
            survivorRotation.x += Input.GetAxis("Mouse X");

            survivor.localRotation = Quaternion.Euler(0f, survivorRotation.x, 0f);

            // Animations
            survivorAnim.SetFloat("SurvivorVertical", Input.GetAxis("Vertical"), 0.05f, Time.deltaTime);
        }
        
    }
}
