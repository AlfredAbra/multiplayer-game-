using UnityEngine;
using Photon.Pun;

public class SurvivorController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    Vector3 survivorMovement;

    public CharacterController survivorController;

    public Animator survivorAnim;

    PhotonView view;

    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        survivorAnim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {

            // Player Input
            float survivorZ = Input.GetAxisRaw("Vertical");
            float survivorX = Input.GetAxisRaw("Horizontal");

            // Player Movement
            survivorMovement = new Vector3(survivorX,0f,survivorZ);

            survivorController.Move(survivorMovement * walkSpeed * Time.deltaTime);

            // Animations
            survivorAnim.SetFloat("SurvivorVertical", survivorZ, 0.05f, Time.deltaTime);
            survivorAnim.SetFloat("SurvivorHorizontal", survivorX, 0.05f, Time.deltaTime);

        }
        
    }

}
