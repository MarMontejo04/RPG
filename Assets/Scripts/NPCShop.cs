using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCShop : MonoBehaviour
{
    public GameObject tiendaUI; // Panel de la tienda
    public GameObject itemPrefab; // Prefab del objeto a soltar
    public Transform dropPoint; // Lugar donde aparecerá el objeto
    public int itemCost = 10; // Precio del objeto

    private int playerCoins;
    private Inventario playerInventory;

    private void Start()
    {
        playerInventory = FindObjectOfType<Inventario>();
        Moneda.sumaMoneda += UpdateCoins; // Suscribirse al evento de monedas
    }

    private void OnDestroy()
    {
        Moneda.sumaMoneda -= UpdateCoins; // Desuscribirse para evitar errores
    }

    private void UpdateCoins(int cantidad)
    {
        playerCoins += cantidad;
    }

    public void BuyItem()
    {
        if (playerCoins >= itemCost)
        {
            playerCoins -= itemCost; // Descuenta el dinero
            GameObject droppedItem = Instantiate(itemPrefab, dropPoint.position, Quaternion.identity); // Suelta el objeto
            droppedItem.AddComponent<ItemPickup>(); // Agrega el script de recogida automáticamente
        }
        else
        {
            Debug.Log("No tienes suficiente dinero.");
        }
    }
}

public class ItemPickup : MonoBehaviour
{
    private Inventario playerInventory;

    private void Start()
    {
        playerInventory = FindObjectOfType<Inventario>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ColeccionablePlayer.objAColeccionar = gameObject.name.ToLower(); // Asigna el nombre del objeto recogido
            playerInventory.EscribeEnArreglo(); // Agrega el objeto al inventario
            Destroy(gameObject); // Destruye el objeto del suelo
        }
    }
}
