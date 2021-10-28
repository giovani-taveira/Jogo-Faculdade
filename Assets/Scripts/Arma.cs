using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject Bala;
    public GameObject ReferenciaBalaM18;
    public GameObject ArmaLonga;
    public GameObject ArmaCurta;
    public Animator animacao;

   
    void Start()
    {
        ArmaCurta.SetActive(false);
        ArmaLonga.SetActive(false);
        animacao.SetInteger("Transition", 0);
    }

    // Update is called once per frame
    void Update()
    {
        TrocaArma();

        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space )) && OutrasAcoes.EstaPausado == false)
        {
            //O Instantiate Cria objetos no caso a Bala da arma;
            Instantiate(Bala,ReferenciaBalaM18.transform.position, ReferenciaBalaM18.transform.rotation);
        }
    }

    void TrocaArma()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            ArmaCurta.SetActive(false);
            ArmaLonga.SetActive(false);
            animacao.SetInteger("Transition", 0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ArmaCurta.SetActive(true);
            ArmaLonga.SetActive(false);
            animacao.SetInteger("Transition", 2);
        }
        if(Input.GetKey(KeyCode.Alpha3))
        {
            ArmaCurta.SetActive(false);
            ArmaLonga.SetActive(true);
            animacao.SetInteger("Transition", 1);
        }
    }
}
