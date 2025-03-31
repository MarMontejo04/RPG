using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasPlayer : MonoBehaviour
{
public Image vidaPlayer;
private float anchoVidasPlayer;
public static int vida; private bool haMuerto;
public GameObject gameOver;
public const int vidasINI = 10;
public static int puedePerderVida = 1;

void Start()
{
    anchoVidasPlayer = vidaPlayer.GetComponent<RectTransform>().sizeDelta.x;
    haMuerto = false;
    vida = vidasINI;
    gameOver.SetActive(false);
}

public void TomarDano(int dano)
{
    if (vida > 0 && puedePerderVida == 1) {
        puedePerderVida = 0;
        vida -= dano;
        DibujaVida(vida);
    }

    if(vida <= 0 && !haMuerto) 
    {
        haMuerto = true;
        StartCoroutine(EjecutaMuerte());
    }
}
public void DibujaVida (int vida) {
    RectTransform transformaImagen = vidaPlayer.GetComponent<RectTransform>();
    transformaImagen.sizeDelta = new Vector2(anchoVidasPlayer * (float)vida / (float)vidasINI, transformaImagen.sizeDelta.y);
}

IEnumerator EjecutaMuerte()
{
    yield return new WaitForSeconds (2.1f); 
    gameOver .SetActive(true);
}
}
