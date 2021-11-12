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
    public static bool DestruiuInimigo;
    bool EstaAfundando;
    public GameObject[] ItemDrop;

    public int ChanceDropItem = 0;

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
        DestruiuInimigo = true;
        int random = Random.Range(0, 10);
        if(random < ChanceDropItem && ItemDrop.Length > 0)
        {
           Instantiate(ItemDrop[Random.Range(0, ItemDrop.Length)], transform.position, Quaternion.identity);
        }

        EstaMorto = true;
        capsuleCollider.isTrigger = true;
        AfundaCorpo();
        XP.XPAtual += ValorPontos;
        // AudioInimigo.clip = deathClip;
        // AudioInimigo.Play(); 
    }

    public void AfundaCorpo()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        EstaAfundando = true;
        Destroy(gameObject, 2f);
        DestruiuInimigo = true;
    }
}
