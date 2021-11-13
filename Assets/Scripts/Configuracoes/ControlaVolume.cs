using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaVolume : MonoBehaviour
{
    float VolumePrincipal, VolumeMusica, VolumeEfeitosSonoros;
    public Slider SliderMaster, SliderEfeitos, SliderMusicas;

    void Start()
    {
        SliderMaster.value = PlayerPrefs.GetFloat("Master");
        SliderEfeitos.value = PlayerPrefs.GetFloat("Efeitos");
        SliderMusicas.value = PlayerPrefs.GetFloat("Musicas");
    }

    void Update()
    {
        
    }

    public void VolumeMaster(float volume)
    {
        VolumePrincipal = volume;
        AudioListener.volume = VolumePrincipal;

        PlayerPrefs.SetFloat("Master", VolumePrincipal);
    }

    public void VolumeDaMusica(float volume)
    {
        VolumeMusica = volume;
        GameObject[] Vlm = GameObject.FindGameObjectsWithTag("Musica");
        for(int i = 0; i < Vlm.Length; i++)
        {
            Vlm[i].GetComponent<AudioSource>().volume = VolumeMusica;
        }
        PlayerPrefs.SetFloat("Musicas", VolumeMusica);
    }

    public void VolumeDosEfeitos(float volume)
    {
        VolumeEfeitosSonoros = volume;
        GameObject[] Vles = GameObject.FindGameObjectsWithTag("EfeitoSonoro");
        for(int i = 0; i < Vles.Length; i++)
        {
            Vles[i].GetComponent<AudioSource>().volume = VolumeEfeitosSonoros;
        }
        PlayerPrefs.SetFloat("Efeitos", VolumeEfeitosSonoros);
    }
}
