using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MenuSO : MonoBehaviourPunCallbacks
{

    [SerializeField] private MenuEntrada _menuEntrada;
    [SerializeField] private MenuLobby _menuLobby;
    // Start is called before the first frame update
    private void Start()
    {
        _menuEntrada.gameObject.SetActive(false);
        
        _menuLobby.gameObject.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        _menuEntrada.gameObject.SetActive(true);
    }
    public override void OnJoinedRoom()
    {
        MenuCharge(_menuLobby.gameObject);
        _menuLobby.photonView.RPC("UpdateList", RpcTarget.All);
    }    

    public void MenuCharge(GameObject menu)
    {
        _menuEntrada.gameObject.SetActive(false);
        
        _menuLobby.gameObject.SetActive(false);

        menu.SetActive(true); 
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        _menuLobby.UpdateList();
    }

    public void Exit()
    {
        Rede.Instancia.ExitLobby();
        MenuCharge(_menuEntrada.gameObject);
    }
    public void InitiateGame(string sceneName)
    {
        Rede.Instancia.InitiateGame(sceneName);
    }

}
