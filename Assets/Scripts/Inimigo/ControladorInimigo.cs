using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
    public ControlaVida VidaJogador;
    public GameObject Inimigo;
    public float TempoSpawn = 3f;
    public int MaxQuantidadoInimigo;
    public int QuantidadeInimigoAtual;
    public Transform[] PontosDeSpawn;
    public static int InimigosMortos;
    public bool a;
    public int SpawnsZerados;
    public bool colidiu;



    void Start()
    {
        QuantidadeInimigoAtual = 0;
        InvokeRepeating("Spawn", TempoSpawn, TempoSpawn);

    }

    void Update()
    {
        if(SpawnsZerados == PontosDeSpawn.Length )
        {
            Debug.Log("Spwns Zerados");
             //gameObject.tag == "Trigger4";
            //gameObject.isTrigger = true;
        }

        if(VidaDoInimigo.DestruiuInimigo)
        {
            InimigosMortos++;
            VidaDoInimigo.DestruiuInimigo = false;
        }
        if(InimigosMortos == MaxQuantidadoInimigo)
        {
            a = true;
            
            //Debug.Log("Inimigos Mortos");
        }  
        if(a)
        {
            SpawnsZerados += 1;
            a = false;
        }
    } 
    // void OnCollisionEnter(Collision collision )
    // {
    //     if(collision.gameObject.tag == "Trigger4")
    //     {
    //         colidiu = true;
    //     }
    // }

    void Spawn()
    {
        if(ControlaVida.Vida <= 0f)
        {
            return;
        }
        if(QuantidadeInimigoAtual < MaxQuantidadoInimigo )
        {
            int PontosDeSpawnIndex = Random.Range(0, PontosDeSpawn.Length);
            Instantiate(Inimigo, PontosDeSpawn[PontosDeSpawnIndex].position, PontosDeSpawn[PontosDeSpawnIndex].rotation);
            QuantidadeInimigoAtual ++;
        } 
    }
}
