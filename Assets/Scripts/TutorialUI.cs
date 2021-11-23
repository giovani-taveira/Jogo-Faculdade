using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject UITutorial;
    public GameObject UIDialogo;
    public GameObject UIGameplay;
    bool PodeAtivarTutorial = true;
    void Start()
    {
        
    }

    void Update()
    {
        if(DialogManager.AtivaTutorial && PodeAtivarTutorial)
        {
            UITutorial.SetActive(true);
            UIGameplay.SetActive(false);
            UIDialogo.SetActive(false);
            //DialogManager.AtivaTutorial = false;
            Time.timeScale = 0;

        }
    }

    public void FechaTutorial()
    {
        PodeAtivarTutorial = false;
        Debug.Log("Apertei");
        UITutorial.SetActive(false);
        UIGameplay.SetActive(true);
        UIDialogo.SetActive(true);
        Time.timeScale = 1;
    }
}
