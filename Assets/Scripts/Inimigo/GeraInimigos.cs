using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraInimigos : MonoBehaviour
{
    public GameObject Inimigo;
    float Contador = 0;
    public float TempoGeraInimigo = 1;
    void Start()
    {

    }

    void Update()
    {
        CriaInimigo();           
    }

    void CriaInimigo()
    {
        //Controla o tempo em que cada inimigo será gerado
        Contador += Time.deltaTime;
        if(Contador >= TempoGeraInimigo + 2)
        {
            Instantiate(Inimigo, transform.position, transform.rotation);
            Contador = 0;
            VidaInimigo.vidaAtualInimigo = 100;
        }
    }
}
