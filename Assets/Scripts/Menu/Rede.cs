using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Rede : MonoBehaviourPunCallbacks
{
    public static Rede Instancia { get; private set; }

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            gameObject.SetActive(false);
            return;
        }
        Instancia = this;
        DontDestroyOnLoad (gameObject);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CriarSala(string nomeSala)
    {
        PhotonNetwork.JoinOrCreateRoom(nomeSala, new RoomOptions{MaxPlayers = 20}, TypedLobby.Default);
    }

    public void MudarNick(string nickname)
    {
        PhotonNetwork.NickName = nickname;
    }

    public string GetPlayersList()
    {
        var list = "";
        foreach (var player in PhotonNetwork.PlayerList)
        {
            list += player.NickName + "\n";
        }
        return list;
    }

    public void ExitLobby()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void InitiateGame(string sceneName)
    {

        PhotonNetwork.LoadLevel(sceneName);
    }
}
