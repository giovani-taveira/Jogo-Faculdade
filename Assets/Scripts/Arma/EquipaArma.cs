using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipaArma : MonoBehaviour
{
    public GameObject Pistola, Uzi, Shotgun, RifleDeAssalto, LMG;
    void Start()
    {
        Pistola.SetActive(true);
        Uzi.SetActive(false);
    }
    void Update()
    {
        
    }

    public void EquipaPistola()
    {
        Pistola.SetActive(true);
        Uzi.SetActive(false);

    }
    public void EquipaUzi()
    {
        Pistola.SetActive(false);
        Uzi.SetActive(true);
    }
}
