using System;
using System. Collections;
using System. Collections. Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public static int vidaEnemigo = 1;
    private float frecAtaque = 2.5f, tiempoSigAtaque = 0, iniciaConteo;

    public Transform personaje;
    private NavMeshAgent agente;
    public Transform [] puntosRuta;
    private int indiceRuta;
    private bool playerEnRango = false;
    [SerializeField] private float distanciaDeteccionPlayer;
    private SpriteRenderer spriteEnemigo;
    private Transform mirarHacia;
    [SerializeField] private GameObject dropeable;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        spriteEnemigo = GetComponent<SpriteRenderer>();
    }

    void Start() {
        vidaEnemigo = 1;
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }

    void Update() {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        float distancia = Vector3.Distance(personaje.position, this.transform.position);

        if(Vector3.Distance(this.transform.position, puntosRuta[indiceRuta].position) < 0.1f)
        {
            if(indiceRuta < puntosRuta.Length - 1)
            {
                indiceRuta++;
            }
            else if(indiceRuta == puntosRuta.Length - 1)
            {
                indiceRuta = 0;
            }
        }

        if(distancia < distanciaDeteccionPlayer)
        {
            playerEnRango = true;
        }
        else
        {
            playerEnRango = false;
        }

        if(tiempoSigAtaque > 0)
        {
            tiempoSigAtaque = frecAtaque + iniciaConteo - Time.time;
        }
        else
        {
            tiempoSigAtaque = 0;
            VidasPlayer.puedePerderVida = 1;
            SigueAlPlayer(playerEnRango);
            RotaEnemigo();
        }
    }

    private void SigueAlPlayer(bool playerEnRango)
    {
        if (playerEnRango)
        {
            agente.SetDestination(personaje.position);
            mirarHacia = personaje;
        }
        else
        {
            agente.SetDestination(puntosRuta[indiceRuta].position);
            mirarHacia = puntosRuta[indiceRuta];
        }
    }

    private void RotaEnemigo()
    {
        if(this.transform.position.x > mirarHacia.position.x)
        {
            spriteEnemigo.flipX = true;
            Debug.Log("FlipX");
        }
        else
        {
            spriteEnemigo.flipX = false;
            Debug.Log("Sin FlipX");
        }
    }

    private void OnTriggerEnter2D(Collider2D obj) {
     if (obj.tag == "Player") {
            tiempoSigAtaque = frecAtaque;
            iniciaConteo = Time.time;
            obj.transform.GetComponentInChildren<VidasPlayer>().TomarDano(1);
      }
    }   

    public void TomarDano(int dano) {
        vidaEnemigo -= dano;
        if (vidaEnemigo <= 0) {
             Vector2 v2Prefab = this.transform.position; 
             Instantiate(dropeable, v2Prefab, transform.rotation);
            Destroy(gameObject);
        }
    }
    

}