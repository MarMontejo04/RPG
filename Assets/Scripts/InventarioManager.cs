using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioManager : MonoBehaviour
{
    public int numMax = 4;
    public ElementoInventario[] elementosInventario;
    public GameObject coleccionableInventarioPrefab;
    public bool AnadirColeccionable(Coleccionable coleccionable){
        for (int i = 0; i < elementosInventario.Length; i++)
        {
            ElementoInventario elemento = elementosInventario[i];
            ColeccionableInventario coleccionableEnElemento = elemento.GetComponentInChildren<ColeccionableInventario>();
            if(coleccionableEnElemento != null && 
            coleccionableEnElemento.coleccionable == coleccionable && 
            coleccionableEnElemento.contador < numMax &&
            coleccionableEnElemento.coleccionable.acumulable == true){
                coleccionableEnElemento.contador++;
                coleccionableEnElemento.ActualizarContador();
                return true;
            }
        }

        for (int i = 0; i < elementosInventario.Length; i++)
        {
            ElementoInventario elemento = elementosInventario[i];
            ColeccionableInventario coleccionableEnElemento = elemento.GetComponentInChildren<ColeccionableInventario>();
            if(coleccionableEnElemento == null){
                SpawnColeccionable(coleccionable,elemento);
                return true;
            }
        }
        return false;
    }
    void SpawnColeccionable(Coleccionable coleccionable, ElementoInventario elemento){
        GameObject nuevoColeccionableGo = Instantiate(coleccionableInventarioPrefab, elemento.transform);
        ColeccionableInventario coleccionableInventario = nuevoColeccionableGo.GetComponent<ColeccionableInventario>();
        coleccionableInventario.InicializarColeccionable(coleccionable);
    }


}
