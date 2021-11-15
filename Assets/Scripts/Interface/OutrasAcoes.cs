using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutrasAcoes : MonoBehaviour
{
    public static bool EstaPausado = false;
    public GameObject InterfacePause;
    public GameObject InterfaceConfig;
    public GameObject InterfaceGameplay;
    private bool ClicouRetomar = false;
    private bool EstaNaConfig;
    private bool ClicouVoltarConfig = false;
    private bool ClicouConfig = false;

    void Update()
    {
        PausaJogo();

        if(ClicouConfig)
            EstaNaConfig = true;


        if(ClicouVoltarConfig)
        {
            EstaNaConfig = false;
            InterfaceConfig.SetActive(false);
            InterfacePause.SetActive(true);
        }


        if(EstaNaConfig && Input.GetKeyDown(KeyCode.Escape))
        {
            ClicouVoltarConfig = true;
            
        }
    }

    void PausaJogo()
    {   
        if(Input.GetKeyDown(KeyCode.Escape) && !EstaPausado && !EstaNaConfig)
        {
            Time.timeScale = 0;
            InterfacePause.SetActive(true);
            InterfaceGameplay.SetActive(false);
            EstaPausado = true;
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && EstaPausado)
        {
            Time.timeScale = 1;
            InterfacePause.SetActive(false);
            InterfaceGameplay.SetActive(true);
            EstaPausado = false;
        }
    }

    public void RetomarJogo()
    {
        if(EstaPausado == true)
        {
            ClicouRetomar = true;
            Time.timeScale = 1;
            EstaPausado = false;
            ClicouRetomar = false;
            InterfacePause.SetActive(false);
            InterfaceGameplay.SetActive(true);
        }
    }

    public void Config()
    {
        InterfacePause.SetActive(false);
        InterfaceConfig.SetActive(true);
        ClicouConfig =  true;
        EstaNaConfig = true;

    }

    public void Reiniciar()
    {
        string cena = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(cena);
        Time.timeScale = 1;
        EstaPausado = false;
        InterfacePause.SetActive(false);
    }

    public void ConfigVoltar()
    {
        InterfaceConfig.SetActive(false);
        InterfacePause.SetActive(true);
        EstaNaConfig = false;
        ClicouVoltarConfig = true;
    }

    public void Sair()
    {
        SceneManager.LoadScene(1);
    }
}
