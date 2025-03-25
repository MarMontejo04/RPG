using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Npc : MonoBehaviour
{
    public DialogoNpc dataDialogo;
    public GameObject panelDialogo;
    public TMP_Text textoDialogo, textoNombre;
    public Image imagenRetrato;

    private int indiceDialogo;
    private bool estaEscribiendo, dialogoActivo;
    public bool playerEnRango;
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && playerEnRango){
            IniciarDialogo();
        }
    }
    void IniciarDialogo(){
        if (dialogoActivo) return;

        dialogoActivo = true;
        indiceDialogo = 0;

        textoNombre.SetText(dataDialogo.name);
        imagenRetrato.sprite = dataDialogo.retratoNPC;

        panelDialogo.SetActive(true);
        FindFirstObjectByType<Movplayer>().puedeMoverse = false;

        StartCoroutine(EscribirLineas());
        
    }

    void SiguienteLinea(){
        if(estaEscribiendo){
            StopAllCoroutines();
            textoDialogo.SetText(dataDialogo.lineasDialogo[indiceDialogo]);
            estaEscribiendo=false;
        }else if(++indiceDialogo < dataDialogo.lineasDialogo.Length){
            StartCoroutine(EscribirLineas());
        }else{
            TerminarDialogo();
        }
    }
    
    IEnumerator EscribirLineas(){
        estaEscribiendo = true;
        textoDialogo.SetText("");

        foreach(char letter in dataDialogo.lineasDialogo[indiceDialogo]){
            textoDialogo.text += letter;
            yield return new WaitForSeconds(dataDialogo.velocidadEscritura);
        }
        estaEscribiendo = false;

        if(dataDialogo.autoProgresionLineas.Length > indiceDialogo && dataDialogo.autoProgresionLineas[indiceDialogo]){
            yield return new WaitForSeconds(dataDialogo.autoProgresionRetraso);
        }

        
    }

     void TerminarDialogo()
    {
        StopAllCoroutines();
        dialogoActivo = false;
        textoDialogo.SetText("");
        panelDialogo.SetActive(false);
        FindFirstObjectByType<Movplayer>().puedeMoverse = true;

    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnRango = true;
        }
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnRango = false;
        }
    }
}
