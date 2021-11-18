using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    public static event System.Action<Dialog> NewTalker;
    public static event System.Action ResetText;
    public static event System.Action<string> ShowMessage;
    public static event System.Action<bool> UIState;
    private DialogContainer CurrentDialog;
    private bool EndCurrentTalk = true;
    private bool ButtonClicked = false;
    public Animator anim;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public static bool MenosZoom = false;

    public static bool TerminouDialogo = true;
    int d = 0;
    string CenaAtual; 
    SceneLoader sceneLoader = new SceneLoader();
    void Awake()
    {
        Instance = this;
        CenaAtual = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if(d == 9 && TerminouDialogo == true  && CenaAtual == "CasaJeffrey1")
        {
            ResetaPosicao();
            SceneManager.LoadScene("CasaJeffrey2");
            
            TerminouDialogo = false;
        }

        if(d == 15 && TerminouDialogo == true  && CenaAtual == "Casa-Frank")
        {
            ResetaPosicao();
            //SceneManager.LoadScene("Fase2-Floresta");
            SceneLoader.Instance.LoadSceneAsync("Fase2-Floresta");
            TerminouDialogo = false;
        }

        if(d == 3  && TerminouDialogo == true  && CenaAtual == "Fase2-Floresta")
        {
            ResetaPosicao();
            SceneManager.LoadScene("Cena-Milton");
            TerminouDialogo = false;
        }

        if(d == 3  && TerminouDialogo == true  && CenaAtual == "CasaFrank2")
        {
            anim.SetInteger("trigger", 1);
        }

        if(d == 10  && TerminouDialogo == true  && CenaAtual == "CasaFrank2")
        {
            MenosZoom = true;
            anim.SetInteger("trigger", 2);
            anim2.SetInteger("trigger", 1);
            anim3.SetInteger("trigger", 1);
            anim4.SetInteger("trigger", 1);
        }

        if(d == 26  && TerminouDialogo == true  && CenaAtual == "CasaFrank2")
        {
            ResetaPosicao();
            SceneManager.LoadScene("Fase2-Floresta");
        }
    }
    public void StartConversation(DialogContainer container)
    {
        CurrentDialog = container;
        StartCoroutine(StartDialogue());
        UIState?.Invoke(true);
    }

    private IEnumerator StartDialogue()
    {
        for(int i = 0; i < CurrentDialog.Dialogos.Length; i++)
        {
            ResetText?.Invoke();
            NewTalker?.Invoke(CurrentDialog.Dialogos[i]);
            StartCoroutine(ShowDialog(CurrentDialog.Dialogos[i].Dialogo));

            //espera o EndCurrentTalk se tornar verdadeiro para poder trocar de personagem
            yield return new WaitUntil(() => EndCurrentTalk);
        }
        UIState?.Invoke(false);
    }

    private IEnumerator ShowDialog(string[] messages)
    {
        EndCurrentTalk = false;

        foreach(var message in messages)
        {
            ShowAllMessage(message);
            yield return new WaitUntil(() => ButtonClicked);
            d++;

        }
        EndCurrentTalk = true;
    }

    //gerencia a exibição dos dialogos
    private void ShowAllMessage(string message)
    {
        ShowMessage?.Invoke(message);
        ButtonClicked = false;
    }
    public void ButtonWasClicked() => ButtonClicked = true;
    

    public void ResetaPosicao()
    {
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");
    }
}
