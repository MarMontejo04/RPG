using UnityEngine;

[CreateAssetMenu(fileName = "NuevoDialogoNPC", menuName = "Dialogo NPC")]
public class DialogoNpc :ScriptableObject
{
    public string nombreNPC;
    public Sprite retratoNPC;
    public string[] lineasDialogo;
    public bool[] autoProgresionLineas;
    public float autoProgresionRetraso = 1.5f;
    public float velocidadEscritura = 0.05f;
    public AudioClip voz;
    

    
}
