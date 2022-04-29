using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using Photon.Pun;

public class Move : MonoBehaviourPunCallbacks
{
    [SerializeField] private float spd = 5f;
    [SerializeField] private Rigidbody _rb;
    public Rigidbody Rb {get => _rb; set => _rb = value;}
    private Player _photonPlayer;
    private Camera _camera;
    private int _id;

    public void Inicialize(Player player)
    {
        _photonPlayer = player;
        _id = player.ActorNumber;
        //GameManager.Instancia.Players.Add(this);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(photonView.IsMine)
        {
            Movement();
        }
    }

    public void Movement()
    {
        if(Input.GetKey("right"))
        {
            transform.position += new Vector3(spd, 0, 0);

        }
        else if(Input.GetKey("left"))
        {
            transform.position -= new Vector3(spd, 0, 0);
        }
        if(Input.GetKey("up"))
        {
            transform.position += new Vector3(0, 0, spd);
        }
        else if(Input.GetKey("down"))
        {
            transform.position -= new Vector3(0, 0, spd);
        }
    }
}
