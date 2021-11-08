using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueInimigo : MonoBehaviour
{
    public float TempoEntreAtaque = 0.5f;
    public int DanoAtaque = 10;
    ControlaVida VidaJogador;
    Animator anim;
    GameObject Jogador;
    bool PodeAtacar;
    float timer;
    VidaDoInimigo vidaDoInimigo;


    void Awake()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        VidaJogador = Jogador.GetComponent<ControlaVida>();
        vidaDoInimigo = GetComponent<VidaDoInimigo>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Jogador)
        {
            PodeAtacar = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Jogador)
        {
            PodeAtacar = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= TempoEntreAtaque && PodeAtacar == true && vidaDoInimigo.VidaAtualInimigo > 0)
        {
            Ataque();
        }   
        if(ControlaVida.Vida <= 0)
        {
            //Aqui coloca a animaçãio de morte
        }
    }

    void Ataque()
    {
        timer = 0f;

        if(ControlaVida.Vida > 0)
        {  
            VidaJogador.TomaDano(DanoAtaque);
        }
    }
}
