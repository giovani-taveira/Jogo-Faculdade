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

    // Start is called before the first frame update
    void Start()
    {
        MateriaisAtuais = 0;
        QuantidadeMaterial = Qtd_Material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider colisor)
    {
        if(Input.GetKeyDown("e"))
        {
            PegouMaterial = true;
            MateriaisAtuais += QuantidadeMaterial;

            Destroy(gameObject);
        }
    }
}