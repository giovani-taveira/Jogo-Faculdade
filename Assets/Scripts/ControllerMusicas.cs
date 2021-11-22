using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMusicas : MonoBehaviour
{

    public GameObject MusicaBatalha1, MusicaBatalha2, MusicaBoss;

    void Start()
    {
        MusicaBatalha1.SetActive(false);
        MusicaBatalha2.SetActive(false);
        MusicaBoss.SetActive(false);
    }

    void Update()
    {
        AtivaMusica();
        DeativaMusica();
    }

    void AtivaMusica()
    {
        if(ControlaEventos.AtivaMusica1)
        {
            MusicaBatalha1.SetActive(true);
        }

        if(ControlaEventos.AtivaMusica2)
        {
            MusicaBatalha2.SetActive(true);
        }


        if(ControlaEventos.AtivaMusica3)
        {
            MusicaBoss.SetActive(true);
        }   
    }

    void DeativaMusica()
    {
        if(ControlaEventos.DesativaMusica)
        {
            MusicaBatalha1.SetActive(false);
            MusicaBatalha2.SetActive(false);
            MusicaBoss.SetActive(false);
            ControlaEventos.DesativaMusica = false;

        }
    }
}
