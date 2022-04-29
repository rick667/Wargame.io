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
    private bool _exist = false;
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
        if(photonView.IsMine)
        {

            //AddPlayer();
            _players = new List<Move>();
        }

    }

    private void Update()
    {
        if(_exist == false)
        {
            _exist = true;
            PhotonNetwork.Instantiate("Player", _spawns[Random.Range(0, _spawns.Length)].position, Quaternion.identity);
            PhotonNetwork.Instantiate("Camera", _spawns[Random.Range(0, _spawns.Length)].position, Quaternion.identity);

        }
    }

}
