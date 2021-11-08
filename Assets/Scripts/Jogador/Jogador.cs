using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{ 
    #region "Variaveis"
    public float Velocidade = 10;
    /*Para evitar que o raio colida em outros objetos além do chão então é criado essa mascara 
    abaixo que so considera o chão*/
    public LayerMask MascaraChao;
    public Image barraStamina;
    public float Stamina = 100;
    bool estaParado = true, estaAndando = false;
    public Animator animacao;
    public Text Txt_Stamina;
    RaycastHit hit;
    Rigidbody rb;
    Vector3 movimento;
    public float vertical;
    public float horizontal;

    Vector3 arma;
    #endregion


    void Start()
    {      
        Stamina = 100; 
        rb = GetComponent<Rigidbody> ();
    }

    void FixedUpdate()
    {
        MovimentaJogador();
        //RotacionaJogador();
        Rotaciona();
        Txt_Stamina.text = $"{Stamina.ToString("0")} / 100";

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        Animacoes();

        if(GameObject.FindWithTag("Arma"))
        {
            arma = movimento;
        }
    }
 
    private void MovimentaJogador()
    {
        animacao.SetFloat("Blend", 0);

        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            animacao.SetFloat("Blend", 0);
            Velocidade = 8;
            estaAndando = true;
            estaParado = false;

            if(Input.GetKey(KeyCode.LeftShift))
            {    
                if(Stamina >= 0)
                {
                    animacao.SetFloat("Blend", 1);

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
                //animacao.SetFloat("Blend", 0);
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

    void Rotaciona()
    {
        if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100)) 
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
            rb.MoveRotation (newRotation);

            Vector3 forwordDirection = new Vector3 (transform.forward.x, 0, transform.forward.z) * Input.GetAxis ("Vertical");
            Vector3 sideDirection = new Vector3 (transform.right.x, 0, transform.right.z) * Input.GetAxis ("Horizontal");
            Vector3 finalDirection = forwordDirection + sideDirection;

            if (finalDirection.magnitude > 1) 
            {
                finalDirection.Normalize ();
            }

            movimento = finalDirection * Velocidade * Time.deltaTime;
            rb.MovePosition (transform.position + movimento);
        }
    }

    void Animacoes()
    {
        animacao.SetFloat("Horizontal", horizontal);
        animacao.SetFloat("Vertical", vertical);
    }
}