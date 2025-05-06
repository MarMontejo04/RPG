    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AI;

    public class Enemigo : MonoBehaviour
    {
        public static int vidaEnemigo = 1;
        private float frecAtaque = 2.5f, tiempoSigAtaque = 0, iniciaConteo;
        private Animator animator;
        public float velMov;
        public Rigidbody2D rb;
        public Animator anim;
        public Transform personaje;
        private NavMeshAgent agente;
        public Transform[] puntosRuta;
        private int indiceRuta;
        private bool playerEnRango = false;
        [SerializeField] private float distanciaDeteccionPlayer;
        [SerializeField] private GameObject dropeable;
    
        

        private void Awake()
        {
            agente = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
    }

        void Start()
        {
            vidaEnemigo = 1;
            agente.updateRotation = false;
            agente.updateUpAxis = false;
        }

        void FixedUpdate()
        {
            ActualizarAnimaciones();
        }

        private void ActualizarAnimaciones()
        {
            float velocidad = agente.velocity.magnitude;
            animator.SetBool("isMover", velocidad > 0.1f);
            if (velocidad >= 0.1f)
            {
                Vector3 direccionMovimiento = agente.velocity.normalized;
                animator.SetFloat("movX", direccionMovimiento.x);
                animator.SetFloat("movY", direccionMovimiento.y);
            }
        }

        void Update()
    {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            float distancia = Vector3.Distance(personaje.position, this.transform.position);

            if (Vector3.Distance(this.transform.position, puntosRuta[indiceRuta].position) < 0.1f)
            {
                if (indiceRuta < puntosRuta.Length - 1)
                {
                    indiceRuta++;
                }
                else if (indiceRuta == puntosRuta.Length - 1)
                {
                    indiceRuta = 0;
                }
            }

            if (distancia < distanciaDeteccionPlayer)
            {
                playerEnRango = true;
            }
            else
            {
                playerEnRango = false;
            }

            if (tiempoSigAtaque > 0)
            {
            tiempoSigAtaque = frecAtaque + iniciaConteo - Time.time;
            }
            else
            {
                tiempoSigAtaque = 0;
                VidasPlayer.puedePerderVida = 1;
                SigueAlPlayer(playerEnRango);
            }
        }

        private void SigueAlPlayer(bool playerEnRango)
        {
            if (playerEnRango)
            {
                agente.SetDestination(personaje.position);
            }
            else
            {
                agente.SetDestination(puntosRuta[indiceRuta].position);
            }
        }

        private void OnTriggerEnter2D(Collider2D obj)
        {
            if (obj.tag == "Player")
            {
                tiempoSigAtaque = frecAtaque;
                iniciaConteo = Time.time;
                obj.transform.GetComponentInChildren<VidasPlayer>().TomarDano(1);
            }
            else if(obj.CompareTag("arma"))
            {
                AtaquePlayer jugador = GameObject.FindWithTag("Player").GetComponentInChildren<AtaquePlayer>();
                int daño = jugador.dañoJugador;
                TomarDano(daño);
            }
    }

        public void TomarDano(int dano)
        {
            vidaEnemigo -= dano;
            if (vidaEnemigo <= 0)
            {
                Vector2 v2Prefab = this.transform.position;
                Instantiate(dropeable, v2Prefab, transform.rotation);
                Destroy(gameObject);
                }
        }

    public void Respawn(){
       
    }
}