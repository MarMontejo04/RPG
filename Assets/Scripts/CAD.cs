using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAD : MonoBehaviour 
{

[SerializeField] private GameObject proyectil;
public float tiempoSigAtaque;
public float tiempoEntreAtaques;
public Transform puntoEmision;
private Animator anim;
public static int dirDisparo = 0;
public static bool disparando = false;
private GameObject Player;

    void Start() {
        anim = GetComponent<Animator>();
        Player = GameObject.Find("Player");

    }


    void Update() { 
        if (tiempoSigAtaque < 0.05f && tiempoEntreAtaques > 0 ) {
            disparando = false;
        }
        if (tiempoSigAtaque > 0) { 
            tiempoSigAtaque -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2") && tiempoSigAtaque <= 0) {
            disparando = true;
            activaCapa("Ataque");
            Dispara();
            tiempoSigAtaque = tiempoEntreAtaques;

            if (EnergiaPlayer.energia > 0)
            {
                EnergiaPlayer.energia -= 10; 
                Player.GetComponent<EnergiaPlayer>().DibujaEnergia(EnergiaPlayer.energia);
            }
        }
    }
      
    

    void Dispara() {
        if (Movplayer.dirAtaque == 1){
            anim.SetTrigger("DisparoAbajo");
        } else if (Movplayer.dirAtaque == 2) {
            anim.SetTrigger("DisparoArriba");
        } else if (Movplayer.dirAtaque == 3) {
        anim.SetTrigger("DisparoIzquierda");
        } else if (Movplayer.dirAtaque == 4) {
        anim.SetTrigger("DisparoDerecha");
        }
    }

    private void EmiteProyectil() {
        dirDisparo = Movplayer.dirAtaque;
        Instantiate(proyectil, puntoEmision.position, transform.rotation);
    }

    private void activaCapa(string nombre) {
        for (int i = 0; i < anim.layerCount; i++) {
            anim.SetLayerWeight(i, 0);
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }
}