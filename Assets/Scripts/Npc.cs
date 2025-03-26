using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Npc : MonoBehaviour
{
    [Header("Panel de diálogo")]
    public GameObject panelDialogo;
    public TMP_Text textoDialogo, textoNombre;
    public Image retrato;

    [Header("Datos del NPC")]
    public string nombreNPC;
    public Sprite retratoNPC;
    public string[] dialogo;
    public float velocidadEscritura = 0.05f;

    private int indice;
    private bool playerEnRango;
    private bool escribiendo = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerEnRango)
        {
            if (panelDialogo.activeInHierarchy)
            {
                SiguienteLinea();
            }
            else
            {
                IniciarDialogo();
            }
        }
    }

    void IniciarDialogo()
    {
        StopAllCoroutines(); // Detiene cualquier escritura anterior
        panelDialogo.SetActive(true);
        textoNombre.text = nombreNPC;
        retrato.sprite = retratoNPC;
        indice = 0;
        StartCoroutine(Escribir());
    }

    IEnumerator Escribir()
    {
        escribiendo = true;
        textoDialogo.text = "";

        foreach (char letter in dialogo[indice].ToCharArray())
        {
            textoDialogo.text += letter;
            yield return new WaitForSeconds(velocidadEscritura);
        }

        escribiendo = false;
    }

    void SiguienteLinea()
    {
        if (escribiendo)
        {
            StopAllCoroutines(); // Detiene la escritura actual
            textoDialogo.text = dialogo[indice]; // Muestra la línea completa de inmediato
            escribiendo = false;
            return;
        }

        if (indice < dialogo.Length - 1)
        {
            indice++;
            StopAllCoroutines(); // Asegura que la escritura anterior no interfiera
            textoDialogo.text = "";
            StartCoroutine(Escribir());
        }
        else
        {
            ResetearDialogo();
        }
    }

    void ResetearDialogo()
    {
        StopAllCoroutines(); // Evita que el diálogo se siga escribiendo al cerrar
        textoDialogo.text = "";
        indice = 0;
        panelDialogo.SetActive(false);
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
            ResetearDialogo();
        }
    }
}
