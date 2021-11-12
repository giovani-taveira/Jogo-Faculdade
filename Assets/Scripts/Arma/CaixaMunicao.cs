using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaixaMunicao : MonoBehaviour
{
    private GameObject jogador;
    public static bool PegouMunicao;
    void Start()
    {
        jogador = GameObject.FindWithTag("Jogador");
    }

    private void OnTriggerStay(Collider colisor)
    {
        if(Input.GetKeyDown("e") &&  colisor.gameObject == jogador.gameObject)
        {
            PegouMunicao = true;
            if(PlayerShoot.FoiRecarregado == true)
            {
                Destroy(gameObject);
                PlayerShoot.FoiRecarregado = false;
            }
        }
    }
}
