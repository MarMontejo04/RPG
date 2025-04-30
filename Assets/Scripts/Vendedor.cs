using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendedor : MonoBehaviour
{
    [SerializeField] private GameObject tienda;
     [SerializeField] private GameObject presionarF;
    private bool playerEnRango;
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerEnRango)
        {
            tienda.SetActive(true);
            presionarF.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            playerEnRango = true;
            presionarF.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            playerEnRango = false;
            presionarF.SetActive(false);

        }
    }

}