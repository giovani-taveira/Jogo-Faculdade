using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public static bool TerminouDialogo = false;
    void Awake()
    {
        Instance = this;
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
        }

        EndCurrentTalk = true;
        TerminouDialogo = true;
    }

    //gerencia a exibição dos dialogos
    private void ShowAllMessage(string message)
    {
        ShowMessage?.Invoke(message);
        ButtonClicked = false;
    }
    public void ButtonWasClicked() => ButtonClicked = true;
 
}
