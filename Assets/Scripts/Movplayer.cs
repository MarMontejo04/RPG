using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movplayer : MonoBehaviour

{

private Vector2 dirMov;
public float velMov;
public Rigidbody2D rb;
public Animator anim;    



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
    }

     private void  Animacionesplayer()
    {
        anim.SetFloat("movX",dirMov.x);
        anim.SetFloat("movY",dirMov.y);
    }
    

}
