using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movplayer : MonoBehaviour

{

private Vector2 dirMov;
public float velMov;
public Rigidbody2D rb;
public Animator anim;   

private string capaIdle = "Idle";
private string capaCaminar = "Caminar";
private bool PlayerMoviendose = false;
private float ultimoMovX, ultimoMovY;





void FixedUpdate() {
    Movimiento();
    Animacionesplayer();
}

    private void Movimiento()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        dirMov = new Vector2(movX, movY).normalized;
        rb.linearVelocity = new Vector2(dirMov.x * velMov, dirMov.y * velMov);

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
        if (PlayerMoviendose){
            activaCapa(capaCaminar);
            Debug.Log("Caminando");
        } else {
            activaCapa(capaIdle);
            Debug.Log("Idle");
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
