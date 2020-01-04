using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEditor;
using UnityEngine;

public class Spell : MonoBehaviour
{
   private PhotonView PV;
   private bool IsTimeDude;

   public char QSpell;
   private int QCD;
   
   // Using LeftShift instead of W key (Cause already bind to forward movement)
   private int WCD;
   
   public char ESpell;
   private int ECD;
   
   public char Ultimate;
   private int UCD;

   public GameObject rocket;
   
   void Start()
   {
      PV = GetComponent<PhotonView>();
      if (PlayerInfo.PI.mySelectedCharacter == 0)
      {
         IsTimeDude = true;
      }
      if (PlayerInfo.PI.mySelectedCharacter == 1)
      {
         IsTimeDude = false;
      }
   }

   private void Update()
   {
      /*if (Input.GetKeyDown(QSpell.ToString()))
      {
         if (IsTimeDude)
         {
            Time.timeScale = 0.5f;
            PlayerMovement.PM.movementSpeed = PlayerMovement.PM.movementSpeed * 2;
            PlayerMovement.PM.rotationSpeed = PlayerMovement.PM.rotationSpeed * 2;
         }
         else
         {
            Debug.Log("Should Have Instantiated");
            Instantiate(rocket, PhotonPlayer.PP.myAvatar.transform.position, Quaternion.identity);
         }
      }
      if (Input.GetKeyDown(KeyCode.LeftShift))
      {
         if (IsTimeDude)
         {
            
         }
         else
         {
            
         }
      }
      if (Input.GetKeyDown(ESpell.ToString()))
      {
         if (IsTimeDude)
         {
            
         }
         else
         {
            
         }
      }
      if (Input.GetKeyDown(Ultimate.ToString()))
      {
         if (IsTimeDude)
         {
            
         }
         else
         {
            
         }
      }*/
   }
}