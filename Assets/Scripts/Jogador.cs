using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float Velocidade = 10;
    Vector3 direcao;
    /*Para evitar que o raio colida em outros objetos além do chão então é criado essa mascara 
    abaixo que so considera o chão*/
    public LayerMask MascaraChao;
    
    
    void Start()
    {
        
    }

    void Update()
    {     

    }

    void FixedUpdate()
    {
        MovimentaJogador();
        RotacionaJogador();
    }

    
    private void MovimentaJogador()
    {
        float eixoX = Input.GetAxis("Vertical");
        float eixoZ = Input.GetAxis("Horizontal");  
        direcao = new Vector3(eixoX, 0, eixoZ);      

        //Movendo o Personagem
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position +
            (direcao * Velocidade * Time.deltaTime));

        /*Testando se o jogador está apertando alguma 
        tecla de movimentação para mudar a animação*/
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            //GetComponent abaixo pega o componente Animator da barra inspector;
            //O SetBool("Nome Variável" , valor) atribui um valor a Variavel Andando criador no animator
            GetComponent<Animator>().SetBool("Andando", true);
            GetComponent<Animator>().SetBool("Correndo", false);
            GetComponent<Animator>().SetBool("Parado", false);
            //GetComponent<Animator>().SetBool("MirandoArmaCurta", true);

            if(Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Animator>().SetBool("Correndo", true);
                Velocidade = 16;
                GetComponent<Animator>().SetBool("Andando", false);
                GetComponent<Animator>().SetBool("Parado", false);
                //GetComponent<Animator>().SetBool("MirandoArmaCurta", false);
            }
            else
            {
                GetComponent<Animator>().SetBool("Correndo", false);
                Velocidade = 9;
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("Andando", false);
            GetComponent<Animator>().SetBool("Parado", true);
            GetComponent<Animator>().SetBool("Correndo", false);
            //GetComponent<Animator>().SetBool("MirandoArmaCurta", true);
        }

        //if()
    }

    void RotacionaJogador()
    {

        //Rotacionando o Jogador com as teclas w, a, s, d
        Quaternion rotacaoInimigo = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(rotacaoInimigo);

        //Rotacionando o jogador com o mouse

        //O Ray Gera um raio no caso abaixo ente a camera e onde o mouse se encontra na tela
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        //DrawRay Desenha o Raio
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);
        Debug.Log(raio.direction);
        //RayCastHit Pega o raio desenhado e verfica onde ele está colidindo(no caso o chão do jogo)
        RaycastHit impacto;

        //Testando se o raio está tocando algo
        //Gerando um novo raio com fisica
        if(Physics.Raycast(raio, out impacto, 100))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            //Para que o personagem não mire para baixo do chão então o y do impacto do raio será igualado ao y do jogador
            posicaoMiraJogador.y = 0;

            Quaternion rotacaoMouse = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(rotacaoMouse);
        }
    }
}
