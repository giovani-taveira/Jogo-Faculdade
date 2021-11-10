using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    #region "Variaveis"
    [Space]
    [Header("Tiro")]
    public int DanoPorTiro = 20;
    public float TempoPorTiro = 0.15f, Alcance = 100f;
    float timer, DuracaoEfeitoDisparo = 0.2f;
    Ray RaioTiro;
    RaycastHit HitTiro;
    int ShootableMask;
    ParticleSystem GunParticles;
    LineRenderer LinhaArma;
    AudioSource audios;
    Light LuzTiro;
    public AudioClip SomTiro, SomRecarregar, SomSemBala;
    // public Animator animacao;

    [Space]
    [Header("Munição")]
    public int MaxMunicao;
    public int TempoRecarregar, MaxMunicaoNoPente;
    [HideInInspector]
    public int MunicaoAtual;
    public static int MaxMunicao2, MunicaoAtual2;
    public Text ContadorMunicao;
    public bool ArmaAutomatica;
    public float CadenciaDeTiro;
    private int TimeTr, MunicaoNoPenteAtual;
    private bool Recarregavel = true;
    private float ProximoTiro;
    public static bool FoiRecarregado;
    #endregion

    void Awake()
    {
        ShootableMask = LayerMask.GetMask("Shootable");
        GunParticles = GetComponent<ParticleSystem>();
        LinhaArma = GetComponent<LineRenderer>();
        audios = GetComponent<AudioSource>();
        LuzTiro = GetComponent<Light>();

        MunicaoAtual = MaxMunicao;
        MunicaoNoPenteAtual = MaxMunicaoNoPente;
        MaxMunicao2 = MaxMunicao;
        MunicaoAtual2 = MunicaoAtual;
        FoiRecarregado = false;
    }

    void Update()
    {
        
        if(MunicaoAtual > MaxMunicao)
            MunicaoAtual = MaxMunicao;

        if(CaixaMunicao.PegouMunicao && MunicaoAtual < MaxMunicao)
        {
            MunicaoAtual += MaxMunicaoNoPente;
            CaixaMunicao.PegouMunicao = false;
            FoiRecarregado = true;
        }


        ContadorMunicao.text = $"{MunicaoNoPenteAtual.ToString()}/{MunicaoAtual.ToString()}";
        timer += Time.deltaTime;

        Cadencia();
        RecarregaArma();

        if((Input.GetMouseButtonDown(0)) && OutrasAcoes.EstaPausado == false && MunicaoNoPenteAtual <= 0 && Time.time > ProximoTiro)
        {
             audios.clip = SomSemBala;
             audios.volume = 0.5f;
             audios.Play();
        }       
    }
    
    void RecarregaArma()
    { 
        if(Input.GetKeyDown("r") && MunicaoNoPenteAtual != MaxMunicaoNoPente && MunicaoAtual != 0 && Recarregavel == true)
        {   
            audios.clip = SomRecarregar;
            audios.Play();
            Recarregavel = false;
            
        }

        if(Recarregavel == false)
        {
            if(TimeTr > TempoRecarregar)
            {
                
                for(int i = 0; i < MaxMunicaoNoPente; i++)
                {
                    if(MunicaoNoPenteAtual < MaxMunicaoNoPente && MunicaoAtual > 0)
                    {
                        MunicaoAtual -= 1;
                        MunicaoNoPenteAtual += 1;
                    }
                    else
                    {
                        break;
                    }
                    Recarregavel = true;
                    TimeTr = 0;
                }
            }
            else
            {
                TimeTr += 1;
            }
        }
    }

    public void DesativarEfeitos()
    {
        LinhaArma.enabled = false;
        LuzTiro.enabled = false;
    }

    void Shoot()
    {
        // o timer abaixo recalcula a cadencia de tiro
        timer = 0f;
        audios.clip = SomTiro;
        audios.Play();

        LuzTiro.enabled = true;

        GunParticles.Stop();
        GunParticles.Play();

        LinhaArma.enabled = true;
        LinhaArma.SetPosition(0, transform.position); 

        RaioTiro.origin = transform.position;
        RaioTiro.direction = transform.forward;

        //Verifica se o objeto que colidiu com a bala tem um componente de vida para poder tirar vida

        if(Physics.Raycast(RaioTiro, out HitTiro, Alcance, ShootableMask))
        {
            VidaDoInimigo vidaInimigo = HitTiro.collider.GetComponent<VidaDoInimigo>();
            if(vidaInimigo != null)
                vidaInimigo.RecebeDano(DanoPorTiro, HitTiro.point);

            LinhaArma.SetPosition(1, HitTiro.point);
        }
        else
        {
            LinhaArma.SetPosition(1,RaioTiro.origin + RaioTiro.direction * Alcance); 
        }
    }

    void Cadencia()
    {
        if(ArmaAutomatica == false)
        {
            if((Input.GetMouseButtonDown(0)) && OutrasAcoes.EstaPausado == false && MunicaoNoPenteAtual > 0 && Time.time > ProximoTiro)
            {
                ProximoTiro = Time.time + CadenciaDeTiro;
                audios.volume = 1f;
                Shoot();
                MunicaoNoPenteAtual -= 1;
                
            }
        }
        else
        {
            if((Input.GetMouseButton(0)) && OutrasAcoes.EstaPausado == false && MunicaoNoPenteAtual > 0 && Time.time > ProximoTiro)
            {
                ProximoTiro = Time.time + CadenciaDeTiro;
                audios.volume = 1f;
                Shoot();
                MunicaoNoPenteAtual -= 1;
            }
        }

        if(timer >= TempoPorTiro * DuracaoEfeitoDisparo)
            DesativarEfeitos();
    }
}
