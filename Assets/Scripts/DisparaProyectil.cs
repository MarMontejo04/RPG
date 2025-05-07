using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparaProyectil : MonoBehaviour
{

    [SerializeField]private float velocidad = 8.0f;


    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "limites") {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "enemigo") {
        collision.transform.GetComponent<Enemigo>().TomarDano(1);
            Destroy(this.gameObject);
        }
    }

}