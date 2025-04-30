using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Objeto Scriptable")]
public class Coleccionable : ScriptableObject
{

    public Sprite imagen;
    public TipoItem tipo;
    public TipoAccion tipoAccion;
    public bool acumulable = true;

    public int precio = 0;


}

public enum TipoItem{
    Botiquin,
    Brazo
}

public enum TipoAccion{
    Curar,
    Energizar

}

