using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColeccionableInventario : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Coleccionable coleccionable;
    public Text contadorTexto;
    [HideInInspector] public Image imagen;
    [HideInInspector] public int contador = 1;
    [HideInInspector] public Transform parentAfterDrag;
    private GameObject Player;

     void Start()
    {
        Player = GameObject.Find("Player");
    }

   
    public void InicializarColeccionable(Coleccionable nuevoColeccionable){
        coleccionable = nuevoColeccionable;
        imagen.sprite = nuevoColeccionable.imagen;
        ActualizarContador();
    }

    public void ActualizarContador(){
        contadorTexto.text = contador.ToString();
        bool textActive = contador > 1;
        contadorTexto.gameObject.SetActive(textActive);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        imagen.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        imagen.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            UsarColeccionable();
        }
    }

    public void UsarColeccionable(){
         switch (coleccionable.tipoAccion)
        {
            case TipoAccion.Curar:
                if (VidasPlayer.vida < VidasPlayer.vidasINI)
                {
                    VidasPlayer.vida++;
                    Player.GetComponent<VidasPlayer>().DibujaVida(VidasPlayer.vida);
                }
                break;

            case TipoAccion.Energizar:
                if (EnergiaPlayer.energia < EnergiaPlayer.energiaMax)
                {
                    EnergiaPlayer.energia +=10;
                     Player.GetComponent<EnergiaPlayer>().DibujaEnergia(EnergiaPlayer.energia); 
                }
                break;
        }


        contador--;
        if (contador <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            ActualizarContador();
        }
    }

    
}
