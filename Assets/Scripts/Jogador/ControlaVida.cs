using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaVida : MonoBehaviour
{
    public int VidaInicial = 100;
    public static int Vida = 100;
    public Image barraVida;
    public GameObject InterfaceMorte;
    
    void Start()
    {
        Vida = 100; 
    }

    void Update()
    {
        ControladorVida();
        if(KitMedico.PegouKit == true && Vida < 100)
        {
            Vida += 30;
            barraVida.fillAmount += 0.3f;
            KitMedico.PegouKit = false;
            if(Vida > VidaInicial)
            {
                Vida = VidaInicial;
            }
        }
    }

    void OnCollisionEnter(Collision colisor)
    {
        //Destruindo o Inimigo
        if(colisor.gameObject.tag == "Inimigo")
        {
            Vida -= 10;
            barraVida.fillAmount -= 0.1f;
        }
    }
    void ControladorVida()
    {
        if(Vida <= 0) 
        {
            Vida = 0;
            Time.timeScale = 0;
            InterfaceMorte.SetActive(true); 
            // if(Input.GetKeyDown(KeyCode.Space))
            // {
            //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // }     
        }
    } 
}
