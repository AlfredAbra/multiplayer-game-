﻿using UnityEngine;
using Photon.Pun;
using System.Collections;
using UnityEngine.SceneManagement;

public class SurvivorController : MonoBehaviourPun
{
    public float walkSpeed = 10;

    public Animator survivorAnim;

    PhotonView view;

    public Transform survivorCam;

    public Camera survivorCamera;

    public CharacterController survivorCC;

    public float survivorHealth;

    public GameObject survivorDeadPanel;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        survivorAnim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();

        //survivorHealth = 10f;

        //survivorDeadPanel.SetActive(false);

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
            float survivorX = Input.GetAxisRaw("Horizontal");

            Vector3 survivorMovement = transform.right * survivorX + transform.forward * survivorZ;

            survivorCC.Move(survivorMovement * walkSpeed * Time.deltaTime);

            // Animations
            survivorAnim.SetFloat("SurvivorVertical", Input.GetAxis("Vertical"), 0.05f, Time.deltaTime);
            survivorAnim.SetFloat("SurvivorHorizontal", Input.GetAxis("Horizontal"), 0.05f, Time.deltaTime);

        }

        /*if(survivorHealth == 0)
        {
            survivorDeadPanel.SetActive(true);
        }*/
    }

    /*public void SurvivorTakesDamage()
    {
        view.RPC("SurvivorTakesDamageRPC", RpcTarget.All);
    }

    [PunRPC]
    void SurvivorTakesDamageRPC()
    {
        survivorHealth -= 10f;
    }*/
}

