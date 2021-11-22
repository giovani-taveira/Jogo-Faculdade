using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    string CenaAtual;

    void Start()
    {
        QuantidadeInimigoAtual = 0;
        InvokeRepeating("Spawn", TempoSpawn, TempoSpawn);
        CenaAtual = SceneManager.GetActiveScene().name;


    }

    void Update()
    {
        if(SpawnsZerados == PontosDeSpawn.Length )
        {
            Debug.Log("Spwns Zerados");

        }

        if(VidaDoInimigo.DestruiuInimigo)
        {
            InimigosMortos++;
            VidaDoInimigo.DestruiuInimigo = false;
        }
        if(InimigosMortos == 5 && CenaAtual == "CasaJeffrey3")
        {
            //SceneLoader.Instance.LoadSceneAsync("CasaFrank2");
            SceneManager.LoadScene("CasaFrank2");
        }  
        if(a)
        {
            SpawnsZerados += 1;
            a = false;
        }
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
