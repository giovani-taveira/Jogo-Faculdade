using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{ 
    #region "Variaveis"
    public float Velocidade = 10;
    /*Para evitar que o raio colida em outros objetos além do chão então é criado essa mascara 
    abaixo que so considera o chão*/
    public LayerMask MascaraChao;
    public Image barraStamina;
    public static float MaxStamina;
    private float Stamina;
    bool estaParado = true, estaAndando = false;
    public Animator animacao;
    public Text Txt_Stamina;
    RaycastHit hit;
    Rigidbody rb;
    public Rigidbody Arma1Rb;
    Vector3 movimento;
    public float vertical;
    public float horizontal;

    public Text Txt_Materiais;

    Vector3 arma;

    public GameObject InterfaceBoss;
    public GameObject empty;
    public static bool PodeMovimentar;
    #endregion


    void Start()
    {    
        // if(SceneManager.GetActiveScene().name == "CasaJeffey2")
        // {
        //      transform.position = empty.transform.position;
        // }
        //MaxStamina = 1000;
        Stamina = MaxStamina; 
        rb = GetComponent<Rigidbody> ();
        Arma1Rb = GetComponent<Rigidbody>();

        if(PlayerPrefs.HasKey("Cena"))
        {
            LoadPrefsCena();
        }
        else
        {   
            SavePrefsCena();
        }

        if(PlayerPrefs.HasKey("Stamina"))
        {
            LoadPrefsStamina();
        }
        else
        {
            MaxStamina = 1000; 
            SavePrefsStamina();
        }

        Materiais.MateriaisAtuais = 1000;
    }

    void FixedUpdate()
    {
        if(ControlaEventos.SpawnaBoss)
        {
            InterfaceBoss.SetActive(true);
            ControlaEventos.SpawnaBoss = false;
        }

        if(PodeMovimentar)
        {
            MovimentaJogador();
            Rotaciona();
            Animacoes();
        }
        else
        {
            animacao.enabled = false;
        }

        Txt_Stamina.text = $"{Stamina.ToString("0")} / {MaxStamina}";
        barraStamina.fillAmount = (1/MaxStamina) * Stamina;

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        

        if(GameObject.FindWithTag("Arma"))
        {
            arma = movimento;
        }

        Txt_Materiais.text = $"x{Materiais.MateriaisAtuais.ToString()}";

        if(ControlaEventos.SalvaPosicao)
        {
            SavePrefs();
            ControlaEventos.SalvaPosicao = false;
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

                    Velocidade = 15;
                    estaParado = false;
                    estaAndando = false;
                    Stamina -= 0.8f;            
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
        if(Stamina < MaxStamina)
        {
            Stamina += 1;
        }
    }

    void Rotaciona()
    {
        if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 200)) 
        {
            
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;          

            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
            rb.MoveRotation (newRotation);
            Arma1Rb.MoveRotation (newRotation);

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
        animacao.enabled = true;
        animacao.SetFloat("Horizontal", horizontal);
        animacao.SetFloat("Vertical", vertical);
    }

    void SavePrefs()
    { 
        PlayerPrefs.SetFloat("PosX", transform.position.x);
        PlayerPrefs.SetFloat("PosY", transform.position.y);
        PlayerPrefs.SetFloat("PosZ", transform.position.z);
        //PlayerPrefs.SetFloat("Stamina", MaxStamina);

        PlayerPrefs.Save();
    }

    void SavePrefsStamina()
    {
        PlayerPrefs.SetFloat("Stamina", MaxStamina);
        PlayerPrefs.Save();
    }

    void SavePrefsCena()
    {
        string cena = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("Cena", cena);
        PlayerPrefs.Save();
    }

    void LoadPrefs()
    {
        Vector3 pos = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
        transform.position = pos;
        
        float StaminaSalva = PlayerPrefs.GetFloat("Stamina");
        MaxStamina = StaminaSalva;
    }

    void LoadPrefsCena()
    {
        string Cena = PlayerPrefs.GetString("Cena");
    }

    void LoadPrefsStamina()
    {
        float StaminaSalva = PlayerPrefs.GetFloat("Stamina");
        MaxStamina = StaminaSalva;
    }
}