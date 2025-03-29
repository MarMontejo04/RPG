using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Necesario para usar 'Action'

public class Moneda : MonoBehaviour
{
    public delegate void SumaMoneda(int moneda);
    public static event SumaMoneda sumaMoneda;

    [SerializeField] private int cantidadMonedas = 1; // Evita valores nulos

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sumaMoneda != null) // Verifica que haya suscriptores
            {
                sumaMoneda(cantidadMonedas); // Dispara el evento con la cantidad correcta
            }
            Destroy(this.gameObject);
        }
    }
}

     
 

