using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
public static int vidaEnemigo = 1;

void Start() {
vidaEnemigo = 1;
}

void Update() {

}

private void OnTriggerEnter2D(Collider2D obj) {
if (obj.tag == "Player") {
obj. transform.GetComponentInChildren<VidasPlayer>() .TomarDano(1);
}
}

public void TomarDano(int dano) {
vidaEnemigo -= dano;
if (vidaEnemigo <= 0) {
Destroy (gameObject);
}
}
}