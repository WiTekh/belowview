using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using Photon.Pun; 
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{
    public static AvatarSetup AS;
    
    private PhotonView PV;
    public int characterValue;
    public GameObject myCharacter;

    public int playerHealth;
    public int playerDamage;

    public Camera myEyes;
    public AudioListener myEars;
    
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            if (PlayerInfo.PI.mySelectedCharacter == 0)
            {
                playerHealth = 2000;
                playerDamage = 2;
            }

            if (PlayerInfo.PI.mySelectedCharacter == 1)
            {
                playerHealth = 3000;
                playerDamage = 1;
            }

            if (PlayerInfo.PI.mySelectedCharacter == 2)
            {
                playerHealth = 1000;
                playerDamage = 3;
            }
            
            PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedCharacter);
        }
        else
        {
            Destroy(myEyes);
            Destroy(myEars);
        }
    }

    [PunRPC]
    void RPC_AddCharacter(int whichOne)
    {
        characterValue = whichOne;
        myCharacter = Instantiate(PlayerInfo.PI.allCharacters[whichOne], transform.position, transform.rotation, transform);
    }
}
