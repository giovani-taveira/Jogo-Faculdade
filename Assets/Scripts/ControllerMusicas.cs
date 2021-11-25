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

        MusicaBatalha1.GetComponent<AudioSource>().volume = 0;
        MusicaBatalha2.GetComponent<AudioSource>().volume = 0;
        MusicaBoss.GetComponent<AudioSource>().volume = 0;
    }

    void Update()
    {
        AtivaMusica();
        DesativaMusica();

        if(ControleProgresso.DiminuiAudio1)
            DiminuiAudio(MusicaBatalha1);

        if(ControleProgresso.DiminuiAudio2)
            DiminuiAudio(MusicaBatalha2);

        if(VidaDoInimigo.DiminuiMusicaBoss)
            DiminuiAudio(MusicaBoss);
    }

    void AtivaMusica()
    {
        if(ControlaEventos.AtivaMusica1)
        {
            MusicaBatalha1.SetActive(true);
            AumentaAudio(MusicaBatalha1);
            StartCoroutine(TempoAumentaAudio(3f));   
        }

        if(ControlaEventos.AtivaMusica2)
        {
            MusicaBatalha2.SetActive(true);
            AumentaAudio(MusicaBatalha2);
            StartCoroutine(TempoAumentaAudio(3f));
        }

        if(ControlaEventos.AtivaMusica3)
        {
            MusicaBoss.SetActive(true);
            AumentaAudio(MusicaBoss);
            StartCoroutine(TempoAumentaAudio(3f));
        }   
    }

    void DesativaMusica()
    {
        if(ControlaEventos.DesativaMusica)
        {
            MusicaBatalha1.SetActive(false);
            MusicaBatalha2.SetActive(false);
            MusicaBoss.SetActive(false);
            ControlaEventos.DesativaMusica = false;
        }
    }

    public void DiminuiAudio(GameObject audio)
    {
        if(audio.GetComponent<AudioSource>().volume > -1)
        {
            audio.GetComponent<AudioSource>().volume -= 0.01f;
        }
    }

    public void AumentaAudio(GameObject audio)
    {
        if(audio.GetComponent<AudioSource>().volume < 1)
        {
            audio.GetComponent<AudioSource>().volume += 0.01f;
        }
    }

    public IEnumerator TempoAumentaAudio(float tempo)
    {       
        yield return new WaitForSeconds(tempo);
        ControlaEventos.AtivaMusica1 = false;
        ControlaEventos.AtivaMusica2 = false;
        ControlaEventos.AtivaMusica3 = false;
        
        StopCoroutine(TempoAumentaAudio(tempo));     
    }
}
