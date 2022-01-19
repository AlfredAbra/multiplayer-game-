using UnityEngine;
using Photon.Pun;

public class KillerController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    Vector2 killerRotation;

    public Transform killer;

    public CharacterController killerController;

    public Animator killerAnim;

    Vector3 killerMovement;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        killerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            // Player Input
            float killerZ = Input.GetAxisRaw("Vertical");

            // Player Movement
            killerMovement = killerController.transform.forward * killerZ;

            killerController.Move(killerMovement * walkSpeed * Time.deltaTime);

            // Mouse Control
            killerRotation.x += Input.GetAxis("Mouse X");

            killer.localRotation = Quaternion.Euler(0f, killerRotation.x, 0f);

            // Animations
            killerAnim.SetFloat("KillerVertical", Input.GetAxis("Vertical"), 0.05f, Time.deltaTime);
        }
        
    }
}
