﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connects to Photon master servers
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Hey ! We are connected to " + PhotonNetwork.CloudRegion + " server!");
    }
}