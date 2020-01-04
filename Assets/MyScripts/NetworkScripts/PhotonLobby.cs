using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;

    public GameObject cancelButton;
    public GameObject battleButton;

    private void Awake()
    {
        lobby = this; //Creates the singleton, lives within the Main menu scene
    }
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connects to Matser photon server
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("Player has connected to the Photon master server");
        battleButton.SetActive(true); //Player is now connected to servers, he can now use Matchmaking
    }

    public void OnBattleButtonClick()
    {
        PhotonNetwork.JoinRandomRoom();
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        Debug.Log("Battle Button Clicked");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("There's no room available now, creating a New room ...");
        CreateRoom();
    }

    void CreateRoom()
    {
        var randomRoomName = Random.Range(0, 10000); 
        var roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 6};
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps); 
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Hey Dude ! We are now in a room, woow");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed Creating a new room, another room must be having the same name, trying again ...");
        CreateRoom();
    }

    public void OnCancelButtonClick()
    {
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
        Debug.Log("Cancel Button Clicked");
    }
}
