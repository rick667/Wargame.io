using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instancia { get; private set; }

    [SerializeField] private string _localPrefab;  
    [SerializeField] private Transform[] _spawns;  

    private int _playersInGame = 0;
    private List<Move> _players;
    public List<Move> Players { get => _players; private set => _players = value; }


    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            gameObject.SetActive(false);
            return;
        }
        Instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
        _players = new List<Move>();
    }

    [PunRPC]
    private void AddPlayer()
    {
        _playersInGame++;
        if(_playersInGame == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }
    }

    private void CreatePlayer()
    {
        var playerObj = PhotonNetwork.Instantiate(_localPrefab, _spawns[Random.Range(0, _spawns.Length)].position, Quaternion.identity);
        var player = playerObj.GetComponent<Move>();

        PhotonNetwork.Instantiate("Player", _spawns[Random.Range(0, _spawns.Length)].position, Quaternion.identity);
    }

}
