using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float velocidade = 7;

    void Start()
    {
        //Faz com que quando um inimigo é gerado ele vá procurar o jogo através da tag 
        Jogador = GameObject.FindWithTag("Jogador");
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        /*Verfica distancia entre o inimigo e o jogador para que o inimigo 
        não fique empurrando o jogador quando ele chegar chegar no nele*/

        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        if(distancia > 0.1)
        {
            //Faz com que o inimigo persiga o jogador subtraindo a posição do jogador pela do inimigo;
            Vector3 direcao = Jogador.transform.position - transform.position;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position +
            direcao.normalized * velocidade * Time.deltaTime);

            //Quaternion é um tipo usado para manipular rotações
            //LookRotation 
            Quaternion rotacaoInimigo = Quaternion.LookRotation(direcao);
            GetComponent<Rigidbody>().MoveRotation(rotacaoInimigo);
        }
    }
}
