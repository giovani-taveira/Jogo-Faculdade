using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleProgresso : MonoBehaviour
{
    public GameObject Parede1, Parede2, TriggerInimigo1, TriggerInimigo2;
    string CenaAtual;
    public static bool AvancouParaOBoss = false, AtivaMusica1, AtivaMusica2, AtivaMusica3, DesativaMusica;
    public static bool SalvaXP, SalvaVida, SalvaMunicao, SalvaPosicao, SalvaMateriais, SalvaCena;
    public static bool DiminuiAudio1, DiminuiAudio2;
     
    void Start()
    {
        CenaAtual = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        ProgressController();
    }

    void ProgressController()
    {
        if(CenaAtual == "CasaJeffrey3")
        {

        }

        if(CenaAtual == "Fase2-Floresta")
        {
            if(ControladorInimigo.InimigosMortos == 19)
            {
                Parede1.GetComponent<BoxCollider>().isTrigger = true;
                DiminuiAudio1 = true;
            }

            if(ControladorInimigo.InimigosMortos == 44)
            {
                Parede1.GetComponent<BoxCollider>().isTrigger = true;
                AvancouParaOBoss = true;
                DiminuiAudio2 = true;
            }
        }


        if(CenaAtual == "Cena-Milton")
        {
            if(ControladorInimigo.InimigosMortos == 3)
            {
                Parede1.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }

    void OnTriggerEnter(Collider colider)
    {
        if(colider.gameObject.tag == "CheckPoint" )
        {  
            SalvaInformacoes();       
        }

        if(colider.gameObject.tag == "CheckPoint2")
        {
            SalvaInformacoes();
        }
    }



    void SalvaInformacoes()
    {
        SalvaXP = true;
        SalvaVida = true;
        SalvaMunicao = true;
        SalvaPosicao = true;
        SalvaMateriais = true;
        SalvaCena = true;
        DesativaMusica = true;
        AtivaMusica1 = false;
        AtivaMusica2 = false;
        AtivaMusica3 = false;
    }
}
