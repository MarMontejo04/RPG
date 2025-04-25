using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendedor : MonoBehaviour
{
    [SerializeField] private GameObject tienda;
    private bool playerEnRango;
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerEnRango)
        {
            tienda.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            playerEnRango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            playerEnRango = false;
        }
    }

}