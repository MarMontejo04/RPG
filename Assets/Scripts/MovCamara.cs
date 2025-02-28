using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera camara;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "portal1") //Entrada a la aldea (escenario 2)
        {
            Vector3 posicionCamara = new Vector3(0, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(0, 8.21f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal2") //Regreso a escenario 1
        {
            Vector3 posicionCamara = new Vector3(0, -0.16f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(0, 2.97f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal3") // Entrada escenario 8
        {
            Vector3 posicionCamara = new Vector3(19.9f, 11.67f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(13.216f, 10.526f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal4") // Entrada escenario 6
        {
            Vector3 posicionCamara = new Vector3(0, 23.5f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(4.088f, 19.938f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal5") //Entrada a fabrica (escenario 3)
        {
            Vector3 posicionCamara = new Vector3(-19.86f, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-12.63f, 12.3f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal6") // Regreso a la aldea (escenario 2)
        {
            Vector3 posicionCamara = new Vector3(0, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-7.24f, 11.94f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal7") //Entrada escenario 5
        {
            Vector3 posicionCamara = new Vector3(-19.87f, 23.51f,-10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-17.32f,19.969f,0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal8") // Entraada ecenario 4
        {
            Vector3 posicionCamara = new Vector3(-19.85f, -0.16f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-17.28f, 3.44f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal9") //Regreso escenario 3
        {
            Vector3 posicionCamara = new Vector3(-19.86f, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-17.28f, 7.97f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal10") // Regreso escenario 3
        {
            Vector3 posicionCamara = new Vector3(-19.86f, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-17.32f, 14.98f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal11") // Entrada escenario 6
        {
            Vector3 posicionCamara = new Vector3(0, 23.5f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-7.075f, 22.45f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal12") // Regreso escenario 5
        {
            Vector3 posicionCamara = new Vector3(-19.87f, 23.51f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-12.81f, 22.38f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal13") // Regreso escenario 2
        {
            Vector3 posicionCamara = new Vector3(0, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(4.064f, 15.175f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal14") // Entrada escenario 7
        {
            Vector3 posicionCamara = new Vector3(19.9f, 23.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(12.679f, 26.916f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal15") // Regreso escenario 6
        {
            Vector3 posicionCamara = new Vector3(0, 23.5f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(7.1146f, 26.65f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal16") // Entrada escenario 8
        {
            Vector3 posicionCamara = new Vector3(19.9f, 11.67f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(17.99f, 14.85f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal17") // Regreso escenario 7
        {
            Vector3 posicionCamara = new Vector3(19.9f, 23.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(17.66f, 20.05f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal18") // Regreso escenario 2
        {
            Vector3 posicionCamara = new Vector3(0, 11.61f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(7.276f, 10.418f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal19") // Entrada escenario 9
        {
            Vector3 posicionCamara = new Vector3(19.9f, -0.2f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(20.39f, 3.237f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal20") // Regreso escenario 8
        {
            Vector3 posicionCamara = new Vector3(19.9f, 11.67f, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(20.39f, 8.258f, 0);
            this.transform.position = posicionPlayer;

        }
    }
}
