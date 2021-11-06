using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public int DanoPorTiro = 20;
    public float TempoPorTiro = 0.15f;
    public float Alcance = 100f;

    float timer;
    Ray RaioTiro;
    RaycastHit HitTiro;
    int ShootableMask;
    ParticleSystem GunParticles;
    LineRenderer LinhaArma;
    AudioSource SomTiro;
    Light LuzTiro;
    float DuracaoEfeitoDisparo = 0.2f;

    void Awake()
    {
        ShootableMask = LayerMask.GetMask("Shootable");
        GunParticles = GetComponent<ParticleSystem>();
        LinhaArma = GetComponent<LineRenderer>();
        SomTiro = GetComponent<AudioSource>();
        LuzTiro = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetButton("Fire1") && timer >= TempoPorTiro)
        {
            Shoot();
        }
        if(timer >= TempoPorTiro * DuracaoEfeitoDisparo)
        {
            DesativarEfeitos();
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
        SomTiro.Play();

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
            {
                vidaInimigo.RecebeDano(DanoPorTiro, HitTiro.point);
            }
            LinhaArma.SetPosition(1, HitTiro.point);
        }
        else{
            LinhaArma.SetPosition(1,RaioTiro.origin + RaioTiro.direction * Alcance); 
        }
    }
}
