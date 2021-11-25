using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Materiais : MonoBehaviour
{
    private GameObject jogador;
    public static bool PegouMaterial;
    public int Qtd_Material;
    public static int QuantidadeMaterial = 10;
    public static int MateriaisAtuais;

    void Start()
    {
        QuantidadeMaterial = Qtd_Material;

       if(PlayerPrefs.HasKey("Materiais"))
        {
            LoadPrefs();   
            Debug.Log("Hello World");
        }
        else
        {
            MateriaisAtuais = 0;
            SavePrefs();
        }
    }

    void Update()
    {
        if(ControleProgresso.SalvaMateriais)
        {
            SavePrefs();
            ControleProgresso.SalvaMateriais = false;
        }
    }

    private void OnTriggerStay(Collider colisor)
    {
        if(Input.GetKeyDown("e"))
        {
            PegouMaterial = true;
            MateriaisAtuais += QuantidadeMaterial;
            ControlaEventos.DesativaText = true;
            Destroy(gameObject);
        }
    }

    void SavePrefs()
    {
        PlayerPrefs.SetInt("Materiais", MateriaisAtuais);
        PlayerPrefs.Save();
    }
    void LoadPrefs()
    {
        int mat = PlayerPrefs.GetInt("Materiais");
        MateriaisAtuais = mat;
    }
}