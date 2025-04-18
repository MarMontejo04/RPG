using UnityEngine;
using TMPro;

public class TiendaController : MonoBehaviour
{
    [SerializeField] private Moneda moneda;                    // Referencia al script de Moneda
    [SerializeField] private GameObject panelTienda;           // Panel de la tienda
    [SerializeField] private Transform dropPoint;              // Punto donde cae el objeto
    [SerializeField] private GameObject botiquinPrefab;        // Prefab del botiquín
    [SerializeField] private GameObject brazoPrefab;           // Prefab del brazo
    [SerializeField] private TMP_Text textoMonedas;            // Texto que muestra la cantidad de monedas

    public void ComprarBotiquin()
    {
        if (moneda.CantidadMonedas >= 10)
        {
            moneda.CantidadMonedas -= 10;
            Instantiate(botiquinPrefab, dropPoint.position, Quaternion.identity);
            ActualizarTextoMonedas();
            Debug.Log("Botiquín comprado. Monedas restantes: " + moneda.CantidadMonedas);
        }
        else
        {
            Debug.Log("No tienes suficientes monedas.");
        }
    }

    public void ComprarBrazo()
    {
        if (moneda.CantidadMonedas >= 20)
        {
            moneda.CantidadMonedas -= 20;
            Instantiate(brazoPrefab, dropPoint.position, Quaternion.identity);
            ActualizarTextoMonedas();
            Debug.Log("Brazo comprado. Monedas restantes: " + moneda.CantidadMonedas);
        }
        else
        {
            Debug.Log("No tienes suficientes monedas.");
        }
    }

    public void SalirDeTienda()
    {
        panelTienda.SetActive(false);
        Time.timeScale = 1;
    }

    private void ActualizarTextoMonedas()
    {
        textoMonedas.text = moneda.CantidadMonedas.ToString();
    }
}
