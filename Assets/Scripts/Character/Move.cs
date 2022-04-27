using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Move : MonoBehaviourPun
{
    public float spd = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(photonView.IsMine){
            if(Input.GetKey("right")){
                transform.position += new Vector3(spd, 0, 0);
            }else if (Input.GetKey("left")){
                transform.position -= new Vector3(spd, 0, 0);
            } 
            if (Input.GetKey("up")){
                transform.position += new Vector3(0, 0, spd);
            }else if (Input.GetKey("down")){
                transform.position -= new Vector3(0, 0, spd);
            }

            if(Input.GetKeyUp("space")){
                GetComponent<Rigidbody>().AddForce(new Vector3(0,5f, 0), ForceMode.Impulse);
            }
        }
    }
}
