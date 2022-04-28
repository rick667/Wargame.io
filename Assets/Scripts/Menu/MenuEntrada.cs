using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEntrada : MonoBehaviour
{
    [SerializeField]private Text _nomeDoJogador;

    public void CriarSala()
    {
        Rede.Instancia.CriarSala("Campo de batalha");
        Rede.Instancia.MudarNick(_nomeDoJogador.text);
    }

}
