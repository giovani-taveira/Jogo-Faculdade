using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorCenas : MonoBehaviour
{
    public string Cena;
    void Start()
    {
        Cena = PlayerPrefs.GetString("Cena");
    }

    // Update is called once per frame
    void Update()
    {
        AdmScenes();
    }

    void AdmScenes()
    {

    }
}
