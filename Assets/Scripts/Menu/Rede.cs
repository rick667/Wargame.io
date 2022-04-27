using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Rede : MonoBehaviourPunCallbacks
{
    public static Rede Instancia { get; private set; }

    private void Awake()
    {
        if(Instancia != null && Instancia != this)
        {
            gameObject.SetActive(false);
            return;
        }
        Instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connection suceful");
    }
}
