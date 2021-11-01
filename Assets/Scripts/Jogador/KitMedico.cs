using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitMedico : MonoBehaviour
{
    private GameObject jogador;
    public static bool PegouKit;
    public int Cura = 50;
    public static int QuantidadeCura;

    void Start()
    {
        jogador = GameObject.FindWithTag("Jogador");
        QuantidadeCura = Cura;
    }

    private void OnTriggerStay(Collider colisor)
    {
        if(Input.GetKeyDown("e") &&  colisor.gameObject == jogador.gameObject)
        {
            PegouKit = true;

            Destroy(gameObject);
        }
    }
}
