using UnityEngine;

public class Loot : MonoBehaviour
{
    public InventarioManager inventario;
    public Coleccionable coleccionableDatos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventario.AnadirColeccionable(coleccionableDatos))
            {
                Destroy(gameObject);
            }
        }
    }
}
