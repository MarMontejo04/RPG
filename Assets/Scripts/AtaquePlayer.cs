using System.Collections;
using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    private bool isAttacking;
    private bool Disparo;
    private float cooldownAtaque = 1f;
    private float tiempoUltimoAtaque = 0f;

    public GameObject flecha;
    public Animator anim;
    private Movplayer playerMovement;
    public int dañoJugador = 1;
    private GameObject Player;

    void Start()
    {
        playerMovement = GetComponent<Movplayer>();
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            if (EnergiaPlayer.energia > 0)
            {
                EnergiaPlayer.energia -= 10; 
                Player.GetComponent<EnergiaPlayer>().DibujaEnergia(EnergiaPlayer.energia);
            }
            Atacar();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (EnergiaPlayer.energia > 0)
            {
                EnergiaPlayer.energia -= 10; 
                Player.GetComponent<EnergiaPlayer>().DibujaEnergia(EnergiaPlayer.energia);
            }
            AtacarDistancia();
        }
    }

    private void Atacar()
    {
        if (isAttacking || Time.time < tiempoUltimoAtaque + cooldownAtaque) return;
        isAttacking = true;
        playerMovement.BloquearMovimiento(true);
        anim.SetBool("isAttacking", true);
        tiempoUltimoAtaque = Time.time;

    }

    private void AtacarDistancia()
    {
        if (Disparo || Time.time < tiempoUltimoAtaque + cooldownAtaque) return;
        Disparo = true;
        playerMovement.BloquearMovimiento(true);
        anim.SetBool("Disparo", true);
        tiempoUltimoAtaque = Time.time;
    }


    public void EndAttack()
    {
        isAttacking = false;
        Disparo = false;
        playerMovement.BloquearMovimiento(false); // 🚀 Libera movimiento
        anim.SetBool("isAttacking", false);
        anim.SetBool("Disparo", false);
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }

    public void MejorarDaño(int cantidad)
    {
        dañoJugador += cantidad;
        dañoJugador = Mathf.Clamp(dañoJugador, 1, 999); // evita que sea 0 o negativo
    }

    public void DisparoFlecha()
    {
        Vector2 direction = new Vector2(anim.GetFloat("movX"), anim.GetFloat("movY")).normalized;

        if (direction == Vector2.zero)
        {
            direction = Vector2.right; 
        }

        GameObject obj = Instantiate(flecha);

        obj.transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * 0.5f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        obj.transform.rotation = Quaternion.Euler(0, 0, angle);

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 10f;
        }
    }


}