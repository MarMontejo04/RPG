using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaPlayer : MonoBehaviour
{
    public Image barraEnergia;
    private float anchoBarraEnergia;
    public static int energia;
    public const int energiaMax = 100;

     private static Movplayer movPlayer; 

    void Start()
    {
        anchoBarraEnergia = barraEnergia.GetComponent<RectTransform>().sizeDelta.x;
        energia = energiaMax;
        movPlayer = FindObjectOfType<Movplayer>(); 
        DibujaEnergia(energia);
    }


    public void DibujaEnergia(int energia)
    {
        RectTransform transformaImagen = barraEnergia.GetComponent<RectTransform>();
        transformaImagen.sizeDelta = new Vector2(anchoBarraEnergia * (float)energia / (float)energiaMax, transformaImagen.sizeDelta.y);
    }
}


