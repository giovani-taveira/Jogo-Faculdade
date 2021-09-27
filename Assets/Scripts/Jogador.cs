using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float Velocidade = 10;
    Vector3 direcao;
    
    void Start()
    {
        
    }

    void Update()
    {     

    }

    void FixedUpdate()
    {
        MovimentaJogador();
    }

    private void MovimentaJogador()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");  
        direcao = new Vector3(eixoX, 0, eixoZ);      
     
        /*Testando se o jogador está apertando alguma 
        tecla de movimentação para mudar a animação*/
        if(direcao != Vector3.zero)
        {
            //GetComponent abaixo pega o componente Animator da barra inspector;
            //O SetBool("Nome Variável" , valor) atribui um valor a Variavel Movendo criador no animator
            GetComponent<Animator>().SetBool("Movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }

        //Rotacionando o Jogador
        Quaternion rotacaoInimigo = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(rotacaoInimigo);

        //Movendo o Personagem
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position +
            (direcao * Velocidade * Time.deltaTime));

        // Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);
        // Debug.Log(raio.direction);

    }
}
