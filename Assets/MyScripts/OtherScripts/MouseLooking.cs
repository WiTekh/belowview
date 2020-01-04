﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooking : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private GameObject cam;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
 
 void Start ()
 {
     cam = GameObject.Find("eyes");
     var pRot = transform.localRotation.eulerAngles;
     var cRot = cam.transform.rotation.eulerAngles;
     rotY = pRot.y;
     rotX = cRot.x;
 }

 void Update()
 {
     var mouseX = Input.GetAxis("Mouse X");
     var mouseY = -Input.GetAxis("Mouse Y");

     rotY += mouseX * mouseSensitivity * Time.deltaTime;
     rotX += mouseY * mouseSensitivity * Time.deltaTime;

     rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

     Quaternion playerRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
     Quaternion cameraRotation = Quaternion.Euler(rotX, rotY, 0.0f);
     
     transform.rotation = playerRotation;
     cam.transform.rotation = cameraRotation;
 }
}
