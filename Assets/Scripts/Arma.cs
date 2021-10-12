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
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            //O Instantiate Cria objetos no caso a Bala da arma;
            Instantiate(Bala,ReferenciaBalaM18.transform.position, ReferenciaBalaM18.transform.rotation);
        }
    }
}
