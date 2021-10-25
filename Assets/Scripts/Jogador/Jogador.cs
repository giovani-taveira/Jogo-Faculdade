using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{ 
    public float Velocidade = 10;
    Vector3 direcao;

    /*Para evitar que o raio colida em outros objetos além do chão então é criado essa mascara 
    abaixo que so considera o chão*/
    public LayerMask MascaraChao;
    public Image barraStamina;
    public float Stamina = 100;
    bool estaParado = true, estaAndando = false;
    public Animator animacao;
    public Text Txt_Stamina;

    void Start()
    {      
        Stamina = 100; 
    }

    void FixedUpdate()
    {
        MovimentaJogador();
        RotacionaJogador();

        Txt_Stamina.text = $"{Stamina.ToString("0")} / 100";
    }
 
    private void MovimentaJogador()
    {

        float eixoX = Input.GetAxis("Vertical");
        float eixoZ = Input.GetAxis("Horizontal");  
        direcao = new Vector3(eixoX, 0 , eixoZ);

        //Movendo o Personagem
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position +
            (direcao * Velocidade * Time.deltaTime));

        animacao.SetInteger("Transition", 0);

        /*Testando se o jogador está apertando alguma 
        tecla de movimentação para mudar a animação*/
        if(Input.GetKey("w") || Input.GetKey("s") ||Input.GetKey("a") || Input.GetKey("d"))
        {
            //GetComponent abaixo pega o componente Animator da barra inspector;
            //O SetBool("Nome Variável" , valor) atribui um valor a Variavel Andando criador no animator
            animacao.SetInteger("Transition", 1);
            Velocidade = 8;
            estaAndando = true;
            estaParado = false;
            //GetComponent<Animator>().SetBool("MirandoArmaCurta", true);

            if(Input.GetKey(KeyCode.LeftShift))
            {
                
                if(Stamina >= 0)
                {
                    animacao.SetInteger("Transition", 2);

                    Velocidade = 14;
                    estaParado = false;
                    estaAndando = false;

                    Stamina -= 0.8f;
                    barraStamina.fillAmount -= 0.008f;
                }
            }
            else
            {
                Velocidade = 8;
                estaAndando = true;

                if(estaAndando == true)
                {
                    estaParado = false;
                    AumentaStamina();
                }           
            }
        }
        else
        {
            estaParado = true;
            if(estaParado == true)
            {
                estaAndando = false;
                AumentaStamina();
            }
        }
    }

    void AumentaStamina()
    {
        if(Stamina < 99)
        {
            Stamina += 1;
            barraStamina.fillAmount += 0.01f; 
        }
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