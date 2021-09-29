using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaBala : MonoBehaviour
{
    public float Velocidade = 90;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position +
            transform.forward * Velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider colisor)
    {
        //DEstruindo o Inimigo
        if(colisor.tag == "Inimigo")
        {
            Destroy(colisor.gameObject);
        }
        //Destruindo a Bala;
        //O gameObject é o objeto que recebera este script
        Destroy(gameObject);
    }
}
