using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movplayer : MonoBehaviour

{

private Vector2 dirMov;
public float velMov;
public Rigidbody2D rb;
public Animator anim;   
public bool puedeMoverse = true;

private string capaIdle = "Idle";
private string capaCaminar = "Caminar";
private bool PlayerMoviendose = false;
private float ultimoMovX, ultimoMovY;



public static int dirAtaque =0;


void FixedUpdate() {
    if (puedeMoverse)
        {
            Movimiento();
        }

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




        if (movX == -1){
            dirAtaque =3;
        }
        if (movX == 1){
            dirAtaque =4;
        }
        if (movY == -1){
            dirAtaque =1;
        }
        if (movY == 1){
            dirAtaque =2;
        }



        if(movX == 0 && movY == 0){//Idle
        PlayerMoviendose = false;
        
        }else {//Caminar
        PlayerMoviendose = true;
        ultimoMovX = movX;
        ultimoMovY = movY;

        }
        ActualizaCapa();

    }

   
     private void  Animacionesplayer()
    {
        anim.SetFloat("movX",ultimoMovX);
        anim.SetFloat("movY",ultimoMovY);
    }

     
     private void ActualizaCapa()
    {
        if (CCC.atacando == false && CAD.disparando == false){
            if (PlayerMoviendose) {
            activaCapa("Caminar");
            } else {
            activaCapa("Idle");
        } 
        } else {
            activaCapa("Ataque");
        }

    }

    private void activaCapa(string nombre)
    {
        for (int i=0; i < anim.layerCount; i++) {
            anim.SetLayerWeight(i,0);// ambos layers con weight en 0

        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre),1);

    }
    

}
