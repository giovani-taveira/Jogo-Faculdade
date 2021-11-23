using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introducao : MonoBehaviour
{
    public GameObject InterfaceIntroducao;
    
    void Start()
    {
        InterfaceIntroducao.SetActive(true);
    }
    
    void Update()
    {
        
    }

    public void Fechaintroducao()
    {
        InterfaceIntroducao.SetActive(false);
    }
}
