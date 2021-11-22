using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimentaInimigo : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    VidaDoInimigo vidaInimigo;
    ControlaVida vidaPlayer;
    void Start()
    {
    
    }

    void Awake()
    {
        player = GameObject.FindWithTag("Jogador").transform;
        vidaPlayer = player.GetComponent<ControlaVida>();
        vidaInimigo = GetComponent<VidaDoInimigo>();
        nav = GetComponent<NavMeshAgent>();

    }


    void Update()
    {
        if(vidaInimigo.VidaAtualInimigo > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
        
    }
}
