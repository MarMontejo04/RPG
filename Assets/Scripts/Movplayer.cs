using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movplayer : MonoBehaviour
{
    private Vector2 dirMov;
    public float velMov; 
    private float velMovOriginal; 
    public Rigidbody2D rb;
    public Animator anim;

    private string capaIdle = "Idle";
    private string capaCaminar = "Caminar";
    private string capaAtaque = "Ataque";
    private bool PlayerMoviendose = false;
    private float ultimoMovX, ultimoMovY;

    public static int dirAtaque = 0;

    void Start()
    {
        velMovOriginal = velMov;
    }

    void FixedUpdate()
    {
        Movimiento();

        if (CCC.atacando == false && CAD.disparando == false)
        {
            Animacionesplayer();
        }
    }

    private void Movimiento()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        dirMov = new Vector2(movX, movY).normalized;
        rb.linearVelocity = new Vector2(dirMov.x * velMov, dirMov.y * velMov);

        if (movX == -1)
        {
            dirAtaque = 3;
        }
        if (movX == 1)
        {
            dirAtaque = 4;
        }
        if (movY == -1)
        {
            dirAtaque = 1;
        }
        if (movY == 1)
        {
            dirAtaque = 2;
        }

        if (movX == 0 && movY == 0)
        { 
            PlayerMoviendose = false;
        }
        else
        { 
            PlayerMoviendose = true;
            ultimoMovX = movX;
            ultimoMovY = movY;
        }

        ActualizaCapa();
    }

    private void Animacionesplayer()
    {
        anim.SetFloat("movX", ultimoMovX);
        anim.SetFloat("movY", ultimoMovY);
    }

   private void ActualizaCapa()
{
    if (!CCC.atacando && !CAD.disparando) // Simplificado con "!"
    {
        if (PlayerMoviendose)
        {
            activaCapa("Caminar");
        }
        else
        {
            activaCapa("Idle");
        }
    }
    else  // ✅ Ahora el 'else' está correctamente colocado
    {
        activaCapa("Ataque");
    }
}


    private void activaCapa(string nombre)
    {
        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0);
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }

   
    public void ReducirVelocidad()
    {
        velMov = velMovOriginal * 0.3f; 
    }

    public void RestaurarVelocidad()
    {
        velMov = velMovOriginal; 
    }
}