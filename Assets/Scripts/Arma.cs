﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject Bala;
    public GameObject ReferenciaBalaM18;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //O Instantiate Cria objetos no caso a Bala da arma;
            Instantiate(Bala,ReferenciaBalaM18.transform.position, ReferenciaBalaM18.transform.rotation);
        }
    }
}
