using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MenuSO : MonoBehaviourPunCallbacks
{

    [SerializeField] private MenuEntrada _menuEntrada;
    // Start is called before the first frame update
    private void Start()
    {
        _menuEntrada.gameObject.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        _menuEntrada.gameObject.SetActive(true);
    }

}
