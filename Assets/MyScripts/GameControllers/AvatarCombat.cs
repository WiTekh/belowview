using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AvatarCombat : MonoBehaviour
{
    private PhotonView PV;
    private AvatarSetup avatarSetup;
    public Transform rayOrg;
    private Text healthUI;
    private float t;

    //Heavy
    public GameObject HVInstatiator;
    public float HVrate;

    //Wizard
    public GameObject WZInstantiator;
    public float WZrate;

    //Ghost
    public GameObject ASInstantiator;
    public float ASrate;

    //Particles
    //HeavyEffect
    public GameObject HVParticles;

    public GameObject HVImpactEffect;

    //GhostEffect
    public GameObject ASParticles;

    public GameObject ASImpactEffect;

    //Wizard
    public GameObject WZParticles;
    public GameObject WZImpactEffect;

    private float HVnextFire;
    private float WZnextFire;
    private float ASnextFire;
    void Start()
    {
        PV = GetComponent<PhotonView>();
        avatarSetup = GetComponent<AvatarSetup>();
        healthUI = GameSetup.GS.healthUI;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Check if i am the local player
        if (!PV.IsMine)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            PV.RPC("RPC_Shooting", RpcTarget.All);
        }

        healthUI.text = avatarSetup.playerHealth.ToString();
    }

    //Shooting thru network
    //Everything that require a specific player's input should be here

    [PunRPC]
    void RPC_Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrg.position, rayOrg.TransformDirection(Vector3.forward), out hit, 1000))
        {
            Debug.DrawRay(rayOrg.position, rayOrg.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("HIT!");
            if (hit.transform.CompareTag("Avatar"))
            {
                hit.transform.gameObject.GetComponent<AvatarSetup>().playerHealth -= avatarSetup.playerDamage;
            }
        }
        else
        {
            Debug.DrawRay(rayOrg.position, rayOrg.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("Try again");
        }

        if (PlayerInfo.PI.mySelectedCharacter == 0 && Time.time >= WZnextFire) //Wizard
        {
            WZnextFire = Time.time + 1f/WZrate;
            GameObject WZMuzzleGO = Instantiate(WZParticles, WZInstantiator.transform.position, gameObject.transform.rotation);
            Destroy(WZMuzzleGO, 0.7f);
            GameObject WZImpactGO = Instantiate(WZImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(WZImpactGO, 2f);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 80f);
            }
        }

        if (PlayerInfo.PI.mySelectedCharacter == 1) //Heavy
        {
            GameObject HVMuzzleGO = Instantiate(HVParticles, HVInstatiator.transform.position, gameObject.transform.rotation);
            Destroy(HVMuzzleGO, 0.7f);
            GameObject HVImpactGO = Instantiate(HVImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(HVImpactGO, 2f);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 150f);
            }
        }

        if (PlayerInfo.PI.mySelectedCharacter == 2) //Assassin
        {
            GameObject ASMuzzleGO = Instantiate(ASParticles, ASInstantiator.transform.position,
                gameObject.transform.rotation);
            Destroy(ASMuzzleGO, 0.7f);
            GameObject ASImpactGO = Instantiate(ASImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ASImpactGO, 2f);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 70f);
            }
        }
    }

    [PunRPC]
    void RPC_Spell()
    {
        RaycastHit hit2;
        if (Input.GetKeyDown(KeyCode.Q)) //Knockback
        {
            if (PlayerInfo.PI.mySelectedCharacter == 0) //TimeDude
            {
                Physics.Raycast(rayOrg.position, rayOrg.TransformDirection(Vector3.forward), out hit2, 1000);
                if (hit2.transform.CompareTag("Avatar"))
                {
                    hit2.transform.gameObject.GetComponent<AvatarSetup>().playerHealth -= avatarSetup.playerDamage/2;
                }

                if (hit2.rigidbody != null)
                {
                    hit2.rigidbody.AddForce(-hit2.normal * 100f);
                }
                GameObject WZMuzzleGO = Instantiate(WZParticles, WZInstantiator.transform.position, gameObject.transform.rotation);
                Destroy(WZMuzzleGO, 0.7f);
            }
            if (PlayerInfo.PI.mySelectedCharacter == 1) //RocketMan
            {
                
            } 
            if (PlayerInfo.PI.mySelectedCharacter == 2) //GhostGuy
            {
                
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) //RocketMan
        {
            if (PlayerInfo.PI.mySelectedCharacter == 0) //TimeDude
            {
                
            }
            if (PlayerInfo.PI.mySelectedCharacter == 1) //RocketMan
            {
                
            } 
            if (PlayerInfo.PI.mySelectedCharacter == 2) //GhostGuy
            {
                
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) //GhostGuy
        {
            if (PlayerInfo.PI.mySelectedCharacter == 0) //TimeDude
            {
                
            }
            if (PlayerInfo.PI.mySelectedCharacter == 1) //RocketMan
            {
                
            } 
            if (PlayerInfo.PI.mySelectedCharacter == 2) //GhostGuy
            {
                
            }
        }
    }
}
