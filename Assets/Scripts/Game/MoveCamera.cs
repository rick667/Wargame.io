using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MoveCamera : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            transform.position = new Vector3(_player.transform.position.x, 10, _player.transform.position.z);
        }
    }
}
