using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesMenuPrincipal : MonoBehaviour
{

    public void Iniciar()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        OutrasAcoes.EstaPausado = false;
    }
}
