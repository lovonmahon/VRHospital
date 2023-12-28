using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField createInput;
    [SerializeField] InputField joinInput;
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }

   public void JoinRoom()
   {
       PhotonNetwork.JoinRoom(joinInput.text);
   }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("scene name here");//To join players on network
    }
}
