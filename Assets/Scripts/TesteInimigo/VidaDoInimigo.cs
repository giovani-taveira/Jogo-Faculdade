using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VidaDoInimigo : MonoBehaviour
{

    public int VidaMaxInimigo = 100;
    public int VidaAtualInimigo;
    public float TempoDestroiCorpo = 2.5f;
    public int ValorPontos = 10;
    //Aqui coloca o audio da morte 
    Animator anim;
    //AudioSource AudioInimigo;
    ParticleSystem ParticulaHit;
    CapsuleCollider capsuleCollider;
    bool EstaMorto;
    bool EstaAfundando;

    void Awake()
    {
        anim = GetComponent<Animator>();
        //AudioInimigo = GetComponent<AudioSource>();
        ParticulaHit = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        VidaAtualInimigo = VidaMaxInimigo;
    }


    void Update()
    {
        if(EstaAfundando)
        {
            transform.Translate(-Vector3.up * TempoDestroiCorpo * Time.deltaTime);
        }
    }

    public void RecebeDano(int dano, Vector3 hitPoint)
    {
        if(EstaMorto)
            return;

        //AudioInimigo.Play();
        VidaAtualInimigo -= dano;

        ParticulaHit.transform.position = hitPoint;
        ParticulaHit.Play();

        if(VidaAtualInimigo <= 0)
        {
            // anim.SetInteger("Morte", 1);
            Morte();
        }
    }

    public void Morte()
    {
        EstaMorto = true;
        capsuleCollider.isTrigger = true;
        AfundaCorpo();

        // AudioInimigo.clip = deathClip;
        // AudioInimigo.Play(); 
    }

    public void AfundaCorpo()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        EstaAfundando = true;
        Destroy(gameObject, 2f);
    }
}
