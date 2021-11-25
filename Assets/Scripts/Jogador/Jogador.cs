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
    Animator anim;
    Vector3 movimento, LookPos, move, moveInput;

    float vertical,horizontal, forwardAmount, turnAmount ;

    public Text Txt_Materiais;
    public GameObject InterfaceBoss;
    public static bool PodeMovimentar, Introducao = false;
    string CenaAtual;
    #endregion

    void awake()
    {
        CenaAtual = SceneManager.GetActiveScene().name;
        if(CenaAtual == "CasaJeffrey1")
        {
            Introducao = true;
        }
    }

    void Start()
    {    
        Stamina = MaxStamina; 
        rb = GetComponent<Rigidbody> ();


        if(PlayerPrefs.HasKey("Stamina"))
        {
            LoadPrefsStamina();
        }
        else
        {
            MaxStamina = 200; 
            SavePrefsStamina();
        }

        if(PlayerPrefs.HasKey("PosX"))
        {
            LoadPrefsPosicao();
        }

        Materiais.MateriaisAtuais = 1000;

        SetupAnimator();
    }

    void Update()
    {
        if(PodeMovimentar)
        {
            Ray  ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                LookPos = hit.point;
            }

            Vector3 lookDir = LookPos - transform.position;
            lookDir.y = 0;

            transform.LookAt(transform.position + lookDir, Vector3.up);

            ConvertMoveInput();
            UpdateAnimator();
        }

        if(Input.GetKey("w") && Input.GetKey("a") || Input.GetKey("w") && Input.GetKey("d"))
            Velocidade = 1.3f;
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

            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            move = vertical * Vector3.forward + horizontal * Vector3.right; 

            if(move.magnitude > 1)
            {
                move.Normalize();
            }

            Move(move);

            Vector3 movement = new Vector3(horizontal, 0, vertical);
            rb.AddForce(movement * Velocidade / Time.deltaTime);
        }

        Txt_Stamina.text = $"{Stamina.ToString("0")} / {MaxStamina}";
        barraStamina.fillAmount = (1/MaxStamina) * Stamina;      

        Txt_Materiais.text = $"x{Materiais.MateriaisAtuais.ToString()}";

        if(ControleProgresso.SalvaPosicao)
        {
            SavePrefsPosicao();
            ControleProgresso.SalvaPosicao = false;
        }

        if(ControleProgresso.SalvaCena)
        {
            SavePrefsCena();
            ControleProgresso.SalvaCena = false;
        }
    }
 
    private void MovimentaJogador()
    {
        animacao.SetFloat("Blend", 0);

        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            animacao.SetFloat("Blend", 0);
            Velocidade = 2.3f;
            estaAndando = true;
            estaParado = false;

            if(Input.GetKey(KeyCode.LeftShift))
            {    
                if(Stamina >= 0)
                {
                    animacao.SetFloat("Blend", 1);

                    Velocidade = 3.6f;
                    estaParado = false;
                    estaAndando = false;
                    Stamina -= 0.8f;            
                }
            }
            else
            {
                Velocidade = 2.3f;
                estaAndando = true;
                animacao.SetFloat("Blend", 0);
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

    void SavePrefsPosicao()
    { 
        PlayerPrefs.SetFloat("PosX", transform.position.x);
        PlayerPrefs.SetFloat("PosY", transform.position.y);
        PlayerPrefs.SetFloat("PosZ", transform.position.z);
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

    void LoadPrefsPosicao()
    {
        Vector3 pos = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
        transform.position = pos;
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
    
    void SetupAnimator()
    {
        anim = GetComponent<Animator>();

        foreach(var childAnimator in GetComponentsInChildren<Animator>())
        {
            if(childAnimator != anim)
            {
                anim.avatar = childAnimator.avatar;
                Destroy(childAnimator);
                break;
            }
        }
    }

    void Move(Vector3 move)
    {
        if(move.magnitude > 1)
        {
            move.Normalize();
        }
        this.moveInput = move;
    }

    void ConvertMoveInput()
    {
        Vector3 localMove = transform.InverseTransformDirection(moveInput);
        turnAmount = localMove.x;
        forwardAmount = localMove.z;
    }

    void UpdateAnimator()
    {
        anim.SetFloat("Horizontal", forwardAmount, 0.1f, Time.deltaTime);
        anim.SetFloat("Vertical", turnAmount, 0.1f, Time.deltaTime);
    }
}