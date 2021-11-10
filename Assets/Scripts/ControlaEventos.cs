using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaEventos : MonoBehaviour
{
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public static bool Zoom;
    public Animator animacao;

    void Start()
    {
        Spawn1.SetActive(false);
        Spawn2.SetActive(false);
        Spawn3.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider colider)
    {
        if(colider.gameObject.tag == "ZoomCamera")
        {
            Zoom = true;
        }

        if(colider.gameObject.tag == "Trigger")
        {
            animacao.SetBool("CaiArvore", true);
            Spawn1.SetActive(true);
            Debug.Log("Colidiu1");
        }

        if(colider.gameObject.tag == "Trigger2")
        {
            //animacao.SetBool("CaiArvore", true);
            Spawn2.SetActive(true);
            Debug.Log("Colidiu2");
        }

        if(colider.gameObject.tag == "Trigger3")
        {
            //animacao.SetBool("CaiArvore", true);
            Spawn3.SetActive(true);
            Debug.Log("Colidiu3");
        }
    }
}
