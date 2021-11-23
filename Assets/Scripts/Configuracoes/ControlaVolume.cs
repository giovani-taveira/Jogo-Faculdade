using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaVolume : MonoBehaviour
{
    float VolumePrincipal, VolumeMusica, VolumeEfeitosSonoros;
    public Slider SliderMaster, SliderMusicas;

    void Start()
    {
        if(PlayerPrefs.HasKey("Master") && PlayerPrefs.HasKey("Musica"))
        {
            LoadPrefsVolume();
        }
        else
        {
            SliderMaster.value = 1;
            SliderMusicas.value = 1;
            //SavePrefsVolume();
            PlayerPrefs.SetFloat("Master", VolumePrincipal);  
            PlayerPrefs.SetFloat("Musica", VolumeMusica);
        }
    }

    void Update()
    {
        //SavePrefsVolume();
    }

    public void VolumeMaster(float volume)
    {
        VolumePrincipal = volume;
        AudioListener.volume = VolumePrincipal; 
        PlayerPrefs.SetFloat("Master", VolumePrincipal);  
        PlayerPrefs.Save();
    }

    public void VolumeDaMusica(float volume)
    {
        VolumeMusica = volume;
        GameObject[] Vlm = GameObject.FindGameObjectsWithTag("Musica");
        for(int i = 0; i < Vlm.Length; i++)
        {
            Vlm[i].GetComponent<AudioSource>().volume = VolumeMusica;
        } 
            PlayerPrefs.SetFloat("Musica", VolumeMusica);
            PlayerPrefs.Save();     
    }

    public void VolumeDosEfeitos(float volume)
    {
        VolumeEfeitosSonoros = volume;
        GameObject[] Vles = GameObject.FindGameObjectsWithTag("EfeitoSonoro");
        for(int i = 0; i < Vles.Length; i++)
        {
            Vles[i].GetComponent<AudioSource>().volume = VolumeEfeitosSonoros;
        }     
    }

    void SavePrefsVolume()
    {
        PlayerPrefs.Save();
    }

    void LoadPrefsVolume()
    {
        SliderMaster.value = PlayerPrefs.GetFloat("Master");
        SliderMusicas.value = PlayerPrefs.GetFloat("Musica");
    }
}
