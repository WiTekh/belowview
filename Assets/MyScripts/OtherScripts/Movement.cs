using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{ 
    GameObject Player;
    private Transform pTransform;
    
    //Player Movement
    public float moveSpeed;
    public float jumpForce;

    public string forKey;
    public string backKey;
    public string leftKey;
    public string rightKey;

    public float jumpRate = 0.75f;
    
    private float nextJump;
    
    public void Start()
    {
        Player = gameObject;
        pTransform = Player.GetComponent<Rigidbody>().transform;
    }
    public void FixedUpdate()
    {
        //Player Movement
        if (Input.GetKey(forKey))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                pTransform.Translate(0.0f, 0.0f, 1.5f * moveSpeed * Time.deltaTime);
            }
            else
            {
                pTransform.Translate(0.0f, 0.0f, moveSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(backKey))
        {
            pTransform.Translate(0.0f, 0.0f, -(0.8f*moveSpeed * Time.deltaTime));
        }

        if (Input.GetKey(leftKey))
        {
            pTransform.Translate((-moveSpeed * Time.deltaTime)*0.9f, 0.0f, 0.0f);
        }
        
        if (Input.GetKey(rightKey))
        {
            pTransform.Translate(x: (moveSpeed * Time.deltaTime)*0.9f, 0.0f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextJump)
        {
            Player.GetComponent<Rigidbody>().AddForce(0.0f, jumpForce, 0.0f);

            nextJump = Time.time + jumpRate;
        }
    }
}