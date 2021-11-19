using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
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
    public Image BarraVidaBoss;
    public Text Txt_NomeBoss;
    public string NomeBoss;
    public static bool Dialogo = false;
    string CenaAtual;
    public bool EUmBoss = false;

    

    void Awake()
    {
        anim = GetComponent<Animator>();
        //AudioInimigo = GetComponent<AudioSource>();
        ParticulaHit = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        VidaAtualInimigo = VidaMaxInimigo;
    }

    void Start()
    {
        BarraVidaBoss.fillAmount = 1;
        Txt_NomeBoss.text = NomeBoss;
        CenaAtual = PlayerPrefs.GetString("Cena");

    }


    void Update()
    {
        if(EUmBoss)
        {
            BarraVidaBoss.fillAmount = (1/(float)VidaMaxInimigo) * VidaAtualInimigo;
            if(BarraVidaBoss.fillAmount <= 0 && CenaAtual == "Fase2-Floresta")
            {
                Dialogo = true;
            }
        }



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
            
            Morte();
        }
    }

    public void Morte()
    {
        anim.SetInteger("State", 1);
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
