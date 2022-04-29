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
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
        {
            try
            {
                _player = GameObject.FindWithTag("Player"); 
                transform.Rotate(new Vector3(70,0,0));
                if(_player != null)
                {
                    gameObject.transform.SetParent(_player.transform);
                }

            }
            catch
            {
                _player = null;
            } 
        }

        if(photonView.IsMine && _player != null)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y +10, _player.transform.position.z -3.5f);
        }

    }
}
