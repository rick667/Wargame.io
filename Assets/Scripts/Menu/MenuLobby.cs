using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class MenuLobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _playersOnline;
    [SerializeField] private Button _initiateGame;

    [PunRPC]
    public void UpdateList()
    {
        _playersOnline.text = Rede.Instancia.GetPlayersList();
    }
}
