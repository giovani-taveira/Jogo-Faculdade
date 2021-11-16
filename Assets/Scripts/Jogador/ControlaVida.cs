using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlaVida : MonoBehaviour
{
    #region "Variaveis"
    public int VidaInicial = 400;
    public static int Vida;
    public Image barraVida;
    public GameObject InterfaceMorte;
    public Text Txt_Vida;
    public Animator animacao;
    public GameObject Kit;
    public Text Txt_Kit;
    public int ContadorKit;
    public bool TemKit;
    public bool TomouDano;
    public Image ImagemDano;
    public float VelocidadeImagem = 5f;
    //public Color CorDano = new Color(1f, 0f, 0f, 0.1f);
    PlayerShoot palyerShooting;
    #endregion
    
    void Awake()
    {
        palyerShooting = GetComponentInChildren<PlayerShoot>();
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("VidaMax"))
        {
            LoadPrefs(); 
        }
        else
        {
            Vida = VidaInicial;
            SavePrefs();
        }
    }

    void Update()
    {
        Txt_Kit.text = $"x{ContadorKit.ToString()}";
        Txt_Vida.text = $"{Vida} / {VidaInicial}";
        barraVida.fillAmount = (1/(float)VidaInicial) * Vida;

        RecuperaVida();

        if(TomouDano)
        {
            ImagemDano.enabled = true;
        }
        else
        {
            //ImagemDano.color = Color.Lerp(ImagemDano.color, Color.clear, VelocidadeImagem * Time.deltaTime);
            ImagemDano.enabled = false;
        }
        TomouDano = false;

        if(ControlaEventos.SalvaVida)
        {
            SavePrefs();
            ControlaEventos.SalvaVida = false;
        }
    }

    void OnCollisionEnter(Collision colisor)
    {
        if(colisor.gameObject.tag == "Inimigo")
        {
            animacao.SetInteger("Transition", 4);
            Vida -= 10;
        }
    }

    void Morte()
    {
        palyerShooting.DesativarEfeitos();
        Vida = 0;
        Time.timeScale = 0;
        InterfaceMorte.SetActive(true); 
    } 

    public void TomaDano(int DanoSofrido)
    {
        TomouDano = true;
        Vida -= DanoSofrido;

        if(Vida <= 0)
        {
            Morte();
        }
    }

    void RecuperaVida()
    { 
        if(KitMedico.PegouKit == true)
        {
            ContadorKit += 1;   
            KitMedico.PegouKit = false;
        }

        if(ContadorKit > 0)
            TemKit = true;
        else
            TemKit = false;

        if(Input.GetKeyDown(KeyCode.Mouse0) && Arma.KitEquipado == true)
        {
            Kit.SetActive(true);
            animacao.SetInteger("Transition", 0);
            if(TemKit == true && Vida < VidaInicial)
            {
                ContadorKit -= 1;
                Vida += KitMedico.QuantidadeCura;
                KitMedico.PegouKit = false;

                if(Vida > VidaInicial)
                {
                    Vida = VidaInicial;
                }
            }
        }
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("Vida", Vida);
        PlayerPrefs.SetInt("VidaMax", VidaInicial);

        PlayerPrefs.SetInt("QtdKit", ContadorKit);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        int vi = PlayerPrefs.GetInt("Vida");
        int vm = PlayerPrefs.GetInt("VidaMax");
        int QtdKit =PlayerPrefs.GetInt("QtdKit");

        ContadorKit = QtdKit;
        Vida = vi;
        VidaInicial = vm;
    }
}
