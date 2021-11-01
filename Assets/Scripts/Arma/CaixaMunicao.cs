using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(gameObject);
        }
    }
}
