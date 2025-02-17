using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera camara;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "portal1") //Entrada a la aldea
        {
            Vector3 posicionCamara = new Vector3(0, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(0, 8.21f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal2") //Regreso a escenario inicial
        {
            Vector3 posicionCamara = new Vector3(0, -0.16f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(0, 2.97f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal3")
        {
            Vector3 posicionCamara = new Vector3(1, 1, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(1, 1, 1);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal4")
        {
            Vector3 posicionCamara = new Vector3(1, 1, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(1, 1, 1);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal5") //Entrada a fabrica
        {
            Vector3 posicionCamara = new Vector3(-19.86f, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-12.63f, 12.3f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal6") // Regreso a la aldea
        {
            Vector3 posicionCamara = new Vector3(0, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-7.24f, 11.94f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal7")
        {
            Vector3 posicionCamara = new Vector3(1, 1, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(1, 1, 1);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal8")
        {
            Vector3 posicionCamara = new Vector3(-19.85f, -0.16f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-17.28f, 3.44f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal9")
        {
            Vector3 posicionCamara = new Vector3(-19.86f, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-17.28f, 7.97f, 0);
            this.transform.position = posicionPlayer;

        }

    }
}
