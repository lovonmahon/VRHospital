using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    //Photon automatically calls 
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
