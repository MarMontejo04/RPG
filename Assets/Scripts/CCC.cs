using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCC : MonoBehaviour 
{

public Transform controladorGolpe;
public float radioGolpe;
public int dañoGolpe;
public float tiempoEntreAtaques;
public float tiempoSigAtaque;
private Animator anim;

public static bool atacando;

private void Start() {
anim = GetComponent<Animator>();
}


private void Update() { 
if (tiempoSigAtaque < 0.05f && tiempoEntreAtaques > 0 ) {
atacando = false;
}
if (tiempoSigAtaque > 0) { 
    tiempoSigAtaque -= Time.deltaTime;
}
if (Input.GetButtonDown("Fire1") && tiempoSigAtaque <= 0) {
atacando = true;
activaCapa("Ataque");
Golpe();
tiempoSigAtaque = tiempoEntreAtaques;
}
}

private void Golpe() {
    if (Movplayer.dirAtaque == 1) {
        anim.SetTrigger("GolpeAbajo");
    } else if (Movplayer.dirAtaque == 2) {
        anim.SetTrigger("GolpeArriba");
    } else if (Movplayer.dirAtaque == 3) {
    anim.SetTrigger("GolpeIzquierda");
    } else if (Movplayer.dirAtaque == 4) {
    anim.SetTrigger("GolpeDerecha");
    }
}

private void VerificaGolpe(){
    Collider2D[] objs = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
    foreach (Collider2D colisionador in objs) {
        if (colisionador.CompareTag("enemigo")) {
            colisionador.transform.GetComponent<Enemigo>().TomarDano(dañoGolpe);
        }
    }
}

private void OnDrawGizmos() {
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
}

private void activaCapa(string nombre) {
    for (int i = 0; i < anim.layerCount; i++) {
        anim.SetLayerWeight(i, 0);
    }
    anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
}

}

