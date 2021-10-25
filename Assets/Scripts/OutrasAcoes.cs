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

    void Update()
    {
        PausaJogo();
    }

    void PausaJogo()
    {   
        if(Input.GetKeyDown(KeyCode.Escape) && EstaPausado == false)
        {
            Time.timeScale = 0;
            InterfacePause.SetActive(true);
            InterfaceGameplay.SetActive(false);
            EstaPausado = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && EstaPausado == true)
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
            Debug.Log("Apertou");
            EstaPausado = false;
            ClicouRetomar = false;
            InterfacePause.SetActive(false);
        }
    }

    public void Config()
    {
        InterfacePause.SetActive(false);
        InterfaceConfig.SetActive(true);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ConfigVoltar()
    {
        InterfaceConfig.SetActive(false);
        InterfacePause.SetActive(true);
    }

    public void Sair()
    {
        SceneManager.LoadScene(1);
    }
}
