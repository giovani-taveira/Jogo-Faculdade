using System.Runtime.InteropServices;
using UnityEngine;

public class MovimentaBala : MonoBehaviour
{
    public float Velocidade = 1;
    public static bool DestruiuInimigo = false;
    public static bool AcertouInimigo = false;
    public static bool acabouVida = false;
    public GameObject inimigo;


    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position +
            transform.forward * Velocidade * Time.deltaTime);
        
        Destroy(this.gameObject, 0.5f);
    }

    public void OnTriggerEnter(Collider colisor)
    {
        //Destruindo o Inimigo
        if(colisor.tag == "Inimigo")
        {
            if(VidaInimigo.vidaAtualInimigo > 0 && VidaInimigo.vidaAtualInimigo <= 100)
            {
                AcertouInimigo = true;      
            }
            if(VidaInimigo.vidaAtualInimigo <= 0 )
            {
                Destroy(colisor.gameObject);
                DestruiuInimigo = true;
                acabouVida = true;
            }
        }
        //Destruindo a Bala;
        Destroy(gameObject);
    }
}
