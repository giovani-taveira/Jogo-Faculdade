using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitMedico : MonoBehaviour
{
    public static bool PegouKit;
    private void OnTriggerEnter(Collider objetoDeColisao)
    {
        if(objetoDeColisao.tag == "Jogador" && ControlaVida.Vida < 100)
        {
            PegouKit = true;
            Destroy(gameObject);
        }
    }
}
