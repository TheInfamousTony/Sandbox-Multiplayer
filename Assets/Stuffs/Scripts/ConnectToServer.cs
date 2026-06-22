using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField usernameInputField;
    public Text buttonText;
    public GameObject loading;

    public void OnClickConnect()
    {
        if(usernameInputField.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInputField.text;
            buttonText.text = "Connecting...";
            loading.SetActive(true);
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}
