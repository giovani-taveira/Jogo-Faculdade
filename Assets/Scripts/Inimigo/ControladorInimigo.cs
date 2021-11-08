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

    void Start()
    {
        QuantidadeInimigoAtual = 0;
        InvokeRepeating("Spawn", TempoSpawn, TempoSpawn);
    }

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
