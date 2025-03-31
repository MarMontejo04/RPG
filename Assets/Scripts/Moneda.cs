using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moneda : MonoBehaviour
{
    public delegate void SumaMoneda(int moneda);
    public static event SumaMoneda sumaMoneda;

    [SerializeField] private int cantidadMonedas = 1; // Evita valores nulos

    // Getter para acceder a la cantidad de monedas
    public int CantidadMonedas
    {
        get { return cantidadMonedas; }
        set { cantidadMonedas = value; }
    }

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


