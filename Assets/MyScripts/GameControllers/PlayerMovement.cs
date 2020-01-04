using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun
{
    public static PlayerMovement PM;
    private PhotonView PV;

    private CharacterController myCC;

    public float movementSpeed;
    public float rotationSpeed;
    public float jumpForce;

    void Start()
    {
        enabled = photonView.IsMine;
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
    }

    void Update()
    {
        BasicMovement();
        BasicRotation();
    }

    void BasicMovement()
    {
        if (Input.GetKey(KeyCode.Z)) //Z
        {
            myCC.Move(transform.forward * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.Q)) //Q
        {
            myCC.Move(-transform.right * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S)) //S
        {
            myCC.Move(-transform.forward * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D)) //D
        {
            myCC.Move(transform.right * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myCC.Move(transform.up * jumpForce);
        }
    }

    void BasicRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.Rotate(new Vector3(0, mouseX, 0));
    }
}
