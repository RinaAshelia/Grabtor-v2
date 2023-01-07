using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class NetworkManager : MonoBehaviourPunCallbacks
{
 void Start()
 {
 ConnectToServer();
 }
 void ConnectToServer()
 {
 PhotonNetwork.ConnectUsingSettings();
 Debug.Log("PhotonLogin: Verbindung zum Server wird hergestellt...");
 }
 public override void OnConnectedToMaster()
 {
 Debug.Log("Verbunden zum Server.");
 base.OnConnectedToMaster();
 RoomOptions roomOptions = new RoomOptions();
 roomOptions.MaxPlayers = 10;
 roomOptions.IsVisible = true;
 roomOptions.IsOpen = true;
 PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
 }
 public override void OnJoinedRoom()
 {
 Debug.Log("Joined a Room");
 base.OnJoinedRoom();
 }
 public override void OnPlayerEnteredRoom(Player newPlayer)
 {
 Debug.Log("Ein neuer Teilnehmer hat den Raum betreten.");
 base.OnPlayerEnteredRoom(newPlayer);
 }
}