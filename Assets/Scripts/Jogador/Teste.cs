using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    
    public float speed;
    public float gravity;
    public float rotSpeed;
    Vector3 direcao;

    private float rot;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        Move();
        if(Input.GetMouseButtonDown(1))
        {
            RotacionaJogador();
        }
    }

    void Move()
    {
        if(controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed;
                GetComponent<Animator>().SetBool("Andando", true);
                GetComponent<Animator>().SetBool("Correndo", false);
                GetComponent<Animator>().SetBool("Parado", false);
                //anim.SetInteger("transition", 1);
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    //anim.SetInteger("transition", 2);
                    GetComponent<Animator>().SetBool("Correndo", true);
                    GetComponent<Animator>().SetBool("Andando", false);
                    GetComponent<Animator>().SetBool("Parado", false);
                    speed = 0.25f;

                }
                else
                {
                    //anim.SetInteger("transition", 1);
                    GetComponent<Animator>().SetBool("Correndo", false);
                    speed = 0.15f;
                }
            }
            else if(Input.GetKey(KeyCode.S))
            {
                moveDirection = Vector3.back * speed;
            }
            else
            {
                moveDirection = Vector3.zero;
                GetComponent<Animator>().SetBool("Andando", false);
                GetComponent<Animator>().SetBool("Parado", true);
                GetComponent<Animator>().SetBool("Correndo", false);
                //anim.SetInteger("transition", 0);
            }

        }
        rot += Input.GetAxis("Horizontal") * rotSpeed *Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection);
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
        Debug.DrawRay(raio.origin, raio.direction * 2200, Color.red);
        //Debug.Log(raio.direction);
        //RayCastHit Pega o raio desenhado e verfica onde ele está colidindo(no caso o chão do jogo)
        RaycastHit impacto;

        //Testando se o raio está tocando algo
        //Gerando um novo raio com fisica
        if(Physics.Raycast(raio, out impacto, 2200))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            //Para que o personagem não mire para baixo do chão então o y do impacto do raio será igualado ao y do jogador
            posicaoMiraJogador.y = 0;
            Quaternion rotacaoMouse = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(rotacaoMouse);
        }
    }
}
    
