using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class KillerController : MonoBehaviourPun, IPunObservable
{
    public float walkSpeed = 10f;

    public Transform killer;

    public Animator killerAnim;

    PhotonView view;

    public Transform killerCam;

    public Camera killerCamera;

    public CharacterController killerCC;

    SurvivorController survivorScript;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        killerAnim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();

        //survivorScript = FindObjectOfType<SurvivorController>();

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

        if (Input.GetMouseButtonDown(0))
        {
            KillerRaycast();
        }
    }

    public void KillerRaycast()
    {
        view.RPC("KillerRaycastRPC", RpcTarget.All);
    }

    [PunRPC]
    void KillerRaycastRPC()
    {
        Ray killerRaycast = killerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit survivorHit;
        if (Physics.Raycast(killerRaycast, out survivorHit, 50))
        {
            Transform playerHit = survivorHit.transform;
            if (playerHit.tag == "Survivor")
            {
                playerHit.transform.gameObject.GetComponent<SurvivorController>().survivorHealth -= 10f;
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        /*if (stream.IsWriting)
        {
            stream.SendNext(survivorScript.survivorHealth);
        }
        else
        {
            survivorScript.survivorHealth = (float)stream.ReceiveNext();
        }*/
    }
}


