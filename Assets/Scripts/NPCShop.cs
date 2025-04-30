using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCShop : MonoBehaviour
{
    public ControladorMoneda controladorMoneda;
    public InventarioManager inventario;
    public Coleccionable[] coleccionableComprar;
    public int[] precios;

    public void ComprarColeccionable(int id)
    {
        Coleccionable item = coleccionableComprar[id];

    if (controladorMoneda.GastarMonedas(item.precio)) {
        inventario.AnadirColeccionable(item);
    }
    }
}
