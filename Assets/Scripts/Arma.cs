using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject Bala;
    public GameObject ReferenciaBalaM18;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space )) && OutrasAcoes.EstaPausado == false)
        {
            //O Instantiate Cria objetos no caso a Bala da arma;
            Instantiate(Bala,ReferenciaBalaM18.transform.position, ReferenciaBalaM18.transform.rotation);
        }
    }
}
