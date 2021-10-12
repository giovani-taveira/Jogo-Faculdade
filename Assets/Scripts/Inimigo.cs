using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject jogador;
    public float velocidade = 7;

    void Start()
    {
        //Faz com que quando um inimigo é gerado ele vá procurar o jogo através da tag 
        jogador = GameObject.FindWithTag("Jogador");
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        /*Verfica distancia entre o inimigo e o jogador para que o inimigo 
        não fique empurrando o jogador quando ele chegar chegar no nele*/

        float distancia = Vector3.Distance(transform.position, jogador.transform.position);

        Vector3 direcao = jogador.transform.position - transform.position;

        Quaternion rotacaoInimigo = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(rotacaoInimigo);

        if(distancia > 2.5)
        {
            //Faz com que o inimigo persiga o jogador subtraindo a posição do jogador pela do inimigo;
            
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position +
            direcao.normalized * velocidade * Time.deltaTime);

            //Quaternion é um tipo usado para manipular rotações
            //LookRotation 

        }
        // else if(distancia < 2.5)
        // {
        //     jogador.GetComponent<Jogador>().RecebeDano();
        // }
    }
    void AtacaJogador()
    {

        
    }
}
